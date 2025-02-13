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
		///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//  _______          ___________         .___.__                                      __  .__         _________                    .__              _________                __                .__   
		//  \   _  \ ___  __/_   \   _  \      __| _/|__|____     ____   ____   ____  _______/  |_|__| ____  /   _____/ ____   ______ _____|__| ____   ____ \_   ___ \  ____   _____/  |________  ____ |  |  
		//  /  /_\  \\  \/  /|   /  /_\  \    / __ | |  \__  \   / ___\ /    \ /  _ \/  ___/\   __\  |/ ___\ \_____  \_/ __ \ /  ___//  ___/  |/  _ \ /    \/    \  \/ /  _ \ /    \   __\_  __ \/  _ \|  |  
		//  \  \_/   \>    < |   \  \_/   \  / /_/ | |  |/ __ \_/ /_/  >   |  (  <_> )___ \  |  | |  \  \___ /        \  ___/ \___ \ \___ \|  (  <_> )   |  \     \___(  <_> )   |  \  |  |  | \(  <_> )  |__
		//   \_____  /__/\_ \|___|\_____  /  \____ | |__(____  /\___  /|___|  /\____/____  > |__| |__|\___  >_______  /\___  >____  >____  >__|\____/|___|  /\______  /\____/|___|  /__|  |__|   \____/|____/
		//         \/      \/           \/        \/         \//_____/      \/           \/               \/        \/     \/     \/     \/               \/        \/            \/                         
		/// /////////////////////////////////                                                            /////////////////////////////////////
		// Token: 0x0600000D RID: 13 RVA: 0x00002444 File Offset: 0x00000644
		/// <summary> SERVICE: 0x10 DIAGNOSTIC SESSION CONTROL
		/// usage: startDiagnosticSession(sessionType);
		/// can.Message(arbitration_id = _DiagSig_Rx, data = [0x02, 0x10, sessionType, 0x00, 0x00, 0x00, 0x00, 0x00], is_extended_id = False)
		/// </summary>
		/// Code is working in present state 10/03/2023
		/// /////////////////////////////////                                                           /////////////////////////////////////
		/// <param name="sessionType">standardDiagnostic, ecuAdjustment, ecuProgramming, eolExtended, systemSupplierSpecific</param>
		/////////////////////////////////////                                                  /////////////////////////////////////
		public bool startDiagnosticSession(byte id0, byte id1, byte id2, byte id3, byte sessionType)
		{
        	try
        	{
            	Log("Service: [0x10 startDiagnosticSess] \r\n");
            	byte[] startDiagnosticSession = new byte[] { id0, id1, id2, id3, Protocol.DIAGNOSTIC_SESSION_CONTROL.service, sessionType};
				string startDiagnosticSessionMsg = sendPassThruMsg(startDiagnosticSession);
				startDiagnosticSessionMsg = startDiagnosticSessionMsg.Replace(" ", "");
				string startDiagnosticSessionMsg1 = startDiagnosticSessionMsg.Substring(8, 2);
				int response = int.Parse(startDiagnosticSessionMsg1, System.Globalization.NumberStyles.HexNumber);
				switch(response)
				{
					case 0x50:
						Log($"10" + sessionType + " Diagnostic Session started...\r\n");
						return true;
					case 0x7F:
						string startDiagnosticSessionMsg2 = startDiagnosticSessionMsg.Substring(12, 2);
						int errorCode = int.Parse(startDiagnosticSessionMsg2, System.Globalization.NumberStyles.HexNumber);
						Log(printerr(errorCode));
						switch(errorCode)
						{
							case 0x78:
								Log("Response Pending...Please wait \r\n");
								string pending = readPassThruMsg();
								pending = pending.Replace(" ", "");
                                pending = pending.Substring(8, 2);
                                int pendingResponse = int.Parse(pending, System.Globalization.NumberStyles.HexNumber);
								switch(pendingResponse)
								{
									case 0x50:
                                        Log($"10" + sessionType + " Diagnostic Session started...\r\n");
                                        return true;
									default:
										break;
                                }
                                break;
							default:
								System.Windows.Forms.MessageBox.Show(printerr(errorCode), 
									"Generic Diagnostic Tool - 0x10 diagnosticSessionControl", 
									MessageBoxButtons.OK, 
									MessageBoxIcon.Asterisk);		
								Log(sessionType + " Session failed to start...\r\n");
								break;
						}
						return false;
				}
				return false;            		
        	}
        	catch (Exception ex)
			{
				// Catching any exception of type Exception
				// Handle the exception here, such as logging or displaying an error message
				Log($"Session Failed to Start: " + ex.Message);
				return false;
			}
		}
		/////////////////////////////////////                              /////////////////////////////////////
		/// startDiagnosticSession (ref. KWP-GRP-1.5, 6.1.1)
		///  The parameters values supported for the diagnosticMode parameter of the startDiagnosticSession
		///  service are listed in Table 5. No other diagnosticMode values shall be supported.
		///  The baudrateIdentifier parameter shall not be used with this or any service.
		///  One and only one diagnostic session shall be active in an ECU at all times. Diagnostic session $81
		///  shall be active by default upon power-up of an ECU (i.e., a tester request message shall not be
		///  required). A tester shall have the capability of changing from any one diagnostic session to another
		///  without performing any type of security access (refer to section 2.2.2.7.6 for additional details).
		///  Diagnostic session $87 (ECUAdjustmentMode), if implemented, shall be an extended diagnostic
		///  session that is a superset of the diagnostic functionality supported in diagnostic session $81.
		///  Diagnostic session $85 (ECUProgrammingMode), if implemented, shall be used only for Method 3
		///  file download and shall be the implementation of the Method 3 programming requirements as
		///  described in MC-v2003.0.
		///  When an ECU transitions from any diagnostic session to another diagnostic session, the ECU shall
		///  reset all active diagnostic functionality that is not supported in the new diagnostic session (e.g.,
		///  security access, I/O control), with the exception of changes written to long term memory. For
		///  example, if an ECU only supports service $2F (inputOutputControlByCommonID) in diagnostic
		///  session $87 then any actively controlled inputs or outputs shall revert back to the normal value as
		///  determined by the control system upon a transition from session $87 to session $81.
		///  An ECU is allowed a 750ms re-initialization period upon returning to the default diagnostic session
		///  ($81) from any other diagnostic session. During this re-initialization period the ECU is not required to
		///  respond to any diagnostic requests.//
		///  The only defined vehicleManufacturerSpecific diagnostic session is $F0 and is defined as
		///  EOLExtendedDiagnosticSession. Any ECU that needs to grant special privileges to an End of Line
		///  test tool shall implement diagnostic session $F0 to provide access to these privileges. For example, an
		///  ABS module that normally exits to the defaultDiagnosticSession when vehicle speed is greater than a
		///  given value may maintain the EOLExtendedDiagnosticSession (despite the vehicle speed). Diagnostic
		///  session $F0 shall be reserved only for use by End of Line test tools in assembly plants and shall be
		///  implemented only when needed to verify communication with an End of Line tester. This
		///  EOLExtendedDiagnosticSession shall grant access to all functionality (e.g., diagnostic services,
		///  privileges, input/output control, etc.) that is necessary during the assembly testing and shall contain a
		///  superset of the diagnostic functionality supported in diagnostic session $87 (ECUAdjustmentMode).
		///  SystemSupplierSpecific diagnostic sessions shall not be supported by Ford test tools. All implemented
		///  systemSupplierSpecific diagnostic sessions shall be specified by the module designer and documented
		///  in the ECU's Subsystem Specific Diagnostic Specification (SSDS/Part 2).'''
		
		
		// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	}
}
