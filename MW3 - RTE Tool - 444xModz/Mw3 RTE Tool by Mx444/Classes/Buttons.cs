using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


     class Buttons
    {
        public static UInt32
        X = 1024,
        O = 512,
        Square = 2097152,
        L3 = 139264,
        R3 = 262144,
        L2 = 32768,
        R2 = 16384,
        Start = 128,
        L1 = 2056,
        R1 = 65536,
        Crouch = 512,
        NoButtonPressed = 0000;
        public static UInt32 DetectButton(Int32 clientID)
        {
            byte[] tits = new byte[4];
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.GetMemory(Offsets.Funcs.G_Client(clientID, 0x3609), tits);
            return System.BitConverter.ToUInt32(tits, 0);
        }
}
