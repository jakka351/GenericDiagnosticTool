 // /////////////////////////////////////////////////////////////////////////////
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassThruJ2534
{
    public partial class SecurityAlgorithms
    {
        public class Ford
        {
            
            public static int CanGenericDiagnosticSeedKey(int s, int sknum, int sknum2, int sknum3, int sknum4, int sknum5)
            {
                var sknum13 = (int)((byte)(s >> 0x10 & 0xFF));
                var b2 = (byte)(s >> 8 & 0xFF);
                var b3 = (byte)(s & 0xFF);
                var sknum6 = (sknum13 << 0x10) + ((int)b2 << 8) + (int)b3;
                var sknum7 = (sknum6 & 0xFF0000) >> 0x10 | (sknum6 & 0xFF00) | sknum << 0x18 | (sknum6 & 0xFF) << 0x10;
                var sknum8 = 0xC541A9;
                for (int i = 0; i < 0x20; i++)
                {
                    int sknum10;
                    int sknum9;
                    sknum8 = (((sknum9 = (sknum10 = (((sknum7 >> i & 1) ^ (sknum8 & 1)) << 0x17 | sknum8 >> 1))) & 0xEF6FD7) | ((sknum9 & 0x100000) >> 0x14 ^ (sknum10 & 0x800000) >> 0x17) << 0x14 | ((sknum8 >> 1 & 0x8000) >> 0xF ^ (sknum10 & 0x800000) >> 0x17) << 0xF | ((sknum8 >> 1 & 0x1000) >> 0xC ^ (sknum10 & 0x800000) >> 0x17) << 0xC | 0x20 * ((sknum8 >> 1 & 0x20) >> 5 ^ (sknum10 & 0x800000) >> 0x17) | 8 * ((sknum8 >> 1 & 8) >> 3 ^ (sknum10 & 0x800000) >> 0x17));
                }
                for (int j = 0; j < 0x20; j++)
                {
                    int sknum12;
                    int sknum11;
                    sknum8 = (((sknum11 = (sknum12 = ((((sknum5 << 0x18 | sknum4 << 0x10 | sknum2 | sknum3 << 8) >> j & 1) ^ (sknum8 & 1)) << 0x17 | sknum8 >> 1))) & 0xEF6FD7) | ((sknum11 & 0x100000) >> 0x14 ^ (sknum12 & 0x800000) >> 0x17) << 0x14 | ((sknum8 >> 1 & 0x8000) >> 0xF ^ (sknum12 & 0x800000) >> 0x17) << 0xF | ((sknum8 >> 1 & 0x1000) >> 0xC ^ (sknum12 & 0x800000) >> 0x17) << 0xC | 0x20 * ((sknum8 >> 1 & 0x20) >> 5 ^ (sknum12 & 0x800000) >> 0x17) | 8 * ((sknum8 >> 1 & 8) >> 3 ^ (sknum12 & 0x800000) >> 0x17));
                }
                return (sknum8 & 0xF0000) >> 0x10 | 0x10 * (sknum8 & 0xF) | ((sknum8 & 0xF00000) >> 0x14 | (sknum8 & 0xF000) >> 8) << 8 | (sknum8 & 0xFF0) >> 4 << 0x10;
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////		
        }

        public class Mazda
        {

        }
        public class JaguarLandRover
        {

        }
        public class Volkswagen
        {

        }
        public class PSA
        {
            /*
            Copyright 2020, Ludwig V. <https://github.com/ludwig-v>
            This program is free software: you can redistribute it and/or modify
            it under the terms of the GNU General Public License as published by
            the Free Software Foundation, either version 3 of the License, or
            (at your option) any later version.
            This program is distributed in the hope that it will be useful,
            but WITHOUT ANY WARRANTY; without even the implied warranty of
            MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
            GNU General Public License at <http://www.gnu.org/licenses/> for
            more details.
            The above copyright notice and this permission notice shall be included in
            all copies or substantial portions of the Software.
            */
            public static string PSASeedKeyAlgorithm(string seedTXT, string appKeyTXT)
            {
                string result = "";

                string[] seed = { seedTXT.Substring(0, 2), seedTXT.Substring(2, 2), seedTXT.Substring(4, 2), seedTXT.Substring(6, 2) };
                string[] appKey = { appKeyTXT.Substring(0, 2), appKeyTXT.Substring(2, 2) };

                long x = 0;
                long a = 0;
                long b = 0;
                long c = 0;
                long d = 0;
                long appKeyComputed = 0;
                long val = 0;
                long key = 0;
                long key_ = 0;

                x = int.Parse(appKey[0] + appKey[1], System.Globalization.NumberStyles.HexNumber);
                a = int.Parse(appKey[1] + "00" + appKey[0] + appKey[1], System.Globalization.NumberStyles.HexNumber) * 0xAA;
                if (x > 0x7FFF)
                {
                    b = ((0x0B81702E1 * (0xFFFFFFFF0000 | x)) >> 32);
                    b = ((0xFFFF0000 | (b & 0xffff)) >> 7) + 0xFE000000;
                }
                else
                {
                    b = ((0x0B81702E1 * x) >> 32) >> 7;
                }
                c = ((b + (b >> 0x1F)) & 0xffff) * 0x7673;
                d = a - c;
                if ((d & 0xffff) > 0x7FFF)
                { // Negative
                    d += 0x7673;
                }
                appKeyComputed = (d & 0xffff);

                x = int.Parse(seed[0] + seed[3], System.Globalization.NumberStyles.HexNumber);
                a = x * 0xAB;
                if (x > 0x7FFF)
                {
                    b = ((0x0B92143FB * (0xFFFFFFFF0000 | x)) >> 32);
                    b = ((0xFFFF0000 | (b & 0xffff)) >> 7) + 0xFE000000;
                }
                else
                {
                    b = ((0x0B92143FB * x) >> 32) >> 7;
                }
                c = ((b + (b >> 0x1F)) & 0xffff) * 0x763D;
                d = a - c;
                if ((d & 0xffff) > 0x7FFF)
                { // Negative
                    d += 0x763D;
                }
                d = (d & 0xffff);
                key = d | appKeyComputed;

                x = int.Parse(seed[1] + seed[2], System.Globalization.NumberStyles.HexNumber);
                a = x * 0xAA;
                if (x > 0x7FFF)
                {
                    b = ((0x0B81702E1 * (0xFFFFFFFF0000 | x)) >> 32);
                    b = ((0xFFFF0000 | (b & 0xffff)) >> 7) + 0xFE000000;
                }
                else
                {
                    b = ((0x0B81702E1 * x) >> 32) >> 7;
                }
                c = ((b + (b >> 0x1F)) & 0xffff) * 0x7673;
                d = a - c;
                if ((d & 0xffff) > 0x7FFF)
                { // Negative
                    d += 0x7673;
                }
                d = (d & 0xffff);

                val = d;

                x = (key & 0xffff);
                a = x * 0xAB;
                if (x > 0x7FFF)
                {
                    b = ((0x0B92143FB * (0xFFFFFFFF0000 | x)) >> 32);
                    b = ((0xFFFF0000 | (b & 0xffff)) >> 7) + 0xFE000000;
                }
                else
                {
                    b = ((0x0B92143FB * x) >> 32) >> 7;
                }
                c = ((b + (b >> 0x1F)) & 0xffff) * 0x763D;
                d = a - c;
                if ((d & 0xffff) > 0x7FFF)
                { // Negative
                    d += 0x763D;
                }
                d = (d & 0xffff);

                key_ = (val | d);

                result = key.ToString("X4") + key_.ToString("X4");

                return result;
            }

        }
        public class Volvo
        {
             public static int VolvoSeedKey(int s, int sknum, int sknum2, int sknum3, int sknum4, int sknum5)
            {
                var sknum13 = (int)((byte)(s >> 0x10 & 0xFF));
                var b2 = (byte)(s >> 8 & 0xFF);
                var b3 = (byte)(s & 0xFF);
                var sknum6 = (sknum13 << 0x10) + ((int)b2 << 8) + (int)b3;
                var sknum7 = (sknum6 & 0xFF0000) >> 0x10 | (sknum6 & 0xFF00) | sknum << 0x18 | (sknum6 & 0xFF) << 0x10;
                var sknum8 = 0xC541A9;
                for (int i = 0; i < 0x20; i++)
                {
                    int sknum10;
                    int sknum9;
                    sknum8 = (((sknum9 = (sknum10 = (((sknum7 >> i & 1) ^ (sknum8 & 1)) << 0x17 | sknum8 >> 1))) & 0xEF6FD7) | ((sknum9 & 0x100000) >> 0x14 ^ (sknum10 & 0x800000) >> 0x17) << 0x14 | ((sknum8 >> 1 & 0x8000) >> 0xF ^ (sknum10 & 0x800000) >> 0x17) << 0xF | ((sknum8 >> 1 & 0x1000) >> 0xC ^ (sknum10 & 0x800000) >> 0x17) << 0xC | 0x20 * ((sknum8 >> 1 & 0x20) >> 5 ^ (sknum10 & 0x800000) >> 0x17) | 8 * ((sknum8 >> 1 & 8) >> 3 ^ (sknum10 & 0x800000) >> 0x17));
                }
                for (int j = 0; j < 0x20; j++)
                {
                    int sknum12;
                    int sknum11;
                    sknum8 = (((sknum11 = (sknum12 = ((((sknum5 << 0x18 | sknum4 << 0x10 | sknum2 | sknum3 << 8) >> j & 1) ^ (sknum8 & 1)) << 0x17 | sknum8 >> 1))) & 0xEF6FD7) | ((sknum11 & 0x100000) >> 0x14 ^ (sknum12 & 0x800000) >> 0x17) << 0x14 | ((sknum8 >> 1 & 0x8000) >> 0xF ^ (sknum12 & 0x800000) >> 0x17) << 0xF | ((sknum8 >> 1 & 0x1000) >> 0xC ^ (sknum12 & 0x800000) >> 0x17) << 0xC | 0x20 * ((sknum8 >> 1 & 0x20) >> 5 ^ (sknum12 & 0x800000) >> 0x17) | 8 * ((sknum8 >> 1 & 8) >> 3 ^ (sknum12 & 0x800000) >> 0x17));
                }
                return (sknum8 & 0xF0000) >> 0x10 | 0x10 * (sknum8 & 0xF) | ((sknum8 & 0xF00000) >> 0x14 | (sknum8 & 0xF000) >> 8) << 8 | (sknum8 & 0xFF0) >> 4 << 0x10;
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////     
        }
    }
}
