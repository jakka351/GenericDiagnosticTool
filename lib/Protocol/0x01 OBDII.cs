#region Copyright (c) 2024, Jack Leighton
// /////     __________________________________________________________________________________________________________________
// /////
// /////                  __                   __              __________                                      __   
// /////                _/  |_  ____   _______/  |_  __________\______   \_______   ____   ______ ____   _____/  |_ 
// /////                \   __\/ __ \ /  ___/\   __\/ __ \_  __ \     ___/\_  __ \_/ __ \ /  ___// __ \ /    \   __\
// /////                 |  | \  ___/ \___ \  |  | \  ___/|  | \/    |     |  | \/\  ___/ \___ \\  ___/|   |  \  |  
// /////                 |__|  \___  >____  > |__|  \___  >__|  |____|     |__|    \___  >____  >\___  >___|  /__|  
// /////                           \/     \/            \/                             \/     \/     \/     \/      
// /////                                                          .__       .__  .__          __                    
// /////                               ____________   ____   ____ |__|____  |  | |__| _______/  |_                  
// /////                              /  ___/\____ \_/ __ \_/ ___\|  \__  \ |  | |  |/  ___/\   __\                 
// /////                              \___ \ |  |_> >  ___/\  \___|  |/ __ \|  |_|  |\___ \  |  |                   
// /////                             /____  >|   __/ \___  >\___  >__(____  /____/__/____  > |__|                   
// /////                                  \/ |__|        \/     \/        \/             \/                         
// /////                                  __                         __  .__                                        
// /////                   _____   __ ___/  |_  ____   _____   _____/  |_|__|__  __ ____                            
// /////                   \__  \ |  |  \   __\/  _ \ /     \ /  _ \   __\  \  \/ // __ \                           
// /////                    / __ \|  |  /|  | (  <_> )  Y Y  (  <_> )  | |  |\   /\  ___/                           
// /////                   (____  /____/ |__|  \____/|__|_|  /\____/|__| |__| \_/  \___  >                          
// /////                        \/                         \/                          \/                           
// /////                                                  .__          __  .__                                      
// /////                                       __________ |  |  __ ___/  |_|__| ____   ____   ______                
// /////                                      /  ___/  _ \|  | |  |  \   __\  |/  _ \ /    \ /  ___/                
// /////                                      \___ (  <_> )  |_|  |  /|  | |  (  <_> )   |  \\___ \                 
// /////                                     /____  >____/|____/____/ |__| |__|\____/|___|  /____  >                
// /////                                          \/                                      \/     \/                 
// /////                                   Tester Present Specialist Automotive Solutions
// /////     __________________________________________________________________________________________________________________
// /////      |--------------------------------------------------------------------------------------------------------------|
// /////      |       https://github.com/jakka351/| https://testerPresent.com.au | https://facebook.com/testerPresent        |
// /////      |--------------------------------------------------------------------------------------------------------------|
// /////      | Copyright (c) 2022/2023/2024 Benjamin Jack Leighton                                                          |          
// /////      | All rights reserved.                                                                                         |
// /////      |--------------------------------------------------------------------------------------------------------------|
// /////        Redistribution and use in source and binary forms, with or without modification, are permitted provided that
// /////        the following conditions are met:
// /////        1.    With the express written consent of the copyright holder.
// /////        2.    Redistributions of source code must retain the above copyright notice, this
// /////              list of conditions and the following disclaimer.
// /////        3.    Redistributions in binary form must reproduce the above copyright notice, this
// /////              list of conditions and the following disclaimer in the documentation and/or other
// /////              materials provided with the distribution.
// /////        4.    Neither the name of the organization nor the names of its contributors may be used to
// /////              endorse or promote products derived from this software without specific prior written permission.
// /////      _________________________________________________________________________________________________________________
// /////      THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES,
// /////      INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// /////      DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// /////      SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
// /////      SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
// /////      WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE
// /////      USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// /////      _________________________________________________________________________________________________________________
// /////
// /////       This software can only be distributed with my written permission. It is for my own educational purposes and  
// /////       is potentially dangerous to ECU health and safety. Gracias a Gato Blancoford desde las alturas del mar de chelle.                                                        
// /////      _________________________________________________________________________________________________________________
// /////
// /////
// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
#endregion License
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
// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace PassThruJ2534
{
	public partial class AlphaRomeoFifteen
	{
		// ////
		// //////////////////////////
		// ////////////////////////////////////////
		// //////////////////////////////////////////////////////
		// ////////////////////////////////////////////////////////////////////
		// ///////////////////////////////////////////////////////////////////////////////////
		// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
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
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		        // /////////////////////////////////////////////////////////////////////////////////////////////////////////////
		void mode01()
		{
			try
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
			catch(Exception Ex) { }
			
		}
		void mode02()
		{
			try
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
			catch(Exception Ex) { }
		}
		void mode03()
		{
			try
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
			catch(Exception Ex) { }

		}
		void mode04()
		{
			try
			{
				// service $04 clear DTC
				listBoxDtc.Items.Remove(1);
				byte[] mode04 = new byte[] { 0, 0, 0x7, 0xDF, 0x04 };
				sendPassThruMsg(mode04);
				listBoxDtc.Items.Add("Faults Cleared");				
			}
			catch(Exception Ex) { }
		}
		void mode05()
		{
			try
			{
				// service $05  Test results, oxygen sensor monitoring PIDS 0x0100-0x210
				byte[] mode05 = new byte[] { 0, 0, 0x7, 0xDF, 0x05, 0x01, 0x00 };
				sendPassThruMsg(mode05);
			}
			catch(Exception Ex) { }
		}
		void mode06()
		{
			try
			{
				byte[] mode06 = new byte[] { 0, 0, 0x7, 0xDF, 0x06 };
				sendPassThruMsg(mode06);				
			}
			catch(Exception Ex) { } 
		}
		void mode07()
		{
			try
			{
				byte[] mode07 = new byte[] { 0, 0, 0x7, 0xDF, 0x07 };
				sendPassThruMsg(mode07);				
			}
			catch(Exception Ex) { }
		}
		void mode08()
		{
			try
			{
				byte[] mode08 = new byte[] { 0, 0, 0x7, 0xDF, 0x08 };
				sendPassThruMsg(mode08);
			}
			catch(Exception Ex) { }
		}
		void mode09()
		{
			try
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
			catch(Exception Ex) {  }
		}
		void mode0A()
		{
			try
			{
				byte[] mode0A = new byte[] { 0, 0, 0x7, 0xDF, 0x0A };
				sendPassThruMsg(mode0A);
			}
			catch(Exception Ex) {  }
		}



		// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	}
}
