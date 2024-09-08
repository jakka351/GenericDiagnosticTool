using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;
using System.Collections;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Diagnostics;
using System.Reflection;
using J2534;
using System.Linq;
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
        public void Log(string m)
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
                if(comboBoxCanBus.SelectedIndex == 0) {highSpeedCan = true;}
                else { highSpeedCan = false; }
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
                if (highSpeed == true)
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
        string sendPassThruMsg(byte[] frame)
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
    }
}
