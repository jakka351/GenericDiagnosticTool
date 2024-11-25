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
using J2534;
using System;
using System.IO;
using System.Net;
using System.Data;
using System.Text;
using System.Linq;
using System.Drawing;
using System.IO.Pipes;
using System.IO.Ports;
using System.Threading;
using System.Reflection;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;
using System.Globalization;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.ConstrainedExecution;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
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
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        

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
        //TESTER PRESENT SIGNAL START BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            timerTesterPresent.Enabled = true;
            buttonStopTester.Enabled = true;
            buttonTester.Enabled = false;
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
        //bruteforce 0x27 button click
        private void button6_Click_1(object sender, EventArgs e)
        {
            switch (comboBoxSess.SelectedIndex)
            {
                case 0:
                    startDiagnosticSession(0x81);
                    break;
                case 1:
                    startDiagnosticSession(0x85);
                    break;
                case 2:
                    startDiagnosticSession(0x87);
                    break;
                case 3:
                    startDiagnosticSession(0xFE);
                    break;
                case 4:
                    startDiagnosticSession(0xFA);
                    break;
                case 5:
                    startDiagnosticSession(0x01);
                    break;
                case 6:
                    startDiagnosticSession(0x02);
                    break;
                case 7:
                    startDiagnosticSession(0x03);
                    break;
                case 8:
                    startDiagnosticSession(0x04);
                    break;

            }
            bruteforce();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void buttonConnect(object sender, EventArgs e)
        {
            if (button1.Text == "Connect")
            {
                if (comboBoxCanBus.SelectedIndex == 0) { highSpeedCan = true; } else { highSpeedCan = false; }
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
        

        private void bruteforceSecurityAccessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
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
        //GET VIN NUMBER BTN
        private void button10_Click(object sender, EventArgs e)
        {
            //textBoxInterVin.Text = "";
            //byte[] mode0902 = new byte[] { 0, 0, 0x7, 0xDF, 0x09, 0x02 };
            //string vehicleIdentificationNumberMsg = sendPassThruMsg(mode0902);
            //string test = "00 00 07 E8 49 02 01 36 46 50 41 41 41 4A 47 53 57 36 4A 38 30 35 30 31";
            //string interVin = vehicleIdentificationNumberMsg.Replace(" ", "");
            //string interVin2 = interVin.Substring(14);
            //string finalVin = HexToASCII(interVin2);
            //textBoxInterVin.Text += finalVin;
            string finalVin = textBoxInterVin.Text; // FOR TESTING THE VIN NUMEBR DISPLAY I HAVE DISABLED THE REQUEST VIN MESSAGE AND LOGIC
            t0.Text = finalVin.Substring(0, 1);
            t1.Text = finalVin.Substring(1, 1);
            t2.Text = finalVin.Substring(2, 1);
            t3.Text = finalVin.Substring(3, 1);
            t4.Text = finalVin.Substring(4, 1);
            t5.Text = finalVin.Substring(5, 1);
            t6.Text = finalVin.Substring(6, 1);
            t7.Text = finalVin.Substring(7, 1);
            t8.Text = finalVin.Substring(8, 1);
            t9.Text = finalVin.Substring(9, 1);
            t10.Text = finalVin.Substring(10, 1);
            t11.Text = finalVin.Substring(11, 1);
            t12.Text = finalVin.Substring(12, 1);
            t13.Text = finalVin.Substring(13, 1);
            t14.Text = finalVin.Substring(14, 1);
            t15.Text = finalVin.Substring(15, 1);
            t16.Text = finalVin.Substring(16, 1);



        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            string vin = textBoxInterVin.Text.ToUpper();
            //string vin = txtVIN.Text.ToUpper();
            if (vin.Length != 17)
            {
                MessageBox.Show("VIN must be 17 characters long.");
                return;
            }
            // Decoding each section of the VIN
            labelWmi.Text = PassThruJ2534.lib.Decoder.VIN_DECODER.DecodeWMI(vin.Substring(0, 3));     // World Manufacturer Identifier
            labelVd.Text = PassThruJ2534.lib.Decoder.VIN_DECODER.DecodeVDS(vin.Substring(3, 6));     // Vehicle Descriptor Section
            labelSn.Text = PassThruJ2534.lib.Decoder.VIN_DECODER.DecodeVIS(vin.Substring(9, 8));     // Vehicle Identifier Section

        }

        private void textBoxInterVin_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            string vin = textBoxInterVin.Text.ToUpper();
            //string vin = txtVIN.Text.ToUpper();
            if (vin.Length != 17)
            {
                MessageBox.Show("VIN must be 17 characters long.");
                return;
            }
            // Decoding each section of the VIN
            labelWmi.Text = PassThruJ2534.lib.Decoder.VIN_DECODER.DecodeWMI(vin.Substring(0, 3));     // World Manufacturer Identifier
            labelVd.Text = PassThruJ2534.lib.Decoder.VIN_DECODER.DecodeVDS(vin.Substring(3, 6));     // Vehicle Descriptor Section
            labelSn.Text = PassThruJ2534.lib.Decoder.VIN_DECODER.DecodeVIS(vin.Substring(9, 8));     // Vehicle Identifier Section
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage9_Click(object sender, EventArgs e)
        {
            
        }

        private void label22_Click(object sender, EventArgs e)
        { 
        
        }
        bool flagNoDataAbort;
        
        // 0x23 Direct Memory Read readMemoryByAddress
        private void button20_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Binary Files (*.bin)|*.bin",
                Title = "Generic Diagnostic Tool | 0x23 Read Memory By Address | Save File",
                DefaultExt = "bin",
                FileName = "Direct Memory Read.bin"
            };

            // Show SaveFileDialog and check if the user selected a file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Open a file stream to save the binary data
                    using (FileStream fileStream = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                    {
                        // Declare variables
                        byte[] memory;
                        uint startAddress = Convert.ToUInt32(textBoxStartAddress.Text, 16);
                        uint finishAddress = Convert.ToUInt32(textBoxFinishAddress.Text, 16);
                        uint blockSize = Convert.ToUInt32(textBoxBlockSize.Text, 16);
                        // Loop through memory addresses and read data
                        for (uint i = startAddress; i <= finishAddress; i += blockSize)
                        {
                            // Read memory block by address
                            memory = readMemoryByAddress(i, blockSize);
                            // Write the memory block to the file
                            fileStream.Write(memory, 0, memory.Length);
                            // Check for specific address (if required)
                            if (i == 0x100000)
                            {
                                MessageBox.Show("Direct Memory Read saved successfully!", "Generic Diagnostic Tool | Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Save operation canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEcuRx_TextChanged(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void tabPage12_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// BRUTEFORCE DID's with service 0x22 readDataByCommonId
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button22_Click(object sender, EventArgs e)
        {
            try
            { 
                for (int did = 0x0000; did <= 0xFFFF; did++)
                {
                    int response = 0;
                    // Extract upper and lower byte of the DID
                    byte upperByte = (byte)((did >> 8) & 0xFF);  // Upper byte of the DID
                    byte lowerByte = (byte)(did & 0xFF);         // Lower byte of the DID
                    // Send the PassThru message with the current DID
                    byte[] array = { 0, 0, ecuId, ecuId2, 0x22, upperByte, lowerByte };
                    string did1 = sendPassThruMsg(array); did1 = did1.Replace(" ", ""); string didFound = did1.Substring(10, 4);
                    //  00  00  07  2F  62  FF FF 
                    response = int.Parse(did1.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
                    switch (response)
                    {
                        case 0x62:
                            Log("Data Identifier Located @ " + did.ToString() + "\r\n");
                            listBox2.Items.Add(didFound);
                            break;
                        case 0x7F:
                            Log($"No Data Identifer found at" + did.ToString());
                            break;
                        default:
                            Log("No Response from ECU \r\n");
                            break;
                    }
                    if (did1.Contains("62"))
                    {
                        Log("Data Identifier Found!");
                        // create a DID variable here that goes into a list
                    }
                    else if(did1.Contains("7F"))
                    {
                        
                    }

                    // Optionally, you can add a delay or log the progress here
                    // Thread.Sleep(10);  // Adding a short delay if necessary
                    // Console.WriteLine($"Sent DID: 0x{did:X4}");
                }
            }
            catch(Exception)
            {
                Log("An Exception Occured with the DID Bruteforce attempt. \r\n");
                return;
            }

        }
        /// <summary>
        /// Request a Single DID in hex form using service 0x22
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // Retreive Single DID
        private void button23_Click(object sender, EventArgs e)
        {
            string did = textBoxDid.Text;
            // Convert the first two characters to a byte (0xFF)
            byte upperByte = Convert.ToByte(did.Substring(0, 2), 16);
            // Convert the last two characters to a byte (0xFF)
            byte lowerByte = Convert.ToByte(did.Substring(2, 2), 16);

            byte[] array = { 0x00, 0x00, ecuId, ecuId2, 0x22, upperByte, lowerByte };
            sendPassThruMsg(array);


        }

        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        // Load the service 0x22 ListBox and disable the default listbox when 0x22 Tab is selected
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TABCNTRL1.SelectedTab == READDATABYCOMMONID) // Check if the selected tab is Tab 2
            {
                listBox1.Visible = false;
                textBoxPassThruMsg.Visible = false;
                buttonAddMsg.Visible = false;
                buttonSendPassThruMsg.Visible = false;
                labelPTMsg.Visible = false;
                listBox2.Visible = true;
                labelDid.Visible = true;
            }
            else
            {
                listBox1.Visible = true;
                textBoxPassThruMsg.Visible = true;
                buttonAddMsg.Visible = true;
                buttonSendPassThruMsg.Visible = true;
                labelPTMsg.Visible = true;
                listBox2.Visible = false;
                labelDid.Visible = false;

            }
        }
        private Dictionary<string, string> definitions;

        //DID LOOKUP TABLE
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Initialize the dictionary with items and definitions
            definitions = new Dictionary<string, string>
            {
                { "0102",   "Air Cleaner Housing DoorFlap Control" },
                { "FA07",   "Dismantler Information" }
            };
            // Get the selected item from the ListBox
            string selectedItem = listBox2.SelectedItem as string;

            if (selectedItem != null && definitions.ContainsKey(selectedItem))
            {
                // Display the definition in the TextBox
                textBox4.Text = definitions[selectedItem];
            }
            else
            {
                // Clear the TextBox if no valid item is selected
                textBox4.Text = string.Empty;
            }
        }
        // request security access button
        private void button5_Click(object sender, EventArgs e)
        {
            string seedkey = comboBoxKey.SelectedText;
            // Array to hold the integer equivalents
            int[] hexValues = new int[5];
            // Convert each character to its hexadecimal equivalent
            for (int i = 0; i < seedkey.Length; i++)
            {
                hexValues[i] = Convert.ToInt32(seedkey[i]);
            }
            switch (comboBoxSess.SelectedIndex)
            {
                case 0:
                    startDiagnosticSession(0x81);
                    break;
                case 1:
                    startDiagnosticSession(0x85);
                    break;
                case 2:
                    startDiagnosticSession(0x87);
                    break;
                case 3:
                    startDiagnosticSession(0xFE);
                    break;
                case 4:
                    startDiagnosticSession(0xFA);
                    break;
                case 5:
                    startDiagnosticSession(0x01);
                    break;
                case 6:
                    startDiagnosticSession(0x02);
                    break;
                case 7:
                    startDiagnosticSession(0x03);
                    break;
                case 8:
                    startDiagnosticSession(0x04);
                    break;

            }
            requestSecurityAccess0x27(ecuId, ecuId2, hexValues[0], hexValues[1], hexValues[2], hexValues[3], hexValues[4]);
        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

        private void CLEARDIAG_Click(object sender, EventArgs e)
        {

        }
        //tester present timer tick
        private void timerTesterPresent_Tick(object sender, EventArgs e)
        {
            byte responseType = 0x00;
            switch(comboBoxTester.SelectedIndex)
            {
                case 0x00:
                    responseType = 0x00;
                    break;
                case 0x01:
                    responseType = 0x01;
                    break;
                case 0x02:
                    responseType = 0x02;
                    break;
            }
            byte[] testerPresent = { 0x00, ecuId, ecuId2, 0x3E, responseType };
            sendPassThruMsg(testerPresent);
        }
        //stop tester present signal buttonclick
        private void buttonStopTester_Click(object sender, EventArgs e)
        {
            timerTesterPresent.Enabled = false;
            buttonStopTester.Enabled = false;
            buttonTester.Enabled = true;
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void informationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void testerPresentWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void jakka351GithubToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void diagnosticSessionControlToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void oBD2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //Hex2Dec Tool Menu Item Click
        private void hex2DecToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        //service 0x14 clearDiagnosticInformation
        private void button2_Click_1(object sender, EventArgs e)
        {
            byte[] clear = { 0x00, ecuId, ecuId2, 0x14, 0xFF, 0x00 };
            sendPassThruMsg(clear);
        }


        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
