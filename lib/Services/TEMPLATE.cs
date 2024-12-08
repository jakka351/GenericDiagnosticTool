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
//using Cryptography.Obfuscation;
using System.Threading;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System;
using System.IO;
using System.Drawing;
using System.Threading;
using J2534;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Emit;
using System.Collections;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace PassThruJ2534
{
	public partial class PassThru
	{
		// ////
		// //////////////////////////
		// ////////////////////////////////////////
		// //////////////////////////////////////////////////////
		// ////////////////////////////////////////////////////////////////////
		// ///////////////////////////////////////////////////////////////////////////////////
		// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////////////////\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// 16.7 Mandatory PIDs 
		// Table 16.3 defines the mandatory PIDs that shall be supported by all ECUs connected to the diagnostic 
		// link connectosr. 
		// PID Description Classification Size 
		// $0200 Number of Continuous DTCs NUM 1 Byte 
		// $0202 Number of DTCs from most recent test NUM 1 Byte 
		// Global Diagnostic Specification – Part One R&VT/EESE - Core Systems Engineering Dept. 
		// FORD CONFIDENTIAL Page 70 of 148 4/25/03, version 2003.0 
		// $D100 ECU Operating State / Mode SED 1 Byte 
		// $E200 Software Version Number PKT 3 Bytes 
		// $E217 Part Number Identification Base PKT 4 Bytes 
		// $E219 Part Number Identification Suffix PKT 2 Bytes 
		// $E21A Part Number Identification Prefix PKT 4 Bytes 
		// Table 16.3 Mandatory Supported PIDs 
		// 16.7.1 Number of Continuous DTCs (PID $0200) 
		// The Number of Continuous DTCs PID contains the number of continuous DTCs currently being stored by 
		// the ECU. 
		// 16.7.2 Number of Trouble Codes Set Due to Diagnostic Test (PID $0202) 
		// The number of trouble codes Set due to diagnostic test PID contains the number of on-demand DTCs 
		// generated during the most recent diagnostic test executed by an ECU. 
		// 16.7.3 ECU Operating State (PID $D100) 
		// ECU Operating State PID contains the ECU’s current operating state/mode, see Table 16.4.
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//   ██████╗ ██████╗ ███╗   ██╗████████╗██╗███╗   ██╗██╗   ██╗ ██████╗ ██╗   ██╗███████╗    ██████╗ ████████╗ ██████╗
		//  ██╔════╝██╔═══██╗████╗  ██║╚══██╔══╝██║████╗  ██║██║   ██║██╔═══██╗██║   ██║██╔════╝    ██╔══██╗╚══██╔══╝██╔════╝
		//  ██║     ██║   ██║██╔██╗ ██║   ██║   ██║██╔██╗ ██║██║   ██║██║   ██║██║   ██║███████╗    ██║  ██║   ██║   ██║     
		//  ██║     ██║   ██║██║╚██╗██║   ██║   ██║██║╚██╗██║██║   ██║██║   ██║██║   ██║╚════██║    ██║  ██║   ██║   ██║     
		//  ╚██████╗╚██████╔╝██║ ╚████║   ██║   ██║██║ ╚████║╚██████╔╝╚██████╔╝╚██████╔╝███████║    ██████╔╝   ██║   ╚██████╗
		//   ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝   ╚═╝   ╚═╝╚═╝  ╚═══╝ ╚═════╝  ╚═════╝  ╚═════╝ ╚══════╝    ╚═════╝    ╚═╝    ╚═════╝
		//                                                                                                                   
		///////////////////////////////////////////////////////////////////////////////////
		/// READ STANDARD AND CONTINUOUS DIAGNOSTIC CODES - SERVICE 0X18, 0X22
		/// 
		///	6.3.2.3 Reporting Continuous DTCs (Ford-9141, SCP and UBP)
		///	In response to a Request Parameter by PID (mode $22) message, with the address set to $0200 - Number
		///	of Continuous DTCs, an ECU shall return a Report Parameter by PID (mode $62) message with the
		///	number of continuous DTCs currently logged. In response to a single Request Stored Codes (mode $13)
		///	message, an ECU shall report all continuous DTCs logged by returning as many consecutive Report
		///	Stored Codes (mode $53) messages as is required. Refer to Table 6.4 for an example of the number of
		///	consecutive messages returned in relation to the number of continuous codes in a module.
		///	NOTE: There is no provision for a tester to request, or for an ECU to report, less than all of the
		///	continuous DTCs logged by a module.
		///	Continuous DTCs
		///	Logged
		///	Messages
		///	Returned
		///	Method
		///	0 1 All six Bytes of the message reserved for three DTCs shall be padded with $00
		///	1 or 2 1 DTC(s) in Data Bytes 2 & 3 and/or Data Bytes 4 & 5; the remaining Bytes shall be
		///	padded with $00
		///	3 1 All three DTCs shall be reported in Data Bytes 2 to 7 of the message
		///	4 or 5 2 The first message shall return three DTCs. The second message shall follow the
		///	method used for one or two DTCs as explained above
		///	6 2 Each message shall return three DTCs
		///	n m Follow the same method presented above for four to six DTCs
		///	Table 6.4 Consecutive Messages Returned When Reporting DTCs
		/// <summary>
		/// CONTINUOUS DTC AND STANDARD DTC READ AND CLEAR LOG
		/// </summary>
		string dtc = "";
		void readContinuousCodes()
		{
			try
			{
				Log("[0x18 readDTCByStatus] \r\n");				
				//labelFaultsDetected.Text = "";
				startDiagnosticSession(ecuAdjustment);
				byte[] readDtc = new byte[] { 0, 0, ecuId1 , ecuId2, 0x18, 0x00, 0xFF, 0x00};
				string readDtcMsg = sendPassThruMsg(readDtc);
				//0000 0728 58 0A A68020 5187E0 920161 C14060 C15960 C00260 C10060 C12160 C16460 C15160
				string responseData = readDtcMsg.Replace(" ", "");
				string responseData2 = responseData.Substring(8, 2);
				string numberOfDtc = responseData.Substring(10, 2);
				int numberOfDtcInt = Convert.ToInt32(numberOfDtc, 16) * 6;
				Log("Codes Detected: " + (numberOfDtcInt / 6) + "\r\n");				
				//labelFaultsDetected.Text = (numberOfDtcInt / 6).ToString();
				//labelFaultsDetected.ForeColor = System.Drawing.Color.Crimson;
				int j = 0;
				int response = int.Parse(responseData2, System.Globalization.NumberStyles.HexNumber);
				switch(response)
				{
					case 0x58:
						// only try to parse fault codes if we get a positive response
						for (int i = 12; j <= numberOfDtcInt; j++)
						{
							dtc += responseData.Substring(i, 6);
							string dtcStr = dtc.Substring(0, 4);
							int dtcInt = Convert.ToInt32(dtcStr, 16);;
							string code = VR_formatDTC(dtcInt);
							string code2 = dtcInt.ToString("X");
							code2 = code2.Substring(1, 3);
							dtc += " (" + code + code2 + ") ";
							string mod = textBoxDtc.Text.Substring(0, 4); //Need to create textBoxDtc
							dtc += mod;
							listBoxDtc.Items.Add(dtc); // Need to create listBoxDtc
							dtc = "";
							i = i + 6;
						}
						Log($"Diagnostic Codes Read Successfully \r\n");
						break;
					case 0x7F:
						Log($"Diagnostic Codes failed to read \r\n");
						break;
					default:
						Log("No Response from ECU\r\n");
						break;
				}
				return;					
			}
			catch (Exception ex)
			{
				Log($"DTC Error Occured: " + ex.Message);	
				return;
			}
		}
		///////////////////////////////////////////////////////////////////////////////////////////////
		/// Convert from Hexadecimal Fault Code from CAN message to human readable format EG P0100
		/// Code pinched from VTM "Vehicle Traffic Monitor" internal ford tool 
		/// Java converyed to C#F by chatGPT with ease                                       
		///////////////////////////////////////////////////////////////////////////////////////////
		private static string VR_formatDTC(int dtc)
		{
			if (dtc <= 65535)
			{
				int nibble = (dtc >> 12) & 0xF;
				switch (nibble)
				{
					case 0:
					case 1:
					case 2:
					case 3:
						return "P" + nibble;
					case 4:
					case 5:
					case 6:
					case 7:
						return "C" + (nibble - 4);
					case 8:
					case 9:
					case 10:
					case 11:
						return "B" + (nibble - 8);
					case 12:
					case 13:
					case 14:
					case 15:
						return "U" + (nibble - 12);
				}
				return VR_formatHexNumber(dtc, 4);
			}
			return null;
		}
 		//////////////////////////////////////////////////////////////////////////////////////////////
		///
		///
		///                                        
		///////////////////////////////////////////////////////////////////////////////////////////
		private static string VR_formatHexNumber(int num, int digits)
		{
			var str = "";
			if (digits == 0)
			{
				int tempNum = num;
				while (tempNum != 0)
				{
					tempNum >>= 8;
					digits++;
				}
			}
			for (int i = 0; i < digits; i++)
			{
				int shift = 4 * (digits - i - 1);
				int temp = (num & (15 << shift)) >> shift;
				if (temp < 10)
				{
					str += (char)(48 + temp);
				}
				else if (temp <= 16)
				{
					str += (char)(65 + temp - 10);
				}
			}
			return str;
		}


		
		
		// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	}
}
