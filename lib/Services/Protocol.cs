using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassThruJ2534
{
    public partial class Protocol
    {
        public class DIAGNOSTIC_SESSION_CONTROL
        {
            public static byte service = 0x10;
            //SESSION_TYPE
            byte standardDiagnostic = 0x81;
            byte ecuProgrammingSession = 0x85;
            byte ecuAdjustmentSession = 0x87;
            byte eolExtendedSession = 0xFE;
            byte systemSupplierSpecific= 0xFA;
            // UDS
            byte standardDiagnosticUds = 0x01;
            byte ecuProgrammingSessionUds = 0x02;
            byte ecuExtendedSessionUDS = 0x03;
            byte safetySystemSession = 0x04;                
        }
        public class ECU_RESET
        {
            public static byte service = 0x11;
            //REFSET_TYPE
            public static byte keyOffOnReset = 0x01;
        }
        public class DIAGNOSTIC_TROUBLE_CODES
        {
            byte readDtc = 0x18;
            byte clearDtc = 0x14;
        }
        public class SECURITY_ACCESS
        {
            public static byte service = 0x27;
            public static byte level1 = 0x01;
            public byte level2 = 0x03;
            public byte level3 = 0x05;
        }
        public class TESTER_PRESENT
        {
            public static byte service = 0x3E;
            //RESPONS=_TYPE
            byte requestResponse = 0x01;
            byte suppressResponse = 0x02;
        }
        public class CONTROL_DTC_SETTING
        {
            public static byte service = 0x85;
        }
        public class READ_MEMORY_BY_ADDRESS
        {
            public static byte service = 0x23;
        }
    }
}
