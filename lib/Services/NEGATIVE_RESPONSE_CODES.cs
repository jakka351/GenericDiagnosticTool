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
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		//  _______         ____________________  _______                       __  .__               __________                                                    _________            .___             
		//  \   _  \ ___  __\______  \_   _____/  \      \   ____   _________ _/  |_|__|__  __ ____   \______   \ ____   ____________   ____   ____   ______ ____   \_   ___ \  ____   __| _/____   ______
		//  /  /_\  \\  \/  /   /    /|    __)    /   |   \_/ __ \ / ___\__  \\   __\  \  \/ // __ \   |       _// __ \ /  ___/\____ \ /  _ \ /    \ /  ___// __ \  /    \  \/ /  _ \ / __ |/ __ \ /  ___/
		//  \  \_/   \>    <   /    / |     \    /    |    \  ___// /_/  > __ \|  | |  |\   /\  ___/   |    |   \  ___/ \___ \ |  |_> >  <_> )   |  \\___ \\  ___/  \     \___(  <_> ) /_/ \  ___/ \___ \ 
		//   \_____  /__/\_ \ /____/  \___  /    \____|__  /\___  >___  (____  /__| |__| \_/  \___  >  |____|_  /\___  >____  >|   __/ \____/|___|  /____  >\___  >  \______  /\____/\____ |\___  >____  >
		//         \/      \/             \/             \/     \/_____/     \/                   \/          \/     \/     \/ |__|               \/     \/     \/          \/            \/    \/     \/ 
		/// 0x7F ERROR MESSAGE PRINTER
		///
		///
		/////////////////////////////// ////////////
		string printerr(int error)
		{
			if (error <= 0x26)
			{
				switch (error)
				{
					case 0x10:
						return "[0x7F]0x10 - General Reject\r\n";
				    case 0x11:
						return "[0x7F]0x11 Service Not Supported\r\n";
					case 0x12:
						return "[0x7F]0x12 Sub-Function Not Supported\r\n";
					case 0x13:
						return "[0x7F]0x13 Incorrect Message Length\r\n";
					case 0x14:
						return "[0x7F]0x14 Response Too Long\r\n";
					default:
						switch (error)
						{
							case 0x21:
								return "[0x7F]0x21 Busy Repeat Request\r\n";
							case 0x22:
								return "[0x7F]0x22 Conditions Not Correct\r\n";
							case 0x24:
								return "[0x7F]0x24 Request Sequence Error\r\n";
						}
						break;
				}
			}
			else
			{
				switch (error)
				{
					case 0x31:
						return "[x7F]0x31 Request Out Of Range\r\n";
					case 0x33:
						return "[0x7F]0x33 Security Access Denied\r\n";
					case 0x35:
						return "[0x7F]0x35 Invalid Key\r\n";
					case 0x36:
						return "[0x7F]0x36 Exceeded Number Of Attempts\r\n";
					case 0x37:
						return "[0x7F]0x37 Required Time Delay Not Expired\r\n";
				}
				switch (error)
				{
					case 0x70:
						return "[0x7F]0x70 Upload Download Not Accepted\r\n";
					case 0x71:
						return "[0x7F]0x71 Transfer Data Suspended\r\n";
					case 0x72:
						return "[0x7F]0x72 General Programming Failure\r\n";
					case 0x73:
						return "[0x7F]0x73 Wrong Block Sequence Counter\r\n";
					case 0x74:
					case 0x75:
					case 0x76:
					case 0x77:
						break;
					case 0x78:
						return "[WAIT]0x78 Request Correctly Recieved Response Pending";
					default:
						if (error == 0x7E)
						{
							return "[0x7F]0x7E Subfunction not supported in active session\r\n";
						}
						if (error == 0x7F)
						{
							return "[0x7F]0x7F Service not supported in active session\r\n";
						}
						break;
				}
			}
			return "";
		}		
		
		// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	}
}
