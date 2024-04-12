using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Call_Of_Duty_Multi_Tool_1._0._0
{
    public partial class TurretSpawn : MetroFramework.Forms.MetroForm
    {
        public TurretSpawn()
        {
            InitializeComponent();
            spawnturret_tut.PS3.Connect();
            spawnturret_tut.PS3.Attach();
            spawnturret_tut.RPC.Enable();

        }

        private void TurretSpawn_Load(object sender, EventArgs e)
        {

        }

        private void POS_Tick(object sender, EventArgs e)
        {
            int Client = 0;
            {   // Position In Real Time.
                float[] POS = new float[] { 
                spawnturret_tut.PS3.ReadFloat(Offsets.G_Client + 0x1C + (0x3980 * (uint)Client)),
                spawnturret_tut.PS3.ReadFloat(Offsets.G_Client + 0x20 + (0x3980 * (uint)Client)), 
                spawnturret_tut.PS3.ReadFloat(Offsets.G_Client + 0x24 + (0x3980 * (uint)Client)) };
                float[] Angles = spawnturret_tut.PS3.ReadSingle(Offsets.Funcs.G_Client((int)Client) + 0x158, 3);
                float[] pos = new float[] { POS[0], POS[1], POS[2] += 50 };
                float[] angles = new float[] { Angles[0], Angles[1], Angles[2] };
                float X = POS[0]; float Y = POS[1]; float Z = POS[2];
                float Pitch = Angles[0]; float Yaw = Angles[1]; float Roll = Angles[2];
                string a = "Your Pos : X: " + X.ToString("F1") + "  Y: " + Y.ToString("F1") + "  Z: " + Z.ToString("F1");
                string b = "Your Angles : Pitch: " + Pitch.ToString("F1") + "  Yaw: " + Yaw.ToString("F1");
                label22.Text = a;
                label24.Text = b;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (button15.Text == "Pos [ OFF ]")
            {
                POS.Start();
                button15.Text = "Pos [ ON ]";

            }
            else if (button15.Text == "Pos [ ON ]")
            {
                POS.Stop();
                button15.Text = "Pos [ OFF ]";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Copy to Clipboard/ auto code func.
            int Client = 0;
            {
                float[] POS = new float[] { 
                spawnturret_tut.PS3.ReadFloat(Offsets.G_Client + 0x1C + (0x3980 * (uint)Client)),
                spawnturret_tut.PS3.ReadFloat(Offsets.G_Client + 0x20 + (0x3980 * (uint)Client)), 
                spawnturret_tut.PS3.ReadFloat(Offsets.G_Client + 0x24 + (0x3980 * (uint)Client)) };
                float[] Angles = spawnturret_tut.PS3.ReadSingle(Offsets.Funcs.G_Client((int)Client) + 0x158, 3);
                float[] pos = new float[] { POS[0], POS[1], POS[2] += 50 };
                float[] angles = new float[] { Angles[0], Angles[1], Angles[2] };
                float X = POS[0]; float Y = POS[1]; float Z = POS[2];
                float Pitch = Angles[0]; float Yaw = Angles[1]; float Roll = Angles[2];
                string a = "Spawn_Turrent.OnValues(" + @"""sentry_minigun_mp""," + @"""weapon_minigun"", (int)" + X.ToString("F1") + ", (int)" + Y.ToString("F1") + ", (int)" + Z.ToString("F1") + ", (int)" + Pitch.ToString("F1") + ", (int)" + Yaw.ToString("F1") + ", (int)" + Roll.ToString("F1") + ");";
                string b = "Your Pos : X: " + X.ToString("F1") + "  Y: " + Y.ToString("F1") + "  Z: " + Z.ToString("F1");
                string c = "Your Angles : Pitch: " + Pitch.ToString("F1") + "  Yaw: " + Yaw.ToString("F1");
                label22.Text = b;
                label24.Text = c;
                Clipboard.SetText(a);
                MessageBox.Show(a, "Copied to Clipboard");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
             int Client = 0;
            {
                float[] POS = new float[] {
                spawnturret_tut.PS3.ReadFloat(Offsets.G_Client + 0x1C + (0x3980 * (uint)Client)),
                spawnturret_tut.PS3.ReadFloat(Offsets.G_Client + 0x20 + (0x3980 * (uint)Client)), 
                spawnturret_tut.PS3.ReadFloat(Offsets.G_Client + 0x24 + (0x3980 * (uint)Client)) };
                float[] Angles = spawnturret_tut.PS3.ReadSingle(Offsets.Funcs.G_Client((int)Client) + 0x158, 3);
                float[] pos = new float[] { POS[0], POS[1], POS[2] += 50 };
                float[] angles = new float[] { Angles[0], Angles[1], Angles[2] };
                float XX = POS[0]; float YY = POS[1]; float ZZ = POS[2];
                float Pitchh = Angles[0]; float Yaw = Angles[1]; float Roll = Angles[2];
                string x = XX.ToString("F1"); string y = YY.ToString("F1"); string z = ZZ.ToString("F1"); string pitch = Pitchh.ToString("F1"); string yaw = Yaw.ToString("F1"); string roll = Roll.ToString("F1");
                X.Value = (int)Convert.ToDecimal(x); Y.Value = Convert.ToDecimal(y); Z.Value = Convert.ToDecimal(z); Pitch.Value = Convert.ToDecimal(pitch); Yaww.Value = Convert.ToDecimal(yaw); Rolll.Value = Convert.ToDecimal(roll);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //Spawns Turrent On Values
            spawnturret_tut.Spawn_Turrent.OnValues("sentry_minigun_mp", "weapon_minigun", (int)X.Value, (int)Y.Value, (int)Z.Value, (int)Pitch.Value, (int)Yaww.Value, (int)Rolll.Value);
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //single Client
            spawnturret_tut.Spawn_Turrent.iPrintln((Int32)(uint)numericUpDown3.Value, "^:Turret Spawned On your Position.");
            spawnturret_tut.Spawn_Turrent.OnAnglesToForward((uint)numericUpDown3.Value);
            System.Threading.Thread.Sleep(3000);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Every Client
            for (int i = 0; i < 18; i++)
            {
                spawnturret_tut.Spawn_Turrent.iPrintln((Int32)(uint)i, "^:Turret Spawned On your Position.");
                spawnturret_tut.Spawn_Turrent.OnAnglesToForward((uint)i);
            }
        }

        private void X_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
