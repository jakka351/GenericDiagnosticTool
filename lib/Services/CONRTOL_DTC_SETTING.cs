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
		//  _______           ______  .________                      __                .__  ________   __           _________       __    __  .__                
		//  \   _  \ ___  ___/  __  \ |   ____/   ____  ____   _____/  |________  ____ |  | \______ \_/  |_  ____  /   _____/ _____/  |__/  |_|__| ____    ____  
		//  /  /_\  \\  \/  />      < |____  \  _/ ___\/  _ \ /    \   __\_  __ \/  _ \|  |  |    |  \   __\/ ___\ \_____  \_/ __ \   __\   __\  |/    \  / ___\ 
		//  \  \_/   \>    </   --   \/       \ \  \__(  <_> )   |  \  |  |  | \(  <_> )  |__|    `   \  | \  \___ /        \  ___/|  |  |  | |  |   |  \/ /_/  >
		//   \_____  /__/\_ \______  /______  /  \___  >____/|___|  /__|  |__|   \____/|____/_______  /__|  \___  >_______  /\___  >__|  |__| |__|___|  /\___  / 
		//         \/      \/      \/       \/       \/           \/                                \/          \/        \/     \/                   \//_____/  
		// 2.2.3.1.2
		// controlDTCSetting (85 hex) service
		///////////////////
		/// <summary> SERVICE: 0X85 CONTROL DTC SETTING
		///             0x01 Off
		///             0x02 On
		/// </summary>
		////////////////////////////////////////////////////////////////////
		public void controlDtcSetting(byte onOff)
		{
			try
			{
				Log("[0x85 controlDtcSetting]\r\n");
            	byte[] controlDtcSetting = new byte[] { 0, 0, ecuId, ecuId2, Protocol.CONTROL_DTC_SETTING.service, onOff};
				string controlDtcSettingMsg = sendPassThruMsg(controlDtcSetting);
				// Logic for responsees needs to be done here...
				//00  00  07  28  C5  02
				controlDtcSettingMsg = controlDtcSettingMsg.Replace(" ", "");
				controlDtcSettingMsg = controlDtcSettingMsg.Substring(8, 2);
				int response = Convert.ToInt32(controlDtcSettingMsg, 16);
				switch(response)
				{
					case 0xC5:
						Log("DTC Logging Off...\r\n");
						break;
					case 0x7F:
						Log("Failed to Switch DTC Logging off...\r\n");
						break;
					default:
						Log("No response from ECU...\r\n");
						break;	
				}
				return;
			}
			catch (Exception ex)
			{
				Log("controlDtcSetting Error: " + ex.Message);
				return;
			}
		}
		// The controlDTCSetting service shall be used by an ECU to stop and start the setting of continuous
		// DTCs.
		// 2.2.3.1.2.1
		// Service Description
		// The controlDTCSetting request message can be used to stop the setting of diagnostic trouble codes in
		// an individual ECU. The ECU being addressed shall respond with a controlDTCSetting positive
		// response message or, if unable to stop the setting of diagnostic trouble codes, respond with a
		// controlDTCSetting negative response message indicating the reason for the reject.
		// The Lack of Diagnostic Dialog timeout requirements from Section 2.2.3.8 shall apply to this service.
		// 2.2.3.1.2.2
		// Request Message Definition
		// Table 34: controlDTCSetting Request Message Definition
		// Data Byte
		// Parameter Name
		// Cvt
		// Hex Value
		// Mnemonic
		// #1
		// controlDTCSetting Request Service Id
		// M
		// 85
		// CDTCS
		// #2
		// sub-function = [
		// DTCSettingMode ]
		// M
		// xx
		// LEV_
		// DTCSM_
		// 2.2.3.1.2.2.1 Request Message Sub-Function Parameter $Level (LEV_) Definition
		// The sub-function parameter DTCSettingMode is used by the controlDTCSetting request message to
		// indicate to ECUs whether diagnostic trouble code setting shall be either enabled or disabled. The only
		// values that shall be used are defined in Table 35.
		// Table 35: controlDTCSetting Sub-function Values
		// Hex
		// Description
		// Cvt
		// Mnemonic
		// 01
		// On
		// M
		// ON
		// The ECU shall resume the setting of diagnostic trouble codes according to normal
		// operating conditions.
		// 02
		// Off
		// M
		// OFF
		// The server(s) shall stop the setting of diagnostic trouble codes.
		// 2.2.3.1.2.3
		// Positive Response Message Definition
		// Table 36: controlDTCSetting Positive Response Message
		// Data Byte Parameter Name
		// Cvt
		// Hex Value
		// Mnemonic
		// #1
		// ControlDTCSetting Response Service Id
		// M
		// C5
		// CDTCSPR
		// #2
		// DTCSettingMode
		// M
		// xx
		// DTCSM_
		
		
		// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	}
}
