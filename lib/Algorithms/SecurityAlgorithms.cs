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
        public class Volvo
        {
            
        }
    }
}
