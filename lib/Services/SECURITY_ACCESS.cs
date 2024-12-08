﻿#region Copyright (c) 2024, Jack Leighton
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
		//  _______         _________________                                              __   _________                          .__  __            _____                                    
		//  \   _  \ ___  __\_____  \______  \_______   ____  ________ __   ____   _______/  |_/   _____/ ____   ____  __ _________|__|/  |_ ___.__. /  _  \   ____  ____  ____   ______ ______
		//  /  /_\  \\  \/  //  ____/   /    /\_  __ \_/ __ \/ ____/  |  \_/ __ \ /  ___/\   __\_____  \_/ __ \_/ ___\|  |  \_  __ \  \   __<   |  |/  /_\  \_/ ___\/ ___\/ __ \ /  ___//  ___/
		//  \  \_/   \>    </       \  /    /  |  | \/\  ___< <_|  |  |  /\  ___/ \___ \  |  | /        \  ___/\  \___|  |  /|  | \/  ||  |  \___  /    |    \  \__\  \__\  ___/ \___ \ \___ \ 
		//   \_____  /__/\_ \_______ \/____/   |__|    \___  >__   |____/  \___  >____  > |__|/_______  /\___  >\___  >____/ |__|  |__||__|  / ____\____|__  /\___  >___  >___  >____  >____  >
		//         \/      \/       \/                     \/   |__|           \/     \/              \/     \/     \/                       \/            \/     \/    \/    \/     \/     \/ 
		//sEcReT KeYs fRoM fOrScaN
		//'Carol', 'JAMES', 'Bosch', 'Flash', 'Bosch', 'FAITH', 'TAMER', 'REMAT', 'DIODE', 'Rowan', 'LAURA', 'JaMes', 'SAMMY', 'DIODE', 'conti', 'conti', 'Lupin', 'BOSEX', 'DIODE', 
		//'nowaR', 'PANDA', 'Jesus', 'Rowan', 'Flash', 'JAMES', 'GANES', 'SAMMY', 'Janis', 'COLIN', 'BOSCH', 'DIODE', 'Rowan', 'Rowan', 'ARIAN', 'ARIAN', 'DRIFT', 'BroWn', 'JaMes', 
		//'kbobA', '.Ted\', 'WALy\', 'euHUN', 'DRIFT', 'DRIFT', 'Flash', 'Bosch', 'Rowan', 'nowaR', 'DIODE', 'DIODE', 'DIODE', 'JaMes', 'conti', 'Rowan', 'MACOM', 'JAMES', 'MACOM', 
		//'MACOM', 'conti', 'Rowan', 'DIODE', 'BOSCH', 'JAMES', 'GANES', 'SKAND', 'FAITH', 'DIODE', 'OuTuY', 'slIor', '-MErM', 'pEde '
		/// <summary> SERVICE: 0X27 REQUEST SECURITY ACCESS seed keys 
		/// </summary>
		///         0x720: {0x01: 0x434f4c494e, 0x03: 0x40E234995F, 0x11: 0x0926F26388},
		///         0x720: {0x01: 0xfa5fc0, 0x03: 0x92c13b},
		///         0x7A6: {0x01: 0x4272616457, 0x11: 0x128665},
		///         0x727: {0x01: 0x42, 0x72, 0x61, 0x64, 0x57},
		///         0x767: {0x01: 0x4272616457}, 
		///         0x781: {0x01: 0x4272616457},
		///         0x731: {0x01: 0x672a70, 0x11: 0x462a71},0-
		///         0x760: {0x01: 0x5B4174657D, 0x03: 0x76807f, 0x11: 0x06316b}
		///////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// Security Access Function Calls with seed keys for midpeed can modules
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		//////////////////////////////////////////////////////////////////
		//var obfuscator = new Obfuscator();
		//string obfuscatedID = obfuscator.Obfuscate(15);   // e.g. xVrAndNb
		// Reverse-process:
		//int deobfuscatedID = obfusactor.Deobfuscate(obfuscatedID);  // 15
		////////////////////////////////////////////////////////////////////
		// Seed Key Bruter Forcer
		public void bruteforce()
		{
			try
			{
				Dictionary<string, int[]> keysDictionary = new Dictionary<string, int[]>
					{
					{"Key000", new int[]{ 0x00, 0x00, 0x00, 0x00, 0x00 }},
					{"Key001", new int[]{ 0xAA, 0x77, 0x5C, 0x45, 0xB7 }},
					{"Key002", new int[]{ 0x79, 0x69, 0x96, 0x56, 0xB6 }},
					{"Key003", new int[]{ 0x1A, 0x12, 0xD3, 0x98, 0x49 }},
					{"Key004", new int[]{ 0x76, 0x66, 0x84, 0x57, 0x8C }},
					{"Key005", new int[]{ 0x76, 0x66, 0x84, 0x57, 0x8C }},
					{"Key006", new int[]{ 0x88, 0x99, 0x96, 0x6A, 0x5C }},
					{"Key007", new int[]{ 0x98, 0x97, 0x68, 0x77, 0xAA }},
					{"Key008", new int[]{ 0x93, 0x46, 0x98, 0x48, 0xB9 }},
					{"Key009", new int[]{ 0x96, 0x99, 0x56, 0x94, 0x85 }},
					{"Key010", new int[]{ 0x9C, 0xCA, 0x8A, 0x7A, 0x37 }},
					{"Key011", new int[]{ 0x79, 0xB6, 0x8C, 0xA4, 0x64 }},
					{"Key012", new int[]{ 0x79, 0x69, 0x96, 0x56, 0xB6 }},
					{"Key013", new int[]{ 0x17, 0x7B, 0x6A, 0x96, 0x74 }},
					{"Key014", new int[]{ 0x7B, 0x73, 0x77, 0x6A, 0xA5 }},
					{"Key015", new int[]{ 0xA8, 0x6B, 0x9C, 0x87, 0x68 }},
					{"Key016", new int[]{ 0x98, 0x85, 0x98, 0x77, 0xA9 }},
					{"Key017", new int[]{ 0x27, 0x76, 0x76, 0x59, 0xC6 }},
					{"Key018", new int[]{ 0x75, 0x37, 0xBB, 0xD8, 0x89 }},
					{"Key019", new int[]{ 0x87, 0xC8, 0x8B, 0x77, 0xA6 }},
					{"Key020", new int[]{ 0x34, 0xD9, 0x52, 0xC9, 0x42 }},
					{"Key021", new int[]{ 0x7D, 0xD0, 0xC4, 0x76, 0x62 }},
					{"Key022", new int[]{ 0x6A, 0xA5, 0x68, 0x56, 0x5E }},
					{"Key023", new int[]{ 0x49, 0xBE, 0x98, 0x2A, 0x14 }},
					{"Key024", new int[]{ 0x08, 0x30, 0x61, 0x55, 0xAA }},
					{"Key025", new int[]{ 0x08, 0x30, 0x61, 0x55, 0xAA }},
					{"Key026", new int[]{ 0x53, 0x67, 0x98, 0xB3, 0xA4 }},
					{"Key027", new int[]{ 0xB3, 0x97, 0xC8, 0x6A, 0x37 }},
					{"Key028", new int[]{ 0x06, 0xF9, 0x04, 0x9E, 0x65 }},
					{"Key029", new int[]{ 0xB6, 0xE3, 0xD7, 0x7C, 0x3D }},
					{"Key030", new int[]{ 0x92, 0x77, 0x6B, 0x88, 0x77 }},
					{"Key031", new int[]{ 0x7B, 0x87, 0x89, 0x9B, 0x57 }},
					{"Key032", new int[]{ 0x38, 0x89, 0x85, 0x87, 0x3A }},
					{"Key033", new int[]{ 0x9A, 0xB6, 0x99, 0x6C, 0x9A }},
					{"Key034", new int[]{ 0x78, 0x77, 0x68, 0x6B, 0x53 }},
					{"Key035", new int[]{ 0x77, 0x87, 0xA5, 0x86, 0xA3 }},
					{"Key036", new int[]{ 0x5C, 0x55, 0x28, 0x9B, 0x6D }},
					{"Key037", new int[]{ 0xD1, 0xF3, 0x2D, 0x91, 0x4B }},
					{"Key038", new int[]{ 0x23, 0x11, 0xD2, 0xA2, 0x67 }},
					{"Key039", new int[]{ 0x99, 0x77, 0x88, 0x88, 0x77 }},
					{"Key040", new int[]{ 0xA7, 0x6C, 0xB2, 0x79, 0xAA }},
					{"Key041", new int[]{ 0x94, 0x87, 0xA9, 0xA6, 0x7A }},
					{"Key042", new int[]{ 0xAA, 0x76, 0x88, 0x6B, 0xA7 }},
					{"Key043", new int[]{ 0xB3, 0xB3, 0x23, 0x03, 0xA6 }},
					{"Key044", new int[]{ 0x6D, 0x82, 0x30, 0x71, 0x01 }},
					{"Key045", new int[]{ 0x96, 0x87, 0x88, 0x94, 0xA8 }},
					{"Key046", new int[]{ 0x97, 0x7A, 0xD9, 0x3C, 0x82 }},
					{"Key047", new int[]{ 0x06, 0xF9, 0x04, 0x9E, 0x65 }},
					{"Key048", new int[]{ 0xB6, 0xE3, 0xD7, 0x7C, 0x3D }},
					{"Key049", new int[]{ 0x30, 0x04, 0xAA, 0x9A, 0x7A }},
					{"Key050", new int[]{ 0x51, 0x1B, 0x53, 0x74, 0x74 }},
					{"Key051", new int[]{ 0xB5, 0x0A, 0xB4, 0x96, 0x2C }},
					{"Key052", new int[]{ 0xA2, 0xA3, 0xAC, 0xCA, 0x50 }},
					{"Key053", new int[]{ 0x85, 0x77, 0xC8, 0x65, 0x36 }},
					{"Key054", new int[]{ 0x59, 0x5B, 0x58, 0x72, 0x52 }},
					{"Key055", new int[]{ 0x20, 0xAC, 0x71, 0x5F, 0xF7 }},
					{"Key056", new int[]{ 0x3C, 0xE2, 0xDB, 0x41, 0x9A }},
					{"Key057", new int[]{ 0x83, 0x55, 0x07, 0x51, 0x9A }},
					{"Key058", new int[]{ 0x42, 0x43, 0x4D, 0x59, 0x32 }},
					{"Key059", new int[]{ 0x44, 0x49, 0x4F, 0x44, 0x45 }},
					{"Key060", new int[]{ 0x58, 0x35, 0x82, 0xC8, 0x1D }},
					{"Key061", new int[]{ 0x3F, 0x43, 0xEF, 0x74, 0xBE }},
					{"Key062", new int[]{ 0xE8, 0xD2, 0x06, 0x6D, 0xDC }},
					{"Key063", new int[]{ 0x71, 0x48, 0x77, 0xB2, 0x4B }},
					{"Key064", new int[]{ 0x1D, 0x61, 0xE5, 0xC7, 0x0D }},
					{"Key065", new int[]{ 0x06, 0x4E, 0x9A, 0xE1, 0xDE }},
					{"Key066", new int[]{ 0x6C, 0x2E, 0xA0, 0x71, 0xE6 }},
					{"Key067", new int[]{ 0x89, 0xD5, 0x7F, 0xB3, 0xA7 }},
					{"Key068", new int[]{ 0xAA, 0xCC, 0xCC, 0x33, 0x55 }},
					{"Key069", new int[]{ 0xAA, 0xCC, 0xCC, 0x33, 0x55 }},
					{"Key070", new int[]{ 0x76, 0xC4, 0x7F, 0xE5, 0x00 }},
					{"Key071", new int[]{ 0x76, 0xC4, 0x7F, 0xE5, 0x00 }},
					{"Key072", new int[]{ 0x47, 0xA7, 0x3B, 0x83, 0x62 }},
					{"Key073", new int[]{ 0x47, 0xA7, 0x3B, 0x83, 0x62 }},
					{"Key074", new int[]{ 0xB3, 0x14, 0xF1, 0x1A, 0x05 }},
					{"Key075", new int[]{ 0x08, 0x1A, 0x78, 0xBB, 0xE7 }},
					{"Key076", new int[]{ 0xB3, 0x14, 0xF1, 0x1A, 0x05 }},
					{"Key077", new int[]{ 0x08, 0x1A, 0x78, 0xBB, 0xE7 }},
					{"Key078", new int[]{ 0x08, 0x53, 0xAC, 0xDE, 0x3D }},
					{"Key079", new int[]{ 0x51, 0x9A, 0x72, 0x13, 0x1C }},
					{"Key080", new int[]{ 0xE7, 0x29, 0xD1, 0x4B, 0x41 }},
					{"Key081", new int[]{ 0xF6, 0x92, 0x02, 0x44, 0xE0 }},
					{"Key082", new int[]{ 0x76, 0x66, 0x84, 0x57, 0x8C }},
					{"Key083", new int[]{ 0x76, 0x66, 0x84, 0x57, 0x8C }},
					{"Key084", new int[]{ 0x4F, 0x53, 0x4E, 0x45, 0x44 }},
					{"Key085", new int[]{ 0x4F, 0x53, 0x4E, 0x45, 0x44 }},
					{"Key086", new int[]{ 0xE7, 0x29, 0xD1, 0x4B, 0x41 }},
					{"Key087", new int[]{ 0xF6, 0x92, 0x02, 0x44, 0xE0 }},
					{"Key088", new int[]{ 0xAA, 0x7C, 0x3A, 0xBD, 0xD9 }},
					{"Key089", new int[]{ 0xDC, 0x0D, 0xE5, 0xB1, 0xAB }},
					{"Key090", new int[]{ 0x6C, 0x5A, 0xB3, 0xC7, 0x8B }},
					{"Key091", new int[]{ 0xB2, 0x6D, 0x74, 0x9A, 0x57 }},
					{"Key092", new int[]{ 0x5F, 0x7D, 0xF5, 0xF7, 0x93 }},
					{"Key093", new int[]{ 0x9D, 0x6C, 0xC3, 0x12, 0xBB }},
					{"Key094", new int[]{ 0xE6, 0xA4, 0x02, 0xD1, 0x6A }},
					{"Key095", new int[]{ 0x31, 0x32, 0x33, 0x34, 0x35 }},
					{"Key096", new int[]{ 0x31, 0x32, 0x33, 0x34, 0x35 }},
					{"Key097", new int[]{ 0xAB, 0xDC, 0x74, 0x45, 0xC6 }},
					{"Key098", new int[]{ 0x06, 0xC3, 0x03, 0x6B, 0x0B }},
					{"Key099", new int[]{ 0x85, 0xEF, 0xF9, 0xF5, 0xDC }},
					{"Key0100", new int[]{ 0x33, 0x59, 0x00, 0x29, 0x8A }},
					{"Key0101", new int[]{ 0xA5, 0xB3, 0xEF, 0xDA, 0x76 }},
					{"Key0102", new int[]{ 0x07, 0xF5, 0x6A, 0xF9, 0x47 }},
					{"Key0103", new int[]{ 0x06, 0xF9, 0x04, 0x9E, 0x65 }},
					{"Key0104", new int[]{ 0xB6, 0xE3, 0xD7, 0x7C, 0x3D }},
					{"Key0105", new int[]{ 0x96, 0x87, 0x88, 0x94, 0xA8 }},
					{"Key0106", new int[]{ 0x97, 0x7A, 0xD9, 0x3C, 0x82 }},
					{"Key0107", new int[]{ 0xAE, 0xC7, 0xB4, 0x4B, 0xAC }},
					{"Key0108", new int[]{ 0x64, 0x06, 0xD6, 0xA6, 0xC0 }},
					{"Key0109", new int[]{ 0x3D, 0x80, 0x49, 0x83, 0xB3 }},
					{"Key0110", new int[]{ 0xA5, 0xFD, 0x4C, 0x45, 0xDA }},
					{"Key0111", new int[]{ 0xFD, 0xB3, 0xF4, 0x35, 0x88 }},
					{"Key0112", new int[]{ 0x8A, 0x81, 0xA8, 0x88, 0x82 }},
					{"Key0113", new int[]{ 0x65, 0x77, 0x78, 0x04, 0x12 }},
					{"Key0114", new int[]{ 0x65, 0x77, 0x78, 0x04, 0x12 }},
					{"Key0115", new int[]{ 0x00, 0x00, 0x00, 0x00, 0x00 }},
					{"Key0116", new int[]{ 0x4D, 0x61, 0x7A, 0x64, 0x41 }},
					{"Key0117", new int[]{ 0x01, 0x01, 0x01, 0x01, 0x01 }},
					{"Key0118", new int[]{ 0x12, 0x17, 0x01, 0xE3, 0x94 }},
					{"Key0119", new int[]{ 0x41, 0x82, 0xF6, 0x78, 0xEE }},
					{"Key0120", new int[]{ 0xC3, 0xA1, 0x09, 0x77, 0x14 }},
					{"Key0121", new int[]{ 0x2E, 0x67, 0xCB, 0x8A, 0x03 }},
					{"Key0122", new int[]{ 0xCA, 0x5B, 0x1B, 0x48, 0xAF }},
					{"Key0123", new int[]{ 0xDE, 0xB4, 0x77, 0x27, 0x04 }},
					{"Key0124", new int[]{ 0x7B, 0x03, 0xC9, 0x22, 0xF1 }},
					{"Key0125", new int[]{ 0x41, 0x52, 0x49, 0x41, 0x4E }},
					{"Key0126", new int[]{ 0x08, 0x30, 0x61, 0xA4, 0xC5 }},
					{"Key0127", new int[]{ 0x4A, 0x65, 0x73, 0x75, 0x73 }},
					{"Key0128", new int[]{ 0x13, 0x4B, 0x7C, 0xF3, 0x5C }},
					{"Key0129", new int[]{ 0x52, 0x45, 0x4D, 0x41, 0x54 }},
					{"Key0130", new int[]{ 0x54, 0x41, 0x4D, 0x45, 0x52 }},
					{"Key0131", new int[]{ 0x97, 0x62, 0x79, 0x84, 0xEC }},
					{"Key0132", new int[]{ 0x41, 0x57, 0x54, 0x43, 0x55 }},
					{"Key0133", new int[]{ 0x08, 0x30, 0x61, 0x55, 0xAA }},
					{"Key0134", new int[]{ 0x08, 0x24, 0x76, 0x01, 0x11 }},
					{"Key0135", new int[]{ 0x41, 0xAA, 0x42, 0xBB, 0x43 }},
					{"Key0136", new int[]{ 0x3A, 0x62, 0x93, 0xD6, 0xF7 }},
					{"Key0137", new int[]{ 0x2E, 0x67, 0xCB, 0x8A, 0x30 }},
					{"Key0138", new int[]{ 0x12, 0x23, 0x34, 0x45, 0x56 }},
					{"Key0139", new int[]{ 0xAD, 0xD9, 0xA2, 0x67, 0x75 }},
					{"Key0140", new int[]{ 0xAA, 0xBB, 0xCC, 0xDD, 0xEE }},
					{"Key0141", new int[]{ 0x05, 0xB7, 0x06, 0x25, 0x03 }},
					{"Key0142", new int[]{ 0x11, 0x41, 0x02, 0x98, 0xE3 }},
					{"Key0143", new int[]{ 0x2D, 0x86, 0xC5, 0x57, 0xA1 }},
					{"Key0144", new int[]{ 0x41, 0x49, 0x53, 0x49, 0x4E }},
					{"Key0145", new int[]{ 0x61, 0xEB, 0xAD, 0xC6, 0x24 }},
					{"Key0146", new int[]{ 0x3F, 0x43, 0xEF, 0x74, 0xBE }},
					{"Key0147", new int[]{ 0x46, 0x6E, 0x74, 0x63, 0x4D }},
					{"Key0148", new int[]{ 0x44, 0x67, 0xAA, 0xF2, 0x07 }},
					{"Key0149", new int[]{ 0x22, 0x7B, 0x3F, 0x23, 0x77 }},
					{"Key0150", new int[]{ 0xFE, 0x42, 0x28, 0xD3, 0xAD }},
					{"Key0151", new int[]{ 0x45, 0x4D, 0x45, 0x31, 0x53 }},
					{"Key0152", new int[]{ 0x54, 0x52, 0x4F, 0x48, 0x53 }},
					{"Key0153", new int[]{ 0xCE, 0x08, 0x91, 0xA6, 0x43 }},
					{"Key0154", new int[]{ 0x34, 0x1F, 0x3C, 0xFB, 0xC5 }},
					{"Key0155", new int[]{ 0x31, 0x49, 0x21, 0x63, 0x27 }},
					{"Key0156", new int[]{ 0x52, 0x6F, 0x77, 0x61, 0x6E }},
					{"Key0157", new int[]{ 0x24, 0x68, 0x86, 0x42, 0x04 }},
					{"Key0158", new int[]{ 0xF7, 0x32, 0xD7, 0x3A, 0x12 }},
					{"Key0159", new int[]{ 0xF4, 0x79, 0x1A, 0x60, 0xCB }},
					{"Key0160", new int[]{ 0x5A, 0x3B, 0x51, 0x4A, 0x35 }},
					{"Key0161", new int[]{ 0x2C, 0xD8, 0x73, 0xA9, 0x14 }},
					{"Key0162", new int[]{ 0x16, 0x17, 0x01, 0x08, 0x15 }},
					{"Key0163", new int[]{ 0x44, 0x52, 0x49, 0x46, 0x54 }},
					{"Key0164", new int[]{ 0xC5, 0xA4, 0x61, 0xA4, 0xA7 }},
					{"Key0165", new int[]{ 0x83, 0x55, 0x07, 0x51, 0x9A }},
					{"Key0166", new int[]{ 0x08, 0x30, 0x55, 0x61, 0xAA }},
					{"Key0167", new int[]{ 0x48, 0x41, 0x5A, 0x45, 0x4C }},
					{"Key0168", new int[]{ 0x7D, 0x2D, 0x20, 0x05, 0x78 }},
					{"Key0169", new int[]{ 0x24, 0x31, 0xDE, 0xF9, 0x46 }},
					{"Key0170", new int[]{ 0x01, 0x23, 0x45, 0x67, 0x89 }},
					{"Key0171", new int[]{ 0xA3, 0xB2, 0xC0, 0x14, 0x92 }},
					{"Key0172", new int[]{ 0xCB, 0x41, 0x12, 0x28, 0x71 }},
					{"Key0173", new int[]{ 0xC4, 0x14, 0x02, 0x11, 0x05 }},
					{"Key0174", new int[]{ 0x1E, 0x08, 0x17, 0x1B, 0x72 }},
					{"Key0175", new int[]{ 0x01, 0x09, 0xFF, 0x19, 0x64 }},
					{"Key0176", new int[]{ 0x15, 0x1F, 0x52, 0x1F, 0x7F }},
					{"Key0177", new int[]{ 0x0C, 0x04, 0x49, 0x15, 0x62 }},
					{"Key0178", new int[]{ 0x1C, 0x27, 0x50, 0x76, 0x77 }},
					{"Key0179", new int[]{ 0x01, 0x68, 0xA4, 0x78, 0xA1 }},
					{"Key0180", new int[]{ 0x57, 0xA2, 0xF7, 0xC3, 0x49 }},
					{"Key0181", new int[]{ 0x16, 0x7E, 0x04, 0xCF, 0xF5 }},
					{"Key0182", new int[]{ 0x00, 0x00, 0x00, 0x00, 0x00 }},
					{"Key0183", new int[]{ 0x00, 0x00, 0x00, 0x00, 0x00 }},
					{"Key0184", new int[]{ 0x00, 0x00, 0x00, 0x00, 0x00 }},
					{"Key0185", new int[]{ 0x00, 0x00, 0x00, 0x00, 0x00 }},
					{"Key0186", new int[]{ 0x00, 0x00, 0x00, 0x00, 0x00 }},
					{"Key0187", new int[]{ 0x00, 0x00, 0x00, 0x00, 0x00 }},
					{"Key0188", new int[]{ 0x00, 0x00, 0x00, 0x00, 0x00 }},
					{"Key0189", new int[]{ 0x00, 0x00, 0x00, 0x00, 0x00 }},
					{"Key0190", new int[]{ 0x00, 0x00, 0x00, 0x00, 0x00 }},
					{"Key0191", new int[]{ 0x00, 0x00, 0x00, 0x00, 0x00 }},
					{"Key0192", new int[]{ 0x00, 0x00, 0x00, 0x00, 0x00 }},
					{"Key0193", new int[]{ 0x00, 0x00, 0x00, 0x00, 0x00 }},
					{"Key0194", new int[]{ 0x00, 0x00, 0x00, 0x00, 0x00 }},
					{"Key0195", new int[]{ 0x00, 0x00, 0x00, 0x00, 0x00 }},
					{"Key0196", new int[]{ 0x19, 0xAC, 0x3A, 0x1C, 0xC2 }},
					{"Key0197", new int[]{ 0x3A, 0x8E, 0xCF, 0x9C, 0xCE }},
					{"Key0198", new int[]{ 0x65, 0x77, 0x78, 0x04, 0x12 }},
					{"Key0199", new int[]{ 0x3F, 0x3A, 0x2F, 0x21, 0x01 }},
					{"Key0200", new int[]{ 0xF8, 0xA9, 0x5F, 0x1D, 0x01 }},
					{"Key0201", new int[]{ 0x35, 0xE7, 0xFA, 0x6D, 0xD1 }},
					{"Key0202", new int[]{ 0x0A, 0x6D, 0xC1, 0x3B, 0x20 }},
					{"Key0203", new int[]{ 0x22, 0xA1, 0x60, 0x51, 0xA9 }},
					{"Key0204", new int[]{ 0x0D, 0x5A, 0xDB, 0xDF, 0xCA }},
					{"Key0205", new int[]{ 0x9F, 0x75, 0x4B, 0x3B, 0x87 }},
					{"Key0206", new int[]{ 0x22, 0x5F, 0xB4, 0xAC, 0x54 }},
					{"Key0207", new int[]{ 0xF4, 0x31, 0x0F, 0xB2, 0x52 }},
					{"Key0208", new int[]{ 0x29, 0x64, 0xB2, 0x72, 0xC2 }},
					{"Key0209", new int[]{ 0xF8, 0x39, 0x12, 0x96, 0x0E }},
					{"Key0210", new int[]{ 0x41, 0xAA, 0x42, 0xBB, 0x43 }},
					{"Key0211", new int[]{ 0x41, 0xAA, 0x42, 0xBB, 0x43 }},
					{"Key0212", new int[]{ 0xAA, 0x5A, 0x35, 0xBE, 0xD4 }},
					{"Key0213", new int[]{ 0x96, 0xA2, 0x3B, 0x83, 0x9B }},
					{"Key0214", new int[]{ 0xC8, 0x9B, 0x10, 0x48, 0x8D }},
					{"Key0215", new int[]{ 0x75, 0xB1, 0x56, 0x83, 0x4A }},
					{"Key0216", new int[]{ 0x9F, 0x75, 0x4B, 0x3B, 0x87 }},
					{"Key0217", new int[]{ 0x48, 0x87, 0x29, 0x88, 0x9D }},
					{"Key0218", new int[]{ 0x5E, 0x18, 0xBF, 0x9B, 0x75 }},
					{"Key0219", new int[]{ 0xA6, 0x37, 0x9E, 0x84, 0x34 }},
					{"Key0220", new int[]{ 0x11, 0x4D, 0x87, 0x75, 0xAF }},
					{"Key0221", new int[]{ 0x0E, 0xAA, 0x0B, 0xA0, 0x16 }},
					{"Key0222", new int[]{ 0xF5, 0x1E, 0x14, 0x87, 0xC0 }},
					{"Key0223", new int[]{ 0x1C, 0xF0, 0x00, 0xC1, 0x0A }},
					{"Key0224", new int[]{ 0x58, 0x05, 0x3E, 0x45, 0x9C }},
					{"Key0225", new int[]{ 0x6A, 0xA5, 0x68, 0x56, 0x5E }},
					{"Key226", new int[]{ 0x42, 0x43, 0x4D, 0x59, 0x32 }},
					{"Key0226", new int[]{ 0x45, 0x55, 0x43, 0x44, 0x31 }},
					{"Key0227", new int[]{ 0x45, 0x55, 0x43, 0x44, 0x31 }},
					{"Key0228", new int[]{ 0x88, 0x99, 0x96, 0x6A, 0x5C }},
					{"Key0229", new int[]{ 0x98, 0x97, 0x68, 0x77, 0xAA }},
					{"Key0230", new int[]{ 0x96, 0xA2, 0x3B, 0x83, 0x9B }},
					{"Key0231", new int[]{ 0xDC, 0xD5, 0x44, 0x7A, 0xE6 }},
					{"Key0232", new int[]{ 0xDC, 0xD5, 0x44, 0x7A, 0xE6 }},
					{"Key0233", new int[]{ 0x08, 0x30, 0x61, 0x55, 0xAA }},
					{"Key0234", new int[]{ 0x08, 0x30, 0x61, 0x55, 0xAA }},
					{"Key0235", new int[]{ 0x54, 0x4F, 0x42, 0x42, 0x45 }},
					{"Key0236", new int[]{ 0x54, 0x4F, 0x42, 0x42, 0x45 }},
					{"Key0237", new int[]{ 0x48, 0x53, 0x54, 0x43, 0x4D }},
					{"Key0238", new int[]{ 0x48, 0x53, 0x54, 0x43, 0x4D }},
					{"Key0239", new int[]{ 0x1F, 0x1A, 0x4F, 0x3E, 0xE6 }},
					{"Key0240", new int[]{ 0x1F, 0x1A, 0x4F, 0x3E, 0xE6 }},
					{"Key0241", new int[] { 0x41, 0xAA, 0x42, 0xBB, 0x43 }},
					{"Key0242", new int[] { 0x41, 0xAA, 0x42, 0xBB, 0x43 }},
					{"Key0243", new int[] { 0x15, 0x24, 0x33, 0x42, 0x51 }},
					{"Key0244", new int[] { 0x15, 0x24, 0x33, 0x42, 0x51 }},
					{"Key0245", new int[] { 0x01, 0x23, 0x45, 0x67, 0x89 }},
					{"Key0246", new int[] { 0x18, 0xAE, 0x78, 0x4A, 0xD2 }},
					{"Key0247", new int[] { 0x45, 0x55, 0x43, 0x44, 0x31 }},
					{"Key0248", new int[] { 0x45, 0x55, 0x43, 0x44, 0x31 }},
					{"Key0249", new int[] { 0xC9, 0xEA, 0x84, 0xCB, 0x10 }},
					{"Key0250", new int[] { 0x25, 0x92, 0xCA, 0x34, 0x29 }},
					{"Key0251", new int[] { 0x53, 0x67, 0x98, 0xB3, 0xA4 }},
					{"Key0252", new int[] { 0x08, 0x30, 0x61, 0x55, 0xAA }},
					{"Key0253", new int[] { 0x08, 0x30, 0x61, 0x55, 0xAA }},
					{"Key0254", new int[] { 0xFA, 0x6B, 0x5A, 0x70, 0x47 }},
					{"Key0255", new int[] { 0x08, 0x30, 0x61, 0x55, 0xAA }},
					{"Key0256", new int[] { 0x00, 0x00, 0x00, 0x00, 0x00 }},
					{"Key0257", new int[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }},
					{"Key0258", new int[] { 0xAC, 0x03, 0x14, 0x89, 0xE3 }},
					{"Key0259", new int[] { 0xAC, 0xF7, 0x29, 0x92, 0xE1 }},
					{"Key0260", new int[] { 0x08, 0x30, 0x61, 0x55, 0xAA }},
					{"Key0261", new int[] { 0xDD, 0x16, 0x1A, 0x48, 0xAF }},
					{"Key0262", new int[] { 0x49, 0x76, 0x66, 0x65, 0x52 }},
					{"Key0263", new int[] { 0x08, 0x28, 0x21, 0x16, 0x63 }},
					{"Key0264", new int[] { 0x0A, 0x16, 0x04, 0x07, 0xB6 }},
					{"Key0265", new int[] { 0x1B, 0x44, 0x14, 0x4D, 0x24 }},
					{"Key0266", new int[] { 0x22, 0x05, 0x12, 0x09, 0x06 }},
					{"Key0267", new int[] { 0x41, 0x51, 0x26, 0x84, 0x11 }},
					{"Key0268", new int[] { 0x48, 0x12, 0xA6, 0xD5, 0x7B }},
					{"Key0269", new int[] { 0x4A, 0x36, 0x31, 0x43, 0x46 }},
					{"Key0270", new int[] { 0x4E, 0x53, 0x59, 0x4E, 0x53 }},
					{"Key0271", new int[] { 0x50, 0x61, 0x44, 0x6D, 0x41 }},
					{"Key0272", new int[] { 0x5F, 0x9C, 0x99, 0xA3, 0x50 }},
					{"Key0273", new int[] { 0x6A, 0x55, 0x68, 0x51, 0x5E }},
					{"Key0274", new int[] { 0x6E, 0x6F, 0x77, 0x61, 0x52 }},
					{"Key0275", new int[] { 0x88, 0x6D, 0x91, 0x75, 0x7D }},
					{"Key0276", new int[] { 0xD8, 0x41, 0x5D, 0x77, 0xA5 }},
					{"Key0277", new int[] { 0x4C, 0x75, 0x70, 0x69, 0x6E }},
					{"Key0278", new int[] { 0x8C, 0x00, 0x00, 0x00, 0x00 }},
					{"Key0279", new int[] { 0x8C, 0x54, 0xF8, 0x0B, 0xD7 }},
					{"Key0280", new int[] { 0x53, 0x48, 0x4F, 0x57, 0x41 }},
					{"Key0281", new int[] { 0x47, 0x76, 0x66, 0x65, 0x52 }},
					{"Key0282", new int[] { 0x26, 0x8C, 0xB4, 0x71, 0xEE }},
					{"Key0283", new int[] { 0xAB, 0x7D, 0xD1, 0xD2, 0x71 }},
					{"Key0284", new int[] { 0x8C, 0xF5, 0xA5, 0x19, 0xEE }},
					{"Key0285", new int[] { 0x69, 0x69, 0xB6, 0x53, 0xA1 }},
					{"Key0286", new int[] { 0x4C, 0x43, 0x41, 0x42, 0x4C }},
					{"Key0287", new int[] { 0x26, 0x81, 0x45, 0x29, 0x7D }},
					{"Key0288", new int[] { 0x28, 0x81, 0x45, 0x29, 0x7D }},
					{"Key0289", new int[] { 0xDA, 0xCC, 0xCB, 0x6E, 0xB3 }},
					{"Key0290", new int[] { 0x43, 0x4F, 0x4C, 0x49, 0x4E }},
					{"Key0291", new int[] { 0x16, 0xB9, 0x13, 0x77, 0x70 }},
					{"Key0292", new int[] { 0x4D, 0x48, 0x65, 0x71, 0x79 }},
					{"Key0293", new int[] { 0x62, 0x48, 0xC5, 0xA2, 0x5F }},
					{"Key0294", new int[] { 0x5A, 0x89, 0xE4, 0x41, 0x72 }},
					{"Key0295", new int[] { 0x42, 0x72, 0x61, 0x64, 0x57 }},
					{"Key0296", new int[] { 0x4A, 0x61, 0x6E, 0x69, 0x73 }},
					{"Key0297", new int[] { 0x8A, 0x78, 0x90, 0x34, 0xF7 }},
					{"Key0298", new int[] { 0x50, 0xC8, 0x6A, 0x49, 0xF1 }},
					{"Key0299", new int[] { 0x02, 0x25, 0x19, 0x77, 0x07 }},
					{"Key0300", new int[] { 0x01, 0x02, 0x03, 0x04, 0x05 }},
					{"Key0301", new int[] { 0x24, 0x87, 0x64, 0x70, 0x32 }},
					{"Key0302", new int[] { 0x24, 0x87, 0x64, 0x65, 0x85 }},
					{"Key0303", new int[] { 0x61, 0x42, 0x2B, 0x54, 0x64 }},
					{"Key0304", new int[] { 0x16, 0x65, 0x2C, 0xEA, 0xBE }},
					{"Key0305", new int[] { 0x8C, 0x4A, 0xD2, 0x1F, 0x2E }},
					{"Key0306", new int[] { 0xDC, 0x40, 0x0A, 0x59, 0x23 }},
					{"Key0307", new int[] { 0x83, 0x9E, 0xE2, 0x12, 0xE0 }},
					{"Key0308", new int[] { 0x46, 0x4D, 0x43, 0x30, 0x31 }},
					{"Key0309", new int[] { 0xC1, 0xB0, 0xCA, 0xD0, 0x1A }},
					{"Key0310", new int[] { 0x38, 0x07, 0x8A, 0x63, 0xC1 }},
					{"Key0311", new int[] { 0xB8, 0x3F, 0x24, 0x7F, 0xFF }},
					{"Key0312", new int[] { 0x53, 0x4B, 0x65, 0x21, 0xAD }},
					{"Key0313", new int[] { 0x27, 0xA1, 0x2B, 0x19, 0x83 }},
					{"Key0314", new int[] { 0x84, 0x66, 0x08, 0x62, 0xAB }},
					{"Key0315", new int[] { 0xA3, 0x13, 0x07, 0x04, 0x7D }},
					{"Key0316", new int[] { 0x64, 0x56, 0x36, 0x4C, 0xA7 }},
					{"Key0317", new int[] { 0x11, 0x22, 0x33, 0x44, 0x55 }},
					{"Key0318", new int[] { 0x00, 0x00, 0x00, 0x00, 0x00 }},
					{"Key0319", new int[] { 0x83, 0x6A, 0xCF, 0x36, 0x1B }},
					{"Key0320", new int[] { 0x03, 0xD6, 0xB5, 0xD7, 0x6F }},
					{"Key0321", new int[] { 0x8C, 0x02, 0x0D, 0x04, 0x5F }},
					{"Key0322", new int[] { 0x98, 0x4B, 0x94, 0x08, 0xE7 }},
					{"Key0323", new int[] { 0x08, 0x03, 0x61, 0x55, 0xAA }},
					{"Key0324", new int[] { 0x62, 0x4B, 0x94, 0x08, 0xE7 }},
					{"Key0325", new int[] { 0x88, 0x2A, 0x7B, 0x93, 0x36 }},
					{"Key0326", new int[] { 0xDF, 0x3A, 0x14, 0x69, 0xC2 }},
					{"Key0327", new int[] { 0x04, 0x06, 0x07, 0x04, 0x09 }},
					{"Key0328", new int[] { 0x05, 0x3C, 0x70, 0x3A, 0x75 }},
					{"Key0329", new int[] { 0xE1, 0x84, 0xBE, 0x23, 0x29 }},
					{"Key0330", new int[] { 0xA3, 0xC1, 0xE4, 0x19, 0x89 }},
					{"Key0331", new int[] { 0x71, 0x55, 0x21, 0xA5, 0x5E }},
					{"Key0332", new int[] { 0x86, 0x9A, 0x78, 0x4D, 0x90 }},
					{"Key0333", new int[] { 0x71, 0x55, 0x21, 0x5E, 0xA5 }},
					{"Key0334", new int[] { 0x71, 0x55, 0x21, 0x41, 0xC2 }},
					{"Key0335", new int[] { 0x42, 0xD3, 0x6E, 0x34, 0xCE }},
					{"Key0336", new int[] { 0x42, 0xDD, 0x6E, 0x34, 0xCE }},
					{"Key0337", new int[] { 0x83, 0x57, 0x07, 0x33, 0x9A }},
					{"Key0338", new int[] { 0x88, 0x2A, 0x7B, 0x93, 0x54 }},
					{"Key0339", new int[] { 0x13, 0xF1, 0x29, 0xB3, 0x01 }},
					{"Key0340", new int[] { 0x5B, 0x41, 0x74, 0x65, 0x7D }},
					{"Key0341", new int[] { 0x50, 0xC8, 0x6A, 0x49, 0xF2 }},
					{"Key0342", new int[] { 0xA7, 0xC2, 0xE9, 0x19, 0x92 }},
					{"Key0343", new int[] { 0xA7, 0xC2, 0xE9, 0x2C, 0x7A }},
					{"Key0344", new int[] { 0x44, 0xDD, 0x45, 0xEE, 0x46 }},
					{"Key0345", new int[] { 0x20, 0x4A, 0xFE, 0x9C, 0x2D }},
					{"Key0346", new int[] { 0x31, 0x63, 0x46, 0x66, 0x48 }},
					{"Key0347", new int[] { 0xE9, 0xD4, 0xA1, 0x12, 0x01 }},
					{"Key0348", new int[] { 0x42, 0x6F, 0x73, 0x63, 0x68 }},
					{"Key0349", new int[] { 0x37, 0xE1, 0xA2, 0x15, 0xC8 }},
					{"Key0350", new int[] { 0x6B, 0xA7, 0x43, 0x0A, 0x71 }},
					{"Key0351", new int[] { 0x16, 0x27, 0x38, 0x49, 0x5A }},
					{"Key0352", new int[] { 0x6F, 0x6E, 0x69, 0x62, 0x68 }},
					{"Key0353", new int[] { 0x62, 0x68, 0x61, 0x77, 0x6E }},
					{"Key0354", new int[] { 0x61, 0x5F, 0x62, 0x61, 0x64 }},
					{"Key0355", new int[] { 0x5C, 0xEB, 0x11, 0x7B, 0x30 }},
					{"Key0356", new int[] { 0x00, 0x1D, 0x46, 0x0F, 0x63 }},
					{"Key0357", new int[] { 0x71, 0x18, 0xA5, 0x68, 0x68 }},
					{"Key0358", new int[] { 0xC8, 0xB2, 0xE3, 0x9E, 0x76 }},
					{"Key0359", new int[] { 0xFD, 0x4C, 0x92, 0x81, 0xED }},
					{"Key0360", new int[] { 0x71, 0x18, 0x41, 0x69, 0x68 }},
					{"Key0361", new int[] { 0x3F, 0x37, 0x5F, 0x22, 0x59 }},
					{"Key0362", new int[] { 0x4E, 0x8A, 0xE2, 0xCA, 0xD8 }},
					{"Key0363", new int[] { 0x65, 0x38, 0x74, 0x36, 0x31 }},
					{"Key0364", new int[] { 0xB6, 0x45, 0x17, 0x77, 0xD3 }},
					{"Key0365", new int[] { 0x21, 0xA4, 0x39, 0x6C, 0x04 }},
					{"Key0366", new int[] { 0x0A, 0x1E, 0x05, 0x14, 0xC2 }},
					{"Key0367", new int[] { 0x7C, 0x70, 0xD0, 0x30, 0xC1 }},
					{"Key0368", new int[] { 0x63, 0x6F, 0x6E, 0x74, 0x69 }},
					{"Key0369", new int[] { 0x6B, 0xA7, 0x24, 0x0A, 0x71 }},
					{"Key0370", new int[] { 0x1A, 0x2B, 0x3C, 0x4D, 0x5E }},
					{"Key0371", new int[] { 0xF3, 0x11, 0x45, 0x4C, 0x73 }},
					{"Key0372", new int[] { 0x17, 0x46, 0xCE, 0xB4, 0x35 }},
					{"Key0373", new int[] { 0x9A, 0x78, 0x56, 0x34, 0x12 }},
					{"Key0374", new int[] { 0x76, 0xAB, 0x51, 0x09, 0x45 }},
					{"Key0375", new int[] { 0x34, 0x23, 0x39, 0x11, 0x77 }},
					{"Key0376", new int[] { 0x41, 0x51, 0x26, 0x84, 0x01 }},
					{"Key0377", new int[] { 0x24, 0x03, 0x35, 0x63, 0x84 }},
					{"Key0378", new int[] { 0x84, 0x08, 0xF5, 0x77, 0x01 }},
					{"Key0379", new int[] { 0x19, 0x82, 0x06, 0x10, 0x03 }},
					{"Key0380", new int[] { 0x42, 0x4F, 0x53, 0x45, 0x58 }},
					{"Key0381", new int[] { 0x66, 0x6F, 0x61, 0x77, 0x65 }},
					{"Key0382", new int[] { 0x53, 0x55, 0x4D, 0x2D, 0x33 }},
					{"Key0383", new int[] { 0x12, 0x13, 0x19, 0x76, 0x30 }},
					{"Key0384", new int[] { 0x42, 0xA4, 0x83, 0x99, 0x79 }},
					{"Key0385", new int[] { 0xEF, 0xE5, 0x7A, 0x91, 0x6A }},
					{"Key0386", new int[] { 0x19, 0xD3, 0x0B, 0x2F, 0xD2 }},
					{"Key0387", new int[] { 0x14, 0x20, 0xE6, 0x89, 0x0A }},
					{"Key0388", new int[] { 0x5E, 0x10, 0x0F, 0x46, 0x33 }},
					{"Key0389", new int[] { 0x15, 0x71, 0x03, 0x19, 0x76 }},
					{"Key0390", new int[] { 0x66, 0xAF, 0x30, 0x06, 0x12 }},
					{"Key0391", new int[] { 0x20, 0xE4, 0x48, 0xE1, 0xD1 }},
					{"Key0392", new int[] { 0x28, 0xE2, 0x22, 0x63, 0x5F }},
					{"Key0393", new int[] { 0x08, 0x31, 0x61, 0xA4, 0xC5 }},
					{"Key0394", new int[] { 0xE6, 0x76, 0x3F, 0xED, 0x74 }},
					{"Key0395", new int[] { 0x4A, 0x41, 0x4D, 0x45, 0x53 }},
					{"Key0396", new int[] { 0x08, 0x08, 0x01, 0x03, 0x01 }},
					{"Key0397", new int[] { 0x54, 0x75, 0xBC, 0x4E, 0x68 }},
					{"Key0398", new int[] { 0x4D, 0x41, 0x5A, 0x44, 0x41 }},
					{"Key0399", new int[] { 0x4B, 0x30, 0x32, 0x31, 0x36 }},
					{"Key0400", new int[] { 0x6D, 0x41, 0x5A, 0x44, 0x61 }},
					{"Key0401", new int[] { 0x62, 0x1C, 0x06, 0x72, 0x60 }},
					{"Key0402", new int[] { 0x50, 0x41, 0x4E, 0x44, 0x41 }},
					{"Key0403", new int[] { 0x21, 0x27, 0x03, 0xDA, 0x27 }},
					{"Key0404", new int[] { 0x22, 0x70, 0xEA, 0x4C, 0x11 }},
					{"Key0405", new int[] { 0x46, 0x6C, 0x61, 0x73, 0x6  }},
					{"Key0406", new int[] { 0x08, 0x30, 0x61, 0x55, 0xAA }},
					{"Key0407", new int[] { 0x44, 0x49, 0x4F, 0x44, 0x45 }},
					{"Key0408", new int[] { 0x43, 0x4F, 0x4C, 0x49, 0x4E }},
					{"Key0409", new int[] { 0x44, 0x6F, 0x57, 0x5A, 0x79 }},
					{"Key0410", new int[] { 0x42, 0x72, 0x61, 0x64, 0x57 }},
					{"Key0411", new int[] { 0x4A, 0x61, 0x6E, 0x69, 0x73 }},
					{"Key0412", new int[] { 0x4A, 0x61, 0x6E, 0x69, 0x73 }},
					{"Key0413", new int[] { 0x61, 0x42, 0x2B, 0X54, 0x64 }},
					{"Key0414", new int[] { 0x8A, 0x78, 0x90, 0x34, 0xF7 }},
					{"Key0415", new int[] { 0x48, 0x37, 0x55, 0x94, 0xA9 }},
					{"Key0416", new int[] { 0xEF, 0x34, 0x84, 0xAB, 0xEA }},
					{"Key0417", new int[] { 0xBF, 0xA4, 0x90, 0x56, 0xCD }},
					{"Key0418", new int[] { 0x4A, 0x41, 0x4D, 0x45, 0x53 }},
					{"Key0419", new int[] { 0x42, 0x6F, 0x73, 0x63, 0x68 }},
					{"Key0420", new int[] { 0x46, 0x6C, 0x61, 0x73, 0x68 }},
					{"Key0421", new int[] { 0x42, 0x6F, 0x73, 0x63, 0x68 }},
					{"Key0422", new int[] { 0x46, 0x41, 0x49, 0x54, 0x48 }},
					{"Key0423", new int[] { 0x54, 0x41, 0x4D, 0x45, 0x52 }},
					{"Key0424", new int[] { 0x52, 0x45, 0x4D, 0x41, 0x54 }},
					{"Key0425", new int[] { 0x44, 0x49, 0x4F, 0x44, 0x45 }},
					{"Key0426", new int[] { 0x52, 0x6F, 0x77, 0x61, 0x6E }},
					{"Key0427", new int[] { 0x4C, 0x41, 0x55, 0x52, 0x41 }},
					{"Key0428", new int[] { 0x4A, 0x61, 0x4D, 0x65, 0x73 }},
					{"Key0429", new int[] { 0x41, 0x49, 0x53, 0x49, 0x4E }},
					{"Key0430", new int[] { 0x53, 0x41, 0x4D, 0x4D, 0x59 }},
					{"Key0431", new int[] { 0x44, 0x49, 0x4F, 0x44, 0x45 }},
					{"Key0432", new int[] { 0x63, 0x6F, 0x6E, 0x74, 0x69 }},
					{"Key0433", new int[] { 0x63, 0x6F, 0x6E, 0x74, 0x69 }},
					{"Key0434", new int[] { 0x4C, 0x75, 0x70, 0x69, 0x6E }},
					{"Key0435", new int[] { 0x42, 0x4F, 0x53, 0x45, 0x58 }},
					{"Key0436", new int[] { 0x44, 0x49, 0x4F, 0x44, 0x45 }},
					{"Key0437", new int[] { 0x6E, 0x6F, 0x77, 0x61, 0x52 }},
					{"Key0438", new int[] { 0x6E, 0x6F, 0x77, 0x61, 0x52 }},
					{"Key0439", new int[] { 0x50, 0x41, 0x4E, 0x44, 0x41 }},
					{"Key0440", new int[] { 0x4A, 0x65, 0x73, 0x75, 0x73 }},
					{"Key0441", new int[] { 0x52, 0x6F, 0x77, 0x61, 0x6E }},
					{"Key0442", new int[] { 0x46, 0x6C, 0x61, 0x73, 0x68 }},
					{"Key0443", new int[] { 0x4A, 0x41, 0x4D, 0x45, 0x53 }},
					{"Key0444", new int[] { 0x47, 0x41, 0x4E, 0x45, 0x53 }},
					{"Key0445", new int[] { 0x53, 0x41, 0x4D, 0x4D, 0x59 }},
					{"Key0446", new int[] { 0x4A, 0x61, 0x6E, 0x69, 0x73 }},
					{"Key0447", new int[] { 0x43, 0x4F, 0x4C, 0x49, 0x4E }},
					{"Key0448", new int[] { 0x42, 0x4F, 0x53, 0x43, 0x48 }},
					{"Key0449", new int[] { 0x44, 0x49, 0x4F, 0x44, 0x45 }},
					{"Key0450", new int[] { 0x52, 0x6F, 0x77, 0x61, 0x6E }},
					{"Key0451", new int[] { 0x52, 0x6F, 0x77, 0x61, 0x6E }},
					{"Key0452", new int[] { 0x41, 0x52, 0x49, 0x41, 0x4E }},
					{"Key0453", new int[] { 0x41, 0x52, 0x49, 0x41, 0x4E }},
					{"Key0454", new int[] { 0x44, 0x52, 0x49, 0x46, 0x54 }},
					{"Key0455", new int[] { 0x42, 0x72, 0x6F, 0x57, 0x6E }},
					{"Key0456", new int[] { 0x4A, 0x61, 0x4D, 0x65, 0x73 }},
					{"Key0457", new int[] { 0x44, 0x52, 0x49, 0x46, 0x54 }},
					{"Key0458", new int[] { 0x44, 0x52, 0x49, 0x46, 0x54 }},
					{"Key0459", new int[] { 0x46, 0x6C, 0x61, 0x73, 0x68 }},
					{"Key0460", new int[] { 0x42, 0x6F, 0x73, 0x63, 0x68 }},
					{"Key0461", new int[] { 0x52, 0x6F, 0x77, 0x61, 0x6E }},
					{"Key0462", new int[] { 0x6E, 0x6F, 0x77, 0x61, 0x52 }},
					{"Key0463", new int[] { 0x44, 0x49, 0x4F, 0x44, 0x45 }},
					{"Key0464", new int[] { 0x44, 0x49, 0x4F, 0x44, 0x45 }},
					{"Key0465", new int[] { 0x44, 0x49, 0x4F, 0x44, 0x45 }},
					{"Key0466", new int[] { 0x4A, 0x61, 0x4D, 0x65, 0x73 }},
					{"Key0467", new int[] { 0x63, 0x6F, 0x6E, 0x74, 0x69 }},
					{"Key0468", new int[] { 0x52, 0x6F, 0x77, 0x61, 0x6E }},
					{"Key0469", new int[] { 0x4D, 0x41, 0x43, 0x4F, 0x4D }},
					{"Key0470", new int[] { 0x4A, 0x41, 0x4D, 0x45, 0x53 }},
					{"Key0471", new int[] { 0x4D, 0x41, 0x43, 0x4F, 0x4D }},
					{"Key0472", new int[] { 0x4D, 0x41, 0x43, 0x4F, 0x4D }},
					{"Key0473", new int[] { 0x63, 0x6F, 0x6E, 0x74, 0x69 }},
					{"Key0474", new int[] { 0x52, 0x6F, 0x77, 0x61, 0x6E }},
					{"Key0475", new int[] { 0x44, 0x49, 0x4F, 0x44, 0x45 }},
					{"Key0476", new int[] { 0x42, 0x4F, 0x53, 0x43, 0x48 }},
					{"Key0477", new int[] { 0x4A, 0x41, 0x4D, 0x45, 0x53 }},
					{"Key0478", new int[] { 0x47, 0x41, 0x4E, 0x45, 0x53 }},
					{"Key0479", new int[] { 0x53, 0x4B, 0x41, 0x4E, 0x44 }},
					{"Key0480", new int[] { 0x46, 0x41, 0x49, 0x54, 0x48 }},
					{"Key0481", new int[] { 0x44, 0x49, 0x4F, 0x44, 0x45 }},
					{"Key0482", new int[] { 0x73, 0x6C, 0x49, 0x6F, 0x72 }},
					{"Key0483", new int[] { 0x2D, 0x4D, 0x45, 0x72, 0x4D }},
					{"Key0484", new int[] { 0xCB, 0x41, 0x12, 0x28, 0x71 }}
				};
				
				labelBruteforcerSuccess.Visible = false;
                labelBruteforcerFail.Visible = false;
				textBoxKey.Text = "Secret Key: ";
				pBarBruteforce.Value = 0;
                byte level;
                switch (comboBoxSecurityLevel.SelectedIndex)
                {
                    case 0x00:
                        level = 0x01;
                        break;
                    case 0x01:
                        level = 0x03;
                        break;
                    //need to finish off all the levels here
                    default:
                        level = 0x01;
                        break;
                }
                foreach (var kvp in keysDictionary)
				{
					//1($"Trying key: {keysDictionary.Key}");
					this.pBarBruteforce.Value += 1;
					int[] keyValues = kvp.Value;
					if (requestSecurityAccess0x27(ecuId, ecuId2, level, keyValues[0], keyValues[1], keyValues[2], keyValues[3], keyValues[4]) == true)
					{
						Log("Unlock Key: " + keyValues[0] + keyValues[1] + keyValues[2] + keyValues[3] + keyValues[4] + "\r\n");
						string seedKey = keyValues[0] + ", " + keyValues[1] + ", " + keyValues[2] + ", " + keyValues[3] + ", " + keyValues[4];
						textBoxKey.Text += seedKey;
						this.pBarBruteforce.Value = 484;
						labelBruteforcerSuccess.Visible = true;
						break;
					}
               
                    else
					{
						Log("Key Failed, trying next... \r\n");
						continue;
					}
				}
				
            }
			catch (Exception ex)
			{
				// Catching any exception of type Exception
				// Handle the exception here, such as logging or displaying an error message
				Log("Security Access Error: " + ex.Message);
				return;
			}
		}
        /* Bruteforce All Possible Keys
		 * Waiting to see if time out conditions come into play and prevent the ecu from sending a seed to a security risk due to too many security attempts
		 * will have to figure out the time it takes for ECU to reset before attempts can resume. at least 3000 attempts can be made before a timeout hapens
		 * Garbage Collector implemented to clear memory, clear text box every 3000 iterations
		 * reconnect J2534 every 3000 iterations, ECU reset and restart diagnostics session every 3000 iterations
		 */
        bool flagExceededNumberOfAttempts = false;
        bool flagRequiredTimeDelayNotExpired = false;
		private async Task BruteforceAllAsync()
		{
			try
			{
				Invoke(() =>
				{
					labelBruteforcerSuccess.Visible = false;
					labelBruteforcerFail.Visible = false;
					textBoxKey.Text = "Secret Key: ";
					pBarBruteforce.Value = 0;
				});
				int counter = 0;
				int[] keyValues = new int[5];
				byte level = 0x03; // Default value
				bool found = false;
				startDiagnosticSession(0x85);
				await Task.Run(async () =>
				{
					for (keyValues[0] = 0x00; keyValues[0] <= 0xFF && !found; keyValues[0]++)
					{
						for (keyValues[1] = 0x00; keyValues[1] <= 0xFF && !found; keyValues[1]++)
						{
							for (keyValues[2] = 0x00; keyValues[2] <= 0xFF && !found; keyValues[2]++)
							{
								for (keyValues[3] = 0x00; keyValues[3] <= 0xFF && !found; keyValues[3]++)
								{
									for (keyValues[4] = 0x00; keyValues[4] <= 0xFF && !found; keyValues[4]++)
									{
										// Call the method with the current keyValues
										if (requestSecurityAccess0x27async(ecuId, ecuId2, level,
																			keyValues[0], keyValues[1],
																			keyValues[2], keyValues[3],
																			keyValues[4]))
										{
											found = true;
											string seedKey = $"{keyValues[0]}, {keyValues[1]}, {keyValues[2]}, {keyValues[3]}, {keyValues[4]}";
											Invoke(() => { textBoxKey.Text += seedKey; labelBruteforcerSuccess.Visible = true; });
											return;
										}
										else
										{
											counter++;
											Log("Key Failed: " + string.Join(",", keyValues) + "\r\n");
											Log("Trying next key... \r\n");
											if (flagExceededNumberOfAttempts) { Thread.Sleep(5000); }
											if (flagRequiredTimeDelayNotExpired) { Thread.Sleep(5000); }
											if (counter == 500 || counter == 1000 || counter == 1500 || counter == 2000 || counter == 2500 || counter == 3000)
											{
												// Yield control momentarily to prevent freeze-ups.
												Log("Momentarily Pausing....\r\n");
												await Task.Delay(1000);
												Log("Continuing...\r\n");
											}
											if (counter >= 3000)
											{
												counter = 0;
												Log("Clearing Text Box to keep memory clear...\r\n");
												Invoke(() => { textBoxLog.Text = ""; });
												GC.Collect(); //GARBAGE COLLECTOR TO FREE UP MEMORY
												GC.WaitForPendingFinalizers();
												GC.Collect();
												connectFlag = false;
												Invoke(() => { connectSelectedJ2534Device(0x07, 0x37, 0x3F, true); });
												connectFlag = true;
												Invoke(() => { connectSelectedJ2534Device(0x07, 0x37, 0x3F, true); });
												Log("Resetting ECU before continuing...\r\n");
												await Task.Delay(2500);
												ecuReset(0x01);
												await Task.Delay(2500);
												startDiagnosticSession(0x85);
											}
										}
									}
								}
							}
						}
					}
				});
				// If no key was found, update UI to indicate failure
				if (!found) { Invoke(() => { labelBruteforcerFail.Visible = true; }); }
			}
			catch (OutOfMemoryException oome)
			{
				Log("OUT OF MEMORY EXCEPTION OCCURED\r\n");
				GC.Collect();
				GC.WaitForPendingFinalizers();
				GC.Collect();
				//goto memoryEx;
				// Attempt to free up resources if possible
				// Initiate a graceful shutdown or restart if necessary
				// Can we save the FOR loop and continue with the code running?
				// can we free up memory inside the for loop after X amount of iterations?
			}
			catch (Exception ex)
			{
				Log("Bruteforcing Security Access Error: " + ex.Message);

			}
		}

        bool flagConditionsNotCorrect = false;
		///////////////////////////////////////////////////////////////////////////////////////////////////////////
		/// <summary>
		/// STANDARD SECURITY ACCESS SERVICE 0x27 BOOLEAN - Mark I Algo "KeyGenMkI(int s, int sknum, int sknum2, 
		///                                                                 int sknum3, int sknum4, int sknum5)"
		/// </summary>
		/// <returns>true or false</returns>
		///////////////////////////////////////////////////////////////////////////////////////////////////
		public bool requestSecurityAccess0x27(byte ecuId, byte ecuId2, byte securityAccessLevel, int seedkey0, int seedkey1, int seedkey2, int seedkey3, int seedkey4)
		{
			try
			{
				var num = 0;
				switch(comboBoxSecurityLevel.SelectedIndex)
				{
					case 0x00:
                        securityAccessLevel = 0x01;
						break;
					case 0x01:
                        securityAccessLevel = 0x03;
						break;
					//need to finish off all the levels here
					default:
                        securityAccessLevel = 0x01;
						break;
				}
				Log("Service: [0x27 reqSecurityAccess]\r\n");
				byte[] requestSecurityAccess = new byte[] { 0, 0, ecuId, ecuId2, Protocol.SECURITY_ACCESS.service, securityAccessLevel };
				string requestSecurityAccessMsg = sendPassThruMsg(requestSecurityAccess);
				// parse response and build seed key algo into flow...
				//00  00  07  AE  67  01  AF  BB  7F 
				string responseData = requestSecurityAccessMsg.Replace(" ", "");
				string firstResponse = responseData.Substring(8, 2);
				int response01 = int.Parse(firstResponse, System.Globalization.NumberStyles.HexNumber);
				switch (response01)
				{
					case 0x67:
						Log("Security Seed Requested.\r\n");
						string seed = responseData.Substring(12, 6);
						Log("Security Seed: " + seed + "\r\n");
						string rxbuf3 = responseData.Substring(12, 2);
						string rxbuf4 = responseData.Substring(14, 2);
						string rxbuf5 = responseData.Substring(16, 2);
						Log("Converting Seed to Int32: " + rxbuf3 + rxbuf4 + rxbuf5 + "\r\n");
						int buf3 = Convert.ToInt32(rxbuf3, 16);
						int buf4 = Convert.ToInt32(rxbuf4, 16);
						int buf5 = Convert.ToInt32(rxbuf5, 16);
						Log("Calculating Response. \r\n");
						var num22 = 0;
						num22 += buf3 << 0x10;
						num22 += buf4 << 8;
						num22 += buf5;
						string responseKey = SecurityAlgorithms.Ford.CanGenericDiagnosticSeedKey(num22, seedkey0, seedkey1, seedkey2, seedkey3, seedkey4).ToString("X6");
						string response1 = responseKey.Substring(0, 2);
						string response2 = responseKey.Substring(2, 2);
						string response3 = responseKey.Substring(4, 2);
						byte responseByte1 = Convert.ToByte(response1, 16);
						byte responseByte2 = Convert.ToByte(response2, 16);
						byte responseByte3 = Convert.ToByte(response3, 16);
						byte[] requestSecurityAccess02 = new byte[] { 0, 0, ecuId, ecuId2, 0x27, 0x02, responseByte1, responseByte2, responseByte3 };
						string requestSecurityAccess02Msg = sendPassThruMsg(requestSecurityAccess02);
						string responseDataA = requestSecurityAccess02Msg.Replace(" ", "");
						string responseDataB = responseDataA.Substring(8, 2);
						//  00  00  07  2F  67  02  
						int response = int.Parse(responseDataB, System.Globalization.NumberStyles.HexNumber);
						switch (response)
						{
							case 0x67:
								Log("Security Access Granted.\r\n");
								return true;
							case 0x7F:
								Log("Security Access Denied. \r\n");
								return false;
						}
						return false;
					case 0x7F:
						//00  00  07  28  7F  27  22  
						string cnc = responseData.Substring(12, 2);
						int cnc01 = int.Parse(cnc, System.Globalization.NumberStyles.HexNumber);
						if (cnc01 == 0x22)
						{
							Log("0x22 Conditions Not Correct \r\n");
							flagConditionsNotCorrect = true;
						}
						break;
				}
				
			}
			catch (Exception ex)
			{
				Log("ECU error occurred: " + ex.Message);
			}
			return false;
		}
        public bool requestSecurityAccess0x27async(byte ecuId, byte ecuId2, byte securityAccessLevel, int seedkey0, int seedkey1, int seedkey2, int seedkey3, int seedkey4)
        {
            try
            {
                // Access comboBoxSecurityLevel on the UI thread if required
                if (comboBoxSecurityLevel.InvokeRequired)
                {
                    comboBoxSecurityLevel.Invoke(new Action(() =>
                    {
                        securityAccessLevel = GetSecurityAccessLevel(comboBoxSecurityLevel.SelectedIndex);
                    }));
                }
                else
                {
                    securityAccessLevel = GetSecurityAccessLevel(comboBoxSecurityLevel.SelectedIndex);
                }
                Log("Service: [0x27 reqSecurityAccess]\r\n");
                byte[] requestSecurityAccess = new byte[] { 0, 0, ecuId, ecuId2, Protocol.SECURITY_ACCESS.service, securityAccessLevel };
                string requestSecurityAccessMsg = sendPassThruMsg(requestSecurityAccess);
                // Parse the response
                string responseData = requestSecurityAccessMsg.Replace(" ", "");
                string firstResponse = responseData.Substring(8, 2);
                int response01 = int.Parse(firstResponse, System.Globalization.NumberStyles.HexNumber);
                switch (response01)
                {
                    case 0x67:
                        HandleSeedRequest(responseData, ecuId, ecuId2, securityAccessLevel, seedkey0, seedkey1, seedkey2, seedkey3, seedkey4);
                        break;

                    case 0x7F:
                        HandleErrorConditions(responseData);
                        break;
                }
            }
            catch (Exception ex)
            {
                // Log exception
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(() => Log("ECU error occurred: " + ex.Message)));
                }
                else
                {
                    Log("ECU error occurred: " + ex.Message);
                }
            }
            return false;
        }

        // Method to handle the seed request logic
        private void HandleSeedRequest(string responseData, byte ecuId, byte ecuId2, byte securityAccessLevel, int seedkey0, int seedkey1, int seedkey2, int seedkey3, int seedkey4)
        {
            Log("Security Seed Requested.\r\n");
            string seed = responseData.Substring(12, 6);
            Log("Security Seed: " + seed + "\r\n");

            string rxbuf3 = responseData.Substring(12, 2);
            string rxbuf4 = responseData.Substring(14, 2);
            string rxbuf5 = responseData.Substring(16, 2);

            Log("Converting Seed to Int32: " + rxbuf3 + rxbuf4 + rxbuf5 + "\r\n");

            int buf3 = Convert.ToInt32(rxbuf3, 16);
            int buf4 = Convert.ToInt32(rxbuf4, 16);
            int buf5 = Convert.ToInt32(rxbuf5, 16);

            Log("Calculating Response. \r\n");

            int num22 = (buf3 << 16) | (buf4 << 8) | buf5;
            string responseKey = SecurityAlgorithms.Ford.CanGenericDiagnosticSeedKey(num22, seedkey0, seedkey1, seedkey2, seedkey3, seedkey4).ToString("X6");

            string response1 = responseKey.Substring(0, 2);
            string response2 = responseKey.Substring(2, 2);
            string response3 = responseKey.Substring(4, 2);

            byte responseByte1 = Convert.ToByte(response1, 16);
            byte responseByte2 = Convert.ToByte(response2, 16);
            byte responseByte3 = Convert.ToByte(response3, 16);

            byte[] requestSecurityAccess02 = new byte[] { 0, 0, ecuId, ecuId2, 0x27, 0x02, responseByte1, responseByte2, responseByte3 };
            string requestSecurityAccess02Msg = sendPassThruMsg(requestSecurityAccess02);

            string responseDataA = requestSecurityAccess02Msg.Replace(" ", "");
            string responseDataB = responseDataA.Substring(8, 2);

            int response = int.Parse(responseDataB, System.Globalization.NumberStyles.HexNumber);

            if (response == 0x67)
            {
                Log("Security Access Granted.\r\n");
            }
            else if (response == 0x7F)
            {
                Log("Security Access Denied. \r\n");
            }
        }
        // Method to handle error conditions
        private void HandleErrorConditions(string responseData)
        {
            string cnc = responseData.Substring(12, 2);
            int cnc01 = int.Parse(cnc, System.Globalization.NumberStyles.HexNumber);

            if (cnc01 == 0x22)
            {
                Log("0x22 Conditions Not Correct \r\n");
                flagConditionsNotCorrect = true;
            }
			if (cnc01 == 0x36)
			{
				//[0x7F]0x36 Exceeded Number Of Attempts 
				flagExceededNumberOfAttempts = true;
            }
            if (cnc01 == 0x37)
			{
				//[0x7F]0x37 Required Time Delay Not Expired 
				flagRequiredTimeDelayNotExpired = true;
            }
        }

        // Utility to get the security access level
        private byte GetSecurityAccessLevel(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0x00:
                    return 0x01;
                case 0x01:
                    return 0x03;
                default:
                    return 0x01;
            }
        }

        // ##################################################################################################################



        // ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }
}
