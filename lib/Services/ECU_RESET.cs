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
		//  _______          ____ ____                     __________                      __   
		//  \   _  \ ___  __/_   /_   |   ____   ____  __ _\______   \ ____   ______ _____/  |_ 
		//  /  /_\  \\  \/  /|   ||   | _/ __ \_/ ___\|  |  \       _// __ \ /  ___// __ \   __\
		//  \  \_/   \>    < |   ||   | \  ___/\  \___|  |  /    |   \  ___/ \___ \\  ___/|  |  
		//   \_____  /__/\_ \|___||___|  \___  >\___  >____/|____|_  /\___  >____  >\___  >__|  
		//         \/      \/                \/     \/             \/     \/     \/     \/      
		////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary> SERVICE: 0X11 ECU RESET 
		/// usage: "ecuReset(resetType, sender, e);"
		/// can.Message(arbitration_id = _DiagSig_Rx, data = [0x02, 0x11, resetType, 0, 0, 0, 0, 0], is_extended_id = False)
		//  ECUReset
		//      Only the powerOn value of the resetMode (RM_) parameter shall be supported. The resetStatus (RS_)
		//      parameter shall not be supported.
		//      The positive response to an ECUReset (service $11) request shall occur before the ECU performs the
		//      reset. An ECU is allowed a 750ms re-initialization period after providing a positive response to an
		//      ECUReset request. During this re-initialization period the ECU is not required to respond to any
		//      diagnostic requests.
		/// </summary>
		/////////////////////////////////////
		/// <param name="resetType">01 = hardReset 02 = keyOffOnReset 03 = softReset 04 = enableRapidPowerShutDown 05 = disableRapidPowerShutdown</param>
		void ecuReset(byte resetType)
		{
			try
			{
				Log("Service: [0x11 ecuReset]\r\n");
            	byte[] ecuReset = new byte[] { 0, 0, ecuId, ecuId2, Protocol.ECU_RESET.service, resetType};
				string ecuResetMsg = sendPassThruMsg(ecuReset);
				// Logic for responsees needs to be done here...
				// 00  00  07  28  51  
				ecuResetMsg = ecuResetMsg.Replace(" ", "");
				string ecuResetMsg1 = ecuResetMsg.Substring(8, 2);
				int response = int.Parse(ecuResetMsg1, System.Globalization.NumberStyles.HexNumber);
				switch(response)
				{
					case 0x51:
						//Log("[0x11 ecuReset]\r\n");
						Log($"ECU has been Rebooted.\r\n");
						break;
					case 0x7F:
						Log($"ECU Reboot Failed...\r\n");
						string err = ecuResetMsg.Substring(12, 2);
						int errorCode = Convert.ToInt32(err, 16);
						Log(printerr(errorCode)); // printing the error code definition from printerr(int)
						System.Windows.Forms.MessageBox.Show(printerr(errorCode), "Generic Diagnostic Tool - 0x11 ecuReset", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						break;
				}
				return;
			}
			catch (Exception ex)
			{
				Log("ECU Reset Error Occurred: " + ex.Message);
				return;
			}
		}
		// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	}
}
