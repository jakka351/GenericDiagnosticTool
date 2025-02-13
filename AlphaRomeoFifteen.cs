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
using System.Linq.Expressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
// //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace PassThruJ2534
{

    // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public partial class AlphaRomeoFifteen : Form
    {
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public AlphaRomeoFifteen()
        {
            InitializeComponent();
        }
        byte[] rx;
        byte[] tx;
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void PassThru_Load(object sender, EventArgs e)
        {
            comboBoxProtocol.SelectedIndex = 0;
            comboBoxCanBus.SelectedIndex = 0;
            comboBoxJ2534Devices.Items.Clear();
            //1) Search for all of our J2534 Devices
            List<J2534.J2534Device> MyListOfJ2534Devices = J2534DeviceFinder.FindInstalledJ2534DLLs();
            //List of devices installed on the PC
            for (int i = 0; i < MyListOfJ2534Devices.Count; i++)
            {
                string J2534ToolsName = MyListOfJ2534Devices[i].Name;
                comboBoxJ2534Devices.Items.Add(J2534ToolsName);
                Log("Found Installed Device: " + J2534ToolsName.ToString() + "\r\n");
            }
            if (comboBoxJ2534Devices.Items.Count > 0) { comboBoxJ2534Devices.SelectedIndex = 0; }
            if (comboBoxJ2534Devices.Items.Count >= 3) { comboBoxJ2534Devices.SelectedIndex = 3; }
        }
        // //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private Thread thread; private bool stopThread; bool connectFlag = false; bool highSpeedCan; byte ecuId; byte ecuId2; byte ecuId3; byte ecuId4;
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
            timerTesterPresent.Enabled = true; buttonStopTester.Enabled = true; buttonTester.Enabled = false;
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
                //listBox1.Items.Add(textBoxPassThruMsg.Text);
                textBoxPassThruMsg.Clear();
            }
            else { MessageBox.Show("Please input a diagnostic message into the textbox to add it to the send list."); }
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
            try 
            {
                if (checkBox29BitId.Checked)
                {
                    switch (comboBoxSess.SelectedIndex)
                    {
                        case 0x00:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x81);
                            break;
                        case 0x01:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x85);
                            break;
                        case 0x02:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x87);
                            break;
                        case 0x03:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0xFE);
                            break;
                        case 0x04:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0xFA);
                            break;
                        case 0x05:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x01);
                            break;
                        case 0x06:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x02);
                            break;
                        case 0x07:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x03);
                            break;
                        case 0x08:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x04);
                            break;
                    }
                }
                else
                {
                    switch (comboBoxSess.SelectedIndex)
                    {
                        case 0x00:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x81);
                            break;
                        case 0x01:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x85);
                            break;
                        case 0x02:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x87);
                            break;
                        case 0x03:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0xFE);
                            break;
                        case 0x04:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0xFA);
                            break;
                        case 0x05:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x01);
                            break;
                        case 0x06:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x02);
                            break;
                        case 0x07:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x03);
                            break;
                        case 0x08:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x04);
                            break;
                    }
                }
                bruteforce();                
            }
            catch(Exception Ex) { Log("Bruteforce Attack Error\r\n"); }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        byte[] ecuRx = { 0x1F, 0x40, 0x10, 0xF2 };
        byte[] ecuTx = { 0x1F, 0x40, 0xF2, 0x10 };

        private void buttonConnect(object sender, EventArgs e)
        {
            try 
            {
                if (button1.Text == "Connect")
                {
                    connectFlag = true;
                    if (comboBoxCanBus.SelectedIndex == 0) { highSpeedCan = true; } else { highSpeedCan = false; }
                    if (!checkBox29BitId.Checked)
                    {
                        textBoxEcuRx.MaxLength = 3;
                        textBoxEcuTx.MaxLength = 3;
                        textBoxEcuRx.Text = "7E0";
                        textBoxEcuTx.Text = "7E8";
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
                        connectSelectedJ2534Device(0, 0, ecuId, ecuId2, 0, 0, ecuId, ecuId3, highSpeedCan);
                    }
                    else
                    {
                        textBoxEcuRx.MaxLength = 8;
                        textBoxEcuTx.MaxLength = 8;
                        textBoxEcuRx.Text = "1F4010F2";
                        textBoxEcuTx.Text = "1F40F210";

                        if (textBoxEcuRx.Text.Length % 2 != 0)
                        {
                            throw new ArgumentException("Hex string must have an even number of characters.");
                        }
                        // Create a byte array with length equal to half of the hex string length.
                        byte[] rx = new byte[textBoxEcuRx.Text.Length / 2];

                        // Convert each pair of hexadecimal digits to a byte.
                        for (int i = 0; i < rx.Length; i++)
                        {
                            // Extract two characters at a time.
                            string twoHexChars = textBoxEcuRx.Text.Substring(i * 2, 2);
                            // Convert the two-character hex substring to a byte.
                            rx[i] = Convert.ToByte(twoHexChars, 16);
                        }
                        if (textBoxEcuTx.Text.Length % 2 != 0)
                        {
                            throw new ArgumentException("Hex string must have an even number of characters.");
                        }
                        // Create a byte array with length equal to half of the hex string length.
                        byte[] tx = new byte[textBoxEcuTx.Text.Length / 2];

                        // Convert each pair of hexadecimal digits to a byte.
                        for (int i = 0; i < rx.Length; i++)
                        {
                            // Extract two characters at a time.
                            string twoHexChars2 = textBoxEcuTx.Text.Substring(i * 2, 2);
                            // Convert the two-character hex substring to a byte.
                            tx[i] = Convert.ToByte(twoHexChars2, 16);
                        }
                        Log("TX & RX IDs:" + rx + " " + tx);
                        connectSelectedJ2534Device(rx[0], rx[1], rx[2], rx[3], tx[0], tx[1], tx[2], tx[3], highSpeedCan);
                    }
                }
                else
                {
                    connectFlag = false;
                    startReadAllPassThruMsgsButton.Enabled = true; // IF disconnecting the j2534 we also want to stop the can sniffer and reset buttons
                    stopReadAllCanMsgsButton.Enabled = false;
                    stopThread = true;
                    disconnect();
                }                
            }
            catch(Exception Ex) { Log("Connection Exception \r\n"); }
        }
        private void checkBox29BitId_CheckedChanged(object sender, EventArgs e)
        {

            if (!checkBox29BitId.Checked)
            {
                textBoxEcuRx.MaxLength = 3;
                textBoxEcuTx.MaxLength = 3;
                textBoxEcuRx.Text = "7E0";
                textBoxEcuTx.Text = "7E8";
            }
            if(checkBox29BitId.Checked)
            {
                textBoxEcuRx.MaxLength = 8;
                textBoxEcuTx.MaxLength = 8;
                textBoxEcuRx.Text = "1F4010F2";
                textBoxEcuTx.Text = "1F40F210";
                if (textBoxEcuRx.Text.Length % 2 != 0)
                {
                    throw new ArgumentException("Hex string must have an even number of characters.");
                }
                // Create a byte array with length equal to half of the hex string length.
                rx = new byte[textBoxEcuRx.Text.Length / 2];
                // Convert each pair of hexadecimal digits to a byte.
                for (int i = 0; i < rx.Length; i++)
                {
                    // Extract two characters at a time.
                    string twoHexChars = textBoxEcuRx.Text.Substring(i * 2, 2);
                    // Convert the two-character hex substring to a byte.
                    rx[i] = Convert.ToByte(twoHexChars, 16);
                }
                if (textBoxEcuTx.Text.Length % 2 != 0)
                {
                    throw new ArgumentException("Hex string must have an even number of characters.");
                }
                // Create a byte array with length equal to half of the hex string length.
                tx = new byte[textBoxEcuTx.Text.Length / 2];
                // Convert each pair of hexadecimal digits to a byte.
                for (int i = 0; i < rx.Length; i++)
                {
                    // Extract two characters at a time.
                    string twoHexChars2 = textBoxEcuTx.Text.Substring(i * 2, 2);
                    // Convert the two-character hex substring to a byte.
                    tx[i] = Convert.ToByte(twoHexChars2, 16);
                }

            }
        }

            //THIS DOESNT WORK
        public void buttonSendPassThruMsg_Click(object sender, EventArgs e)
        {
            try
            {
                string message = textBoxPassThruMsg.Text;
                message = message.Replace(" ", "");
                byte[] byteMsg = StringToByteArray(message);  // Your byte array from the string
                if(checkBox29BitId.Checked)
                {
                    byte[] byteEcuId = new byte[] { rx[0], rx[1], rx[2], rx[3]  };  // Your ECU ID byte arra
                                                                                    // Create a new byte array with enough space to hold both arrays
                    byte[] combinedArray = new byte[byteMsg.Length + byteEcuId.Length];
                    // Copy byteMsg into the new array
                    Array.Copy(byteMsg, 0, combinedArray, 0, byteMsg.Length);
                    // Copy byteEcuId into the new array, starting right after the byteMsg
                    Array.Copy(byteEcuId, 0, combinedArray, byteMsg.Length, byteEcuId.Length);
                    sendPassThruMsg(combinedArray);

                }
                else 
                {
                    byte[] byteEcuId = new byte[] { 0, 0, ecuId, ecuId2 };  // Your ECU ID byte arra
                    // Create a new byte array with enough space to hold both arrays
                    byte[] combinedArray = new byte[byteMsg.Length + byteEcuId.Length];
                    // Copy byteMsg into the new array
                    Array.Copy(byteMsg, 0, combinedArray, 0, byteMsg.Length);
                    // Copy byteEcuId into the new array, starting right after the byteMsg
                    Array.Copy(byteEcuId, 0, combinedArray, byteMsg.Length, byteEcuId.Length);
                    sendPassThruMsg(combinedArray);
                }
            }
            catch(Exception Ex) {  }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try 
            {
                //DIAG SESS CONTROL BTN
                int sessionType = comboBoxDiagSessControl.SelectedIndex;
                if(checkBox29BitId.Checked)
                {
                    switch (sessionType)
                    {
                        case 0x00:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x81);
                            break;
                        case 0x01:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x85);
                            break;
                        case 0x02:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x87);
                            break;
                        case 0x03:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0xFE);
                            break;
                        case 0x04:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0xFA);
                            break;
                        case 0x05:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x01);
                            break;
                        case 0x06:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x02);
                            break;
                        case 0x07:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x03);
                            break;
                        case 0x08:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x04);
                            break;
                    }                
                }
                else 
                {
                    switch (sessionType)
                    {
                        case 0x00:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x81);
                            break;
                        case 0x01:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x85);
                            break;
                        case 0x02:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x87);
                            break;
                        case 0x03:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0xFE);
                            break;
                        case 0x04:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0xFA);
                            break;
                        case 0x05:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x01);
                            break;
                        case 0x06:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x02);
                            break;
                        case 0x07:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x03);
                            break;
                        case 0x08:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x04);
                            break;
                    }                                    
                }
            }
            catch(Exception Ex) { Log("Diagnostic Session Control Exception\r\n"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try 
            {
                //ECU RESET BTN
                int resetType = comboBoxEcuReset.SelectedIndex;
                if(checkBox29BitId.Checked)
                {
                    switch (resetType)
                    {
                        case 0x00:
                            ecuReset(rx[0], rx[1], rx[2], rx[3], 0x01);
                            break;
                        case 0x01:
                            ecuReset(rx[0], rx[1], rx[2], rx[3], 0x02);
                            break;
                        case 0x02:
                            ecuReset(rx[0], rx[1], rx[2], rx[3], 0x03);
                            break;
                        case 0x03:
                            ecuReset(rx[0], rx[1], rx[2], rx[3], 0x04);
                            break;
                        case 0x04:
                            ecuReset(rx[0], rx[1], rx[2], rx[3], 0x05);
                            break;
                    }                                    
                }
                else
                {
                    switch (resetType)
                    {
                        case 0x00:
                            ecuReset(0, 0, ecuId, ecuId2, 0x01);
                            break;
                        case 0x01:
                            ecuReset(0, 0, ecuId, ecuId2, 0x02);
                            break;
                        case 0x02:
                            ecuReset(0, 0, ecuId, ecuId2, 0x03);
                            break;
                        case 0x03:
                            ecuReset(0, 0, ecuId, ecuId2, 0x04);
                            break;
                        case 0x04:
                            ecuReset(0, 0, ecuId, ecuId2, 0x05);
                            break;
                    }
                }
            }
            catch(Exception Ex) { Log("ECU RESET Exception\r\n"); }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try 
            {
                //CONTROL DTC BTN
                int onOff = comboBoxControlDtc.SelectedIndex;
                if(checkBox29BitId.Checked)
                {
                    switch (onOff)
                    {
                        case 0x00:
                            controlDtcSetting(rx[0], rx[1], rx[2], rx[3], 0x01);
                            break;
                        case 0x01:
                            controlDtcSetting(rx[0], rx[1], rx[2], rx[3], 0x02);
                            break;
                    }                    
                }
                else 
                {
                    switch (onOff)
                    {
                        case 0x00:
                            controlDtcSetting(0, 0, ecuId, ecuId2, 0x01);
                            break;
                        case 0x01:
                            controlDtcSetting(0, 0, ecuId, ecuId2, 0x02);
                            break;
                    }               
                }
            }
            catch(Exception Ex) { Log("CONTROL DTC SETTING Exception\r\n"); }
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
        /// <summary>
        /// VIN DECODER CODE BUTTON CLICKS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //GET VIN NUMBER BTN
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                Log("Requesting VIN via OBDII \r\n");
                textBoxInterVin.Text = "";
                byte[] mode0902 = new byte[] { 0, 0, 0x7, 0xDF, 0x09, 0x02 };
                string vehicleIdentificationNumberMsg = sendPassThruMsg(mode0902);
                //string test = "00 00 07 E8 49 02 01 36 46 50 41 41 41 4A 47 53 57 36 4A 38 30 35 30 31";
                string interVin = vehicleIdentificationNumberMsg.Replace(" ", "");
                string interVin2 = interVin.Substring(14);
                string finalVin = HexToASCII(interVin2);
                Log("VIN: " + finalVin + "\r\n");
                textBoxInterVin.Text += finalVin;
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
                MessageBox.Show("Successfully recieved VIN from ECU.");
            }
            catch (Exception ex)
            {
                Log("VIN Grab ERROR\r\n");
            }
        }
        //VIN DECODE BUTTON
        private void button7_Click_1(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Log("VIN Decoding Error\r\n");
            }

        }
        //VIN DECODE CLICK
        private void button7_Click_2(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                Log("VIN Decoding Error\r\n");
            }
        }
        // /////////////////////////////////////////////////////////////
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
        //WHATS THIS FOR
        bool flagNoDataAbort;
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // 0x23 Direct Memory Read readMemoryByAddress
        private async void button20_Click(object sender, EventArgs e)
        {
            await Task.Run(DirectMemoryRead);
        }
        // ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // 0x23 Direct Memory Read readMemoryByAddress
        public async Task DirectMemoryRead()
        {
            // Show SaveFileDialog on the main UI thread
            string fileName = null;
            Invoke(new Action(() =>
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Binary Files (*.bin)|*.bin",
                    Title = "Generic Diagnostic Tool | Direct Memory Read | Save File",
                    DefaultExt = "bin",
                    FileName = "DMR.bin"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK) { fileName = saveFileDialog.FileName; }
            }));
            // If no file selected, return
            if (fileName == null)
            {
                MessageBox.Show(
                    "Save operation canceled.", "Canceled", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                return;
            }
            try
            {
                // Parse inputs from UI on the main thread
                uint startAddress = 0, finishAddress = 0, blockSize = 0; int millisecTxGap = 0;
                Invoke(new Action(() =>
                {
                    startAddress = Convert.ToUInt32(textBoxStartAddress.Text, 16);
                    finishAddress = Convert.ToUInt32(textBoxFinishAddress.Text, 16);
                    blockSize = Convert.ToUInt32(textBoxBlockSize.Text, 16);
                    millisecTxGap = Convert.ToInt32(textBoxMilliseconds.Text);
                }));
                // Validate inputs
                if (startAddress > finishAddress || blockSize == 0)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show(
                            "Invalid input: Ensure start address <= finish address and block size > 0.", "Input Error", 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);
                    }));
                    return;
                }
                // Perform file operations in a background task
                await Task.Run(() =>
                {
                    using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                    {
                        for (uint i = startAddress; i <= finishAddress; i += blockSize)
                        {
                            uint currentBlockSize = (i + blockSize > finishAddress + 1) ? finishAddress - i + 1 : blockSize;
                            if(checkBox29BitId.Checked)
                            {
                                byte[] memory = readMemoryByAddress(rx[0], rx[1], rx[2], rx[3], i, currentBlockSize);
                                Task.Delay(millisecTxGap).Wait();
                                fileStream.Write(memory, 0, memory.Length); // Write the memory block to the file
                            }
                            else 
                            {
                                byte[] memory = readMemoryByAddress(0, 0, ecuId, ecuId2, i, currentBlockSize);
                                Task.Delay(millisecTxGap).Wait();
                                fileStream.Write(memory, 0, memory.Length); // Write the memory block to the file
                            }
                        }
                    }
                });
                // Show success message on the UI thread
                Invoke(new Action(() =>
                {
                    MessageBox.Show("Direct Memory Read saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }));
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid hexadecimal numbers in the text boxes.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException)
            {
                MessageBox.Show("One or more values are too large. Please enter smaller hexadecimal numbers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TResult Invoke<TResult>(Func<TResult> function)
        {
            if (InvokeRequired)
                return (TResult)Invoke(function);
            return function();
        }

        private void Invoke(Action action)
        {
            if (InvokeRequired)
                Invoke((Delegate)action);
            else
                action();
        }
        //Invoke required for updating listbox 2 from a seperate async task...
        private Task UpdateUIAsync(Action uiAction)
        {
            return Task.Run(() =>
            {
               
            });
        }
        private async void button22_Click(object sender, EventArgs e)
        {
            await Task.Run(bruteforceDids);
        }
        /// <summary>
        /// BRUTEFORCE DID's with service 0x22 readDataByCommonId
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async Task bruteforceDids()
        {
            try
            {
                for (int did = 0x0000; did <= 0xFFFF; did++)
                {
                    int response = 0;
                    byte upperByte = (byte)((did >> 8) & 0xFF);  // Upper byte of the DID
                    byte lowerByte = (byte)(did & 0xFF);         // Lower byte of the DID
                    if(checkBox29BitId.Checked)
                    {
                        byte[] array = { rx[0], rx[1], rx[2], rx[3], 0x22, upperByte, lowerByte };
                        string did1 = sendPassThruMsg(array); did1 = did1.Replace(" ", ""); string didFound = "$" + did1.Substring(10, 4);
                        response = int.Parse(did1.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
                        switch (response)
                        {
                            case 0x62:
                                await UpdateUIAsync(() =>
                                {
                                    Log($"Data Identifier Located \r\n");
                                    //listBox2.Items.Add(didFound);
                                    string def = getDidDefinition(did1.Substring(10, 4));
                                    dataGridView2.Rows.Add(didFound, def);
                                    string msgap = textBoxDidGap.Text;
                                    int gap = Convert.ToInt32(msgap);
                                    Thread.Sleep(gap);
                                });
                                break;
                            case 0x7F:
                                await UpdateUIAsync(() =>
                                {
                                    Log($"No Data Identifier Located \r\n");
                                    string msgap = textBoxDidGap.Text;
                                    int gap = Convert.ToInt32(msgap);
                                    Thread.Sleep(gap);
                                });
                                break;
                            default:
                                await UpdateUIAsync(() =>
                                {
                                    Log("No Response from ECU, ECU is offline\r\n");
                                    MessageBox.Show(
                                        "No response from ECU", "ECU is Offline",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                });
                                break;
                        }

                    }
                    else 
                    {
                        byte[] array = { 0, 0, ecuId, ecuId2, 0x22, upperByte, lowerByte };
                        string did1 = sendPassThruMsg(array); did1 = did1.Replace(" ", ""); string didFound = "$" + did1.Substring(10, 4);
                        response = int.Parse(did1.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
                        switch (response)
                        {
                            case 0x62:
                                await UpdateUIAsync(() =>
                                {
                                    Log($"Data Identifier Located \r\n");
                                    //listBox2.Items.Add(didFound);
                                    string def = getDidDefinition(did1.Substring(10, 4));
                                    dataGridView2.Rows.Add(didFound, def);
                                    string msgap = textBoxDidGap.Text;
                                    int gap = Convert.ToInt32(msgap);
                                    Thread.Sleep(gap);
                                });
                                break;
                            case 0x7F:
                                await UpdateUIAsync(() =>
                                {
                                    Log($"No Data Identifier Located \r\n");
                                    string msgap = textBoxDidGap.Text;
                                    int gap = Convert.ToInt32(msgap);
                                    Thread.Sleep(gap);
                                });
                                break;
                            default:
                                await UpdateUIAsync(() =>
                                {
                                    Log("No Response from ECU, ECU is offline\r\n");
                                    MessageBox.Show(
                                        "No response from ECU", "ECU is Offline",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                                });
                                break;
                        }
                    }
                }
            }
            catch (Exception)
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
        private async void button23_Click(object sender, EventArgs e)
        {
            try
            {
                string did = textBoxDid.Text;
                // Convert the first two characters to a byte (0xFF)
                byte upperByte = Convert.ToByte(did.Substring(0, 2), 16);
                // Convert the last two characters to a byte (0xFF)
                byte lowerByte = Convert.ToByte(did.Substring(2, 2), 16);
                if(checkBox29BitId.Checked)
                {
                    byte[] array = { rx[0], rx[1], rx[2], rx[3], 0x22, upperByte, lowerByte };
                    string did1 = sendPassThruMsg(array); did1 = did1.Replace(" ", ""); string didFound = "$" + did1.Substring(10, 4);
                    int response = int.Parse(did1.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
                    switch (response)
                    {
                        case 0x62:
                            await UpdateUIAsync(() =>
                            {
                                Log($"Data Identifier Located @ {didFound} \r\n");
                                //listBox2.Items.Add(didFound);
                                string def = getDidDefinition(did1.Substring(10, 4));
                                dataGridView2.Rows.Add(didFound, def);
                            });
                            break;
                        case 0x7F:
                            await UpdateUIAsync(() =>
                            {
                                Log($"No Data Identifier Located @ {didFound} \r\n");
                            });
                            break;
                        default:
                            await UpdateUIAsync(() =>
                            {
                                Log("No Response from ECU, ECU is offline\r\n");
                                MessageBox.Show(
                                    "No response from ECU", "ECU is Offline",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            });
                            break;
                    }
                }
                else 
                {
                    byte[] array = { 0, 0, ecuId, ecuId2, 0x22, upperByte, lowerByte };
                    string did1 = sendPassThruMsg(array); did1 = did1.Replace(" ", ""); string didFound = "$" + did1.Substring(10, 4);
                    int response = int.Parse(did1.Substring(8, 2), System.Globalization.NumberStyles.HexNumber);
                    switch (response)
                    {
                        case 0x62:
                            await UpdateUIAsync(() =>
                            {
                                Log($"Data Identifier Located @ {didFound} \r\n");
                                //listBox2.Items.Add(didFound);
                                string def = getDidDefinition(did1.Substring(10, 4));
                                dataGridView2.Rows.Add(didFound, def);
                            });
                            break;
                        case 0x7F:
                            await UpdateUIAsync(() =>
                            {
                                Log($"No Data Identifier Located @ {didFound} \r\n");
                            });
                            break;
                        default:
                            await UpdateUIAsync(() =>
                            {
                                Log("No Response from ECU, ECU is offline\r\n");
                                MessageBox.Show(
                                    "No response from ECU", "ECU is Offline",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                            });
                            break;
                    }
                }
            

            }
            catch (Exception ex) { Log("DID Retrieval Exception Occurred...\r\n"); }
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
            if (TABCNTRL1.SelectedTab == READDIAG) // Check if the selected tab is Tab 2
            {
                tabControl2.SelectedTab = DTC;
            }
            else if (TABCNTRL1.SelectedTab == READDTC19) // Check if the selected tab is Tab 2
            {
                tabControl2.SelectedTab = DTC;
            }
            else
            {
                tabControl2.SelectedTab = PT;
            }
            if (TABCNTRL1.SelectedTab == READDATABYCOMMONID) // Check if the selected tab is Tab 2
            {
                tabControl2.SelectedTab = DID;
            }
            else if (TABCNTRL1.SelectedTab == SECURITY)
            {
                pBarBruteforce.Visible = true;
            }
            else if (TABCNTRL1.SelectedTab == STARTROUTINE) 
            {
                //tabControl2.SelectedTab = ODST;
            }
            else
            {
               
            }
        }
        // request security access button
        private void button5_Click(object sender, EventArgs e)
        {
            try 
            {
                byte level;
                switch (comboBoxSecurityLevel.SelectedIndex)
                {
                    case 0x00:
                        level = 0x01;
                        break;
                    case 0x01:
                        level = 0x03;
                        break;
                    //need to finish off all the levels here
                    default:
                        level = 0x01;
                        break;
                }
                // Array to hold the integer equivalents
                int[] hexInts = new int[5];
                if (comboBoxKey.SelectedIndex >= 1)
                {
                    // Proceed with your following code
                    string seedkey = comboBoxKey.SelectedText;
                    for (int i = 0; i < seedkey.Length; i++)
                    {
                        // Convert each character to its integer value
                        try
                        {
                            hexInts[i] = Convert.ToInt32(seedkey[i].ToString(), 16);
                        }
                        catch (FormatException)
                        {
                            Log($"Invalid hexadecimal character: {seedkey[i]}");
                            return;
                        }
                    }
                }
                else if (!string.IsNullOrWhiteSpace(textBoxSecretKeyInput.Text))
                {
                    string seedkey2 = textBoxSecretKeyInput.Text;
                    // Ensure the string length is valid for splitting into 5 bytes (2 characters each)
                    if (seedkey2.Length != 10)
                    {
                        Log("The hexadecimal string must have exactly 10 characters.");
                        return;
                    }

                    // Split the string into 5 parts and convert to integers
                    for (int i = 0; i < 5; i++)
                    {
                        string hexPair = seedkey2.Substring(i * 2, 2); // Take 2 characters at a time
                        hexInts[i] = Convert.ToInt32(hexPair, 16);      // Convert to integer
                    }
                }
                if(checkBox29BitId.Checked)
                {
                    switch (comboBoxSess.SelectedIndex)
                    {
                        case 0x00:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x81);
                            break;
                        case 0x01:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x85);
                            break;
                        case 0x02:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x87);
                            break;
                        case 0x03:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0xFE);
                            break;
                        case 0x04:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0xFA);
                            break;
                        case 0x05:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x01);
                            break;
                        case 0x06:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x02);
                            break;
                        case 0x07:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x03);
                            break;
                        case 0x08:
                            startDiagnosticSession(rx[0], rx[1], rx[2], rx[3], 0x04);
                            break;
                    }                
                }
                else 
                {
                    switch (comboBoxSess.SelectedIndex)
                    {
                        case 0x00:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x81);
                            break;
                        case 0x01:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x85);
                            break;
                        case 0x02:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x87);
                            break;
                        case 0x03:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0xFE);
                            break;
                        case 0x04:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0xFA);
                            break;
                        case 0x05:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x01);
                            break;
                        case 0x06:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x02);
                            break;
                        case 0x07:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x03);
                            break;
                        case 0x08:
                            startDiagnosticSession(0, 0, ecuId, ecuId2, 0x04);
                            break;
                    }                                    
                }
                if(checkBox29BitId.Checked)
                {
                    requestSecurityAccess0x27(rx[0], rx[1], rx[2], rx[3], level, hexInts[0], hexInts[1], hexInts[2], hexInts[3], hexInts[4]);
                }
                else 
                {
                    requestSecurityAccess0x27(0, 0, ecuId, ecuId2, level, hexInts[0], hexInts[1], hexInts[2], hexInts[3], hexInts[4]);    
                }
            }
            catch(Exception Ex) { Log("Security Access Exception\r\n"); }
        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

        private void CLEARDIAG_Click(object sender, EventArgs e)
        {

        }
        //tester present timer tick
        //Now setup to run as an sync task in the background.
        private async void timerTesterPresent_Tick(object sender, EventArgs e)
        {
            try
            {
                // Capture UI state (SelectedIndex) on the UI thread
                int selectedIndex = comboBoxTester.SelectedIndex;
                // Run the main logic in a background thread
                await Task.Run(() =>
                {
                    byte responseType;
                    switch (selectedIndex)
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
                        default:
                            responseType = 0x01;
                            break;
                    }
                    if(checkBox29BitId.Checked)
                    {
                        byte[] testerPresent = { rx[0], rx[1], rx[2], rx[3], 0x3E, responseType };
                        this.Invoke((Action)(() =>
                        {
                            sendPassThruMsg(testerPresent);
                        }));

                    }
                    else 
                    {
                        byte[] testerPresent = { 0, 0, ecuId, ecuId2, 0x3E, responseType };
                        this.Invoke((Action)(() =>
                        {
                            sendPassThruMsg(testerPresent);
                        }));

                    }
                    // If sendPassThruMsg must run on the UI thread (e.g., it updates UI):
                    // If sendPassThruMsg does NOT need UI thread and is thread-safe, 
                    // you can just call it here:
                    // sendPassThruMsg(testerPresent);
                });
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately, possibly invoking UI updates on the UI thread
                this.Invoke((Action)(() =>
                {
                    // Update UI with error info
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }));
            }
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
            Form Info = new PassThruJ2534.Info(); Info.Activate(); Info.Show();
        }

        private void testerPresentWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://testerpresent.com.au";
            try
            {
                // Open the URL in the default web browser
                Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void jakka351GithubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/jakka351";
            try
            {
                // Open the URL in the default web browser
                Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            Form hex2dec = new PassThruJ2534.lib.Forms.Hex2Dec(); hex2dec.Activate(); hex2dec.Show();
        }
        //service 0x14 clearDiagnosticInformation
        private void button2_Click_1(object sender, EventArgs e)
        {
            Type currentType = this.GetType();
            MethodInfo methodInfo = currentType.GetMethod(
                "clearDtc",
                BindingFlags.Instance | BindingFlags.NonPublic
            );
            if (methodInfo != null)
            {
                methodInfo.Invoke(this, null);
            }
        }

        private void label45_Click(object sender, EventArgs e)
        {

        }
        // READ DATA BY LOCAL ID CHECKBOX CHANGED ENABLE AND DISABLE FINISH ADDRESS TEXTBOX AND LABEL
        private void checkBoxBruteforce21_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBruteforce21.Checked) { label21setfinishblock.Enabled = false; textBox21finish.Enabled = false; }
            else if (!checkBoxBruteforce21.Checked) { label21setfinishblock.Enabled = true; textBox21finish.Enabled = true; }
        }
        //FILE >> EXIT click
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        /// <summary>
        /// CAN SNIFFER CODE FOR BUTTON CLICKS AND ASYNC TASK from readAllMsgs.cs
        /// </summary>
        //private Thread thread;
        //private bool stopThread;
        //START CAN SNIFFER BUTTON CLICK
        private void startReadAllPassThruMsgsButton_Click(object sender, EventArgs e)
        {
            startReadAllPassThruMsgsButton.Enabled = false;
            stopReadAllCanMsgsButton.Enabled = true;
            stopThread = false;
            thread = new Thread(readAllMsgs);
            thread.Start();
            return;
        }
        //STOP CAN SNIFFER BUTTON CLICK
        private void stopReadAllCanMsgsButton_Click(object sender, EventArgs e)
        {
            startReadAllPassThruMsgsButton.Enabled = true;
            stopReadAllCanMsgsButton.Enabled = false;
            stopThread = true;
        }
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
            if(checkBox29BitId.Checked)
            {
                PassThruMsg maskMsg = new PassThruMsg(ProtocolID.CAN, TxFlag.CAN_29BIT_ID, new byte[] { 0, 0, 0x00, 0x00 }); //Set mask of 7FF (Only accept the exact PATTERN
                PassThruMsg patternMsg = new PassThruMsg(ProtocolID.CAN, TxFlag.CAN_29BIT_ID, new byte[] { tx[0], tx[1], tx[2], tx[3] }); //Search for 7E8
                PassThruMsg flowMsg = new PassThruMsg(ProtocolID.CAN, TxFlag.CAN_29BIT_ID, new byte[] { rx[0], rx[1], rx[2], rx[3] }); //Use the flow message of 7E0
                IntPtr maskPtr = maskMsg.ToIntPtr();
                IntPtr PatternPtr = patternMsg.ToIntPtr();
                IntPtr FlowPtr = IntPtr.Zero;
                var ErrorResult = J2534Port.Functions.PassThruStartMsgFilter((int)ChannelID, FilterType.PASS_FILTER, maskPtr, PatternPtr, FlowPtr, ref FilterID);
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
                Marshal.FreeHGlobal(maskPtr);
                Marshal.FreeHGlobal(PatternPtr);
                Marshal.FreeHGlobal(FlowPtr);
            }
            else
            {
                PassThruMsg maskMsg = new PassThruMsg(ProtocolID.CAN, TxFlag.NONE, new byte[] { 0, 0, 0x00, 0x00 }); //Set mask of 7FF (Only accept the exact PATTERN
                PassThruMsg patternMsg = new PassThruMsg(ProtocolID.CAN, TxFlag.NONE, new byte[] { 0, 0, 07, 0xFF }); //Search for 7E8
                PassThruMsg flowMsg = new PassThruMsg(ProtocolID.CAN, TxFlag.NONE, new byte[] { 0, 0, 07, 0xFF }); //Use the flow message of 7E0
                IntPtr maskPtr = maskMsg.ToIntPtr();
                IntPtr PatternPtr = patternMsg.ToIntPtr();
                IntPtr FlowPtr = IntPtr.Zero;
                var ErrorResult = J2534Port.Functions.PassThruStartMsgFilter((int)ChannelID, FilterType.PASS_FILTER, maskPtr, PatternPtr, FlowPtr, ref FilterID);
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
                Marshal.FreeHGlobal(maskPtr);
                Marshal.FreeHGlobal(PatternPtr);
                Marshal.FreeHGlobal(FlowPtr);

            }

            // ///////////////////////////////////////////////////////////////
            // PassThruReadMsgs(int channelId, IntPtr msgs, ref int numMsgs, int timeout);
            //8) Read Respnse
            int timeout = 60;
            while (stopThread == false)
            {
                int NumReadMsgs = 1;
                IntPtr MyRXMsg = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(PassThruMsg)) * NumReadMsgs);
                var ErrorResult = J2534Port.Functions.PassThruReadMsgs((int)ChannelID, MyRXMsg, ref NumReadMsgs, timeout);
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
                // 1. Timestamp: get the current date/time
                string timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                // 2. CAN ID: bytes [0..3]. Represent it as a hex string.
                //    For example, "1F40F210"
                string canId = BitConverter.ToString(MyRXDBytes, 0, 4).Replace("-", "");
                // 3. Message Data: bytes [4..end] as a variable-length hex string.
                int messageLength = MyRXDBytes.Length - 4; // from index 4 to the end
                string messageData = BitConverter
                    .ToString(MyRXDBytes, 4, messageLength)
                    .Replace("-", " ");
                // Add a new row to dataGridView3
                dataGridView3.Rows.Add(timeStamp, canId, messageData);
                //textBox4.Text += timeStamp + " " + canId + " " + messageData + "\r\n";
                // Assume you've just added a new row to dataGridView3
                int newRowIndex = dataGridView3.Rows.Count - 1; // Index of the last row
                if (newRowIndex >= 0)
                {
                    dataGridView3.FirstDisplayedScrollingRowIndex = newRowIndex;
                }
            }
            return;
        }
        //SAVE CAN LOG BUTTON
        private void saveCanLog_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Generic Diagnostic Tool - Save Log File";
                saveFileDialog.Filter = "CANbus Log files (*.log)|*.log|All files (*.*)|*.*";
                saveFileDialog.DefaultExt = "log";

                // Show the dialog and check if the user clicked OK
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Open a stream to write to the chosen file
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(saveFileDialog.FileName))
                    {
                        // Optionally, write a header row
                        writer.WriteLine("Timestamp CANID MessageData");

                        // Loop through each row in the DataGridView
                        foreach (DataGridViewRow row in dataGridView3.Rows)
                        {
                            // Skip any 'new row' placeholders
                            if (row.IsNewRow) continue;

                            // Get the cell values (assuming columns in order: Timestamp, CAN ID, Message Data)
                            string timestamp = row.Cells[0].Value?.ToString() ?? "";
                            string canId = row.Cells[1].Value?.ToString() ?? "";
                            string msgData = row.Cells[2].Value?.ToString() ?? "";

                            // Write them to file, separated by spaces
                            writer.WriteLine($"{timestamp} {canId} {msgData}");
                        }
                    }

                    MessageBox.Show("GDT CAN Log file saved successfully!", "Generic Diagnostic Tool", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        // CLEAR CAN LOG BUTTON CLICK
        private void clearCanLogButton_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            //textBoxCAN.Text = "";
        }

        private void textBoxBlockSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }
        //BRUTEFORCE ALL POSSIBLE KEYS
        private async void button18_Click(object sender, EventArgs e)
        {
            if(checkBoxFF.Checked)
            {

                await BruteforceAllAsyncFF();
            }
            else
            {
                await BruteforceAllAsync();
            }
            //bruteforecAll();
        }

        private void DTC_Click(object sender, EventArgs e)
        {

        }

        private void READDIAG_Click(object sender, EventArgs e)
        {

        }
        // Read DTC BUTTON CLICK
        private void button9_Click(object sender, EventArgs e)
        {
            Type currentType = this.GetType();
            MethodInfo methodInfo = currentType.GetMethod(
                "readContinuousCodes",
                BindingFlags.Instance | BindingFlags.NonPublic
            );
            if (methodInfo != null)
            {
                methodInfo.Invoke(this, null);
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Type currentType = this.GetType();
            MethodInfo methodInfo = currentType.GetMethod(
                "clearDtc",
                BindingFlags.Instance | BindingFlags.NonPublic
            );
            if (methodInfo != null)
            {
                methodInfo.Invoke(this, null);
            }
        }

        private void READDATABYCOMMONID_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void READDTC19_Click(object sender, EventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {
            string dtc = "P1130"; string global = "Generic"; string type = "Powertrain"; string subType = "Injector Circuit"; string definition = definitionLookup(dtc);
            AddDtcRow(dtc, global, type, subType, definition);
            string dtc1 = "P1415"; string global1 = "Generic"; string type1 = "Powertrain"; string subType1 = "Injector Circuit"; string definition1 = definitionLookup(dtc1);
            AddDtcRow(dtc1, global1, type1, subType1, definition1);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                    sfd.Title = "Generic Diagnostic Tool | Export DTC as CSV";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName))
                        {
                            // Write the header line
                            sw.WriteLine("DTC,Global,Type,SubType,Definition");

                            // Iterate through each row in the DataGridView
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                // Skip the new row placeholder if it's present
                                if (row.IsNewRow) continue;

                                // Retrieve each cell's value, using .ToString() and null checks
                                string dtc = row.Cells["code"].Value?.ToString() ?? string.Empty;
                                string global = row.Cells["generic"].Value?.ToString() ?? string.Empty;
                                string type = row.Cells["type"].Value?.ToString() ?? string.Empty;
                                string subType = row.Cells["subtype"].Value?.ToString() ?? string.Empty;
                                string definition = row.Cells["definition"].Value?.ToString() ?? string.Empty;

                                // Write the CSV line
                                sw.WriteLine($"{dtc},{global},{type},{subType},{definition}");
                            }
                        }

                        MessageBox.Show("Data saved successfully!", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception Ex) { Log("Exception Exporting DTC to CSV");  }
        }

        private void testerPresentFacebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://facebook.com/testerPresent";
            try
            {
                // Open the URL in the default web browser
                Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void testerPresentOnlineStoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://testerpresent.com.au/index.php/shop/";
            try
            {
                // Open the URL in the default web browser
                Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void gTDRepositoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/jakka351/GenericDiagnosticTool";
            try
            {
                // Open the URL in the default web browser
                Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void raiseAnIssueToolStripMenuItem_Click(object sender, EventArgs e)
        {
        
            string url = "https://github.com/jakka351/GenericDiagnosticTool/issues";
            try
            {
                // Open the URL in the default web browser
                Process.Start(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void STARTROUTINE_Click(object sender, EventArgs e)
        {

        }
        // START ON DEMAND SELF TEST BUTTON CLICK
        private async void button34_Click(object sender, EventArgs e)
        {
            //await Task.Run(routineControl_onDemandSelfTest);
            
        }
        // CLEAR DID BUTTON CLICK
        private void button35_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
        }

        //TEST ADD DIDS TO DATAGRIDVIEW2
        private void button37_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add("0200", "Continuous Codes");
            dataGridView2.Rows.Add("0202", "Continuous Codes since last test");
            dataGridView2.Rows.Add("E200", "Software Version");
        }

        private void DID_Click(object sender, EventArgs e)
        {

        }
        // THIS IS SO THAT THE APPLICATION SHUT DOWN CORRECTLY AND PROPERLY EXITS
        private void AlphaRomeoFifteen_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), "0x7E0", "02 10 85 00 00 00 00 00");
            dataGridView3.Rows.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), "0x7E8", "02 50 85 00 00 00 00 00");
        }

        private void button41_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxDiagSessControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////

