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
		// Read All PassThru Messages 
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
            PassThruMsg maskMsg1 = new PassThruMsg(ProtocolID.ISO15765, TxFlag.NONE, new byte[] { 0, 0, 0x00, 0x00 }); //Set mask of 7FF (Only accept the exact PATTERN
            PassThruMsg patternMsg1 = new PassThruMsg(ProtocolID.ISO15765, TxFlag.NONE, new byte[] { 0, 0, 07, 0xFF }); //Search for 7E8
            PassThruMsg flowMsg1 = new PassThruMsg(ProtocolID.ISO15765, TxFlag.NONE, new byte[] { 0, 0, 07, 0xE0 }); //Use the flow message of 7E0
            IntPtr maskPtr1 = maskMsg1.ToIntPtr();
            IntPtr PatternPtr1 = patternMsg1.ToIntPtr();
            IntPtr FlowPtr1 = IntPtr.Zero;
            var ErrorResult = J2534Port.Functions.PassThruStartMsgFilter((int)ChannelID, FilterType.PASS_FILTER, maskPtr1, PatternPtr1, FlowPtr1, ref FilterID);
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
            Marshal.FreeHGlobal(maskPtr1);
            Marshal.FreeHGlobal(PatternPtr1);
            Marshal.FreeHGlobal(FlowPtr1);

            // ///////////////////////////////////////////////////////////////
            // PassThruReadMsgs(int channelId, IntPtr msgs, ref int numMsgs, int timeout);
            //8) Read Respnse
            int timeout = 60;
            while (stopThread == false)
            {
                int NumReadMsgs = 1;
                IntPtr MyRXMsg = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(PassThruMsg)) * NumReadMsgs);
                ErrorResult = J2534Port.Functions.PassThruReadMsgs((int)ChannelID, MyRXMsg, ref NumReadMsgs, timeout);
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
                addTxtCAN("PassThru Msg Rx: " + DataToString + "\r\n");
                string JustForBreakpoint = "";
            }
            return;
        }
		// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	}
}
