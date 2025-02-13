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
    	// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        bool flagSelfTesting;
		//
		//   ██████╗ ███╗   ██╗      ██████╗ ███████╗███╗   ███╗ █████╗ ███╗   ██╗██████╗       ███████╗███████╗██╗     ███████╗ ████████╗███████╗███████╗████████╗
		//  ██╔═══██╗████╗  ██║      ██╔══██╗██╔════╝████╗ ████║██╔══██╗████╗  ██║██╔══██╗      ██╔════╝██╔════╝██║     ██╔════╝ ╚══██╔══╝██╔════╝██╔════╝╚══██╔══╝
		//  ██║   ██║██╔██╗ ██║█████╗██║  ██║█████╗  ██╔████╔██║███████║██╔██╗ ██║██║  ██║█████╗███████╗█████╗  ██║     █████╗█████╗██║   █████╗  ███████╗   ██║   
		//  ██║   ██║██║╚██╗██║╚════╝██║  ██║██╔══╝  ██║╚██╔╝██║██╔══██║██║╚██╗██║██║  ██║╚════╝╚════██║██╔══╝  ██║     ██╔══╝╚════╝██║   ██╔══╝  ╚════██║   ██║   
		//  ╚██████╔╝██║ ╚████║      ██████╔╝███████╗██║ ╚═╝ ██║██║  ██║██║ ╚████║██████╔╝      ███████║███████╗███████╗██║         ██║   ███████╗███████║   ██║   
		//   ╚═════╝ ╚═╝  ╚═══╝      ╚═════╝ ╚══════╝╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═════╝       ╚══════╝╚══════╝╚══════╝╚═╝         ╚═╝   ╚══════╝╚══════╝   ╚═╝   
		//                                                                                                                                                         
		/////////////////////////////////////////////////////////////////////////////////////////////////
		/// ON DEMAND SELF TEST
		/// Service 33 requestRoutineResults requires better NRC 0x78 Handling - see fjds logs for example
		/// 01/01/2023 0x31`and 0x33 request self test and request self test result handling implemented
		bool flagFaultCodesAfterSelfTest;
		public async Task routineControl_onDemandSelfTest(byte id0, byte id1, byte id2, byte id3)
		{
			startDiagnosticSession(0, 0, ecuId, ecuId2, 0x81);
			Invoke(new Action(() =>
			{
				Log("[0x31 startRoutineByLocalId]\r\n");
	    	}));        
            await Task.Run(() =>
            {
				try
				{
					int attempt = 1;
					startDiagnosticSession(0, 0, ecuId, ecuId2, 0x87);
					byte[] onDemandSelfTest = new byte[] { id0, id1, id2, id3, 0x31, 0x02};
					string onDemandSelfTestMsg = sendPassThruMsg(onDemandSelfTest);
					onDemandSelfTestMsg = onDemandSelfTestMsg.Replace(" ", ""); onDemandSelfTestMsg = onDemandSelfTestMsg.Substring(8, 2);
					int response = int.Parse(onDemandSelfTestMsg, System.Globalization.NumberStyles.HexNumber);
					switch(response)
					{
						case 0x71:
							// 0x7A6 0x03, 0x31, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00
							// 0x7AE 0x02, 0x71, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00
							flagSelfTesting = true;
							while (flagSelfTesting == true)
							{
								selfTesting:
									Invoke(new Action(() =>
									{
										Log("[0x33 requestRoutineResultsByLocalId]\r\n");
							    	}));
									byte[] requestRoutineResults = new byte[] { 0, 0, ecuId, ecuId2, 0x33, 0x02, 0x00 };
									string requestRoutineResultsMsg = sendPassThruMsg(requestRoutineResults);  // request routine results
									requestRoutineResultsMsg = requestRoutineResultsMsg.Replace(" ", "");
									string requestRoutineResultsMsg1 = requestRoutineResultsMsg.Substring(8, 2);
									string requestRoutineResultsMsg2= requestRoutineResultsMsg.Substring(10, 2);
									int responseR = int.Parse(requestRoutineResultsMsg, System.Globalization.NumberStyles.HexNumber);
									switch(responseR)
									{
										case 0x73:
											flagSelfTesting = false;
											Invoke(new Action(() =>
											{
												Log("Self Test Completed\r\n");
												Log("Received Routine Result\r\n");
												Log("Checking for DTCs from Test...\r\n");
									    	}));
											readContinuousCodes(); //check for DTCs
											break;
										case 0x7F:
											// 0x7A6 0x02, 0x33, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00
											// 0x7AE 0x03, 0x7F, 0x33, 0x21, 0x00, 0x00, 0x00, 0x00
											int response8 = int.Parse(requestRoutineResultsMsg2, System.Globalization.NumberStyles.HexNumber);
											switch(response8)
											{
												case 0x12:
													break;
												case 0x21:
													Invoke(new Action(() =>
													{
														Log("Self Test in Progress...\r\n");
											    	}));
													flagSelfTesting = true;	
													Thread.Sleep(50);
													goto selfTesting;
												case 0x78:
													break;
											}
											break;
										default:
											break;
									} 
							}
							break;
						case 0x7F:
							Invoke(new Action(() =>
							{
								Log("Self Test Failed to start\r\n");
					    	}));
							flagSelfTesting = false;
							break;
					}
				}
				catch(Exception Ex) 
				{ 
					Invoke(new Action(() =>
					{
						Log("Self Test Exception Occured\r\n");  
			    	}));
				}
			});
			return;
			//////////////////////////////////////////////////////////////////////////////////////////////////////
		}
	}
}
