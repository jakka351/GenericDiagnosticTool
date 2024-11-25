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
        // Connect the selected J2534 device from the comboBox
        private void connectSelectedJ2534Device(byte ecuId, byte ecuId2, byte ecuId3, bool highSpeed)
        {
            if(connectFlag = true)
            {
                List<J2534.J2534Device> MyListOfJ2534Devices = J2534DeviceFinder.FindInstalledJ2534DLLs();
                for (int i = 0; i < MyListOfJ2534Devices.Count; i++)
                {
                    string J2534ToolsName = MyListOfJ2534Devices[i].Name;
                    //comboBoxJ2534Devices.Items.Add(J2534ToolsName);
                    //Log("Found Installed Device: " + J2534ToolsName.ToString() + "\r\n");
                }

                // ///////////////////////////////////////////////////
                //2) Select our device and load the DLL into memory
                //Below is my fancy way of specificaly targeting a tool in the list based on its name.
                //J2534Port.LoadedDevice = MyListOfJ2534Devices.Where(x => x.Name == "CDR900").First(); //MyListOfJ2534Devices[0];
                J2534Port.LoadedDevice = MyListOfJ2534Devices[comboBoxJ2534Devices.SelectedIndex];
                if (J2534Port.Functions.LoadLibrary(J2534Port.LoadedDevice) == false)
                {
                    Log("Failed to load library DLL ERROR \r\n");
                    //Error here, DLL is fucked.
                }
                else
                {
                    Log("Library Loaded Succesfully \r\n");

                }
                Log("Selected Device: " + comboBoxJ2534Devices.SelectedItem.ToString() + "\r\n");  //get ti this point successfully
                // ///////////////////////////////////////////////////
                //3) Open the connection to the J2534 Tool
                var ErrorResult = J2534Port.Functions.PassThruOpen(IntPtr.Zero, ref DeviceID); //then error out here with invalid device number
                if (ErrorResult != J2534Err.STATUS_NOERROR)
                {
                    Log(ErrorResult.ToString() + "\r\n");
                    Log("PassThru Open ERROR) \r\n");
                }
                else
                {
                    Log("PassThru Open Success \r\n");
                }
                // ///////////////////////////////////////////////////////////////////
                //4) Start our OBD2 connection 
                //Use ProtocolID.ISO15765_PS if needing to connect to MS CAN. Have to pass the pins 3/11 to tell it to go to those.
                ushort psValue = 0x60E;
                if (highSpeedCan == true)
                {
                    ErrorResult = J2534Port.Functions.PassThruConnect(DeviceID, ProtocolID.ISO15765, ConnectFlag.NONE, BaudRate.CAN_500000, ref ChannelID);
                    if (ErrorResult != J2534Err.STATUS_NOERROR)
                    {
                        Log(ErrorResult.ToString() + "\r\n");
                        Log("PassThru Connect ERROR \r\n");
                    }
                    else
                    {
                        Log("PassThru Connect Success \r\n");
                    }
                    psValue = 0x60E;
                }
                if (highSpeedCan == false) // edited for bench rig
                {
                    //ErrorResult = J2534Port.Functions.PassThruConnect(DeviceID, ProtocolID.ISO15765, ConnectFlag.NONE, BaudRate.CAN_125000, ref ChannelID); //_PS
                    ErrorResult = J2534Port.Functions.PassThruConnect(DeviceID, ProtocolID.ISO15765_PS, ConnectFlag.NONE, BaudRate.CAN_125000, ref ChannelID); //_PS
                    if (ErrorResult != J2534Err.STATUS_NOERROR)
                    {
                        Log(ErrorResult.ToString() + "\r\n");
                        Log("PassThru Connect ERROR \r\n");
                    }
                    else
                    {
                        Log("PassThru Connect Success \r\n");
                    }
                    //psValue = 0x60E;
                    psValue = 0x30B; //0x30B for real world             

                }
                List<SConfig> configuration = new List<SConfig>();
                configuration.Add(new SConfig() { Parameter = ConfigParameter.J1962_PINS, Value = psValue }); //0x30B
                ErrorResult = J2534Port.Functions.SetConfig((int)ChannelID, ref configuration);
                if (ErrorResult != J2534Err.STATUS_NOERROR)
                {
                    Log(ErrorResult.ToString() + "\r\n");
                    Log("SConfig Pin Select ERROR \r\n");
                }
                else
                {
                    Log("SConfig Pin Select Success\r\n");
                }
                // //////////////////////////////////////////////////////////////
                //5) Set the OBD2 pins we are connecting to on the canbus line
                //Set pins if doing MSCAN or selecting the _PS channel (PS stands for Pin Select)
                //pins= 0x60E 'pin 6 for CAN H, pin 14 for CAN L
                //pins= 0x30B 'pin 3 for CAN H, pin 11 for CAN L

                ///////////////////////
                //6) Set Filters
                //A flow filter is whats required for ending multi line messages. Pass is for sending just individual messages.
                PassThruMsg maskMsg = new PassThruMsg(ProtocolID.ISO15765, TxFlag.NONE, new byte[] { 0, 0, 07, 0xFF }); //Set mask of 7FF (Only accept the exact PATTERN
                PassThruMsg patternMsg = new PassThruMsg(ProtocolID.ISO15765, TxFlag.NONE, new byte[] { 0, 0, ecuId, ecuId3 }); //Search for 7E8
                PassThruMsg flowMsg = new PassThruMsg(ProtocolID.ISO15765, TxFlag.NONE, new byte[] { 0, 0, ecuId, ecuId2 }); //Use the flow message of 7E0
                IntPtr maskPtr = maskMsg.ToIntPtr();
                IntPtr PatternPtr = patternMsg.ToIntPtr();
                IntPtr FlowPtr = flowMsg.ToIntPtr();
                ErrorResult = J2534Port.Functions.PassThruStartMsgFilter((int)ChannelID, FilterType.FLOW_CONTROL_FILTER, maskPtr, PatternPtr, FlowPtr, ref FilterID);
                if (ErrorResult != J2534Err.STATUS_NOERROR)
                {
                    Log(ErrorResult.ToString() + "\r\n");
                    //Shits fucked, couldnt set required folter
                }
                else
                {
                    Log("Control Module Start Message Filter Success \r\n");
                }

                //ALWAYS do this after all commands that use a INTPTR so that it releases any used memory/ram by that variable.
                Marshal.FreeHGlobal(maskPtr);
                Marshal.FreeHGlobal(PatternPtr);
                Marshal.FreeHGlobal(FlowPtr);
            }
            if(!connectFlag)
            {
                var ErrorResult = J2534Port.Functions.PassThruDisconnect((int)ChannelID);
                if (ErrorResult != J2534Err.STATUS_NOERROR)
                {
                    Log(ErrorResult.ToString() + "\r\n");
                    Log("PassThru Disconnect ERROR \r\n");
                }
                else
                {
                    Log("PassThru Disconnected.\r\n");
                }
                ErrorResult = J2534Port.Functions.PassThruClose(DeviceID); ;
                if (ErrorResult != J2534Err.STATUS_NOERROR)
                {
                    Log(ErrorResult.ToString() + "\r\n");
                    Log("PassThru Disconnect ERROR \r\n");
                }
                else
                {
                    Log("PassThru Library Closed. \r\n");
                }
                return;             

            }
        }



		// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	}
}
