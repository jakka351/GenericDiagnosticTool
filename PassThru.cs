// /////////////////////////////////////////////////////////////////////////////
//   ________                           .__                          
//  /  _____/  ____   ____   ___________|__| ____                    
// /   \  ____/ __ \ /    \_/ __ \_  __ \  |/ ___\                   
// \    \_\  \  ___/|   |  \  ___/|  | \/  \  \___                   
//  \______  /\___  >___|  /\___  >__|  |__|\___  >                  
//         \/     \/     \/     \/              \/                   
// ________  .__                                      __  .__        
// \______ \ |__|____     ____   ____   ____  _______/  |_|__| ____  
//  |    |  \|  \__  \   / ___\ /    \ /  _ \/  ___/\   __\  |/ ___\ 
//  |    `   \  |/ __ \_/ /_/  >   |  (  <_> )___ \  |  | |  \  \___ 
// /_______  /__(____  /\___  /|___|  /\____/____  > |__| |__|\___  >
//         \/        \//_____/      \/           \/               \/  //Version 1.0.0
// 
using System;
using System.IO;
using System.Data;
using System.Text;
using System.Linq;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using J2534;
// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace PassThruJ2534
{

    // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public partial class PassThru : Form
    {
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public PassThru()
        {
            InitializeComponent();
        }
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Log(string m)
        {
            // Invoke required to marshal the call back to the UI thread
            if (textBoxLog.InvokeRequired)
            {
                textBoxLog.Invoke(new Action<string>(Log), m);
            }
            else
            {
                textBoxLog.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + "\r\n" + m);
                if (textBoxLog.Focused)
                {
                    textBoxLog.SelectionStart = textBoxLog.Text.Length;
                    textBoxLog.SelectionLength = 0;
                    textBoxLog.ScrollToCaret();
                }
            }
        }
        // //////////////////////////////////
        // Write CAN messages to textBoxCAN
        public void addTxtCAN(string m)
        {
            if (textBoxCAN.InvokeRequired)
            {
                textBoxCAN.Invoke(new Action<string>(addTxtCAN), m);
            }
            else

            {
                textBoxCAN.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) + " " + m);
                if (textBoxCAN.Focused)
                {
                    textBoxCAN.SelectionStart = textBoxCAN.Text.Length;
                    textBoxCAN.SelectionLength = 0;
                    textBoxCAN.ScrollToCaret();
                }
            }
        }
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //       ____.________   .________________     _____  
        //      |    |\_____  \  |   ____/\_____  \   /  |  | 
        //      |    | /  ____/  |____  \   _(__  <  /   |  |_
        //  /\__|    |/       \  /       \ /       \/    ^   /
        //  \________|\_______ \/______  //______  /\____   |  
        //   PassThru         \/       \/        \/      |__|
        //   
        class J2534_Struct
        {
            public J2534_Struct()
            {
                Functions = new J2534FunctionsExtended();
                LoadedDevice = new J2534Device();
            }
            public J2534.J2534FunctionsExtended Functions;
            public J2534.J2534Device LoadedDevice;
        }
        // //////////////////////////////////////////////////////////////////////////////////////
        private J2534_Struct J2534Port = new J2534_Struct();
        private uint DeviceID;//This is the unique ID of the J2534 that is used in all functions.
        public uint ChannelID;//This is the unqiue ID of the CHannel (Protocol) that we connect to
        public int FilterID; //This is the unique ID of the Filter we set (Every filter gets a ID, so you should make this a list to save them all if doing more then 1.
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void PassThru_Load(object sender, EventArgs e)
        {
            comboBoxJ2534Devices.Items.Clear();
            // ///////////////////////////////////////////////////
            //1) Search for all of our J2534 Devices
            List<J2534.J2534Device> MyListOfJ2534Devices = J2534DeviceFinder.FindInstalledJ2534DLLs();
            //List of devices installed on the PC
            for (int i = 0; i < MyListOfJ2534Devices.Count; i++)
            {
                string J2534ToolsName = MyListOfJ2534Devices[i].Name;
                comboBoxJ2534Devices.Items.Add(J2534ToolsName);
                Log("Found Installed Device: " + J2534ToolsName.ToString() + "\r\n");
            }

            if (comboBoxJ2534Devices.Items.Count > 0)
            {
                comboBoxJ2534Devices.SelectedIndex = 0;
            }
        }
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void CmdDetectDevicesClick(object sender, EventArgs e)
        {
            // ///////////////////////////////////////////////////
            //1) Search for all of our J2534 Devices
            List<J2534.J2534Device> MyListOfJ2534Devices = J2534DeviceFinder.FindInstalledJ2534DLLs();
            //List of devices installed on the PC
            for (int i = 0; i < MyListOfJ2534Devices.Count; i++)
            {
                string J2534ToolsName = MyListOfJ2534Devices[i].Name;
                comboBoxJ2534Devices.Items.Add(J2534ToolsName);
                Log("Found Installed Device: " + J2534ToolsName.ToString() + "\r\n");
            }
        }
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private Thread thread;
        private bool stopThread;
        bool connectFlag = false;
        bool highSpeedCan;
        byte ecuId;
        byte ecuId2;
        byte ecuId3;
        byte ecuId4;
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void buttonConnect(object sender, EventArgs e)
        {
            if (button1.Text == "Connect")
            {
                if(comboBoxCanBus.SelectedIndex == 0) {highSpeedCan = true;} else { highSpeedCan = false; }
                string hexString1 = textBoxEcuRx.Text;
                // Convert the hex string to an integer
                int intValue1 = Convert.ToInt32(hexString1, 16);
                // Extract the two bytes
                ecuId = (byte)((intValue1 >> 8) & 0xFF); // Extract 0x07
                ecuId2 = (byte)(intValue1 & 0xFF);          // Extract 0xE0
                string hexString2 = textBoxEcuTx.Text;
                // Convert the hex string to an integer
                int intValue2 = Convert.ToInt32(hexString2, 16);
                // Extract the two bytes
                ecuId4 = (byte)((intValue2 >> 8) & 0xFF); // Extract 0x07
                ecuId3 = (byte)(intValue2 & 0xFF);          // Extract 0xE0
                connectFlag = true;
                button1.BackColor = System.Drawing.Color.Crimson; // Change Connect BTN colour to RED      
                button1.Text = "Disconnect";                                                        //
                Log("Initialising Comms...\r\n");
                connectSelectedJ2534Device(ecuId, ecuId2, ecuId3, highSpeedCan);
            }
            else
            {
                connectFlag = false;
                button1.BackColor = System.Drawing.Color.MediumSeaGreen; // Change Connect BTN colour to RED       
                button1.Text = "Connect";                                                        //
                Log("Disconnected.\r\n");
                connectSelectedJ2534Device(ecuId, ecuId2, ecuId3, highSpeedCan);
            }

        }
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Connect the selected J2534 device from the comboBox
        private void connectSelectedJ2534Device(byte ecuId, byte ecuId2, byte ecuId3, bool highSpeed)
        {
            if(connectFlag = true)
            {
                List<J2534.J2534Device> MyListOfJ2534Devices = J2534DeviceFinder.FindInstalledJ2534DLLs();
                for (int i = 0; i < MyListOfJ2534Devices.Count; i++)
                {
                    string J2534ToolsName = MyListOfJ2534Devices[i].Name;
                    //comboBoxJ2534Devices.Items.Add(J2534ToolsName);
                    //Log("Found Installed Device: " + J2534ToolsName.ToString() + "\r\n");
                }

                // ///////////////////////////////////////////////////
                //2) Select our device and load the DLL into memory
                //Below is my fancy way of specificaly targeting a tool in the list based on its name.
                //J2534Port.LoadedDevice = MyListOfJ2534Devices.Where(x => x.Name == "CDR900").First(); //MyListOfJ2534Devices[0];
                J2534Port.LoadedDevice = MyListOfJ2534Devices[comboBoxJ2534Devices.SelectedIndex];
                if (J2534Port.Functions.LoadLibrary(J2534Port.LoadedDevice) == false)
                {
                    Log("Failed to load library DLL ERROR \r\n");
                    //Error here, DLL is fucked.
                }
                else
                {
                    Log("Library Loaded Succesfully \r\n");

                }
                Log("Selected Device: " + comboBoxJ2534Devices.SelectedItem.ToString() + "\r\n");  //get ti this point successfully
                // ///////////////////////////////////////////////////
                //3) Open the connection to the J2534 Tool
                var ErrorResult = J2534Port.Functions.PassThruOpen(IntPtr.Zero, ref DeviceID); //then error out here with invalid device number
                if (ErrorResult != J2534Err.STATUS_NOERROR)
                {
                    Log(ErrorResult.ToString() + "\r\n");
                    Log("PassThru Open ERROR) \r\n");
                }
                else
                {
                    Log("PassThru Open Success \r\n");
                }
                // ///////////////////////////////////////////////////////////////////
                //4) Start our OBD2 connection 
                //Use ProtocolID.ISO15765_PS if needing to connect to MS CAN. Have to pass the pins 3/11 to tell it to go to those.
                ushort psValue = 0x60E;
                if (highSpeedCan == true)
                {
                    ErrorResult = J2534Port.Functions.PassThruConnect(DeviceID, ProtocolID.ISO15765, ConnectFlag.NONE, BaudRate.CAN_500000, ref ChannelID);
                    if (ErrorResult != J2534Err.STATUS_NOERROR)
                    {
                        Log(ErrorResult.ToString() + "\r\n");
                        Log("PassThru Connect ERROR \r\n");
                    }
                    else
                    {
                        Log("PassThru Connect Success \r\n");
                    }
                    psValue = 0x60E;
                }
                if (highSpeedCan == false) // edited for bench rig
                {
                    //ErrorResult = J2534Port.Functions.PassThruConnect(DeviceID, ProtocolID.ISO15765, ConnectFlag.NONE, BaudRate.CAN_125000, ref ChannelID); //_PS
                    ErrorResult = J2534Port.Functions.PassThruConnect(DeviceID, ProtocolID.ISO15765_PS, ConnectFlag.NONE, BaudRate.CAN_125000, ref ChannelID); //_PS
                    if (ErrorResult != J2534Err.STATUS_NOERROR)
                    {
                        Log(ErrorResult.ToString() + "\r\n");
                        Log("PassThru Connect ERROR \r\n");
                    }
                    else
                    {
                        Log("PassThru Connect Success \r\n");
                    }
                    //psValue = 0x60E;
                    psValue = 0x30B; //0x30B for real world             

                }
                List<SConfig> configuration = new List<SConfig>();
                configuration.Add(new SConfig() { Parameter = ConfigParameter.J1962_PINS, Value = psValue }); //0x30B
                ErrorResult = J2534Port.Functions.SetConfig((int)ChannelID, ref configuration);
                if (ErrorResult != J2534Err.STATUS_NOERROR)
                {
                    Log(ErrorResult.ToString() + "\r\n");
                    Log("SConfig Pin Select ERROR \r\n");
                }
                else
                {
                    Log("SConfig Pin Select Success\r\n");
                }
                // //////////////////////////////////////////////////////////////
                //5) Set the OBD2 pins we are connecting to on the canbus line
                //Set pins if doing MSCAN or selecting the _PS channel (PS stands for Pin Select)
                //pins= 0x60E 'pin 6 for CAN H, pin 14 for CAN L
                //pins= 0x30B 'pin 3 for CAN H, pin 11 for CAN L

                ///////////////////////
                //6) Set Filters
                //A flow filter is whats required for ending multi line messages. Pass is for sending just individual messages.
                PassThruMsg maskMsg = new PassThruMsg(ProtocolID.ISO15765, TxFlag.NONE, new byte[] { 0, 0, 07, 0xFF }); //Set mask of 7FF (Only accept the exact PATTERN
                PassThruMsg patternMsg = new PassThruMsg(ProtocolID.ISO15765, TxFlag.NONE, new byte[] { 0, 0, ecuId, ecuId3 }); //Search for 7E8
                PassThruMsg flowMsg = new PassThruMsg(ProtocolID.ISO15765, TxFlag.NONE, new byte[] { 0, 0, ecuId, ecuId2 }); //Use the flow message of 7E0
                IntPtr maskPtr = maskMsg.ToIntPtr();
                IntPtr PatternPtr = patternMsg.ToIntPtr();
                IntPtr FlowPtr = flowMsg.ToIntPtr();
                ErrorResult = J2534Port.Functions.PassThruStartMsgFilter((int)ChannelID, FilterType.FLOW_CONTROL_FILTER, maskPtr, PatternPtr, FlowPtr, ref FilterID);
                if (ErrorResult != J2534Err.STATUS_NOERROR)
                {
                    Log(ErrorResult.ToString() + "\r\n");
                    //Shits fucked, couldnt set required folter
                }
                else
                {
                    Log("Control Module Start Message Filter Success \r\n");
                }

                //ALWAYS do this after all commands that use a INTPTR so that it releases any used memory/ram by that variable.
                Marshal.FreeHGlobal(maskPtr);
                Marshal.FreeHGlobal(PatternPtr);
                Marshal.FreeHGlobal(FlowPtr);
            }
            if(!connectFlag)
            {
                var ErrorResult = J2534Port.Functions.PassThruDisconnect((int)ChannelID);
                if (ErrorResult != J2534Err.STATUS_NOERROR)
                {
                    Log(ErrorResult.ToString() + "\r\n");
                    Log("PassThru Disconnect ERROR \r\n");
                }
                else
                {
                    Log("PassThru Disconnected.\r\n");
                }
                ErrorResult = J2534Port.Functions.PassThruClose(DeviceID); ;
                if (ErrorResult != J2534Err.STATUS_NOERROR)
                {
                    Log(ErrorResult.ToString() + "\r\n");
                    Log("PassThru Disconnect ERROR \r\n");
                }
                else
                {
                    Log("PassThru Library Closed. \r\n");
                }
                return;             

            }
        }

        private void comboBoxCanBus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void DSC_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        // ADD MSG BUTTON CODE
        private void button6_Click(object sender, EventArgs e)
        {
            // Check if the textbox is not empty
            if (!string.IsNullOrWhiteSpace(textBoxPassThruMsg.Text))
            {
                // Add the text from the TextBox to the ListBox
                listBox1.Items.Add(textBoxPassThruMsg.Text);
                // Optionally clear the TextBox after adding
                textBoxPassThruMsg.Clear();
            }
            else
            {
                MessageBox.Show("Please input a diagnostic message into the textbox to add it to the send list.");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            bruteforce();
        }
        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //       ____.________   .________________     _____  
        //      |    |\_____  \  |   ____/\_____  \   /  |  | 
        //      |    | /  ____/  |____  \   _(__  <  /   |  |_
        //  /\__|    |/       \  /       \ /       \/    ^   /
        //  \________|\_______ \/______  //______  /\____   |  Send PassThru Message
        //                    \/       \/        \/      |__| 
        // ///////////////////////////////////////////////////
        private string sendPassThruMsg(byte[] frame)
        {
            // ///////////////////////////////////////
            // ///////////////////////////////////////////////////////////////////
            //7) Write a message
            int NumberOfMsgs = 1;
            //new byte[] { 0, 0, 0, canId1, canId2, data0, data1, data2, data3, data4, data5, data6, data7 }
            //byte[] tempframe = new byte[] { 0, 0, 0x7, 0xDF, 4 }; //this equals 7DF 01 04  00 00 00 00 00 00 (Rest of 00's is just filler bytes to make up full 8 byte frame).
            PassThruMsg WriteMsg = new PassThruMsg(ProtocolID.ISO15765, TxFlag.ISO15765_FRAME_PAD, frame); //Send 7E0 mode 1 table C. SAE REQUEST.
            IntPtr WritePtr = WriteMsg.ToIntPtr();
            var ErrorResult = J2534Port.Functions.PassThruWriteMsgs((int)ChannelID, WritePtr, ref NumberOfMsgs, 0);//timeout of 0 means just send it and dont care how long.
            if (ErrorResult != J2534Err.STATUS_NOERROR)
            {
                Log(ErrorResult.ToString() + "\r\n");
                //Shits fucked, fauled writing.
            }
            else
            {
                //1("PassThru Write Msg Success \r\n");
            }
            // ///////////////////////////////////////////////////////////////
            //8) Read Respnse
            bool SearchForResponse = true;
            while (SearchForResponse == true)
            {
                int NumReadMsgs = 1;
                IntPtr MyRXMsg = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(PassThruMsg)) * NumReadMsgs);
                ErrorResult = J2534Port.Functions.PassThruReadMsgs((int)ChannelID, MyRXMsg, ref NumReadMsgs, 2000); //this is your timeout here.
                if (ErrorResult != J2534Err.STATUS_NOERROR) //if no frames received, it goes here.
                {
                    Log(ErrorResult.ToString() + "\r\n");
                    Log("Failed to read PassThru Msg \r\n");
                    //Shits fucked, fauled reading!!!
                    break;
                }
                else
                {
                    //1("PassThru Read Msg Success \r\n");
                }
                //Convert the memory pointer back to a PassThruMsg Object
                PassThruMsg FoundFrame = MyRXMsg.AsMsgList(1).Last();
                if (((int)FoundFrame.RxStatus == ((int)J2534.RxStatus.TX_INDICATION_SUCCESS ^ (int)J2534.RxStatus.TX_MSG_TYPE)) ||
                    ((int)FoundFrame.RxStatus == ((int)J2534.RxStatus.TX_INDICATION_SUCCESS ^ (int)J2534.RxStatus.TX_MSG_TYPE ^ (int)J2534.RxStatus.ISO15765_ADDR_TYPE)) ||
                    ((int)FoundFrame.RxStatus == ((int)J2534.RxStatus.START_OF_MESSAGE))
                    )
                {
                    //We dont want any of this, continue!
                    Marshal.FreeHGlobal(MyRXMsg);
                    continue;
                }
                Marshal.FreeHGlobal(MyRXMsg);
                //This should have our bytes!
                byte[] MyRXDBytes = FoundFrame.GetBytes();
                string DataToString = "";
                for (int i = 0; i < MyRXDBytes.Length; i++)
                {
                    DataToString += MyRXDBytes[i].ToString("X2") + "  ";
                }
                Log("Rx: " + DataToString + "\r\n");
                return DataToString;
            }
            string noData = "No Data";
            return noData;
        }

        public static byte[] StringToByteArray(string input)
        {
            // Ensure even number of characters by padding if necessary
            if (input.Length % 2 != 0)
            {
                input = "0" + input;
            }
            // Prepare the byte array
            byte[] byteArray = new byte[input.Length / 2];
            for (int i = 0; i < input.Length; i += 2)
            {
                // Take two characters at a time and convert them to a byte
                string hexPair = input.Substring(i, 2);
                byteArray[i / 2] = Convert.ToByte(hexPair, 16);
            }
            return byteArray;
        }

        public void buttonSendPassThruMsg_Click(object sender, EventArgs e)
        {
            string message = listBox1.SelectedItem.ToString();
            message = message.Replace(" ", "");
            byte[] byteMsg = StringToByteArray(message);  // Your byte array from the string
            byte[] byteEcuId = new byte[] { 0, 0, ecuId, ecuId2 };  // Your ECU ID byte arra
            // Create a new byte array with enough space to hold both arrays
            byte[] combinedArray = new byte[byteMsg.Length + byteEcuId.Length];
            // Copy byteMsg into the new array
            Array.Copy(byteMsg, 0, combinedArray, 0, byteMsg.Length);
            // Copy byteEcuId into the new array, starting right after the byteMsg
            Array.Copy(byteEcuId, 0, combinedArray, byteMsg.Length, byteEcuId.Length);
            sendPassThruMsg(combinedArray);
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //DIAG SESS CONTROL BTN
            int sessionType = comboBoxDiagSessControl.SelectedIndex;
            switch(sessionType) 
            {
                case 0x00:
                    startDiagnosticSession(0x81);
                    break;
                case 0x01:
                    startDiagnosticSession(0x85);
                    break;
                case 0x02:
                    startDiagnosticSession(0x87);
                    break;
                case 0x03:
                    startDiagnosticSession(0xFE);
                    break;
                case 0x04:
                    startDiagnosticSession(0xFA);
                    break;
                case 0x05:
                    startDiagnosticSession(0x81);
                    break;
                case 0x06:
                    startDiagnosticSession(0x02);
                    break;
                case 0x07:
                    startDiagnosticSession(0x03);
                    break;
                case 0x08:
                    startDiagnosticSession(0x04);
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //ECU RESET BTN
            int resetType = comboBoxEcuReset.SelectedIndex;
            switch(resetType)
            {
                case 0x00:
                    ecuReset(0x01);
                    break;
                case 0x01:
                    ecuReset(0x02);
                    break;
                case 0x02:
                    ecuReset(0x03);
                    break;
                case 0x03:
                    ecuReset(0x04);
                    break;
                case 0x04:
                    ecuReset(0x05);
                    break;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //CONTROL DTC BTN
            int onOff = comboBoxControlDtc.SelectedIndex;
            switch(onOff)
            {
                case 0x00:
                    controlDtcSetting(0x01);
                    break;
                case 0x01:
                    controlDtcSetting(0x02);
                    break;
            }
        }

        private void tabPage8_Click(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {
            mode07();
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            mode09();
        }
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////
		void mode01()
		{
			// service $01 PIDS 0x00-0xC8
			textBoxPid.Text = "";
			textBoxPidName.Text = "";
			string selectedPid = comboBoxPids.SelectedItem.ToString();
			textBoxPidName.Text += selectedPid;
			var selectedPidHex = selectedPid.Substring(0, 2);
			byte pid = Convert.ToByte(selectedPidHex, 16);
			byte[] mode01 = new byte[] { 0, 0, 0x7, 0xDF, 0x01, pid };
			string pidDataRaw = sendPassThruMsg(mode01);
			// 00  00  07  E8  41  01  00  07  61  61  
			string pidDataInter = pidDataRaw.Replace(" ", "");
			//string pidData = pidDataInter.Substring(12, 8);
			textBoxPid.Text += pidDataInter;
			
		}
		void mode02()
		{
			// service $02 PIDS 0x00-0xC8
			textBoxPid.Text = "";
			textBoxPidName.Text = "";
			string selectedPid = comboBoxPids.SelectedItem.ToString();
			textBoxPidName.Text += selectedPid;
			var selectedPidHex = selectedPid.Substring(0, 2);
			byte pid = Convert.ToByte(selectedPidHex, 16);
			byte[] mode01 = new byte[] { 0, 0, 0x7, 0xDF, 0x02, pid };
			string pidDataRaw = sendPassThruMsg(mode01);
			// 00  00  07  E8  41  01  00  07  61  61  
			string pidDataInter = pidDataRaw.Replace(" ", "");
			//string pidData = pidDataInter.Substring(12, 8);
			textBoxPid.Text += pidDataInter;
		}
		void mode03()
		{
			// service $03 Read DTC
			listBoxDtc.Items.Remove(1);
			byte[] mode03 = new byte[] { 0, 0, 0x7, 0xDF, 0x03 };
			string dtcMsg = sendPassThruMsg(mode03);
			string dtcMsgInter = dtcMsg.Replace(" ", "");
			string dtcMsgInter2 = dtcMsgInter.Substring(10, 2);
			int dtc = int.Parse(dtcMsgInter2);
			if (dtc == 0)
			{
				listBoxDtc.Items.Add("No Fault Codes");
			}

		}
		void mode04()
		{
			// service $04 clear DTC
			listBoxDtc.Items.Remove(1);
			byte[] mode04 = new byte[] { 0, 0, 0x7, 0xDF, 0x04 };
			sendPassThruMsg(mode04);
			listBoxDtc.Items.Add("Faults Cleared");
		}
		void mode05()
		{
			// service $05  Test results, oxygen sensor monitoring PIDS 0x0100-0x210
			byte[] mode05 = new byte[] { 0, 0, 0x7, 0xDF, 0x05, 0x01, 0x00 };
			sendPassThruMsg(mode05);

		}
		void mode06()
		{
			byte[] mode06 = new byte[] { 0, 0, 0x7, 0xDF, 0x06 };
			sendPassThruMsg(mode06);
		}
		void mode07()
		{
			byte[] mode07 = new byte[] { 0, 0, 0x7, 0xDF, 0x07 };
			sendPassThruMsg(mode07);
		}
		void mode08()
		{
			byte[] mode08 = new byte[] { 0, 0, 0x7, 0xDF, 0x08 };
			sendPassThruMsg(mode08);
		}
		void mode09()
		{
			textBoxVin.Text = "";
			textBoxCalId.Text = "";
			//textBoxEcuName.Text = "";
			//service $09 Request Vehicle Information PIDS 0x00-0x0B
			// 00	4	Service 9 supported PIDs ($01 to $20)				Bit encoded. [A7..D0] = [PID $01..PID $20] See below
			// 01	1	VIN Message Count in PID 02. Only for ISO 9141-2, ISO 14230-4 and SAE J1850.				
			// 02	17	Vehicle Identification Number (VIN)				17-char VIN, ASCII-encoded and left-padded with null chars (0x00) if needed to.
			byte[] mode0902 = new byte[] { 0, 0, 0x7, 0xDF, 0x09, 0x02 };
			string vehicleIdentificationNumberMsg = sendPassThruMsg(mode0902);
			//string test = "00 00 07 E8 49 02 01 36 46 50 41 41 41 4A 47 53 57 36 4A 38 30 35 30 31";
			string interVin = vehicleIdentificationNumberMsg.Replace(" ", "");
			string interVin2 = interVin.Substring(14);
			string finalVin = HexToASCII(interVin2);
			textBoxVin.Text += finalVin;
			// 03	1	Calibration ID message count for PID 04. Only for ISO 9141-2, ISO 14230-4 and SAE J1850.			
			// 04	16,32,48,64..	Calibration ID				Up to 16 ASCII chars. Data bytes not used will be reported as null bytes (0x00). Several CALID can be outputed (16 bytes each)
			byte[] mode0904 = new byte[] { 0, 0, 0x7, 0xDF, 0x09, 0x04 };
			string calibrationIdMsg = sendPassThruMsg(mode0904);
			// string 00  00  07  E8  49  04  01  20  20  20  48  41  43  43  4B  47  41  2E  48  45  58  00  00 
			string interCalId = calibrationIdMsg.Replace(" ", "");
			string interCalId2 = interCalId.Substring(20);
			string finalCalId = HexToASCII(interCalId2);
			textBoxCalId.Text += finalCalId;
			// 05	1	Calibration verification numbers (CVN) message count for PID 06. Only for ISO 9141-2, ISO 14230-4 and SAE J1850.				
			// 06	4,8,12,16	Calibration Verification Numbers (CVN) Several CVN can be output (4 bytes each) the number of CVN and CALID must match			
			byte[] mode0906 = new byte[] { 0, 0, 0x7, 0xDF, 0x09, 0x06 };
			string calibrationVerificationMsg = sendPassThruMsg(mode0906);
			// 07	1	In-use performance tracking message count for PID 08 and 0B. Only for ISO 9141-2, ISO 14230-4 and SAE J1850.	
			// 08	4	In-use performance tracking for spark ignition vehicles				
			// 09	1	ECU name message count for PID 0A				
			// 0A	20	ECU name				ASCII-coded. Right-padded with null chars (0x00).
			byte[] mode090A = new byte[] { 0, 0, 0x7, 0xDF, 0x09, 0x0A };
			string ecuNameMsg = sendPassThruMsg(mode090A);
			// 0B	4	In-use performance tracking for compression ignition vehicles				
		}
		void mode0A()
		{
			byte[] mode0A = new byte[] { 0, 0, 0x7, 0xDF, 0x0A };
			sendPassThruMsg(mode0A);
		}

        private void button16_Click(object sender, EventArgs e)
        {
            mode03();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            mode04();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            mode0A();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            mode01();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            mode02();
        }
        private void listBoxObd_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Service / Mode $01 Live Sensor Data
            //Service / Mode $02 Freeze Frame Data
            //Service / Mode $03 Stored Fault Codes
            //Service / Mode $04 Clear Stored Codes
            //Service / Mode $05 Oxygen Sensor Monitor
            //Service / Mode $06 Monitoring Results
            //Service / Mode $07 Pending Fault Codes
            //Service / Mode $08 Test Device Control
            //Service / Mode $09 Vehicle Information
            //Service / Mode $0A Permanent Fault Codes
            switch (listBoxObd.SelectedIndex)
            {
                case 0x00:
                    Log("Mode $01 Live Sensor Data\r\n");
                    mode01();
                    break;
                case 0x01:
                    Log("Mode $02 Freeze Frame Data\r\n");
                    mode02();
                    break;
                case 0x02:
                    Log("Mode $03 Stored Fault Codes\r\n");
                    mode03();
                    break;
                case 0x03:
                    Log("Clear Stored Codes\r\n");
                    mode04();
                    break;
                case 0x04:
                    Log("Mode $05 Oxygen Sensor Monitor\r\n");
                    mode05();
                    break;
                case 0x05:
                    Log("Mode $06 Monitoring Results\r\n");
                    mode06();
                    break;
                case 0x06:
                    Log("Mode $07 Pending Fault Codes\r\n");
                    mode07();
                    break;
                case 0x07:
                    Log("Mode $08 Test Device Control\r\n");
                    mode08();
                    break;
                case 0x08:
                    Log("Mode $09 Vehicle Information\r\n");
                    mode09();
                    break;
                case 0x09:
                    Log("Mode $0A Permanent Fault Codes\r\n");
                    mode0A();
                    break;
            }
        }
        // //////////////////////////////////
        static string HexToASCII(string hexString)
        {
            byte[] bytes = new byte[hexString.Length / 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }
            return Encoding.ASCII.GetString(bytes);
        }

        private void bruteforceSecurityAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bruteforce();
        }

        private void readOBDDTCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode03();
        }

        private void clearOBD2DTCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode04();
        }

        private void requestVehicleVINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mode09();
        }
        // /////////////////////////////////////////////////////////////////////////////
        // Read All PassThru Messages 
        public void readAllMsgs()
        {

            List<J2534.J2534Device> MyListOfJ2534Devices = J2534DeviceFinder.FindInstalledJ2534DLLs();
            for (int i = 0; i < MyListOfJ2534Devices.Count; i++)
            {
                string J2534ToolsName = MyListOfJ2534Devices[i].Name;
                //comboBoxJ2534Devices.Items.Add(J2534ToolsName);
                //addTxtLog("Found Installed Device: " + J2534ToolsName.ToString() + "\r\n");
            }
			//A flow filter is whats required for ending multi line messages. Pass is for sending just individual messages.
            PassThruMsg maskMsg1 = new PassThruMsg(ProtocolID.ISO15765, TxFlag.NONE, new byte[] { 0, 0, 0x00, 0x00 }); //Set mask of 7FF (Only accept the exact PATTERN
            PassThruMsg patternMsg1 = new PassThruMsg(ProtocolID.ISO15765, TxFlag.NONE, new byte[] { 0, 0, 07, 0xFF }); //Search for 7E8
            PassThruMsg flowMsg1 = new PassThruMsg(ProtocolID.ISO15765, TxFlag.NONE, new byte[] { 0, 0, 07, 0xE0 }); //Use the flow message of 7E0
            IntPtr maskPtr1 = maskMsg1.ToIntPtr();
            IntPtr PatternPtr1 = patternMsg1.ToIntPtr();
            IntPtr FlowPtr1 = IntPtr.Zero;
            var ErrorResult = J2534Port.Functions.PassThruStartMsgFilter((int)ChannelID, FilterType.PASS_FILTER, maskPtr1, PatternPtr1, FlowPtr1, ref FilterID);
            if (ErrorResult != J2534Err.STATUS_NOERROR)
            {
                Log(ErrorResult.ToString() + "\r\n");
                Log("Failed to set filters ERROR");
            }
            else
            {
                Log("PassThru Start Message Filter Success \r\n");
            }
            //ALWAYS do this after all commands that use a INTPTR so that it releases any used memory/ram by that variable.
            Marshal.FreeHGlobal(maskPtr1);
            Marshal.FreeHGlobal(PatternPtr1);
            Marshal.FreeHGlobal(FlowPtr1);

            // ///////////////////////////////////////////////////////////////
            // PassThruReadMsgs(int channelId, IntPtr msgs, ref int numMsgs, int timeout);
            //8) Read Respnse
            int timeout = 60;
            while (stopThread == false)
            {
                int NumReadMsgs = 1;
                IntPtr MyRXMsg = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(PassThruMsg)) * NumReadMsgs);
                ErrorResult = J2534Port.Functions.PassThruReadMsgs((int)ChannelID, MyRXMsg, ref NumReadMsgs, timeout);
                if (ErrorResult != J2534Err.STATUS_NOERROR)
                {
                    Log(ErrorResult.ToString() + "\r\n");
                    Log("Failed to read PassThru Message \r\n");
                    //Shits fucked, fauled reading!!!
                    break;
                }
                else
                {
                    Log("PassThru Read Message Success \r\n");
                }
                //Convert the memory pointer back to a PassThruMsg Object
                PassThruMsg FoundFrame = MyRXMsg.AsMsgList(1).Last();
                if (((int)FoundFrame.RxStatus == ((int)J2534.RxStatus.TX_INDICATION_SUCCESS ^ (int)J2534.RxStatus.TX_MSG_TYPE)) ||
                    ((int)FoundFrame.RxStatus == ((int)J2534.RxStatus.TX_INDICATION_SUCCESS ^ (int)J2534.RxStatus.TX_MSG_TYPE ^ (int)J2534.RxStatus.ISO15765_ADDR_TYPE)) ||
                    ((int)FoundFrame.RxStatus == ((int)J2534.RxStatus.START_OF_MESSAGE))
                    )
                {
                    //We dont want any of this, continue!
                    Marshal.FreeHGlobal(MyRXMsg);
                    continue;
                }
                Marshal.FreeHGlobal(MyRXMsg);
                //This should have our bytes!
                byte[] MyRXDBytes = FoundFrame.GetBytes();
                string DataToString = "";
                for (int i = 0; i < MyRXDBytes.Length; i++)
                {
                    DataToString += MyRXDBytes[i].ToString("X2") + "  ";
                    //addTxtLog("PassThru Msg Rx: " + DataToString + "\r\n");
                }
                addTxtCAN("PassThru Msg Rx: " + DataToString + "\r\n");
                string JustForBreakpoint = "";
            }
            return;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            startReadAllPassThruMsgsButton.Enabled = false;
            stopThread = false;
            thread = new Thread(readAllMsgs);
            thread.Start();
            //readAllMsgs();
            return;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            using (var saveFileDialog1 = new SaveFileDialog())
            {
                saveFileDialog1.Filter = "log files (*.log)|*.log";
                saveFileDialog1.FilterIndex = 2;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName, textBoxCAN.Text);
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            stopThread = true;
            startReadAllPassThruMsgsButton.Enabled = true;
        }
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
