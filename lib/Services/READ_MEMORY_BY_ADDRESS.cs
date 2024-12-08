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
		static byte[] RemoveFirstNBytes(byte[] originalArray, int n)
		{
			// Check if the original array is large enough
			if (originalArray == null || originalArray.Length <= n)
			{
				throw new ArgumentException("The original array is too small or null.");
			}
			// Create a new array with a size reduced by n
			byte[] newArray = new byte[originalArray.Length - n];
			// Copy the data from the original array to the new array, starting from index n
			Array.Copy(originalArray, n, newArray, 0, newArray.Length);
			return newArray;
		}
		// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		public byte[] readMemoryByAddress(uint address, uint blockSize)
        {
            //Send the read memory request
            byte blockSizeUpper = (byte)((blockSize >> 8) & 0xFF);
            byte blockSizeLower = (byte)(blockSize & 0xFF);
            byte[] readMemoryByAddress = new byte[] { 0, 0, ecuId, ecuId2, Protocol.READ_MEMORY_BY_ADDRESS.service, 0x00, (byte)((address >> 16) & 0xFF), (byte)((address >> 8) & 0xFF), (byte)((address) & 0xFF), blockSizeUpper, blockSizeLower };
        	int NumberOfMsgs = 1;
			PassThruMsg WriteMsg = new PassThruMsg(ProtocolID.ISO15765, TxFlag.ISO15765_FRAME_PAD, readMemoryByAddress); 
			IntPtr WritePtr = WriteMsg.ToIntPtr();
			var ErrorResult = J2534Port.Functions.PassThruWriteMsgs((int)ChannelID, WritePtr, ref NumberOfMsgs, 0);//timeout of 0 means just send it and dont care how long.
			if (ErrorResult != J2534Err.STATUS_NOERROR)
			{
				Log(ErrorResult.ToString() + "\r\n");
				flagNoDataAbort = true;
				//Shits fucked, fauled writing.
			}
			else
			{
				//addTxt1("PassThru Write Msg Success \r\n");
			}
			// ///////////////////////////////////////////////////////////////
			//8) Read Respnse
			//byte[] nodata = new byte[1];
			bool SearchForResponse = true;
			while (SearchForResponse == true)
			{
				int NumReadMsgs = 1;
				IntPtr MyRXMsg = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(PassThruMsg)) * NumReadMsgs);
				ErrorResult = J2534Port.Functions.PassThruReadMsgs((int)ChannelID, MyRXMsg, ref NumReadMsgs, 20); //this is your timeout here.
				if (ErrorResult != J2534Err.STATUS_NOERROR) //if no frames received, it goes here.
				{
					Log(ErrorResult.ToString() + "\r\n");
					Log("Failed to read PassThru Msg \r\n");
					//Shits fucked, fauled reading!!!
					break;
				}
				else
				{
					//addTxt1("PassThru Read Msg Success \r\n");
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
				}
				Log("Rx: " + DataToString + "\r\n");
				//DataToString = DataToString.Replace(" ", "");
				//DataToString = DataToString.Substring(10);
				//return DataToString;
				// 00 00 07 28 63 11 22 33 44 55 66
				// Here we are removing the first five bytes of the passthru message, and returning on the flash memory bytes //
				byte[] flashBytes = RemoveFirstNBytes(MyRXDBytes, 5);
				return flashBytes;
			}
			//string noData = "";
			//return noData;
			byte[] nodata = new byte[] {0x00};
			return nodata;
        }
		// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	}
}
