using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace spawnturret_tut
{
    class Spawn_Turrent
    {
        #region SV_GameSendServerCommand
        public static void SV_GameSendServerCommand(Int32 client, String command)
        {//Credits To SC58< for this function
            RPC.Call(Offsets.SV_GameSendServerCommand, new Object[] { client, 0, command });
        }
        #endregion
        #region iPrintl
        public static void iPrintln(int client, string Text)
        {
            SV_GameSendServerCommand(client, "c \"" + Text + "\"");
            Thread.Sleep(20);
        }
        #endregion
        #region Spawn Turrent by JOHN_DAT_GOON and Shark|| Few Tweaks By kiwi_modz

        private static Int32 G_Spawn()
        {
            return RPC.Call(0x01C058C); // updated
        }

        public static int OnValues(string Type, string ModelName, Single X, Single Y, Single Z, Single Pitch, Single Yaw, Single Roll)
        {
            int Ent = G_Spawn();
            PS3.WriteSingle((uint)Ent + 0x138, new float[] { X, Y, Z });
            PS3.WriteSingle((uint)Ent + 0x144, new float[] { Pitch, Yaw, Roll }); //Fixed Format. // Pitch,Yaw, Roll. kiwi_modz
            RPC.Call(0x01BEF5C, Ent, ModelName);// G_SetModel
            RPC.Call(0x01CF0E8, Ent, Type);//G_SpawnTurret
            return Ent;
        }
        public static int SpawnTurret(string Type, string ModelName, float[] Angles, float[] Pos)
        {
            int Ent = G_Spawn();
            PS3.WriteSingle((uint)Ent + 0x138, new float[] { Pos[0], Pos[1], Pos[2] });
            PS3.WriteSingle((uint)Ent + 0x144, new float[] { Angles[0], Angles[1], Angles[2] });
            RPC.Call(0x01BEF5C, Ent, ModelName);// G_SetModel
            RPC.Call(0x01CF0E8, Ent, Type);//G_SpawnTurret

            return Ent;
        }

        public static void OnAnglesToForward(uint client, uint Distance_in_Meters = 6)
        {
            float[] Origin = new float[] {
            PS3.ReadFloat(Offsets.G_Client + 0x1C + (0x3980 * (uint)client)), 
            PS3.ReadFloat(Offsets.G_Client + 0x20 + (0x3980 * (uint)client)), 
            PS3.ReadFloat(Offsets.G_Client + 0x24 + (0x3980 * (uint)client)) };
            float[] Angles = PS3.ReadSingle(Offsets.Funcs.G_Client((int)client) + 0x158, 3);
            float diff = Distance_in_Meters * 15;
            float num = ((float)Math.Sin((Angles[0] * Math.PI) / 180)) * diff;
            float num1 = (float)Math.Sqrt(((diff * diff) - (num * num)));
            float num2 = ((float)Math.Sin((Angles[1] * Math.PI) / 180)) * num1;
            float num3 = ((float)Math.Cos((Angles[1] * Math.PI) / 180)) * num1;
            float[] Forward = new float[] { Origin[0] + num3, Origin[1] + num2, Origin[2] += 50 - num };//works now
            SpawnTurret("sentry_minigun_mp", "weapon_minigun", Angles, Forward);

            //Spawn on clients AnglesToForward By Vezah. Tweaked By kiwi_modz
        }
        #endregion
    }
}
        



