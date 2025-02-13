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
	//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //  _______         ____________________  _______                       __  .__               __________                                                    _________            .___             
        //  \   _  \ ___  __\______  \_   _____/  \      \   ____   _________ _/  |_|__|__  __ ____   \______   \ ____   ____________   ____   ____   ______ ____   \_   ___ \  ____   __| _/____   ______
        //  /  /_\  \\  \/  /   /    /|    __)    /   |   \_/ __ \ / ___\__  \\   __\  \  \/ // __ \   |       _// __ \ /  ___/\____ \ /  _ \ /    \ /  ___// __ \  /    \  \/ /  _ \ / __ |/ __ \ /  ___/
        //  \  \_/   \>    <   /    / |     \    /    |    \  ___// /_/  > __ \|  | |  |\   /\  ___/   |    |   \  ___/ \___ \ |  |_> >  <_> )   |  \\___ \\  ___/  \     \___(  <_> ) /_/ \  ___/ \___ \ 
        //   \_____  /__/\_ \ /____/  \___  /    \____|__  /\___  >___  (____  /__| |__| \_/  \___  >  |____|_  /\___  >____  >|   __/ \____/|___|  /____  >\___  >  \______  /\____/\____ |\___  >____  >
        //         \/      \/             \/             \/     \/_____/     \/                   \/          \/     \/     \/ |__|               \/     \/     \/          \/            \/    \/     \/ 
        /// <summary>
        /// Negative Response Code Boolean Flags for indicating an error condition/code
        /// </summary>
        bool flagGeneralReject = false;
        bool flagServiceNotSupported = false;
        bool flagSubFunctionNotSupported = false;
        bool flagIncorrectMessageLength = false;
        bool flagResponseTooLong = false;
        bool flagBusyRepeatRequest = false;
        bool flagConditionsNotCorrect = false;
        bool flagRequestSequenceError = false;
        bool flagRequestOutOfRange = false;
        bool flagSecurityAccessDenied = false;
        bool flagInvalidKey = false;
        bool flagExceededNumberOfAttempts = false;
        bool flagRequiredTimeDelayNotExpired = false;
        bool flagUploadDownloadNotAccepted = false;
        bool flagTransferDataSuspended = false;
        bool flagGeneralProgrammingFailure = false;
        bool flagWrongBlockSequenceCounter = false;
        bool flagIllegalByteCountInBlockTransfer = false;
        bool flagRequestCorrectlyReceivedResponsePending = false;
        bool flagIncorrectByteCountDuringBlockTransfer = false;
        // //////////////////////////////////////////////////
        /// <summary>
        /// Dictionary for getting the status of currently flagged negative response codes.
        /// </summary>
        /// <returns>Active Negative Response Code Status</returns>
        public Dictionary<string, bool> GetActiveFlags()
        {
            var activeFlags = new Dictionary<string, bool>();
            if (flagGeneralReject) activeFlags["flagGeneralReject"] = true;
            if (flagServiceNotSupported) activeFlags["flagServiceNotSupported"] = true;
            if (flagSubFunctionNotSupported) activeFlags["flagSubFunctionNotSupported"] = true;
            if (flagIncorrectMessageLength) activeFlags["flagIncorrectMessageLength"] = true;
            if (flagResponseTooLong) activeFlags["flagResponseTooLong"] = true;
            if (flagBusyRepeatRequest) activeFlags["flagBusyRepeatRequest"] = true;
            if (flagConditionsNotCorrect) activeFlags["flagConditionsNotCorrect"] = true;
            if (flagRequestSequenceError) activeFlags["flagRequestSequenceError"] = true;
            if (flagRequestOutOfRange) activeFlags["flagRequestOutOfRange"] = true;
            if (flagSecurityAccessDenied) activeFlags["flagSecurityAccessDenied"] = true;
            if (flagInvalidKey) activeFlags["flagInvalidKey"] = true;
            if (flagExceededNumberOfAttempts) activeFlags["flagExceededNumberOfAttempts"] = true;
            if (flagRequiredTimeDelayNotExpired) activeFlags["flagRequiredTimeDelayNotExpired"] = true;
            if (flagUploadDownloadNotAccepted) activeFlags["flagUploadDownloadNotAccepted"] = true;
            if (flagTransferDataSuspended) activeFlags["flagTransferDataSuspended"] = true;
            if (flagGeneralProgrammingFailure) activeFlags["flagGeneralProgrammingFailure"] = true;
            if (flagWrongBlockSequenceCounter) activeFlags["flagWrongBlockSequenceCounter"] = true;
            if (flagIllegalByteCountInBlockTransfer) activeFlags["flagIllegalByteCountInBlockTransfer"] = true;
            if (flagRequestCorrectlyReceivedResponsePending) activeFlags["flagRequestCorrectlyReceivedResponsePending"] = true;
            if (flagIncorrectByteCountDuringBlockTransfer) activeFlags["flagIncorrectByteCountDuringBlockTransfer"] = true;
            return activeFlags;
        }
        // //////////////////////////////////////////////////
        /// <summary>
        /// Get Currently Active(boolean true status) negative response codes
        /// </summary>
        void GetActiveNegativeResponseCodes()
        {
            var activeFlagNames = GetActiveFlags();
            Log(string.Join(", ", activeFlagNames));
        }
        // //////////////////////////////////////////////////
        // Negative Response Codes - 0x7F Error String Printer and Flag Setter.
        /// <summary>
        /// When called sets the boolean to true for the negative response code that is asked for from the protocol methods. 
        /// Raising the Error Code flag allows logic to becreated for that specific error code in the protocol methods.
        /// Usage: "Log(printerr(int));"
        /// to print the error code message to the application log display
        /// </summary>
        /// <param name="error">INT returned from the diagnostic message negative response 0x7F, followed by SID Byte and then Error Code Byte </param>
        /// <returns>Error Code Definition as a string</returns>       /////////////////////////////// ////////////
        string printerr(int error)
        {
            //Sets all error code flags to be false until we parse a new error code and set its flag
            flagGeneralReject = false;
            flagServiceNotSupported = false;
            flagSubFunctionNotSupported = false;
            flagIncorrectMessageLength = false;
            flagResponseTooLong = false;
            flagBusyRepeatRequest = false;
            flagConditionsNotCorrect = false;
            flagRequestSequenceError = false;
            flagRequestOutOfRange = false;
            flagSecurityAccessDenied = false;
            flagInvalidKey = false;
            flagExceededNumberOfAttempts = false;
            flagRequiredTimeDelayNotExpired = false;
            flagUploadDownloadNotAccepted = false;
            flagTransferDataSuspended = false;
            flagGeneralProgrammingFailure = false;
            flagWrongBlockSequenceCounter = false;
            flagIllegalByteCountInBlockTransfer = false;
            flagRequestCorrectlyReceivedResponsePending = false;
            flagIncorrectByteCountDuringBlockTransfer = false;
            // Return Error Code as a string and set the boolean to true for that error code.
            switch (error)
            {
                case 0x10:
                    flagGeneralReject = true;
                    return "[0x7F]0x10 - General Reject\r\n";
                case 0x11:
                    flagServiceNotSupported = true;
                    return "[0x7F]0x11 Service Not Supported\r\n";
                case 0x12:
                    flagSubFunctionNotSupported = true;
                    return "[0x7F]0x12 Sub-Function Not Supported\r\n";
                case 0x13:
                    flagIncorrectMessageLength = true;
                    return "[0x7F]0x13 Incorrect Message Length\r\n";
                case 0x14:
                    flagResponseTooLong = true;
                    return "[0x7F]0x14 Response Too Long\r\n";
                case 0x21:
                    flagBusyRepeatRequest = true;
                    return "[0x7F]0x21 Busy Repeat Request\r\n";
                case 0x22:
                    flagConditionsNotCorrect = true;
                    return "[0x7F]0x22 Conditions Not Correct\r\n";
                case 0x24:
                    flagRequestSequenceError = true;
                    return "[0x7F]0x24 Request Sequence Error\r\n";
                case 0x31:
                    flagRequestOutOfRange = true;
                    return "[x7F]0x31 Request Out Of Range\r\n";
                case 0x33:
                    flagSecurityAccessDenied = true;
                    return "[0x7F]0x33 Security Access Denied\r\n";
                case 0x35:
                    flagInvalidKey = true;
                    return "[0x7F]0x35 Invalid Key\r\n";
                case 0x36:
                    flagExceededNumberOfAttempts = true;
                    return "[0x7F]0x36 Exceeded Number Of Attempts\r\n";
                case 0x37:
                    flagRequiredTimeDelayNotExpired = true;
                    return "[0x7F]0x37 Required Time Delay Not Expired\r\n";
                case 0x70:
                    flagUploadDownloadNotAccepted = true;
                    return "[0x7F]0x70 Upload Download Not Accepted\r\n";
                case 0x71:
                    flagTransferDataSuspended = true;
                    return "[0x7F]0x71 Transfer Data Suspended\r\n";
                case 0x72:
                    flagGeneralProgrammingFailure = true;
                    return "[0x7F]0x72 General Programming Failure/Transfer Aborted\r\n";
                case 0x73:
                    flagWrongBlockSequenceCounter = true;
                    return "[0x7F]0x73 Wrong Block Sequence Counter\r\n";
                case 0x74:
                case 0x75:
                    flagIllegalByteCountInBlockTransfer = true;
                    return "[0x7F] 0x75 Illegal Byte Count in Block Transfer\r\n";
                case 0x76:
                case 0x77:
                    break;
                case 0x78:
                    //Not really a negative response, more pending 
                    flagRequestCorrectlyReceivedResponsePending = true;
                    return "[WAIT]0x78 Request Correctly Recieved Response Pending";
                case 0x79:
                    flagIncorrectByteCountDuringBlockTransfer = true;
                    return "[0x7F] 0x79 Incorrect Byte Count During Block Transfer\r\n";
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
            return "Error Pprsing Negative Response Code data...\r\n";
        }
        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		
		// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	}
}
