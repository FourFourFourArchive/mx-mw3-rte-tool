            #region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PS3Lib;
using System.IO;

using System.Threading;


using System.Text.RegularExpressions;
#endregion
namespace Call_Of_Duty_Multi_Tool_1._0._0
{
            #region Connection
    public partial class Form1 : Form
    {
    
        public static TMAPI TMAPI = new TMAPI();
 
        public static CCAPI CCAPI = new CCAPI();
        public static uint ProcessID;
        public static uint[] processIDs;
        public static string snresult;
        public static string Info;
        public static PS3TMAPI.ConnectStatus connectStatus;
        public static string Status;
        public static string MemStatus;
        private Random rand = new Random();
        public static PS3API PS3 = new PS3API();
        public static TMAPI DEX = new TMAPI();
        public static uint EliteCamos = 0x1c1b2ec;
        public static uint UnlockAll_1 = 0x1c190b4;
        public static uint UnlockAll_2 = 0x1c19ff2;
        public static uint UnlockAll_3 = 0x1c1b0a2;
        public uint g_Client = 0x110a280;
        public uint G_Client1 = 0x110a280;
        public uint G_ClientSize = 0x3980;
        public uint G_ClientSize1 = 0x3980;
        public uint G_Entity = 0xfca280;
        public uint G_Entity1 = 0xfca280;
        public uint G_EntitySize = 640;
        public uint G_EntitySize1 = 640;
        public uint G_HudElems = 0xf0e10c;
        public static UInt32 HudelemSize = 0xB8;
        public static UInt32 InGame = 0x7F072C;
        public static UInt32 LevelTime = 0xFC3DB0;
        public static UInt32 G_Client = 0x110A280;
        public static UInt32 ButtonMonitoring = 0xFCA280;
        public static UInt32 PlayerName = 0x1BBBC2C;
        public static UInt32 ClientName = G_Client + 0x338C;
        public static UInt32 FreezeClient = G_Client + 0x35FF;

        public Form1()
        {
            InitializeComponent();

        }
        private List<string> colorList = new List<string>();
        private Dictionary<string, Color> lblColors = new Dictionary<string, Color>();
        private void metroUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
             lblColors.Add("^1", Color.Red);
            lblColors.Add("^2", Color.GreenYellow);
            lblColors.Add("^3", Color.Yellow);
            lblColors.Add("^4", Color.Blue);
            lblColors.Add("^5", Color.Cyan);
            lblColors.Add("^6", Color.DeepPink);
           
            

             if (dataGridView1.RowCount == 1)
                    {
                        dataGridView1.Rows.Add(17);
                    }

                    for (uint i = 0; i < 18; i++);
        } 
            private List<Label> Labels = new List<Label>();
        private void button1_Click(object sender, EventArgs e)
        {

            
            try
            {
                if (PS3.GetCurrentAPI() == SelectAPI.TargetManager)
                {
                    PS3.ConnectTarget(0);
                   
                    label4.Text = "DEX Connected ";
                    
                    
                }
            }
            catch
            {
                label4.Text = "Error";
         
                string Message = "Impossible to connect !";
                MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            try
            {
                if (PS3.GetCurrentAPI() == SelectAPI.ControlConsole)
                {
                    PS3.ConnectTarget();
                    label4.Text = "CEX Connected !";
             
                    PS3.CCAPI.Notify(CCAPI.NotifyIcon.FRIEND, ("Welcome CEX User"));
                    PS3.CCAPI.RingBuzzer(CCAPI.BuzzerMode.Single);

                }
            }
            catch
            {
                label4.Text = "Error";
                label4.ForeColor = Color.Red;
                button1.ForeColor = Color.Red;
                string Message = "Impossible to connect !";
                MessageBox.Show(Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
    ﻿try
     {
         if (PS3.GetCurrentAPI() == SelectAPI.TargetManager)
         {

             if (File.Exists("C:/Program Files/SN Systems/PS3/bin/ps3debugger.exe"))
             {
                 File.Exists("C:/Program Files/SN Systems/PS3/bin/ps3debugger.exe");

             }
             else if (File.Exists("C:/Program Files (x86)/SN Systems/PS3/bin/ps3debugger.exe"))
             {
                 File.Exists("C:/Program Files (x86)/SN Systems/PS3/bin/ps3debugger.exe");

             }

             else
             {
                 DialogResult dialogResult = MessageBox.Show("Could not locate Debugger.\nPlease copy Debugger to the current directory\nC:/Program Files/SN Systems/PS3/bin/<here>", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                 if (dialogResult == DialogResult.OK)
                 {


                     Close();

                 }
             }
         }
         PS3.AttachProcess();
         if (PS3.AttachProcess())
         RPC_MW3.EnablePPC();
         RPC_MW3.EnableRPC();
         label3.Text = "PS3 Attached";
         PS3.CCAPI.Notify(CCAPI.NotifyIcon.FRIEND, ("Game Attached. Thanks for using 444xMoDz MW3 Tool"));
         PS3.CCAPI.RingBuzzer(CCAPI.BuzzerMode.Double);       ﻿ 
         timer50.Enabled = true;

     }
     catch
     {
     }
          

        }
        #region welcome
        public void Clear_Hud2()// Reset size
        {
            byte[] Clear_Hud1 = new byte[] { 0x3E, 0xCE };
            PS3.SetMemory(0x0027714c, Clear_Hud1);
        }
        public void Clear_Hud3()// Reset position
        {
            byte[] Clear_Hud1 = new byte[] { 0x44, 0x15, 0x00, 0x00, 0x42, 0x00, 0x00 };
            PS3.SetMemory(0x00277150, Clear_Hud1);
        }

        public void setText_Titre(byte[] Text)  // 1D "endian" for adding a setText
        {
            uint num2 = Convert.ToUInt32(Text.Length);
            PS3.SetMemory(0x00554D84, Text);
        }
        private static byte[] GetBytes(string str)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetBytes(str);
        }

        public void Intructor2() // Text instructions left of the screen
        {
            Clear_Hud();
            Clear_Hud2();
            Clear_Hud3();
            byte[] Lecteture = new byte[] { 0x70, 0, 0, 0 }; // Initialization text
            PS3.SetMemory(0x277208, Lecteture); // Initialization text
            byte[] Clear_Hud1 = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, };
            PS3.SetMemory(0x00554D84, Clear_Hud1);


        }

        public void Clear_Hud()// Reset text
        {
            byte[] Clear_Hud1 = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, };
            PS3.SetMemory(0x00554D84, Clear_Hud1);

        }
        public void Intructor3() // Text instructions left of the screen
        {
            Clear_Hud();
            Clear_Hud2();
            Clear_Hud3();
            byte[] Lecteture = new byte[] { 0x70, 0, 0, 0 }; // Initialization text
            PS3.SetMemory(0x277208, Lecteture); // Initialization text
            setText_Titre(GetBytes(this.textBox18.Text = "^1M^0x444 ^1P^0rivate ^1T^0ool"));
        }
        #endregion
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.ControlConsole);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PS3.ChangeAPI(SelectAPI.TargetManager);
        }
    #endregion

            #region Mods
        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (this.checkBox1.Checked)
                {

                    PS3.SetMemory(0x5F067, new byte[] {0x02});
                }
                if (!this.checkBox1.Checked)
                {
                    PS3.SetMemory(0x5F067, new byte[] { 0x01 });
                }
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (this.checkBox2.Checked)
                {

                    PS3.SetMemory(0x65D14, new byte[] { 0x60 ,0x00 ,0x00 ,0x00 });
                }
                if (!this.checkBox2.Checked)
                {
                    PS3.SetMemory(0x65D14, new byte[] { 0x41, 0x82, 0x00, 0x0c });
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (this.checkBox3.Checked)
                {

                    PS3.SetMemory(0xbe6d0, new byte[] { 0x60, 0x00, 0x00, 0x00 });
                }
                if (!this.checkBox3.Checked)
                {
                    PS3.SetMemory(0xbe6d0, new byte[] { 0x4a, 0xf8, 0x15, 0x01 });
                }
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (this.checkBox4.Checked)
                {

                    PS3.SetMemory(0x018C9158, new byte[] { 0x00 ,0x00 ,0x00 ,0x00 ,0x00 ,0x53 ,0xC5 ,0x48 ,0x00 ,0x44 ,0x05 ,0x00 ,0x01 });
                }
                if (!this.checkBox4.Checked)
                {
                    PS3.SetMemory(0x018C9158, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x53, 0xC5, 0x48, 0x00, 0x44, 0x05, 0x00, 0x00 });
                }
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (this.checkBox5.Checked)
                {
                    
                    PS3.SetMemory(0x018de168, new byte[] { 0x01 });
                    
                }
                if (!this.checkBox5.Checked)
                {
                    PS3.SetMemory(0x018de168, new byte[] { 0x00 });
                }
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (this.checkBox6.Checked)
                {

                    PS3.SetMemory(0x018de784, new byte[] { 0x01 });

                }
                if (!this.checkBox6.Checked)
                {
                    PS3.SetMemory(0x018de784, new byte[] { 0x00 });
                }
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (this.checkBox7.Checked)
                {

                    PS3.SetMemory(0x018de1ac, new byte[] { 0x01 });

                }
                if (!this.checkBox7.Checked)
                {
                    PS3.SetMemory(0x018de1ac, new byte[] { 0x00 });
                }
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (this.checkBox8.Checked)
                {

                    PS3.SetMemory(0x00173b62, new byte[] { 0x01, 0x2c });

                }
                if (!this.checkBox8.Checked)
                {
                    PS3.SetMemory(0x00173b62, new byte[] { 0x02, 0x81 });
                }
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (this.checkBox9.Checked)
                {

                    PS3.SetMemory(0x018cce7c, new byte[] { 0x01 });

                }
                if (!this.checkBox9.Checked)
                {
                    PS3.SetMemory(0x018cce7c, new byte[] { 0x00 });
                }
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (this.checkBox10.Checked)
                {
                    PS3.SetMemory(0x18da450, new byte[] { 1 });
               

                }
                if (!this.checkBox10.Checked)
                {
                    PS3.SetMemory(0x18da450, new byte[1]);
                }
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (this.checkBox12.Checked)
                {

                    PS3.SetMemory(0x000b6703, new byte[] { 0x01 });

                }
                if (!this.checkBox12.Checked)
                {
                    PS3.SetMemory(0x000b6703, new byte[] { 0x00 });
                }
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown24_ValueChanged(object sender, EventArgs e)
        {
            uint CBuf_AddText = 0x1DB240;
            string text = this.numericUpDown24.Text;
            RPC_MW3.CallFunction(CBuf_AddText, 0, RPC_MW3.str_pointer("cg_gun_y " + text));
            
        }

        private void numericUpDown25_ValueChanged(object sender, EventArgs e)
        {
            uint CBuf_AddText = 0x1DB240;
            string text = this.numericUpDown25.Text;
            RPC_MW3.CallFunction(CBuf_AddText, 0, RPC_MW3.str_pointer("cg_gun_x " + text));
        }

        private void numericUpDown26_ValueChanged(object sender, EventArgs e)
        {
            uint CBuf_AddText = 0x1DB240;
            string text = this.numericUpDown26.Text;
            RPC_MW3.CallFunction(CBuf_AddText, 0, RPC_MW3.str_pointer("cg_gun_z " + text));
        }

        private void numericUpDown27_ValueChanged(object sender, EventArgs e)
        {
            uint CBuf_AddText = 0x1DB240;
            string text = this.numericUpDown27.Text;
            RPC_MW3.CallFunction(CBuf_AddText, 0, RPC_MW3.str_pointer("cg_fovScale " + text));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            uint CBuf_AddText = 0x1DB240;
            string text = this.numericUpDown1.Text;
            RPC_MW3.CallFunction(CBuf_AddText, 0, RPC_MW3.str_pointer("cg_fov " + text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            uint CBuf_AddText = 0x1DB240;

            RPC_MW3.CallFunction(CBuf_AddText, 0, RPC_MW3.str_pointer("reset cg_gun_y"));
            RPC_MW3.CallFunction(CBuf_AddText, 0, RPC_MW3.str_pointer("reset cg_gun_x"));
            RPC_MW3.CallFunction(CBuf_AddText, 0, RPC_MW3.str_pointer("reset cg_gun_z"));
            RPC_MW3.CallFunction(CBuf_AddText, 0, RPC_MW3.str_pointer("reset cg_fovScale"));
            RPC_MW3.CallFunction(CBuf_AddText, 0, RPC_MW3.str_pointer("reset cg_fov"));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PS3.Extension.WriteFloat(0x19780, (float)((int)this.SpeedMw3.Value));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int num = (int)this.numericUpDown8.Value;
            byte num2 = (byte)num;
            byte num3 = (byte)(num >> 8);
            PS3.SetMemory(0x173bb2, new byte[] { num3, num2 });
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            RPC_MW3.Vision(-1, "" + text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RPC_MW3.Vision(-1, "default");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://pastebin.com/3g2UTuzW");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox11_CheckedChanged_1(object sender, EventArgs e)
        {
            {
                if (this.checkBox11.Checked)
                {

                    PS3.SetMemory(0x018C6904, new byte[] { 0x01 });
                }
                if (!this.checkBox11.Checked)
                {
                    PS3.SetMemory(0x018C6904, new byte[] { 0x00 });
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == "Red")
            {

                PS3.SetMemory(0x018C69D0, new byte[] { 0x4F });
            }
            if (comboBox3.SelectedItem == "Green")
            {
                PS3.SetMemory(0x018C69D4, new byte[] { 0x4F });
            }
            if (comboBox3.SelectedItem == "Blue​")
            {
                PS3.SetMemory(0x018C69D8, new byte[] { 0x4F });

            }

            if (comboBox3.SelectedItem == "Black Weapons")
            {

                PS3.SetMemory(0x018C69D0, new byte[] { 0x5F });
                PS3.SetMemory(0x018C69D4, new byte[] { 0x5F });
                PS3.SetMemory(0x018C69D8, new byte[] { 0x5F });
            }
            if (comboBox3.SelectedItem == "White Weapons")
            {
                PS3.SetMemory(0x018C69D0, new byte[] { 0x4F });
                PS3.SetMemory(0x018C69D4, new byte[] { 0x4F });
                PS3.SetMemory(0x018C69D8, new byte[] { 0x4F });
            }
            if (comboBox3.SelectedItem == "Pink")
            {
                PS3.SetMemory(0x018C69D0, new byte[] { 0x4F });
                PS3.SetMemory(0x018C69D4, new byte[] { 0x5F });
                PS3.SetMemory(0x018C69D8, new byte[] { 0x4F });

            }

            if (comboBox3.SelectedItem == "Ice Color")
            {

                PS3.SetMemory(0x018C69D0, new byte[] { 0x4F });
                
                PS3.SetMemory(0x018C69D8, new byte[] { 0x4F });
            }
            if (comboBox3.SelectedItem == "Brown")
            {
                PS3.SetMemory(0x018C69D0, new byte[] { 0x5F });
               
                PS3.SetMemory(0x018C69D8, new byte[] { 0x5F });
            }
            if (comboBox3.SelectedItem == "Light Green")
            {
                PS3.SetMemory(0x018C69D0, new byte[] { 0x4F });
                
                PS3.SetMemory(0x018C69D8, new byte[] { 0x5F });

            }
            if (comboBox3.SelectedItem == "Blue Dark")
            {

                PS3.SetMemory(0x018C69D0, new byte[] { 0x5F });
            }
            if (comboBox3.SelectedItem == "Purple Dark")
            {
                PS3.SetMemory(0x018C69D4, new byte[] { 0x5F });
            }
            if (comboBox3.SelectedItem == "Yellow Dark")
            {
                PS3.SetMemory(0x018C69D8, new byte[] { 0x5F });

            }

            if (comboBox3.SelectedItem == "Blue Sky")
            {

                PS3.SetMemory(0x018C69D0, new byte[] { 0x3F });

                PS3.SetMemory(0x018C69D8, new byte[] { 0x4F });
            }
            if (comboBox3.SelectedItem == "Purple")
            {
                PS3.SetMemory(0x018C69D0, new byte[] { 0x5F });

                PS3.SetMemory(0x018C69D8, new byte[] { 0x3F });
            }
            if (comboBox3.SelectedItem == "Light Purple")
            {
                PS3.SetMemory(0x018C69D0, new byte[] { 0x5F });

                PS3.SetMemory(0x018C69D8, new byte[] { 0x4F });

            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            string text = this.numericUpDown2.Text;
            RPC_MW3.Cmd_ExecuteSingleCommand(0, string.Concat("set compassSize " , text));
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            string text = this.numericUpDown3.Text;
            RPC_MW3.Cmd_ExecuteSingleCommand(0, string.Concat("set compassMaxRange " , text));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            RPC_MW3.Cmd_ExecuteSingleCommand(0, string.Concat("reset compassMaxRange ") );
          
        }

        private void button10_Click(object sender, EventArgs e)
        {
            RPC_MW3.Cmd_ExecuteSingleCommand(0, string.Concat("reset compassSize "));
            this.numericUpDown2.Value = new decimal(1);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string text = this.textBox2.Text;
            RPC_MW3.CBuf_AddText(0,"ui_mapname  " + text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            string text = this.numericUpDown4.Text;
            RPC_MW3.CBuf_AddText(0, "set scr_nukeTimer " + text);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Requires Fast Restart\ne.g 600 = 10 min");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            for (uint i = 0; i < 12; i++)
            {
                PS3.SetMemory(0x18ceea0 + (i * 4), ReverseBytes(BitConverter.GetBytes((int)this.numericUpDown5.Value)));
            }
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem == "Team Death Match")
            {

                RPC_MW3.CBuf_AddText(0, ("set scr_tdm_score_kill " + textBox3.Text + "               "));
            }

            if (comboBox4.SelectedItem == "Free For All")
            {

                RPC_MW3.CBuf_AddText(0,("set scr_dm_score_kill " + this.textBox3.Text + "               "));

            }
            if (comboBox4.SelectedItem == "Kill Confirmed")
            {
                RPC_MW3.CBuf_AddText(0,("set scr_kc_score_kill " + this.textBox3.Text + "               "));

            }
            if (comboBox4.SelectedItem == "Domination")
            {

                RPC_MW3.CBuf_AddText(0, ("set scr_dom_score_kill " + this.textBox3.Text + "               "));
            }

            if (comboBox4.SelectedItem == "War")
            {

                RPC_MW3.CBuf_AddText(0, ("set scr_war_score_kill " + this.textBox3.Text + "               "));

            }
            if (comboBox4.SelectedItem == "Demolition")
            {
                RPC_MW3.CBuf_AddText(0, ("set scr_dem_score_kill " + this.textBox3.Text + "               "));

            }
            if (comboBox4.SelectedItem == "SnD")
            {

                RPC_MW3.CBuf_AddText(0, ("set scr_sd_score_kill " + this.textBox3.Text + "               "));

            }
            if (comboBox4.SelectedItem == "Infected")
            {
                RPC_MW3.CBuf_AddText(0, ("set scr_infect_score_kill " + this.textBox3.Text + "               "));
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem == "Domination")
            {

                RPC_MW3.CBuf_AddText(0, ("g_gametype dom"));
                System.Threading.Thread.Sleep(20);
                RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));

            }

            if (comboBox5.SelectedItem == "HQ")
            {

                RPC_MW3.CBuf_AddText(0, ("g_gametype koth"));
                System.Threading.Thread.Sleep(20);
                RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));

            }
            if (comboBox5.SelectedItem == "FFA")
            {
                RPC_MW3.CBuf_AddText(0, ("g_gametype dm"));
                System.Threading.Thread.Sleep(20);
                RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));

            }

            if (comboBox5.SelectedItem == "OneInTheChamber")
            {

                RPC_MW3.CBuf_AddText(0, ("g_gametype oic"));
                System.Threading.Thread.Sleep(20);
                RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));

            }

            if (comboBox5.SelectedItem == "Infected")
            {

                RPC_MW3.CBuf_AddText(0, ("g_gametype infect"));
                System.Threading.Thread.Sleep(20);
                RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));

            }
            if (comboBox5.SelectedItem == "Kill Confirmed")
            {
                RPC_MW3.CBuf_AddText(0, ("g_gametype conf"));
                System.Threading.Thread.Sleep(20);
                RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));

            }

            if (comboBox5.SelectedItem == "CTF")
            {

                RPC_MW3.CBuf_AddText(0, ("g_gametype ctf"));
                System.Threading.Thread.Sleep(20);
                RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));

            }

            if (comboBox5.SelectedItem == "Demolition")
            {

                RPC_MW3.CBuf_AddText(0, ("g_gametype dd"));
                System.Threading.Thread.Sleep(20);
                RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));

            }
            if (comboBox5.SelectedItem == "Juggernaut")
            {
                RPC_MW3.CBuf_AddText(0, ("g_gametype jugg"));
                System.Threading.Thread.Sleep(20);
                RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));

            }
            if (comboBox5.SelectedItem == "Sabotage")
            {

                RPC_MW3.CBuf_AddText(0, ("g_gametype sab"));
                System.Threading.Thread.Sleep(20);
                RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));

            }

            if (comboBox5.SelectedItem == "Team Defender")
            {

                RPC_MW3.CBuf_AddText(0, ("g_gametype tdef"));
                System.Threading.Thread.Sleep(20);
                RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));

            }
            if (comboBox5.SelectedItem == "Team Juggernaut")
            {
                RPC_MW3.CBuf_AddText(0, ("g_gametype tjugg"));
                System.Threading.Thread.Sleep(20);
                RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));

            }

            if (comboBox5.SelectedItem == "Snd")
            {

                RPC_MW3.CBuf_AddText(0, ("g_gametype sd"));
                System.Threading.Thread.Sleep(20);
                RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));

            }

            if (comboBox5.SelectedItem == "Team Death Match")
            {

                RPC_MW3.CBuf_AddText(0, ("g_gametype war"));
                System.Threading.Thread.Sleep(20);
                RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));

            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            RPC_MW3.CBuf_AddText(0, ("g_gametype gun"));
            System.Threading.Thread.Sleep(20);
            RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));
        }
        private void endgame(int client, string command)
        {
            RPC_MW3.CallFunction(0x0022F7A8, (uint)client, 0, RPC_MW3.str_pointer(command));
        }
        public void AntiQuitOn(int ClientNumber)
        {

            byte[] buffer = new byte[0x20];
            RPC_MW3.Set_ClientDvar(-1, "g_scriptmainmenu \"byMx444\"");
            System.Threading.Thread.Sleep(10);
            PS3.SetMemory(0x523b30, buffer);
          


        }
        public void AntiQuitOff(int ClientNumber)
        {

            byte[] buffer = new byte[0x19];
            RPC_MW3.Set_ClientDvar(-1, "q g_scriptmainmenu \"by444xMoDz\"");
            System.Threading.Thread.Sleep(10);
            PS3.SetMemory(0x523b30, buffer);
        


        }
        private void button20_Click(object sender, EventArgs e)
        {
            endgame(0, "sv_matchend");
        }

        private void button21_Click(object sender, EventArgs e)
        {
            button21.Visible = false;
            button22.Visible = true;
            AntiQuitOn(-1);
            RPC_MW3.iPrintln(-1,"^2AntiQuit On");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            button21.Visible = true;
            button22.Visible = false;
            AntiQuitOff(-1);
            RPC_MW3.iPrintln(-1, "^1AntiQuit Off");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Kickgod("^1FGT");
        }
        private void SV_KickClient(uint localClientIndex, string command)
        {
            RPC_MW3.CallFunction(0x00223BD0, localClientIndex, RPC_MW3.str_pointer(""));
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (uint i = 0; i < 18; i++)
            {
                //gets the needed bytes
                byte[] antigod1 = new byte[1];
                byte[] antigod2 = new byte[1];
                byte[] antigod3 = new byte[1];
                PS3.GetMemory(0x110a280 + 0x27b + (i * 0x3980), antigod1);
                PS3.GetMemory(0x110a280 + 0x283 + (i * 0x3980), antigod2);
                PS3.GetMemory(0x110a280 + 0x27f + (i * 0x3980), antigod3);
                //Checks for the bytes that indicate a godmode class
                if (antigod1[0] != 0x00 && antigod2[0] == 0x00 && antigod3[0] == 0x00)
                {
                    //kicks a client if the godmode class is detected
                    System.Threading.Thread.Sleep(20);
                    SV_KickClient(i, "Kicked ^1For Using Godmode class");
                }
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
          
        }

        private void button25_Click(object sender, EventArgs e)
        {
            button25.Visible = false;
            button26.Visible = true;
            RPC_MW3.CBuf_AddText(0, ("set scr_sd_numlives 0"));
            RPC_MW3.iPrintln(-1, "^2Unlimited Spawn On");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            button25.Visible = true;
            button26.Visible = false;
            RPC_MW3.CBuf_AddText(0, ("set scr_sd_numlives 1"));
            RPC_MW3.iPrintln(-1, "^1Unlimited Spawn Off");
        }

        private void comboBox6_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (comboBox6.SelectedItem == "Black")
            {

                PS3.SetMemory(0x018C654B, new byte[] { 0x00 ,0x00 ,0x00 ,0x00 ,0x00 });
            }
            if (comboBox6.SelectedItem == "Default")
            {
                PS3.SetMemory(0x018C654B, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x01 });
            }
            if (comboBox6.SelectedItem == "White​")
            {
                PS3.SetMemory(0x018C654B, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x02 });

            }
            if (comboBox6.SelectedItem == "Cartoon​")
            {
                PS3.SetMemory(0x018C654B, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x03 });

            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button28_Click(object sender, EventArgs e)
        {
            if (comboBox7.SelectedItem == "Default")
            {

                PS3.SetMemory(0x018C6437, new byte[] { 0xD4, 0x00, 0x04, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x80, 0x00 });
            }
            if (comboBox7.SelectedItem == "Weed")
            {
                PS3.SetMemory(0x018C6437, new byte[] { 0xD4, 0x00, 0x04, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3E, 0x30, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x80, 0x00 });
            }
            if (comboBox7.SelectedItem == "Drugs​")
            {
                PS3.SetMemory(0x018C6437, new byte[] { 0xD4, 0x00, 0x04, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3E, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3D, 0xFF, 0x00 });

            }
            if (comboBox7.SelectedItem == "Blind")
            {
                PS3.SetMemory(0x018C6437, new byte[] { 0xD4, 0x00, 0x04, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x4F, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x80, 0x00 });

            }
            if (comboBox7.SelectedItem == "Wind Screen")
            {
                PS3.SetMemory(0x018C6437, new byte[] { 0xD4, 0x00, 0x04, 0x04, 0x00, 0x40, 0x00, 0x00, 0x00, 0x8F, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x80, 0x00 });

            }
        }
             #endregion

            #region Enable
        private void enableRPCMW3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

            #region Ghetto Advanced No CLip
        public static void IsAirborn(Int32 client)
        {//Credits To kiwi_modz
            float Velocity = PS3.Extension.ReadFloat(Offsets.Funcs.G_Client(client, 0x30));
            Velocity = 5;
            PS3.Extension.WriteFloat(Offsets.Funcs.G_Client(client, 0x30), Velocity);
        }
        public static void MoveUp(Int32 client)
        {//Credits To Sticky < for this function that was originally called "double jump"
            //He Ported this function from se7ensins.com so credits to that aswell.
            //I made Ghetto Shit with this Func to start with :)

            float Velocity = PS3.Extension.ReadFloat(Offsets.Funcs.G_Client(client, 0x30));
            Velocity += 50;
            PS3.Extension.WriteFloat(Offsets.Funcs.G_Client(client, 0x30), Velocity);
        }
        public static void MoveDown(Int32 client)
        {//Credits To kiwi_modz
            System.Threading.Thread.Sleep(20);
            float Velocity = PS3.Extension.ReadFloat(Offsets.Funcs.G_Client(client, 0x30));
            Velocity -= 550;
            PS3.Extension.WriteFloat(Offsets.Funcs.G_Client(client, 0x30), Velocity);
        }

        public static void AdvancedNoClip(Int32 client)
        {//Credits To kiwi_modz
            if (Buttons.DetectButton(client) == Buttons.X)
            {
                MoveUp(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.X + Buttons.L1)
            {
                MoveUp(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.R3)
            {
                MoveDown(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.NoButtonPressed)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.R1)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.L1)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.L1 + Buttons.L3)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.L1 + Buttons.L3 + Buttons.R1)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.L1 + Buttons.R1)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.Square)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.L3)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.R3)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.L2)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.R2)
            {
                IsAirborn(client);
            }
            else if (Buttons.DetectButton(client) == Buttons.O)
            {
                IsAirborn(client);
            }
        }
        #endregion

            #region Aimbot

        public static class Aimbot_and_ForgeMode
        {
            //If you using this class or the Functions give Credits to
            //xCSBKx: Making this class the Aimbot and the ForgeMode Function
            //VezahModz: AnglestoForward Function
            //iMCSx and Seb5594 Read+Write Function
            //Have Fun and enjoy using it :)
            //www.YouTube.com/GMTPS3
            #region Read + Write
            //Read and return an Integer.
            //Liest und gibt eine Integer wieder.
            public static int ReadInt(uint Offset)
            {
                byte[] buffer = new byte[4];
                PS3.GetMemory(Offset, buffer);
                Array.Reverse(buffer);
                int Value = BitConverter.ToInt32(buffer, 0);
                return Value;
            }

            //Read and return 1 Byte.
            //Liest und gibt einen Byte wieder.
            public static byte ReadByte(uint Offset)
            {
                byte[] buffer = new byte[1];
                PS3.GetMemory(Offset, buffer);
                return buffer[0];
            }

            //Read and return an float value over Length.
            //Liest und gibt eine Float Value wieder über eine Länge wieder.

            public static float[] ReadFloatLength(uint Offset, int Length)
            {
                byte[] buffer = new byte[Length * 4];
                PS3.GetMemory(Offset, buffer);
                System.Array.Reverse(buffer);
                float[] Array = new float[Length];
                for (int i = 0; i < Length; i++)
                {
                    Array[i] = BitConverter.ToSingle(buffer, (Length - 1 - i) * 4);
                }
                return Array;
            }

            //Write a Float Array in Memory.
            //Schreibt einen Float Array in den Memory. 
            public static void WriteFloatArray(uint Offset, float[] Array)
            {
                byte[] buffer = new byte[Array.Length * 4];
                for (int Lenght = 0; Lenght < Array.Length; Lenght++)
                {
                    ReverseBytes(BitConverter.GetBytes(Array[Lenght])).CopyTo(buffer, Lenght * 4);
                }
                PS3.SetMemory(Offset, buffer);
            }

            //Read and return an Float Value. (4 Bytes)
            //Liest und gibt eine Float Value wieder. (4 Bytes)
            public static float ReadFloat(uint Offset)
            {
                byte[] buffer = new byte[4];
                PS3.GetMemory(Offset, buffer);
                Array.Reverse(buffer, 0, 4);
                return BitConverter.ToSingle(buffer, 0);
            }
            #endregion

            //Freeze or unfreeze the selected Client.
            //Friert oder taut den Clienten ein oder auf.
            public static void Freeze(uint Client, bool State)
            {
                if (State == true)
                {
                    PS3.SetMemory(0x0110d87f + (Client * 0x3980), new byte[] { 0x04 });
                }
                else
                {
                    PS3.SetMemory(0x0110d87f + (Client * 0x3980), new byte[] { 0x00 });
                }
            }

            //Set Client View Angles to aim on Target
            //Setzs das Aiming vom Client auf die Position des Target 
            public static void Aimbot(uint Client, uint Target)
            {
                #region Check if Dead
                //Checks if Target is Dead or Alive.
                //Guckt ob der Gegeners Tot oder Lebendig ist.
                if (ReadInt(0xFCA41D + (Target * 0x280)) > 0)
                {
                    #region Stance
                    //Displays the player's Status.
                    //Zeigt den Status des Spielers an.
                    byte StanceByte = ReadByte(0x110d88a + (Target * 0x3980));
                    float Stance = 0;
                    //if Target is crouch Stance = 21.
                    //Wenn der Gegeners Hockt ist Stance = 21.    
                    if (StanceByte == 2)
                        Stance = 21;
                    //if Target is lie Stance = 47.
                    //Wenn der Gegeners liegt ist Stance = 47.
                    else if (StanceByte == 1)
                        Stance = 47;
                    //if Target is standing Stance = 0.
                    //Wenn der Gegeners steht ist Stance = 0.
                    else
                        Stance = 0;
                    #endregion

                    #region Origin
                    //Get the Origin of the Client.
                    //Gibt die Position des Clienten an.
                    float[] O1 = ReadFloatLength(0x110a29c + (Client * 0x3980), 3);

                    //Get the Origin of the Target.
                    //Gibt die Position des Gegeners an.
                    float[] O2 = ReadFloatLength(0x110a29c + (Target * 0x3980), 3);
                    //ZValue - Stance
                    O2[2] = O2[2] - Stance;
                    #endregion

                    #region VectoAngles
                    //Calculates the X angle and Y angle to give a direction.
                    //Berechnet den X Winkel und den Y Winkel um eine Richtung  anzugeben.
                    //Source: http://www.java2s.com/Open-Source/Java/Game/Jake2-0.9.5/Jake2/util/Math3D.java.htm
                    float[] value1 = new float[] { O2[0] - O1[0], O2[1] - O1[1], O2[2] - O1[2] };
                    float yaw, pitch;
                    float[] angles = new float[3];

                    if ((value1[1] == 0f) && (value1[0] == 0f))
                    {
                        yaw = 0f;
                        pitch = 0f;
                        if (value1[2] > 0f)
                            pitch = 90f;
                        else
                            pitch = 270f;
                    }
                    else
                    {
                        if (value1[0] != -1f)
                            yaw = (float)((Math.Atan2(value1[1], value1[0]) * 180) / Math.PI);
                        else if (value1[1] > 0f)
                            yaw = 90f;
                        else
                            yaw = 270f;
                        if (yaw < 0f)
                            yaw += 360f;
                        float forward = (float)Math.Sqrt(((value1[0] * value1[0]) + (value1[1] * value1[1])));
                        pitch = (float)((Math.Atan2(value1[2], (double)forward) * 180.0) / Math.PI);
                        if (pitch < 0f)
                            pitch += 360f;
                    }
                    angles[0] = -pitch;
                    angles[1] = yaw;
                    angles[2] = 0;
                    #endregion

                    #region SetViewAngles
                    //0x1767E0 - SetClientViewAngle(gentity_s *ent, const float *angle)
                    //Writes the angles to 0x1000000.
                    //Schreibt die Winkel auf 0x1000000.
                    WriteFloatArray(0x1000000, angles);
                    //Calls the SetClientViewAnlge and sets the Angles
                    //Ruft die SetCleintView Angles function auf und setzt die Winkel
                    RPC_MW3.CallFunction(0x1767E0, 0xFCA280 + (0x280 * Client), 0x1000000);
                    #endregion
                }
                #endregion
            }

            //Teleport the Target in the Client Crosshairs.
            //Teleportiert den Target in das Fadenkreuz des Clienten.
            //The distance is set by a Metric size(Meters).
            //3 Yard = 1 Meter (rounded)
            public static void ForgeMode(uint Client, uint Target, uint Distance_in_Meters = 6)
            {
                #region Get Angles and Origion
                //Get the Angles of the Client.
                //Gibt die Sicht Winkel des Clienten an.
                float[] Angles = ReadFloatLength(0x110a3d8 + (Client * 0x3980), 2);
                //Get the Origin of the Client.
                //Gibt die Position des Clienten an.
                float[] Origin = ReadFloatLength(0x110a29c + (Client * 0x3980), 3);
                #endregion

                #region AnglestoForward
                //The Distance shows how far away the target is from the client.
                //Die Distance gibt an wie weit weg der Target vom Clienten ist.
                float diff = Distance_in_Meters * 40;

                //Calculates the Angles and th to give a direction.
                //Berechnet die anzugeben.
                //http://www.nextgenupdate.com/forums/playstation-3-elite/723550-c-anglestoforward-function.html
                float num = ((float)Math.Sin((Angles[0] * Math.PI) / 180)) * diff;
                float num1 = (float)Math.Sqrt(((diff * diff) - (num * num)));
                float num2 = ((float)Math.Sin((Angles[1] * Math.PI) / 180)) * num1;
                float num3 = ((float)Math.Cos((Angles[1] * Math.PI) / 180)) * num1;
                float[] forward = new float[] { Origin[0] + num3, Origin[1] + num2, Origin[2] - num };
                #endregion

                #region Set Target Origin
                Freeze(Target, true);
                WriteFloatArray(0x110a29c + (Target * 0x3980), forward);
                #endregion
            }

            //Returns the Client who is closest to the Attacker.
            //Gibt den Clienten wieder der am nähsten zum Angreifer ist.
            public static float[] distances = new float[18];
            public static uint FindClosestEnemy(uint Attacker)
            {
                #region Check if Alive and Get Origin
                for (uint i = 0; i < 18; i++)
                {
                    //Only if the Target is Alive it stores there distance.
                    //Nur wenn der Target lebt wird seine Enferung zum Clienten angezeigt.
                    if (ReadInt(0xFCA41D + (i * 0x280)) > 0)
                    {
                        #region Attacker Origin
                        //Get the Origin of the Attacker.
                        //Gibt die Position des Angreifers an.
                        float[] O1 = ReadFloatLength(0x110a29c + ((uint)Attacker * 0x3980), 3);
                        #endregion

                        #region Client Origin
                        //Get the Origin of the Target.
                        //Gibt die Position des Gegners an.
                        float[] O2 = ReadFloatLength(0x110a29c + (i * 0x3980), 3);
                        #endregion

                        #region Get Distance
                        //Convertet the Origin from Client and Target and shows the Distance.
                        //Convertiert die Position von Client und Target und gibt die Enferung an.
                        distances[i] = (float)(Math.Sqrt(
                        ((O2[0] - O1[0]) * (O2[0] - O1[0])) +
                        ((O2[1] - O1[1]) * (O2[1] - O1[1])) +
                        ((O2[2] - O1[2]) * (O2[2] - O1[2]))
                        ));
                        #endregion
                    }
                    else
                    {
                        #region Dead Players get Max Value
                        //If the Client is Dead the Distance set to Max.
                        //Wenn der Client Tod ist wird die Enfernung auf Max gesetzt.
                        distances[i] = float.MaxValue;
                        #endregion
                    }
                }
                #endregion

                #region Copy Distances
                float[] newDistances = new float[18];
                Array.Copy(distances, newDistances, distances.Length);
                #endregion

                #region Sort Distances and return Client
                //Sorts the Distances from Small to Big
                //Sortiert die Enfernungen von Klein zu Groß
                Array.Sort(newDistances);
                //Array.Sort(distances);
                for (uint i = 0; i < 18; i++)
                {
                    //Shows which Client is the closest (0 is the attacker)
                    //Zeigt an welcher Client der nähste ist(0 ist der Angreifer)
                    if (distances[i] == newDistances[1])
                    //if (distances[i] == distances[1])
                    {
                        return i;
                    }
                }
                #endregion

                #region Failed
                //If finding ClosestEnemey Function is Failed it returns -1 but never happend :P
                //Wenn die ClosestEnemy Funktion einen Fehler hat gibt sie -1 zurück das Passiert aber nie :P
                int Failed = -1;
                return (uint)Failed;
                #endregion
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            
            Forge.Stop();
            NoClip.Stop();
            button30.Visible = true;
            button29.Visible = false;
            Aimbot.Start();
            RPC_MW3.iPrintln(comboBox8.SelectedIndex,"Aimbot ^2ON");
        }

        private void button30_Click(object sender, EventArgs e)
        {
            button30.Visible = false;
            button29.Visible = true;

            Aimbot.Stop();
            Forge.Stop();
            NoClip.Stop();
            RPC_MW3.iPrintln(comboBox8.SelectedIndex, "Aimbot ^1OFF");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
           
                       
        }
              public static string ClientNamesmw3(uint client)
        {
            string getnames = PS3.Extension.ReadString(0x0110d60c + client * 0x3980);
            return getnames;
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        private void StartAimbot(UInt32 Client)
        {

            if (Aimbot_and_ForgeMode.ReadFloat(0x110a5f8 + (Client * 0x3980)) > 0)
                Aimbot_and_ForgeMode.Aimbot(Client, Aimbot_and_ForgeMode.FindClosestEnemy(Client));
        }
        uint Client;
        private void Aimbot_Tick(object sender, EventArgs e)
        {

            StartAimbot((uint)comboBox8.SelectedIndex);
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button33_Click(object sender, EventArgs e)
        {
            for (uint i = 0; i < 12; i++)
                comboBox8.Items.Add(ClientNamesmw3(i));

           
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Aimbot.Stop();
         
            NoClip.Stop();
            button31.Visible = true;
            button32.Visible = false;
            Forge.Start();
            RPC_MW3.iPrintln(comboBox8.SelectedIndex, "Forge Mode ^2ON");
        }

        private void button31_Click(object sender, EventArgs e)
        {
            Aimbot.Stop();
            
            NoClip.Stop();
            button31.Visible = false;
            button32.Visible = true;
            Forge.Stop();
            RPC_MW3.iPrintln(comboBox8.SelectedIndex, "Forge Mode ^1OFF");
        }
        
     private void StartForgeMode(UInt32 Client)
        {
            //Checks if player is aiming.
            //Guckt ob der Spieler ziehlt.
            uint Enemy = Aimbot_and_ForgeMode.FindClosestEnemy(Client);
            //This is just only a way you can use Key_Down.
            //Das ist nur ein weg um es zu nutzen benutz am besten Key_Down.
            if (Aimbot_and_ForgeMode.ReadFloat(0x110a5f8 + ((uint)Client * 0x3980)) > 0)
            {
                Aimbot_and_ForgeMode.Freeze(Enemy, true);
                Aimbot_and_ForgeMode.ForgeMode(Client, Enemy);
            }
            else
            {
                Aimbot_and_ForgeMode.Freeze(Enemy, false);
            }
        }

        private void Forge_Tick(object sender, EventArgs e)
        {
            StartForgeMode((uint)comboBox8.SelectedIndex);
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button34_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.ShowDialog();
            this.nudR.Value = dialog.Color.R;
            this.nudG.Value = dialog.Color.G;
            this.nudB.Value = dialog.Color.B;
            this.pictureBox1.BackColor = Color.FromArgb(0xff, (int)this.nudR.Value, (int)this.nudG.Value, (int)this.nudB.Value);
       
        }

        private void button35_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.ShowDialog();
            this.nudGR.Value = dialog.Color.R;
            this.nudGG.Value = dialog.Color.G;
            this.nudGB.Value = dialog.Color.B;
            this.pictureBox2.BackColor = Color.FromArgb(0xff, (int)this.nudGR.Value, (int)this.nudGG.Value, (int)this.nudGB.Value);
       
        }

        private void button36_Click(object sender, EventArgs e)
        {
            RPC_MW3.Huds.Typewriter((uint)100, 0, txbText.Text, (int)nudFont.Value, (float)nudFontScale.Value, (int)nudX.Value, (int)nudY.Value, 0, 0, (int)nudR.Value, (int)nudG.Value, (int)nudB.Value, (int)nudA.Value, (int)nudGR.Value, (int)nudGG.Value, (int)nudGB.Value, (int)nudGA.Value, (int)nudLetterTime.Value, (int)nudDecayStartTime.Value, (int)nudDecayDuration.Value);
            RPC_MW3.Huds.ActivateIndex(true, 100, 1);
            RPC_MW3.Huds.Typewriter((uint)101, 1, txbText.Text, (int)nudFont.Value, (float)nudFontScale.Value, (int)nudX.Value, (int)nudY.Value, 0, 0, (int)nudR.Value, (int)nudG.Value, (int)nudB.Value, (int)nudA.Value, (int)nudGR.Value, (int)nudGG.Value, (int)nudGB.Value, (int)nudGA.Value, (int)nudLetterTime.Value, (int)nudDecayStartTime.Value, (int)nudDecayDuration.Value);
            RPC_MW3.Huds.ActivateIndex(true, 101, 1);
            RPC_MW3.Huds.Typewriter((uint)102, 2, txbText.Text, (int)nudFont.Value, (float)nudFontScale.Value, (int)nudX.Value, (int)nudY.Value, 0, 0, (int)nudR.Value, (int)nudG.Value, (int)nudB.Value, (int)nudA.Value, (int)nudGR.Value, (int)nudGG.Value, (int)nudGB.Value, (int)nudGA.Value, (int)nudLetterTime.Value, (int)nudDecayStartTime.Value, (int)nudDecayDuration.Value);
            RPC_MW3.Huds.ActivateIndex(true, 102, 1);
            RPC_MW3.Huds.Typewriter((uint)103, 3, txbText.Text, (int)nudFont.Value, (float)nudFontScale.Value, (int)nudX.Value, (int)nudY.Value, 0, 0, (int)nudR.Value, (int)nudG.Value, (int)nudB.Value, (int)nudA.Value, (int)nudGR.Value, (int)nudGG.Value, (int)nudGB.Value, (int)nudGA.Value, (int)nudLetterTime.Value, (int)nudDecayStartTime.Value, (int)nudDecayDuration.Value);
            RPC_MW3.Huds.ActivateIndex(true, 103, 1);
            RPC_MW3.Huds.Typewriter((uint)104, 4, txbText.Text, (int)nudFont.Value, (float)nudFontScale.Value, (int)nudX.Value, (int)nudY.Value, 0, 0, (int)nudR.Value, (int)nudG.Value, (int)nudB.Value, (int)nudA.Value, (int)nudGR.Value, (int)nudGG.Value, (int)nudGB.Value, (int)nudGA.Value, (int)nudLetterTime.Value, (int)nudDecayStartTime.Value, (int)nudDecayDuration.Value);
            RPC_MW3.Huds.ActivateIndex(true, 104, 1);
            RPC_MW3.Huds.Typewriter((uint)105, 5, txbText.Text, (int)nudFont.Value, (float)nudFontScale.Value, (int)nudX.Value, (int)nudY.Value, 0, 0, (int)nudR.Value, (int)nudG.Value, (int)nudB.Value, (int)nudA.Value, (int)nudGR.Value, (int)nudGG.Value, (int)nudGB.Value, (int)nudGA.Value, (int)nudLetterTime.Value, (int)nudDecayStartTime.Value, (int)nudDecayDuration.Value);
            RPC_MW3.Huds.ActivateIndex(true, 105, 1);
            RPC_MW3.Huds.Typewriter((uint)106, 6, txbText.Text, (int)nudFont.Value, (float)nudFontScale.Value, (int)nudX.Value, (int)nudY.Value, 0, 0, (int)nudR.Value, (int)nudG.Value, (int)nudB.Value, (int)nudA.Value, (int)nudGR.Value, (int)nudGG.Value, (int)nudGB.Value, (int)nudGA.Value, (int)nudLetterTime.Value, (int)nudDecayStartTime.Value, (int)nudDecayDuration.Value);
            RPC_MW3.Huds.ActivateIndex(true, 106, 1);
            RPC_MW3.Huds.Typewriter((uint)107, 7, txbText.Text, (int)nudFont.Value, (float)nudFontScale.Value, (int)nudX.Value, (int)nudY.Value, 0, 0, (int)nudR.Value, (int)nudG.Value, (int)nudB.Value, (int)nudA.Value, (int)nudGR.Value, (int)nudGG.Value, (int)nudGB.Value, (int)nudGA.Value, (int)nudLetterTime.Value, (int)nudDecayStartTime.Value, (int)nudDecayDuration.Value);
            RPC_MW3.Huds.ActivateIndex(true, 107, 1);
            RPC_MW3.Huds.Typewriter((uint)108, 8, txbText.Text, (int)nudFont.Value, (float)nudFontScale.Value, (int)nudX.Value, (int)nudY.Value, 0, 0, (int)nudR.Value, (int)nudG.Value, (int)nudB.Value, (int)nudA.Value, (int)nudGR.Value, (int)nudGG.Value, (int)nudGB.Value, (int)nudGA.Value, (int)nudLetterTime.Value, (int)nudDecayStartTime.Value, (int)nudDecayDuration.Value);
            RPC_MW3.Huds.ActivateIndex(true, 108, 1);
            RPC_MW3.Huds.Typewriter((uint)109, 9, txbText.Text, (int)nudFont.Value, (float)nudFontScale.Value, (int)nudX.Value, (int)nudY.Value, 0, 0, (int)nudR.Value, (int)nudG.Value, (int)nudB.Value, (int)nudA.Value, (int)nudGR.Value, (int)nudGG.Value, (int)nudGB.Value, (int)nudGA.Value, (int)nudLetterTime.Value, (int)nudDecayStartTime.Value, (int)nudDecayDuration.Value);
            RPC_MW3.Huds.ActivateIndex(true, 109, 1);
            RPC_MW3.Huds.Typewriter((uint)110, 10, txbText.Text, (int)nudFont.Value, (float)nudFontScale.Value, (int)nudX.Value, (int)nudY.Value, 0, 0, (int)nudR.Value, (int)nudG.Value, (int)nudB.Value, (int)nudA.Value, (int)nudGR.Value, (int)nudGG.Value, (int)nudGB.Value, (int)nudGA.Value, (int)nudLetterTime.Value, (int)nudDecayStartTime.Value, (int)nudDecayDuration.Value);
            RPC_MW3.Huds.ActivateIndex(true, 110, 1);
            RPC_MW3.Huds.Typewriter((uint)111, 11, txbText.Text, (int)nudFont.Value, (float)nudFontScale.Value, (int)nudX.Value, (int)nudY.Value, 0, 0, (int)nudR.Value, (int)nudG.Value, (int)nudB.Value, (int)nudA.Value, (int)nudGR.Value, (int)nudGG.Value, (int)nudGB.Value, (int)nudGA.Value, (int)nudLetterTime.Value, (int)nudDecayStartTime.Value, (int)nudDecayDuration.Value);
            RPC_MW3.Huds.ActivateIndex(true, 111, 1);
            RPC_MW3.Huds.Typewriter((uint)112, 12, txbText.Text, (int)nudFont.Value, (float)nudFontScale.Value, (int)nudX.Value, (int)nudY.Value, 0, 0, (int)nudR.Value, (int)nudG.Value, (int)nudB.Value, (int)nudA.Value, (int)nudGR.Value, (int)nudGG.Value, (int)nudGB.Value, (int)nudGA.Value, (int)nudLetterTime.Value, (int)nudDecayStartTime.Value, (int)nudDecayDuration.Value);
            RPC_MW3.Huds.ActivateIndex(true, 112, 1);
            RPC_MW3.Huds.Typewriter((uint)113, 13, txbText.Text, (int)nudFont.Value, (float)nudFontScale.Value, (int)nudX.Value, (int)nudY.Value, 0, 0, (int)nudR.Value, (int)nudG.Value, (int)nudB.Value, (int)nudA.Value, (int)nudGR.Value, (int)nudGG.Value, (int)nudGB.Value, (int)nudGA.Value, (int)nudLetterTime.Value, (int)nudDecayStartTime.Value, (int)nudDecayDuration.Value);
            RPC_MW3.Huds.ActivateIndex(true, 113, 1);
            RPC_MW3.Huds.Typewriter((uint)114, 14, txbText.Text, (int)nudFont.Value, (float)nudFontScale.Value, (int)nudX.Value, (int)nudY.Value, 0, 0, (int)nudR.Value, (int)nudG.Value, (int)nudB.Value, (int)nudA.Value, (int)nudGR.Value, (int)nudGG.Value, (int)nudGB.Value, (int)nudGA.Value, (int)nudLetterTime.Value, (int)nudDecayStartTime.Value, (int)nudDecayDuration.Value);
            RPC_MW3.Huds.ActivateIndex(true, 114, 1);
            RPC_MW3.Huds.Typewriter((uint)115, 15, txbText.Text, (int)nudFont.Value, (float)nudFontScale.Value, (int)nudX.Value, (int)nudY.Value, 0, 0, (int)nudR.Value, (int)nudG.Value, (int)nudB.Value, (int)nudA.Value, (int)nudGR.Value, (int)nudGG.Value, (int)nudGB.Value, (int)nudGA.Value, (int)nudLetterTime.Value, (int)nudDecayStartTime.Value, (int)nudDecayDuration.Value);
            RPC_MW3.Huds.ActivateIndex(true, 115, 1);
            RPC_MW3.Huds.Typewriter((uint)116, 16, txbText.Text, (int)nudFont.Value, (float)nudFontScale.Value, (int)nudX.Value, (int)nudY.Value, 0, 0, (int)nudR.Value, (int)nudG.Value, (int)nudB.Value, (int)nudA.Value, (int)nudGR.Value, (int)nudGG.Value, (int)nudGB.Value, (int)nudGA.Value, (int)nudLetterTime.Value, (int)nudDecayStartTime.Value, (int)nudDecayDuration.Value);
            RPC_MW3.Huds.ActivateIndex(true, 116, 1);
            RPC_MW3.Huds.Typewriter((uint)117, 17, txbText.Text, (int)nudFont.Value, (float)nudFontScale.Value, (int)nudX.Value, (int)nudY.Value, 0, 0, (int)nudR.Value, (int)nudG.Value, (int)nudB.Value, (int)nudA.Value, (int)nudGR.Value, (int)nudGG.Value, (int)nudGB.Value, (int)nudGA.Value, (int)nudLetterTime.Value, (int)nudDecayStartTime.Value, (int)nudDecayDuration.Value);
            RPC_MW3.Huds.ActivateIndex(true, 117, 1);
           
        }

        private void groupBox17_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private uint HudElem_Alloc()
        {
            byte[] buffer = new byte[1];
            for (int i = 0; i < 0x400; i++)
            {
                uint addr = (uint)(0xf0e10c + (i * 180));
                PS3.GetMemory(addr, buffer);
                if (buffer[0] == 0)
                {
                    PS3.SetMemory(addr, new byte[0xb1]);
                    return addr;
                }
            }
            return 0;
        }
        public byte[] ReverseBytesS(byte[] inArray)
        {
            Array.Reverse(inArray);
            return inArray;
        }
        public byte[] uintBytesS(uint input)
        {
            byte[] bytes = BitConverter.GetBytes(input);
            Array.Reverse(bytes);
            return bytes;
        }
        public uint CreateText1(string text)
        {
            RPC_MW3.CallFunction(0x1be6cc, RPC_MW3.str_pointer(text), 0, 0, 0, 0);
            System.Threading.Thread.Sleep(10);
            return RPC_MW3.GetFuncReturn();
        }
        public void spawnElem(int client, uint elemAddress)
        {
            PS3.SetMemory(elemAddress + 0xa8, ReverseBytesS(BitConverter.GetBytes(client)));
        }
        public void setText(uint elem, byte[] text, uint font, float x, float y, uint align, int r = 0xff, int g = 0xff, int b = 0xff, int a = 0xff)
        {
            PS3.SetMemory(elem, new byte[180]);
            byte[] val = new byte[4];
            val[3] = 1;
            PS3.SetMemory(elem, val);
            PS3.SetMemory(elem + HElems.textOffset, text);
            PS3.SetMemory(elem + HElems.relativeOffset, this.uintBytesS(5));
            PS3.SetMemory((elem + HElems.relativeOffset) - 4, this.uintBytesS(6));
            PS3.SetMemory(elem + HElems.fontOffset, this.uintBytesS(font));
            PS3.SetMemory(elem + HElems.alignOffset, this.uintBytesS(align));
            byte[] buffer2 = new byte[2];
            buffer2[0] = 0x40;
            PS3.SetMemory((elem + HElems.textOffset) + 4, buffer2);

            PS3.SetMemory(elem + HElems.xOffset, ReverseBytesS(BitConverter.GetBytes(x)));
            PS3.SetMemory(elem + HElems.yOffset, ReverseBytesS(BitConverter.GetBytes(y)));
            PS3.SetMemory(elem + HElems.colorOffset, new byte[] { BitConverter.GetBytes(r)[0], BitConverter.GetBytes(g)[0], BitConverter.GetBytes(b)[0], BitConverter.GetBytes(a)[0] });
        }
        public class Huds
        {


            public static void Typewriter(uint elemIndex, int client, string text, int font, float fontScale, int x, int y, uint align, int sort, int r, int g, int b, int a, int r1, int g1, int b1, int a1, int fxLetterTime, int fxDecayStartTime, int fxDecayDuration)
            {
                //Original function by BadLuckbrian, slighty modiefied by me (kiwi_modz) to add the Typewriter effect
                uint elem = 0xF0E10C + ((elemIndex) * 0xB4);
                byte[] ClientID = ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(client)));
                PS3.SetMemory(elem, new byte[0xB4]);
                PS3.SetMemory(elem, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(elem + HElems.textOffset, uintBytes(CreateText(text + "\0")));
                PS3.SetMemory(elem + HElems.relativeOffset, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x92, 0xFF, 0xFF, 0xFF, 0xFF });
                PS3.SetMemory(elem + HElems.relativeOffset - 4, new byte[] { 0x00, 0x00, 0x00, 0x05 });
                PS3.SetMemory(elem + HElems.fontOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(font))));
                PS3.SetMemory(elem + HElems.alignOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(align))));
                PS3.SetMemory(elem + HElems.textOffset + 4, ReverseBytes(BitConverter.GetBytes(sort)));
                PS3.SetMemory(elem + HElems.fontSizeOffset, ToHexFloat(fontScale));
                PS3.SetMemory(elem + HElems.xOffset, ToHexFloat(x));
                PS3.SetMemory(elem + HElems.yOffset, ToHexFloat(y));
                PS3.SetMemory(elem + 0x88, new byte[] { 7 });
                PS3.SetMemory(elem + 0xa7, new byte[] { 69 });
                PS3.SetMemory(elem + HElems.colorOffset, RGBA(r, g, b, a));
                PS3.SetMemory(elem + HElems.GlowColor, RGBA(r1, g1, b1, a1));
                PS3.SetMemory(elem + HElems.clientOffset, ClientID);
                PS3.SetMemory(elem + 0x2b, new byte[] { 0x5 });
                PS3.SetMemory(elem + 0x88, new byte[] { 0x44 });
                PS3.SetMemory(elem + 0xA8, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(client))));

                PS3.SetMemory(elem + HElems.fxBirthTime, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(GetClientTime(CheckHost())))));
                PS3.SetMemory(elem + HElems.fxLetterTime, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(fxLetterTime))));
                PS3.SetMemory(elem + HElems.fxDecayStartTime, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(fxDecayStartTime))));
                PS3.SetMemory(elem + HElems.fxDecayDuration, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(fxDecayDuration))));
                System.Threading.Thread.Sleep(2);
            }


            static int GetClientTime(uint clientIndex)
            {

                byte[] buffer = new byte[4];
                PS3.GetMemory(0x0110a280 + (clientIndex * 0x3980), buffer);
                return BitConverter.ToInt32(ReverseBytes(buffer), 0);
            }
            public static void ActivateIndex(Boolean State, int index, int type)
            {

                uint elem = 0xF0E10C + ((uint)index * 0xB4);
                byte[] Type_ = BitConverter.GetBytes(type);
                Array.Reverse(Type_);
                if (State == true)
                {
                    PS3.SetMemory(elem, Type_);
                }
                else
                { PS3.SetMemory(elem, new byte[] { 0x00, 0x00, 0x00, 0x00 }); }
            }

        }

        public static string ByteArrayToString(byte[] bytes)
        {

            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            return enc.GetString(bytes);
        }

        public static uint CheckHost()
        {

            byte[] buffer = new byte[16];
            PS3.GetMemory(0x01BBBC2C, buffer);
            string myname = ByteArrayToString(buffer);
            for (uint i = 0; i < 18; i++)
            {

                if (myname == GetNames(i))
                {
                    return i;
                }
            }
            return 0;
        }
        public static string GetNames(uint clientIndex)
        {

            byte[] nameb = new byte[16];
            PS3.GetMemory(0x110a280 + (clientIndex * 0x3980) + 0x338C, nameb);
            return ByteArrayToString(nameb).Replace(Convert.ToChar(0x00).ToString(), string.Empty);
        }

        public static byte[] MakeBl(uint callAddr, uint addrToBlTo)
        {
            byte[] instruction = new byte[4];
            uint addr_t = (uint)(((int)addrToBlTo - (int)callAddr) + 1);
            if ((int)addrToBlTo > (int)callAddr) instruction[3] = 0x48;
            else
            {
                instruction[3] = 0x4B; addr_t = (uint)(0x1000000 - ((int)callAddr - (int)addrToBlTo) + 1);
            }
            byte[] addr = BitConverter.GetBytes(addr_t);
            for (int i = 0; i < 3; i++)
            {
                instruction[i] = addr[i];
            }
            Array.Reverse(instruction);
            return instruction;
        }


        public static byte[] uintBytes(uint input) { byte[] data = BitConverter.GetBytes(input); Array.Reverse(data); return data; }
        public static uint CreateText(string text)
        {
            RPC_MW3.CallFunction(1828556u, RPC_MW3.str_pointer(text));
            System.Threading.Thread.Sleep(10);

            return RPC_MW3.GetFuncReturn();
        }
        public static byte[] ReverseBytes(byte[] inArray) { Array.Reverse(inArray); return inArray; }
        public static byte[] ToHexFloat(float Axis) { byte[] bytes = BitConverter.GetBytes(Axis); Array.Reverse(bytes); return bytes; }
        public static byte[] RGBA(decimal R, decimal G, decimal B, decimal A) { byte[] RGBA = new byte[4]; byte[] RVal = BitConverter.GetBytes(Convert.ToInt32(R)); byte[] GVal = BitConverter.GetBytes(Convert.ToInt32(G)); byte[] BVal = BitConverter.GetBytes(Convert.ToInt32(B)); byte[] AVal = BitConverter.GetBytes(Convert.ToInt32(A)); RGBA[0] = RVal[0]; RGBA[1] = GVal[0]; RGBA[2] = BVal[0]; RGBA[3] = AVal[0]; return RGBA; }

        public static class HElems
        {
            //Some stuff from the Hudelems struct from Hacksorce we gonna need!
            public static uint xOffset = 0x04, yOffset = 0x08, textOffset = 0x84, fontOffset = 0x24, fontSizeOffset = 0x14, colorOffset = 0x30, relativeOffset = 0x2c, widthOffset = 0x44, heightOffset = 0x48, shaderOffset = 0x4c, GlowColor = 0x8C, clientOffset = 0xA8, alignOffset = 0x2C, fxBirthTime = 0x90,              // 0x90-0x94 
                 fxLetterTime = 0x94, fxDecayStartTime = 0x98, fxDecayDuration = 0x9c;
            
            public static uint alignOrg = 40;
            public static uint alignScreen = 0x2c;

            public static uint color = 0x30;
     
            public static uint duration = 0x7c;
            public static uint fadeStartTime = 0x38;
            public static uint fadeTime = 60;
            public static uint flags = 0xa4;
            public static uint font = 0x24;
            
            public static uint fontScale = 20;
            public static uint fontScaleStartTime = 0x1c;
            public static uint fontScaleTime = 0x20;
     
            public static uint fromAlignOrg = 0x68;
            public static uint fromAlignScreen = 0x6c;
            public static uint fromColor = 0x34;
            public static uint fromFontScale = 0x18;
            public static uint fromHeight = 0x54;
            public static uint fromWidth = 80;
            public static uint fromX = 0x60;
            public static uint fromY = 100;

            public static uint glowColor = 140;
         
            public static uint height = 0x48;
        
            public static uint label = 0x40;
            public static uint materialIndex = 0x4c;
            public static uint moveStartTime = 0x70;
            public static uint moveTime = 0x74;
         
            public static uint scaleStartTime = 0x58;
            public static uint scaleTime = 0x5c;
       
            public static uint sort = 0x88;
            public static uint soundID = 160;
            public static uint targetEntNum = 0x10;
            public static uint text = 0x84;
   
            public static uint time = 120;
            public static uint type = 0;
            public static uint value = 0x80;
            public static uint width = 0x44;
   
            public static uint zOffset = 12;
        }
        private void button37_Click(object sender, EventArgs e)
        {
            uint elem = this.HudElem_Alloc();
            this.setText(elem, this.uintBytesS(this.CreateText1(" ^:^2" + this.textBox5.Text)), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
            this.spawnElem(0x7ff, elem);
            this.setText(elem, this.uintBytesS(this.CreateText1(" ^:^2" + this.textBox5.Text)), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
            this.spawnElem(0x7ff, elem);
            byte[] DoHeart = new byte[] { 0x01, 0x43, 0xA1, 0x00, 0x00, 0x41, 0x80 };
            byte[] DoHeart2 = new byte[] { 0x3F, 0x70, };
            PS3.SetMemory(0x00F0E120, DoHeart2);
            timer2.Start();
            
        }
          

                private void button38_Click(object sender, EventArgs e)
                {
                   
                    timer2.Enabled = false;
                    timer3.Enabled = false;
                    timer4.Enabled = false;
                    timer5.Enabled = false;
                    timer6.Enabled = false;
                    timer7.Enabled = false;
                    timer8.Enabled = false;
                    
                    uint elem = this.HudElem_Alloc();
                    this.setText(elem, this.uintBytesS(this.CreateText1(" ^:^1" + this.textBox5.Text)), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
                    this.spawnElem(0x7ff, elem);
                    byte[] DoHeart = new byte[] { 0x00, 0x43, 0xA1, 0x00, 0x00, 0x41, 0x80 };
                    PS3.SetMemory(0x00F0E10f, DoHeart);
                    byte[] DoHeart2 = new byte[] { 0x3F, 0x70, };
                    PS3.SetMemory(0x00F0E120, DoHeart2);
                }

                private void timer2_Tick(object sender, EventArgs e)
                {
                    uint elem = this.HudElem_Alloc();
                    this.setText(elem, this.uintBytesS(this.CreateText1(" ^:^2" + this.textBox5.Text)), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
                    this.spawnElem(0x7ff, elem);
                    this.setText(elem, this.uintBytesS(this.CreateText1(" ^:^2" + this.textBox5.Text)), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
                    this.spawnElem(0x7ff, elem);
                    byte[] DoHeart = new byte[] { 0x01, 0x43, 0xA1, 0x00, 0x00, 0x41, 0x80 };
                    byte[] DoHeart2 = new byte[] { 0x3F, 0x70, };
                    PS3.SetMemory(0x00F0E120, DoHeart2);
                    timer2.Stop();
                    timer3.Start();
                }

                private void timer3_Tick(object sender, EventArgs e)
                {
                    uint elem = this.HudElem_Alloc();
                    this.setText(elem, this.uintBytesS(this.CreateText1(" ^:^4" + this.textBox5.Text)), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
                    this.spawnElem(0x7ff, elem);
                    this.setText(elem, this.uintBytesS(this.CreateText1(" ^:^4" + this.textBox5.Text)), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
                    this.spawnElem(0x7ff, elem);
                    byte[] DoHeart2 = new byte[] { 0x3F, 0x80, };
                    byte[] DoHeart = new byte[] { 0x01, 0x43, 0xA1, 0x00, 0x00, 0x41, 0x80 };
                    PS3.SetMemory(0x00F0E120, DoHeart2);
                    timer3.Stop();
                    timer4.Start();
                }

                private void timer4_Tick(object sender, EventArgs e)
                {
                    uint elem = this.HudElem_Alloc();
                    this.setText(elem, this.uintBytesS(this.CreateText1(" ^:^6" + this.textBox5.Text)), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
                    this.spawnElem(0x7ff, elem);
                    this.setText(elem, this.uintBytesS(this.CreateText1(" ^:^6" + this.textBox5.Text)), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
                    this.spawnElem(0x7ff, elem);
                    byte[] DoHeart2 = new byte[] { 0x3F, 0x90, };
                    byte[] DoHeart = new byte[] { 0x01, 0x43, 0xA1, 0x00, 0x00, 0x41, 0x80 };
                    PS3.SetMemory(0x00F0E120, DoHeart2);
                    timer4.Stop();
                    timer5.Start();
                }

                private void timer5_Tick(object sender, EventArgs e)
                {
                    uint elem = this.HudElem_Alloc();
                    this.setText(elem, this.uintBytesS(this.CreateText1(" ^:^3" + this.textBox5.Text)), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
                    this.spawnElem(0x7ff, elem);
                    this.setText(elem, this.uintBytesS(this.CreateText1(" ^:^3" + this.textBox5.Text)), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
                    this.spawnElem(0x7ff, elem);
                    byte[] DoHeart2 = new byte[] { 0x3F, 0x9A, };
                    byte[] DoHeart = new byte[] { 0x01, 0x43, 0xA1, 0x00, 0x00, 0x41, 0x80 };
                    PS3.SetMemory(0x00F0E120, DoHeart2);
                    timer5.Stop();
                    timer6.Start();
                }

                private void timer6_Tick(object sender, EventArgs e)
                {
                    uint elem = this.HudElem_Alloc();
                    this.setText(elem, this.uintBytesS(this.CreateText1(" ^:^5" + this.textBox5.Text)), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
                    this.spawnElem(0x7ff, elem);
                    this.setText(elem, this.uintBytesS(this.CreateText1(" ^:^5" + this.textBox5.Text)), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
                    this.spawnElem(0x7ff, elem);
                    byte[] DoHeart2 = new byte[] { 0x3F, 0xAA, };
                    byte[] DoHeart = new byte[] { 0x01, 0x43, 0xA1, 0x00, 0x00, 0x41, 0x80 };
                    PS3.SetMemory(0x00F0E120, DoHeart2);
                    timer6.Stop();
                    timer7.Start();
                }

                private void timer7_Tick(object sender, EventArgs e)
                {
                    uint elem = this.HudElem_Alloc();
                    this.setText(elem, this.uintBytesS(this.CreateText1(" ^:^1" + this.textBox5.Text)), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
                    this.spawnElem(0x7ff, elem);
                    this.setText(elem, this.uintBytesS(this.CreateText1(" ^:^1" + this.textBox5.Text)), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
                    this.spawnElem(0x7ff, elem);
                    byte[] DoHeart2 = new byte[] { 0x3F, 0xAF, };
                    byte[] DoHeart = new byte[] { 0x01, 0x43, 0xA1, 0x00, 0x00, 0x41, 0x80 };
                    PS3.SetMemory(0x00F0E120, DoHeart2);
                    timer7.Stop();
                    timer8.Start();
                }

                private void timer8_Tick(object sender, EventArgs e)
                {
                    uint elem = this.HudElem_Alloc();
                    this.setText(elem, this.uintBytesS(this.CreateText1(" ^:^7" + this.textBox5.Text)), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
                    this.setText(elem, this.uintBytesS(this.CreateText1(" ^:^7" + this.textBox5.Text)), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
                    this.spawnElem(0x7ff, elem);
                    this.spawnElem(0x7ff, elem);
                    byte[] DoHeart2 = new byte[] { 0x3F, 0xBC, };
                    byte[] DoHeart = new byte[] { 0x01, 0x43, 0xA1, 0x00, 0x00, 0x41, 0x80 };
                    PS3.SetMemory(0x00F0E120, DoHeart2);
                    timer8.Stop();
                    timer2.Start();
                }

                private void textBox5_TextChanged(object sender, EventArgs e)
                {

                }

                private void button39_Click(object sender, EventArgs e)
                {
                    button39.Visible = false;
                    button40.Visible = true;
                    uint elem = this.HudElem_Alloc();
                    this.setText(elem, this.uintBytesS(this.CreateText1(" ^0 444xMoDz Tool " + "\r" + " ^4444xMoDz Tool " + "\r" +" " + " ^1444xMoDz Tool " + "\r" + "^6_^5_^6_^5_^6_^5_^6_^5_^6_^5_^6_^5_^6_^5_^6_^5_")), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
                    this.spawnElem(0x7ff, elem);
                    byte[] DoHeart = new byte[] { 0x01, 0x43, 0xA1, 0x00, 0x00, 0x41, 0x80 };
                    PS3.SetMemory(0x00F0E10f, DoHeart);
                    byte[] DoHeart2 = new byte[] { 0x3F, 0xAF, };
                    PS3.SetMemory(0x00F0E120, DoHeart2);
                    timer9.Enabled = true;
                }

                private void timer9_Tick(object sender, EventArgs e)
                {
                    uint elem = this.HudElem_Alloc();
                    this.setText(elem, this.uintBytesS(this.CreateText1(" ^0 444xMoDz Tool " + "\r" + " ^1444xMoDz Tool " + "\r" + " " + " ^4444xMoDz Tool " + "\r" + "^5_^6_^5_^6_^5_^6_^5_^6_^5_^6_^5_^6_^5_^6_^5_^6_")), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
                    this.spawnElem(0x7ff, elem);
                    byte[] DoHeart = new byte[] { 0x01, 0x43, 0xA1, 0x00, 0x00, 0x41, 0x80 };
                    PS3.SetMemory(0x00F0E10f, DoHeart);
                    byte[] DoHeart2 = new byte[] { 0x3F, 0xAF, };
                    PS3.SetMemory(0x00F0E120, DoHeart2);
                    timer9.Enabled = false;
                    timer10.Enabled = true;
                }

                private void timer10_Tick(object sender, EventArgs e)
                {
                    uint elem = this.HudElem_Alloc();
                    this.setText(elem, this.uintBytesS(this.CreateText1(" ^0 444xMoDz Tool " + "\r" + " ^4444xMoDz Tool " + "\r" + " " + " ^1444xMoDz Tool " + "\r" + "^6_^5_^6_^5_^6_^5_^6_^5_^6_^5_^6_^5_^6_^5_^6_^5_")), 6, 322f, 5f, 1, 0xff, 0xff, 0xff, 0xff);
                    this.spawnElem(0x7ff, elem);
                    byte[] DoHeart = new byte[] { 0x01, 0x43, 0xA1, 0x00, 0x00, 0x41, 0x80 };
                    PS3.SetMemory(0x00F0E10f, DoHeart);
                    byte[] DoHeart2 = new byte[] { 0x3F, 0xAF, };
                    PS3.SetMemory(0x00F0E120, DoHeart2);
                    timer10.Enabled = false;
                    timer9.Enabled = true;
                }

                private void button40_Click(object sender, EventArgs e)
                {
                    timer9.Enabled = false;
                    timer10.Enabled = false;
                    button39.Visible = true;
                    button40.Visible = false;
                }

                private void timer11_Tick(object sender, EventArgs e)
                {
                    RPC_MW3.iPrintlnBold(-1, textBox4.Text);
                }

                private void textBox4_TextChanged_1(object sender, EventArgs e)
                {

                }

                private void button42_Click(object sender, EventArgs e)
                {
                    timer11.Start();
                }

                private void button41_Click(object sender, EventArgs e)
                {
                    timer11.Stop();
                }

                private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
                {

                }

                private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
                {
                    try
                    {
                        if (e.Button == MouseButtons.Right)
                        {
                            dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                            dataGridView1.Rows[e.RowIndex].Selected = true;
                            dataGridView1.Focus();

                        }
                    }
                    catch
                    {
                        //nothing
                    }
                }
                private void cName(uint ClientIndex)
                {
                    Encoding.ASCII.GetBytes(string.Concat(this.textBox6.Text, "\0"));
                    PS3.Extension.WriteString(0x0110D694 + ClientIndex * 0x3980, this.textBox6.Text);
                }
                private void button44_Click(object sender, EventArgs e)
                {
                    if (comboBox10.SelectedItem == "Client 0")
                    {

                        cName(0);
                    }
                    if (comboBox10.SelectedItem == "Client 1")
                    {
                        cName(1);

                    }
                    if (comboBox10.SelectedItem == "Client 2")
                    {
                        cName(2);

                    }
                    if (comboBox10.SelectedItem == "Client 3")
                    {
                        cName(3);
                    }
                    if (comboBox10.SelectedItem == "Client 4")
                    {
                        cName(4);

                    }
                    if (comboBox10.SelectedItem == "Client 5")
                    {
                        cName(5);
                    }
                    if (comboBox10.SelectedItem == "Client 6")
                    {

                        cName(6);
                    }
                    if (comboBox10.SelectedItem == "Client 7")
                    {
                        cName(7);

                    }
                    if (comboBox10.SelectedItem == "Client 8")
                    {
                        cName(8);

                    }
                    if (comboBox10.SelectedItem == "Client 9")
                    {
                        cName(9);
                    }
                    if (comboBox10.SelectedItem == "Client 10")
                    {
                        cName(10);

                    }
                    if (comboBox10.SelectedItem == "Client 11")
                    {
                        cName(11);
                    }
                    if (comboBox10.SelectedItem == "Client 12")
                    {

                        cName(12);
                    }
                    if (comboBox10.SelectedItem == "Client 13")
                    {
                        cName(13);

                    }
                    if (comboBox10.SelectedItem == "Client 14")
                    {
                        cName(14);

                    }
                    if (comboBox10.SelectedItem == "Client 15")
                    {
                        cName(15);
                    }
                    if (comboBox10.SelectedItem == "Client 16")
                    {
                        cName(16);

                    }
                    if (comboBox10.SelectedItem == "Client 17")
                    {
                        cName(17);
                    }
                }

                private void textBox6_TextChanged(object sender, EventArgs e)
                {

                }

                private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
                {

                }

                private void checkBox13_CheckedChanged(object sender, EventArgs e)
                {
                    {
                        if (this.checkBox13.Checked)
                        {

                            timer12.Start();

                        }
                        if (!this.checkBox13.Checked)
                        {
                            timer12.Stop();
                        }
                    }
                }

                private void timer12_Tick(object sender, EventArgs e)
                {
                    cName(0);
                    cName(1);
                    cName(2);
                    cName(3);
                    cName(4);
                    cName(5);
                    cName(6);
                    cName(7);
                    cName(8);
                    cName(9);
                    cName(10);
                    cName(11);
                    cName(12);
                    cName(13);
                    cName(14);
                    cName(15);
                    cName(16);
                    cName(17);
                }
                private String ReturnInfosmw3(Int32 Index)
                {
                    return Encoding.ASCII.GetString(PS3.GetBytes(0X008360d5, 0x100)).Replace(@"\", "|").Split('|')[Index];
                }
                public String getMapNamemw3()
                {
                    String Map = ReturnInfosmw3(6);
                    switch (Map)
                    {
                        default: return "Unknown Map";
                        case "mp_alpha": return "Lockdown";
                        case "mp_bootleg": return "Bootleg";
                        case "mp_bravo": return "Mission";
                        case "mp_carbon": return "Carbon";
                        case "mp_dome": return "Dome";
                        case "mp_exchange": return "Downturn";
                        case "mp_hardhat": return "Hardhat";
                        case "mp_interchange": return "Interchange";
                        case "mp_lambeth": return "Fallen";
                        case "mp_mogadishu": return "Bakaara";
                        case "mp_paris": return "Resistance";
                        case "mp_plaza2": return "Arkaden";
                        case "mp_radar": return "Outpost";
                        case "mp_seatown": return "Seatown";
                        case "mp_underground": return "Underground";
                        case "mp_village": return "Village";
                        case "mp_aground_ss": return "Aground";
                        case "mp_aqueduct_ss": return "Aqueduct";
                        case "mp_cement": return "Foundation";
                        case "mp_hillside_ss": return "Getaway";
                        case "mp_italy": return "Piazza";
                        case "mp_meteora": return "Sanctuary";
                        case "mp_morningwood": return "Black Box";
                        case "mp_overwatch": return "Overwatch";
                        case "mp_park": return "Liberation";
                        case "mp_qadeem": return "Oasis";
                        case "mp_restrepo_ss": return "Lookout";
                        case "mp_terminal_cls": return "Terminal";
                    }
                }
                public String getGameModemw3()
                {
                    String GM = ReturnInfosmw3(2);
                    switch (GM)
                    {
                        default: return "Unknown Gametype";
                        case "war": return "Team Deathmatch";
                        case "dm": return "Free for All";
                        case "sd": return "Search and Destroy";
                        case "dom": return "Domination";
                        case "conf": return "Kill Confirmed";
                        case "sab": return "Sabotage";
                        case "koth": return "Head Quartes";
                        case "ctf": return "Capture The Flag";
                        case "infect": return "Infected";
                        case "sotf": return "Hunted";
                        case "dd": return "Demolition";
                        case "grnd": return "Drop Zone";
                        case "tdef": return "Team Defender";
                        case "tjugg": return "Team Juggernaut";
                        case "jugg": return "Juggernaut";
                        case "gun": return "Gun Game";
                        case "oic": return "One In The Chamber";

                    }
                }
                public String getHostNamemw3()
                {
                    String Host = ReturnInfosmw3(16);
                    if (Host == "Modern Warfare 3")
                        return "Dedicated Server (No Player is Host)";
                    else if (Host == "")
                        return "You are not In-Game";
                    else return Host;
                }
                private void tabPage6_Click(object sender, EventArgs e)
                {

                }

                private void button45_Click(object sender, EventArgs e)
                {
                    HOST.Text = getHostNamemw3();
                    MAP.Text = getMapNamemw3();
                    GAME.Text = getGameModemw3();
                }

                private void checkBox14_CheckedChanged(object sender, EventArgs e)
                {
                    {
                        if (this.checkBox14.Checked)
                        {

                            timer13.Start();

                        }
                        if (!this.checkBox14.Checked)
                        {
                            timer13.Stop();
                        }
                    }
                }

                private void timer13_Tick(object sender, EventArgs e)
                {
                    HOST.Text = getHostNamemw3();
                    MAP.Text = getMapNamemw3();
                    GAME.Text = getGameModemw3();
                }

                private void onToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    byte[] godmode = new byte[] { 0xFF };
                    PS3.SetMemory((0x0FCA41E + (uint)dataGridView1.CurrentRow.Index * 0x280), godmode);
                }

                private void button43_Click(object sender, EventArgs e)
                {
                    if (dataGridView1.RowCount == 1)
                    {
                        dataGridView1.Rows.Add(17);
                    }

                    for (uint i = 0; i < 18; i++)
                    {
                        dataGridView1[0, Convert.ToInt32(i)].Value = i;
                        dataGridView1[1, Convert.ToInt32(i)].Value = ClientNamesmw3(i);
                    }
                }

                private void offToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    byte[] godmode = new byte[] { 0x00 };
                    PS3.SetMemory((0x0FCA41E + (uint)dataGridView1.CurrentRow.Index * 0x280), godmode);
                }

                private void onToolStripMenuItem1_Click(object sender, EventArgs e)
                {

                }

                private void dragunovToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    byte[] ac130 = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x29, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x29, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x29, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x29, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00, 0x18, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x29, 0x00, 0x00, 0x03, 0xD9, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x29, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x31, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x29, 0x00, 0x00, 0x0F, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00F };
                    PS3.SetMemory((0x0110A4F0 + (uint)dataGridView1.CurrentRow.Index * 0x3980), ac130);
                }

                private void barretToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    
                  
                    byte[] godmode = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2B, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x2B, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x2B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x2B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00, 0x18, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2B, 0x00, 0x00, 0x03, 0xD9, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2B, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x31, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2B, 0x00, 0x00, 0x0F, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00F };
                    PS3.SetMemory((0x0110A4F0 + (uint)dataGridView1.CurrentRow.Index * 0x3980), godmode);
                }

                private void rSASSToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    byte[] ac130 = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2C, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x2C, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x2C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x2C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00, 0x18, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2C, 0x00, 0x00, 0x03, 0xD9, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2C, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x31, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2C, 0x00, 0x00, 0x0F, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00F };
                    PS3.SetMemory((0x0110A4F0+(uint)dataGridView1.CurrentRow.Index * 0x3980), ac130);
                }

                private void juggToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    byte[] ac130 = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2d, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x2d, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2d, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x2d, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x2d, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00, 0x18, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2d, 0x00, 0x00, 0x03, 0xD9, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2d, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x31, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2d, 0x00, 0x00, 0x0F, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00F };
                    PS3.SetMemory((0x0110A4F0 + (uint)dataGridView1.CurrentRow.Index * 0x3980), ac130);
                }

                private void mSRToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    byte[] ac130 = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2A, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x2A, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2A, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x2A, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x2A, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00, 0x18, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2A, 0x00, 0x00, 0x03, 0xD9, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2A, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x31, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x2A, 0x00, 0x00, 0x0F, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00F };
                    PS3.SetMemory((0x0110A4F0 + (uint)dataGridView1.CurrentRow.Index * 0x3980), ac130);
                }

                private void juggToolStripMenuItem1_Click(object sender, EventArgs e)
                {
                    byte[] ac130 = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x35, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x35, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x35, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x35, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x35, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00, 0x18, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x35, 0x00, 0x00, 0x03, 0xD9, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x35, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x31, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x35, 0x00, 0x00, 0x0F, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00F };
                    PS3.SetMemory((0x0110A4F0 + (uint)dataGridView1.CurrentRow.Index * 0x3980), ac130);
                }
                public void AMMO(uint Pclientnum)
                {

                    byte[] PEmptyN = new byte[] { 0x0f, 0xff, 0xff, 0xff };
                    byte[] PEmptyN1 = new byte[] { 0x0f, 0xff, 0xff };

                    PS3.SetMemory(0x0110a6ab + (0x3980 * Pclientnum), PEmptyN);
                    PS3.SetMemory(0x0110a629 + (0x3980 * Pclientnum), PEmptyN1);

                    byte[] PEmptyN2 = new byte[] { 0x0f, 0xff, 0xff, 0xff };
                    byte[] PEmptyN3 = new byte[] { 0x0f, 0xff, 0xff };

                    PS3.SetMemory(0x0110a691 + (0x3980 * Pclientnum), PEmptyN2);
                    PS3.SetMemory(0x0110a619 + (0x3980 * Pclientnum), PEmptyN3);
                    PS3.SetMemory(0x0110a690 + (0x3980 * Pclientnum), PEmptyN3);
                    PS3.SetMemory(0x0110a6a8 + (0x3980 * Pclientnum), PEmptyN3);
                    PS3.SetMemory(0x0110a6cd + (0x3980 * Pclientnum), PEmptyN3);
                    PS3.SetMemory(0x0110a6c0 + (0x3980 * Pclientnum), PEmptyN3);
                    PS3.SetMemory(0x0110a69c + (0x3980 * Pclientnum), PEmptyN3);
                    PS3.SetMemory(0x0110a6c0 + (0x3980 * Pclientnum), PEmptyN3);
                    PS3.SetMemory(0x0110a6b4 + (0x3980 * Pclientnum), PEmptyN3);


                }
                private void unlimitedAmmoToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    AMMO((uint)dataGridView1.CurrentRow.Index);
                }

                private void kickClientToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    SV_KickClient((uint)dataGridView1.CurrentRow.Index,"");
                }

                private void kickWhitErrorToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    RPC_MW3.Kick(dataGridView1.CurrentRow.Index,"^1Faggot!");
                }
                private static void killmw3(uint ClientNum)
                {
                    byte[] EmptyN = new byte[] { 0xff, 0xff, 0xff, 0x74 };
                    PS3.SetMemory(0x0110A2a5 + (0x3980 * ClientNum), EmptyN);
                }
                    public void Suicide(uint ClientNum)
                     {

                         PS3.SetMemory(0x110a2a5 + (ClientNum * 0x3980), new byte[] { 0xff });
        


                    }
                  
                private void toolStripMenuItem1_Click(object sender, EventArgs e)
                {
                    kill((uint)dataGridView1.CurrentRow.Index);
                }


                private void kill(uint ClientNum)
                {
                    byte[] EmptyN = new byte[] { 0xff };
                    PS3.SetMemory(0x0110a2a5 + (0x3980 * ClientNum), EmptyN);

                }
           private void PS3Freeez(uint ClientNum)
                {
               PS3.SetMemory(0x110A4FF + (((UInt32)client* 0x3980)), new byte[] { 0x80 });
                PS3.SetMemory(0x110a4f7 + (((UInt32)client * 0x3980)), new byte[] { 0x80 });
                PS3.SetMemory(0x110a503 + (((UInt32)client * 0x3980)), new byte[] { 0x80 });
                PS3.SetMemory(0x110a69b + (((UInt32)client * 0x3980)), new byte[] { 0x80 });
                }
                private void freezePS3ToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    
                        PS3Freeze((int)dataGridView1.CurrentRow.Index);
                   
                }

                private void toolStripMenuItem3_Click(object sender, EventArgs e)
                {
                    byte[] godmode = new byte[] {  };
                    PS3.SetMemory((0x0110a2a5 + (uint)dataGridView1.CurrentRow.Index * 0x3980), godmode);
                }

                private void onToolStripMenuItem2_Click(object sender, EventArgs e)
                {
                    byte[] godmode = new byte[] { 0x07 };
                    PS3.SetMemory((0x0110d87f + (uint)dataGridView1.CurrentRow.Index * 0x3980), godmode);
                }

                private void offToolStripMenuItem2_Click(object sender, EventArgs e)
                {
                    byte[] godmode = new byte[] { 0x00 };
                    PS3.SetMemory((0x0110d87f + (uint)dataGridView1.CurrentRow.Index * 0x3980), godmode);
                }

                private void onToolStripMenuItem3_Click(object sender, EventArgs e)
                {
                    byte[] godmode = new byte[] { 0x02};
                    PS3.SetMemory((0x0110d87f + (uint)dataGridView1.CurrentRow.Index * 0x3980), godmode);
                }

                private void offToolStripMenuItem3_Click(object sender, EventArgs e)
                {
                    byte[] godmode = new byte[] { 0x00 };
                    PS3.SetMemory((0x0110d87f + (uint)dataGridView1.CurrentRow.Index * 0x3980), godmode);
                }

                private void friendlyToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    byte[] godmode = new byte[] { 0x01 };
                    PS3.SetMemory((0x0110d657 + (uint)dataGridView1.CurrentRow.Index * 0x3980), godmode);
                }

                private void enemyToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    byte[] godmode = new byte[] { 0x02 };
                    PS3.SetMemory((0x0110d657 + (uint)dataGridView1.CurrentRow.Index * 0x3980), godmode);
                }

                private void spectatorToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    byte[] godmode = new byte[] { 0x07};
                    PS3.SetMemory((0x0110d657 + (uint)dataGridView1.CurrentRow.Index * 0x3980), godmode);
                }

                private void onToolStripMenuItem1_Click_1(object sender, EventArgs e)
                {
                    byte[] godmode = new byte[] { 0x01 };
                    PS3.SetMemory((0x0110D5AF + (uint)dataGridView1.CurrentRow.Index * 0x3980), godmode);
                }

                private void offToolStripMenuItem1_Click(object sender, EventArgs e)
                {
                    byte[] godmode = new byte[] { 0x02};
                    PS3.SetMemory((0x0110D5AF + (uint)dataGridView1.CurrentRow.Index * 0x3980), godmode);
                }

                private void toolStripMenuItem7_Click(object sender, EventArgs e)
                {
                  
                }

                private void onToolStripMenuItem4_Click(object sender, EventArgs e)
                {
                    int client = dataGridView1.CurrentRow.Index;
                    {
                        PS3.SetMemory(0x0FCA41E + 0x280 * (uint)client, new byte[] { 0xFF, 0xFF, });
                    }
                }

                private void offToolStripMenuItem4_Click(object sender, EventArgs e)
                {
                    int client = dataGridView1.CurrentRow.Index;
                    {
                        PS3.SetMemory(0x0FCA41E + 0x280 * (uint)client, new byte[] { 0x00, 0x00, });
                    }
                }

                private void toolStripMenuItem8_Click(object sender, EventArgs e)
                {
                    int client = dataGridView1.CurrentRow.Index;
                    {
                        PS3.SetMemory(0x0110A4F0 + (0x3980 * (uint)client), new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x45, 0x00, 0x00, 0x00, 0x5C, 0x00, 0x00, 0x00, 0x8B, 0x00, 0x00, 0x00, 0x68, 0x00, 0x00, 0x00, 0x67, 0x00, 0x00, 0x00, 0x51, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x42, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x8B, 0x0F, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00, 0x42, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1A, 0x00, 0x00, 0x00, 0x50, 0x00, 0x00, 0x00, 0x45, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x51, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x8B, 0x00, 0x0F, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x5C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x67, 0x00, 0x00, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x68, 0x00, 0x00, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x42, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x1A, 0x00, 0x00, 0x00, 0x28, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x45, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x8B, 0x00, 0x0F, 0xFF, 0xFF, 0x00, 0x00, 0x00 });

                    }
                }

                private void toMeToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    int client = dataGridView1.CurrentRow.Index;
                    {
                        byte[] Position = PS3.GetBytes(0x110A29C + ((uint)client * 0x3980), 0xC);
                        for (int clients = 0; clients < 18; clients++)
                        {
                            PS3.SetMemory(0x110A29C + ((uint)clients * 0x3980), Position);
                        }
                    }
                }

                private void toolStripMenuItem11_Click(object sender, EventArgs e)
                {

                }

                private void toolStripMenuItem10_Click(object sender, EventArgs e)
                {
                    int client = dataGridView1.CurrentRow.Index;
                    {
                        PS3.SetMemory(0x0110A773 + 0x3980 * (uint)client, new byte[] { 0xC5, 0xFF, });
                       
                    }
                }

                private void onToolStripMenuItem5_Click(object sender, EventArgs e)
                {
                int client = dataGridView1.CurrentRow.Index;
            {
                PS3.SetMemory(0x0110A773 + 0x3980 * (uint)client, new byte[] { 0xC5, 0xFF, });
                RPC_MW3.CallFunction(0x1DB240, 0, RPC_MW3.str_pointer("set bg_bulletExplDmgFactor 100"));
            }
                }

                private void offToolStripMenuItem5_Click(object sender, EventArgs e)
                {
                    int client = dataGridView1.CurrentRow.Index;
                    {
                        PS3.SetMemory(0x0110A773 + 0x3980 * (uint)client, new byte[] { 0xC5, 0xFF, });
                        RPC_MW3.CallFunction(0x1DB240, 0, RPC_MW3.str_pointer("set bg_bulletExplDmgFactor 10"));
                    }
                }

                private void toolStripMenuItem12_Click(object sender, EventArgs e)
                {
                    int client = dataGridView1.CurrentRow.Index;
                    {
                        PS3.SetMemory(0x0110A76d + 0x3980 * (uint)client, new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x00 });

                    }
            
                }

                private void onToolStripMenuItem6_Click(object sender, EventArgs e)
                {

                }

                private void toolStripMenuItem13_Click(object sender, EventArgs e)
                {
                    int client = dataGridView1.CurrentRow.Index;
                    {
                        PS3.SetMemory(0x110D640 + 0x3980 * (uint)client, new byte[] { 0x40, 0x00, 0x00, 0x00, });
                    }
                }

                private void onToolStripMenuItem6_Click_1(object sender, EventArgs e)
                {
                    int client = dataGridView1.CurrentRow.Index;
                    {
                        byte[] EmptyN = new byte[] { 0x01 };
                        PS3.SetMemory(0x0110a549 + (0x3980 * (uint)client), EmptyN);
                        PS3.SetMemory(0x0110a531 + (0x3980 * (uint)client), EmptyN);

                    }
                }

                private void offToolStripMenuItem6_Click(object sender, EventArgs e)
                {
                    int client = dataGridView1.CurrentRow.Index;
                    {
                        byte[] EmptyN = new byte[] { 0x00 };
                        PS3.SetMemory(0x0110a549 + (0x3980 * (uint)client), EmptyN);
                        PS3.SetMemory(0x0110a531 + (0x3980 * (uint)client), EmptyN);

                    }
                }

                private void onToolStripMenuItem7_Click(object sender, EventArgs e)
                {
                    int client = dataGridView1.CurrentRow.Index;
                    {
                        PS3.SetMemory(0x0110a292 + 0x3980 * (uint)client, new byte[] { 0x99, });
                    }
                }

                private void offToolStripMenuItem7_Click(object sender, EventArgs e)
                {
                    int client = dataGridView1.CurrentRow.Index;
                    {
                        PS3.SetMemory(0x0110a292 + 0x3980 * (uint)client, new byte[] { 0x00, });
                    }
                }
                
                public static void TeleportEveryoneHere(int ClientNum)
                {
                   
                }
                private void everyoneHereToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    byte[] YouPos = new byte[13];
                    byte[] HimPos = new byte[13];

                    PS3.GetMemory(0x110d60c + (14720 * Client) - 13168, HimPos);
                    PS3.SetMemory(0x110d60c + (14720 * Client) - 13168, HimPos);
                }

                private void toolStripMenuItem16_Click(object sender, EventArgs e)
                {
                    byte[] EmptyN = new byte[] { 0x41 };
                    PS3.SetMemory(0x110D640 + ((uint)dataGridView1.CurrentRow.Index * 0x3980), EmptyN);
                }

                private void toolStripMenuItem17_Click(object sender, EventArgs e)
                {

                }

                private void onToolStripMenuItem8_Click(object sender, EventArgs e)
                {
                    int index = this.dataGridView1.CurrentRow.Index;
                    RPC_MW3.Set_ClientDvar(index, "cg_thirdperson 1");

                }

                private void onToolStripMenuItem9_Click(object sender, EventArgs e)
                {
                    byte[] godmode = new byte[] { 0xFF };
                    PS3.SetMemory((0x0110a5f7 + (uint)dataGridView1.CurrentRow.Index * 0x3980), godmode);
                }

                private void offToolStripMenuItem9_Click(object sender, EventArgs e)
                {
                    byte[] godmode = new byte[] { 0x00 };
                    PS3.SetMemory((0x0110a5f7 + (uint)dataGridView1.CurrentRow.Index * 0x3980), godmode);
                }
                public void Wallhack(uint ClientNum)
                {
                    PS3.SetMemory(0x110a297 + (0x3980 * ClientNum), new byte[] { 9 });
                }

                public void WallhackOFF(uint ClientNum)
                {
                    PS3.SetMemory(0x110a297 + (0x3980 * ClientNum), new byte[1]);
                }
                private void onToolStripMenuItem10_Click(object sender, EventArgs e)
                {
                    int index = this.dataGridView1.CurrentRow.Index;
                    this.Wallhack((uint)index);
                    RPC_MW3.iPrintlnBold(index, "Wallhack: ^2ON");
                   
                }

                private void offToolStripMenuItem10_Click(object sender, EventArgs e)
                {
                    int index = this.dataGridView1.CurrentRow.Index;
                    this.WallhackOFF((uint)index);
                    RPC_MW3.iPrintlnBold(index, "Wallhack: ^1OFF");
                }
                private static void killmw33(uint client)
                {
                    PS3.SetMemory(0x0110A29C + 0x3980 * (uint)client, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, });
                    System.Threading.Thread.Sleep(2);
                    PS3.SetMemory(0x0110a28d + 0x3980 * (uint)client, new byte[] { 0x54, });
                  
                    PS3.SetMemory(0x110D640 + 0x3980 * (uint)client, new byte[] { 0x40, 0x00, 0x00, 0x00, });
                  
                    PS3.SetMemory(0x0110a5f7 + (uint)client * 0x3980, new byte[] { 0x00 });
                    PS3.SetMemory(0x0110a293 + (uint)client * 0x3980, new byte[] { 0x38 });
                    System.Threading.Thread.Sleep(2);
                   

                }
                private void toolStripMenuItem22_Click(object sender, EventArgs e)
                {
                    int client = dataGridView1.CurrentRow.Index;
                    {
                        PS3.SetMemory(0x0110A29C + 0x3980 * (uint)client, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, });
                        System.Threading.Thread.Sleep(2);
                        PS3.SetMemory(0x0110a28d + 0x3980 * (uint)client, new byte[] { 0x54, });
                        //0x0110a28d 
                        PS3.SetMemory(0x110D640 + 0x3980 * (uint)client, new byte[] { 0x40, 0x00, 0x00, 0x00, });
                        RPC_MW3.iPrintlnBold(client, "^1You Are An Exorcist");
                        PS3.SetMemory(0x0110a5f7 + (uint)client * 0x3980, new byte[] { 0x00 });
                        PS3.SetMemory(0x0110a293 + (uint)client * 0x3980, new byte[] { 0x38 });
                        System.Threading.Thread.Sleep(2);
                        RPC_MW3.iPrintlnBold(client, "^1Go Get Them");


                    }
                }

                private void toolStripMenuItem19_Click(object sender, EventArgs e)
                {

                }

                private void offToolStripMenuItem8_Click(object sender, EventArgs e)
                {
                    int index = this.dataGridView1.CurrentRow.Index;
                    RPC_MW3.Set_ClientDvar(index, "cg_thirdperson 0");
                }

                private void testToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    RPC_MW3.SetModel(dataGridView1.CurrentRow.Index, "Care_Package");
                }

                private void carePackageToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    RPC_MW3.SetModel(dataGridView1.CurrentRow.Index, "vehicle_av8b_harrier_jet_mp");
                }

                private void harrier2ToolStripMenuItem_Click(object sender, EventArgs e)
                {

                    RPC_MW3.SetModel(dataGridView1.CurrentRow.Index, "vehicle_av8b_harrier_jet_opfor_mp");
                }

                private void paveLowToolStripMenuItem_Click(object sender, EventArgs e)
                {

                    RPC_MW3.SetModel(dataGridView1.CurrentRow.Index, "vehicle_pavelow");
                }

                private void ac130ToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    RPC_MW3.SetModel(dataGridView1.CurrentRow.Index, "vehicle_ac130_coop");
                }

                private void opForceToolStripMenuItem_Click(object sender, EventArgs e)
                {
                   
                        RPC_MW3.SetModel(dataGridView1.CurrentRow.Index, "head_opforce_russian_air_sniper");
                }

                private void acogToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    RPC_MW3.SetModel(dataGridView1.CurrentRow.Index, "weapon_acog");
                }

                private void thermalToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    RPC_MW3.Vision(dataGridView1.CurrentRow.Index, "ac130_thermal_mp");
                }

                private void airportGreenToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    RPC_MW3.Vision(dataGridView1.CurrentRow.Index, "airport_green");
                }

                private void aftermathToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    RPC_MW3.Vision(dataGridView1.CurrentRow.Index, "aftermath");
                }

                private void blackoutToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    RPC_MW3.Vision(dataGridView1.CurrentRow.Index, "blackout");
                }

                private void nightToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    RPC_MW3.Vision(dataGridView1.CurrentRow.Index, "default_night_mp");
                }

                private void hamburgToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    RPC_MW3.Vision(dataGridView1.CurrentRow.Index, "berlin_parkway");
                }

                private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    RPC_MW3.Vision(dataGridView1.CurrentRow.Index, "default");
                }

                private void defaultToolStripMenuItem1_Click(object sender, EventArgs e)
                {
                    RPC_MW3.SetModel(dataGridView1.CurrentRow.Index, "defaultvehicle");
                }
                public static bool GetMap1()
                {

                    byte[] MAPN1 = new byte[17];

                    string Mapstring1 = "";
                    System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                    PS3.GetMemory(0x11f92ad, MAPN1);
                    Mapstring1 = encoding.GetString(MAPN1);
                    bool plusone = false;


                    if (Mapstring1.Contains("mp_mogadishu"))
                    {
                        plusone = false;
                    }

                    if (Mapstring1.Contains("mp_terminal"))
                    {
                        plusone = false;
                    }
                    if (Mapstring1.Contains("mp_seatown"))
                    {
                        plusone = true;
                    }
                    if (Mapstring1.Contains("mp_dome"))
                    {
                        plusone = false;
                    }
                    if (Mapstring1.Contains("mp_plaza2"))
                    {
                        plusone = true;
                    }
                    if (Mapstring1.Contains("mp_paris"))
                    {
                        plusone = true;
                    }
                    if (Mapstring1.Contains("mp_exchange"))
                    {
                        plusone = true;
                    }
                    if (Mapstring1.Contains("mp_bootleg"))
                    {
                        plusone = true;
                    }
                    if (Mapstring1.Contains("mp_carbon"))
                    {
                        plusone = false;
                    }
                    if (Mapstring1.Contains("mp_hardhat"))
                    {
                        plusone = false;
                    }
                    if (Mapstring1.Contains("mp_alpha"))
                    {
                        plusone = true;
                    }
                    if (Mapstring1.Contains("mp_village"))
                    {
                        plusone = true;
                    }
                    if (Mapstring1.Contains("mp_lambeth"))
                    {
                        plusone = false;
                    }
                    if (Mapstring1.Contains("mp_radar"))
                    {
                    }
                    if (Mapstring1.Contains("mp_interchange"))
                    {
                        plusone = false;
                    }
                    if (Mapstring1.Contains("mp_underground"))
                    {
                        plusone = true;
                    }
                    if (Mapstring1.Contains("mp_bravo"))
                    {
                        plusone = true;
                    }

                    return plusone;

                }
           private void rockets(uint Clientnum)
        {
            try
            {
                if (GetMap1() == false)
                    
                
                    
                {
                    PS3.SetMemory(0x0110A4F0 + (Clientnum * 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x71, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x71, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x71, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x71, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00, 0x18, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x71, 0x00, 0x00, 0x03, 0xFD, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x71, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x31, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x69, 0x00, 0x00, 0x0F, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x71, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
                }
                else
                {
                    PS3.SetMemory(0x0110A4F0 + (Clientnum * 0x3980), new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x70, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x70, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x70, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x70, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00, 0x18, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x70, 0x00, 0x00, 0x03, 0xFD, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x70, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x31, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x69, 0x00, 0x00, 0x0F, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x70, 0x00, 0x00, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
                }
            }
            catch
            {

            }
        }
                private void rocketsToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    rockets((uint)dataGridView1.CurrentRow.Index);
                }

                private void ac130ToolStripMenuItem1_Click(object sender, EventArgs e)
                {
                    
            if (GetMap1() == true)
            {//69
                byte[] ac130 = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x69, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x69, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x69, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x69, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00, 0x18, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x69, 0x00, 0x00, 0x03, 0xD9, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x69, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x31, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x69, 0x00, 0x00, 0x0F, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00F };
                PS3.SetMemory(0x0110A4F0 + ((uint)dataGridView1.CurrentRow.Index * 0x3980), ac130);
            }
            else
            {//6A
                byte[] ac130 = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x6A, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x6A, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x6A, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x6A, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x3F, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x07, 0x00, 0x00, 0x00, 0x18, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x6A, 0x00, 0x00, 0x03, 0xFD, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x6A, 0x00, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F, 0x00, 0x00, 0x00, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x43, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x31, 0x00, 0x00, 0x00, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46, 0x00, 0x00, 0x00, 0x02, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x69, 0x00, 0x00, 0x0F, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x6A, 0x00, 0x00, 0xFF, 0xFF };
                PS3.SetMemory(0x0110A4F0 + ((uint)dataGridView1.CurrentRow.Index * 0x3980), ac130);
            }

    }

                private void mP7ToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    
                }

                private void button46_Click(object sender, EventArgs e)
                {
                    timer14.Start();
                }

                private void button47_Click(object sender, EventArgs e)
                {
                    timer14.Stop();
                }

                private void timer14_Tick(object sender, EventArgs e)
                {
                    killmw3(0);
                    killmw3(1);
                    killmw3(2);
                    killmw3(3);
                    killmw3(4);
                    killmw3(5);
                    killmw3(6);
                    killmw3(7);
                    killmw3(8);
                    killmw3(9);
                    killmw3(10);
                    killmw3(11);
                    killmw3(12);
                    killmw3(13);
                    killmw3(14);
                    killmw3(15);
                    killmw3(16);
                    killmw3(17);
                    RPC_MW3.iPrintlnBold(-1, "^1Kill And Scare Lobby");

                }

                private void button48_Click(object sender, EventArgs e)
                {
                    PS3.SetMemory(0x00173b62, new byte[] { 0x01, 0x2C });
                    RPC_MW3.iPrintlnBold(-1, "^2WallBreak Mode On");
                }

                private void button49_Click(object sender, EventArgs e)
                {
                    PS3.SetMemory(0x00173b62, new byte[] { 0x02 ,0x81});
                    RPC_MW3.iPrintlnBold(-1, "^1WallBreak Mode Off");
                }

                private void timer15_Tick(object sender, EventArgs e)
                {

                }
                #region ForceHOST Stuph
                private void lockIntDvarToValue(uint pointer, byte[] value)
                {
                    uint _flag = 0x4;                           // First value is pointer to name ( const char* ), so dvar flag is at 0x4 
                    uint _value = 0xB;                          // Default value is at 0x11

                    // Get pointer to dvar
                    byte[] buffer = new byte[4];
                    PS3.GetMemory(pointer, buffer);
                    Array.Reverse(buffer);
                    uint dvar = BitConverter.ToUInt32(buffer, 0);

                    // Get current dvar flag
                    byte[] flag = new byte[2];
                    PS3.GetMemory(dvar + _flag, flag);
                    Array.Reverse(flag);
                    ushort shortFlag = BitConverter.ToUInt16(flag, 0);

                    // Check if dvar is already write protected
                    if ((shortFlag & 0x800) != 0x800)
                    {
                        shortFlag |= 0x800;

                        flag = BitConverter.GetBytes(shortFlag);
                        Array.Reverse(flag);

                        // Apply new dvarflag
                        PS3.SetMemory(dvar + _flag, flag);
                    }

                    // Apply new value
                    PS3.SetMemory(dvar + _value, value);//FIXED THIS FOR NUMERICUPDOWN --"BaSs_HaXoR"
                }
                public byte[] myhostmin = { 0x6 };
                public byte[] myhostmax = { 0x12 };
                public byte[] myhostminDefault = { 0x6 };
                public byte[] myhostmaxDefault = { 0x12 };

                public void forceHostOn()
                {
                    lockIntDvarToValue(0x8AEE34, myhostmin);  // Lock 'party_minplayers' to 1/// 06 = off, 0x01 = 1 player
                    lockIntDvarToValue(0x8AEE40, myhostmax); // Lock 'party_maxplayers' to 18/// 12 = 18 players, but anything but equals itself
                }

                public void forceHostOff()
                {
                    lockIntDvarToValue(0x8AEE34, myhostminDefault);  // Lock 'party_minplayers' to 1/// 06 = off, 0x01 = 1 player
                    lockIntDvarToValue(0x8AEE40, myhostmaxDefault); // Lock 'party_maxplayers' to 18/// 12 = 18 players, but anything but equals itself
                }
                #endregion
                private void groupBox22_Enter(object sender, EventArgs e)
                {

                }

                private void switchButton1_ValueChanged(object sender, EventArgs e)
                {
                  
                }

                private void button50_Click(object sender, EventArgs e)
                {

                    Forcehostbool = true; 
                    forceHostOn();
                }

                private void button51_Click(object sender, EventArgs e)
                {
                    forceHostOff();
                    Forcehostbool = false; 
                }

                private void minplayer_ValueChanged(object sender, EventArgs e)
                {
                    if (minplayer.Value == 0)
                    {
                        myhostmin = new byte[] { 0x00 };
                        minlabel.Text = "0x00";
                    }
                    if (minplayer.Value == 1)
                    {
                        myhostmin = new byte[] { 0x01 };
                        minlabel.Text = "0x01";
                    }
                    if (minplayer.Value == 2)
                    {
                        myhostmin = new byte[] { 0x02 };
                        minlabel.Text = "0x02";
                    }
                    if (minplayer.Value == 3)
                    {
                        myhostmin = new byte[] { 0x03 };
                        minlabel.Text = "0x03";
                    }
                    if (minplayer.Value == 4)
                    {
                        myhostmin = new byte[] { 0x04 };
                        minlabel.Text = "0x04";
                    }
                    if (minplayer.Value == 5)
                    {
                        myhostmin = new byte[] { 0x05 };
                        minlabel.Text = "0x05";
                    }
                    if (minplayer.Value == 6)
                    {
                        myhostmin = new byte[] { 0x06 };
                        minlabel.Text = "0x06";
                    }
                    if (minplayer.Value == 7)
                    {
                        myhostmin = new byte[] { 0x07 };
                        minlabel.Text = "0x07";
                    }
                    if (minplayer.Value == 8)
                    {
                        myhostmin = new byte[] { 0x08 };
                        minlabel.Text = "0x08";
                    }
                    if (minplayer.Value == 9)
                    {
                        myhostmin = new byte[] { 0x09 };
                        minlabel.Text = "0x09";
                    }
                    if (minplayer.Value == 10)
                    {
                        myhostmin = new byte[] { 0x0A };//10
                        minlabel.Text = "0x0A";
                    }
                    if (minplayer.Value == 11)
                    {
                        myhostmin = new byte[] { 0x0B };//11
                        minlabel.Text = "0x0B";
                    }
                    if (minplayer.Value == 12)
                    {
                        myhostmin = new byte[] { 0x0C };//12
                        minlabel.Text = "0x0C";
                    }
                    if (minplayer.Value == 13)
                    {
                        myhostmin = new byte[] { 0x0D };//13
                        minlabel.Text = "0x0D";
                    }
                    if (minplayer.Value == 14)
                    {
                        myhostmin = new byte[] { 0x0E };//14
                        minlabel.Text = "0x0E";
                    }
                    if (minplayer.Value == 15)
                    {
                        myhostmin = new byte[] { 0x0F };//15
                        minlabel.Text = "0x0F";
                    }
                    if (minplayer.Value == 16)
                    {
                        myhostmin = new byte[] { 0x11 };//16 minPLAYERS?
                        minlabel.Text = "0x11";
                    }
                    if (minplayer.Value == 17)
                    {
                        myhostmin = new byte[] { 0x12 };//17
                        minlabel.Text = "0x12";
                    }
                    if (minplayer.Value == 18)
                    {
                        myhostmin = new byte[] { 0x13 };//18
                        minlabel.Text = "0x13";
                    }
                }

                private void maxplayer_ValueChanged(object sender, EventArgs e)
                {
                    if (maxplayer.Value == 0)
                    {
                        myhostmax = new byte[] { 0x00 };
                        maxlabel.Text = "0x00";
                    }
                    if (maxplayer.Value == 1)
                    {
                        myhostmax = new byte[] { 0x01 };
                        maxlabel.Text = "0x01";
                    }
                    if (maxplayer.Value == 2)
                    {
                        myhostmax = new byte[] { 0x02 };
                        maxlabel.Text = "0x02";
                    }
                    if (maxplayer.Value == 3)
                    {
                        myhostmax = new byte[] { 0x03 };
                        maxlabel.Text = "0x03";
                    }
                    if (maxplayer.Value == 4)
                    {
                        myhostmax = new byte[] { 0x04 };
                        maxlabel.Text = "0x04";
                    }
                    if (maxplayer.Value == 5)
                    {
                        myhostmax = new byte[] { 0x05 };
                        maxlabel.Text = "0x05";
                    }
                    if (maxplayer.Value == 6)
                    {
                        myhostmax = new byte[] { 0x06 };
                        maxlabel.Text = "0x06";
                    }
                    if (maxplayer.Value == 7)
                    {
                        myhostmax = new byte[] { 0x07 };
                        maxlabel.Text = "0x07";
                    }
                    if (maxplayer.Value == 8)
                    {
                        myhostmax = new byte[] { 0x08 };
                        maxlabel.Text = "0x08";
                    }
                    if (maxplayer.Value == 9)
                    {
                        myhostmax = new byte[] { 0x09 };
                        maxlabel.Text = "0x09";
                    }
                    if (maxplayer.Value == 10)
                    {
                        myhostmax = new byte[] { 0x0A };//10
                        maxlabel.Text = "0x0A";
                    }
                    if (maxplayer.Value == 11)
                    {
                        myhostmax = new byte[] { 0x0B };//11
                        maxlabel.Text = "0x0B";
                    }
                    if (maxplayer.Value == 12)
                    {
                        myhostmax = new byte[] { 0x0C };//12
                        maxlabel.Text = "0x0C";
                    }
                    if (maxplayer.Value == 13)
                    {
                        myhostmax = new byte[] { 0x0D };//13
                        maxlabel.Text = "0x0D";
                    }
                    if (maxplayer.Value == 14)
                    {
                        myhostmax = new byte[] { 0x0E };//14
                        maxlabel.Text = "0x0E";
                    }
                    if (maxplayer.Value == 15)
                    {
                        myhostmax = new byte[] { 0x0F };//15
                        maxlabel.Text = "0x0F";
                    }
                    if (maxplayer.Value == 16)
                    {
                        myhostmax = new byte[] { 0x11 };//16 MAXPLAYERS?
                        maxlabel.Text = "0x11";
                    }
                    if (maxplayer.Value == 17)
                    {
                        myhostmax = new byte[] { 0x12 };//17
                        maxlabel.Text = "0x12";
                    }
                    if (maxplayer.Value == 18)
                    {
                        myhostmax = new byte[] { 0x13 };//18
                        maxlabel.Text = "0x13";
                    }
                }
                private bool Forcehostbool = false;
                private void ForcehostBGW_DoWork(object sender, DoWorkEventArgs e)
                {
                    while (true)
                    {
                        if (Forcehostbool == true)
                        {
                            forceHostOn();
                        }
                        else
                        {
                            //DO NOTHING
                        }
                    }
                }

                private void numericUpDown8_ValueChanged(object sender, EventArgs e)
                {

                }

                private void button52_Click(object sender, EventArgs e)
                {

                }

                private void numericUpDown9_ValueChanged(object sender, EventArgs e)
                {

                }

                private void button53_Click(object sender, EventArgs e)
                {
                  
                }

                private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
                {

                }

                private void button54_Click(object sender, EventArgs e)
                {
                   
                }

                private void numericUpDown10_ValueChanged(object sender, EventArgs e)
                {

                }

                private void textBox10_TextChanged(object sender, EventArgs e)
                {

                }

                private void button55_Click(object sender, EventArgs e)
                {
                    byte[] NAME = Encoding.ASCII.GetBytes( textBox10.Text);
                    Array.Resize(ref NAME, NAME.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, NAME);
                }

                private void timer16_Tick(object sender, EventArgs e)
                {
                    byte[] NAME = Encoding.ASCII.GetBytes("^1" + textBox11.Text);
                    Array.Resize(ref NAME, NAME.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, NAME);

                    System.Threading.Thread.Sleep(50);

                    byte[] NAME1 = Encoding.ASCII.GetBytes("^2" + textBox11.Text);
                    Array.Resize(ref NAME1, NAME1.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, NAME1);

                    System.Threading.Thread.Sleep(50);

                    byte[] NAME3 = Encoding.ASCII.GetBytes("^3" + textBox11.Text);
                    Array.Resize(ref NAME3, NAME3.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, NAME3);

                    System.Threading.Thread.Sleep(50);

                    byte[] NAME4 = Encoding.ASCII.GetBytes("^4" + textBox11.Text);
                    Array.Resize(ref NAME4, NAME4.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, NAME4);

                    System.Threading.Thread.Sleep(50);



                    byte[] NAME5 = Encoding.ASCII.GetBytes("^5" + textBox11.Text);
                    Array.Resize(ref NAME5, NAME5.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, NAME5);

                    System.Threading.Thread.Sleep(50);


                    byte[] NAME6 = Encoding.ASCII.GetBytes("^6" + textBox11.Text);
                    Array.Resize(ref NAME6, NAME6.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, NAME6);
                }

                private void button56_Click(object sender, EventArgs e)
                {
                    timer16.Start();
                }

                private void button57_Click(object sender, EventArgs e)
                {
                    timer16.Stop();
                }

                private void textBox11_TextChanged(object sender, EventArgs e)
                {

                }

                private void button59_Click(object sender, EventArgs e)
                {
                    timer17.Start();
                }

                private void button58_Click(object sender, EventArgs e)
                {
                    timer17.Stop();
                    timer18.Stop();
                    timer19.Stop();
                    timer20.Stop();
                    timer21.Stop();
                    timer22.Stop();
                    timer23.Stop();
                    timer24.Stop();
                    timer25.Stop();
                    timer26.Stop();
                    timer27.Stop();
                    timer28.Stop();
                    timer29.Stop();
                    timer30.Stop();
                   
                }

                private void timer17_Tick(object sender, EventArgs e)
                {
                    byte[] name3 = Encoding.ASCII.GetBytes("\n" + textBox25.Text);
                    Array.Resize(ref name3, name3.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, name3);
                    timer17.Enabled = false;
                    timer18.Enabled = true;
                }

                private void timer18_Tick(object sender, EventArgs e)
                {
                    byte[] name4 = Encoding.ASCII.GetBytes("\n\n" + textBox25.Text);
                    Array.Resize(ref name4, name4.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, name4);
                    timer18.Enabled = false;
                    timer19.Enabled = true;
                }

                private void timer19_Tick(object sender, EventArgs e)
                {
                    byte[] name5 = Encoding.ASCII.GetBytes("\n\n\n" + textBox25.Text);
                    Array.Resize(ref name5, name5.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, name5);
                    timer19.Enabled = false;
                    timer20.Enabled = true;
                }

                private void timer20_Tick(object sender, EventArgs e)
                {
                    byte[] name6 = Encoding.ASCII.GetBytes("\n\n\n\n" + textBox25.Text);
                    Array.Resize(ref name6, name6.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, name6);
                    timer20.Enabled = false;
                    timer21.Enabled = true;
                }

                private void timer21_Tick(object sender, EventArgs e)
                {
                    byte[] name7 = Encoding.ASCII.GetBytes("\n\n\n\n\n" + textBox25.Text);
                    Array.Resize(ref name7, name7.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, name7);
                    timer21.Enabled = false;
                    timer22.Enabled = true;
                }

                private void timer22_Tick(object sender, EventArgs e)
                {
                    byte[] name8 = Encoding.ASCII.GetBytes("\n\n\n\n\n\n" + textBox25.Text);
                    Array.Resize(ref name8, name8.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, name8);
                    timer22.Enabled = false;
                    timer23.Enabled = true;
                }

                private void timer23_Tick(object sender, EventArgs e)
                {
                    byte[] name9 = Encoding.ASCII.GetBytes("\n\n\n\n\n\n\n" + textBox25.Text);
                    Array.Resize(ref name9, name9.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, name9);
                    timer23.Enabled = false;
                    timer24.Enabled = true;
                }

                private void timer24_Tick(object sender, EventArgs e)
                {
                    byte[] name10 = Encoding.ASCII.GetBytes("\n\n\n\n\n\n\n\n" + textBox25.Text);
                    Array.Resize(ref name10, name10.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, name10);
                    timer24.Enabled = false;
                    timer25.Enabled = true;
                }

                private void timer25_Tick(object sender, EventArgs e)
                {
                    byte[] name11 = Encoding.ASCII.GetBytes("\n\n\n\n\n\n\n\n\n" + textBox25.Text);
                    Array.Resize(ref name11, name11.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, name11);
                    timer25.Enabled = false;
                    timer26.Enabled = true;
                }

                private void timer26_Tick(object sender, EventArgs e)
                {
                    byte[] name12 = Encoding.ASCII.GetBytes("\n\n\n\n\n\n\n\n\n\n" + textBox25.Text);
                    Array.Resize(ref name12, name12.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, name12);
                    timer26.Enabled = false;
                    timer27.Enabled = true;
                }

                private void timer27_Tick(object sender, EventArgs e)
                {
                    byte[] name13 = Encoding.ASCII.GetBytes("\n\n\n\n\n\n\n\n\n\n\n" + textBox25.Text);
                    Array.Resize(ref name13, name13.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, name13);
                    timer27.Enabled = false;
                    timer28.Enabled = true;
                }

                private void timer28_Tick(object sender, EventArgs e)
                {
                    byte[] name14 = Encoding.ASCII.GetBytes("\n\n\n\n\n\n\n\n\n\n\n\n" + textBox25.Text);
                    Array.Resize(ref name14, name14.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, name14);
                    timer28.Enabled = false;
                    timer29.Enabled = true;
                }

                private void timer29_Tick(object sender, EventArgs e)
                {
                    byte[] name15 = Encoding.ASCII.GetBytes("\n\n\n\n\n\n\n\n\n\n\n\n\n" + textBox25.Text);
                    Array.Resize(ref name15, name15.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, name15);
                    timer29.Enabled = false;
                    timer30.Enabled = true;
                }

                private void timer30_Tick(object sender, EventArgs e)
                {
                    byte[] name16 = Encoding.ASCII.GetBytes("\n\n\n\n\n\n\n\n\n\n\n\n\n\n" + textBox25.Text);
                    Array.Resize(ref name16, name16.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, name16);
                    timer30.Enabled = false;
                    timer17.Enabled = true;
                }

                private void timer31_Tick(object sender, EventArgs e)
                {

                }

                private void textBox13_TextChanged(object sender, EventArgs e)
                {

                }

                private void textBox14_TextChanged(object sender, EventArgs e)
                {

                }

                private void button60_Click(object sender, EventArgs e)
                {
                    {

                        if (this.textBox13.Text.Length >= 1)
                        {
                            this.textBox13.Text = this.textBox13.Text.Substring(0, 1).ToUpper() + this.textBox13.Text.Substring(1);
                        }
                        else
                        {
                            if (this.textBox14.Text.Length >= 1)
                            {
                                this.textBox14.Text = this.textBox14.Text.Substring(0, 1).ToUpper() + this.textBox14.Text.Substring(1);
                            }
                        }
                        byte[] bytes1 = Encoding.ASCII.GetBytes("^4" + this.textBox13.Text + "\r^2" + this.textBox14.Text);
                        Array.Resize<byte>(ref bytes1, bytes1.Length + 1);
                        PS3.SetMemory(0x01BBBC2C, bytes1);
                    }
                    timer31.Start();
                }

                private void button61_Click(object sender, EventArgs e)
                {
                    {

                        if (this.textBox13.Text.Length >= 1)
                        {
                            this.textBox13.Text = this.textBox13.Text.Substring(0, 1).ToUpper() + this.textBox13.Text.Substring(1);
                        }
                        else
                        {
                            if (this.textBox14.Text.Length >= 1)
                            {
                                this.textBox14.Text = this.textBox14.Text.Substring(0, 1).ToUpper() + this.textBox14.Text.Substring(1);
                            }
                        }
                        byte[] bytes1 = Encoding.ASCII.GetBytes("^4" + this.textBox13.Text + "\r ^3" + this.textBox14.Text);
                        Array.Resize<byte>(ref bytes1, bytes1.Length + 1);
                        PS3.SetMemory(0x01BBBC2C, bytes1);
                    }
                    timer31.Stop();
                }

                private void timer31_Tick_1(object sender, EventArgs e)
                {
                   
                    {

                        if (this.textBox13.Text.Length >= 1)
                        {
                            this.textBox13.Text = this.textBox13.Text.Substring(0, 1).ToUpper() + this.textBox13.Text.Substring(1);
                        }
                        else
                        {
                            if (this.textBox14.Text.Length >= 1)
                            {
                                this.textBox14.Text = this.textBox14.Text.Substring(0, 1).ToUpper() + this.textBox14.Text.Substring(1);
                            }
                        }
                        byte[] bytes1 = Encoding.ASCII.GetBytes("^1" + this.textBox13.Text + "\r ^2" + this.textBox14.Text);
                        Array.Resize<byte>(ref bytes1, bytes1.Length + 1);
                        PS3.SetMemory(0x01BBBC2C, bytes1);
                    }

                    System.Threading.Thread.Sleep(10);

                    if (this.textBox13.Text.Length >= 1)
                    {
                        this.textBox13.Text = this.textBox13.Text.Substring(0, 1).ToUpper() + this.textBox13.Text.Substring(1);
                    }
                    else
                    {
                        if (this.textBox14.Text.Length >= 1)
                        {
                            this.textBox14.Text = this.textBox14.Text.Substring(0, 1).ToUpper() + this.textBox14.Text.Substring(1);
                        }
                    }
                    byte[] bytes = Encoding.ASCII.GetBytes("^2" + this.textBox13.Text + "\r ^3" + "  " + this.textBox14.Text);
                    Array.Resize<byte>(ref bytes, bytes.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, bytes);

                    System.Threading.Thread.Sleep(10);

                    if (this.textBox13.Text.Length >= 1)
                    {
                        this.textBox13.Text = this.textBox13.Text.Substring(0, 1).ToUpper() + this.textBox13.Text.Substring(1);
                    }
                    else
                    {
                        if (this.textBox14.Text.Length >= 1)
                        {
                            this.textBox14.Text = this.textBox14.Text.Substring(0, 1).ToUpper() + this.textBox14.Text.Substring(1);
                        }
                    }
                    byte[] bytes2 = Encoding.ASCII.GetBytes("^4" + this.textBox13.Text + "\r ^5" + "  " + this.textBox14.Text);
                    Array.Resize<byte>(ref bytes2, bytes2.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, bytes2);

                    System.Threading.Thread.Sleep(10);

                    if (this.textBox13.Text.Length >= 1)
                    {
                        this.textBox13.Text = this.textBox13.Text.Substring(0, 1).ToUpper() + this.textBox13.Text.Substring(1);
                    }
                    else
                    {
                        if (this.textBox14.Text.Length >= 1)
                        {
                            this.textBox14.Text = this.textBox14.Text.Substring(0, 1).ToUpper() + this.textBox14.Text.Substring(1);
                        }
                    }
                    byte[] bytes3 = Encoding.ASCII.GetBytes("^6" + this.textBox13.Text + "\r ^4" + "  " + this.textBox14.Text);
                    Array.Resize<byte>(ref bytes3, bytes3.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, bytes3);

                    System.Threading.Thread.Sleep(10);


                    {
                        if (this.textBox13.Text.Length >= 1)
                        {
                            this.textBox13.Text = this.textBox13.Text.Substring(0, 1).ToUpper() + this.textBox13.Text.Substring(1);
                        }
                        else
                        {
                            if (this.textBox14.Text.Length >= 1)
                            {
                                this.textBox14.Text = this.textBox14.Text.Substring(0, 1).ToUpper() + this.textBox14.Text.Substring(1);
                            }
                        }
                        byte[] bytes4 = Encoding.ASCII.GetBytes("^5" + this.textBox13.Text + "\r ^6" + "  " + this.textBox14.Text);
                        Array.Resize<byte>(ref bytes4, bytes4.Length + 1);
                        PS3.SetMemory(0x01BBBC2C, bytes4);

                        System.Threading.Thread.Sleep(10);
                    }
                }

                private void textBox12_TextChanged(object sender, EventArgs e)
                {
                    timer32.Start();
                }

                private void timer32_Tick(object sender, EventArgs e)
                {
                    byte[] NAME = Encoding.ASCII.GetBytes(textBox12.Text);
                    Array.Resize(ref NAME, NAME.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, NAME);
                    timer32.Stop();
                }

                private void textBox15_TextChanged(object sender, EventArgs e)
                {
                    byte[] NAME = Encoding.ASCII.GetBytes("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" + textBox15.Text + "\n\n\n\n");
                    PS3.SetMemory(0x01BBBC2C, NAME);
                    System.Threading.Thread.Sleep(0);
                    timer33.Start();
                }

                private void timer33_Tick(object sender, EventArgs e)
                {
                    byte[] NAME = new byte[] { 10, 16, 17, 10, 17, 16, 10, 16, 17, 10, 17, 16, 10, 16, 17, 10 };
                    PS3.SetMemory(0x01BBBC2C, NAME);
                    System.Threading.Thread.Sleep(1);
                    timer33.Stop();
                }

                private void button63_Click(object sender, EventArgs e)
                {
                    timer34.Start();
                }

                private void button62_Click(object sender, EventArgs e)
                {
                    timer34.Stop();
                }

                private void textBox16_TextChanged(object sender, EventArgs e)
                {

                }

                private void timer34_Tick(object sender, EventArgs e)
                {





                    byte[] buffer1 = Encoding.ASCII.GetBytes(" " + "^1" + textBox16.Text + "");
                    Array.Resize(ref buffer1, buffer1.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, buffer1);
                    System.Threading.Thread.Sleep(10);


                    byte[] buffer2 = Encoding.ASCII.GetBytes("" + "^2" + textBox16.Text + "");
                    Array.Resize(ref buffer2, buffer2.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, buffer2);
                    System.Threading.Thread.Sleep(10);


                    byte[] buffer3 = Encoding.ASCII.GetBytes("" + "^3" + textBox16.Text + "");
                    Array.Resize(ref buffer3, buffer3.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, buffer3);
                    System.Threading.Thread.Sleep(10);


                    byte[] buffer4 = Encoding.ASCII.GetBytes("" + "^4" + textBox16.Text + "");
                    Array.Resize(ref buffer4, buffer4.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, buffer4);
                    System.Threading.Thread.Sleep(10);


                    byte[] buffer5 = Encoding.ASCII.GetBytes("" + "^5" + textBox16.Text + "");
                    Array.Resize(ref buffer5, buffer5.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, buffer5);
                    System.Threading.Thread.Sleep(10);


                    byte[] buffer6 = Encoding.ASCII.GetBytes("" + "^6" + textBox16.Text + "");
                    Array.Resize(ref buffer6, buffer6.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, buffer6);
                    System.Threading.Thread.Sleep(10);



                    byte[] buffer7 = Encoding.ASCII.GetBytes("" + "^7" + textBox16.Text + "");
                    Array.Resize(ref buffer7, buffer7.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, buffer7);
                    System.Threading.Thread.Sleep(10);
                }

                private void button64_Click(object sender, EventArgs e)
                {
                    textBox18.Text = textBox17.Text;
                    byte[] name9 = Encoding.ASCII.GetBytes(" "+textBox17.Text + "\n\n\n\n" +textBox18.Text + " " + "Was Here");
                    Array.Resize(ref name9, name9.Length + 1);
                    PS3.SetMemory(0x01BBBC2C, name9);
                    System.Threading.Thread.Sleep(0);
                }

                private void textBox17_TextChanged(object sender, EventArgs e)
                {

                }

                private void button65_Click(object sender, EventArgs e)
                {
                    timer35.Start();
                }

                private void button66_Click(object sender, EventArgs e)
                {
                    timer35.Stop();
                }

                private void timer35_Tick(object sender, EventArgs e)
                {
                    byte[] BIG = new byte[] { 0X5E, 0X32, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, };
                    PS3.SetMemory(0X01bbbc2c, BIG);
                    System.Threading.Thread.Sleep(20);
                    byte[] BIG1 = new byte[] { 0X5E, 0X32, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, };
                    PS3.SetMemory(0X01bbbc2c, BIG1);
                    System.Threading.Thread.Sleep(20);
                    byte[] BIG2 = new byte[] { 0X5E, 0X36, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, };
                    PS3.SetMemory(0X01bbbc2c, BIG2);
                    System.Threading.Thread.Sleep(20);
                    byte[] BIG3 = new byte[] { 0X5E, 0X36, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, };
                    PS3.SetMemory(0X01bbbc2c, BIG3);
                    System.Threading.Thread.Sleep(20);
                    byte[] BIG4 = new byte[] { 0X5E, 0X30, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, };
                    PS3.SetMemory(0X01bbbc2c, BIG4);
                    System.Threading.Thread.Sleep(20);
                }

                private void checkBox15_CheckedChanged(object sender, EventArgs e)
                {
                    {
                        if (this.checkBox15.Checked)
                        {

                            PS3.SetMemory(0x00892C13, new byte[] { 0x01 });

                        }
                        if (!this.checkBox15.Checked)
                        {
                            PS3.SetMemory(0x00892C13, new byte[] { 0x00 });
                        }
                    }
                }

                private void button67_Click(object sender, EventArgs e)
                {
                    byte[] NAME = Encoding.ASCII.GetBytes(textBox19.Text);
                    Array.Resize(ref NAME, NAME.Length + 1);
                    PS3.SetMemory(0x00892C34, NAME);
                }

                private void textBox19_TextChanged(object sender, EventArgs e)
                {

                }

                private void checkBox16_CheckedChanged(object sender, EventArgs e)
                {
                   
                }

                private void textBox20_TextChanged(object sender, EventArgs e)
                {

                }

                private void button68_Click(object sender, EventArgs e)
                {
         
                }

                private void button69_Click(object sender, EventArgs e)
                {
                  
                    byte[] name = new byte[] { 0x01, };
                    PS3.SetMemory(0X01bbbc2b, name);
                }

                private void tabPage8_Click(object sender, EventArgs e)
                {

                }

                private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
                {

                }
                private void Wait(double time)
                {
                    System.Threading.Thread.Sleep(20);
                }
                private void button70_Click(object sender, EventArgs e)
                {
                    if (comboBox12.SelectedItem == "Red")
                    {
                        byte[] NAME1 = new byte[] { 0x5E, 0x31, 0x5E, 0x02, 0x7F, 0x7F, 0x13 };
                        PS3.SetMemory(0x001bbbc2c, NAME1);


                    }

                    if (comboBox12.SelectedItem == "Green")
                    {
                        byte[] NAME1 = new byte[] { 0x5E, 0x32, 0x5E, 0x02, 0x7F, 0x7F, 0x13 };
                        PS3.SetMemory(0x001bbbc2c, NAME1);


                    }


                    if (comboBox12.SelectedItem == "Tan")
                    {
                        byte[] NAME1 = new byte[] { 0x5E, 0x33, 0x5E, 0x02, 0x7F, 0x7F, 0x13 };
                        PS3.SetMemory(0x001bbbc2c, NAME1);

                    }
                    if (comboBox12.SelectedItem == "Blue")
                    {
                        byte[] NAME1 = new byte[] { 0x5E, 0x34, 0x5E, 0x02, 0x7F, 0x7F, 0x13 };
                        PS3.SetMemory(0x001bbbc2c, NAME1);


                    }

                    if (comboBox12.SelectedItem == "Cyan")
                    {
                        byte[] NAME1 = new byte[] { 0x5E, 0x35, 0x5E, 0x02, 0x7F, 0x7F, 0x13 };
                        PS3.SetMemory(0x001bbbc2c, NAME1);


                    }


                    if (comboBox12.SelectedItem == "Purple")
                    {
                        byte[] NAME1 = new byte[] { 0x5E, 0x36, 0x5E, 0x02, 0x7F, 0x7F, 0x13 };
                        PS3.SetMemory(0x001bbbc2c, NAME1);

                    }

                    if (comboBox12.SelectedItem == "Black")
                    {
                        byte[] NAME1 = new byte[] { 0x5E, 0x30, 0x5E, 0x02, 0x7F, 0x7F, 0x13 };
                        PS3.SetMemory(0x001bbbc2c, NAME1);

                    }
                }

                private void checkBox16_CheckedChanged_1(object sender, EventArgs e)
                {
                   
                }

                private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
                {

                }

                private void button72_Click(object sender, EventArgs e)
                {
                    timer36.Start();
                }

                private void button71_Click(object sender, EventArgs e)
                {
                    timer36.Stop();
                }

                private void timer36_Tick(object sender, EventArgs e)
                {
                    PS3.SetMemory(0x01C1947C, new byte[] {0x00});
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x01 });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x02 });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x03 });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x04 });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x05 });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x06 });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x07 });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x08 });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x09 });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x0A });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x0B });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x0C });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x0D });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x0E });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x0F });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x10 });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x11 });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x12 });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x13 });
                    Wait(1);
                    PS3.SetMemory(0x01C1947C, new byte[] { 0x14 });
                    Wait(1);
                }

                private void button74_Click(object sender, EventArgs e)
                {
                
                }

                private void button73_Click(object sender, EventArgs e)
                {
                 
                }

                private void timer37_Tick(object sender, EventArgs e)
                {
                   
                }

                private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
                {

                }

                private void button73_Click_1(object sender, EventArgs e)
                {
                    if (comboBox13.SelectedItem == "Red")
                    {
                        byte[] NAME1 = new byte[] { 0x5E, 0x31, 0x5E, 0x02, 0x31, 0x31, 0x13 };
                        PS3.SetMemory(0x001bbbc2c, NAME1);


                    }

                    if (comboBox13.SelectedItem == "Green")
                    {
                        byte[] NAME1 = new byte[] { 0x5E, 0x32, 0x5E, 0x02, 0x31, 0x31, 0x13 };
                        PS3.SetMemory(0x001bbbc2c, NAME1);


                    }


                    if (comboBox13.SelectedItem == "Tan")
                    {
                        byte[] NAME1 = new byte[] { 0x5E, 0x33, 0x5E, 0x02, 0x31, 0x31, 0x13 };
                        PS3.SetMemory(0x001bbbc2c, NAME1);

                    }
                    if (comboBox13.SelectedItem == "Blue")
                    {
                        byte[] NAME1 = new byte[] { 0x5E, 0x34, 0x5E, 0x02, 0x31, 0x31, 0x13 };
                        PS3.SetMemory(0x001bbbc2c, NAME1);


                    }

                    if (comboBox13.SelectedItem == "Cyan")
                    {
                        byte[] NAME1 = new byte[] { 0x5E, 0x35, 0x5E, 0x02, 0x31, 0x31, 0x13 };
                        PS3.SetMemory(0x001bbbc2c, NAME1);


                    }


                    if (comboBox13.SelectedItem == "Purple")
                    {
                        byte[] NAME1 = new byte[] { 0x5E, 0x36, 0x5E, 0x02, 0x31, 0x31, 0x13 };
                        PS3.SetMemory(0x001bbbc2c, NAME1);

                    }

                    if (comboBox13.SelectedItem == "Black")
                    {
                        byte[] NAME1 = new byte[] { 0x5E, 0x30, 0x5E, 0x02, 0x31, 0x31, 0x13 };
                        PS3.SetMemory(0x001bbbc2c, NAME1);

                    }
                }

                private void button74_Click_1(object sender, EventArgs e)
                {

                }

                private void numericUpDown11_ValueChanged(object sender, EventArgs e)
                {

                }

                private void numericUpDown12_ValueChanged(object sender, EventArgs e)
                {

                }

                private void numericUpDown13_ValueChanged(object sender, EventArgs e)
                {

                }

                private void numericUpDown18_ValueChanged(object sender, EventArgs e)
                {

                }

                private void checkBox16_CheckedChanged_2(object sender, EventArgs e)
                {

                }

                private void checkBox18_CheckedChanged(object sender, EventArgs e)
                {

                }

                private void checkBox23_CheckedChanged(object sender, EventArgs e)
                {

                }

                private void button74_Click_2(object sender, EventArgs e)
                {
                    if (this.checkBox16.CheckState == CheckState.Checked) 
                    {
                        byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown11.Value.ToString()));
                        PS3.SetMemory(0x01C1947C, buffer);
                    }
                    if (this.checkBox17.CheckState == CheckState.Checked)
                    {
                        byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown12.Value.ToString()));
                        PS3.SetMemory(0x01C1926C, buffer);
                    }
                    if (this.checkBox18.CheckState == CheckState.Checked)
                    {
                        byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown13.Value.ToString()));
                        PS3.SetMemory(0x01C19484, buffer);
                    }
                    if (this.checkBox19.CheckState == CheckState.Checked)
                    {
                        byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown14.Value.ToString()));
                        PS3.SetMemory(0x01C194AC, buffer);
                    }
                    if (this.checkBox20.CheckState == CheckState.Checked)
                    {
                        byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown15.Value.ToString()));
                        PS3.SetMemory(0x01C194B4, buffer);
                    }
                    if (this.checkBox21.CheckState == CheckState.Checked)
                    {
                        byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown16.Value.ToString()));
                        PS3.SetMemory(0x01C194BC, buffer);
                    }
                    if (this.checkBox22.CheckState == CheckState.Checked)
                    {
                        byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown17.Value.ToString()));
                        PS3.SetMemory(0x01C194C0, buffer);
                    }
                    if (this.checkBox23.CheckState == CheckState.Checked)
                    {
                        byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown18.Value.ToString()));
                        PS3.SetMemory(0x01C194E0, buffer);
                         }
                    
                         if (this.checkBox24.CheckState == CheckState.Checked)
                    {
                        byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown19.Value.ToString()));
                        PS3.SetMemory(0x01C194E4, buffer);
                    }
                         if (this.checkBox25.CheckState == CheckState.Checked)
                         {
                             byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown20.Value.ToString()));
                             PS3.SetMemory(0x01C194E8, buffer);
                         }
                         if (this.checkBox26.CheckState == CheckState.Checked)
                         {
                             byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown21.Value.ToString()));
                             PS3.SetMemory(0x01C194EC, buffer);
                         }
                         if (this.checkBox27.CheckState == CheckState.Checked)
                         {
                             byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown22.Value.ToString()));
                             PS3.SetMemory(0x01C194B0, buffer);
                         }
                         if (this.checkBox28.CheckState == CheckState.Checked)
                         {
                             byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown23.Value.ToString()));
                             PS3.SetMemory(0x01C1B2DB, buffer);
                         }
                         if (this.checkBox31.CheckState == CheckState.Checked)
                         {
                             byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown28.Value.ToString()));
                             PS3.SetMemory(0x01C194F8, buffer);
                         }
                         if (this.checkBox32.CheckState == CheckState.Checked)
                         {
                             byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown29.Value.ToString()));
                             PS3.SetMemory(0x01C194FC, buffer);
                         }
                         if (this.checkBox33.CheckState == CheckState.Checked)
                         {
                             byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown30.Value.ToString()));
                             PS3.SetMemory(0x01C1B376, buffer);
                         }
                         if (this.checkBox34.CheckState == CheckState.Checked)
                         {
                             byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown31.Value.ToString()));
                             PS3.SetMemory(0x01C1B37B, buffer);
                         }
                         if (this.checkBox35.CheckState == CheckState.Checked)
                         {
                             byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown32.Value.ToString()));
                             PS3.SetMemory(0x01C1B381, buffer);
                         }
                         if (this.checkBox36.CheckState == CheckState.Checked)
                         {
                             byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown33.Value.ToString()));
                             PS3.SetMemory(0x01C1B388, buffer);
                         }
                         if (this.checkBox36.CheckState == CheckState.Checked) // Time Played
                         {
                             int Minutes = (int)minutes.Value * 60;
                             int Hours = (int)hours.Value * 60 * 60;
                             int Days = (int)days.Value * 24 * 60 * 60;
                             int playtime = Minutes + Hours + Days;
                             byte[] time = BitConverter.GetBytes(playtime);
                             PS3.SetMemory(0x01C194CE, time);
                         }
                }

                private void numericUpDown28_ValueChanged(object sender, EventArgs e)
                {

                }

                private void checkBox31_CheckedChanged(object sender, EventArgs e)
                {

                }

                private void checkBox32_CheckedChanged(object sender, EventArgs e)
                {

                }

                private void numericUpDown29_ValueChanged(object sender, EventArgs e)
                {

                }

                private void numericUpDown30_ValueChanged(object sender, EventArgs e)
                {

                }

                private void checkBox29_CheckedChanged(object sender, EventArgs e)
                {
                     
                    {
                        if (this.checkBox29.Checked)
                        {

       byte[] buffer = new byte[] { 
                                0xbc, 0x24, 0xb8, 30, 0xa5, 0x1f, 0xb8, 30, 0xc1, 30, 0xb8, 30, 0xf8, 30, 0xb8, 30, 
                                0xcd, 30, 0xb8, 30, 200, 30, 0xb8, 30, 0xbb, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb9, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0x26, 0x21, 0xb8, 30, 
                                0x29, 0x1f, 0xb8, 30, 0xbb, 30, 0xb8, 30, 0xda, 30, 0xb8, 30, 0xc7, 30, 0xb8, 30, 
                                0xe2, 30, 0xb8, 30, 0xbb, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb9, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0x24, 0x2d, 0xb8, 30, 6, 0x21, 0xb8, 30, 0xc9, 30, 0xb8, 30, 0x55, 0x1f, 0xb8, 30, 
                                0xf5, 30, 0xb8, 30, 0xa1, 0x22, 0xb8, 30, 0x60, 0x1f, 0xb8, 30, 0xc0, 30, 0xb8, 30, 
                                230, 30, 0xb8, 30, 0xca, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xbb, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xbb, 30, 0xb8, 30, 0xbc, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xa2, 0x2b, 0xb8, 30, 0x91, 0x20, 0xb8, 30, 0xc6, 30, 0xb8, 30, 0x2f, 0x1f, 0xb8, 30, 
                                0xed, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0x18, 0xa5, 0x1a, 0, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 9, 0xb8, 9, 
                                9, 9, 9, 30, 0xb8, 30, 30, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                30, 30, 30, 9, 9, 30, 9, 30, 0xb8, 30, 30, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 30, 30, 0xb8, 30, 0xb8, 30, 9, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 9, 9, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 9, 30, 
                                0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 9, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xb8, 30, 0xb8, 30, 250, 0, 0, 0, 20, 0, 0, 0, 0xb8, 30, 0xb8, 30, 
                                0x44, 0x8d, 0, 6, 0xe4, 0xcf, 0, 0, 0xc0, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xd4, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 0xb8, 30, 
                                0xcc, 30, 0xb8, 30, 0xbb, 30, 0xb8, 30, 0x2a, 0xa8, 0x5b, 0, 0x5e, 1, 0, 0, 
                                0xb0, 0x4b, 15, 0, 0, 0, 0, 0, 0x88, 0x9f, 0, 0, 140, 0x3b, 1, 0, 
                                0, 0, 0, 0, 2, 0, 0, 0, 0x3d, 0xdf, 0x83, 0, 40, 15, 0, 0, 
                                0, 0xd6, 0x83, 0, 0x65, 0x18, 0, 0, 0xab, 6, 0, 0, 0x60, 0x97, 0, 0, 
                                0x68, 0x38, 0, 0, 0x1c, 0, 0, 0, 0xf8, 1, 0, 0, 5, 0, 0, 0, 
                                0x7b, 10, 0, 0, 0xa6, 30, 0, 0, 0x98, 0xf9, 0xff, 0xff, 0x3e, 0x18, 0, 0, 
                                0x10, 0x27, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x9b, 0x69, 0x4a, 0x53, 
                                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                                10, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                                0, 0x56, 3, 0x56, 3, 0x56, 3, 0x56, 3, 0x56, 3, 0x56, 3, 0x56, 3, 0x56, 
                                3, 0x56, 3, 0x56, 3, 0x56, 3, 0x56, 3, 0x56, 3, 0x56, 3, 0x56, 3, 0x56, 
                                3, 0x56, 3, 0x56, 3, 0x56, 3, 0x56, 3, 0, 0, 0, 0, 0, 10, 0, 
                                5, 0, 0, 0, 0x17, 0, 2, 0, 0, 0, 0x21, 0, 1, 0, 0, 0, 
                                3, 0, 6, 0, 0, 0, 0x1c, 0, 12, 0
                             };
                            byte[] buffer2 = new byte[] { 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 1, 1, 1, 1, 1, 1, 10, 
                                20, 0, 0, 0, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 
                                10, 10, 10, 10, 10, 10, 10, 10
                             };
                            byte[] buffer3 = new byte[] { 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 
                                0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 1, 
                                0x88, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                                0, 0, 0, 0, 0, 0, 0, 0, 0, 0xe8, 3, 0, 0, 0, 0, 0, 
                                0, 10, 0, 0, 0, 0, 0, 0, 0, 0, 0xff
                             };
                            byte[] buffer4 = new byte[0];
                            byte[] buffer5 = new byte[] { 0xff };
                            SetMemoryref(0x1c190b4, ref buffer);
                            SetMemoryref(0x1c19ff2, ref buffer2);
                            SetMemoryref(0x1c1b0a2, ref buffer3);
                            SetMemoryref(0x1c1b2ec, ref buffer5);

                        }

                        if (!this.checkBox29.Checked)
                        {
                          
                        }
                    }
                }
                private static void SetMemoryref(uint Address, ref byte[] buffer)
                {
                    PS3.SetMemory(Address, buffer);
                }
                private void button77_Click(object sender, EventArgs e)
                {
                    byte[] godmodeclassprivite = new byte[] { 0x01, 0x27, 0x00, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x86, 0x00, 0x00, 0x00, 0x07, 0x00, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x86, 0x00, 0x00, 0x00, 0x6A, 0x00, 0x0F, 0x00, 0x11, 0x00, 0x08, 0x00, 0x00, 0x00, 0x61, 0x00, 0x83, 0x00, 0x00, 0x00, 0x73, 0x77, 0x61, 0x67, 0x2E, 0x63, 0x6C, 0x61, 0x73, 0x73, 0x00, 0x73, 0x73, 0x20, 0x32, 0x00, 0x54, 0x20, 0x31, 0x00, 0x00, 0x76, 0x00, 0x20, 0x00, 0x20, 0x00, 0x20, 0x00, 0x13, 0x00, 0x14, 0x00, 0x19, 0x00, 0x2D, 0x00, 0x26, 0x00, 0x27, 0x00, 0x02, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x06, 0x00, 0x6B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x37, };
                    PS3.SetMemory( 0x01c19dc1, godmodeclassprivite);
                }

                private void button76_Click(object sender, EventArgs e)
                {
                    byte[] godmodeclassonline = new byte[] { 0x01, 0x27, 0x00, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x86, 0x00, 0x00, 0x00, 0x07, 0x00, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x86, 0x00, 0x00, 0x00, 0x6A, 0x00, 0x0F, 0x00, 0x11, 0x00, 0x08, 0x00, 0x00, 0x00, 0x61, 0x00, 0x83, 0x00, 0x00, 0x00, 0x73, 0x77, 0x61, 0x67, 0x2E, 0x63, 0x6C, 0x61, 0x73, 0x73, 0x00, 0x73, 0x73, 0x20, 0x32, 0x00, 0x54, 0x20, 0x31, 0x00, 0x00, 0x76, 0x00, 0x20, 0x00, 0x20, 0x00, 0x20, 0x00, 0x13, 0x00, 0x14, 0x00, 0x19, 0x00, 0x2D, 0x00, 0x26, 0x00, 0x27, 0x00, 0x02, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x06, 0x00, 0x6B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x37, };
                    PS3.SetMemory( 0x01c19865, godmodeclassonline);
                }
             
                private void button75_Click(object sender, EventArgs e)
                {
                    if (this.checkBox38.CheckState == CheckState.Checked)
                    {
                        byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown34.Value.ToString()));
                        PS3.SetMemory(0x01C1B2E3, buffer);
                    }
                }

                private void textBox21_TextChanged(object sender, EventArgs e)
                {

                }

                private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
                {

                }

                private void numericUpDown34_ValueChanged(object sender, EventArgs e)
                {

                }

                private void checkBox38_CheckedChanged(object sender, EventArgs e)
                {

                }

                private void checkBox30_CheckedChanged(object sender, EventArgs e)
                {
                   
                }

                private void checkBox37_CheckedChanged(object sender, EventArgs e)
                {

                }

                private void checkBox30_CheckedChanged_1(object sender, EventArgs e)
                {
                    {
                        if (this.checkBox30.Checked)
                        {

                            checkBox16.Checked = true;
                            checkBox17.Checked = true;
                            checkBox18.Checked = true;
                            checkBox19.Checked = true;
                            checkBox20.Checked = true;
                            checkBox21.Checked = true;
                            checkBox22.Checked = true;
                            checkBox23.Checked = true;
                            checkBox24.Checked = true;
                            checkBox25.Checked = true;
                            checkBox26.Checked = true;
                            checkBox27.Checked = true;
                            checkBox28.Checked = true;
                            checkBox29.Checked = true;
                            checkBox30.Checked = true;
                            checkBox31.Checked = true;
                            checkBox32.Checked = true;
                            checkBox33.Checked = true;
                            checkBox34.Checked = true;
                            checkBox35.Checked = true;
                            checkBox36.Checked = true;
                            checkBox37.Checked = true;



                        }
                        if (!this.checkBox30.Checked)
                        {
                            checkBox16.Checked = false;
                            checkBox17.Checked = false;
                            checkBox18.Checked = false;
                            checkBox19.Checked = false;
                            checkBox20.Checked = false;
                            checkBox21.Checked = false;
                            checkBox22.Checked = false;
                            checkBox23.Checked = false;
                            checkBox24.Checked = false;
                            checkBox25.Checked = false;
                            checkBox26.Checked = false;
                            checkBox27.Checked = false;
                            checkBox28.Checked = false;
                            checkBox29.Checked = false;
                            checkBox30.Checked = false;
                            checkBox31.Checked = false;
                            checkBox32.Checked = false;
                            checkBox33.Checked = false;
                            checkBox34.Checked = false;
                            checkBox35.Checked = false;
                            checkBox36.Checked = false;
                            checkBox37.Checked = false;
                        }
                    } checkBox16.Checked = true;
                }
              
                private void button78_Click(object sender, EventArgs e)
                {
                    if (this.checkBox41.CheckState == CheckState.Checked)
                    {
                        byte[] NAME = Encoding.ASCII.GetBytes(textBox21.Text);
                        Array.Resize(ref NAME, NAME.Length + 1);
                        PS3.SetMemory(0x0110d5a0, NAME);
                    }
                    if (this.checkBox42.CheckState == CheckState.Checked)
                    {
                        byte[] NAME = Encoding.ASCII.GetBytes(textBox22.Text);
                        Array.Resize(ref NAME, NAME.Length + 1);
                        PS3.SetMemory(0x0110d59c, NAME);
                    }
                    if (this.checkBox43.CheckState == CheckState.Checked)
                    {
                        byte[] NAME = Encoding.ASCII.GetBytes(textBox23.Text);
                        Array.Resize(ref NAME, NAME.Length + 1);
                        PS3.SetMemory(0x0110d598, NAME);
                    }
                    
                }

                private void textBox21_TextChanged_1(object sender, EventArgs e)
                {

                }

                private void checkBox41_CheckedChanged(object sender, EventArgs e)
                {

                }

                private void comboBox14_SelectedIndexChanged_1(object sender, EventArgs e)
                {

                }

                private void checkBox42_CheckedChanged(object sender, EventArgs e)
                {

                }

                private void checkBox40_CheckedChanged(object sender, EventArgs e)
                {
                    if (this.checkBox40.Checked)
                    {
                        checkBox41.Checked = true;
                        checkBox42.Checked = true;
                        checkBox43.Checked = true;


                    }
                    if (!this.checkBox40.Checked)
                    {
                        checkBox41.Checked = false;
                        checkBox42.Checked = false;
                        checkBox43.Checked = false;
                    }
                }

                private void checkBox39_CheckedChanged(object sender, EventArgs e)
                {
                    if (this.checkBox39.Checked)
                    {

                        PS3.SetMemory(0x01C1B2E3, new byte[] {0x0F });


                    }
                    if (!this.checkBox39.Checked)
                    {
                  
                    }
                }
            #endregion
                
            #region NoClip
                private void tabPage1_Click(object sender, EventArgs e)
                {

                }
            
           

                private void toolStripMenuItem2_Click(object sender, EventArgs e)
                {

                }
                #region AllPerks
                public static void allPerks(Int32 client)
                {

                    PS3.SetMemory(0x110A76D + (0x3980 * (UInt32)client), new byte[] { 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF });
                }
                #endregion
                private void NoClip_Tick(object sender, EventArgs e)
                {
                    AdvancedNoClip((int)comboBox8.SelectedIndex);

                    if (Aimbot_and_ForgeMode.ReadInt(0xFCA41D + ((uint)comboBox8.SelectedIndex * 0x280)) == 0)
                    {
                        System.Threading.Thread.Sleep(1500);
                        allPerks((int)comboBox8.SelectedIndex);
                       
                    }
                }

                private void comboBox14_SelectedIndexChanged_2(object sender, EventArgs e)
                {

                }

                private void button81_Click(object sender, EventArgs e)
                {
                    
                }

                private void button80_Click(object sender, EventArgs e)
                {
                    Aimbot.Stop();
                    Forge.Stop();
                    button80.Visible = false;
                    button79.Visible = true;
                    NoClip.Start();
                    RPC_MW3.iPrintln((int)comboBox8.SelectedIndex, "Advanced NoClip ^2ON");
                    System.Threading.Thread.Sleep(1500);
                    RPC_MW3.iPrintln((int)comboBox8.SelectedIndex, " Press And Hold [{+gostand}] To Go Up");
                    System.Threading.Thread.Sleep(1500);
                    RPC_MW3.iPrintln((int)comboBox8.SelectedIndex, " Press And Hold [{+melee}] To Go Down");
                }

                private void button79_Click(object sender, EventArgs e)
                {
                    Aimbot.Stop();
                    Forge.Stop();
                    button79.Visible = false;
                    button80.Visible = true;
                    NoClip.Stop();
                    RPC_MW3.iPrintln((int)comboBox8.SelectedIndex, "Advanced NoClip ^1OFF");
                }

                private void button646_Click(object sender, EventArgs e)
                {
                    
                }

                private void onToolStripMenuItem11_Click(object sender, EventArgs e)
                {
                    
                    
                }
                #endregion 

            #region Mods client
                private void toolStripMenuItem24_Click(object sender, EventArgs e)
                {
                    byte[] buffer = new byte[0x20];
                    RPC_MW3.Set_ClientDvar(dataGridView1.CurrentRow.Index, "g_scriptmainmenu \"byMx444\"");
                    System.Threading.Thread.Sleep(10);
                    PS3.SetMemory(0x523b30, buffer);
                }

                private void underMapToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    byte[] UnderMap = new byte[] { 99};
                    PS3.SetMemory(0x110a2a4 + ((uint)dataGridView1.CurrentRow.Index * 0x3980), UnderMap);
                }

                private void skyToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    byte[] UnderMap = new byte[] { 70 };
                    PS3.SetMemory(0x110a2a4 + ((uint)dataGridView1.CurrentRow.Index * 0x3980), UnderMap);
                }

                private void spaceToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    byte[] UnderMap = new byte[] { 90 };
                    PS3.SetMemory(0x110a2a4 + ((uint)dataGridView1.CurrentRow.Index * 0x3980), UnderMap);
                }

                private void toolStripMenuItem25_Click(object sender, EventArgs e)
                {

                  
                }

                private void toolStripMenuItem25_Click_1(object sender, EventArgs e)
                {
                    RPC_MW3.Vision(this.dataGridView1.CurrentRow.Index, "oilrig_underwater");
                }
               
                public static void AutoShoot(uint client)
                {
                    if (client == client)
                    {
                        for (uint i = 0; i < 0x12; i++)
                        {
                            PS3.SetMemory(0x110a4c7 + (i * 0x3980), new byte[] { 1 });
                        }
                    }
                    else
                    {
                       PS3.SetMemory(0x110a4c7 + (client * 0x3980), new byte[] { 1 });
                    }
                }
                private void toolStripMenuItem26_Click(object sender, EventArgs e)
                {

                }

                private void shoot_Tick(object sender, EventArgs e)
                {
                    AutoShoot(((uint)this.dataGridView1.CurrentRow.Index));
                    
                }

                private void onToolStripMenuItem11_Click_1(object sender, EventArgs e)
                {
                    shoot.Start();
                }

                private void offToolStripMenuItem11_Click(object sender, EventArgs e)
                {
                    shoot.Stop();
                }
                public void clonePlayer(int client)
                {
                   RPC_MW3.Call(0x180f48, new object[] { client << 16 });
                  
                }
                private void toolStripMenuItem27_Click(object sender, EventArgs e)
                {

                    int index = this.dataGridView1.CurrentRow.Index;
                   clonePlayer(index);
                }

               

                private void button82_Click(object sender, EventArgs e)
                {
                    
                }

                private void checkBox44_CheckedChanged(object sender, EventArgs e)
                {
                    {
                        if (this.checkBox44.Checked)
                        {

                            clientl1.Start();

                        }
                        if (!this.checkBox44.Checked)
                        {
                            clientl1.Stop();
                        }
                    }
                }

                private void clientl1_Tick(object sender, EventArgs e)
                {
                    if (dataGridView1.RowCount == 1)
                    {
                        dataGridView1.Rows.Add(17);
                    }

                    for (uint i = 0; i < 18; i++)
                    {
                        dataGridView1[0, Convert.ToInt32(i)].Value = i;
                        dataGridView1[1, Convert.ToInt32(i)].Value = ClientNamesmw3(i);
                    }
                }

                private void toolStripMenuItem30_Click(object sender, EventArgs e)
                {

                }

                private void toolStripMenuItem31_Click(object sender, EventArgs e)
                {
                    string tits = toolStripTextBox1.Text;
                    RPC_MW3.iPrintln(dataGridView1.CurrentRow.Index,tits);
                }

                private void sendToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    string tits = toolStripTextBox2.Text;
                    RPC_MW3.iPrintlnBold(dataGridView1.CurrentRow.Index, tits);
                }

                private void sendToolStripMenuItem1_Click(object sender, EventArgs e)
                {
                    string tits = toolStripTextBox3.Text;
                    RPC_MW3.Kick(dataGridView1.CurrentRow.Index, tits);
                }

                private void toolStripTextBox3_Click(object sender, EventArgs e)
                {

                }

                private void aC13040mmToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    Weapons.AC130_40mm((uint)dataGridView1.CurrentRow.Index);
                }

                private void aC130ToolStripMenuItem2_Click(object sender, EventArgs e)
                {
                    Weapons.AC130_25mm((uint)dataGridView1.CurrentRow.Index);
                }

                private void pavelowToolStripMenuItem1_Click(object sender, EventArgs e)
                {
                    Weapons.Pavelow((uint)dataGridView1.CurrentRow.Index); 
                }

                private void helicopterToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    Weapons.helicopter((uint)dataGridView1.CurrentRow.Index);
                }

                private void ospreyToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    Weapons.osprey((uint)dataGridView1.CurrentRow.Index);
                }

                private void walkingIMSToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    Weapons.IMS((uint)dataGridView1.CurrentRow.Index);
                }

                private void bombToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    Weapons.Bomb((uint)dataGridView1.CurrentRow.Index);
                }

                private void laptopToolStripMenuItem_Click(object sender, EventArgs e)
                {
                    Weapons.Lap((uint)dataGridView1.CurrentRow.Index);
                }

                private void button622_Click(object sender, EventArgs e)
                {
                    RPC_MW3.Cmd_ExecuteSingleCommand((uint)this.numericUpDown247.Value, this.textBox209.Text);
                }

                private void textBox209_TextChanged(object sender, EventArgs e)
                {

                }

                private void button623_Click(object sender, EventArgs e)
                {
                    RPC_MW3.SV_GameSendServerCommand((int)this.numericUpDown248.Value, this.textBox210.Text);
                }

                private void button624_Click(object sender, EventArgs e)
                {
                    RPC_MW3.CBuf_AddText((int)this.numericUpDown249.Value, this.textBox211.Text);
                }

                private void button625_Click(object sender, EventArgs e)
                {
                    RPC_MW3.Set_ClientDvar((int)this.numericUpDown250.Value, this.textBox212.Text);
                }

                private void button565_Click(object sender, EventArgs e)
                {
                    RPC_MW3.Vision((int)this.numericUpDown234.Value, this.textBox180.Text);
                }

                private void button621_Click(object sender, EventArgs e)
                {
                    RPC_MW3.Kick((int)this.numericUpDown246.Value, this.textBox208.Text);
                }

                private void button563_Click(object sender, EventArgs e)
                {
                    RPC_MW3.Fov((int)this.numericUpDown232.Value, this.textBox121.Text);
                }

                private void onToolStripMenuItem12_Click(object sender, EventArgs e)
                {
                    Aimbot1.Start();
                }

                private void offToolStripMenuItem12_Click(object sender, EventArgs e)
                {
                    Aimbot1.Stop();
                }

                private void Aimbot1_Tick(object sender, EventArgs e)
                {
                    StartAimbot((uint)dataGridView1.CurrentRow.Index);
                }

                private void Forge1_Tick(object sender, EventArgs e)
                {
                    StartForgeMode((uint)dataGridView1.CurrentRow.Index);
                }

                private void onToolStripMenuItem13_Click(object sender, EventArgs e)
                {
                    Forge1.Start();
                }

                private void offToolStripMenuItem13_Click(object sender, EventArgs e)
                {
                    Forge1.Stop();
                }

                private void Ghetto_Tick(object sender, EventArgs e)
                {
                    AdvancedNoClip((int)dataGridView1.CurrentRow.Index);

                    if (Aimbot_and_ForgeMode.ReadInt(0xFCA41D + ((uint)dataGridView1.CurrentRow.Index * 0x280)) == 0)
                    {
                        System.Threading.Thread.Sleep(1500);
                        allPerks((int)dataGridView1.CurrentRow.Index);

                    }
                }

                private void onToolStripMenuItem14_Click(object sender, EventArgs e)
                {
                    Ghetto.Start();
                }

                private void offToolStripMenuItem14_Click(object sender, EventArgs e)
                {
                    Ghetto.Stop();
                }

                private void textBox7_TextChanged_1(object sender, EventArgs e)
                {

                }

                private void numericUpDown6_ValueChanged_1(object sender, EventArgs e)
                {

                }

                private void button52_Click_1(object sender, EventArgs e)
                {
                    RPC_MW3.SetModel((int)this.numericUpDown6.Value,this.textBox7.Text);
                }

                private void button627_Click(object sender, EventArgs e)
                {
                    int weapon = Convert.ToInt32(this.textBox214.Text);
                    if (this.numericUpDown252.Value == -1M)
                    {
                        for (int i = 0; i < 0x12; i++)
                        {
                           RPC_MW3.GiveWeapon(i, weapon, 0);
                        }
                    }
                    RPC_MW3.GiveWeapon((int)this.numericUpDown252.Value, weapon, 0);
                }
              
                private void button53_Click_1(object sender, EventArgs e)
                {
                    
                
                }

                private void button53_Click_2(object sender, EventArgs e)
                {
                    if (comboBox50.SelectedItem == "Middle Screen")
                    {
                        RPC_MW3.iPrintlnBold((int)numericUpDown7.Value,textBox8.Text);
                        

                    }

                    if (comboBox50.SelectedItem == "Killfeed")
                    {
                        RPC_MW3.iPrintln((int)numericUpDown7.Value, textBox8.Text);
                       
                    }
                }

                private void comboBox50_SelectedIndexChanged(object sender, EventArgs e)
                {

                }

                private void numericUpDown7_ValueChanged_1(object sender, EventArgs e)
                {

                }

                private void textBox8_TextChanged_1(object sender, EventArgs e)
                {

                }

                private void numericUpDown8_ValueChanged_1(object sender, EventArgs e)
                {

                }

                private void SpeedMw3_ValueChanged(object sender, EventArgs e)
                {

                }

                private void button54_Click_1(object sender, EventArgs e)
                {
                    byte[] buffer = new byte[4];
                    buffer[0] = 0x42;
                    buffer[1] = 0x9c;
                    PS3.SetMemory(0x19780, buffer);
                    this.SpeedMw3.Value = 78M;
                   
                }

                private void button588_Click(object sender, EventArgs e)
                {
                    
                }
                public static class g_knockback
                {
                    public static void Default()
                    {
                        RPC_MW3.CBuf_AddText(0, "reset g_knockback");
                    }

                    public static void Scale(decimal value)
                    {
                        RPC_MW3.CBuf_AddText(0, "g_knockback " + value);
                    }
                }

                private void Mw3KnockBack_ValueChanged(object sender, EventArgs e)
                {
                    g_knockback.Scale(this.Mw3KnockBack.Value);
                }

                private void button589_Click(object sender, EventArgs e)
                {
                    g_knockback.Default();
                }

                private void button582_Click(object sender, EventArgs e)
                {

                }

                private void Mw3Timescale_ValueChanged(object sender, EventArgs e)
                {
                    fixedtime.Scale(Mw3Timescale.Value);
                }

                public static class fixedtime
                {
                    public static void Default()
                    {
                        RPC_MW3.CBuf_AddText(0, "reset fixedtime");
                    }

                    public static void Scale(decimal value)
                    {
                       RPC_MW3.CBuf_AddText(0, "fixedtime " + value);
                    }
                }

                private void button583_Click(object sender, EventArgs e)
                {
                    fixedtime.Default();
                }

                private void button82_Click_1(object sender, EventArgs e)
                {
                    Speed_Default();
                   
                }
                public static void Speed(decimal value)
                {
                    int num = (int)value;
                    byte num2 = (byte)num;
                    byte num3 = (byte)(num >> 8);
                    PS3.SetMemory(0x173bb2, new byte[] { num3, num2 });
                }

                public static void Speed_Default()
                {
                    PS3.SetMemory(0x173bb2, new byte[] { 0x38, 0xa0, 0x00, 0x0b });
                }

                private void button84_Click(object sender, EventArgs e)
                {
                    timer40.Start();

                }
                public static class g_password
                {
                    public static void Off()
                    {
                        RPC_MW3.CBuf_AddText(0, "reset g_password");
                    }

                    public static void On()
                    {
                        RPC_MW3.CBuf_AddText(0, "g_password Mx444");
                    }
                }

                private void button83_Click(object sender, EventArgs e)
                {
                    timer40.Stop();
                }

                private void button86_Click(object sender, EventArgs e)
                {
                    RPC_MW3.Cmd_ExecuteSingleCommand(0, "onlinegame 1");
                    RPC_MW3.Cmd_ExecuteSingleCommand(0, "onlinegameandhost 1");
                    RPC_MW3.Cmd_ExecuteSingleCommand(0, "xblive_privatematch 0");
                    RPC_MW3.Cmd_ExecuteSingleCommand(0, "xblive_rankedmatch 1");
                    System.Threading.Thread.Sleep(1);
                    RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));
                }

                private void button85_Click(object sender, EventArgs e)
                {
                    RPC_MW3.Cmd_ExecuteSingleCommand(0, "onlinegame 0");
                    RPC_MW3.Cmd_ExecuteSingleCommand(0, "onlinegameandhost 0");
                    RPC_MW3.Cmd_ExecuteSingleCommand(0, "xblive_privatematch 1");
                    RPC_MW3.Cmd_ExecuteSingleCommand(0, "xblive_rankedmatch 0");
                    System.Threading.Thread.Sleep(1);
                    RPC_MW3.CallFunction(0x00223B20, RPC_MW3.str_pointer("sv_maprestart_f"));
                }

                private void button87_Click(object sender, EventArgs e)
                {
                    
                  
               }
                private static string JustForKeyboard(string text)
                {
                    return text.Replace("[X]", "\x0001").Replace("[O]", "\x0002").Replace("[]", "\x0003").Replace("[Y]", "\x0004").Replace("[L1]", "\x0005").Replace("[R1]", "\x0006").Replace("[L3]", "\x0010").Replace("[R3]", "\x0011").Replace("[L2]", "\x0012").Replace("[R2]", "\x0013").Replace("[UP]", "\x0014").Replace("[DOWN]", "\x0015").Replace("[LEFT]", "\x0016").Replace("[RIGHT]", "\x0017").Replace("[START]", "\x000e").Replace("[SELECT]", "\x000f").Replace("[LINE]", "\n").Replace("[3D]", "\r");
                }

                public static string KeyBoard(int client, string Title, string input, int MaxLength = 20)
                {
                    string str = JustForKeyboard(Title);
                    string str2 = JustForKeyboard(input);
                    RPC_MW3.Call(0x26f5bc, new object[] { client, str, str2, MaxLength, 0x72dce8, 0x7239a0 });
                    while (PS3.Extension.ReadInt32(0x73145c) != client)
                    {
                    }
                    return PS3.Extension.ReadString(0x2380e22);
                }
                public static String KeyBoard(String Title)
                {
                    RPC_MW3.Call(0x026F5BC, 0, Title, "", 20, 0x72DCE8, 0x7239A0);
                    while (PS3.Extension.ReadInt32(0x73145C) != 0)
                    {
                        continue;
                    }
                    return PS3.Extension.ReadString(0x2380E22);
                }

                private void groupBox339_Enter(object sender, EventArgs e)
                {
                  
                }

                private void button87_Click_1(object sender, EventArgs e)
                {

                }

                private void Painter_Tick(object sender, EventArgs e)
                {
                   
                }



                private void button87_Click_2(object sender, EventArgs e)
                {

                }

                private void button88_Click(object sender, EventArgs e)
                {


                }
            #endregion

            #region Other Stuff
 
                
                private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
                {
                   
                }

                private void Box_SelectedIndexChanged_1(object sender, EventArgs e)
                {
                    
                }
          
           

        
    

        private void button88_Click_1(object sender, EventArgs e)
        {
            
    }

        private void button89_Click(object sender, EventArgs e)
        {
       
        }

        private void button90_Click(object sender, EventArgs e)
        {

        }

        private void POS_Tick(object sender, EventArgs e)
        {
           
        }

        private void label72_Click(object sender, EventArgs e)
        {

        }

        private void label71_Click(object sender, EventArgs e)
        {

        }

        private void button90_Click_1(object sender, EventArgs e)
        {

            
        }

        private void button89_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button87_Click_3(object sender, EventArgs e)
        {
            PS3.SetMemory(0x1C19484, new byte[] { 0x10, 0x3F, 0x66, 0 }); //score
            PS3.SetMemory(0x01C194AC, new byte[] { 0x10, 0x3F, 0x66, 0 }); //kills
            PS3.SetMemory(0x01C194B0, new byte[] { 0x10, 0x3F, 0x66, 0 }); //Killstreak
            PS3.SetMemory(0x01C194B4, new byte[] { 0x10, 0x3F, 0x66, 0 }); //deaths
            PS3.SetMemory(0x01C194BC, new byte[] { 0x10, 0x3F, 0x66, 0 }); //assists
            PS3.SetMemory(0x01C194C0, new byte[] { 0x10, 0x3F, 0x66, 0 }); //headshots
            PS3.SetMemory(0x01C194E0, new byte[] { 0x10, 0x3F, 0x66, 0 }); //wins
            PS3.SetMemory(0x01C194E4, new byte[] { 0x10, 0x3F, 0x66, 0 }); //losses
            PS3.SetMemory(0x01C194E8, new byte[] { 0x10, 0x3F, 0x66, 0 });//ties
            PS3.SetMemory(0x01C194EC, new byte[] { 0x10, 0x3F, 0x66, 0 }); //winstreak
        }

        private void button88_Click_2(object sender, EventArgs e)
        {
            PS3.SetMemory(0x1C1C271, new byte[] { 0x18, 0xA5, 0x1A });
        }

        private void button91_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x01C19484, new byte[] { 0xB8, 0xC2, 0x20, 0 }); //score
            PS3.SetMemory(0x01C194AC, new byte[] { 0xB8, 0xC2, 0x20, 0 }); //kills
            PS3.SetMemory(0x01C194B0, new byte[] { 0xB8, 0xC2, 0x20, 0 }); //Killstreak
            PS3.SetMemory(0x01C194B4, new byte[] { 0, 0, 0, 0 }); //deaths
            PS3.SetMemory(0x01C194BC, new byte[] { 0xB8, 0xC2, 0x20, 0 }); //assists
            PS3.SetMemory(0x01C194C0, new byte[] { 0xB8, 0xC2, 0x20, 0 }); //headshots
            PS3.SetMemory(0x01C194E0, new byte[] { 0xB8, 0xC2, 0x20, 0 }); //wins
            PS3.SetMemory(0x01C194E4, new byte[] { 0, 0, 0, 0 }); //losses
            PS3.SetMemory(0x01C194E8, new byte[] { 0xB8, 0xC2, 0x20, 0 }); //ties
            PS3.SetMemory(0x01C194EC, new byte[] { 0xB8, 0xC2, 0x20, 0 }); //winstreak
        }

        private void button92_Click(object sender, EventArgs e)
        {
            
        }

        private void button93_Click(object sender, EventArgs e)
        {
            
        }
       
        private void FPS_Tick(object sender, EventArgs e)
        {
           

        }

        private void txbText_TextChanged(object sender, EventArgs e)
        {

        }

        private void label71_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button92_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button93_Click_1(object sender, EventArgs e)
        {
           
        }

        private void Mw3ClassModdingStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Mw3ClassModdingStatus.SelectedItem.ToString() == "Online")
            {
                this.Mw3GMClass_CustomClass.Text = "Custom Class 1";
                this.Mw3AUGClassNum.Text = "Custom Class 1";
                this.Mw32Scopes_ClassNum.Text = "Custom Class 1";
                this.Mw3HandgunClassNum.Text = "Custom Class 1";
                try
                {
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 1");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 2");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 3");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 4");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 5");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 1");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 2");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 3");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 4");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 5");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 1");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 2");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 3");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 4");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 5");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 1");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 2");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 3");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 4");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 5");
                }
                catch
                {
                }
                this.Mw3AUGClassNum.Items.Add("Custom Class 1");
                this.Mw3AUGClassNum.Items.Add("Custom Class 2");
                this.Mw3AUGClassNum.Items.Add("Custom Class 3");
                this.Mw3AUGClassNum.Items.Add("Custom Class 4");
                this.Mw3AUGClassNum.Items.Add("Custom Class 5");
                this.Mw3AUGClassNum.Items.Add("Custom Class 6");
                this.Mw3AUGClassNum.Items.Add("Custom Class 7");
                this.Mw3AUGClassNum.Items.Add("Custom Class 8");
                this.Mw3AUGClassNum.Items.Add("Custom Class 9");
                this.Mw3AUGClassNum.Items.Add("Custom Class 10");
                this.Mw3AUGClassNum.Items.Add("Custom Class 11");
                this.Mw3AUGClassNum.Items.Add("Custom Class 12");
                this.Mw3AUGClassNum.Items.Add("Custom Class 13");
                this.Mw3AUGClassNum.Items.Add("Custom Class 14");
                this.Mw3AUGClassNum.Items.Add("Custom Class 15");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 1");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 2");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 3");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 4");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 5");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 6");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 7");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 8");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 9");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 10");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 11");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 12");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 13");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 14");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 15");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 1");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 2");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 3");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 4");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 5");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 6");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 7");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 8");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 9");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 10");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 11");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 12");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 13");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 14");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 15");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 1");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 2");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 3");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 4");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 5");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 6");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 7");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 8");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 9");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 10");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 11");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 12");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 13");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 14");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 15");
            }
            if (this.Mw3ClassModdingStatus.SelectedItem.ToString() == "Split Screen")
            {
                this.Mw3GMClass_CustomClass.Text = "Custom Class 1";
                this.Mw3AUGClassNum.Text = "Custom Class 1";
                this.Mw32Scopes_ClassNum.Text = "Custom Class 1";
                this.Mw3HandgunClassNum.Text = "Custom Class 1";
                try
                {
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 1");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 2");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 3");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 4");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 5");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 1");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 2");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 3");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 4");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 5");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 1");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 2");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 3");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 4");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 5");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 1");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 2");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 3");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 4");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 5");
                }
                catch
                {
                }
                this.Mw3AUGClassNum.Items.Add("Custom Class 1");
                this.Mw3AUGClassNum.Items.Add("Custom Class 2");
                this.Mw3AUGClassNum.Items.Add("Custom Class 3");
                this.Mw3AUGClassNum.Items.Add("Custom Class 4");
                this.Mw3AUGClassNum.Items.Add("Custom Class 5");
                this.Mw3AUGClassNum.Items.Add("Custom Class 6");
                this.Mw3AUGClassNum.Items.Add("Custom Class 7");
                this.Mw3AUGClassNum.Items.Add("Custom Class 8");
                this.Mw3AUGClassNum.Items.Add("Custom Class 9");
                this.Mw3AUGClassNum.Items.Add("Custom Class 10");
                this.Mw3AUGClassNum.Items.Add("Custom Class 11");
                this.Mw3AUGClassNum.Items.Add("Custom Class 12");
                this.Mw3AUGClassNum.Items.Add("Custom Class 13");
                this.Mw3AUGClassNum.Items.Add("Custom Class 14");
                this.Mw3AUGClassNum.Items.Add("Custom Class 15");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 1");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 2");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 3");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 4");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 5");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 6");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 7");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 8");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 9");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 10");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 11");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 12");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 13");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 14");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 15");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 1");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 2");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 3");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 4");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 5");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 6");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 7");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 8");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 9");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 10");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 11");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 12");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 13");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 14");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 15");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 1");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 2");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 3");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 4");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 5");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 6");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 7");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 8");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 9");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 10");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 11");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 12");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 13");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 14");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 15");
            }
            if (this.Mw3ClassModdingStatus.SelectedItem.ToString() == "Private Match")
            {
                this.Mw3GMClass_CustomClass.Text = "Custom Class 1";
                this.Mw3AUGClassNum.Text = "Custom Class 1";
                this.Mw32Scopes_ClassNum.Text = "Custom Class 1";
                this.Mw3HandgunClassNum.Text = "Custom Class 1";
                try
                {
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 1");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 2");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 3");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 4");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 5");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 6");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 7");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 8");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 9");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 10");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 11");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 12");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 13");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 14");
                    this.Mw3AUGClassNum.Items.Remove("Custom Class 15");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 1");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 2");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 3");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 4");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 5");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 6");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 7");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 8");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 9");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 10");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 11");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 12");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 13");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 14");
                    this.Mw32Scopes_ClassNum.Items.Remove("Custom Class 15");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 1");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 2");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 3");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 4");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 5");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 6");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 7");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 8");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 9");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 10");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 11");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 12");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 13");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 14");
                    this.Mw3HandgunClassNum.Items.Remove("Custom Class 15");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 1");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 2");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 3");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 4");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 5");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 6");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 7");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 8");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 9");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 10");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 11");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 12");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 13");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 14");
                    this.Mw3GMClass_CustomClass.Items.Remove("Custom Class 15");
                }
                catch
                {
                }
                this.Mw3AUGClassNum.Items.Add("Custom Class 1");
                this.Mw3AUGClassNum.Items.Add("Custom Class 2");
                this.Mw3AUGClassNum.Items.Add("Custom Class 3");
                this.Mw3AUGClassNum.Items.Add("Custom Class 4");
                this.Mw3AUGClassNum.Items.Add("Custom Class 5");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 1");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 2");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 3");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 4");
                this.Mw3HandgunClassNum.Items.Add("Custom Class 5");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 1");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 2");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 3");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 4");
                this.Mw32Scopes_ClassNum.Items.Add("Custom Class 5");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 1");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 2");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 3");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 4");
                this.Mw3GMClass_CustomClass.Items.Add("Custom Class 5");
            }
            this.Mw3GMClass_CustomClass.Text = "Custom Class 1";
            this.Mw3AUGClassNum.Text = "Custom Class 1";
            this.Mw32Scopes_ClassNum.Text = "Custom Class 1";
            this.Mw3HandgunClassNum.Text = "Custom Class 1";
        }

        private void Mw3AUGProficiency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Mw3AUGProficiency.SelectedItem.ToString() == "2 Attachments")
            {
                this.Mw3AUG2ndAttachment.Enabled = true;
            }
            else
            {
                this.Mw3AUG2ndAttachment.Enabled = false;
            }
        }

        private void metroButton41_Click(object sender, EventArgs e)
        {

        }

        private void button92_Click_2(object sender, EventArgs e)
        {
            try
            {
                uint num2;
                uint num3;
                uint num4;
                uint num5;
                if (this.Mw3ClassModdingStatus.SelectedItem.ToString() == "Online")
                {
                    uint num = 0x1c19804;
                    num2 = num + 8;
                    num3 = num + 2;
                    num4 = num + 4;
                    num5 = num + 6;
                    PS3.SetMemory(num + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 90 });
                    if (this.Mw3AUGProficiency.Text == "Proficiency")
                    {
                        MessageBox.Show("Choose Proficiency!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    if (this.Mw3AUGProficiency.SelectedItem.ToString() == "None")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[1]);
                    }
                    else if (this.Mw3AUGProficiency.SelectedItem.ToString() == "Kick")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x85 });
                    }
                    else if (this.Mw3AUGProficiency.SelectedItem.ToString() == "Impact")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x84 });
                    }
                    else if (this.Mw3AUGProficiency.SelectedItem.ToString() == "2 Attachments")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x39 });
                    }
                    else if (this.Mw3AUGProficiency.SelectedItem.ToString() == "Focus")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x86 });
                    }
                    else if (this.Mw3AUGProficiency.SelectedItem.ToString() == "Speed")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x23 });
                    }
                    else if (this.Mw3AUGProficiency.SelectedItem.ToString() == "Stability")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x8b });
                    }
                    if (this.Mw3AUGProficiency.Text == "1st Attachment")
                    {
                        MessageBox.Show("Choose Attachment!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "None")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[1]);
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Red Dot Sight")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 1 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Silencer")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x11 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Grip")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 3 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "ACOG Scope")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Rapid Fire")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 10 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Heartbeat Sensor")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 7 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Holographic Sight")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 11 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Extended Mags")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 9 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Thermal")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 5 });
                    }
                    if (this.Mw3AUGProficiency.SelectedItem.ToString() == "2 Attachments")
                    {
                        if (this.Mw3AUG2ndAttachment.Text == "2st Attachment")
                        {
                            MessageBox.Show("Choose 2nd Attachment!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "None")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[1]);
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Red Dot Sight")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 1 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Silencer")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x11 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Grip")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 3 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "ACOG Scope")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Rapid Fire")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 10 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Heartbeat Sensor")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 7 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Holographic Sight")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 11 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Extended Mags")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 9 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Thermal")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 5 });
                        }
                    }
                    if (this.Mw3AUGCamo.Text == "Camo")
                    {
                        MessageBox.Show("Choose Camo!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    if (this.Mw3AUGCamo.SelectedItem.ToString() == "None")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[1]);
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Woodland")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 1 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Desert")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Arctic")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 3 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Digital")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 4 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Urban")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 5 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Blue Tiger")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 8 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Red Tiger")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 6 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Fall")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 10 });
                    }
                }
                else if (this.Mw3ClassModdingStatus.SelectedItem.ToString() == "Private Match")
                {
                    uint num6 = 0x1c19dc2;
                    num2 = num6 + 8;
                    num3 = num6 + 2;
                    num4 = num6 + 4;
                    num5 = num6 + 6;
                    PS3.SetMemory(num6 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 90 });
                    if (this.Mw3AUGProficiency.Text == "Proficiency")
                    {
                        MessageBox.Show("Choose Proficiency!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    if (this.Mw3AUGProficiency.SelectedItem.ToString() == "None")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[1]);
                    }
                    else if (this.Mw3AUGProficiency.SelectedItem.ToString() == "Kick")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x85 });
                    }
                    else if (this.Mw3AUGProficiency.SelectedItem.ToString() == "Impact")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x84 });
                    }
                    else if (this.Mw3AUGProficiency.SelectedItem.ToString() == "2 Attachments")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x39 });
                    }
                    else if (this.Mw3AUGProficiency.SelectedItem.ToString() == "Focus")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x86 });
                    }
                    else if (this.Mw3AUGProficiency.SelectedItem.ToString() == "Speed")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x23 });
                    }
                    else if (this.Mw3AUGProficiency.SelectedItem.ToString() == "Stability")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x8b });
                    }
                    if (this.Mw3AUGProficiency.Text == "1st Attachment")
                    {
                        MessageBox.Show("Choose Attachment!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "None")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[1]);
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Red Dot Sight")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 1 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Silencer")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x11 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Grip")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 3 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "ACOG Scope")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Rapid Fire")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 10 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Heartbeat Sensor")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 7 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Holographic Sight")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 11 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Extended Mags")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 9 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Thermal")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 5 });
                    }
                    if (this.Mw3AUGProficiency.SelectedItem.ToString() == "2 Attachments")
                    {
                        if (this.Mw3AUG2ndAttachment.Text == "2st Attachment")
                        {
                            MessageBox.Show("Choose 2nd Attachment!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "None")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[1]);
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Red Dot Sight")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 1 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Silencer")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x11 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Grip")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 3 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "ACOG Scope")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Rapid Fire")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 10 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Heartbeat Sensor")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 7 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Holographic Sight")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 11 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Extended Mags")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 9 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Thermal")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 5 });
                        }
                    }
                    if (this.Mw3AUGCamo.Text == "Camo")
                    {
                        MessageBox.Show("Choose Camo!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    if (this.Mw3AUGCamo.SelectedItem.ToString() == "None")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[1]);
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Woodland")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 1 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Desert")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Arctic")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 3 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Digital")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 4 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Urban")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 5 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Blue Tiger")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 8 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Red Tiger")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 6 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Fall")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 10 });
                    }
                }
                else if (this.Mw3ClassModdingStatus.SelectedItem.ToString() == "Split Screen")
                {
                    uint num7 = 0x1c1c809;
                    num2 = num7 + 8;
                    num3 = num7 + 2;
                    num4 = num7 + 4;
                    num5 = num7 + 6;
                    PS3.SetMemory(num7 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 90 });
                    if (this.Mw3AUGProficiency.Text == "Proficiency")
                    {
                        MessageBox.Show("Choose Proficiency!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    if (this.Mw3AUGProficiency.SelectedItem.ToString() == "None")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[1]);
                    }
                    else if (this.Mw3AUGProficiency.SelectedItem.ToString() == "Kick")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x85 });
                    }
                    else if (this.Mw3AUGProficiency.SelectedItem.ToString() == "Impact")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x84 });
                    }
                    else if (this.Mw3AUGProficiency.SelectedItem.ToString() == "2 Attachments")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x39 });
                    }
                    else if (this.Mw3AUGProficiency.SelectedItem.ToString() == "Focus")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x86 });
                    }
                    else if (this.Mw3AUGProficiency.SelectedItem.ToString() == "Speed")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x23 });
                    }
                    else if (this.Mw3AUGProficiency.SelectedItem.ToString() == "Stability")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x8b });
                    }
                    if (this.Mw3AUGProficiency.Text == "1st Attachment")
                    {
                        MessageBox.Show("Choose Attachment!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "None")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[1]);
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Red Dot Sight")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 1 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Silencer")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x11 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Grip")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 3 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "ACOG Scope")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Rapid Fire")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 10 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Heartbeat Sensor")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 7 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Holographic Sight")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 11 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Extended Mags")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 9 });
                    }
                    else if (this.Mw3AUG1stAttachment.SelectedItem.ToString() == "Thermal")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 5 });
                    }
                    if (this.Mw3AUGProficiency.SelectedItem.ToString() == "2 Attachments")
                    {
                        if (this.Mw3AUG2ndAttachment.Text == "2st Attachment")
                        {
                            MessageBox.Show("Choose 2nd Attachment!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "None")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[1]);
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Red Dot Sight")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 1 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Silencer")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 0x11 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Grip")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 3 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "ACOG Scope")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Rapid Fire")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 10 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Heartbeat Sensor")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 7 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Holographic Sight")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 11 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Extended Mags")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 9 });
                        }
                        else if (this.Mw3AUG2ndAttachment.SelectedItem.ToString() == "Thermal")
                        {
                            PS3.SetMemory(num4 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 5 });
                        }
                    }
                    if (this.Mw3AUGCamo.Text == "Camo")
                    {
                        MessageBox.Show("Choose Camo!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    if (this.Mw3AUGCamo.SelectedItem.ToString() == "None")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[1]);
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Woodland")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 1 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Desert")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Arctic")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 3 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Digital")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 4 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Urban")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 5 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Blue Tiger")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 8 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Red Tiger")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 6 });
                    }
                    else if (this.Mw3AUGCamo.SelectedItem.ToString() == "Fall")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw3AUGClassNum.SelectedIndex * 0x62)), new byte[] { 10 });
                    }
                }
            }
            catch
            {
                MessageBox.Show("No Attachment | Camo Choosed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button93_Click_2(object sender, EventArgs e)
        {
            uint num = 0x1c19812;
            uint num2 = 0x1c19810;
            try
            {
                if (this.Mw3HandgunType.SelectedItem.ToString() == "Choose Pistol")
                {
                    MessageBox.Show("No Handgun have been choosed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (this.Mw3HandgunType.SelectedItem.ToString() == "Desert Eagle")
                {
                    PS3.SetMemory(num2 + ((uint)(this.Mw3HandgunClassNum.SelectedIndex * 0x62)), new byte[] { 4 });
                }
                else if (this.Mw3HandgunType.SelectedItem.ToString() == ".44 Magnum")
                {
                    PS3.SetMemory(num2 + ((uint)(this.Mw3HandgunClassNum.SelectedIndex * 0x62)), new byte[] { 3 });
                }
                if (this.Mw3HandgunType.SelectedItem.ToString() == "MP412")
                {
                    PS3.SetMemory(num2 + ((uint)(this.Mw3HandgunClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                }
                byte[] buffer = new byte[10];
                buffer[0] = 0x12;
                PS3.SetMemory(num + ((uint)(this.Mw3HandgunClassNum.SelectedIndex * 0x62)), buffer);
            }
            catch
            {
                MessageBox.Show("No Handgun have been choosed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void Mw32ScopesWeaponType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Mw32ScopesWeaponType.SelectedItem.ToString() == "Assault Rifle")
            {
                this.Mw32Scopes_Weapon.ResetText();
                System.Threading.Thread.Sleep(100);
                this.Mw32Scopes_Weapon.Text = "Weapon";
                try
                {
                    this.Mw32Scopes_Weapon.Items.Remove("Choose Weapon Type");
                }
                catch
                {
                }
                try
                {
                    this.Mw32Scopes_Weapon.Items.Remove("MP5");
                    this.Mw32Scopes_Weapon.Items.Remove("UMP45");
                    this.Mw32Scopes_Weapon.Items.Remove("PP90M1");
                    this.Mw32Scopes_Weapon.Items.Remove("P90");
                    this.Mw32Scopes_Weapon.Items.Remove("PM-9");
                    this.Mw32Scopes_Weapon.Items.Remove("MP7");
                }
                catch
                {
                }
                this.Mw32Scopes_Weapon.Items.Add("M4A1");
                this.Mw32Scopes_Weapon.Items.Add("M16A4");
                this.Mw32Scopes_Weapon.Items.Add("SCAR-L");
                this.Mw32Scopes_Weapon.Items.Add("CM901");
                this.Mw32Scopes_Weapon.Items.Add("Type 95");
                this.Mw32Scopes_Weapon.Items.Add("G36C");
                this.Mw32Scopes_Weapon.Items.Add("ACR 6.8");
                this.Mw32Scopes_Weapon.Items.Add("MK14");
                this.Mw32Scopes_Weapon.Items.Add("AK-47");
                this.Mw32Scopes_Weapon.Items.Add("FAD");
                this.Mw32Scopes_Scope2.Text = "Hybrid Sight";
            }
            if (this.Mw32ScopesWeaponType.SelectedItem.ToString() == "Sub Machine Gun")
            {
                this.Mw32Scopes_Weapon.ResetText();
                System.Threading.Thread.Sleep(100);
                this.Mw32Scopes_Weapon.Text = "Weapon";
                try
                {
                    this.Mw32Scopes_Weapon.Items.Remove("Choose Weapon Type");
                }
                catch
                {
                }
                try
                {
                    this.Mw32Scopes_Weapon.Items.Remove("M4A1");
                    this.Mw32Scopes_Weapon.Items.Remove("M16A4");
                    this.Mw32Scopes_Weapon.Items.Remove("SCAR-L");
                    this.Mw32Scopes_Weapon.Items.Remove("CM901");
                    this.Mw32Scopes_Weapon.Items.Remove("Type 95");
                    this.Mw32Scopes_Weapon.Items.Remove("G36C");
                    this.Mw32Scopes_Weapon.Items.Remove("ACR 6.8");
                    this.Mw32Scopes_Weapon.Items.Remove("MK14");
                    this.Mw32Scopes_Weapon.Items.Remove("AK-47");
                    this.Mw32Scopes_Weapon.Items.Remove("FAD");
                }
                catch
                {
                }
                this.Mw32Scopes_Weapon.Items.Add("MP5");
                this.Mw32Scopes_Weapon.Items.Add("UMP45");
                this.Mw32Scopes_Weapon.Items.Add("PP90M1");
                this.Mw32Scopes_Weapon.Items.Add("P90");
                this.Mw32Scopes_Weapon.Items.Add("PM-9");
                this.Mw32Scopes_Weapon.Items.Add("MP7");
                this.Mw32Scopes_Scope2.Text = "Hamr Scope";
            }
        }

        private void button94_Click(object sender, EventArgs e)
        {
            try
            {
                uint num2;
                uint num3;
                uint num4;
                uint num5;
                uint num6;
                if (this.Mw3ClassModdingStatus.SelectedItem.ToString() == "Online")
                {
                    uint num = 0x1c19804;
                    num2 = num + 8;
                    num3 = num + 2;
                    num4 = num + 4;
                    num5 = num + 10;
                    num6 = num + 6;
                    if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "M4A1")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 9 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "M16A4")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 11 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "SCAR-L")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 14 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "CM901")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x10 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "Type 95")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 8 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "G36C")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 13 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "ACR 6.8")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 7 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "AK-47")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 10 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "MK14")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 12 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "FAD")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 15 });
                    }
                    if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "MP5")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x11 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "UMP45")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x15 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "PP90M1")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 20 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "P90")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x13 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "PM-9")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x12 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "MP7")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x16 });
                    }
                    if (this.Mw32Scopes_Scope1.SelectedItem.ToString() == "Red Dot Sight")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 1 });
                    }
                    else if (this.Mw32Scopes_Scope1.SelectedItem.ToString() == "ACOG Scope")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                    }
                    else if (this.Mw32Scopes_Scope1.SelectedItem.ToString() == "Holographic Sight")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 11 });
                    }
                    else if (this.Mw32Scopes_Scope1.SelectedItem.ToString() == "Thermal")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 5 });
                    }
                    if (this.Mw32Scopes_Scope2.Text == "Hybrid Sight")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x15 });
                    }
                    else if (this.Mw32Scopes_Scope2.Text == "Hamr Scope")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 20 });
                    }
                    if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "None")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[1]);
                    }
                    else if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "TARGET DOT")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 1 });
                    }
                    else if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "DELTA")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                    }
                    else if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "U-DOT")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 3 });
                    }
                    else if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "MIL-DOT")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 4 });
                    }
                    else if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "OMEGA")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 5 });
                    }
                    else if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "LAMBDA")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 6 });
                    }
                    if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "None")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[1]);
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Classic")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 1 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Snow")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Multicam")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 3 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Digital Urban")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 4 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Hex")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 5 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Choco")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 6 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Snake")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 8 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Blue")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 10 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Red")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 11 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Autunm")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 12 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Gold")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 13 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Marine")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 7 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Winter")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 9 });
                    }
                    PS3.SetMemory(num2 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x39 });
                }
                else if (this.Mw3ClassModdingStatus.SelectedItem.ToString() == "Private Match")
                {
                    uint num7 = 0x1c19dc2;
                    num2 = num7 + 8;
                    num3 = num7 + 2;
                    num4 = num7 + 4;
                    num5 = num7 + 10;
                    num6 = num7 + 6;
                    if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "M4A1")
                    {
                        PS3.SetMemory(num7 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 9 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "M16A4")
                    {
                        PS3.SetMemory(num7 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 11 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "SCAR-L")
                    {
                        PS3.SetMemory(num7 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 14 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "CM901")
                    {
                        PS3.SetMemory(num7 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x10 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "Type 95")
                    {
                        PS3.SetMemory(num7 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 8 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "G36C")
                    {
                        PS3.SetMemory(num7 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 13 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "ACR 6.8")
                    {
                        PS3.SetMemory(num7 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 7 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "AK-47")
                    {
                        PS3.SetMemory(num7 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 10 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "MK14")
                    {
                        PS3.SetMemory(num7 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 12 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "FAD")
                    {
                        PS3.SetMemory(num7 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 15 });
                    }
                    if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "MP5")
                    {
                        PS3.SetMemory(num7 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x11 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "UMP45")
                    {
                        PS3.SetMemory(num7 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x15 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "PP90M1")
                    {
                        PS3.SetMemory(num7 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 20 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "P90")
                    {
                        PS3.SetMemory(num7 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x13 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "PM-9")
                    {
                        PS3.SetMemory(num7 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x12 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "MP7")
                    {
                        PS3.SetMemory(num7 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x16 });
                    }
                    if (this.Mw32Scopes_Scope1.SelectedItem.ToString() == "Red Dot Sight")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 1 });
                    }
                    else if (this.Mw32Scopes_Scope1.SelectedItem.ToString() == "ACOG Scope")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                    }
                    else if (this.Mw32Scopes_Scope1.SelectedItem.ToString() == "Holographic Sight")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 11 });
                    }
                    else if (this.Mw32Scopes_Scope1.SelectedItem.ToString() == "Thermal")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 5 });
                    }
                    if (this.Mw32Scopes_Scope2.Text == "Hybrid Sight")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x15 });
                    }
                    else if (this.Mw32Scopes_Scope2.Text == "Hamr Scope")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 20 });
                    }
                    if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "None")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[1]);
                    }
                    else if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "TARGET DOT")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 1 });
                    }
                    else if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "DELTA")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                    }
                    else if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "U-DOT")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 3 });
                    }
                    else if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "MIL-DOT")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 4 });
                    }
                    else if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "OMEGA")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 5 });
                    }
                    else if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "LAMBDA")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 6 });
                    }
                    if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "None")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[1]);
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Classic")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 1 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Snow")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Multicam")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 3 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Digital Urban")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 4 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Hex")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 5 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Choco")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 6 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Snake")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 8 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Blue")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 10 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Red")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 11 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Autunm")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 12 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Gold")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 13 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Marine")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 7 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Winter")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 9 });
                    }
                    PS3.SetMemory(num2 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x39 });
                }
                else if (this.Mw3ClassModdingStatus.SelectedItem.ToString() == "Split Screen")
                {
                    uint num8 = 0x1c1c809;
                    num2 = num8 + 8;
                    num3 = num8 + 2;
                    num4 = num8 + 4;
                    num5 = num8 + 10;
                    num6 = num8 + 6;
                    if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "M4A1")
                    {
                        PS3.SetMemory(num8 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 9 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "M16A4")
                    {
                        PS3.SetMemory(num8 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 11 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "SCAR-L")
                    {
                        PS3.SetMemory(num8 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 14 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "CM901")
                    {
                        PS3.SetMemory(num8 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x10 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "Type 95")
                    {
                        PS3.SetMemory(num8 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 8 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "G36C")
                    {
                        PS3.SetMemory(num8 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 13 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "ACR 6.8")
                    {
                        PS3.SetMemory(num8 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 7 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "AK-47")
                    {
                        PS3.SetMemory(num8 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 10 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "MK14")
                    {
                        PS3.SetMemory(num8 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 12 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "FAD")
                    {
                        PS3.SetMemory(num8 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 15 });
                    }
                    if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "MP5")
                    {
                        PS3.SetMemory(num8 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x11 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "UMP45")
                    {
                        PS3.SetMemory(num8 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x15 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "PP90M1")
                    {
                        PS3.SetMemory(num8 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 20 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "P90")
                    {
                        PS3.SetMemory(num8 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x13 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "PM-9")
                    {
                        PS3.SetMemory(num8 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x12 });
                    }
                    else if (this.Mw32Scopes_Weapon.SelectedItem.ToString() == "MP7")
                    {
                        PS3.SetMemory(num8 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x16 });
                    }
                    if (this.Mw32Scopes_Scope1.SelectedItem.ToString() == "Red Dot Sight")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 1 });
                    }
                    else if (this.Mw32Scopes_Scope1.SelectedItem.ToString() == "ACOG Scope")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                    }
                    else if (this.Mw32Scopes_Scope1.SelectedItem.ToString() == "Holographic Sight")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 11 });
                    }
                    else if (this.Mw32Scopes_Scope1.SelectedItem.ToString() == "Thermal")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 5 });
                    }
                    if (this.Mw32Scopes_Scope2.Text == "Hybrid Sight")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x15 });
                    }
                    else if (this.Mw32Scopes_Scope2.Text == "Hamr Scope")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 20 });
                    }
                    if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "None")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[1]);
                    }
                    else if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "TARGET DOT")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 1 });
                    }
                    else if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "DELTA")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                    }
                    else if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "U-DOT")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 3 });
                    }
                    else if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "MIL-DOT")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 4 });
                    }
                    else if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "OMEGA")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 5 });
                    }
                    else if (this.Mw32Scopes_Reticle.SelectedItem.ToString() == "LAMBDA")
                    {
                        PS3.SetMemory(num5 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 6 });
                    }
                    if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "None")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[1]);
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Classic")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 1 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Snow")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 2 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Multicam")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 3 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Digital Urban")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 4 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Hex")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 5 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Choco")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 6 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Snake")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 8 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Blue")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 10 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Red")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 11 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Autunm")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 12 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Gold")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 13 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Marine")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 7 });
                    }
                    else if (this.Mw32Scopes_Camo.SelectedItem.ToString() == "Winter")
                    {
                        PS3.SetMemory(num6 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 9 });
                    }
                    PS3.SetMemory(num2 + ((uint)(this.Mw32Scopes_ClassNum.SelectedIndex * 0x62)), new byte[] { 0x39 });
                }
            }
            catch
            {
            }
        }

        private void Mw3GMClass_WeaponType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Mw3GMClass_WeaponType.SelectedItem.ToString() == "Assault Rifle")
            {
                this.Mw3GMClass_Weapon.ResetText();
                System.Threading.Thread.Sleep(100);
                this.Mw3GMClass_Weapon.Text = "Weapon";
                try
                {
                    this.Mw3GMClass_Weapon.Items.Remove("Choose Weapon Type");
                }
                catch
                {
                }
                try
                {
                    this.Mw3GMClass_Weapon.Items.Remove("MP5");
                    this.Mw3GMClass_Weapon.Items.Remove("UMP45");
                    this.Mw3GMClass_Weapon.Items.Remove("PP90M1");
                    this.Mw3GMClass_Weapon.Items.Remove("P90");
                    this.Mw3GMClass_Weapon.Items.Remove("PM-9");
                    this.Mw3GMClass_Weapon.Items.Remove("MP7");
                }
                catch
                {
                }
                this.Mw3GMClass_Weapon.Items.Add("M4A1");
                this.Mw3GMClass_Weapon.Items.Add("M16A4");
                this.Mw3GMClass_Weapon.Items.Add("SCAR-L");
                this.Mw3GMClass_Weapon.Items.Add("CM901");
                this.Mw3GMClass_Weapon.Items.Add("Type 95");
                this.Mw3GMClass_Weapon.Items.Add("G36C");
                this.Mw3GMClass_Weapon.Items.Add("ACR 6.8");
                this.Mw3GMClass_Weapon.Items.Add("MK14");
                this.Mw3GMClass_Weapon.Items.Add("AK-47");
                this.Mw3GMClass_Weapon.Items.Add("FAD");
            }
            if (this.Mw3GMClass_WeaponType.SelectedItem.ToString() == "Sub Machine Gun")
            {
                this.Mw3GMClass_Weapon.ResetText();
                System.Threading.Thread.Sleep(100);
                this.Mw3GMClass_Weapon.Text = "Weapon";
                try
                {
                    this.Mw3GMClass_Weapon.Items.Remove("Choose Weapon Type");
                }
                catch
                {
                }
                try
                {
                    this.Mw3GMClass_Weapon.Items.Remove("M4A1");
                    this.Mw3GMClass_Weapon.Items.Remove("M16A4");
                    this.Mw3GMClass_Weapon.Items.Remove("SCAR-L");
                    this.Mw3GMClass_Weapon.Items.Remove("CM901");
                    this.Mw3GMClass_Weapon.Items.Remove("Type 95");
                    this.Mw3GMClass_Weapon.Items.Remove("G36C");
                    this.Mw3GMClass_Weapon.Items.Remove("ACR 6.8");
                    this.Mw3GMClass_Weapon.Items.Remove("MK14");
                    this.Mw3GMClass_Weapon.Items.Remove("AK-47");
                    this.Mw3GMClass_Weapon.Items.Remove("FAD");
                }
                catch
                {
                }
                this.Mw3GMClass_Weapon.Items.Add("MP5");
                this.Mw3GMClass_Weapon.Items.Add("UMP45");
                this.Mw3GMClass_Weapon.Items.Add("PP90M1");
                this.Mw3GMClass_Weapon.Items.Add("P90");
                this.Mw3GMClass_Weapon.Items.Add("PM-9");
                this.Mw3GMClass_Weapon.Items.Add("MP7");
            }
        }

        private void button95_Click(object sender, EventArgs e)
        {
            try
            {
                uint num2;
                if (this.Mw3ClassModdingStatus.SelectedItem.ToString() == "Online")
                {
                    uint num = 0x1c19810;
                    num2 = num + 6;
                    if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "M4A1")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 9 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "M16A4")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 11 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "SCAR-L")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 14 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "CM901")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 0x10 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "Type 95")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 8 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "G36C")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 13 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "ACR 6.8")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 7 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "AK-47")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 10 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "MK14")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 12 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "FAD")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 15 });
                    }
                    if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "MP5")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 0x11 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "UMP45")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 0x15 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "PP90M1")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 20 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "P90")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 0x13 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "PM-9")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 0x12 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "MP7")
                    {
                        PS3.SetMemory(num + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 0x16 });
                    }
                    if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "None")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[1]);
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Classic")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 1 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Snow")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 2 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Multicam")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 3 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Digital Urban")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 4 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Hex")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 5 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Choco")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 6 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Snake")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 8 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Blue")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 10 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Red")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 11 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Autunm")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 12 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Gold")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 13 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Marine")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 7 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Winter")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 9 });
                    }
                    PS3.SetMemory((uint)(0x1c19865 + (0x62 * this.Mw3GMClass_CustomClass.SelectedIndex)), new byte[] { 
                        1, 0x27, 0, 9, 0, 0, 0, 0, 0, 0x86, 0, 0, 0, 7, 0, 9, 
                        0, 0, 0, 0, 0, 0x86, 0, 0, 0, 0x6a, 0, 15, 0, 0x11, 0, 8, 
                        0, 0, 0, 0x61, 0, 0x83, 0, 0, 0, 0x73, 0x77, 0x61, 0x67, 0x2e, 0x63, 0x6c, 
                        0x61, 0x73, 0x73, 0, 0x73, 0x73, 0x20, 50, 0, 0x54, 0x20, 0x31, 0, 0, 0x76, 0, 
                        0x20, 0, 0x20, 0, 0x20, 0, 0x13, 0, 20, 0, 0x19, 0, 0x2d, 0, 0x26, 0, 
                        0x27, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0x6b, 0, 0, 0, 
                        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x37
                     });
                }
                else if (this.Mw3ClassModdingStatus.SelectedItem.ToString() == "Private Match")
                {
                    uint num3 = 0x1c19dce;
                    num2 = num3 + 6;
                    if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "M4A1")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 9 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "M16A4")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 11 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "SCAR-L")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 14 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "CM901")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 0x10 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "Type 95")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 8 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "G36C")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 13 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "ACR 6.8")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 7 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "AK-47")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 10 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "MK14")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 12 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "FAD")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 15 });
                    }
                    if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "MP5")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 0x11 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "UMP45")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 0x15 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "PP90M1")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 20 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "P90")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 0x13 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "PM-9")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 0x12 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "MP7")
                    {
                        PS3.SetMemory(num3 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 0x16 });
                    }
                    if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "None")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[1]);
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Classic")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 1 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Snow")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 2 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Multicam")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 3 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Digital Urban")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 4 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Hex")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 5 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Choco")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 6 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Snake")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 8 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Blue")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 10 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Red")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 11 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Autunm")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 12 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Gold")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 13 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Marine")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 7 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Winter")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 9 });
                    }
                    PS3.SetMemory((uint)(0x1c19dc1 + (0x62 * this.Mw3GMClass_CustomClass.SelectedIndex)), new byte[] { 
                        1, 0x27, 0, 9, 0, 0, 0, 0, 0, 0x86, 0, 0, 0, 7, 0, 9, 
                        0, 0, 0, 0, 0, 0x86, 0, 0, 0, 0x6a, 0, 15, 0, 0x11, 0, 8, 
                        0, 0, 0, 0x61, 0, 0x83, 0, 0, 0, 0x73, 0x77, 0x61, 0x67, 0x2e, 0x63, 0x6c, 
                        0x61, 0x73, 0x73, 0, 0x73, 0x73, 0x20, 50, 0, 0x54, 0x20, 0x31, 0, 0, 0x76, 0, 
                        0x20, 0, 0x20, 0, 0x20, 0, 0x13, 0, 20, 0, 0x19, 0, 0x2d, 0, 0x26, 0, 
                        0x27, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0x6b, 0, 0, 0, 
                        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x37
                     });
                }
                else if (this.Mw3ClassModdingStatus.SelectedItem.ToString() == "Split Screen")
                {
                    uint num4 = 0x1c1c808;
                    num2 = num4 + 6;
                    if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "M4A1")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 9 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "M16A4")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 11 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "SCAR-L")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 14 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "CM901")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 0x10 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "Type 95")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 8 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "G36C")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 13 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "ACR 6.8")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 7 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "AK-47")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 10 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "MK14")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 12 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "FAD")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 15 });
                    }
                    if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "MP5")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 0x11 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "UMP45")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 0x15 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "PP90M1")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 20 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "P90")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 0x13 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "PM-9")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 0x12 });
                    }
                    else if (this.Mw3GMClass_Weapon.SelectedItem.ToString() == "MP7")
                    {
                        PS3.SetMemory(num4 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 0x16 });
                    }
                    if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "None")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[1]);
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Classic")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 1 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Snow")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 2 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Multicam")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 3 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Digital Urban")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 4 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Hex")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 5 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Choco")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 6 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Snake")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 8 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Blue")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 10 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Red")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 11 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Autunm")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 12 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Gold")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 13 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Marine")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 7 });
                    }
                    else if (this.Mw3GMClass_Camo.SelectedItem.ToString() == "Winter")
                    {
                        PS3.SetMemory(num2 + ((uint)(this.Mw3GMClass_CustomClass.SelectedIndex * 0x62)), new byte[] { 9 });
                    }
                    PS3.SetMemory((uint)(0x1c19dc1 + (0x62 * this.Mw3GMClass_CustomClass.SelectedIndex)), new byte[] { 
                        1, 0x27, 0, 9, 0, 0, 0, 0, 0, 0x86, 0, 0, 0, 7, 0, 9, 
                        0, 0, 0, 0, 0, 0x86, 0, 0, 0, 0x6a, 0, 15, 0, 0x11, 0, 8, 
                        0, 0, 0, 0x61, 0, 0x83, 0, 0, 0, 0x73, 0x77, 0x61, 0x67, 0x2e, 0x63, 0x6c, 
                        0x61, 0x73, 0x73, 0, 0x73, 0x73, 0x20, 50, 0, 0x54, 0x20, 0x31, 0, 0, 0x76, 0, 
                        0x20, 0, 0x20, 0, 0x20, 0, 0x13, 0, 20, 0, 0x19, 0, 0x2d, 0, 0x26, 0, 
                        0x27, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0x6b, 0, 0, 0, 
                        0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x37
                     });
                }
            }
            catch
            {
                MessageBox.Show("No Weapon | Camo Choosed!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
        private static class Gen
        {
            private static Random rand = new Random();

            public static char Par1()
            {
                char[] chArray = "3B21CE7F".ToCharArray();
                int index = rand.Next(chArray.Length);
                return chArray[index];
            }

            public static char Par2()
            {
                char[] chArray = "86C4F90B12".ToCharArray();
                int index = rand.Next(chArray.Length);
                return chArray[index];
            }

            public static char Par3()
            {
                char[] chArray = "29CD153A67".ToCharArray();
                int index = rand.Next(chArray.Length);
                return chArray[index];
            }

            public static char Par4()
            {
                char[] chArray = "1A3EDB98".ToCharArray();
                int index = rand.Next(chArray.Length);
                return chArray[index];
            }

            public static char Par5()
            {
                char[] chArray = "480A2FB".ToCharArray();
                int index = rand.Next(chArray.Length);
                return chArray[index];
            }

            public static char Par6()
            {
                char[] chArray = "9F75A8BE64D".ToCharArray();
                int index = rand.Next(chArray.Length);
                return chArray[index];
            }

            public static char Par7()
            {
                char[] chArray = "897C1AFE".ToCharArray();
                int index = rand.Next(chArray.Length);
                return chArray[index];
            }

            public static char Par8()
            {
                char[] chArray = "A7FB49683C".ToCharArray();
                int index = rand.Next(chArray.Length);
                return chArray[index];
            }

            public static char Par9()
            {
                char[] chArray = "85362ACBFED".ToCharArray();
                int index = rand.Next(chArray.Length);
                return chArray[index];
            }

            public static string Part1()
            {
                return "00000001008";
            }

            public static char Part2()
            {
                char[] chArray = "58C".ToCharArray();
                int index = rand.Next(chArray.Length);
                return chArray[index];
            }

            public static string Part3()
            {
                return "000";
            }

            public static char Part4()
            {
                char[] chArray = "5B".ToCharArray();
                int index = rand.Next(chArray.Length);
                return chArray[index];
            }

            public static string Part5()
            {
                return "140";
            }

            public static char Part6()
            {
                char[] chArray = "24D60318537".ToCharArray();
                int index = rand.Next(chArray.Length);
                return chArray[index];
            }

            public static char Part7()
            {
                char[] chArray = "B863DE257C1".ToCharArray();
                int index = rand.Next(chArray.Length);
                return chArray[index];
            }

            public static char Part8()
            {
                char[] chArray = "3EA7FB596C".ToCharArray();
                int index = rand.Next(chArray.Length);
                return chArray[index];
            }

            public static char Part9()
            {
                char[] chArray = "D304A5C82E".ToCharArray();
                int index = rand.Next(chArray.Length);
                return chArray[index];
            }
        }

        private void button322_Click(object sender, EventArgs e)
        {
            
        }

        private void button322_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button96_Click(object sender, EventArgs e)
        {
           
        }

        private void button97_Click(object sender, EventArgs e)
        {
          
        }

        private void button98_Click(object sender, EventArgs e)
        {
            
        }
    
        private void button100_Click(object sender, EventArgs e)
        {
          
            }

        private void button99_Click(object sender, EventArgs e)
        {

        }

        private void button99_Click_1(object sender, EventArgs e)
        {
            PS3.SetMemory(0x1c1947c, new byte[] { 21 });
        }

        private void timer83_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            byte[] bytes = BitConverter.GetBytes(random.Next(0, 0x1a));
            Array.Resize<byte>(ref bytes, bytes.Length - 2);
            PS3.SetMemory(0x1c1926c + 2, bytes);
            Random random2 = new Random();
            byte[] array = BitConverter.GetBytes(random2.Next(0, 0xff));
            Array.Resize<byte>(ref array, array.Length - 2);
            PS3.SetMemory(0x1c1926c + 1, array);
        }

        private void button100_Click_1(object sender, EventArgs e)
        {
            timer83.Start();
        }

        private void button97_Click_1(object sender, EventArgs e)
        {
            timer83.Stop();
        }

        private void button96_Click_1(object sender, EventArgs e)
        {
            PS3.SetMemory(0x1c1926c, new byte[] { 0x18, 0xa5, 0x1a, 0 });
        }

        private void button101_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x1c1926c, new byte[] { 0x18, 0xa5, 0x1a, 0 });
        }

        private void button104_Click(object sender, EventArgs e)
        {
            try
            {
                PS3.SetMemory(0x892c14, new byte[] { 1 });
                textBox223.Text = "Unstoppable";
                NameChanger(label00, 0x892c15, "Unstoppable");
                numericUpDown261.Value = 0;
                comboBox56.Text = "Challenge Titles";
                PS3.SetMemory(0x892c30, new byte[] { (byte)numericUpDown261.Value });
                Mw3Titlesnumeric.Value = 159;
                PS3.SetMemory(0x892c30, new byte[] { 0 });
                PS3.SetMemory(0x892c33, new byte[] { 159 });
                PS3.SetMemory(0x892c32, new byte[] { 0 });
            }
            catch { }
        }

        private void metroButton19_Click(object sender, EventArgs e)
        {

        }

        private void button103_Click(object sender, EventArgs e)
        {
            try
            {
                PS3.SetMemory(0x892c14, new byte[] { 1 });
                textBox223.Enabled = true;
                comboBox56.Enabled = true;
                button106.Enabled = true;
                label547.Enabled = true;
                Mw3Titlesnumeric.Enabled = true;
                numericUpDown261.Enabled = true;
                button107.Enabled = true;
                button108.Enabled = true;
                label546.Text = "Elite Clan Title: On";
                label546.ForeColor = Color.Green;
                button103.Enabled = false;
                button105.Enabled = true;
                label531.Text = "Elite Title is On";
                label531.ForeColor = Color.Green;
                if (comboBox56.SelectedItem.ToString() == "Challenge Titles")
                {
                    Mw3EliteTitles.Enabled = true;
                }
                else
                {
                    Mw3EliteTitles.Enabled = false;
                }
            }
            catch { }
        }

        private void button105_Click(object sender, EventArgs e)
        {
            try
            {
                PS3.SetMemory(0x892c14, new byte[] { 0 });
                textBox223.Enabled = false;
                comboBox56.Enabled = false;
                numericUpDown261.Enabled = false;
                button107.Enabled = false;
                button108.Enabled = false;
                button106.Enabled = false;
                label547.Enabled = false;
                Mw3Titlesnumeric.Enabled = false;
                label546.Text = "Elite Clan Title: Off";
                label546.ForeColor = Color.Red;
                button103.Enabled = true;
                button105.Enabled = false;
                label531.Text = "Elite Title is Off";
                label531.ForeColor = Color.Red;
                timer81.Stop();
                Mw3EliteTitles.Enabled = true;
            }
            catch { }
        }

        private void timer81_Tick(object sender, EventArgs e)
        {
            try
            {
                Random random = new Random();
                int Level = random.Next(0, 99);
                byte[] Loop = BitConverter.GetBytes(Level);
                Array.Resize(ref Loop, Loop.Length - 3);
                PS3.SetMemory(0x892c30, Loop);
            }
            catch
            {
                label531.ForeColor = System.Drawing.Color.Red;
                label531.Text = "Error!";
            }
        }
        private byte[] EncodingOffset(uint address, string string_)
        {
            byte[] text = Encoding.ASCII.GetBytes(string_);
            ASCIIEncoding encoding = new ASCIIEncoding();
            Array.Resize(ref text, text.Length + 1);
            PS3.SetMemory(address, text);
            return encoding.GetBytes(string_);

        }
        private byte[] DetectButtons(uint offset, string textBox)
        {
            string str = textBox.Replace("[X]", "\x0001").Replace("[O]", "\x0002").Replace("[]", "\x0003")
                .Replace("[Y]", "\x0004").Replace("[L1]", "\x0005").Replace("[R1]", "\x0006").Replace("[L3]", "\x0010")
                .Replace("[R3]", "\x0011").Replace("[L2]", "\x0012").Replace("[R2]", "\x0013").Replace("[UP]", "\x0014")
                .Replace("[DOWN]", "\x0015").Replace("[LEFT]", "\x0016").Replace("[RIGHT]", "\x0017").Replace("[START]", "\x000e")
                .Replace("[SELECT]", "\x000f").Replace("[LINE]", "\n").Replace("[3D]", "\r");
            EncodingOffset(offset, (str));
            ASCIIEncoding encoding = new ASCIIEncoding();
            return encoding.GetBytes(textBox);
        }
        private void NameChange(uint offset, string text)
        {
            byte[] ClanTagEditor = Encoding.ASCII.GetBytes(text);
            Array.Resize(ref ClanTagEditor, ClanTagEditor.Length + 1);
            PS3.SetMemory(offset, ClanTagEditor);

        }
        public static string ButtonDetect = "Detect Buttons - On";
         private void NameChanger(Label label, uint offset, string text)
        {
            if (label.Text == ButtonDetect)
            {
                DetectButtons(offset, text);
            }
            else
            {
                NameChange(offset, text);
            }
        }

        private void button106_Click(object sender, EventArgs e)
        {
            try
            {
                NameChanger(label00,(uint)0x892c15 , (string)textBox223.Text);
            }
            catch { }
        }

        private void comboBox56_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox56.SelectedItem.ToString() == "Challenge Titles")
            {
                Mw3EliteTitles.Enabled = true;
            }
            else
            {
                Mw3EliteTitles.Enabled = false;
            }
            if (comboBox56.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Choose Title!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Mw3Titlesnumeric.Enabled = true;
            }
            else if (comboBox56.SelectedItem.ToString() == "Challenge Titles")
            {
                PS3.SetMemory(0x892c32, new byte[] { 0 });
                Mw3Titlesnumeric.Enabled = true;
            }
            else if (comboBox56.SelectedItem.ToString() == "Weapon Titles")
            {
                PS3.SetMemory(0x892c32, new byte[] { 1 });
                Mw3Titlesnumeric.Enabled = true;
            }
            else if (comboBox56.SelectedItem.ToString() == "Checkerboard")
            {
                PS3.SetMemory(0x892c32, new byte[] { 2 });
                Mw3Titlesnumeric.Enabled = false;
            }
        }

        private void Mw3EliteTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Mw3EliteTitles.SelectedItem.ToString() == "Elite")
                {
                    Mw3Titlesnumeric.Value = 28;
                }
                else if (Mw3EliteTitles.SelectedItem.ToString() == "Premium")
                {
                    Mw3Titlesnumeric.Value = 27;
                }
                else if (Mw3EliteTitles.SelectedItem.ToString() == "Gryphon")
                {
                    Mw3Titlesnumeric.Value = 29;
                }
                else if (Mw3EliteTitles.SelectedItem.ToString() == "Blue Bullet")
                {
                    Mw3Titlesnumeric.Value = 30;
                }
                else if (Mw3EliteTitles.SelectedItem.ToString() == "Wild Life")
                {
                    Mw3Titlesnumeric.Value = 31;
                }
                else if (Mw3EliteTitles.SelectedItem.ToString() == "Gorilla")
                {
                    Mw3Titlesnumeric.Value = 32;
                }
                else if (Mw3EliteTitles.SelectedItem.ToString() == "Horse")
                {
                    Mw3Titlesnumeric.Value = 33;
                }
            }
            catch { MessageBox.Show("Choose Title", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void Mw3Titlesnumeric_ValueChanged(object sender, EventArgs e)
        {
            PS3.SetMemory(0x892c33, new byte[] { (byte)Mw3Titlesnumeric.Value });
        }

        private void button102_Click(object sender, EventArgs e)
        {
            try
            {

                //
                PS3.SetMemory(0x892c14, new byte[] { 1 });
                textBox223.Text = "Over Achiever";
                NameChanger(label00, 0x892c15, "Over Achiever");
                numericUpDown261.Value = 0;
                comboBox56.Text = "Challenge Titles";
                PS3.SetMemory(0x892c30, new byte[] { (byte)numericUpDown261.Value });
                Mw3Titlesnumeric.Value = 160;
                PS3.SetMemory(0x892c30, new byte[] { 0 });
                PS3.SetMemory(0x892c33, new byte[] { 160 });
                PS3.SetMemory(0x892c32, new byte[] { 0 });
            }
            catch { }
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {

        }

        private void button107_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x892c30, new byte[] { (byte)numericUpDown261.Value });
        }
        private bool bool_25;
        private void button108_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bool_25)
                {
                    timer81.Start();
                    bool_25 = true;
                    label531.ForeColor = System.Drawing.Color.Green;
                    label531.Text = "Disco: On";
                }
                else if (bool_25)
                {
                    timer81.Stop();
                    bool_25 = false;
                    label531.ForeColor = System.Drawing.Color.Red;
                    label531.Text = "Disco: Off";
                }
            }
            catch { }
        }

        private void numericUpDown261_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button109_Click(object sender, EventArgs e)
        {

        }

        private void button113_Click(object sender, EventArgs e)
        {
            byte[] buffer1 = Encoding.ASCII.GetBytes("       " + textBox9.Text + "                   ");
            PS3.SetMemory(0x01BBBC2C, buffer1);
            System.Threading.Thread.Sleep(50);
            byte[] NAME1142213 = new byte[] { 94, 54, 15, 15, 15, 13 };
            PS3.SetMemory(0x01BBBC2C, NAME1142213);
        }

        private void textBox9_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button114_Click(object sender, EventArgs e)
        {
            byte[] buffer1 = Encoding.ASCII.GetBytes("       " + textBox9.Text + "                   ");
            PS3.SetMemory(0x01BBBC2C, buffer1);
            System.Threading.Thread.Sleep(50);
            byte[] NAME1142213 = new byte[] { 94, 53, 02, 02, 02, 13 };
            PS3.SetMemory(0x01BBBC2C, NAME1142213);
        }

        private void button111_Click(object sender, EventArgs e)
        {
            byte[] buffer1 = Encoding.ASCII.GetBytes("       " + textBox9.Text + "                   ");
            PS3.SetMemory(0x01BBBC2C, buffer1);
            System.Threading.Thread.Sleep(50);
            byte[] NAME1142213 = new byte[] { 94, 51, 04, 04, 04, 13 };
            PS3.SetMemory(0x01BBBC2C, NAME1142213);
        }

        private void button112_Click(object sender, EventArgs e)
        {
            byte[] buffer1 = Encoding.ASCII.GetBytes("       " + textBox9.Text + "                   ");
            PS3.SetMemory(0x01BBBC2C, buffer1);
            System.Threading.Thread.Sleep(50);
            byte[] NAME1142213 = new byte[] { 94, 50, 03, 03, 03, 13 };
            PS3.SetMemory(0x01BBBC2C, NAME1142213);
        }

        private void button109_Click_1(object sender, EventArgs e)
        {
            byte[] buffer1 = Encoding.ASCII.GetBytes("       " + textBox9.Text + "                   ");
            PS3.SetMemory(0x01BBBC2C, buffer1);
            System.Threading.Thread.Sleep(50);
            byte[] NAME1142213 = new byte[] { 94, 54, 05, 06, 05, 13 };
            PS3.SetMemory(0x01BBBC2C, NAME1142213);
        }

        private void button110_Click(object sender, EventArgs e)
        {
          
                     byte[] buffer1 = Encoding.ASCII.GetBytes("       " + textBox9.Text + "                   ");
            PS3.SetMemory(0x01BBBC2C, buffer1);
            System.Threading.Thread.Sleep(50);
            byte[] NAME1142213 = new byte[] { 94, 50, 16, 17, 13 };
            PS3.SetMemory(0x01BBBC2C, NAME1142213);
        }

        private void button68_Click_1(object sender, EventArgs e)
        {
            PS3.SetMemory(0x892c14, new byte[] { 1 });
            timer38.Start();

        }

        private void timer38_Tick(object sender, EventArgs e)
        {
            byte[] BIG = new byte[] { 0X5E, 0X32, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, };
            PS3.SetMemory(0x892c15, BIG);
            System.Threading.Thread.Sleep(20);
            byte[] BIG1 = new byte[] { 0X5E, 0X32, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, };
            PS3.SetMemory(0x892c15, BIG1);
            System.Threading.Thread.Sleep(20);
            byte[] BIG2 = new byte[] { 0X5E, 0X36, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, };
            PS3.SetMemory(0x892c15, BIG2);
            System.Threading.Thread.Sleep(20);
            byte[] BIG3 = new byte[] { 0X5E, 0X36, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, };
            PS3.SetMemory(0x892c15, BIG3);
            System.Threading.Thread.Sleep(20);
            byte[] BIG4 = new byte[] { 0X5E, 0X30, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X02, 0X80, 0X80, 0X01, 0X01, 0X5E, 0X01, 0X80, 0X80, 0X01, };
            PS3.SetMemory(0x892c15, BIG4);
            System.Threading.Thread.Sleep(20);
        }

        private void button115_Click(object sender, EventArgs e)
        {
          
            timer38.Stop();
        }

        private void button116_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x892c14, new byte[] { 0 });
        }

        private void Mw3ColorClasses_CheckedChanged(object sender, EventArgs e)
        {
            if (Mw3ColorClasses.Checked)
            {
                Mw3AllClasses.Checked = true;
            }
            else
            {
                Mw3AllClasses.Checked = false;
            }
        }

        private void Mw3AllClasses_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (Mw3AllClasses.Checked)
                {
                    numericUpDown285.Enabled = false;
                }
                else
                {
                    numericUpDown285.Enabled = true;
                }
            }
            catch { }
        }
        public static void resetOnlineClasses()
        {
            #region Reset Bytes
            Byte[] reset = new Byte[] { 0x6C, 0, 0x0F, 0, 0x26, 0, 0x94, 0, 0, 0, 0x5E, 0, 0x70, 0, 0, 0, 0x43, 0x75, 0x73,
                            0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x31, 0, 0x6C, 0x79, 0, 0, 0, 0, 0x76, 0, 1, 0, 3,
                            0, 8, 0, 0x16, 0, 0x18, 0, 0x1F, 0, 0x2C, 0, 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0,
                            6, 0, 0, 0, 0, 0, 0, 0, 1, 0x11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x17, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x5C, 0, 0x26, 0, 0x94, 0, 0, 0, 0x5E, 0, 0x6E,
                            0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x32, 0, 0x6C, 0x79, 0, 0, 0,
                            0, 0x76, 0, 1, 0, 3, 0, 8, 0, 0x16, 0, 0x18, 0, 0x1F, 0, 0x2C, 0, 0, 0, 0, 0, 2, 0,
                            0, 0, 4, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 1, 0x25, 0, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0x37, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x0F, 0, 0x4E, 0, 0x4A,
                            0, 0, 0, 0x5F, 0, 0x6E, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x33,
                            0, 0x6C, 0x79, 0, 0, 0, 0, 0x76, 0, 6, 0, 9, 0, 0x0D, 0, 0x13, 0, 0x17, 0, 0x19, 0, 0x29, 0,
                            0x27, 0, 0x2F, 0, 1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 1, 0x27, 0,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 
                            0, 0x5C, 0, 0x26, 0, 0x94, 0, 0, 0, 0x5E, 0, 0x6E, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43,
                            0x6C, 0x61, 0x73, 0x73, 0x20, 0x34, 0, 0x6C, 0x79, 0, 0, 0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 0x16, 0,
                            0x18, 0, 0x1F, 0, 0x2C, 0, 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0, 0, 0,
                            0, 0, 0, 1, 0x20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x17, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0x6C, 0, 0x0F, 0, 0x4E, 0, 0x4A, 0, 0, 0, 0x5F, 0, 0x70, 0, 0, 0, 0x43, 0x75,
                            0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x35, 0, 0x6C, 0x79, 0, 0, 0, 0, 0x76, 0, 1, 0,
                            3, 0, 8, 0, 0x13, 0, 0x17, 0, 0x19, 0, 0x2C, 0, 0x22, 0, 0x28, 0, 1, 0, 0, 0, 2, 0, 0,
                            0, 3, 0, 0x4F, 0, 0, 0, 0, 0, 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x0F, 0, 0x26, 0, 0x94, 0, 0, 0, 0x5E, 0,
                            0x70, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x36, 0, 0x6C, 0x79, 0, 0,
                            0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 3, 0, 0x0E, 0, 0x12, 0, 0x2C, 0, 0x22, 0, 0x28, 0, 1,
                            0, 0, 0, 2, 0, 0, 0, 3, 0, 0x4F, 0, 0, 0, 0, 0, 1, 0x11, 0, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0x17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x5C, 0, 0x26, 0,
                            0x94, 0, 0, 0, 0x5E, 0, 0x6E, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20,
                            0x37, 0, 0x6C, 0x79, 0, 0, 0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 3, 0, 0x0E, 0, 0x12, 0, 0x2C,
                            0, 0x22, 0, 0x28, 0, 1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0x4F, 0, 0, 0, 0, 0, 1, 0x25,
                            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x37, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0x6C, 0, 0x0F, 0, 0x4E, 0, 0x4A, 0, 0, 0, 0x5F, 0, 0x6E, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20,
                            0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x38, 0, 0, 0, 0, 0, 0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 0x13, 
                            0, 0x17, 0, 0x19, 0, 0x2C, 0, 0x22, 0, 0x28, 0, 1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0x4F, 0, 
                            0, 0, 0, 0, 1, 0x27, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x5C, 0, 0x26, 0, 0x94, 0, 0, 0, 0x5E, 0, 0x6E, 0, 0, 0, 0x43, 
                            0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x39, 0, 0, 0, 0, 0, 0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 3, 0, 0x0E, 0, 0x12, 0, 0x2C, 0, 0x22, 0, 0x28, 0, 1, 0, 0, 0, 2, 0,
                            0, 0, 3, 0, 0x4F, 0, 0, 0, 0, 0, 1, 0x20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0x17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x0F, 0, 0x4E, 0, 0x4A, 0, 0, 0, 0x5F,
                            0, 0x70, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x31, 0x30, 0, 0, 0,
                            0, 0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 0x13, 0, 0x17, 0, 0x19, 0, 0x2C, 0, 0x22, 0, 0x28, 0,
                            1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0x4F, 0, 0, 0, 0, 0, 1, 9, 0, 0, 0, 0, 0,
                            0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x0F, 0, 0x26, 
                            0, 0x94, 0, 0, 0, 0x5E, 0, 0x70, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73,
                            0x20, 0x31, 0x31, 0, 0, 0, 0, 0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 3, 0, 0x0E, 0, 0x12, 0,
                            0x2C, 0, 0x22, 0, 0x28, 0, 1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0x4F, 0, 0, 0, 0, 0, 1,
                            0x11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                            0, 0x6C, 0, 0x5C, 0, 0x26, 0, 0x94, 0, 0, 0, 0x5E, 0, 0x6E, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x31, 0x32,
                            0, 0, 0, 0, 0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 3, 0, 0x0E, 0, 0x12, 0, 0x2C, 0, 0x22, 0, 0x28, 0, 1, 0, 0, 0, 2, 0, 0, 0, 3, 0, 0x4F, 0, 0,
                            0, 0, 0, 1, 0x25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x37, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x0F, 0, 0x4E, 0, 0x4A, 0, 0, 0, 0x5F, 0, 0x6E, 0, 0, 0, 
                            0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x31, 0x33, 0, 0, 0, 0, 0, 0, 0x76, 0, 6, 0, 9, 0, 0x0D, 0, 0x13, 0, 0x17, 0, 
                            0x19, 0, 0x27, 0, 0x25, 0, 0x24, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 1, 0x27, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 
                            0, 0, 0, 0, 0, 0x6C, 0, 0x5C, 0, 0x26, 0, 0x94, 0, 0, 0, 0x5E, 0, 0x6E, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x31,
                            0x34, 0, 0, 0, 0, 0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 2, 0, 0x16, 0, 7, 0, 0x22, 0, 0x2D, 0, 0x21, 0, 1, 0x2D, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x16,
                            0, 0x0A, 1, 0x20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x0F, 0, 0x4E, 0, 0x4A, 0, 0, 0, 0x5F, 0, 0x70, 0, 0, 0, 0x43,
                            0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x31, 0x35, 0, 0, 0, 0, 0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 0x13, 0, 0x17, 0, 0x19, 0, 
                            0x21, 0, 0x22, 0, 0x28, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0x4C, 0, 0, 0x11, 0, 0x4A, 3, 0x28, 0, 9, 0, 0, 0, 0x0D, 0, 0x85, 0, 0, 0, 6, 0, 9, 0, 
                            0, 0, 0, 0, 0, 0, 0, 0, 0x6A };
            #endregion

            PS3.SetMemory(0x01c1981c, reset);
        }
        private void button118_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox57.SelectedItem.ToString() == "Online")
                {
                resetOnlineClasses();
                }
                else if (comboBox57.SelectedItem.ToString() == "Private Match")
                {
                  resetPVTMatchClasses();
                }
                else if (comboBox57.SelectedItem.ToString() == "Split Screen")
                {
                   resetSplitScreenClasses();
                }
                else
                {
                    MessageBox.Show("Game Not Attach | PS3 Not Connected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch { MessageBox.Show("Game Not Attach | PS3 Not Connected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); }
        }
        #region resetPVTMatchClasses
        public static void resetPVTMatchClasses()
        {
            Byte[] reset = new Byte[] { 1, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x0F, 0, 0x26, 0, 0x94,
                                0, 0, 0, 0x5E, 0, 0x70, 0, 0x61, 0x53, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x31, 0, 0x6C, 0x79, 0, 1,
                                0x2D, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 0x13, 0, 0x17, 0, 0x19, 0, 0x26, 0, 0x21, 0, 0x23, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0x61, 0,
                                0x65, 0x11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x5C, 0, 0x26, 0, 0x94, 0, 0x4F, 0x44, 0x5E,
                                0, 0x6E, 0, 0x46, 0x72, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x32, 0, 0x6C, 0x79, 0, 0,
                                0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 0x13, 0, 0x17, 0, 0x19, 0, 0x22, 0, 0x21, 0, 0x28, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0x4C, 0,
                                0x11, 0, 0x4A, 0, 1, 0x25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x37, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x0F, 0, 0x4E, 0,
                                0x4A, 0, 0, 0, 0x5F, 0, 0x6E, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 
                                0x20, 0x33, 0, 0x6C, 0x79, 0, 0, 0x5E, 0, 0x76, 0, 0, 0, 3, 0, 8, 0, 0x13, 0, 0x17, 0, 0x19, 0, 0x22, 0, 0x21, 0, 0x28, 0, 2, 0, 0, 0, 4, 0, 0, 0,
                                6, 0, 0x4C, 0, 0, 0, 0, 0, 1, 0x27, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x5C, 0, 0x26, 0, 
                                0x94, 0, 0, 0, 0x5E, 0, 0x6E, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x34, 0, 0x6C,
                                0x79, 0, 0x4E, 0x6F, 0x6F, 0x76, 0, 1, 0, 3, 0, 8, 0, 0x13, 0, 0x17, 0, 0x19, 0, 0x22, 0, 0x21, 0, 0x28,
                                0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0x4C, 0, 0x11, 0, 0x4A, 0, 1, 0x20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                                0x17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x0F, 0, 0x4E, 0, 0x4A, 0, 0, 0, 0x5F, 0, 0x70, 0, 0, 0, 0x43, 0x75, 0x73, 
                                0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x35, 0, 0x6C, 0x79, 0, 0, 0, 0, 0x76 };
            PS3.SetMemory(0x01c19dc1, reset);
        }
        #endregion
        #region resetSplitScreenClasses
        public static void resetSplitScreenClasses()
        {
            Byte[] reset = new Byte[] { 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1,
                                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 15, 0, 0x26, 0,
                                0x94, 0, 0, 0, 0x5E, 0, 0x70, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 
                                0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x31, 0, 0, 0, 0, 0, 0, 0, 0x76, 0, 1,
                                0, 3, 0, 8, 0, 19, 0, 23, 0, 25, 0, 0, 0, 0, 0, 0, 0,
                                2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 1, 17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                                23, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x5C, 0, 0x26, 0, 0x94, 0, 0, 0, 0x5E, 0, 0x6E, 0, 0, 
                                0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x32, 0, 0, 0, 0, 0, 
                                0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 19, 0, 23, 0, 25, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0, 
                                0, 0, 0, 0, 0, 1, 0x25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x37, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 
                                15, 0, 0x4E, 0, 0x4A, 0, 0, 0, 0x5F, 0, 0x6E, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D,
                                0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x33, 0, 0, 0, 0, 0, 0, 0, 0x76, 0, 1, 0, 3, 0, 8,
                                0, 19, 0, 23, 0, 25, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 1, 
                                0x27, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x5C, 0,
                                0x26, 0, 0x94, 0, 0, 0, 0x5E, 0, 0x6E, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D,
                                0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x34, 0, 0, 0, 0, 0, 0, 0, 0x76, 0, 1, 0,
                                3, 0, 8, 0, 19, 0, 23, 0, 25, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0, 
                                0, 0, 0, 0, 0, 1, 0x20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 23, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 
                                0, 15, 0, 0x4E, 0, 0x4A, 0, 0, 0, 0x5F, 0, 0x70, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43,
                                0x6C, 0x61, 0x73, 0x73, 0x20, 0x35, 0, 0, 0, 0, 0, 0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 19, 0, 23, 0, 25, 0, 0,
                                0, 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                                1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 15, 0, 0x26, 0, 0x94, 0, 0, 0, 0x5E, 0, 0x70, 0, 0
                                , 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x36, 0, 0, 0, 0, 0, 0, 0, 0x76,
                                0, 1, 0, 3, 0, 8, 0, 19, 0, 23, 0, 25, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 17, 0,
                                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 23, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x5C, 0, 0x26, 0, 0x94, 0, 0, 0, 0x5E, 0,
                                0x6E, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x37, 0, 0, 0, 0, 0, 0, 0
                                , 0x76, 0, 1, 0, 3, 0, 8, 0, 19, 0, 23, 0, 25, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0,
                                0x25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x37, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 15, 0, 0x4E, 0, 0x4A, 0, 0, 0, 
                                0x5F, 0, 0x6E, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x38, 0, 0, 0, 0
                                , 0, 0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 19, 0, 23, 0, 25, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0, 0, 0, 0,
                                0, 0, 0, 0x27, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x5C, 0, 0x26, 0, 0x94, 0
                                , 0, 0, 0x5E, 0, 0x6E, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x39, 0,
                                0, 0, 0, 0, 0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 19, 0, 23, 0, 25, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6,
                                0, 0, 0, 0, 0, 0, 0, 0, 0x20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 23, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 15, 0,
                                0x4E, 0, 0x4A, 0, 0, 0, 0x5F, 0, 0x70, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73,
                                0x20, 0x31, 0x30, 0, 0, 0, 0, 0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 19, 0, 23, 0, 25, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 
                                4, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0,
                                0, 0, 0, 0, 0x6C, 0, 15, 0, 0x26, 0, 0x94, 0, 0, 0, 0x5E, 0, 0x70, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20
                                , 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x31, 0x31, 0, 0, 0, 0, 0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 19, 0, 23, 0, 25, 0,
                                0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 23, 0, 0, 
                                0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x5C, 0, 0x26, 0, 0x94, 0, 0, 0, 0x5E, 0, 0x6E, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 
                                0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x31, 0x32, 0, 0, 0, 0, 0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 19, 0,
                                23, 0, 25, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0x25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
                                , 0, 0x37, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 15, 0, 0x4E, 0, 0x4A, 0, 0, 0, 0x5F, 0, 0x6E, 0, 0, 0, 0x43,
                                0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x31, 0x33, 0, 0, 0, 0, 0, 0, 0x76, 0, 1,
                                0, 3, 0, 8, 0, 19, 0, 23, 0, 25, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0x27, 0, 0,
                                0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 0x5C, 0, 0x26, 0, 0x94, 0, 0, 0, 0x5E, 0,
                                0x6E, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x6D, 0x20, 0x43, 0x6C, 0x61, 0x73, 0x73, 0x20, 0x31, 0x34, 0, 0, 0
                                , 0, 0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 19, 0, 23, 0, 25, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0
                                , 0, 0, 0, 0, 0, 0, 0x20, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 23, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0x6C, 0, 15
                                , 0, 0x4E, 0, 0x4A, 0, 0, 0, 0x5F, 0, 0x70, 0, 0, 0, 0x43, 0x75, 0x73, 0x74, 0x6F, 0x30, 0x30, 0x30, 0x30,
                                0x30, 0x30, 0x73, 0x20, 0x31, 0x35, 0, 0, 0, 0, 0, 0, 0x76, 0, 1, 0, 3, 0, 8, 0, 19, 0, 23, 0, 25, 0, 0, 0
                                , 0, 0, 0, 0, 2, 0, 0, 0, 4, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0,
                                0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            PS3.SetMemory(0x01c1c809, reset);
        }
        private static void ChangeName(UInt32 address, string text)
        {
            Byte[] name = Encoding.ASCII.GetBytes(text);
            Array.Resize(ref name, name.Length + 1);
            PS3.SetMemory(address, name);
        }
        #endregion
                  public static UInt32 AllClients = 18;
                  public static UInt32 client = 0;

     
  #region ChangeClassName_Online
                        public static void ChangeClassName_Online(UInt32 client, string text)
                        {
                            if (client == AllClients)
                            {
                                for (UInt32 i = 0; i < 15; i++)
                                {
                                    ChangeName(0x1c1982c + (i * 0x62), text);
                                }
                            }
                            else
                            {
                                ChangeName(0x1c1982c + (client * 0x62), text);
                            }
                        }
                        #endregion
                        #region ChangeClassName_PVTMatch
                        public static void ChangeClassName_PVTMatch(UInt32 client, string text)
                        {
                            if (client == AllClients)
                            {
                                for (UInt32 i = 0; i < 5; i++)
                                {
                                    ChangeName(0x1c19dea + (i * 0x62), text);
                                }
                            }
                            else
                            {
                                ChangeName(0x1c19dea + (client * 0x62), text);
                            }
                        }
                        #endregion
                        #region ChangeClassName_SplitScreen
                        public static void ChangeClassName_SplitScreen(UInt32 client, string text)
                        {
                            if (client == AllClients)
                            {
                                for (UInt32 i = 0; i < 5; i++)
                                {
                                    ChangeName(0x1c1c831 + (i * 0x62), text);
                                }
                            }
                            else
                            {
                                ChangeName(0x1c1c831 + (client * 0x62), text);
                            }
                        }
                        #endregion
        private void button117_Click(object sender, EventArgs e)
        {
            try
            {
                if (Mw3ColorClasses.Checked)
                {
                    if (comboBox57.SelectedItem.ToString() == "Online")
                    {
                        ChangeClassName_Online(0, "^1" + Mw3ClassName.Text);
                        ChangeClassName_Online(1, "^2" + Mw3ClassName.Text);
                        ChangeClassName_Online(2, "^3" + Mw3ClassName.Text);
                        ChangeClassName_Online(3, "^4" + Mw3ClassName.Text);
                        ChangeClassName_Online(4, "^5" + Mw3ClassName.Text);
                        ChangeClassName_Online(5, "^6" + Mw3ClassName.Text);
                        ChangeClassName_Online(6, "^1" + Mw3ClassName.Text);
                        ChangeClassName_Online(7, "^2" + Mw3ClassName.Text);
                        ChangeClassName_Online(8, "^3" + Mw3ClassName.Text);
                        ChangeClassName_Online(9, "^4" + Mw3ClassName.Text);
                        ChangeClassName_Online(10, "^5" + Mw3ClassName.Text);
                        ChangeClassName_Online(11, "^6" + Mw3ClassName.Text);
                        ChangeClassName_Online(12, "^1" + Mw3ClassName.Text);
                        ChangeClassName_Online(13, "^2" + Mw3ClassName.Text);
                        ChangeClassName_Online(14, "^3" + Mw3ClassName.Text);
                    }
                    if (comboBox57.SelectedItem.ToString() == "Split Screen")
                    {
                        ChangeClassName_SplitScreen(0, "^1" + Mw3ClassName.Text);
                        ChangeClassName_SplitScreen(1, "^2" + Mw3ClassName.Text);
                        ChangeClassName_SplitScreen(2, "^3" + Mw3ClassName.Text);
                        ChangeClassName_SplitScreen(3, "^4" + Mw3ClassName.Text);
                        ChangeClassName_SplitScreen(4, "^5" + Mw3ClassName.Text);
                        ChangeClassName_SplitScreen(5, "^6" + Mw3ClassName.Text);
                        ChangeClassName_SplitScreen(6, "^1" + Mw3ClassName.Text);
                        ChangeClassName_SplitScreen(7, "^2" + Mw3ClassName.Text);
                        ChangeClassName_SplitScreen(8, "^3" + Mw3ClassName.Text);
                        ChangeClassName_SplitScreen(9, "^4" + Mw3ClassName.Text);
                        ChangeClassName_SplitScreen(10, "^5" + Mw3ClassName.Text);
                        ChangeClassName_SplitScreen(11, "^6" + Mw3ClassName.Text);
                        ChangeClassName_SplitScreen(12, "^1" + Mw3ClassName.Text);
                        ChangeClassName_SplitScreen(13, "^2" + Mw3ClassName.Text);
                        ChangeClassName_SplitScreen(14, "^3" + Mw3ClassName.Text);
                    }
                    if (comboBox57.SelectedItem.ToString() == "Private Match")
                    {
                        ChangeClassName_PVTMatch(0, "^1" + Mw3ClassName.Text);
                        ChangeClassName_PVTMatch(1, "^2" + Mw3ClassName.Text);
                        ChangeClassName_PVTMatch(2, "^3" + Mw3ClassName.Text);
                        ChangeClassName_PVTMatch(3, "^4" + Mw3ClassName.Text);
                        ChangeClassName_PVTMatch(4, "^5" + Mw3ClassName.Text);
                    }
                }
                else
                {
                    if (comboBox57.SelectedItem.ToString() == "Online")
                    {
                        if (Mw3AllClasses.Checked)
                        {
                            ChangeClassName_Online(18, Mw3ClassName.Text);
                        }
                        else
                        {
                            ChangeClassName_Online((uint)numericUpDown285.Value - 1, Mw3ClassName.Text);
                        }
                    }
                    else if (comboBox57.SelectedItem.ToString() == "Private Match")
                    {
                        if (Mw3AllClasses.Checked)
                        {
                            ChangeClassName_PVTMatch(18, Mw3ClassName.Text);
                        }
                        else
                        {
                            ChangeClassName_PVTMatch((uint)numericUpDown285.Value - 1, Mw3ClassName.Text);
                        }
                    }
                    else if (comboBox57.SelectedItem.ToString() == "Split Screen")
                    {
                        if (Mw3AllClasses.Checked)
                        {
                            ChangeClassName_SplitScreen(18, Mw3ClassName.Text);
                        }
                        else
                        {
                            ChangeClassName_SplitScreen((uint)numericUpDown285.Value - 1, Mw3ClassName.Text);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Game Not Attach | PS3 Not Connected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Game Not Attach | PS3 Not Connected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void Mw3ClassName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button562_Click(object sender, EventArgs e)
        {

        }

        private void button119_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Go in private match", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            PS3.SetMemory(0x1811190, new byte[] { 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 10, 0, 0, 0, 0, 0x4d, 80, 0x55, 0x49, 0x5f, 0x52, 0x55, 0x53, 
                0x54, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0x6d, 0x70, 0x5f, 100, 0x6f, 0x6d, 0x65, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0x4d, 80, 0x55, 0x49, 0x5f, 0x44, 0x45, 0x53, 
                0x43, 0x5f, 0x4d, 0x41, 80, 0x5f, 0x44, 0x4f, 0x4d, 0x45, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0x70, 0x72, 0x65, 0x76, 0x69, 0x65, 0x77, 0x5f, 
                0x6d, 0x70, 0x5f, 0x72, 0x75, 0x73, 0x74, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0x6d, 0x61, 0x70, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0x6c, 0x6f, 110, 0x67, 110, 0x61, 0x6d, 0x65, 
                0, 0, 0, 0, 0, 0, 0, 0, 0x67, 0x61, 0x6d, 0x65, 0x74, 0x79, 0x70, 0x65, 
                0, 0, 0, 0, 0, 0, 0, 0, 100, 0x65, 0x73, 0x63, 0x72, 0x69, 0x70, 0x74, 
                0x69, 0x6f, 110, 0, 0, 0, 0, 0, 0x6d, 0x61, 0x70, 0x69, 0x6d, 0x61, 0x67, 0x65, 
                0, 0, 0, 0, 0, 0, 0, 0, 0x6d, 0x61, 0x70, 0x6f, 0x76, 0x65, 0x72, 0x6c, 
                0x61, 0x79, 0, 0, 0, 0, 0, 0, 0x61, 0x6c, 0x6c, 0x69, 0x65, 0x73, 0x63, 0x68, 
                0x61, 0x72, 0, 0, 0, 0, 0, 0, 0x61, 120, 0x69, 0x73, 0x63, 0x68, 0x61, 0x72, 
                0, 0, 0, 0, 0, 0, 0, 0, 0x65, 110, 0x76, 0x69, 0x72, 0x6f, 110, 0x6d, 
                0x65, 110, 0x74, 0, 0, 0, 0, 0, 0x6d, 0x61, 0x70, 0x70, 0x61, 0x63, 0x6b, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0x6d, 0x70, 0x5f, 100, 0x6f, 0x6d, 0x65, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0x4d, 80, 0x55, 0x49, 0x5f, 0x52, 0x55, 0x53, 
                0x54, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 100, 0x6d, 0x20, 0x77, 0x61, 0x72, 0x20, 0x73, 
                0x61, 0x62, 0x20, 0x73, 0x61, 0x62, 50, 0x20, 100, 0x6f, 0x6d, 0x20, 0x73, 100, 0x20, 0x73, 
                100, 50, 0x20, 0x68, 0x63, 0x20, 0x74, 0x68, 0x63, 0x20, 0x63, 0x74, 0x66, 0x20, 0x6b, 0x6f, 
                0x74, 0x68, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0x4d, 80, 0x55, 0x49, 0x5f, 0x44, 0x45, 0x53, 
                0x43, 0x5f, 0x4d, 0x41, 80, 0x5f, 0x52, 0x55, 0x53, 0x54, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0x70, 0x72, 0x65, 0x76, 0x69, 0x65, 0x77, 0x5f, 
                0x6d, 0x70, 0x5f, 0x72, 0x75, 0x73, 0x74, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0x63, 0x6f, 0x6d, 0x70, 0x61, 0x73, 0x73, 0x5f, 
                0x6f, 0x76, 0x65, 0x72, 0x6c, 0x61, 0x79, 0x5f, 0x6d, 0x61, 0x70, 0x5f, 0x62, 0x6c, 0x61, 110, 
                0x6b, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 100, 0x65, 0x6c, 0x74, 0x61, 0x5f, 0x6d, 0x75, 
                0x6c, 0x74, 0x69, 0x63, 0x61, 0x6d, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0x6f, 0x70, 0x66, 0x6f, 0x72, 0x63, 0x65, 0x5f, 
                0x75, 0x72, 0x62, 0x61, 110, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 100, 0x65, 0x73, 0x65, 0x72, 0x74, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0x30, 0, 0, 0, 0, 0, 0, 0, 
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
             });
        }

        private void button98_Click_1(object sender, EventArgs e)
        {
           
        }

        private void textBox130_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void button120_Click(object sender, EventArgs e)
        {
            label77.Text = textBox20.Text;
            scrollTimer.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button121_Click(object sender, EventArgs e)
        {
      
        }

        private void scrollTimer_Tick(object sender, EventArgs e)
        {
            label77.Text = label77.Text.Substring(1) + label77.Text.Substring(0, 1);
            byte[] name1 = Encoding.ASCII.GetBytes("^1|^2" + label77.Text + "^1|");
            Array.Resize(ref name1, name1.Length + 1);
            PS3.SetMemory(0x01BBBC2C, name1);

            System.Threading.Thread.Sleep(200);

            label77.Text = label77.Text.Substring(1) + label77.Text.Substring(0, 1);
            byte[] name2 = Encoding.ASCII.GetBytes("^1|^3" + label77.Text + "^1|");
            Array.Resize(ref name2, name2.Length + 1);
            PS3.SetMemory(0x01BBBC2C, name2);

            System.Threading.Thread.Sleep(200);

            label77.Text = label77.Text.Substring(1) + label77.Text.Substring(0, 1);
            byte[] name3 = Encoding.ASCII.GetBytes("^1|^4" + label77.Text + "^1|");
            Array.Resize(ref name3, name3.Length + 1);
            PS3.SetMemory(0x01BBBC2C, name3);

            System.Threading.Thread.Sleep(200);

            label77.Text = label77.Text.Substring(1) + label77.Text.Substring(0, 1);
            byte[] name4 = Encoding.ASCII.GetBytes("^1|^5" + label77.Text + "^1|");
            Array.Resize(ref name4, name4.Length + 1);
            PS3.SetMemory(0x01BBBC2C, name4);

            System.Threading.Thread.Sleep(200);

            label77.Text = label77.Text.Substring(1) + label77.Text.Substring(0, 1);
            byte[] name5 = Encoding.ASCII.GetBytes("^1|^6" + label77.Text + "^1|");
            Array.Resize(ref name5, name5.Length + 1);
            PS3.SetMemory(0x01BBBC2C, name5);

            System.Threading.Thread.Sleep(200);
        }
             private int charcount;
        private string text;
        private bool state;
        private void moveTimer_Tick(object sender, EventArgs e)
        {
             if (text.Length <= 16)
            {
                if (text.Length == charcount)
                {
                    state = true;
                }
                if (text.Length == 16)
                {
                    state = false;
                }
                
                if (state)
                {
                    text = text.Insert(0, " ");
                    label2.Text = text;
                 
      byte[] name = Encoding.ASCII.GetBytes(text);
             PS3.SetMemory(0x01BBBC2C, name);
                  
                }
                if (!state)
                {
                    text = text.Remove(0, 1);
                    label2.Text = text;
                  
                    byte[] name = Encoding.ASCII.GetBytes(text);
             PS3.SetMemory(0x01BBBC2C, name);
                  
                }
        }
        }

        private void rainTimer_Tick(object sender, EventArgs e)
        {
             string temp = rainLabel.Text;


              int count = 0;
              foreach (Match match in Regex.Matches(temp, @"\^([0-9])(.)"))
              {
                  string digit = match.Value.Substring(1, 1);
                  string lbltext = match.Value.Substring(2, 1);

                  Labels[count].Text = lbltext;
                  Labels[count].ForeColor = lblColors[match.Value.Substring(0, 2)];

                  var i = int.Parse(digit);
                  if (i < 7)
                  {
                      i++;
                      digit = Convert.ToString(i);

                      if (digit == "7")
                          digit = "1";

                      temp = temp.Remove(match.Index + 1, 1);
                      temp = temp.Insert(match.Index + 1, digit);
                  }
                  count++;
              }

              rainLabel.Text = temp;

            
             byte[] name = Encoding.ASCII.GetBytes(rainLabel.Text);
             Array.Resize(ref name, name.Length + 1);
              PS3.SetMemory(0x01f9f11c, name);
        }

        private void textBox20_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button121_Click_1(object sender, EventArgs e)
        {
            scrollTimer.Stop();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void button122_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Weed")
            {
                PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 50, 0x5e, 1, 80, 80, 13 });
                PS3.Extension.WriteString(0x1bbbc33, "cardicon_weed ^2" + this.textBox24.Text );


            }

            if (comboBox1.SelectedItem == "PSN")
            {
                PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 0x7f, 0x7f, 10 });
                PS3.Extension.WriteString(0x1bbbc33, "ps3network " + this.textBox24.Text);

            }


            if (comboBox1.SelectedItem == "Facebook")
            {
                PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 8 });
                PS3.Extension.WriteString(0x1bbbc33, "facebook ^5" + this.textBox24.Text);

            }
   
            if (comboBox1.SelectedItem == "Nuke")
            {
                PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 10 });
                PS3.Extension.WriteString(0x1bbbc33, "death_nuke " + this.textBox24.Text);

            }
            if (comboBox1.SelectedItem == "Moab")
            {
                PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 10 });
                PS3.Extension.WriteString(0x1bbbc33, "death_moab " + this.textBox24.Text);

            }
           
          
        }

        private void button123_Click(object sender, EventArgs e)
        {
            timer39.Start();
            button123.Visible = false;
            button124.Visible = true;
        }

        private void timer39_Tick(object sender, EventArgs e)
        {
            PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 8 });
            PS3.Extension.WriteString(0x1bbbc33, "facebook " + this.textBox24.Text);
            Thread.Sleep(150);
            PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 10 });
            PS3.Extension.WriteString(0x1bbbc33, "ps3network " + this.textBox24.Text);
            Thread.Sleep(150);
            PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 9 });
            PS3.Extension.WriteString(0x1bbbc33, "voice_off " + this.textBox24.Text);
            Thread.Sleep(150);
            PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 2 });
            PS3.Extension.WriteString(0x1bbbc33, "xp " + this.textBox24.Text);
            Thread.Sleep(150);
            PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 12 });
            PS3.Extension.WriteString(0x1bbbc33, "award_trophy " + this.textBox24.Text);
            Thread.Sleep(150);
            PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 10 });
            PS3.Extension.WriteString(0x1bbbc33, "weapon_msr " + this.textBox24.Text);
            Thread.Sleep(150);
            PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 10 });
            PS3.Extension.WriteString(0x1bbbc33, "death_nuke " + this.textBox24.Text);
            Thread.Sleep(150);
            PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 10 });
            PS3.Extension.WriteString(0x1bbbc33, "rank_empty " + this.textBox24.Text);
            Thread.Sleep(150);
            PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 7 });
            PS3.Extension.WriteString(0x1bbbc33, "ui_host " + this.textBox24.Text);
            Thread.Sleep(150);
            PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 7 });
            PS3.Extension.WriteString(0x1bbbc33, "money_3 " + this.textBox24.Text);
            Thread.Sleep(150);
            PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 9 });
            PS3.Extension.WriteString(0x1bbbc33, "checkmark " + this.textBox24.Text);
            Thread.Sleep(150);
            PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 9 });
            PS3.Extension.WriteString(0x1bbbc33, "weapon_c4 " + this.textBox24.Text);
            Thread.Sleep(150);
            PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 10 });
            PS3.Extension.WriteString(0x1bbbc33, "death_moab " + this.textBox24.Text);
            Thread.Sleep(150);
            PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 13 });
            PS3.Extension.WriteString(0x1bbbc33, "cardicon_cod4 " + this.textBox24.Text);
            Thread.Sleep(150);
            PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 13 });
            PS3.Extension.WriteString(0x1bbbc33, "cardicon_bear " + this.textBox24.Text);
            Thread.Sleep(150);
        }

        private void button124_Click(object sender, EventArgs e)
        {
            timer39.Stop();
            button124.Visible = false;
            button123.Visible = true;
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void button125_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x1bbbc2c, new byte[] { 0x5e, 0x37, 0x5e, 1 });
            byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown38.Value.ToString()));
            PS3.SetMemory(0x1bbbc30, bytes);
            byte[] buffer = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown36.Value.ToString()));
            PS3.SetMemory(0x1bbbc31, buffer);
            byte[] buffer3 = BitConverter.GetBytes(Convert.ToInt32(this.numericUpDown37.Value.ToString()));
            PS3.SetMemory(0x1bbbc32, buffer3);
            PS3.Extension.WriteString(0x1bbbc33, this.textBox26.Text + " " + this.textBox27.Text);
        }

        private void button126_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button126_Click_1(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "Mw2 10th")
            {
  
                byte[] NAME1142213 = new byte[] { 0x5e, 0x37, 0x5e, 1, 80, 80, 0x17, 0x72, 0x61, 110, 0x6b, 0x5f, 0x63, 0x6c, 0x61, 0x73, 
                    0x73, 0x69, 0x63, 0x5f, 0x70, 0x72, 0x65, 0x73, 0x74, 0x69, 0x67, 0x65, 0x31, 0x30 };
                PS3.SetMemory(0x01BBBC2C, NAME1142213);

               

            }
            if (comboBox2.SelectedItem == "Mw3 10th")
            {


                PS3.Extension.WriteString(0x1bbbc33, "master_prestige_10");


            }
            if (comboBox2.SelectedItem == "Bo1 15th")
            {


                PS3.Extension.WriteString(0x1bbbc33, "rank_prestige_bo15");


            }
          
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {

        }

        private void button127_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox28_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox11_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button128_Click(object sender, EventArgs e)
        {
            byte[] NAME = Encoding.ASCII.GetBytes(this.textBox223.Text);
            Array.Resize(ref NAME, NAME.Length + 9999);
            PS3.SetMemory(0x892c15, NAME);
        }

        private void textBox223_TextChanged(object sender, EventArgs e)
        {

        }

        private void secretRomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.CurrentRow.Index;
            SecretRoom(index);
        }

        public void SecretRoom(int client)
        {
            if (getMapNamemw3() == "Seatown")
            {
                PS3.SetMemory((uint)(0x110a29c + (client * 0x3980)), new byte[] { 70, 0x36, 0xec, 40, 0xc2, 0xf9, 0xb1, 0x93, 0x45 });
                PS3.SetMemory((uint)(0x110dc1c + (client * 0x3980)), new byte[] { 70, 0x36, 0xec, 40, 0xc2, 0xf9, 0xb1, 0x93, 0x45 });
                PS3.SetMemory((uint)(0x111159c + (client * 0x3980)), new byte[] { 70, 0x36, 0xec, 40, 0xc2, 0xf9, 0xb1, 0x93, 0x45 });
                PS3.SetMemory((uint)(0x1114f1c + (client * 0x3980)), new byte[] { 70, 0x36, 0xec, 40, 0xc2, 0xf9, 0xb1, 0x93, 0x45 });
                PS3.SetMemory((uint)(0x111889c + (client * 0x3980)), new byte[] { 70, 0x36, 0xec, 40, 0xc2, 0xf9, 0xb1, 0x93, 0x45 });
                PS3.SetMemory((uint)(0x111c21c + (client * 0x3980)), new byte[] { 70, 0x36, 0xec, 40, 0xc2, 0xf9, 0xb1, 0x93, 0x45 });
                PS3.SetMemory((uint)(0x111fb9c + (client * 0x3980)), new byte[] { 70, 0x36, 0xec, 40, 0xc2, 0xf9, 0xb1, 0x93, 0x45 });
                PS3.SetMemory((uint)(0x112351c + (client * 0x3980)), new byte[] { 70, 0x36, 0xec, 40, 0xc2, 0xf9, 0xb1, 0x93, 0x45 });
                PS3.SetMemory((uint)(0x1126e9c + (client * 0x3980)), new byte[] { 70, 0x36, 0xec, 40, 0xc2, 0xf9, 0xb1, 0x93, 0x45 });
                PS3.SetMemory((uint)(0x112a81c + (client * 0x3980)), new byte[] { 70, 0x36, 0xec, 40, 0xc2, 0xf9, 0xb1, 0x93, 0x45 });
                PS3.SetMemory((uint)(0x112e19c + (client * 0x3980)), new byte[] { 70, 0x36, 0xec, 40, 0xc2, 0xf9, 0xb1, 0x93, 0x45 });
                PS3.SetMemory((uint)(0x1131b1c + (client * 0x3980)), new byte[] { 70, 0x36, 0xec, 40, 0xc2, 0xf9, 0xb1, 0x93, 0x45 });
                PS3.SetMemory((uint)(0x113549c + (client * 0x3980)), new byte[] { 70, 0x36, 0xec, 40, 0xc2, 0xf9, 0xb1, 0x93, 0x45 });
                PS3.SetMemory((uint)(0x1138e1c + (client * 0x3980)), new byte[] { 70, 0x36, 0xec, 40, 0xc2, 0xf9, 0xb1, 0x93, 0x45 });
                PS3.SetMemory((uint)(0x113c79c + (client * 0x3980)), new byte[] { 70, 0x36, 0xec, 40, 0xc2, 0xf9, 0xb1, 0x93, 0x45 });
                PS3.SetMemory((uint)(0x114011c + (client * 0x3980)), new byte[] { 70, 0x36, 0xec, 40, 0xc2, 0xf9, 0xb1, 0x93, 0x45 });
                PS3.SetMemory((uint)(0x1143a9c + (client * 0x3980)), new byte[] { 70, 0x36, 0xec, 40, 0xc2, 0xf9, 0xb1, 0x93, 0x45 });
                PS3.SetMemory((uint)(0x114741c + (client * 0x3980)), new byte[] { 70, 0x36, 0xec, 40, 0xc2, 0xf9, 0xb1, 0x93, 0x45 });
                RPC_MW3.iPrintlnBold(client, "Teleported to ^2Seatown^7 Secret Room");
            }
            if (getMapNamemw3() == "Dome")
            {
                PS3.SetMemory((uint)(0x110a29c + (client * 0x3980)), new byte[] { 0x44, 0x51, 240, 0xfb, 0x45, 0x27, 0x25, 0x5f, 0xc3, 0x7e, 0xe0 });
                PS3.SetMemory((uint)(0x110dc1c + (client * 0x3980)), new byte[] { 0x44, 0x51, 240, 0xfb, 0x45, 0x27, 0x25, 0x5f, 0xc3, 0x7e, 0xe0 });
                PS3.SetMemory((uint)(0x111159c + (client * 0x3980)), new byte[] { 0x44, 0x51, 240, 0xfb, 0x45, 0x27, 0x25, 0x5f, 0xc3, 0x7e, 0xe0 });
                PS3.SetMemory((uint)(0x1114f1c + (client * 0x3980)), new byte[] { 0x44, 0x51, 240, 0xfb, 0x45, 0x27, 0x25, 0x5f, 0xc3, 0x7e, 0xe0 });
                PS3.SetMemory((uint)(0x111889c + (client * 0x3980)), new byte[] { 0x44, 0x51, 240, 0xfb, 0x45, 0x27, 0x25, 0x5f, 0xc3, 0x7e, 0xe0 });
                PS3.SetMemory((uint)(0x111c21c + (client * 0x3980)), new byte[] { 0x44, 0x51, 240, 0xfb, 0x45, 0x27, 0x25, 0x5f, 0xc3, 0x7e, 0xe0 });
                PS3.SetMemory((uint)(0x111fb9c + (client * 0x3980)), new byte[] { 0x44, 0x51, 240, 0xfb, 0x45, 0x27, 0x25, 0x5f, 0xc3, 0x7e, 0xe0 });
                PS3.SetMemory((uint)(0x112351c + (client * 0x3980)), new byte[] { 0x44, 0x51, 240, 0xfb, 0x45, 0x27, 0x25, 0x5f, 0xc3, 0x7e, 0xe0 });
                PS3.SetMemory((uint)(0x1126e9c + (client * 0x3980)), new byte[] { 0x44, 0x51, 240, 0xfb, 0x45, 0x27, 0x25, 0x5f, 0xc3, 0x7e, 0xe0 });
                PS3.SetMemory((uint)(0x112a81c + (client * 0x3980)), new byte[] { 0x44, 0x51, 240, 0xfb, 0x45, 0x27, 0x25, 0x5f, 0xc3, 0x7e, 0xe0 });
                PS3.SetMemory((uint)(0x112e19c + (client * 0x3980)), new byte[] { 0x44, 0x51, 240, 0xfb, 0x45, 0x27, 0x25, 0x5f, 0xc3, 0x7e, 0xe0 });
                PS3.SetMemory((uint)(0x1131b1c + (client * 0x3980)), new byte[] { 0x44, 0x51, 240, 0xfb, 0x45, 0x27, 0x25, 0x5f, 0xc3, 0x7e, 0xe0 });
                PS3.SetMemory((uint)(0x113549c + (client * 0x3980)), new byte[] { 0x44, 0x51, 240, 0xfb, 0x45, 0x27, 0x25, 0x5f, 0xc3, 0x7e, 0xe0 });
                PS3.SetMemory((uint)(0x1138e1c + (client * 0x3980)), new byte[] { 0x44, 0x51, 240, 0xfb, 0x45, 0x27, 0x25, 0x5f, 0xc3, 0x7e, 0xe0 });
                PS3.SetMemory((uint)(0x113c79c + (client * 0x3980)), new byte[] { 0x44, 0x51, 240, 0xfb, 0x45, 0x27, 0x25, 0x5f, 0xc3, 0x7e, 0xe0 });
                PS3.SetMemory((uint)(0x114011c + (client * 0x3980)), new byte[] { 0x44, 0x51, 240, 0xfb, 0x45, 0x27, 0x25, 0x5f, 0xc3, 0x7e, 0xe0 });
                PS3.SetMemory((uint)(0x1143a9c + (client * 0x3980)), new byte[] { 0x44, 0x51, 240, 0xfb, 0x45, 0x27, 0x25, 0x5f, 0xc3, 0x7e, 0xe0 });
                PS3.SetMemory((uint)(0x114741c + (client * 0x3980)), new byte[] { 0x44, 0x51, 240, 0xfb, 0x45, 0x27, 0x25, 0x5f, 0xc3, 0x7e, 0xe0 });
                RPC_MW3.iPrintlnBold(client, "Teleported to ^2Dome^7 Secret Room");
            }
            if (getMapNamemw3() == "Arkaden")
            {
                PS3.SetMemory((uint)(0x110a29c + (client * 0x3980)), new byte[] { 0x43, 0x95, 0xbb, 0xc7, 0x45, 0x9d, 0x67, 1, 0x44 });
                PS3.SetMemory((uint)(0x110dc1c + (client * 0x3980)), new byte[] { 0x43, 0x95, 0xbb, 0xc7, 0x45, 0x9d, 0x67, 1, 0x44 });
                PS3.SetMemory((uint)(0x111159c + (client * 0x3980)), new byte[] { 0x43, 0x95, 0xbb, 0xc7, 0x45, 0x9d, 0x67, 1, 0x44 });
                PS3.SetMemory((uint)(0x1114f1c + (client * 0x3980)), new byte[] { 0x43, 0x95, 0xbb, 0xc7, 0x45, 0x9d, 0x67, 1, 0x44 });
                PS3.SetMemory((uint)(0x111889c + (client * 0x3980)), new byte[] { 0x43, 0x95, 0xbb, 0xc7, 0x45, 0x9d, 0x67, 1, 0x44 });
                PS3.SetMemory((uint)(0x111c21c + (client * 0x3980)), new byte[] { 0x43, 0x95, 0xbb, 0xc7, 0x45, 0x9d, 0x67, 1, 0x44 });
                PS3.SetMemory((uint)(0x111fb9c + (client * 0x3980)), new byte[] { 0x43, 0x95, 0xbb, 0xc7, 0x45, 0x9d, 0x67, 1, 0x44 });
                PS3.SetMemory((uint)(0x112351c + (client * 0x3980)), new byte[] { 0x43, 0x95, 0xbb, 0xc7, 0x45, 0x9d, 0x67, 1, 0x44 });
                PS3.SetMemory((uint)(0x1126e9c + (client * 0x3980)), new byte[] { 0x43, 0x95, 0xbb, 0xc7, 0x45, 0x9d, 0x67, 1, 0x44 });
                PS3.SetMemory((uint)(0x112a81c + (client * 0x3980)), new byte[] { 0x43, 0x95, 0xbb, 0xc7, 0x45, 0x9d, 0x67, 1, 0x44 });
                PS3.SetMemory((uint)(0x112e19c + (client * 0x3980)), new byte[] { 0x43, 0x95, 0xbb, 0xc7, 0x45, 0x9d, 0x67, 1, 0x44 });
                PS3.SetMemory((uint)(0x1131b1c + (client * 0x3980)), new byte[] { 0x43, 0x95, 0xbb, 0xc7, 0x45, 0x9d, 0x67, 1, 0x44 });
                PS3.SetMemory((uint)(0x113549c + (client * 0x3980)), new byte[] { 0x43, 0x95, 0xbb, 0xc7, 0x45, 0x9d, 0x67, 1, 0x44 });
                PS3.SetMemory((uint)(0x1138e1c + (client * 0x3980)), new byte[] { 0x43, 0x95, 0xbb, 0xc7, 0x45, 0x9d, 0x67, 1, 0x44 });
                PS3.SetMemory((uint)(0x113c79c + (client * 0x3980)), new byte[] { 0x43, 0x95, 0xbb, 0xc7, 0x45, 0x9d, 0x67, 1, 0x44 });
                PS3.SetMemory((uint)(0x114011c + (client * 0x3980)), new byte[] { 0x43, 0x95, 0xbb, 0xc7, 0x45, 0x9d, 0x67, 1, 0x44 });
                PS3.SetMemory((uint)(0x1143a9c + (client * 0x3980)), new byte[] { 0x43, 0x95, 0xbb, 0xc7, 0x45, 0x9d, 0x67, 1, 0x44 });
                PS3.SetMemory((uint)(0x114741c + (client * 0x3980)), new byte[] { 0x43, 0x95, 0xbb, 0xc7, 0x45, 0x9d, 0x67, 1, 0x44 });
                RPC_MW3.iPrintlnBold(client, "Teleported to ^2Arkaden^7 Secret Room");
            }
            if (getMapNamemw3() == "Bakaraa")
            {
                PS3.SetMemory((uint)(0x110a29c + (client * 0x3980)), new byte[] { 0x44, 0xbc, 0xea, 0x27, 0xc4, 240, 0x94, 0xce, 0x44, 0x22, 0x1b, 0x33 });
                PS3.SetMemory((uint)(0x110dc1c + (client * 0x3980)), new byte[] { 0x44, 0xbc, 0xea, 0x27, 0xc4, 240, 0x94, 0xce, 0x44, 0x22, 0x1b, 0x33 });
                PS3.SetMemory((uint)(0x111159c + (client * 0x3980)), new byte[] { 0x44, 0xbc, 0xea, 0x27, 0xc4, 240, 0x94, 0xce, 0x44, 0x22, 0x1b, 0x33 });
                PS3.SetMemory((uint)(0x1114f1c + (client * 0x3980)), new byte[] { 0x44, 0xbc, 0xea, 0x27, 0xc4, 240, 0x94, 0xce, 0x44, 0x22, 0x1b, 0x33 });
                PS3.SetMemory((uint)(0x111889c + (client * 0x3980)), new byte[] { 0x44, 0xbc, 0xea, 0x27, 0xc4, 240, 0x94, 0xce, 0x44, 0x22, 0x1b, 0x33 });
                PS3.SetMemory((uint)(0x111c21c + (client * 0x3980)), new byte[] { 0x44, 0xbc, 0xea, 0x27, 0xc4, 240, 0x94, 0xce, 0x44, 0x22, 0x1b, 0x33 });
                PS3.SetMemory((uint)(0x111fb9c + (client * 0x3980)), new byte[] { 0x44, 0xbc, 0xea, 0x27, 0xc4, 240, 0x94, 0xce, 0x44, 0x22, 0x1b, 0x33 });
                PS3.SetMemory((uint)(0x112351c + (client * 0x3980)), new byte[] { 0x44, 0xbc, 0xea, 0x27, 0xc4, 240, 0x94, 0xce, 0x44, 0x22, 0x1b, 0x33 });
                PS3.SetMemory((uint)(0x1126e9c + (client * 0x3980)), new byte[] { 0x44, 0xbc, 0xea, 0x27, 0xc4, 240, 0x94, 0xce, 0x44, 0x22, 0x1b, 0x33 });
                PS3.SetMemory((uint)(0x112a81c + (client * 0x3980)), new byte[] { 0x44, 0xbc, 0xea, 0x27, 0xc4, 240, 0x94, 0xce, 0x44, 0x22, 0x1b, 0x33 });
                PS3.SetMemory((uint)(0x112e19c + (client * 0x3980)), new byte[] { 0x44, 0xbc, 0xea, 0x27, 0xc4, 240, 0x94, 0xce, 0x44, 0x22, 0x1b, 0x33 });
                PS3.SetMemory((uint)(0x1131b1c + (client * 0x3980)), new byte[] { 0x44, 0xbc, 0xea, 0x27, 0xc4, 240, 0x94, 0xce, 0x44, 0x22, 0x1b, 0x33 });
                PS3.SetMemory((uint)(0x113549c + (client * 0x3980)), new byte[] { 0x44, 0xbc, 0xea, 0x27, 0xc4, 240, 0x94, 0xce, 0x44, 0x22, 0x1b, 0x33 });
                PS3.SetMemory((uint)(0x1138e1c + (client * 0x3980)), new byte[] { 0x44, 0xbc, 0xea, 0x27, 0xc4, 240, 0x94, 0xce, 0x44, 0x22, 0x1b, 0x33 });
                PS3.SetMemory((uint)(0x113c79c + (client * 0x3980)), new byte[] { 0x44, 0xbc, 0xea, 0x27, 0xc4, 240, 0x94, 0xce, 0x44, 0x22, 0x1b, 0x33 });
                PS3.SetMemory((uint)(0x114011c + (client * 0x3980)), new byte[] { 0x44, 0xbc, 0xea, 0x27, 0xc4, 240, 0x94, 0xce, 0x44, 0x22, 0x1b, 0x33 });
                PS3.SetMemory((uint)(0x1143a9c + (client * 0x3980)), new byte[] { 0x44, 0xbc, 0xea, 0x27, 0xc4, 240, 0x94, 0xce, 0x44, 0x22, 0x1b, 0x33 });
                PS3.SetMemory((uint)(0x114741c + (client * 0x3980)), new byte[] { 0x44, 0xbc, 0xea, 0x27, 0xc4, 240, 0x94, 0xce, 0x44, 0x22, 0x1b, 0x33 });
                RPC_MW3.iPrintlnBold(client, "Teleported to ^2Bakaara^7 Secret Room");
            }
            if (getMapNamemw3() == "Resistence")
            {
                PS3.SetMemory((uint)(0x110a29c + (client * 0x3980)), new byte[] { 0x42, 0x59, 60, 0xd3, 0x44, 50, 0x54, 0xc3, 0x44, 100, 0x41, 0xc4 });
                PS3.SetMemory((uint)(0x110dc1c + (client * 0x3980)), new byte[] { 0x42, 0x59, 60, 0xd3, 0x44, 50, 0x54, 0xc3, 0x44, 100, 0x41, 0xc4 });
                PS3.SetMemory((uint)(0x111159c + (client * 0x3980)), new byte[] { 0x42, 0x59, 60, 0xd3, 0x44, 50, 0x54, 0xc3, 0x44, 100, 0x41, 0xc4 });
                PS3.SetMemory((uint)(0x1114f1c + (client * 0x3980)), new byte[] { 0x42, 0x59, 60, 0xd3, 0x44, 50, 0x54, 0xc3, 0x44, 100, 0x41, 0xc4 });
                PS3.SetMemory((uint)(0x111889c + (client * 0x3980)), new byte[] { 0x42, 0x59, 60, 0xd3, 0x44, 50, 0x54, 0xc3, 0x44, 100, 0x41, 0xc4 });
                PS3.SetMemory((uint)(0x111c21c + (client * 0x3980)), new byte[] { 0x42, 0x59, 60, 0xd3, 0x44, 50, 0x54, 0xc3, 0x44, 100, 0x41, 0xc4 });
                PS3.SetMemory((uint)(0x111fb9c + (client * 0x3980)), new byte[] { 0x42, 0x59, 60, 0xd3, 0x44, 50, 0x54, 0xc3, 0x44, 100, 0x41, 0xc4 });
                PS3.SetMemory((uint)(0x112351c + (client * 0x3980)), new byte[] { 0x42, 0x59, 60, 0xd3, 0x44, 50, 0x54, 0xc3, 0x44, 100, 0x41, 0xc4 });
                PS3.SetMemory((uint)(0x1126e9c + (client * 0x3980)), new byte[] { 0x42, 0x59, 60, 0xd3, 0x44, 50, 0x54, 0xc3, 0x44, 100, 0x41, 0xc4 });
                PS3.SetMemory((uint)(0x112a81c + (client * 0x3980)), new byte[] { 0x42, 0x59, 60, 0xd3, 0x44, 50, 0x54, 0xc3, 0x44, 100, 0x41, 0xc4 });
                PS3.SetMemory((uint)(0x112e19c + (client * 0x3980)), new byte[] { 0x42, 0x59, 60, 0xd3, 0x44, 50, 0x54, 0xc3, 0x44, 100, 0x41, 0xc4 });
                PS3.SetMemory((uint)(0x1131b1c + (client * 0x3980)), new byte[] { 0x42, 0x59, 60, 0xd3, 0x44, 50, 0x54, 0xc3, 0x44, 100, 0x41, 0xc4 });
                PS3.SetMemory((uint)(0x113549c + (client * 0x3980)), new byte[] { 0x42, 0x59, 60, 0xd3, 0x44, 50, 0x54, 0xc3, 0x44, 100, 0x41, 0xc4 });
                PS3.SetMemory((uint)(0x1138e1c + (client * 0x3980)), new byte[] { 0x42, 0x59, 60, 0xd3, 0x44, 50, 0x54, 0xc3, 0x44, 100, 0x41, 0xc4 });
                PS3.SetMemory((uint)(0x113c79c + (client * 0x3980)), new byte[] { 0x42, 0x59, 60, 0xd3, 0x44, 50, 0x54, 0xc3, 0x44, 100, 0x41, 0xc4 });
                PS3.SetMemory((uint)(0x114011c + (client * 0x3980)), new byte[] { 0x42, 0x59, 60, 0xd3, 0x44, 50, 0x54, 0xc3, 0x44, 100, 0x41, 0xc4 });
                PS3.SetMemory((uint)(0x1143a9c + (client * 0x3980)), new byte[] { 0x42, 0x59, 60, 0xd3, 0x44, 50, 0x54, 0xc3, 0x44, 100, 0x41, 0xc4 });
                PS3.SetMemory((uint)(0x114741c + (client * 0x3980)), new byte[] { 0x42, 0x59, 60, 0xd3, 0x44, 50, 0x54, 0xc3, 0x44, 100, 0x41, 0xc4 });
                RPC_MW3.iPrintlnBold(client, "Teleported to ^2Resistence^7 Secret Room");
            }
            if (getMapNamemw3() == "Downturn")
            {
                PS3.SetMemory((uint)(0x110a29c + (client * 0x3980)), new byte[] { 0x44, 0x9b, 0x23, 0xb7, 0x45, 0x19, 0x53, 0xf5, 0x44, 0xc1, 0xe4 });
                PS3.SetMemory((uint)(0x110dc1c + (client * 0x3980)), new byte[] { 0x44, 0x9b, 0x23, 0xb7, 0x45, 0x19, 0x53, 0xf5, 0x44, 0xc1, 0xe4 });
                PS3.SetMemory((uint)(0x111159c + (client * 0x3980)), new byte[] { 0x44, 0x9b, 0x23, 0xb7, 0x45, 0x19, 0x53, 0xf5, 0x44, 0xc1, 0xe4 });
                PS3.SetMemory((uint)(0x1114f1c + (client * 0x3980)), new byte[] { 0x44, 0x9b, 0x23, 0xb7, 0x45, 0x19, 0x53, 0xf5, 0x44, 0xc1, 0xe4 });
                PS3.SetMemory((uint)(0x111889c + (client * 0x3980)), new byte[] { 0x44, 0x9b, 0x23, 0xb7, 0x45, 0x19, 0x53, 0xf5, 0x44, 0xc1, 0xe4 });
                PS3.SetMemory((uint)(0x111c21c + (client * 0x3980)), new byte[] { 0x44, 0x9b, 0x23, 0xb7, 0x45, 0x19, 0x53, 0xf5, 0x44, 0xc1, 0xe4 });
                PS3.SetMemory((uint)(0x111fb9c + (client * 0x3980)), new byte[] { 0x44, 0x9b, 0x23, 0xb7, 0x45, 0x19, 0x53, 0xf5, 0x44, 0xc1, 0xe4 });
                PS3.SetMemory((uint)(0x112351c + (client * 0x3980)), new byte[] { 0x44, 0x9b, 0x23, 0xb7, 0x45, 0x19, 0x53, 0xf5, 0x44, 0xc1, 0xe4 });
                PS3.SetMemory((uint)(0x1126e9c + (client * 0x3980)), new byte[] { 0x44, 0x9b, 0x23, 0xb7, 0x45, 0x19, 0x53, 0xf5, 0x44, 0xc1, 0xe4 });
                PS3.SetMemory((uint)(0x112a81c + (client * 0x3980)), new byte[] { 0x44, 0x9b, 0x23, 0xb7, 0x45, 0x19, 0x53, 0xf5, 0x44, 0xc1, 0xe4 });
                PS3.SetMemory((uint)(0x112e19c + (client * 0x3980)), new byte[] { 0x44, 0x9b, 0x23, 0xb7, 0x45, 0x19, 0x53, 0xf5, 0x44, 0xc1, 0xe4 });
                PS3.SetMemory((uint)(0x1131b1c + (client * 0x3980)), new byte[] { 0x44, 0x9b, 0x23, 0xb7, 0x45, 0x19, 0x53, 0xf5, 0x44, 0xc1, 0xe4 });
                PS3.SetMemory((uint)(0x113549c + (client * 0x3980)), new byte[] { 0x44, 0x9b, 0x23, 0xb7, 0x45, 0x19, 0x53, 0xf5, 0x44, 0xc1, 0xe4 });
                PS3.SetMemory((uint)(0x1138e1c + (client * 0x3980)), new byte[] { 0x44, 0x9b, 0x23, 0xb7, 0x45, 0x19, 0x53, 0xf5, 0x44, 0xc1, 0xe4 });
                PS3.SetMemory((uint)(0x113c79c + (client * 0x3980)), new byte[] { 0x44, 0x9b, 0x23, 0xb7, 0x45, 0x19, 0x53, 0xf5, 0x44, 0xc1, 0xe4 });
                PS3.SetMemory((uint)(0x114011c + (client * 0x3980)), new byte[] { 0x44, 0x9b, 0x23, 0xb7, 0x45, 0x19, 0x53, 0xf5, 0x44, 0xc1, 0xe4 });
                PS3.SetMemory((uint)(0x1143a9c + (client * 0x3980)), new byte[] { 0x44, 0x9b, 0x23, 0xb7, 0x45, 0x19, 0x53, 0xf5, 0x44, 0xc1, 0xe4 });
                PS3.SetMemory((uint)(0x114741c + (client * 0x3980)), new byte[] { 0x44, 0x9b, 0x23, 0xb7, 0x45, 0x19, 0x53, 0xf5, 0x44, 0xc1, 0xe4 });
                RPC_MW3.iPrintlnBold(client, "Teleported to ^2Dowturn^7 Secret Room");
            }
            if (getMapNamemw3() == "Bootleg")
            {
                PS3.SetMemory((uint)(0x110a29c + (client * 0x3980)), new byte[] { 0x43, 80, 0x19, 0x40, 0x44, 0xbf, 0x5d, 0x4d, 0x43, 0x6a, 0x58 });
                PS3.SetMemory((uint)(0x110dc1c + (client * 0x3980)), new byte[] { 0x43, 80, 0x19, 0x40, 0x44, 0xbf, 0x5d, 0x4d, 0x43, 0x6a, 0x58 });
                PS3.SetMemory((uint)(0x111159c + (client * 0x3980)), new byte[] { 0x43, 80, 0x19, 0x40, 0x44, 0xbf, 0x5d, 0x4d, 0x43, 0x6a, 0x58 });
                PS3.SetMemory((uint)(0x1114f1c + (client * 0x3980)), new byte[] { 0x43, 80, 0x19, 0x40, 0x44, 0xbf, 0x5d, 0x4d, 0x43, 0x6a, 0x58 });
                PS3.SetMemory((uint)(0x111889c + (client * 0x3980)), new byte[] { 0x43, 80, 0x19, 0x40, 0x44, 0xbf, 0x5d, 0x4d, 0x43, 0x6a, 0x58 });
                PS3.SetMemory((uint)(0x111c21c + (client * 0x3980)), new byte[] { 0x43, 80, 0x19, 0x40, 0x44, 0xbf, 0x5d, 0x4d, 0x43, 0x6a, 0x58 });
                PS3.SetMemory((uint)(0x111fb9c + (client * 0x3980)), new byte[] { 0x43, 80, 0x19, 0x40, 0x44, 0xbf, 0x5d, 0x4d, 0x43, 0x6a, 0x58 });
                PS3.SetMemory((uint)(0x112351c + (client * 0x3980)), new byte[] { 0x43, 80, 0x19, 0x40, 0x44, 0xbf, 0x5d, 0x4d, 0x43, 0x6a, 0x58 });
                PS3.SetMemory((uint)(0x1126e9c + (client * 0x3980)), new byte[] { 0x43, 80, 0x19, 0x40, 0x44, 0xbf, 0x5d, 0x4d, 0x43, 0x6a, 0x58 });
                PS3.SetMemory((uint)(0x112a81c + (client * 0x3980)), new byte[] { 0x43, 80, 0x19, 0x40, 0x44, 0xbf, 0x5d, 0x4d, 0x43, 0x6a, 0x58 });
                PS3.SetMemory((uint)(0x112e19c + (client * 0x3980)), new byte[] { 0x43, 80, 0x19, 0x40, 0x44, 0xbf, 0x5d, 0x4d, 0x43, 0x6a, 0x58 });
                PS3.SetMemory((uint)(0x1131b1c + (client * 0x3980)), new byte[] { 0x43, 80, 0x19, 0x40, 0x44, 0xbf, 0x5d, 0x4d, 0x43, 0x6a, 0x58 });
                PS3.SetMemory((uint)(0x113549c + (client * 0x3980)), new byte[] { 0x43, 80, 0x19, 0x40, 0x44, 0xbf, 0x5d, 0x4d, 0x43, 0x6a, 0x58 });
                PS3.SetMemory((uint)(0x1138e1c + (client * 0x3980)), new byte[] { 0x43, 80, 0x19, 0x40, 0x44, 0xbf, 0x5d, 0x4d, 0x43, 0x6a, 0x58 });
                PS3.SetMemory((uint)(0x113c79c + (client * 0x3980)), new byte[] { 0x43, 80, 0x19, 0x40, 0x44, 0xbf, 0x5d, 0x4d, 0x43, 0x6a, 0x58 });
                PS3.SetMemory((uint)(0x114011c + (client * 0x3980)), new byte[] { 0x43, 80, 0x19, 0x40, 0x44, 0xbf, 0x5d, 0x4d, 0x43, 0x6a, 0x58 });
                PS3.SetMemory((uint)(0x1143a9c + (client * 0x3980)), new byte[] { 0x43, 80, 0x19, 0x40, 0x44, 0xbf, 0x5d, 0x4d, 0x43, 0x6a, 0x58 });
                PS3.SetMemory((uint)(0x114741c + (client * 0x3980)), new byte[] { 0x43, 80, 0x19, 0x40, 0x44, 0xbf, 0x5d, 0x4d, 0x43, 0x6a, 0x58 });
                RPC_MW3.iPrintlnBold(client, "Teleported to ^2Bootleg^7 Secret Room");
            }
            if (getMapNamemw3() == "Carbon")
            {
                PS3.SetMemory((uint)(0x110a29c + (client * 0x3980)), new byte[] { 0xc4, 0xad, 0x62, 170, 0xc5, 0xe9, 0x25, 0x88, 0x45, 150, 0x35, 0x89 });
                PS3.SetMemory((uint)(0x110dc1c + (client * 0x3980)), new byte[] { 0xc4, 0xad, 0x62, 170, 0xc5, 0xe9, 0x25, 0x88, 0x45, 150, 0x35, 0x89 });
                PS3.SetMemory((uint)(0x111159c + (client * 0x3980)), new byte[] { 0xc4, 0xad, 0x62, 170, 0xc5, 0xe9, 0x25, 0x88, 0x45, 150, 0x35, 0x89 });
                PS3.SetMemory((uint)(0x1114f1c + (client * 0x3980)), new byte[] { 0xc4, 0xad, 0x62, 170, 0xc5, 0xe9, 0x25, 0x88, 0x45, 150, 0x35, 0x89 });
                PS3.SetMemory((uint)(0x111889c + (client * 0x3980)), new byte[] { 0xc4, 0xad, 0x62, 170, 0xc5, 0xe9, 0x25, 0x88, 0x45, 150, 0x35, 0x89 });
                PS3.SetMemory((uint)(0x111c21c + (client * 0x3980)), new byte[] { 0xc4, 0xad, 0x62, 170, 0xc5, 0xe9, 0x25, 0x88, 0x45, 150, 0x35, 0x89 });
                PS3.SetMemory((uint)(0x111fb9c + (client * 0x3980)), new byte[] { 0xc4, 0xad, 0x62, 170, 0xc5, 0xe9, 0x25, 0x88, 0x45, 150, 0x35, 0x89 });
                PS3.SetMemory((uint)(0x112351c + (client * 0x3980)), new byte[] { 0xc4, 0xad, 0x62, 170, 0xc5, 0xe9, 0x25, 0x88, 0x45, 150, 0x35, 0x89 });
                PS3.SetMemory((uint)(0x1126e9c + (client * 0x3980)), new byte[] { 0xc4, 0xad, 0x62, 170, 0xc5, 0xe9, 0x25, 0x88, 0x45, 150, 0x35, 0x89 });
                PS3.SetMemory((uint)(0x112a81c + (client * 0x3980)), new byte[] { 0xc4, 0xad, 0x62, 170, 0xc5, 0xe9, 0x25, 0x88, 0x45, 150, 0x35, 0x89 });
                PS3.SetMemory((uint)(0x112e19c + (client * 0x3980)), new byte[] { 0xc4, 0xad, 0x62, 170, 0xc5, 0xe9, 0x25, 0x88, 0x45, 150, 0x35, 0x89 });
                PS3.SetMemory((uint)(0x1131b1c + (client * 0x3980)), new byte[] { 0xc4, 0xad, 0x62, 170, 0xc5, 0xe9, 0x25, 0x88, 0x45, 150, 0x35, 0x89 });
                PS3.SetMemory((uint)(0x113549c + (client * 0x3980)), new byte[] { 0xc4, 0xad, 0x62, 170, 0xc5, 0xe9, 0x25, 0x88, 0x45, 150, 0x35, 0x89 });
                PS3.SetMemory((uint)(0x1138e1c + (client * 0x3980)), new byte[] { 0xc4, 0xad, 0x62, 170, 0xc5, 0xe9, 0x25, 0x88, 0x45, 150, 0x35, 0x89 });
                PS3.SetMemory((uint)(0x113c79c + (client * 0x3980)), new byte[] { 0xc4, 0xad, 0x62, 170, 0xc5, 0xe9, 0x25, 0x88, 0x45, 150, 0x35, 0x89 });
                PS3.SetMemory((uint)(0x114011c + (client * 0x3980)), new byte[] { 0xc4, 0xad, 0x62, 170, 0xc5, 0xe9, 0x25, 0x88, 0x45, 150, 0x35, 0x89 });
                PS3.SetMemory((uint)(0x1143a9c + (client * 0x3980)), new byte[] { 0xc4, 0xad, 0x62, 170, 0xc5, 0xe9, 0x25, 0x88, 0x45, 150, 0x35, 0x89 });
                PS3.SetMemory((uint)(0x114741c + (client * 0x3980)), new byte[] { 0xc4, 0xad, 0x62, 170, 0xc5, 0xe9, 0x25, 0x88, 0x45, 150, 0x35, 0x89 });
                RPC_MW3.iPrintlnBold(client, "Teleported to ^2Carbon^7 Secret Room");
            }
            if (getMapNamemw3() == "Hardhat")
            {
                PS3.SetMemory((uint)(0x110a29c + (client * 0x3980)), new byte[] { 0x44, 0xe4, 0xb5, 0xb1, 0xc4, 3, 0xa8, 0xc3, 0x44, 0xcd, 4 });
                PS3.SetMemory((uint)(0x110dc1c + (client * 0x3980)), new byte[] { 0x44, 0xe4, 0xb5, 0xb1, 0xc4, 3, 0xa8, 0xc3, 0x44, 0xcd, 4 });
                PS3.SetMemory((uint)(0x111159c + (client * 0x3980)), new byte[] { 0x44, 0xe4, 0xb5, 0xb1, 0xc4, 3, 0xa8, 0xc3, 0x44, 0xcd, 4 });
                PS3.SetMemory((uint)(0x1114f1c + (client * 0x3980)), new byte[] { 0x44, 0xe4, 0xb5, 0xb1, 0xc4, 3, 0xa8, 0xc3, 0x44, 0xcd, 4 });
                PS3.SetMemory((uint)(0x111889c + (client * 0x3980)), new byte[] { 0x44, 0xe4, 0xb5, 0xb1, 0xc4, 3, 0xa8, 0xc3, 0x44, 0xcd, 4 });
                PS3.SetMemory((uint)(0x111c21c + (client * 0x3980)), new byte[] { 0x44, 0xe4, 0xb5, 0xb1, 0xc4, 3, 0xa8, 0xc3, 0x44, 0xcd, 4 });
                PS3.SetMemory((uint)(0x111fb9c + (client * 0x3980)), new byte[] { 0x44, 0xe4, 0xb5, 0xb1, 0xc4, 3, 0xa8, 0xc3, 0x44, 0xcd, 4 });
                PS3.SetMemory((uint)(0x112351c + (client * 0x3980)), new byte[] { 0x44, 0xe4, 0xb5, 0xb1, 0xc4, 3, 0xa8, 0xc3, 0x44, 0xcd, 4 });
                PS3.SetMemory((uint)(0x1126e9c + (client * 0x3980)), new byte[] { 0x44, 0xe4, 0xb5, 0xb1, 0xc4, 3, 0xa8, 0xc3, 0x44, 0xcd, 4 });
                PS3.SetMemory((uint)(0x112a81c + (client * 0x3980)), new byte[] { 0x44, 0xe4, 0xb5, 0xb1, 0xc4, 3, 0xa8, 0xc3, 0x44, 0xcd, 4 });
                PS3.SetMemory((uint)(0x112e19c + (client * 0x3980)), new byte[] { 0x44, 0xe4, 0xb5, 0xb1, 0xc4, 3, 0xa8, 0xc3, 0x44, 0xcd, 4 });
                PS3.SetMemory((uint)(0x1131b1c + (client * 0x3980)), new byte[] { 0x44, 0xe4, 0xb5, 0xb1, 0xc4, 3, 0xa8, 0xc3, 0x44, 0xcd, 4 });
                PS3.SetMemory((uint)(0x113549c + (client * 0x3980)), new byte[] { 0x44, 0xe4, 0xb5, 0xb1, 0xc4, 3, 0xa8, 0xc3, 0x44, 0xcd, 4 });
                PS3.SetMemory((uint)(0x1138e1c + (client * 0x3980)), new byte[] { 0x44, 0xe4, 0xb5, 0xb1, 0xc4, 3, 0xa8, 0xc3, 0x44, 0xcd, 4 });
                PS3.SetMemory((uint)(0x113c79c + (client * 0x3980)), new byte[] { 0x44, 0xe4, 0xb5, 0xb1, 0xc4, 3, 0xa8, 0xc3, 0x44, 0xcd, 4 });
                PS3.SetMemory((uint)(0x114011c + (client * 0x3980)), new byte[] { 0x44, 0xe4, 0xb5, 0xb1, 0xc4, 3, 0xa8, 0xc3, 0x44, 0xcd, 4 });
                PS3.SetMemory((uint)(0x1143a9c + (client * 0x3980)), new byte[] { 0x44, 0xe4, 0xb5, 0xb1, 0xc4, 3, 0xa8, 0xc3, 0x44, 0xcd, 4 });
                PS3.SetMemory((uint)(0x114741c + (client * 0x3980)), new byte[] { 0x44, 0xe4, 0xb5, 0xb1, 0xc4, 3, 0xa8, 0xc3, 0x44, 0xcd, 4 });
                RPC_MW3.iPrintlnBold(client, "Teleported to ^2Hardhat^7 Secret Room");
            }
            if (getMapNamemw3() == "Lockdown")
            {
                PS3.SetMemory((uint)(0x110a29c + (client * 0x3980)), new byte[] { 0xc4, 0x76, 0x87, 0xcc, 0x45, 0x42, 0xa1, 0x57, 0x43, 0x92, 0x10 });
                PS3.SetMemory((uint)(0x110dc1c + (client * 0x3980)), new byte[] { 0xc4, 0x76, 0x87, 0xcc, 0x45, 0x42, 0xa1, 0x57, 0x43, 0x92, 0x10 });
                PS3.SetMemory((uint)(0x111159c + (client * 0x3980)), new byte[] { 0xc4, 0x76, 0x87, 0xcc, 0x45, 0x42, 0xa1, 0x57, 0x43, 0x92, 0x10 });
                PS3.SetMemory((uint)(0x1114f1c + (client * 0x3980)), new byte[] { 0xc4, 0x76, 0x87, 0xcc, 0x45, 0x42, 0xa1, 0x57, 0x43, 0x92, 0x10 });
                PS3.SetMemory((uint)(0x111889c + (client * 0x3980)), new byte[] { 0xc4, 0x76, 0x87, 0xcc, 0x45, 0x42, 0xa1, 0x57, 0x43, 0x92, 0x10 });
                PS3.SetMemory((uint)(0x111c21c + (client * 0x3980)), new byte[] { 0xc4, 0x76, 0x87, 0xcc, 0x45, 0x42, 0xa1, 0x57, 0x43, 0x92, 0x10 });
                PS3.SetMemory((uint)(0x111fb9c + (client * 0x3980)), new byte[] { 0xc4, 0x76, 0x87, 0xcc, 0x45, 0x42, 0xa1, 0x57, 0x43, 0x92, 0x10 });
                PS3.SetMemory((uint)(0x112351c + (client * 0x3980)), new byte[] { 0xc4, 0x76, 0x87, 0xcc, 0x45, 0x42, 0xa1, 0x57, 0x43, 0x92, 0x10 });
                PS3.SetMemory((uint)(0x1126e9c + (client * 0x3980)), new byte[] { 0xc4, 0x76, 0x87, 0xcc, 0x45, 0x42, 0xa1, 0x57, 0x43, 0x92, 0x10 });
                PS3.SetMemory((uint)(0x112a81c + (client * 0x3980)), new byte[] { 0xc4, 0x76, 0x87, 0xcc, 0x45, 0x42, 0xa1, 0x57, 0x43, 0x92, 0x10 });
                PS3.SetMemory((uint)(0x112e19c + (client * 0x3980)), new byte[] { 0xc4, 0x76, 0x87, 0xcc, 0x45, 0x42, 0xa1, 0x57, 0x43, 0x92, 0x10 });
                PS3.SetMemory((uint)(0x1131b1c + (client * 0x3980)), new byte[] { 0xc4, 0x76, 0x87, 0xcc, 0x45, 0x42, 0xa1, 0x57, 0x43, 0x92, 0x10 });
                PS3.SetMemory((uint)(0x113549c + (client * 0x3980)), new byte[] { 0xc4, 0x76, 0x87, 0xcc, 0x45, 0x42, 0xa1, 0x57, 0x43, 0x92, 0x10 });
                PS3.SetMemory((uint)(0x1138e1c + (client * 0x3980)), new byte[] { 0xc4, 0x76, 0x87, 0xcc, 0x45, 0x42, 0xa1, 0x57, 0x43, 0x92, 0x10 });
                PS3.SetMemory((uint)(0x113c79c + (client * 0x3980)), new byte[] { 0xc4, 0x76, 0x87, 0xcc, 0x45, 0x42, 0xa1, 0x57, 0x43, 0x92, 0x10 });
                PS3.SetMemory((uint)(0x114011c + (client * 0x3980)), new byte[] { 0xc4, 0x76, 0x87, 0xcc, 0x45, 0x42, 0xa1, 0x57, 0x43, 0x92, 0x10 });
                PS3.SetMemory((uint)(0x1143a9c + (client * 0x3980)), new byte[] { 0xc4, 0x76, 0x87, 0xcc, 0x45, 0x42, 0xa1, 0x57, 0x43, 0x92, 0x10 });
                PS3.SetMemory((uint)(0x114741c + (client * 0x3980)), new byte[] { 0xc4, 0x76, 0x87, 0xcc, 0x45, 0x42, 0xa1, 0x57, 0x43, 0x92, 0x10 });
                RPC_MW3.iPrintlnBold(client, "Teleported to ^2Lockdown^7 Secret Room");
            }
            if (getMapNamemw3() == "Village")
            {
                PS3.SetMemory((uint)(0x110a29c + (client * 0x3980)), new byte[] { 0xc4, 0x98, 5, 0x16, 0xc5, 0x31, 0x68, 6, 0x44, 0xa8, 4 });
                PS3.SetMemory((uint)(0x110dc1c + (client * 0x3980)), new byte[] { 0xc4, 0x98, 5, 0x16, 0xc5, 0x31, 0x68, 6, 0x44, 0xa8, 4 });
                PS3.SetMemory((uint)(0x111159c + (client * 0x3980)), new byte[] { 0xc4, 0x98, 5, 0x16, 0xc5, 0x31, 0x68, 6, 0x44, 0xa8, 4 });
                PS3.SetMemory((uint)(0x1114f1c + (client * 0x3980)), new byte[] { 0xc4, 0x98, 5, 0x16, 0xc5, 0x31, 0x68, 6, 0x44, 0xa8, 4 });
                PS3.SetMemory((uint)(0x111889c + (client * 0x3980)), new byte[] { 0xc4, 0x98, 5, 0x16, 0xc5, 0x31, 0x68, 6, 0x44, 0xa8, 4 });
                PS3.SetMemory((uint)(0x111c21c + (client * 0x3980)), new byte[] { 0xc4, 0x98, 5, 0x16, 0xc5, 0x31, 0x68, 6, 0x44, 0xa8, 4 });
                PS3.SetMemory((uint)(0x111fb9c + (client * 0x3980)), new byte[] { 0xc4, 0x98, 5, 0x16, 0xc5, 0x31, 0x68, 6, 0x44, 0xa8, 4 });
                PS3.SetMemory((uint)(0x112351c + (client * 0x3980)), new byte[] { 0xc4, 0x98, 5, 0x16, 0xc5, 0x31, 0x68, 6, 0x44, 0xa8, 4 });
                PS3.SetMemory((uint)(0x1126e9c + (client * 0x3980)), new byte[] { 0xc4, 0x98, 5, 0x16, 0xc5, 0x31, 0x68, 6, 0x44, 0xa8, 4 });
                PS3.SetMemory((uint)(0x112a81c + (client * 0x3980)), new byte[] { 0xc4, 0x98, 5, 0x16, 0xc5, 0x31, 0x68, 6, 0x44, 0xa8, 4 });
                PS3.SetMemory((uint)(0x112e19c + (client * 0x3980)), new byte[] { 0xc4, 0x98, 5, 0x16, 0xc5, 0x31, 0x68, 6, 0x44, 0xa8, 4 });
                PS3.SetMemory((uint)(0x1131b1c + (client * 0x3980)), new byte[] { 0xc4, 0x98, 5, 0x16, 0xc5, 0x31, 0x68, 6, 0x44, 0xa8, 4 });
                PS3.SetMemory((uint)(0x113549c + (client * 0x3980)), new byte[] { 0xc4, 0x98, 5, 0x16, 0xc5, 0x31, 0x68, 6, 0x44, 0xa8, 4 });
                PS3.SetMemory((uint)(0x1138e1c + (client * 0x3980)), new byte[] { 0xc4, 0x98, 5, 0x16, 0xc5, 0x31, 0x68, 6, 0x44, 0xa8, 4 });
                PS3.SetMemory((uint)(0x113c79c + (client * 0x3980)), new byte[] { 0xc4, 0x98, 5, 0x16, 0xc5, 0x31, 0x68, 6, 0x44, 0xa8, 4 });
                PS3.SetMemory((uint)(0x114011c + (client * 0x3980)), new byte[] { 0xc4, 0x98, 5, 0x16, 0xc5, 0x31, 0x68, 6, 0x44, 0xa8, 4 });
                PS3.SetMemory((uint)(0x1143a9c + (client * 0x3980)), new byte[] { 0xc4, 0x98, 5, 0x16, 0xc5, 0x31, 0x68, 6, 0x44, 0xa8, 4 });
                PS3.SetMemory((uint)(0x114741c + (client * 0x3980)), new byte[] { 0xc4, 0x98, 5, 0x16, 0xc5, 0x31, 0x68, 6, 0x44, 0xa8, 4 });
                RPC_MW3.iPrintlnBold(client, "Teleported to ^2Village^7 Secret Room");
            }
            if (getMapNamemw3() == "Fallen")
            {
                PS3.SetMemory((uint)(0x110a29c + (client * 0x3980)), new byte[] { 0xc5, 0x1b, 0x94, 0x7b, 0x43, 0xdb, 0x97, 0x26, 0x44, 0x88, 4 });
                PS3.SetMemory((uint)(0x110dc1c + (client * 0x3980)), new byte[] { 0xc5, 0x1b, 0x94, 0x7b, 0x43, 0xdb, 0x97, 0x26, 0x44, 0x88, 4 });
                PS3.SetMemory((uint)(0x111159c + (client * 0x3980)), new byte[] { 0xc5, 0x1b, 0x94, 0x7b, 0x43, 0xdb, 0x97, 0x26, 0x44, 0x88, 4 });
                PS3.SetMemory((uint)(0x1114f1c + (client * 0x3980)), new byte[] { 0xc5, 0x1b, 0x94, 0x7b, 0x43, 0xdb, 0x97, 0x26, 0x44, 0x88, 4 });
                PS3.SetMemory((uint)(0x111889c + (client * 0x3980)), new byte[] { 0xc5, 0x1b, 0x94, 0x7b, 0x43, 0xdb, 0x97, 0x26, 0x44, 0x88, 4 });
                PS3.SetMemory((uint)(0x111c21c + (client * 0x3980)), new byte[] { 0xc5, 0x1b, 0x94, 0x7b, 0x43, 0xdb, 0x97, 0x26, 0x44, 0x88, 4 });
                PS3.SetMemory((uint)(0x111fb9c + (client * 0x3980)), new byte[] { 0xc5, 0x1b, 0x94, 0x7b, 0x43, 0xdb, 0x97, 0x26, 0x44, 0x88, 4 });
                PS3.SetMemory((uint)(0x112351c + (client * 0x3980)), new byte[] { 0xc5, 0x1b, 0x94, 0x7b, 0x43, 0xdb, 0x97, 0x26, 0x44, 0x88, 4 });
                PS3.SetMemory((uint)(0x1126e9c + (client * 0x3980)), new byte[] { 0xc5, 0x1b, 0x94, 0x7b, 0x43, 0xdb, 0x97, 0x26, 0x44, 0x88, 4 });
                PS3.SetMemory((uint)(0x112a81c + (client * 0x3980)), new byte[] { 0xc5, 0x1b, 0x94, 0x7b, 0x43, 0xdb, 0x97, 0x26, 0x44, 0x88, 4 });
                PS3.SetMemory((uint)(0x112e19c + (client * 0x3980)), new byte[] { 0xc5, 0x1b, 0x94, 0x7b, 0x43, 0xdb, 0x97, 0x26, 0x44, 0x88, 4 });
                PS3.SetMemory((uint)(0x1131b1c + (client * 0x3980)), new byte[] { 0xc5, 0x1b, 0x94, 0x7b, 0x43, 0xdb, 0x97, 0x26, 0x44, 0x88, 4 });
                PS3.SetMemory((uint)(0x113549c + (client * 0x3980)), new byte[] { 0xc5, 0x1b, 0x94, 0x7b, 0x43, 0xdb, 0x97, 0x26, 0x44, 0x88, 4 });
                PS3.SetMemory((uint)(0x1138e1c + (client * 0x3980)), new byte[] { 0xc5, 0x1b, 0x94, 0x7b, 0x43, 0xdb, 0x97, 0x26, 0x44, 0x88, 4 });
                PS3.SetMemory((uint)(0x113c79c + (client * 0x3980)), new byte[] { 0xc5, 0x1b, 0x94, 0x7b, 0x43, 0xdb, 0x97, 0x26, 0x44, 0x88, 4 });
                PS3.SetMemory((uint)(0x114011c + (client * 0x3980)), new byte[] { 0xc5, 0x1b, 0x94, 0x7b, 0x43, 0xdb, 0x97, 0x26, 0x44, 0x88, 4 });
                PS3.SetMemory((uint)(0x1143a9c + (client * 0x3980)), new byte[] { 0xc5, 0x1b, 0x94, 0x7b, 0x43, 0xdb, 0x97, 0x26, 0x44, 0x88, 4 });
                PS3.SetMemory((uint)(0x114741c + (client * 0x3980)), new byte[] { 0xc5, 0x1b, 0x94, 0x7b, 0x43, 0xdb, 0x97, 0x26, 0x44, 0x88, 4 });
                RPC_MW3.iPrintlnBold(client, "Teleported to ^2Fallen^7 Secret Room");
            }
            if (getMapNamemw3() == "Outpost")
            {
                PS3.SetMemory((uint)(0x110a29c + (client * 0x3980)), new byte[] { 0xc5, 0xab, 0x2d, 0x7e, 0x41, 12, 3, 210, 0x45, 0x40, 0xba, 0xf8 });
                PS3.SetMemory((uint)(0x110dc1c + (client * 0x3980)), new byte[] { 0xc5, 0xab, 0x2d, 0x7e, 0x41, 12, 3, 210, 0x45, 0x40, 0xba, 0xf8 });
                PS3.SetMemory((uint)(0x111159c + (client * 0x3980)), new byte[] { 0xc5, 0xab, 0x2d, 0x7e, 0x41, 12, 3, 210, 0x45, 0x40, 0xba, 0xf8 });
                PS3.SetMemory((uint)(0x1114f1c + (client * 0x3980)), new byte[] { 0xc5, 0xab, 0x2d, 0x7e, 0x41, 12, 3, 210, 0x45, 0x40, 0xba, 0xf8 });
                PS3.SetMemory((uint)(0x111889c + (client * 0x3980)), new byte[] { 0xc5, 0xab, 0x2d, 0x7e, 0x41, 12, 3, 210, 0x45, 0x40, 0xba, 0xf8 });
                PS3.SetMemory((uint)(0x111c21c + (client * 0x3980)), new byte[] { 0xc5, 0xab, 0x2d, 0x7e, 0x41, 12, 3, 210, 0x45, 0x40, 0xba, 0xf8 });
                PS3.SetMemory((uint)(0x111fb9c + (client * 0x3980)), new byte[] { 0xc5, 0xab, 0x2d, 0x7e, 0x41, 12, 3, 210, 0x45, 0x40, 0xba, 0xf8 });
                PS3.SetMemory((uint)(0x112351c + (client * 0x3980)), new byte[] { 0xc5, 0xab, 0x2d, 0x7e, 0x41, 12, 3, 210, 0x45, 0x40, 0xba, 0xf8 });
                PS3.SetMemory((uint)(0x1126e9c + (client * 0x3980)), new byte[] { 0xc5, 0xab, 0x2d, 0x7e, 0x41, 12, 3, 210, 0x45, 0x40, 0xba, 0xf8 });
                PS3.SetMemory((uint)(0x112a81c + (client * 0x3980)), new byte[] { 0xc5, 0xab, 0x2d, 0x7e, 0x41, 12, 3, 210, 0x45, 0x40, 0xba, 0xf8 });
                PS3.SetMemory((uint)(0x112e19c + (client * 0x3980)), new byte[] { 0xc5, 0xab, 0x2d, 0x7e, 0x41, 12, 3, 210, 0x45, 0x40, 0xba, 0xf8 });
                PS3.SetMemory((uint)(0x1131b1c + (client * 0x3980)), new byte[] { 0xc5, 0xab, 0x2d, 0x7e, 0x41, 12, 3, 210, 0x45, 0x40, 0xba, 0xf8 });
                PS3.SetMemory((uint)(0x113549c + (client * 0x3980)), new byte[] { 0xc5, 0xab, 0x2d, 0x7e, 0x41, 12, 3, 210, 0x45, 0x40, 0xba, 0xf8 });
                PS3.SetMemory((uint)(0x1138e1c + (client * 0x3980)), new byte[] { 0xc5, 0xab, 0x2d, 0x7e, 0x41, 12, 3, 210, 0x45, 0x40, 0xba, 0xf8 });
                PS3.SetMemory((uint)(0x113c79c + (client * 0x3980)), new byte[] { 0xc5, 0xab, 0x2d, 0x7e, 0x41, 12, 3, 210, 0x45, 0x40, 0xba, 0xf8 });
                PS3.SetMemory((uint)(0x114011c + (client * 0x3980)), new byte[] { 0xc5, 0xab, 0x2d, 0x7e, 0x41, 12, 3, 210, 0x45, 0x40, 0xba, 0xf8 });
                PS3.SetMemory((uint)(0x1143a9c + (client * 0x3980)), new byte[] { 0xc5, 0xab, 0x2d, 0x7e, 0x41, 12, 3, 210, 0x45, 0x40, 0xba, 0xf8 });
                PS3.SetMemory((uint)(0x114741c + (client * 0x3980)), new byte[] { 0xc5, 0xab, 0x2d, 0x7e, 0x41, 12, 3, 210, 0x45, 0x40, 0xba, 0xf8 });
                RPC_MW3.iPrintlnBold(client, "Teleported to ^2Outpost^7 Secret Room");
            }
            if (getMapNamemw3() == "Interchange")
            {
                PS3.SetMemory((uint)(0x110a29c + (client * 0x3980)), new byte[] { 0x45, 100, 0x9d, 0x8e, 0x42, 0xbd, 0x6d, 0xab, 0x43, 0xd8, 0x90 });
                PS3.SetMemory((uint)(0x110dc1c + (client * 0x3980)), new byte[] { 0x45, 100, 0x9d, 0x8e, 0x42, 0xbd, 0x6d, 0xab, 0x43, 0xd8, 0x90 });
                PS3.SetMemory((uint)(0x111159c + (client * 0x3980)), new byte[] { 0x45, 100, 0x9d, 0x8e, 0x42, 0xbd, 0x6d, 0xab, 0x43, 0xd8, 0x90 });
                PS3.SetMemory((uint)(0x1114f1c + (client * 0x3980)), new byte[] { 0x45, 100, 0x9d, 0x8e, 0x42, 0xbd, 0x6d, 0xab, 0x43, 0xd8, 0x90 });
                PS3.SetMemory((uint)(0x111889c + (client * 0x3980)), new byte[] { 0x45, 100, 0x9d, 0x8e, 0x42, 0xbd, 0x6d, 0xab, 0x43, 0xd8, 0x90 });
                PS3.SetMemory((uint)(0x111c21c + (client * 0x3980)), new byte[] { 0x45, 100, 0x9d, 0x8e, 0x42, 0xbd, 0x6d, 0xab, 0x43, 0xd8, 0x90 });
                PS3.SetMemory((uint)(0x111fb9c + (client * 0x3980)), new byte[] { 0x45, 100, 0x9d, 0x8e, 0x42, 0xbd, 0x6d, 0xab, 0x43, 0xd8, 0x90 });
                PS3.SetMemory((uint)(0x112351c + (client * 0x3980)), new byte[] { 0x45, 100, 0x9d, 0x8e, 0x42, 0xbd, 0x6d, 0xab, 0x43, 0xd8, 0x90 });
                PS3.SetMemory((uint)(0x1126e9c + (client * 0x3980)), new byte[] { 0x45, 100, 0x9d, 0x8e, 0x42, 0xbd, 0x6d, 0xab, 0x43, 0xd8, 0x90 });
                PS3.SetMemory((uint)(0x112a81c + (client * 0x3980)), new byte[] { 0x45, 100, 0x9d, 0x8e, 0x42, 0xbd, 0x6d, 0xab, 0x43, 0xd8, 0x90 });
                PS3.SetMemory((uint)(0x112e19c + (client * 0x3980)), new byte[] { 0x45, 100, 0x9d, 0x8e, 0x42, 0xbd, 0x6d, 0xab, 0x43, 0xd8, 0x90 });
                PS3.SetMemory((uint)(0x1131b1c + (client * 0x3980)), new byte[] { 0x45, 100, 0x9d, 0x8e, 0x42, 0xbd, 0x6d, 0xab, 0x43, 0xd8, 0x90 });
                PS3.SetMemory((uint)(0x113549c + (client * 0x3980)), new byte[] { 0x45, 100, 0x9d, 0x8e, 0x42, 0xbd, 0x6d, 0xab, 0x43, 0xd8, 0x90 });
                PS3.SetMemory((uint)(0x1138e1c + (client * 0x3980)), new byte[] { 0x45, 100, 0x9d, 0x8e, 0x42, 0xbd, 0x6d, 0xab, 0x43, 0xd8, 0x90 });
                PS3.SetMemory((uint)(0x113c79c + (client * 0x3980)), new byte[] { 0x45, 100, 0x9d, 0x8e, 0x42, 0xbd, 0x6d, 0xab, 0x43, 0xd8, 0x90 });
                PS3.SetMemory((uint)(0x114011c + (client * 0x3980)), new byte[] { 0x45, 100, 0x9d, 0x8e, 0x42, 0xbd, 0x6d, 0xab, 0x43, 0xd8, 0x90 });
                PS3.SetMemory((uint)(0x1143a9c + (client * 0x3980)), new byte[] { 0x45, 100, 0x9d, 0x8e, 0x42, 0xbd, 0x6d, 0xab, 0x43, 0xd8, 0x90 });
                PS3.SetMemory((uint)(0x114741c + (client * 0x3980)), new byte[] { 0x45, 100, 0x9d, 0x8e, 0x42, 0xbd, 0x6d, 0xab, 0x43, 0xd8, 0x90 });
                RPC_MW3.iPrintlnBold(client, "Teleported to ^2Interchange^7 Secret Room");
            }
            if (getMapNamemw3() == "Underground")
            {
                PS3.SetMemory((uint)(0x110a29c + (client * 0x3980)), new byte[] { 0xc6, 0x3a, 0xf9, 0x25, 0xc5, 0x8a, 0xfc, 0x98, 0x45, 0xa5, 0x60 });
                PS3.SetMemory((uint)(0x110dc1c + (client * 0x3980)), new byte[] { 0xc6, 0x3a, 0xf9, 0x25, 0xc5, 0x8a, 0xfc, 0x98, 0x45, 0xa5, 0x60 });
                PS3.SetMemory((uint)(0x111159c + (client * 0x3980)), new byte[] { 0xc6, 0x3a, 0xf9, 0x25, 0xc5, 0x8a, 0xfc, 0x98, 0x45, 0xa5, 0x60 });
                PS3.SetMemory((uint)(0x1114f1c + (client * 0x3980)), new byte[] { 0xc6, 0x3a, 0xf9, 0x25, 0xc5, 0x8a, 0xfc, 0x98, 0x45, 0xa5, 0x60 });
                PS3.SetMemory((uint)(0x111889c + (client * 0x3980)), new byte[] { 0xc6, 0x3a, 0xf9, 0x25, 0xc5, 0x8a, 0xfc, 0x98, 0x45, 0xa5, 0x60 });
                PS3.SetMemory((uint)(0x111c21c + (client * 0x3980)), new byte[] { 0xc6, 0x3a, 0xf9, 0x25, 0xc5, 0x8a, 0xfc, 0x98, 0x45, 0xa5, 0x60 });
                PS3.SetMemory((uint)(0x111fb9c + (client * 0x3980)), new byte[] { 0xc6, 0x3a, 0xf9, 0x25, 0xc5, 0x8a, 0xfc, 0x98, 0x45, 0xa5, 0x60 });
                PS3.SetMemory((uint)(0x112351c + (client * 0x3980)), new byte[] { 0xc6, 0x3a, 0xf9, 0x25, 0xc5, 0x8a, 0xfc, 0x98, 0x45, 0xa5, 0x60 });
                PS3.SetMemory((uint)(0x1126e9c + (client * 0x3980)), new byte[] { 0xc6, 0x3a, 0xf9, 0x25, 0xc5, 0x8a, 0xfc, 0x98, 0x45, 0xa5, 0x60 });
                PS3.SetMemory((uint)(0x112a81c + (client * 0x3980)), new byte[] { 0xc6, 0x3a, 0xf9, 0x25, 0xc5, 0x8a, 0xfc, 0x98, 0x45, 0xa5, 0x60 });
                PS3.SetMemory((uint)(0x112e19c + (client * 0x3980)), new byte[] { 0xc6, 0x3a, 0xf9, 0x25, 0xc5, 0x8a, 0xfc, 0x98, 0x45, 0xa5, 0x60 });
                PS3.SetMemory((uint)(0x1131b1c + (client * 0x3980)), new byte[] { 0xc6, 0x3a, 0xf9, 0x25, 0xc5, 0x8a, 0xfc, 0x98, 0x45, 0xa5, 0x60 });
                PS3.SetMemory((uint)(0x113549c + (client * 0x3980)), new byte[] { 0xc6, 0x3a, 0xf9, 0x25, 0xc5, 0x8a, 0xfc, 0x98, 0x45, 0xa5, 0x60 });
                PS3.SetMemory((uint)(0x1138e1c + (client * 0x3980)), new byte[] { 0xc6, 0x3a, 0xf9, 0x25, 0xc5, 0x8a, 0xfc, 0x98, 0x45, 0xa5, 0x60 });
                PS3.SetMemory((uint)(0x113c79c + (client * 0x3980)), new byte[] { 0xc6, 0x3a, 0xf9, 0x25, 0xc5, 0x8a, 0xfc, 0x98, 0x45, 0xa5, 0x60 });
                PS3.SetMemory((uint)(0x114011c + (client * 0x3980)), new byte[] { 0xc6, 0x3a, 0xf9, 0x25, 0xc5, 0x8a, 0xfc, 0x98, 0x45, 0xa5, 0x60 });
                PS3.SetMemory((uint)(0x1143a9c + (client * 0x3980)), new byte[] { 0xc6, 0x3a, 0xf9, 0x25, 0xc5, 0x8a, 0xfc, 0x98, 0x45, 0xa5, 0x60 });
                PS3.SetMemory((uint)(0x114741c + (client * 0x3980)), new byte[] { 0xc6, 0x3a, 0xf9, 0x25, 0xc5, 0x8a, 0xfc, 0x98, 0x45, 0xa5, 0x60 });
                RPC_MW3.iPrintlnBold(client, "Teleported to ^2Underground^7 Secret Room");
            }
            if (getMapNamemw3() == "Mission")
            {
                PS3.SetMemory((uint)(0x110a29c + (client * 0x3980)), new byte[] { 0x44, 240, 0xa4, 0x52, 0x45, 0x53, 0x61, 0x83, 0x44, 0x98, 0xf9 });
                PS3.SetMemory((uint)(0x110dc1c + (client * 0x3980)), new byte[] { 0x44, 240, 0xa4, 0x52, 0x45, 0x53, 0x61, 0x83, 0x44, 0x98, 0xf9 });
                PS3.SetMemory((uint)(0x111159c + (client * 0x3980)), new byte[] { 0x44, 240, 0xa4, 0x52, 0x45, 0x53, 0x61, 0x83, 0x44, 0x98, 0xf9 });
                PS3.SetMemory((uint)(0x1114f1c + (client * 0x3980)), new byte[] { 0x44, 240, 0xa4, 0x52, 0x45, 0x53, 0x61, 0x83, 0x44, 0x98, 0xf9 });
                PS3.SetMemory((uint)(0x111889c + (client * 0x3980)), new byte[] { 0x44, 240, 0xa4, 0x52, 0x45, 0x53, 0x61, 0x83, 0x44, 0x98, 0xf9 });
                PS3.SetMemory((uint)(0x111c21c + (client * 0x3980)), new byte[] { 0x44, 240, 0xa4, 0x52, 0x45, 0x53, 0x61, 0x83, 0x44, 0x98, 0xf9 });
                PS3.SetMemory((uint)(0x111fb9c + (client * 0x3980)), new byte[] { 0x44, 240, 0xa4, 0x52, 0x45, 0x53, 0x61, 0x83, 0x44, 0x98, 0xf9 });
                PS3.SetMemory((uint)(0x112351c + (client * 0x3980)), new byte[] { 0x44, 240, 0xa4, 0x52, 0x45, 0x53, 0x61, 0x83, 0x44, 0x98, 0xf9 });
                PS3.SetMemory((uint)(0x1126e9c + (client * 0x3980)), new byte[] { 0x44, 240, 0xa4, 0x52, 0x45, 0x53, 0x61, 0x83, 0x44, 0x98, 0xf9 });
                PS3.SetMemory((uint)(0x112a81c + (client * 0x3980)), new byte[] { 0x44, 240, 0xa4, 0x52, 0x45, 0x53, 0x61, 0x83, 0x44, 0x98, 0xf9 });
                PS3.SetMemory((uint)(0x112e19c + (client * 0x3980)), new byte[] { 0x44, 240, 0xa4, 0x52, 0x45, 0x53, 0x61, 0x83, 0x44, 0x98, 0xf9 });
                PS3.SetMemory((uint)(0x1131b1c + (client * 0x3980)), new byte[] { 0x44, 240, 0xa4, 0x52, 0x45, 0x53, 0x61, 0x83, 0x44, 0x98, 0xf9 });
                PS3.SetMemory((uint)(0x113549c + (client * 0x3980)), new byte[] { 0x44, 240, 0xa4, 0x52, 0x45, 0x53, 0x61, 0x83, 0x44, 0x98, 0xf9 });
                PS3.SetMemory((uint)(0x1138e1c + (client * 0x3980)), new byte[] { 0x44, 240, 0xa4, 0x52, 0x45, 0x53, 0x61, 0x83, 0x44, 0x98, 0xf9 });
                PS3.SetMemory((uint)(0x113c79c + (client * 0x3980)), new byte[] { 0x44, 240, 0xa4, 0x52, 0x45, 0x53, 0x61, 0x83, 0x44, 0x98, 0xf9 });
                PS3.SetMemory((uint)(0x114011c + (client * 0x3980)), new byte[] { 0x44, 240, 0xa4, 0x52, 0x45, 0x53, 0x61, 0x83, 0x44, 0x98, 0xf9 });
                PS3.SetMemory((uint)(0x1143a9c + (client * 0x3980)), new byte[] { 0x44, 240, 0xa4, 0x52, 0x45, 0x53, 0x61, 0x83, 0x44, 0x98, 0xf9 });
                PS3.SetMemory((uint)(0x114741c + (client * 0x3980)), new byte[] { 0x44, 240, 0xa4, 0x52, 0x45, 0x53, 0x61, 0x83, 0x44, 0x98, 0xf9 });
                RPC_MW3.iPrintlnBold(client, "Teleported to ^2Mission^7 Secret Room");
            }
            if (getMapNamemw3() == "Terminal")
            {
                PS3.SetMemory((uint)(0x110a29c + (client * 0x3980)), new byte[] { 0x44, 0xfe, 0x1b, 10, 0x45, 0xf2, 0x4c, 0x24, 0x43, 0x40, 0x20 });
                PS3.SetMemory((uint)(0x110dc1c + (client * 0x3980)), new byte[] { 0x44, 0xfe, 0x1b, 10, 0x45, 0xf2, 0x4c, 0x24, 0x43, 0x40, 0x20 });
                PS3.SetMemory((uint)(0x111159c + (client * 0x3980)), new byte[] { 0x44, 0xfe, 0x1b, 10, 0x45, 0xf2, 0x4c, 0x24, 0x43, 0x40, 0x20 });
                PS3.SetMemory((uint)(0x1114f1c + (client * 0x3980)), new byte[] { 0x44, 0xfe, 0x1b, 10, 0x45, 0xf2, 0x4c, 0x24, 0x43, 0x40, 0x20 });
                PS3.SetMemory((uint)(0x111889c + (client * 0x3980)), new byte[] { 0x44, 0xfe, 0x1b, 10, 0x45, 0xf2, 0x4c, 0x24, 0x43, 0x40, 0x20 });
                PS3.SetMemory((uint)(0x111c21c + (client * 0x3980)), new byte[] { 0x44, 0xfe, 0x1b, 10, 0x45, 0xf2, 0x4c, 0x24, 0x43, 0x40, 0x20 });
                PS3.SetMemory((uint)(0x111fb9c + (client * 0x3980)), new byte[] { 0x44, 0xfe, 0x1b, 10, 0x45, 0xf2, 0x4c, 0x24, 0x43, 0x40, 0x20 });
                PS3.SetMemory((uint)(0x112351c + (client * 0x3980)), new byte[] { 0x44, 0xfe, 0x1b, 10, 0x45, 0xf2, 0x4c, 0x24, 0x43, 0x40, 0x20 });
                PS3.SetMemory((uint)(0x1126e9c + (client * 0x3980)), new byte[] { 0x44, 0xfe, 0x1b, 10, 0x45, 0xf2, 0x4c, 0x24, 0x43, 0x40, 0x20 });
                PS3.SetMemory((uint)(0x112a81c + (client * 0x3980)), new byte[] { 0x44, 0xfe, 0x1b, 10, 0x45, 0xf2, 0x4c, 0x24, 0x43, 0x40, 0x20 });
                PS3.SetMemory((uint)(0x112e19c + (client * 0x3980)), new byte[] { 0x44, 0xfe, 0x1b, 10, 0x45, 0xf2, 0x4c, 0x24, 0x43, 0x40, 0x20 });
                PS3.SetMemory((uint)(0x1131b1c + (client * 0x3980)), new byte[] { 0x44, 0xfe, 0x1b, 10, 0x45, 0xf2, 0x4c, 0x24, 0x43, 0x40, 0x20 });
                PS3.SetMemory((uint)(0x113549c + (client * 0x3980)), new byte[] { 0x44, 0xfe, 0x1b, 10, 0x45, 0xf2, 0x4c, 0x24, 0x43, 0x40, 0x20 });
                PS3.SetMemory((uint)(0x1138e1c + (client * 0x3980)), new byte[] { 0x44, 0xfe, 0x1b, 10, 0x45, 0xf2, 0x4c, 0x24, 0x43, 0x40, 0x20 });
                PS3.SetMemory((uint)(0x113c79c + (client * 0x3980)), new byte[] { 0x44, 0xfe, 0x1b, 10, 0x45, 0xf2, 0x4c, 0x24, 0x43, 0x40, 0x20 });
                PS3.SetMemory((uint)(0x114011c + (client * 0x3980)), new byte[] { 0x44, 0xfe, 0x1b, 10, 0x45, 0xf2, 0x4c, 0x24, 0x43, 0x40, 0x20 });
                PS3.SetMemory((uint)(0x1143a9c + (client * 0x3980)), new byte[] { 0x44, 0xfe, 0x1b, 10, 0x45, 0xf2, 0x4c, 0x24, 0x43, 0x40, 0x20 });
                PS3.SetMemory((uint)(0x114741c + (client * 0x3980)), new byte[] { 0x44, 0xfe, 0x1b, 10, 0x45, 0xf2, 0x4c, 0x24, 0x43, 0x40, 0x20 });
                RPC_MW3.iPrintlnBold(client, "Teleported to ^2Terminal^7 Secret Room");
            }
        }

        private void timer40_Tick(object sender, EventArgs e)
        {
            byte[] buffer = new byte[0x20];
            RPC_MW3.Set_ClientDvar(-1, "g_scriptmainmenu \"Mx444 Anti Quit\"");
            Thread.Sleep(10);
            PS3.SetMemory(0x523b30, buffer);
        }

        private void toolStripMenuItem35_Click(object sender, EventArgs e)
        {

        }

        private void onToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.CurrentRow.Index;
            RPC_MW3.SV_GameSendServerCommand(index, "l \"3\"");
            Thread.Sleep(50);
            RPC_MW3.Set_ClientDvar(index, "profile_setvolume 1");
        }

        private void offToolStripMenuItem15_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.CurrentRow.Index;
            RPC_MW3.SV_GameSendServerCommand(index, "l \"0\"");
            Thread.Sleep(50);
            RPC_MW3.Set_ClientDvar(index, "profile_setvolume 0");
        }

        #region type
        public uint CreateText11(string text)
        {
            RPC_MW3.CallFunction(0x1be6cc, this.str_pointer(text), 0, 0, 0, 0);
            Thread.Sleep(50);
            return RPC_MW3.GetFuncReturn();
        }
        public byte[] SetText(string text)
        {
            return uintBytes(CreateText1(text + "\0"));
        }
        public void doTypeWriter(uint ElemIndex, uint clientIndex, string text, float fontScale, int font, float float_9, float float_10, int fxLetterTime, int fxDecayStartTime, int fxDecayDuration, int r, int g, int b, int a, int r1, int b1, int g1, int a1)
        {
            string str = text + "\0";
            this.SetText(str);
            uint offset = this.G_HudElems + (ElemIndex * 180);
            byte[] buffer = ReverseBytes(BitConverter.GetBytes(clientIndex));
            PS3.SetMemory(offset, new byte[180]);
            PS3.SetMemory(offset, new byte[4]);
            PS3.SetMemory(offset + HElems.relativeOffset, new byte[] { 0, 0, 0, 0, 0x92, 0xff, 0xff, 0xff, 0xff });
            byte[] buffer2 = new byte[4];
            buffer2[3] = 5;
            PS3.SetMemory((offset + HElems.relativeOffset) - 4, buffer2);
            PS3.SetMemory(offset + HElems.fontOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(font))));
            PS3.SetMemory(offset + HElems.alignOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(0))));
            PS3.SetMemory((offset + HElems.textOffset) + 4, ReverseBytes(BitConverter.GetBytes(0)));
            PS3.SetMemory(offset + HElems.fontSizeOffset, ToHexFloat(fontScale));
            PS3.SetMemory(offset + HElems.xOffset, ToHexFloat(float_9));
            PS3.SetMemory(offset + HElems.yOffset, ToHexFloat(float_10));
            PS3.SetMemory(offset + HElems.colorOffset, RGBA(r, g, b, a));
            PS3.SetMemory(offset + HElems.GlowColor, RGBA(r1, g1, b1, a1));
            PS3.SetMemory(offset + HElems.clientOffset, buffer);
            PS3.SetMemory(offset + 0xa8, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(clientIndex))));
            byte[] bytes = BitConverter.GetBytes(1);
            Array.Reverse(bytes);
            PS3.SetMemory(offset, bytes);
            PS3.Extension.WriteInt32(offset + HElems.fxBirthTime, (int)GetLevelTime());
            PS3.Extension.WriteInt32(offset + HElems.fxLetterTime, fxLetterTime);
            PS3.Extension.WriteInt32(offset + HElems.fxDecayStartTime, fxDecayStartTime);
            PS3.Extension.WriteInt32(offset + HElems.fxDecayDuration, fxDecayDuration);
            PS3.SetMemory(offset + HElems.textOffset, this.SetText(text));
        }
        public uint LevelTime1 = 0xfc3db0;
        public uint GetLevelTime()
        {
            return PS3.Extension.ReadUInt32(this.LevelTime1);
        }

        public void doTypeWriterCustom(uint Index, ushort fxLetterTime, ushort fxDecayStartTime, ushort fxDecayDuration)
        {
            uint num = this.G_HudElems + (Index * 180);
            PS3.Extension.WriteInt32(num + HElems.fxBirthTime, (int)this.GetLevelTime());
            PS3.Extension.WriteInt32(num + HElems.fxLetterTime, fxLetterTime);
            PS3.Extension.WriteInt32(num + HElems.fxDecayStartTime, fxDecayStartTime);
            PS3.Extension.WriteInt32(num + HElems.fxDecayDuration, fxDecayDuration);
        }
        public void DestroyAll()
        {
            PS3.SetMemory(this.G_HudElems, new byte[0x2d000]);
        }

        public void DestroyElem(int index)
        {
            uint offset = this.G_HudElems + ((uint)(index * 180));
            PS3.SetMemory(offset, new byte[180]);
        }
        
        public uint MoveOverTime(uint Elem, short Time, float float_9, float float_10)
        {
            uint num = this.G_HudElems + (Elem * 180);
            PS3.Extension.WriteFloat(num + HElems.fromX, PS3.Extension.ReadFloat(num + HElems.xOffset));
            PS3.Extension.WriteFloat(num + HElems.fromY, PS3.Extension.ReadFloat(num + HElems.yOffset));
            PS3.Extension.WriteInt32(num + HElems.moveTime, Time);
            PS3.Extension.WriteInt32(num + HElems.moveStartTime, (int)this.GetLevelTime());
            PS3.Extension.WriteFloat(num + HElems.xOffset, float_9);
            PS3.Extension.WriteFloat(num + HElems.yOffset, float_10);
            return Elem;
        }

        public void MoveShaderXY(uint index, float float_9, float float_10)
        {
            PS3.Extension.WriteFloat((this.G_HudElems + (index * 180)) + HElems.xOffset, float_9);
            PS3.Extension.WriteFloat((this.G_HudElems + (index * 180)) + HElems.yOffset, float_10);
        }

        public void MoveShaderY(uint index, float float_9)
        {
            PS3.Extension.WriteFloat((this.G_HudElems + (index * 180)) + HElems.yOffset, float_9);
        }
        public void StoreTextElem(uint elemIndex, decimal client, string Text, int font, double fontScale, float x, float y, uint align, float sort, decimal r, decimal g, decimal b, decimal a, decimal r1, decimal g1, decimal b1, decimal a1)
        {
            string text = Text + "\0";
            byte[] buffer = this.SetText(text);
            uint offset = this.G_HudElems + (elemIndex * 180);
            PS3.SetMemory(offset + 0xa8, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(client))));
            byte[] buffer2 = ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(client)));
            PS3.SetMemory(offset, new byte[180]);
            PS3.SetMemory(offset, new byte[4]);
            PS3.SetMemory(offset + HElems.relativeOffset, new byte[] { 0, 0, 0, 0, 0x92, 0xff, 0xff, 0xff, 0xff });
            byte[] buffer4 = new byte[4];
            buffer4[3] = 5;
            PS3.SetMemory((offset + HElems.relativeOffset) - 4, buffer4);
            PS3.SetMemory(offset + HElems.textOffset, buffer);
            PS3.SetMemory(offset + HElems.fontOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(font))));
            PS3.SetMemory(offset + HElems.alignOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(align))));
            PS3.SetMemory((offset + HElems.textOffset) + 4, ReverseBytes(BitConverter.GetBytes(sort)));
            PS3.Extension.WriteFloat(offset + HElems.fontSizeOffset, (float)fontScale);
            PS3.SetMemory(offset + HElems.xOffset, ToHexFloat(x));
            PS3.SetMemory(offset + HElems.yOffset, ToHexFloat(y));
            PS3.SetMemory(offset + HElems.colorOffset, RGBA(r, g, b, a));
            PS3.SetMemory(offset + HElems.clientOffset, buffer2);
            PS3.SetMemory(offset + 0xa8, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(client))));
            byte[] bytes = BitConverter.GetBytes(1);
            Array.Reverse(bytes);
            PS3.SetMemory(offset, bytes);
            PS3.SetMemory(offset + HElems.GlowColor, RGBA(r1, g1, b1, a1));
        }

        public uint str_pointer(string str)
        {
            uint num2;
            uint offset = 0x523b30;
            byte[] buffer = new byte[1];
            for (num2 = 0; num2 < 5; num2++)
            {
                PS3.GetMemory(offset, buffer);
                if (buffer[0] == 0)
                {
                    break;
                }
                if (num2 == 4)
                {
                    num2 = 0;
                    break;
                }
            }
            offset = 0x523b30 + (num2 * 0x68);
            PS3.SetMemory(offset, new byte[0x68]);
            PS3.SetMemory(offset, Encoding.UTF8.GetBytes(str));
            return offset;
        }
        public string[] centerString(string[] StringArray)
        {
            int num3;
            int length = 0;
            int num2 = 0;
            string str = "";
            for (num3 = 0; num3 < StringArray.Length; num3++)
            {
                if (StringArray[num3].Length > length)
                {
                    length = StringArray[num3].Length;
                }
            }
            for (num3 = 0; num3 < StringArray.Length; num3++)
            {
                str = "";
                if (StringArray[num3].Length < length)
                {
                    num2 = length - StringArray[num3].Length;
                    for (int i = 0; i < num2; i++)
                    {
                        str = str + " ";
                    }
                }
                StringArray[num3] = str + StringArray[num3];
            }
            return StringArray;
        }

        public void ChangeAlpha(int index, int r, int g, int b, int a)
        {
            uint num = this.G_HudElems + ((uint)(index * 180));
            PS3.SetMemory(num + HElems.colorOffset, RGBA(r, g, b, a));
        }

        public void ChangeAlphaGlow(int index, int r, int g, int b, int alpha, int r1, int g1, int b1, int alpha1)
        {
            uint num = this.G_HudElems + ((uint)(index * 180));
            PS3.SetMemory(num + HElems.GlowColor, RGBA(r1, g1, b1, alpha1));
            PS3.SetMemory(num + HElems.colorOffset, RGBA(r, g, b, alpha));
        }

        public void ChangeFont(int elemIndex, short font)
        {
            uint num = this.G_HudElems + (Convert.ToUInt32(elemIndex) * 180);
            PS3.Extension.WriteInt16(num + HElems.fontOffset, font);
        }

        public void ChangeFontScale(uint elemIndex, double fontScale)
        {
            uint num = this.G_HudElems + (elemIndex * 180);
            PS3.Extension.WriteFloat(num + HElems.fontSizeOffset, (float)fontScale);
        }

        public void ChangeFontScaleOverTime(uint elemIndex, short Time, float OldFont, float NewFont)
        {
            uint num = this.G_HudElems + (elemIndex * 180);
            PS3.Extension.WriteFloat(num + HElems.fromFontScale, OldFont);
            PS3.Extension.WriteUInt32(num + HElems.fontScaleStartTime, this.GetLevelTime());
            PS3.Extension.WriteInt32(num + HElems.fontScaleTime, Time);
            PS3.Extension.WriteFloat(num + HElems.fontScale, NewFont);
        }

        public void ChangeShaderColor(uint elemIndex, int r, int g, int b, int a)
        {
            uint num = this.G_HudElems + (elemIndex * 180);
            PS3.SetMemory(num + HElems.colorOffset, RGBA(r, g, b, a));
        }

        public void ChangeText(int index, string txt)
        {
            string text = txt + "\0";
            byte[] buffer = SetText(text);
            uint num = this.G_HudElems + (Convert.ToUInt32(index) * 180);
            PS3.SetMemory(num + HElems.textOffset, buffer);
        }

        public void ChangeText(uint index, string txt, int xAxis)
        {
            string text = txt + "\0";
            byte[] buffer = SetText(text);
            uint num = this.G_HudElems + (index * 180);
            byte[] array = new byte[4];
            array = BitConverter.GetBytes(Convert.ToSingle(xAxis));
            Array.Reverse(array);
            PS3.SetMemory(num + HElems.xOffset, array);
            PS3.SetMemory(num + HElems.textOffset, buffer);
        }

        public void ChangeTextColor(uint elemIndex, int r, int g, int b, int a)
        {
            uint num = this.G_HudElems + (elemIndex * 180);
            PS3.SetMemory(num + HElems.colorOffset, RGBA(r, g, b, a));
        }

        public void ChangeTextSize(uint index, double fontScale_)
        {
            byte[] array = new byte[4];
            array = BitConverter.GetBytes(Convert.ToSingle(fontScale_));
            Array.Reverse(array);
            PS3.SetMemory((this.G_HudElems + (index * 180)) + 20, array);
        }

        public void ChangeTextSub(int index, string txt)
        {
            string text = txt;
            byte[] buffer = SetText(text);
            uint num = this.G_HudElems + ((uint)(index * 180));
            PS3.SetMemory(num + HElems.textOffset, buffer);
        }

        public void ChangeWidth(int elemIndex, short width)
        {
            uint num = this.G_HudElems + (Convert.ToUInt32(elemIndex) * 180);
            PS3.Extension.WriteInt16(num + HElems.widthOffset, width);
        }
        #endregion

        private void customColorBlender2_SelectedColorChanged(object sender, EventArgs e)
        {
           
        }

        private void customColorBlender1_SelectedColorChanged(object sender, EventArgs e)
        {
           
        }
        public uint ALLClientHUD = 0x7ff;
        private void metroButton192_Click(object sender, EventArgs e)
        {

        }

        private void nudDecayStartTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button127_Click_1(object sender, EventArgs e)
        {
            this.doTypeWriter(100, ALLClientHUD, this.metroTextBox45.Text, 3f, 5, 325f, 100f, 100, 0x1770, 0x3e8, (int)this.numericUpDown51.Value, (int)this.numericUpDown50.Value, (int)this.numericUpDown49.Value, (int)this.numericUpDown48.Value, (int)this.numericUpDown47.Value, (int)this.numericUpDown46.Value, (int)this.numericUpDown45.Value, (int)this.numericUpDown44.Value);
        }

        private void button129_Click(object sender, EventArgs e)
        {
            this.StoreTextElem(140, this.ALLClientHUD,  this.metroTextBox42.Text , 4, 2.5, 325f, 410f, 0, 0f, 255M, 213M, 92M, 255M, 2M, 80M, 180M, 255M);
        }
         public void StoreIcon(uint elemIndex, decimal client, decimal shader, decimal width, decimal height, float x, float y, uint align, float sort, decimal r, decimal g, decimal b, decimal a)
        {
            uint offset = this.G_HudElems + (elemIndex * 180);
            byte[] buffer = ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(client)));
            PS3.SetMemory(offset, new byte[180]);
            PS3.SetMemory(offset, new byte[4]);
            byte[] buffer3 = new byte[4];
            buffer3[3] = 1;
            PS3.SetMemory(offset + HElems.relativeOffset, buffer3);
            PS3.SetMemory((offset + HElems.relativeOffset) - 4, new byte[4]);
            PS3.SetMemory(offset + HElems.shaderOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(shader))));
            PS3.SetMemory(offset + HElems.heightOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(height))));
            PS3.SetMemory(offset + HElems.widthOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(width))));
            PS3.SetMemory(offset + HElems.alignOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(align))));
            PS3.SetMemory((offset + HElems.textOffset) + 4, ReverseBytes(BitConverter.GetBytes(sort)));
            PS3.SetMemory(offset + HElems.xOffset, ToHexFloat(x));
            PS3.SetMemory(offset + HElems.yOffset, ToHexFloat(y));
            PS3.SetMemory(offset + HElems.colorOffset, RGBA(r, g, b, a));
            PS3.SetMemory(offset + HElems.clientOffset, buffer);
            PS3.SetMemory(offset + 0xa8, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(client))));
            byte[] bytes = BitConverter.GetBytes(4);
            Array.Reverse(bytes);
            PS3.SetMemory(offset, bytes);
        }
         private uint uint_0 = 0x7ff;
         private bool bool_0;
         private bool bool_1;
         private bool bool_10;
         private bool bool_11;
         private bool bool_12;
         private bool bool_13;
         private bool bool_14;
         private bool bool_15;
         private bool bool_16;
         private bool bool_17;
         private bool bool_18;
         private bool bool_19;
         private bool bool_2;
         private bool bool_20;
         private bool bool_21 = false;
         private bool bool_3;
         private bool bool_4;
         private bool bool_5;
         private bool bool_6;
         private bool bool_7;
         private bool bool_8;
         private bool bool_9;
        
        private void button130_Click(object sender, EventArgs e)
        {
           
            }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
           
           
        }

        private void button131_Click(object sender, EventArgs e)
        {
            for (uint i = 0; i < 12; i++)
            {
                PS3.SetMemory(0x18ceea0 + (i * 4), ReverseBytes(BitConverter.GetBytes((int)this.numericUpDown10.Value)));
            }
        }

        private void numericUpDown10_ValueChanged_1(object sender, EventArgs e)
        {

        }
        private string string_0 = "^1Mx444 ^2Private ^3Tool - ^1www.YouTube.com/444xMoDz - ";
        private uint uint_6 = 200;
        private uint uint_7 = 0xc9;
        private uint uint_8 = 0xcc;
        private static uint uint_4;
        private uint uint_5 = 0xca;

        private float float_0 = 15000f;
        private float float_1 = 1200f;
        private float float_2 = -780f;
        private float float_3 = -150f;
        private float float_4 = 1000f;
        private float float_5 = 325f;
        private float float_6 = 1000f;
        private float float_7 = 700f;
        private float float_8 = -120f;
        private void metroButton184_Click(object sender, EventArgs e)
        {
            
        }

        private void backgroundWorker_19_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                this.MoveOverTime(this.uint_5, (short)this.float_0, this.float_2, 445f);
                Thread.Sleep((int)this.float_0);
                this.MoveShaderXY(this.uint_5, (float)((int)this.float_1), 445f);
            }
        }

        private void button133_Click(object sender, EventArgs e)
        {
            this.StoreIcon(this.uint_7, this.uint_0, 1M, 21476M, 30M, -150f, 0f, 0, 0f, 0M, 0M, 0M, 165M);
            this.StoreIcon(this.uint_6, this.uint_0, 1M, 21476M, 2M, -150f, 0f, 0, 0f, 255M, 0M, 0M, 255M);
            this.StoreTextElem(this.uint_5, this.uint_0, this.string_0 + this.textBox28.Text, 4, 1.5, this.float_1, 515f, 0, 0f, 255M, 255M, 255M, 255M, 0M, 255M, 110M, 180M);
            this.MoveOverTime(this.uint_7, (short)this.float_4, this.float_3, 440f);
            Thread.Sleep(100);
            this.MoveOverTime(this.uint_6, (short)this.float_4, this.float_3, 438f);
            if (!this.backgroundWorker_19.IsBusy)
            {
                this.backgroundWorker_19.RunWorkerAsync();
            }
        }

        private void textBox28_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void button132_Click(object sender, EventArgs e)
        {
            this.MoveOverTime(this.uint_6, (short)this.float_4, this.float_3, 0f);
            Thread.Sleep(0x3e8);
            this.MoveOverTime(this.uint_7, (short)this.float_4, this.float_3, 0f);
            Thread.Sleep(0x4b0);
            this.DestroyElem((int)this.uint_7);
            this.DestroyElem((int)this.uint_6);
            this.ChangeAlpha((int)this.uint_5, 0, 0, 0, 0);
        }

        private void button134_Click(object sender, EventArgs e)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(textBox54.Text); Array.Resize(ref buffer, buffer.Length + 1); PS3.SetMemory(0x01BBBC36, buffer);

            byte[] meaw = new byte[] { 0x01, };
            PS3.SetMemory(0x00892C14, meaw);

            byte[] koww = new byte[] { 0xEF, };
            PS3.SetMemory(0x00892C33, koww);

            byte[] a = new byte[] { 0x5E, 0x32, 0x5E, 0x02, 0x80, 0x80, 0x01, 0x01, 0x5e, 0x35, };
            PS3.SetMemory(0X01bbbc2c, a);
            timer41.Enabled = true;

        }

        private void timer41_Tick(object sender, EventArgs e)
        {
            byte[] a = new byte[] { 0x02, };
            PS3.SetMemory(0X01bbbc2f, a);

            timer41.Enabled = false;
            timer42.Enabled = true;
        }

        private void textBox54_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer42_Tick(object sender, EventArgs e)
        {
            byte[] a = new byte[] { 0x01, };
            PS3.SetMemory(0X01bbbc2f, a);

            timer42.Enabled = false;
            timer43.Enabled = true;
        }

        private void timer43_Tick(object sender, EventArgs e)
        {
            byte[] a = new byte[] { 0x5E, 0x32, 0x49, 0x20 };
            PS3.SetMemory(0x00892C15, a);

            byte[] x = new byte[] { 0x31 };
            PS3.SetMemory(0X01bbbc2d, x);

            timer43.Enabled = false;
            timer44.Enabled = true;
        }

        private void timer44_Tick(object sender, EventArgs e)
        {
            byte[] a = new byte[] { 0x5E, 0x32, 0x49, 0x20, 0x41, 0x4D, 0x20 };
            PS3.SetMemory(0x00892C15, a);

            byte[] x = new byte[] { 0x32 };
            PS3.SetMemory(0X01bbbc35, x);

            timer44.Enabled = false;
            timer45.Enabled = true;
        }

        private void timer45_Tick(object sender, EventArgs e)
        {
            byte[] a = new byte[] { 0x5E, 0x32, 0x49, 0x20, 0x41, 0x4D, 0x20, 0x41, 0x20 };
            PS3.SetMemory(0x00892C15, a);

            byte[] b = new byte[] { 0x34 };
            PS3.SetMemory(0X01bbbc2d, b);

            timer45.Enabled = false;
            timer46.Enabled = true;
        }

        private void timer46_Tick(object sender, EventArgs e)
        {

            byte[] a = new byte[] { 0x5E, 0x32, 0x49, 0x20, 0x41, 0x4D, 0x20, 0x41, 0x20, 0x46, 0x55, 0x43, 0x4B, 0x49, 0x4E, 0x47, 0x20 };
            PS3.SetMemory(0x00892C15, a);

            byte[] x = new byte[] { 0x31 };
            PS3.SetMemory(0X01bbbc35, x);

            timer46.Enabled = false;
            timer47.Enabled = true;
        }

        private void timer47_Tick(object sender, EventArgs e)
        {
            byte[] a = new byte[] { 0x5E, 0x32, 0x49, 0x20, 0x41, 0x4D, 0x20, 0x41, 0x20, 0x46, 0x55, 0x43, 0x4B, 0x49, 0x4E, 0x47, 0x20, 0x42, 0x4F, 0x53, 0x53 };
            PS3.SetMemory(0x00892C15, a);

            byte[] b = new byte[] { 0x36 };
            PS3.SetMemory(0X01bbbc2d, b);

            timer47.Enabled = false;
            timer48.Enabled = true;
        }

        private void timer48_Tick(object sender, EventArgs e)
        {
            byte[] a = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            PS3.SetMemory(0x00892C15, a);

            byte[] x = new byte[] { 0x36 };
            PS3.SetMemory(0X01bbbc35, x);

            timer48.Enabled = false;
            timer41.Enabled = true;
        }

        private void button135_Click(object sender, EventArgs e)
        {
            timer41.Enabled = false;
            timer42.Enabled = false;
            timer43.Enabled = false;
            timer44.Enabled = false;
            timer45.Enabled = false;
            timer46.Enabled = false;
            timer47.Enabled = false;
            timer48.Enabled = false;
         
        }

        private void button136_Click(object sender, EventArgs e)
        {
     
        }
        public string Time;
        private void timer49_Tick(object sender, EventArgs e)
        {
            this.Time = DateTime.Now.ToLongTimeString();
            PS3.Extension.WriteString(0x1bbbc2c, this.Time);
        }

        private void button137_Click(object sender, EventArgs e)
        {
            timer49.Enabled = true;
        }

        private void button136_Click_1(object sender, EventArgs e)
        {
            timer49.Enabled = false;
        }

        private void button138_Click(object sender, EventArgs e)
        {
           
        }

        private void button148_Click(object sender, EventArgs e)
        {

        }

        private void textBox38_TextChanged(object sender, EventArgs e)
        {

        }

        private void Mw33D_2Names_Raido_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void _3DName_2Text(String str1, String str2)
        {
            Byte[] Final = Encoding.ASCII.GetBytes(str1 + " " + str2 + "\0");
            Final[str1.Length] = 0xD;
            PS3.SetMemory(0x01bbbc2c, Final);

        }
        public void _3DName_3Text(UInt32 Offset, String str1, String str2, String str3)
        {
            byte[] str = Encoding.ASCII.GetBytes(str1 + "\r" + str2 + "\r\r\r" + str3);
            Array.Resize(ref str, str.Length + 1);
            PS3.SetMemory(Offset, str);
        }
        
        private void button138_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (Mw3DetectButtons.Text == ButtonDetect)
                {
                    string str1 = Mw33DName_Text_1.Text.Replace("[X]", "\x0001").Replace("[O]", "\x0002").Replace("[]", "\x0003")
                    .Replace("[Y]", "\x0004").Replace("[L1]", "\x0005").Replace("[R1]", "\x0006").Replace("[L3]", "\x0010")
                    .Replace("[R3]", "\x0011").Replace("[L2]", "\x0012").Replace("[R2]", "\x0013").Replace("[UP]", "\x0014")
                    .Replace("[DOWN]", "\x0015").Replace("[LEFT]", "\x0016").Replace("[RIGHT]", "\x0017").Replace("[START]", "\x000e")
                    .Replace("[SELECT]", "\x000f").Replace("[LINE]", "\n").Replace("[3D]", "\r");
                    string str2 = Mw33DName_Text_2.Text.Replace("[X]", "\x0001").Replace("[O]", "\x0002").Replace("[]", "\x0003")
                    .Replace("[Y]", "\x0004").Replace("[L1]", "\x0005").Replace("[R1]", "\x0006").Replace("[L3]", "\x0010")
                    .Replace("[R3]", "\x0011").Replace("[L2]", "\x0012").Replace("[R2]", "\x0013").Replace("[UP]", "\x0014")
                    .Replace("[DOWN]", "\x0015").Replace("[LEFT]", "\x0016").Replace("[RIGHT]", "\x0017").Replace("[START]", "\x000e")
                    .Replace("[SELECT]", "\x000f").Replace("[LINE]", "\n").Replace("[3D]", "\r");
                    string str3 = Mw33DName_Text_3.Text.Replace("[X]", "\x0001").Replace("[O]", "\x0002").Replace("[]", "\x0003")
                    .Replace("[Y]", "\x0004").Replace("[L1]", "\x0005").Replace("[R1]", "\x0006").Replace("[L3]", "\x0010")
                    .Replace("[R3]", "\x0011").Replace("[L2]", "\x0012").Replace("[R2]", "\x0013").Replace("[UP]", "\x0014")
                    .Replace("[DOWN]", "\x0015").Replace("[LEFT]", "\x0016").Replace("[RIGHT]", "\x0017").Replace("[START]", "\x000e")
                    .Replace("[SELECT]", "\x000f").Replace("[LINE]", "\n").Replace("[3D]", "\r");
                    if (Mw33D_2Names_Raido.Checked)
                    {
                        _3DName_2Text(str1, str2);
                    }
                    else if (Mw33D_3Names_Raido.Checked)
                    {
                        _3DName_3Text(0x01bbbc2c ,str1, str2, str3);
                    }
                }
                else
                {
                    if (Mw33D_2Names_Raido.Checked)
                    {
                        _3DName_2Text(Mw33DName_Text_1.Text, Mw33DName_Text_2.Text);
                    }
                    else if (Mw33D_3Names_Raido.Checked)
                    {
                        _3DName_3Text(0x01bbbc2c, Mw33DName_Text_1.Text, Mw33DName_Text_2.Text, Mw33DName_Text_3.Text);
                    }
                }
            }
            catch { }
        }

        private void Mw33D_2Names_Raido_CheckedChanged_1(object sender, EventArgs e)
        {
            if (Mw33D_2Names_Raido.Checked)
            {
                Mw33DName_Text_3.Enabled = false;
                Mw33D_3Names_Raido.Checked = false;
            }
        }

        private void Mw33D_3Names_Raido_CheckedChanged(object sender, EventArgs e)
        {
            if (Mw33D_3Names_Raido.Checked)
            {
                Mw33DName_Text_3.Enabled = true;
                Mw33D_2Names_Raido.Checked = false;
            }
        }
        public static float[] ReadFloatLength(uint Offset, int Length)
        {
            byte[] buffer = new byte[Length * 4];
            PS3.GetMemory(Offset, buffer);
            Array.Reverse(buffer);
            float[] FArray = new float[Length];
            for (int i = 0; i < Length; i++)
            {
                FArray[i] = BitConverter.ToSingle(buffer, (Length - 1 - i) * 4);
            }
            return FArray;
        }
        private bool bols;
        private bool bols_;
        public static float[] GetAngles(uint Client)
        {
            return ReadFloatLength(0x110a3d8 + (Client * 0x3980), 3);
        }
        public static float[] GetOrigin(uint Client)
        {
            return ReadFloatLength(0x110a29c + (Client * 0x3980), 3);
        }
   
             private void getOrginToValue_Mw3()
        {
            try
            {
                if (bols_ == false)
                {
                    UInt32 Client = (UInt32)Mw3EntityClient.Value;
                    float[] Origin = GetOrigin(Client);
                    Mw3EntityX.Value = (int)Origin[0];
                    Mw3EntityY.Value = (int)Origin[1];
                    Mw3EntityZ.Value = (int)Origin[2] + 50;
                    float[] Angels = GetAngles(Client);
                    Mw3EntityRoll.Value = (int)Angels[0];
                    Mw3EntityYaw.Value = (int)Angels[1];
                    Mw3EntityPitch.Value = (int)Angels[2];
                }
            }
            catch
            { MessageBox.Show("Not in Game | Not Attached", "", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        
        public enum Bush : uint//I will seach for these and Release them :)
        {
            CarePackage = 2,//com_plasticcase_friendly
            Bomb = 3,//com_bomb_objective
            Barrel = 11,//com_barrel_benzin
        }
        public static void WriteFloatArray(UInt32 Offset, float[] Array)
        {
            try
            {
                Byte[] buffer = new Byte[Array.Length * 4];
                for (Int32 Lenght = 0; Lenght < Array.Length; Lenght++)
                {
                    ReverseBytes(BitConverter.GetBytes(Array[Lenght])).CopyTo(buffer, Lenght * 4);
                }
                PS3.SetMemory(Offset, buffer);
            }
            catch { }
        }
        public static void WriteInt(UInt32 address, Int32 val, Boolean Reverse = true)
        {
            if (Reverse == true) { PS3.SetMemory(address, ReverseBytes(BitConverter.GetBytes(val))); }
            else { PS3.SetMemory(address, BitConverter.GetBytes(val)); }
        }
        private static String Addr(String Address)
        {
            String TempAddr = Address.Replace("0x", "").Replace("&H", "").Replace("u", "");
            return TempAddr;
        }
       
        public static uint SolidModel(float[] Origin, float[] Angles, string Model = "com_plasticcase_friendly", Bush Index = Bush.CarePackage)
        {
            uint Entity = (uint)RPC_MW3.Call(0x01C058C);//G_Spawn
            WriteFloatArray(Entity + 0x138, Origin);//Position
            WriteFloatArray(Entity + 0x144, Angles);//Orientation
            RPC_MW3.Call(0x01BEF5C, Entity, Model);//G_SetModel
            RPC_MW3.Call(0x01B6F68, Entity); //SP_script_model
            RPC_MW3.Call(0x002377B8, Entity);//SV_UnlinkEntity
            WriteByte(Entity + 0x101, 4);
            WriteInt(Entity + 0x8C, (int)Index);
            RPC_MW3.Call(0x0022925C, Entity);//SV_SetBrushModel
            RPC_MW3.Call(0x00237848, Entity);//SV_LinkEntity
            return Entity;
        }
        public static Int32 G_Spawn()
        {
            return RPC_MW3.Call(0x01C058C); // updated
        }

        private void button139_Click(object sender, EventArgs e)
        {
            
        }
       
        private static void SetMem(UInt32 Address, Byte[] buffer, SelectAPI API)
        {
            try
            {
                if (API == SelectAPI.ControlConsole)
                    PS3.CCAPI.SetMemory(Address, buffer);
                else if (API == SelectAPI.TargetManager)
                    PS3.TMAPI.SetMemory(Address, buffer);
            }
            catch { }
        }
        public static SelectAPI CurrentAPI;
        public static void WriteByte(UInt32 offset, Byte input)
        {
            try
            {
                Byte[] buffer = new Byte[] { input };
                SetMem(offset, buffer, CurrentAPI);
            }
            catch { }
        }
        public static void WriteByte(UInt32 offset, Byte input1, Byte input2)
        {
            try
            {
                Byte[] buffer = new Byte[] { input1, input2 };
                SetMem(offset, buffer, CurrentAPI);
            }
            catch { }
        }
        public static void WriteByte(UInt32 offset, Byte input1, Byte input2, Byte input3)
        {
            try
            {
                Byte[] buffer = new Byte[] { input1, input2, input3 };
                SetMem(offset, buffer, CurrentAPI);
            }
            catch { }
        }
        public static void WriteByte(UInt32 offset, Byte input1, Byte input2, Byte input3, Byte input4)
        {
            try
            {
                Byte[] buffer = new Byte[] { input1, input2, input3, input4 };
                SetMem(offset, buffer, CurrentAPI);
            }
            catch { }
        }

        public static void WriteBytes(UInt32 offset, Byte[] input)
        {
            try
            {
                Byte[] buffer = input;
                SetMem(offset, buffer, CurrentAPI);
            }
            catch { }
        }
        public static void WriteBytes(uint address, byte[] ByteArray, int length)
        {
            int i = 0;
            uint Address = Convert.ToUInt32(address + 1 * i);
            while (i < length)
            {
                PS3.SetMemory(Address, ByteArray);
            }
        }
        public static void WriteByte(uint address, byte Byte, int length)
        {
            int i = 0;
            uint Address = Convert.ToUInt32(address + 1 * i);
            byte[] BYTE = new byte[] { Byte };
            while (i < length)
            {
                PS3.SetMemory(Address, BYTE);
            }
        }

        public static class MysteryBox
        {
            #region Variables
            private static uint Weapon = 0;
            private static uint[] MBIndexes = new uint[3];
            private static string WeaponName = null;
            private static Thread MBThread;
            #endregion

            #region Read + Write
            private static string ReadString(uint Offset)
            {
                uint num = 0;
                List<byte> List = new List<byte>();
                while (true)
                {
                    byte[] buffer = new byte[1];
                    PS3.GetMemory(Offset + num, buffer);
                    if (buffer[0] == 0)
                    {
                        return Encoding.UTF8.GetString(List.ToArray());
                    }
                    List.Add(buffer[0]);
                    num++;
                }
            }

            private static float ReadFloat(uint Offset)
            {
                byte[] buffer = new byte[4];
                PS3.GetMemory(Offset, buffer);
                Array.Reverse(buffer, 0, 4);
                return BitConverter.ToSingle(buffer, 0);
            }

            private static int ReadInt(uint Offset)
            {
                byte[] buffer = new byte[4];
                PS3.GetMemory(Offset, buffer);
                Array.Reverse(buffer);
                int Value = BitConverter.ToInt32(buffer, 0);
                return Value;
            }

            private static float[] ReadFloatLength(uint Offset, int Length)
            {
                byte[] buffer = new byte[Length * 4];
                PS3.GetMemory(Offset, buffer);
                Array.Reverse(buffer);
                float[] FArray = new float[Length];
                for (int i = 0; i < Length; i++)
                {
                    FArray[i] = BitConverter.ToSingle(buffer, (Length - 1 - i) * 4);
                }
                return FArray;
            }

            private static void WriteString(uint Offset, string Text)
            {
                byte[] buffer = Encoding.UTF8.GetBytes(Text);
                Array.Resize(ref buffer, buffer.Length + 1);
                PS3.SetMemory(Offset, buffer);
            }

            private static void WriteByte(uint Offset, byte Byte)
            {
                byte[] buffer = new byte[1];
                buffer[0] = Byte;
                PS3.SetMemory(Offset, buffer);
            }

            private static void WriteFloat(uint Offset, float Float)
            {
                byte[] buffer = new byte[4];
                BitConverter.GetBytes(Float).CopyTo(buffer, 0);
                Array.Reverse(buffer, 0, 4);
                PS3.SetMemory(Offset, buffer);
            }

            private static void WriteFloatArray(uint Offset, float[] Array)
            {
                byte[] buffer = new byte[Array.Length * 4];
                for (int Lenght = 0; Lenght < Array.Length; Lenght++)
                {
                    ReverseBytes(BitConverter.GetBytes(Array[Lenght])).CopyTo(buffer, Lenght * 4);
                }
                PS3.SetMemory(Offset, buffer);
            }

            private static void WriteInt(uint Offset, int Value)
            {
                byte[] buffer = BitConverter.GetBytes(Value);
                Array.Reverse(buffer);
                PS3.SetMemory(Offset, buffer);
            }

            private static void WriteUInt(uint Offset, uint Value)
            {
                byte[] buffer = new byte[4];
                BitConverter.GetBytes(Value).CopyTo(buffer, 0);
                Array.Reverse(buffer, 0, 4);
                PS3.SetMemory(Offset, buffer);
            }

            private static byte[] ReverseBytes(byte[] inArray)
            {
                Array.Reverse(inArray);
                return inArray;
            }
            #endregion

            #region RPC
            public static uint func_address = 0x0277208;

           public static void Enable()
            {
                byte[] Check = new byte[1];
                PS3.GetMemory(func_address + 4, Check);
                if (Check[0] == 0x3F)
                {

                }
                else
                {
                    byte[] PPC = new byte[] 
        {0x3F,0x80,0x10,0x05,0x81,0x9C,0,0x48,0x2C,0x0C,0,  0,0x41,0x82,0,0x78,
         0x80,0x7C,0,0,0x80,0x9C,0,0x04,0x80,0xBC,0,0x08,0x80,0xDC,0,0x0C,0x80,
         0xFC,0,0x10,0x81,0x1C,0,0x14,0x81,0x3C,0,0x18,0x81  ,0x5C,0,0x1C,0x81,
         0x7C,0,0x20,0xC0,0x3C,0,0x24,0xC0,0x5C,0,0x28,0xC0  ,0x7C,0,0x2C,0xC0,
         0x9C,0,0x30,0xC0,0xBC,0,0x34,0xC0,0xDC,0,0x38,0xC0  ,0xFC,0,0x3C,0xC1,
         0x1C,0,0x40,0xC1,0x3C,0,0x44,0x7D,0x89,0x03,0xA6,0x4E,0x80,0x04,0x21,
         0x38,0x80,0,0,0x90,0x9C,0,0x48,0x90,0x7C,0,0x4C,0xD0,0x3C,0,0x50,0x48,0,0,0x14};
                    PS3.SetMemory(func_address, new byte[] { 0x41 });
                    PS3.SetMemory(func_address + 4, PPC);
                    PS3.SetMemory(func_address, new byte[] { 0x40 });
                }
            }

            public static int Call(uint address, params object[] parameters)
            {
                int length = parameters.Length;
                int index = 0;
                uint count = 0;
                uint Strings = 0;
                uint Single = 0;
                uint Array = 0;
                while (index < length)
                {
                    if (parameters[index] is int)
                    {
                        WriteInt(0x10050000 + (count * 4), (int)parameters[index]);
                        count++;
                    }
                    else if (parameters[index] is uint)
                    {
                        WriteUInt(0x10050000 + (count * 4), (uint)parameters[index]);
                        count++;
                    }
                    else if (parameters[index] is byte)
                    {
                        WriteByte(0x10050000 + (count * 4), (byte)parameters[index]);
                        count++;
                    }
                    else
                    {
                        uint pointer;
                        if (parameters[index] is string)
                        {
                            pointer = 0x10052000 + (Strings * 0x400);
                            WriteString(pointer, Convert.ToString(parameters[index]));
                            WriteUInt(0x10050000 + (count * 4), (uint)pointer);
                            count++;
                            Strings++;
                        }
                        else if (parameters[index] is float)
                        {
                            WriteFloat(0x10050024 + (Single * 4), (float)parameters[index]);
                            Single++;
                        }
                        else if (parameters[index] is float[])
                        {
                            float[] Args = (float[])parameters[index];
                            pointer = 0x10051000 + Array * 4;
                            WriteFloatArray(pointer, Args);
                            WriteUInt(0x10050000 + count * 4, (uint)pointer);
                            count++;
                            Array += (uint)Args.Length;
                        }
                    }
                    index++;
                }
                WriteUInt(0x10050048, (uint)address);
                Thread.Sleep(20);
                return ReadInt(0x1005004c);
            }

            public static bool Dvar_GetBool(string DVAR)
            {//0x00291060 - Dvar_GetBool(const char *dvarName)
                bool State;
                uint Value = (uint)Call(0x00291060, DVAR);
                if (Value == 1)
                    State = true;
                else
                    State = false;
                return State;
            }
            #endregion

            #region HUDS
            private static uint Element(uint Index)
            {
                return 0xF0E10C + ((Index) * 0xB4);
            }

            private static uint StoreText(uint Index, decimal Client, string Text, int Font, float FontScale, int X, int Y, decimal R = 255, decimal G = 255, decimal B = 255, decimal A = 255, decimal R1 = 0, decimal G1 = 0, decimal B1 = 0, decimal A1 = 0)
            {
                uint elem = Element(Index);
                WriteInt(elem + 0x84, Call(0x1BE6CC, Text));
                WriteInt(elem + 0x24, Font);
                WriteFloat(elem + 0x14, FontScale);
                WriteFloat(elem + 0x4, X);
                WriteFloat(elem + 0x8, Y);
                PS3.SetMemory(elem + 0xa7, new byte[] { 7 });
                PS3.SetMemory(elem + 0x30, new byte[] { (byte)R, (byte)G, (byte)B, (byte)A });
                PS3.SetMemory(elem + 0x8C, new byte[] { (byte)R1, (byte)G1, (byte)B1, (byte)A1 });
                WriteInt(elem + 0xA8, (int)Client);
                System.Threading.Thread.Sleep(20);
                WriteInt(elem, 1);
                return elem;
            }
            #endregion

            #region Functions
            private enum Brush : uint
            {
                NULL = 0,
                CarePackage = 2,
                Bomb = 3,
            }

            private static uint SolidModel(float[] Origin, float[] Angles, string Model = "com_plasticcase_friendly", Brush Index = Brush.CarePackage)
            {
                uint Entity = (uint)Call(0x01C058C);//G_Spawn
                WriteFloatArray(Entity + 0x138, Origin);//Position
                WriteFloatArray(Entity + 0x144, Angles);//Orientation
                Call(0x01BEF5C, Entity, Model);//G_SetModel
                Call(0x01B6F68, Entity); //SP_script_model
                Call(0x002377B8, Entity);//SV_UnlinkEntity
                WriteByte(Entity + 0x101, 4);
                WriteByte(Entity + 0x8C + 3, (byte)Index);
                Call(0x0022925C, Entity);//SV_SetBrushModel
                Call(0x00237848, Entity);//SV_LinkEntity
                return Entity;
            }

            public static float[] GetOrigin(uint Client)
            {
                return ReadFloatLength(0x110a29c + (Client * 0x3980), 3);
            }

            private static string ChangeWeaponModel()
            {
                int Value = 0;
                byte[] buffer = new byte[100];
                PS3.GetMemory(0x8360d5, buffer);
                System.Text.ASCIIEncoding Encoding = new System.Text.ASCIIEncoding();
                string Map = Encoding.GetString(buffer).Split(Convert.ToChar(0x5c))[6];
                if (Map == "mp_seatown" | Map == "mp_paris" | Map == "mp_plaza2" | Map == "mp_exchange" | Map == "mp_bootleg" | Map == "mp_alpha" | Map == "mp_village" | Map == "mp_bravo" | Map == "mp_courtyard_ss" | Map == "mp_aground_ss")
                    Value = -1;
                else
                    Value = 0;

                Random Random = new Random();
                switch (Random.Next(1, 50))
                {
                    case 1:
                        Weapon = (uint)Value + 4;
                        WeaponName = "Riotshield";
                        return "weapon_riot_shield_mp";
                    case 2:
                        Weapon = (uint)Value + 6;
                        WeaponName = ".44 Magnum";
                        return "weapon_44_magnum_iw5";
                    case 3:
                        Weapon = (uint)Value + 7;
                        WeaponName = "USP .45";
                        return "weapon_usp45_iw5";
                    case 4:
                        Weapon = (uint)Value + 9;
                        WeaponName = "Desert Eagle";
                        return "weapon_desert_eagle_iw5";
                    case 5:
                        Weapon = (uint)Value + 10;
                        WeaponName = "MP412";
                        return "weapon_mp412";
                    case 6:
                        Weapon = (uint)Value + 12;
                        WeaponName = "P99";
                        return "weapon_walther_p99_iw5";
                    case 7:
                        Weapon = (uint)Value + 13;
                        WeaponName = "Five-Seven";
                        return "weapon_fn_fiveseven_iw5";
                    case 8:
                        Weapon = (uint)Value + 14;
                        WeaponName = "FMG9";
                        return "weapon_fmg_iw5";
                    case 9:
                        Weapon = (uint)Value + 15;
                        WeaponName = "Skorpion";
                        return "weapon_skorpion_iw5";
                    case 10:
                        Weapon = (uint)Value + 16;
                        WeaponName = "MP9";
                        return "weapon_mp9_iw5";
                    case 11:
                        Weapon = (uint)Value + 17;
                        WeaponName = "G18";
                        return "weapon_g18_iw5";
                    case 12:
                        Weapon = (uint)Value + 18;
                        WeaponName = "MP5";
                        return "weapon_mp5_iw5";
                    case 13:
                        Weapon = (uint)Value + 19;
                        WeaponName = "PM-9";
                        return "weapon_uzi_m9_iw5";
                    case 14:
                        Weapon = (uint)Value + 20;
                        WeaponName = "P90";
                        return "weapon_p90_iw5";
                    case 15:
                        Weapon = (uint)Value + 21;
                        WeaponName = "PP90M1";
                        return "weapon_pp90m1_iw5";
                    case 16:
                        Weapon = (uint)Value + 22;
                        WeaponName = "UMP45";
                        return "weapon_ump45_iw5";
                    case 17:
                        Weapon = (uint)Value + 23;
                        WeaponName = "MP7";
                        return "weapon_mp7_iw5";
                    case 18:
                        Weapon = (uint)Value + 24;
                        WeaponName = "AK-47";
                        return "weapon_ak47_iw5";
                    case 19:
                        Weapon = (uint)Value + 25;
                        WeaponName = "M16A4";
                        return "weapon_m16_iw5";
                    case 20:
                        Weapon = (uint)Value + 26;
                        WeaponName = "M4A1";
                        return "weapon_m4_iw5";
                    case 21:
                        Weapon = (uint)Value + 27;
                        WeaponName = "FAD";
                        return "weapon_fad_iw5";
                    case 22:
                        Weapon = (uint)Value + 28;
                        WeaponName = "ACR 6.8";
                        return "weapon_remington_acr_iw5";
                    case 23:
                        Weapon = (uint)Value + 29;
                        WeaponName = "Typ 95";
                        return "weapon_type95_iw5";
                    case 24:
                        Weapon = (uint)Value + 30;
                        WeaponName = "MK14";
                        return "weapon_m14_iw5";
                    case 25:
                        Weapon = (uint)Value + 31;
                        WeaponName = "SCAR-L";
                        return "weapon_scar_iw5";
                    case 26:
                        Weapon = (uint)Value + 32;
                        WeaponName = "G36C";
                        return "weapon_g36_iw5";
                    case 27:
                        Weapon = (uint)Value + 33;
                        WeaponName = "CM901";
                        return "weapon_cm901";
                    case 28:
                        Weapon = (uint)Value + 35;
                        WeaponName = "M320 GLM";
                        return "weapon_m320_gl";
                    case 29:
                        Weapon = (uint)Value + 36;
                        WeaponName = "RPG-7";
                        return "weapon_rpg7";
                    case 30:
                        Weapon = (uint)Value + 37;
                        WeaponName = "SMAW";
                        return "weapon_smaw";
                    case 31:
                        Weapon = (uint)Value + 39;
                        WeaponName = "Javelin";
                        return "weapon_javelin";
                    case 32:
                        Weapon = (uint)Value + 40;
                        WeaponName = "XM25";
                        return "weapon_xm25";
                    case 33:
                        Weapon = (uint)Value + 12329;
                        WeaponName = "Dragunow";
                        return "weapon_dragunov_iw5";
                    case 34:
                        Weapon = (uint)Value + 12330;
                        WeaponName = "MSR";
                        return "weapon_remington_msr_iw5";
                    case 35:
                        Weapon = (uint)Value + 12331;
                        WeaponName = "BARRET KAL. .50";
                        return "weapon_m82_iw5";
                    case 36:
                        Weapon = (uint)Value + 12332;
                        WeaponName = "RSASS";
                        return "weapon_rsass_iw5";
                    case 37:
                        Weapon = (uint)Value + 12333;
                        WeaponName = "AS50";
                        return "weapon_as50_iw5";
                    case 38:
                        Weapon = (uint)Value + 12334;
                        WeaponName = "L118A";
                        return "weapon_l96a1_iw5";
                    case 39:
                        Weapon = (uint)Value + 47;
                        WeaponName = "KSG 12";
                        return "weapon_ksg_iw5";
                    case 40:
                        Weapon = (uint)Value + 48;
                        WeaponName = "MODELL 1887";
                        return "weapon_model1887";
                    case 41:
                        Weapon = (uint)Value + 49;
                        WeaponName = "STRIKER";
                        return "weapon_striker_iw5";
                    case 42:
                        Weapon = (uint)Value + 50;
                        WeaponName = "AA-12";
                        return "weapon_aa12_iw5";
                    case 43:
                        Weapon = (uint)Value + 51;
                        WeaponName = "USAS12";
                        return "weapon_usas12_iw5";
                    case 44:
                        Weapon = (uint)Value + 52;
                        WeaponName = "SPAS-12";
                        return "weapon_spas12_iw5";
                    case 45:
                        Weapon = (uint)Value + 54;
                        WeaponName = "M60E4";
                        return "weapon_m60_iw5";
                    case 46:
                        Weapon = (uint)Value + 17461;
                        WeaponName = "AUG";
                        return "weapon_steyr_digital";
                    case 47:
                        Weapon = (uint)Value + 55;
                        WeaponName = "MK46";
                        return "weapon_mk46_iw5";
                    case 48:
                        Weapon = (uint)Value + 56;
                        WeaponName = "PKP PECHENEG";
                        return "weapon_pecheneg_iw5";
                    case 49:
                        Weapon = (uint)Value + 57;
                        WeaponName = "L86 LSW";
                        return "weapon_sa80_iw5";
                    case 50:
                        Weapon = (uint)Value + 58;
                        WeaponName = "MG36";
                        return "weapon_mg36";
                }
                return null;
            }

            private static void MBFunction(float[] Origin, float[] Angles)
            {
                float[] BoxOrigin = Origin;
                float WeaponZ1 = 0;
                bool Running = false;
                uint ClientUsing = 0, WeaponID = 0;
                PS3.ConnectTarget(0);
                Origin[2] += 16;
                MBIndexes[0] = SolidModel(Origin, Angles, "com_plasticcase_trap_friendly");
                MBIndexes[1] = SolidModel(new float[] { Origin[0], Origin[1], Origin[2] += 28 }, Angles, "");
                MBIndexes[2] = SolidModel(new float[] { Origin[0] += -8, Origin[1], Origin[2] += -18 }, Angles, "weapon_ak47_iw5", Brush.NULL);
                WeaponID = MBIndexes[2];
                while (MBThread.IsAlive)
                {
                    if (Dvar_GetBool("cl_ingame") == false)
                    {
                        MBThread.Abort();
                        for (uint i = 0; i < 3; i++)
                            PS3.SetMemory(MBIndexes[i], new byte[0x280]);
                        PS3.SetMemory(0xF0E10C + (500 * 0xB4), new byte[18 * 0xB4]);
                    }
                    else
                    {
                        if (Running == false)
                        {
                            for (uint Client = 0; Client < 18; Client++)
                            {
                                if (ReadInt(0xFCA41D + (Client * 0x280)) > 0)
                                {
                                    float[] PlayerOrigin = ReadFloatLength(0x110a29c + (Client * 0x3980), 3);
                                    float X = PlayerOrigin[0] - BoxOrigin[0];
                                    float Y = PlayerOrigin[1] - BoxOrigin[1];
                                    float Z = PlayerOrigin[2] - (BoxOrigin[2] - 23);
                                    float Distance = (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
                                    if (Distance < 50)
                                    {
                                        StoreText(500 + Client, Client, "Press  for a Random Weapon", 7, 0.8f, 195, 300);
                                        byte[] Key = new byte[1];
                                        PS3.GetMemory(0x110D5E3 + (0x3980 * Client), Key);
                                        if (Key[0] == 0x20)
                                        {
                                            PS3.SetMemory(0xF0E10C + (500 * 0xB4), new byte[18 * 0xB4]);
                                            float WeaponZ = Origin[2];
                                            for (int i = 0; i < 37; i++)
                                            {
                                                WriteFloat(WeaponID + 0x20, WeaponZ += 0.7f);
                                                if ((i / 2) * 2 == i)
                                                {
                                                    WriteUInt(WeaponID + 0x58, (uint)Call(0x1BE7A8, ChangeWeaponModel()));
                                                }
                                                if (i == 36)
                                                {
                                                    break;
                                                }
                                                WeaponZ1 = WeaponZ;
                                                Thread.Sleep(100);
                                            }
                                            Running = true;
                                            ClientUsing = Client;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        PS3.SetMemory(Element(500 + Client), new byte[0xB4]);
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < 37; i++)
                            {
                                float[] PlayerOrigin = ReadFloatLength(0x110a29c + (ClientUsing * 0x3980), 3);
                                float X = PlayerOrigin[0] - BoxOrigin[0];
                                float Y = PlayerOrigin[1] - BoxOrigin[1];
                                float Z = PlayerOrigin[2] - (BoxOrigin[2] - 23);
                                float Distance = (float)Math.Sqrt((X * X) + (Y * Y) + (Z * Z));
                                if (Distance < 50)
                                {
                                    StoreText(500 + ClientUsing, ClientUsing, "Press  for " + WeaponName, 7, 0.8f, 195, 300);
                                    byte[] Key = new byte[1];
                                    PS3.GetMemory(0x110D5E3 + (0x3980 * ClientUsing), Key);
                                    if (Key[0] == 0x20)
                                    {

                                        if (ReadInt(0x0110a5f0 + (ClientUsing * 0x3980)) == ReadInt(0x0110a4fc + (ClientUsing * 0x3980)))
                                        {
                                            WriteUInt(0x0110a4fc + (ClientUsing * 0x3980), Weapon);
                                            WriteUInt(0x0110a624 + (ClientUsing * 0x3980), Weapon);
                                            WriteUInt(0x0110a6a4 + (ClientUsing * 0x3980), Weapon);
                                        }
                                        else
                                        {
                                            WriteUInt(0x0110a4f4 + (ClientUsing * 0x3980), Weapon);
                                            WriteUInt(0x0110a68c + (ClientUsing * 0x3980), Weapon);
                                            WriteUInt(0x0110a614 + (ClientUsing * 0x3980), Weapon);
                                        }
                                        WriteUInt(0x0110a5f0 + (ClientUsing * 0x3980), Weapon);
                                        Call(0x18A29C, 0xFCA280 + (ClientUsing * 0x280), Weapon, "", 9999, 9999);
                                        WriteFloat(WeaponID + 0x20, Origin[2]);
                                        WriteUInt(WeaponID + 0x58, (uint)Call(0x1BE7A8, "weapon_ak47_iw5"));
                                        PS3.SetMemory(Element(500 + ClientUsing), new byte[0xB4]);
                                        Running = false;
                                        break;
                                    }
                                    else
                                    {
                                        WriteFloat(WeaponID + 0x20, WeaponZ1 += -0.7f);
                                        if (i == 36)
                                        {
                                            WriteUInt(WeaponID + 0x58, (uint)Call(0x1BE7A8, "weapon_ak47_iw5"));
                                            PS3.SetMemory(Element(500 + ClientUsing), new byte[0xB4]);
                                            Running = false;
                                            break;
                                        }
                                        Thread.Sleep(200);
                                    }
                                }
                                else
                                {
                                    PS3.SetMemory(Element(500 + ClientUsing), new byte[0xB4]);
                                    WriteFloat(WeaponID + 0x20, WeaponZ1 += -0.7f);
                                    if (i == 36)
                                    {
                                        WriteUInt(WeaponID + 0x58, (uint)Call(0x1BE7A8, "weapon_ak47_iw5"));
                                        PS3.SetMemory(Element(500 + ClientUsing), new byte[0xB4]);
                                        Running = false;
                                        break;
                                    }
                                    Thread.Sleep(200);
                                }
                            }
                            Thread.Sleep(2000);
                        }
                    }
                }
            }
            #endregion

            public static void Spawn(float[] Origin, float Yaw)
            {
                Enable();
                float[] Angles = new float[] { 0, Yaw, 0 };
                ThreadStart Start = null;
                Thread.Sleep(100);
                if (Start == null)
                {
                    Start = () => MBFunction(Origin, Angles);
                }
                MBThread = new Thread(Start);
                MBThread.IsBackground = true;
                MBThread.Start();
            }

            public static void DeleteMB()
            {
                MBThread.Abort();
                for (uint i = 0; i < 3; i++)
                    PS3.SetMemory(MBIndexes[i], new byte[0x280]);
                PS3.SetMemory(0xF0E10C + (500 * 0xB4), new byte[18 * 0xB4]);
            }
        }
        
        private void button139_Click_1(object sender, EventArgs e)
        {

          
            uint client = (uint)Mw3EntityClientAuto.Value;
            UInt32 Index = 0x110a2a4 + 0x3980 * client;
            Single[] Origin = GetOrigin((uint)Mw3EntityClientAuto.Value);
            MysteryBox.Spawn(Origin, 0);
            Thread.Sleep(50);
            PS3.Extension.WriteFloat(Index, PS3.Extension.ReadFloat(Index) + 100);
        }
       

       
      
        private void button140_Click(object sender, EventArgs e)
        {
            MysteryBox.DeleteMB();
        
       
        }
        public static class Spawner
        {
            #region Read + Write

            private static float[] ReadFloatLength(uint Offset, int Length)
            {
                byte[] buffer = new byte[Length * 4];
                PS3.GetMemory(Offset, buffer);
                ReverseBytes(buffer);
                float[] Array = new float[Length];
                for (int i = 0; i < Length; i++)
                {
                    Array[i] = BitConverter.ToSingle(buffer, (Length - 1 - i) * 4);
                }
                return Array;
            }

            private static void WriteByte(uint Offset, byte Byte)
            {
                byte[] buffer = new byte[1];
                buffer[0] = Byte;
                PS3.SetMemory(Offset, buffer);
            }

            private static void WriteFloatArray(uint Offset, float[] Array)
            {
                byte[] buffer = new byte[Array.Length * 4];
                for (int Lenght = 0; Lenght < Array.Length; Lenght++)
                {
                    ReverseBytes(BitConverter.GetBytes(Array[Lenght])).CopyTo(buffer, Lenght * 4);
                }
                PS3.SetMemory(Offset, buffer);
            }

            private static void WriteInt(uint Offset, int Value)
            {
                PS3.SetMemory(Offset, ReverseBytes(BitConverter.GetBytes(Value)));
            }

            private static byte[] ReverseBytes(byte[] inArray)
            {
                Array.Reverse(inArray);
                return inArray;
            }

            #endregion

            public enum Bush : uint//I will seach for these and Release them :)
            {
                CarePackage = 2,//com_plasticcase_friendly
                Bomb = 3,//com_bomb_objective
                Barrel = 11,//com_barrel_benzin
            }

            public static uint SolidModel(float[] Origin, float[] Angles, string Model = "com_plasticcase_friendly", Bush Index = Bush.CarePackage)
            {
                uint Entity = (uint)RPC_MW3.Call(0x01C058C);//G_Spawn
                WriteFloatArray(Entity + 0x138, Origin);//Position
                WriteFloatArray(Entity + 0x144, Angles);//Orientation
               RPC_MW3.Call(0x01BEF5C, Entity, Model);//G_SetModel
               RPC_MW3.Call(0x01B6F68, Entity); //SP_script_model
               RPC_MW3.Call(0x002377B8, Entity);//SV_UnlinkEntity
                WriteByte(Entity + 0x101, 4);
                WriteInt(Entity + 0x8C, (int)Index);
               RPC_MW3.Call(0x0022925C, Entity);//SV_SetBrushModel
               RPC_MW3.Call(0x00237848, Entity);//SV_LinkEntity
                return Entity;
            }

            public static float[] GetOrigin(uint Client)
            {
                return ReadFloatLength(0x110a29c + (Client * 0x3980), 3);
            }

            public static float[] GetAngles(uint Client)
            {
                return ReadFloatLength(0x110a3d8 + (Client * 0x3980), 3);
            }

            public static float[] AnglesToForward(float[] Origin, float[] Angles, uint diff)
            {
                float num = ((float)Math.Sin((Angles[0] * Math.PI) / 180)) * diff;
                float num1 = (float)Math.Sqrt(((diff * diff) - (num * num)));
                float num2 = ((float)Math.Sin((Angles[1] * Math.PI) / 180)) * num1;
                float num3 = ((float)Math.Cos((Angles[1] * Math.PI) / 180)) * num1;
                return new float[] { Origin[0] + num3, Origin[1] + num2, Origin[2] - num };
            }

            private static uint[] STHIndexes;
            public static void StairsToHeaven(uint Client, uint Stairs = 41, int Time = 200)//When you use STH you can Freeze dont make it to Fast 200 is Good time and dont to Much Staris 41 Stairs = 2 Rounds :)
            {
                uint[] Index = new uint[Stairs];
                float[] Origin = GetOrigin(Client);
                float[] Angles = new float[3];
                for (uint i = 0; i < Stairs; )
                {
                    Index[i] = SolidModel(AnglesToForward(Origin, Angles, 60), Angles);
                    Angles[1] += 18;
                    Origin[2] += 10;
                    i++;
                    Thread.Sleep(Time);
                }
                STHIndexes = Index;
            }

            public static void RemoveSTH()
            {
                for (uint i = 0; i < STHIndexes.Length; i++)
                    PS3.SetMemory(STHIndexes[i] + 0xF, new byte[] { 0x2 });
            }
        }
        private void metroButton49_Click(object sender, EventArgs e)
        {

        }

        private void button141_Click(object sender, EventArgs e)
        {
            Spawner.StairsToHeaven((uint)Mw3EntityClientAuto.Value, (UInt32)Mw3STHStairs.Value, (Int32)Mw3STHSpeed.Value);
       
        }

        private void button142_Click(object sender, EventArgs e)
        {
            Spawner.RemoveSTH();
        }

        private void Mw3EntityClient_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Mw3EntityTXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void button143_Click(object sender, EventArgs e)
        {

        }

        private void Mw3TurrentType_TextChanged(object sender, EventArgs e)
        {

        }

        private void Mw3EntityClientAuto_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timer50_Tick(object sender, EventArgs e)
        {
            Intructor2();
            timer50.Enabled = false;
            timer51.Enabled = true;
        }

        private void timer51_Tick(object sender, EventArgs e)
        {
            Intructor3();
            timer50.Enabled = true;
            timer51.Enabled = false;
        }

        private void timer52_Tick(object sender, EventArgs e)
        {

        }

        private void button146_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure?", "Disconnect From PS3", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            if (dialogResult == DialogResult.Yes)
            {

                PS3.DisconnectTarget();


            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void button144_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure?", "ResetPS3?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            if (dialogResult == DialogResult.Yes)
            {


                if (PS3.GetCurrentAPI() == SelectAPI.TargetManager)
                    PS3.CCAPI.ShutDown(CCAPI.RebootFlags.SoftReboot);
                else
                    PS3.CCAPI.ShutDown(CCAPI.RebootFlags.SoftReboot);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void button145_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are You Sure?", "ResetPS3?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            if (dialogResult == DialogResult.Yes)
            {


                if (PS3.GetCurrentAPI() == SelectAPI.TargetManager)
                    PS3.CCAPI.ShutDown(CCAPI.RebootFlags.ShutDown);
                else
                    PS3.CCAPI.ShutDown(CCAPI.RebootFlags.ShutDown);
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {

        }

        private void button147_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x892c14, new byte[] { 1 });
            if (this.textBox29.Text.Length >= 1)
            {
                this.textBox29.Text = this.textBox30.Text.Substring(0, 1).ToUpper() + this.textBox29.Text.Substring(1);
            }
            else
            {
                if (this.textBox30.Text.Length >= 1)
                {
                    this.textBox30.Text = this.textBox30.Text.Substring(0, 1).ToUpper() + this.textBox30.Text.Substring(1);
                }
            }
            byte[] bytes1 = Encoding.ASCII.GetBytes(" " + this.textBox29.Text + "\r" + this.textBox30.Text);
            Array.Resize<byte>(ref bytes1, bytes1.Length + 1);
            PS3.SetMemory(0x892c15, bytes1);
        }

        private void button148_Click_1(object sender, EventArgs e)
        {
            timer54.Interval = 100;
            timer54.Enabled = true;
            timer54.Tick += timer54_Tick;
            timer54.Start();






            for (int i = 0; i < 1; i++)
            {
          
                RPC_MW3.iPrintlnBold(0, "Press [{+gostand}] To Double Jump");

            }
        }

        private void timer54_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 1; i++)
            {
                byte[] But = new byte[3];
                PS3.GetMemory(0x110D5E1, But);
                string mystring = null;
                mystring = BitConverter.ToString(But);
                string result = mystring.Replace("-", "");
                string result1 = result.Replace(" ", "");


                string key = result1;
                string KeyPressed = "";
                if (key == "000000")
                {
                    KeyPressed = "NONE";


                }
                else if (key == "000400")
                {
                    KeyPressed = "X";

                    byte[] b = new byte[] { 0xf0, 0xf0, 0x60 };
                    PS3.SetMemory(0x0110A2a5, b);

                }
                else if (key == "000004")
                {
                    KeyPressed = "R3";

                }
                else
                {
                    KeyPressed = key;
                }


            }
        }

        private void button149_Click(object sender, EventArgs e)
        {
            RPC_MW3.iPrintlnBold(0, "Double Jump Disabled");
            timer54.Stop();
        }

        private void button150_Click(object sender, EventArgs e)
        {


        }

        private void groupBox60_Enter(object sender, EventArgs e)
        {

        }

        private void button150_Click_1(object sender, EventArgs e)
        {
           
        }

        private void _Blender_Mw3_Text_SelectedColorChanged(object sender, EventArgs e)
        {
            numericUpDown51.Value = _Blender_Mw3_Text.SelectedColor.R;
            numericUpDown50.Value = _Blender_Mw3_Text.SelectedColor.G;
            numericUpDown49.Value = _Blender_Mw3_Text.SelectedColor.B;
            panel1.BackColor = _Blender_Mw3_Text.SelectedColor;
           
        }

        private void _Blender_Mw3_Glow_SelectedColorChanged(object sender, EventArgs e)
        {


            numericUpDown47.Value = _Blender_Mw3_Glow.SelectedColor.R;
            numericUpDown46.Value = _Blender_Mw3_Glow.SelectedColor.G;
            numericUpDown45.Value = _Blender_Mw3_Glow.SelectedColor.B;
            panel2.BackColor = _Blender_Mw3_Glow.SelectedColor;

        }

        private void button81_Click_1(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.ShowDialog();
            numericUpDown51.Value = dialog.Color.R;
            numericUpDown50.Value = dialog.Color.G;
            numericUpDown49.Value = dialog.Color.B;
            panel1.BackColor = Color.FromArgb(0xff, (int)this.numericUpDown51.Value, (int)this.numericUpDown50.Value, (int)this.numericUpDown49.Value);
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.ShowDialog();
            numericUpDown47.Value = dialog.Color.R;
            numericUpDown46.Value = dialog.Color.G;
            numericUpDown45.Value = dialog.Color.B;
            panel2.BackColor = Color.FromArgb(0xff, (int)this.numericUpDown47.Value, (int)this.numericUpDown46.Value, (int)this.numericUpDown45.Value);
        }

        private void groupBox61_Enter(object sender, EventArgs e)
        {

        }
        public static void WriteSingle(UInt32 address, float input)
        {
            Byte[] array = new Byte[4];
            BitConverter.GetBytes(input).CopyTo(array, 0);
            Array.Reverse(array, 0, 4);
            PS3.SetMemory(address, array);
        }

        public static void WriteSingle(UInt32 address, float[] input)
        {
            Int32 length = input.Length;
            Byte[] array = new Byte[length * 4];
            for (Int32 i = 0; i < length; i++)
            {
                ReverseBytes(BitConverter.GetBytes(input[i])).CopyTo(array, (Int32)(i * 4));
            }
            PS3.SetMemory(address, array);
        }

       
        public static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            if (s == null) return null;
            else
                return new string(charArray);
        }
        public static Int32 SpawnOnValues(string Type, string ModelName,
                       Single X, Single Y, Single Z, Single Forward, Single Yaw, Single Pitch)
        {
            Int32 Ent = G_Spawn();
            WriteSingle((UInt32)Ent + 0x138, new float[] { X, Y, Z });
            WriteSingle((UInt32)Ent + 0x144, new float[] { Forward, Yaw, Pitch });
            RPC_MW3.Call(0x01BEF5C, Ent, ModelName);// G_SetModel
            RPC_MW3.Call(0x01CF0E8, Ent, Type);//G_SpawnTurret

            return Ent;
        }
        private void Mw3TurrentSpawnBtn_Click(object sender, EventArgs e)
        {
           
        }
        public float ReadSingle(UInt32 address)
        {
            return BitConverter.ToSingle(PS3.Extension.ReadBytes(address, 4).Reverse().ToArray(), 0);
        }
       
        public static Byte[] GetMemoryL(UInt32 address, Int32 length)
        {
            Byte[] buffer = new Byte[length];
            PS3.GetMemory(address, buffer);
            return buffer;
        }
        public static float[] ReadSingle(UInt32 address, Int32 length)
        {
            Byte[] mem = PS3.Extension.ReadBytes(address, length * 4);
            ReverseBytes(mem);
            float[] numArray = new float[length];
            for (Int32 index = 0; index < length; ++index)
                numArray[index] = BitConverter.ToSingle(mem, (length - 1 - index) * 4);
            return numArray;
        }
        private void metroButton66_Click(object sender, EventArgs e)
        {
           
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button151_Click(object sender, EventArgs e)
        {
            try
            {
                SpawnOnValues
                    (Mw3TurrentType.Text, Mw3TurrentModel.Text, (int)X.Value, (int)Y.Value, (int)Z.Value, (int)Pitch.Value, (int)Yaww.Value,(int)Rolll.Value);

            }

            catch
            {
                MessageBox.Show("Not in Game | Not Attached", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button152_Click(object sender, EventArgs e)
        {
            if (button152.Text == "Auto Position ON")
            {
                timer55.Start();
                button152.Text = "Auto Position OFF";

            }
            else if (button152.Text == "Auto Position OFF")
            {
                timer55.Stop();
                button152.Text = "Auto Position ON";
            }
                
  
        }

        private void timer55_Tick(object sender, EventArgs e)
        {
            int Client = 0;
            {   // Position In Real Time.
                float[] POS = new float[] { 
              PS3.Extension.ReadFloat(Offsets.G_Client + 0x1C + (0x3980 * (uint)Client)),
              PS3.Extension.ReadFloat(Offsets.G_Client + 0x20 + (0x3980 * (uint)Client)), 
              PS3.Extension.ReadFloat(Offsets.G_Client + 0x24 + (0x3980 * (uint)Client)) };
                float[] Angles = ReadSingle(Offsets.Funcs.G_Client((int)Client) + 0x158, 3);
                float[] pos = new float[] { POS[0], POS[1], POS[2] += 50 };
                float[] angles = new float[] { Angles[0], Angles[1], Angles[2] };
                float X = POS[0]; float Y = POS[1]; float Z = POS[2];
                float Pitch = Angles[0]; float Yaw = Angles[1]; float Roll = Angles[2];
                string a = "Your Pos : X: " + X.ToString("F1") + "  Y: " + Y.ToString("F1") + "  Z: " + Z.ToString("F1");
                string b = "Your Angles : Pitch: " + Pitch.ToString("F1") + "  Yaw: " + Yaw.ToString("F1");
                label70.Text = a;
                label99.Text = b;

              
            }
        }

        private void label22_Click(object sender, EventArgs e)
        {
        
        }

        private void label70_Click(object sender, EventArgs e)
        {
        
        }

        private void button153_Click(object sender, EventArgs e)
        {
            int Client = 0;
            {
                float[] POS = new float[] {
                PS3.Extension.ReadFloat(Offsets.G_Client + 0x1C + (0x3980 * (uint)Client)),
                PS3.Extension.ReadFloat(Offsets.G_Client + 0x20 + (0x3980 * (uint)Client)), 
                PS3.Extension.ReadFloat(Offsets.G_Client + 0x24 + (0x3980 * (uint)Client)) };
                float[] Angles = ReadSingle(Offsets.Funcs.G_Client((int)Client) + 0x158, 3);
                float[] pos = new float[] { POS[0], POS[1], POS[2] += 50 };
                float[] angles = new float[] { Angles[0], Angles[1], Angles[2] };
                float XX = POS[0]; float YY = POS[1]; float ZZ = POS[2];
                float Pitchh = Angles[0]; float Yaw = Angles[1]; float Roll = Angles[2];
                string x = XX.ToString("F1"); string y = YY.ToString("F1"); string z = ZZ.ToString("F1"); string pitch = Pitchh.ToString("F1"); string yaw = Yaw.ToString("F1"); string roll = Roll.ToString("F1");
                X.Value = (int)Convert.ToDecimal(x); Y.Value = Convert.ToDecimal(y); Z.Value = Convert.ToDecimal(z); Pitch.Value = Convert.ToDecimal(pitch); Yaww.Value = Convert.ToDecimal(yaw); Rolll.Value = Convert.ToDecimal(roll);
            }
            
        }

        private void Box_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button173_Click(object sender, EventArgs e)
        {
          

            
        }

        private void clientsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Box_SelectedIndexChanged_2(object sender, EventArgs e)
        {
            if ((Box.Text == "Green") && (MAP.Text == "Dome"))
            {
                FXValue.Value = 92;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Dome"))
            {
                FXValue.Value = 66;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Seatown"))
            {
                FXValue.Value = 90;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Seatown"))
            {
                FXValue.Value = 64;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Arkaden"))
            {
                FXValue.Value = 98;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Arkaden"))
            {
                FXValue.Value = 72;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Bakaara"))
            {
                FXValue.Value = 88;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Bakaara"))
            {
                FXValue.Value = 62;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Resistance"))
            {
                FXValue.Value = 84;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Resistance"))
            {
                FXValue.Value = 58;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Downturn"))
            {
                FXValue.Value = 95;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Downturn"))
            {
                FXValue.Value = 69;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Bootleg"))
            {
                FXValue.Value = 105;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Bootleg"))
            {
                FXValue.Value = 79;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Bootleg"))
            {
                FXValue.Value = 105;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Bootleg"))
            {
                FXValue.Value = 79;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Carbon"))
            {
                FXValue.Value = 132;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Carbon"))
            {
                FXValue.Value = 106;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Hardhat"))
            {
                FXValue.Value = 100;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Hardhat"))
            {
                FXValue.Value = 74;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Lockdown"))
            {
                FXValue.Value = 86;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Lockdown"))
            {
                FXValue.Value = 60;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Village"))
            {
                FXValue.Value = 85;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Village"))
            {
                FXValue.Value = 59;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Fallen"))
            {
                FXValue.Value = 102;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Fallen"))
            {
                FXValue.Value = 76;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Outpost"))
            {
                FXValue.Value = 118;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Outpost"))
            {
                FXValue.Value = 92;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Interchange"))
            {
                FXValue.Value = 83;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Interchange"))
            {
                FXValue.Value = 57;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Underground"))
            {
                FXValue.Value = 109;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Underground"))
            {
                FXValue.Value = 83;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Mission"))
            {
                FXValue.Value = 87;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Mission"))
            {
                FXValue.Value = 61;
            }
            else if ((Box.Text == "Green") && (MAP.Text == "Terminal"))
            {
                FXValue.Value = 92;
            }
            else if ((Box.Text == "Red") && (MAP.Text == "Terminal"))
            {
                FXValue.Value = 66;
            }
        }

        private void button143_Click_1(object sender, EventArgs e)
        {
            if (button143.Text == "DrawFX [ OFF ]")
            {
                Painter1.Start();
                button143.Text = "DrawFX [ ON ]";
                button143.ForeColor = Color.Green;
            }
            else if (button143.Text == "DrawFX [ ON ]")
            {
                Painter1.Stop();
                button143.Text = "DrawFX [ OFF ]";
                button143.ForeColor = Color.Crimson;
            }
        }
        public static string GetName(int Client)
        {
            byte[] buffer = new byte[16];
            PS3.GetMemory(0x0110D694 + 0x3980 * (uint)Client, buffer);
            string names = Encoding.ASCII.GetString(buffer);
            names = names.Replace("\0", "");
            return names;
        }
        private void button150_Click_2(object sender, EventArgs e)
        {
            try
            {
                
                HOST.Text = getHostNamemw3();
                MAP.Text = getMapNamemw3();
                MODE.Text = getGameModemw3();
                for (int i = 0; i < 18; i++)
                {
                    dataGridView2.Enabled = true;
                    dataGridView2.RowCount = 18;
                    dataGridView2.Rows[i].Cells[0].Value = i;
                    dataGridView2.Rows[i].Cells[1].Value = GetName(i);
                    Application.DoEvents();

                }
            }
            catch
            {
                for (int i = 0; i < 18; i++)
                {
                    HOST.Text = "Null";
                    MAP.Text = "Null";
                    MODE.Text = "Null";
                    dataGridView2.RowCount = 18;
                    dataGridView2.Rows[i].Cells[0].Value = i;
                    dataGridView2.Rows[i].Cells[1].Value = "";
                }

            }
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            FXC.Value = dataGridView2.CurrentRow.Index;

        }
        public static uint PlayFX(float[] Origin, int EffectIndex)
        {
            uint ent = (uint)RPC_MW3.Call(0x1C0B7C, Origin, 0x56); //G_Temp
            PS3.Extension.WriteInt32(ent + 0xA0, EffectIndex);
            PS3.Extension.WriteInt32(ent + 0xD8, 0);
            PS3.Extension.WriteFloat(ent + 0x40, 0f);
            PS3.Extension.WriteFloat(ent + 0x44, 0f);
            PS3.Extension.WriteFloat(ent + 0x3C, 270f);
            return ent;
        }
        public static void SetFX(UInt32 Client, Int32 FX_Value, uint Distance_in_Meters = 6)
        {
            float[] Origin = new float[] { PS3.Extension.ReadFloat(Offsets.G_Client + 0x1C + (0x3980 * (uint)Client)), PS3.Extension.ReadFloat(Offsets.G_Client + 0x20 + (0x3980 * (uint)Client)), PS3.Extension.ReadFloat(Offsets.G_Client + 0x24 + (0x3980 * (uint)Client)) };
            float[] Angles = ReadSingle(Offsets.Funcs.G_Client((int)Client) + 0x158, 3);
           
            float diff = Distance_in_Meters * 40;
            float num = ((float)Math.Sin((Angles[0] * Math.PI) / 180)) * diff;
            float num1 = (float)Math.Sqrt(((diff * diff) - (num * num)));
            float num2 = ((float)Math.Sin((Angles[1] * Math.PI) / 180)) * num1;
            float num3 = ((float)Math.Cos((Angles[1] * Math.PI) / 180)) * num1;
            float[] Forward = new float[] { Origin[0] + num3, Origin[1] + num2, Origin[2] += 60 - num };
            Origin[2] += 50;
            PlayFX(Forward, FX_Value);
        }
        private void Painter1_Tick(object sender, EventArgs e)
        {
            if (PS3.Extension.ReadFloat(0x110a5f8 + ((uint)FXC.Value * 0x3980)) > 0)
            {
                SetFX((uint)FXC.Value, (Int32)FXValue.Value);
            }
        }

        private void label103_Click(object sender, EventArgs e)
        {

        }
        public static Int32 G_Spawn1()
        {
            return RPC_MW3.Call(0x01C058C); // updated
        }
        private void button89_Click_2(object sender, EventArgs e)
        {
            try
            {
                Int32 Ent = G_Spawn1();
               SolidModel(new float[] { Convert.ToSingle(Mw3EntityX.Value), Convert.ToSingle(Mw3EntityY.Value), Convert.ToSingle(Mw3EntityZ.Value) },
                  new float[] { Convert.ToSingle(Mw3EntityRoll.Value), Convert.ToSingle(Mw3EntityYaw.Value), Convert.ToSingle(Mw3EntityPitch.Value) },
                    Mw3EntityTXT.Text, Bush.CarePackage);
            }
            catch { }
            try
            {
                ListViewItem lvl = new ListViewItem(Mw3EntityTXT.Text);
                lvl.SubItems.Add(Mw3EntityX.Value.ToString());
                lvl.SubItems.Add(Mw3EntityY.Value.ToString());
                lvl.SubItems.Add(Mw3EntityZ.Value.ToString());
                lvl.SubItems.Add(Mw3EntityYaw.Value.ToString());
                lvl.SubItems.Add(Mw3EntityPitch.Value.ToString());
                lvl.SubItems.Add(Mw3EntityRoll.Value.ToString());
             
            }
            catch { }
        }

        
        private void button90_Click_2(object sender, EventArgs e)
        {
            getOrginToValue_Mw3();
        }

        private void tabPage15_Click(object sender, EventArgs e)
        {

        }

        private void metroButton205_Click(object sender, EventArgs e)
        {
          
        }

        private void metroButton205_Click_1(object sender, EventArgs e)
        {
          
        }
        public void Earthquake(int Duration, float[] origin, float radius, float scale)
        {
            int num = RPC_MW3.Call(0x1c0b7c, new object[] { origin, 0x5f });
            PS3.Extension.WriteFloat((uint)(num + 0x5c), radius);
            PS3.Extension.WriteFloat((uint)(num + 0x54), scale);
            PS3.Extension.WriteFloat((uint)(num + 0x58), (float)Duration);
            PS3.Extension.WriteInt32((uint)(num + 0xd8), 0);
        }
        public float[] getOrigin(uint clientNum)
        {
            return new float[] { this.ReadSingle((0x110a280 + (0x3980 * clientNum)) + 0x1c),
                this.ReadSingle(((0x110a280 + (0x3980 * clientNum)) + 0x1c) + 4),
                this.ReadSingle(((0x110a280 + (0x3980 * clientNum)) + 0x1c) + 8) };
        }
        private void button98_Click_2(object sender, EventArgs e)
        {
            this.Earthquake(0x1770, getOrigin(0), 1f, 1f);
            this.Earthquake(0x1770, this.getOrigin(1), 1f, 1f);
            this.Earthquake(0x1770, this.getOrigin(2), 1f, 1f);
            this.Earthquake(0x1770, this.getOrigin(3), 1f, 1f);
            this.Earthquake(0x1770, this.getOrigin(4), 1f, 1f);
            this.Earthquake(0x1770, this.getOrigin(5), 1f, 1f);
            this.Earthquake(0x1770, this.getOrigin(6), 1f, 1f);
            this.Earthquake(0x1770, this.getOrigin(7), 1f, 1f);
            this.Earthquake(0x1770, this.getOrigin(8), 1f, 1f);
            this.Earthquake(0x1770, this.getOrigin(9), 1f, 1f);
            this.Earthquake(0x1770, this.getOrigin(10), 1f, 1f);
            this.Earthquake(0x1770, this.getOrigin(11), 1f, 1f);
            this.Earthquake(0x1770, this.getOrigin(12), 1f, 1f);
            this.Earthquake(0x1770, this.getOrigin(13), 1f, 1f);
            this.Earthquake(0x1770, this.getOrigin(14), 1f, 1f);
            this.Earthquake(0x1770, this.getOrigin(15), 1f, 1f);
            this.Earthquake(0x1770, this.getOrigin(0x10), 1f, 1f);
            this.Earthquake(0x1770, this.getOrigin(0x11), 1f, 1f);
            RPC_MW3.iPrintlnBold(-1, "^2 Earthquake Mod , ^1Kill your Self to Reset ");
        }
        public uint PlayFX1(float[] Origin, int EffectIndex)
        {
            uint num = (uint)RPC_MW3.Call(0x1c0b7c, new object[] { Origin, 0x56 });
            PS3.Extension.WriteInt32(num + 160, EffectIndex);
            PS3.Extension.WriteInt32(num + 0xd8, 0);
            PS3.Extension.WriteFloat(num + 0x40, 0f);
            PS3.Extension.WriteFloat(num + 0x44, 0f);
            PS3.Extension.WriteFloat(num + 60, 270f);
            return num;
        }
        private void button154_Click(object sender, EventArgs e)
        {
            this.PlayFX1(this.getOrigin(1), 0x6f);
            this.PlayFX1(this.getOrigin(2), 0x6f);
            this.PlayFX1(this.getOrigin(3), 0x6f);
            this.PlayFX1(this.getOrigin(4), 0x6f);
            this.PlayFX1(this.getOrigin(5), 0x6f);
            this.PlayFX1(this.getOrigin(6), 0x6f);
            RPC_MW3.iPrintlnBold(-1, "^2 Fog Mod");
        }
        public float[] MW2Effect1()
        {
            float[] numArray = new float[5];
            numArray[0] = 444f;
            numArray[1] = 2570f;
            numArray[2] = -260f;
            return numArray;
        }

        public float[] MW2Effect2()
        {
            float[] numArray = new float[5];
            numArray[0] = 465f;
            numArray[1] = 2841f;
            numArray[2] = -260f;
            return numArray;
        }

        public float[] MW2Effect3()
        {
            float[] numArray = new float[5];
            numArray[0] = 1226f;
            numArray[1] = 2778f;
            numArray[2] = -260f;
            return numArray;
        }

        public float[] MW2Effect4()
        {
            float[] numArray = new float[5];
            numArray[0] = 1201f;
            numArray[1] = 2515f;
            numArray[2] = -260f;
            return numArray;
        }
        public float[] Disco()
        {
            float[] numArray = new float[5];
            numArray[0] = 843f;
            numArray[1] = 2645f;
            numArray[2] = -50f;
            return numArray;
        }
        private void button155_Click(object sender, EventArgs e)
        {
           
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            PS3.ConnectTarget(0);
            this.StoreIcon(500, this.uint_0, 1M, 250M, 200M, 180f, 115f, 0, 0f, 220M, 100M, 100M, 0M);
            this.StoreIcon(0x1f5, this.uint_0, 1M, 65M, 40M, 180f, 315f, 0, 0f, 220M, 100M, 100M, 0M);
            this.StoreIcon(0x1f6, this.uint_0, 1M, 65M, 40M, 365f, 315f, 0, 0f, 220M, 100M, 100M, 0M);
            this.StoreIcon(0x1f7, this.uint_0, 1M, 65M, 40M, 273f, 315f, 0, 0f, 220M, 100M, 100M, 0M);
            this.StoreIcon(0x1f8, this.uint_0, 1M, 90M, 55M, 180f, 180f, 0, 0f, 255M, 255M, 255M, 0M);
            this.StoreIcon(0x1f9, this.uint_0, 1M, 90M, 55M, 340f, 180f, 0, 0f, 255M, 255M, 255M, 0M);
            this.StoreIcon(0x1fa, this.uint_0, 1M, 30M, 30M, 208f, 180f, 0, 0f, 0M, 0M, 0M, 0M);
            this.StoreIcon(0x1fb, this.uint_0, 1M, 30M, 30M, 370f, 180f, 0, 0f, 0M, 0M, 0M, 0M);
            this.StoreIcon(0x1fc, this.uint_0, 1M, 30M, 30M, 336f, 287f, 0, 0f, 190M, 127M, 125M, 0M);
            this.StoreIcon(0x1fd, this.uint_0, 1M, 30M, 30M, 243f, 287f, 0, 0f, 190M, 127M, 125M, 0M);
            while (!this.bool_1)
            {
                continue;
            Label_038D:
                this.ChangeAlpha(500, 220, 100, 100, 10);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 10);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 10);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 10);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 10);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 10);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 10);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 10);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 10);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 10);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 20);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 20);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 20);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 20);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 20);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 20);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 20);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 20);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 20);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 20);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 30);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 30);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 30);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 30);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 30);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 30);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 30);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 30);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 30);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 30);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 40);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 40);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 40);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 40);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 40);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 40);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 40);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 40);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 40);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 40);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 50);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 50);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 50);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 50);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 50);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 50);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 50);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 50);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 50);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 50);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 60);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 60);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 60);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 60);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 60);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 60);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 60);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 60);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 60);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 60);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 70);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 70);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 70);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 70);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 70);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 70);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 70);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 70);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 70);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 70);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 80);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 80);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 80);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 80);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 80);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 80);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 80);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 80);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 80);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 80);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 90);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 90);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 90);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 90);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 90);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 90);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 90);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 90);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 90);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 90);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 100);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 100);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 100);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 100);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 100);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 100);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 100);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 100);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 100);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 100);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 110);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 110);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 110);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 110);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 110);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 110);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 110);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 110);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 110);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 110);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 120);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 120);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 120);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 120);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 120);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 120);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 120);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 120);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 120);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 120);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 130);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 130);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 130);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 130);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 130);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 130);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 130);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 130);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 130);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 130);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 140);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 140);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 140);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 140);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 140);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 140);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 140);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 140);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 140);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 140);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 150);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 150);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 150);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 150);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 150);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 150);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 150);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 150);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 150);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 150);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 160);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 160);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 160);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 160);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 160);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 160);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 160);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 160);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 160);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 160);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 170);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 170);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 170);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 170);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 170);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 170);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 170);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 170);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 170);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 170);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 180);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 180);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 180);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 180);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 180);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 180);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 180);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 180);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 180);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 180);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 190);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 190);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 190);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 190);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 190);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 190);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 190);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 190);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 190);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 190);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 200);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 200);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 200);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 200);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 200);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 200);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 200);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 200);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 200);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 200);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 210);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 210);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 210);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 210);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 210);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 210);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 210);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 210);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 210);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 210);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 220);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 220);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 220);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 220);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 220);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 220);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 220);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 220);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 220);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 220);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 230);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 230);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 230);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 230);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 230);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 230);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 230);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 230);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 230);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 230);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 240);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 240);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 240);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 240);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 240);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 240);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 240);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 240);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 240);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 240);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 0xff);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 0xff);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 0xff);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 0xff);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 0xff);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 0xff);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 0xff);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 0xff);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 0xff);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 0xff);
                Thread.Sleep(0xfa0);
                this.doTypeWriter(120, this.ALLClientHUD, "Why Not ZoidBerg?!", 3f, 5, 325f, 100f, 100, 0x1770, 0x3e8, 220, 100, 100, 0xff, 190, 0x7f, 0x7d, 0xff);
                Thread.Sleep(0x1388);
                this.ChangeAlpha(500, 220, 100, 100, 240);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 240);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 240);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 240);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 240);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 240);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 240);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 240);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 240);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 240);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 230);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 230);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 230);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 230);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 230);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 230);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 230);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 230);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 230);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 230);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 220);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 220);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 220);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 220);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 220);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 220);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 220);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 220);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 220);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 220);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 210);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 210);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 210);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 210);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 210);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 210);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 210);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 210);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 210);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 210);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 200);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 200);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 200);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 200);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 200);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 200);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 200);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 200);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 200);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 200);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 190);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 190);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 190);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 190);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 190);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 190);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 190);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 190);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 190);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 190);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 180);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 180);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 180);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 180);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 180);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 180);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 180);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 180);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 180);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 180);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 170);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 170);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 170);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 170);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 170);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 170);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 170);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 170);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 170);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 170);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 160);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 160);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 160);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 160);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 160);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 160);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 160);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 160);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 160);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 160);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 150);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 150);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 150);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 150);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 150);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 150);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 150);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 150);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 150);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 150);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 140);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 140);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 140);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 140);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 140);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 140);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 140);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 140);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 140);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 140);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 130);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 130);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 130);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 130);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 130);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 130);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 130);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 130);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 130);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 130);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 120);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 120);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 120);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 120);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 120);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 120);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 120);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 120);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 120);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 120);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 110);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 110);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 110);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 110);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 110);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 110);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 110);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 110);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 110);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 110);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 100);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 100);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 100);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 100);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 100);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 100);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 100);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 100);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 100);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 100);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 90);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 90);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 90);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 90);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 90);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 90);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 90);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 90);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 90);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 90);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 80);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 80);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 80);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 80);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 80);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 80);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 80);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 80);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 80);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 80);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 70);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 70);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 70);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 70);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 70);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 70);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 70);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 70);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 70);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 70);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 60);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 60);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 60);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 60);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 60);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 60);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 60);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 60);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 60);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 60);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 50);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 50);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 50);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 50);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 50);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 50);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 50);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 50);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 50);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 50);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 40);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 40);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 40);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 40);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 40);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 40);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 40);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 40);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 40);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 40);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 30);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 30);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 30);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 30);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 30);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 30);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 30);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 30);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 30);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 30);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 20);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 20);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 20);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 20);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 20);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 20);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 20);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 20);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 20);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 20);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 10);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 10);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 10);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 10);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 10);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 10);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 10);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 10);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 10);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 10);
                Thread.Sleep(150);
                this.ChangeAlpha(500, 220, 100, 100, 0);
                this.ChangeAlpha(0x1f5, 220, 100, 100, 0);
                this.ChangeAlpha(0x1f6, 220, 100, 100, 0);
                this.ChangeAlpha(0x1f7, 220, 100, 100, 0);
                this.ChangeAlpha(0x1f8, 0xff, 0xff, 0xff, 0);
                this.ChangeAlpha(0x1f9, 0xff, 0xff, 0xff, 0);
                this.ChangeAlpha(0x1fa, 0, 0, 0, 0);
                this.ChangeAlpha(0x1fb, 0, 0, 0, 0);
                this.ChangeAlpha(0x1fc, 190, 0x7f, 0x7d, 0);
                this.ChangeAlpha(0x1fd, 190, 0x7f, 0x7d, 0);
                Thread.Sleep(150);
                this.bool_1 = false;
            }
        }

        private void button155_Click_1(object sender, EventArgs e)
        {
            if (button155.Text == "OFF")
            {
                TTT.Start((uint)numericUpDown39.Value, (uint)numericUpDown40.Value);
                button155.Text = "ON";
                button155.ForeColor = Color.Green;
            }
            else if (button155.Text == "ON")
            {
                TTT.Stop();
                button155.Text = "OFF";
                button155.ForeColor = Color.Crimson;
            }
           
        }
        class Hudelem
    {
        #region Huds
        public static class HElems
        {
            public static uint
            xOffset = 0x04,
            yOffset = 0x08,
            zOffset = 0xC,
            textOffset = 0x84,
            fontOffset = 0x24,
            fontSizeOffset = 0x14,
            colorOffset = 0x30,
            relativeOffset = 0x2c,
            widthOffset = 0x44,
            heightOffset = 0x48,
            shaderOffset = 0x4C,
            GlowColor = 0x8C,
            alignOffset = 0x2C,
            clientOffset = 0xA8,
            AllClient = 0x7FF;

            public static uint duration = 0x7c;
            public static uint fadeStartTime = 0x38;
            public static uint fadeTime = 60;
            public static uint flags = 0xa4;
            public static uint fromAlignOrg = 0x68;
            public static uint fromAlignScreen = 0x6c;
            public static uint fromHeight = 0x54;
            public static uint fromWidth = 80;
            public static uint fromX = 0x60;
            public static uint fromY = 0x64;
            public static uint fxBirthTime = 0x90;
            public static uint fxDecayDuration = 0x9c;
            public static uint fxDecayStartTime = 0x98;
            public static uint fxLetterTime = 0x94;
            public static uint label = 0x40;
            public static uint moveStartTime = 0x70;
            public static uint moveTime = 0x74;
            public static uint scaleStartTime = 0x58;
            public static uint scaleTime = 0x5c;
            public static uint sort = 0x88;
            public static uint soundID = 160;
            public static uint time = 120;
            public static uint value = 0x80;
            public static uint
            type = 0x00,
            targetEntNum = 0x10,
            fontScale = 0x14,
            fromFontScale = 0x18,
            fontScaleStartTime = 0x1C,
            fontScaleTime = 0x20,
            font = 0x24,
            alignOrg = 0x28,
            alignScreen = 0x2C,
            color = 0x30,
            fromColor = 0x34,
            width = 0x44,
            height = 0x48,
            materialIndex = 0x4C,
            text = 0x84,
            glowColor = 0x8C;
        }

        public static uint CreateText(string text)
        {
            RPC_MW3.CallFunction(1828556u, RPC_MW3.str_pointer(text));
            System.Threading.Thread.Sleep(50);

            return RPC_MW3.GetFuncReturn();
        }
        public static byte[] uintBytes(uint input) { byte[] data = BitConverter.GetBytes(input); Array.Reverse(data); return data; }

        public static String[] centerString(String[] StringArray)
        {
            Int32 maxSize = 0;
            Int32 trimSize = 0;
            String tempStr = "";
            for (Int32 i = 0; i < StringArray.Length; i++)
            {
                if (StringArray[i].Length > maxSize)
                    maxSize = StringArray[i].Length;
            }
            for (Int32 i = 0; i < StringArray.Length; i++)
            {
                tempStr = "";
                if (StringArray[i].Length < maxSize)
                {
                    trimSize = maxSize - StringArray[i].Length;
                    for (Int32 x = 0; x < trimSize; x++)
                        tempStr += " ";
                }
                tempStr += StringArray[i];
                StringArray[i] = tempStr;
            }
            return StringArray;
        }
        public static String buildString(String[] StringArray)
        {
            String str = "";
            for (Int32 i = 0; i < StringArray.Length; i++)
                str += StringArray[i] + "\n";
            return str;
        }
        public static byte[] SetText(string text)
        {
            byte[] Index = uintBytes(CreateText(text + "\0"));
            return Index;
        }

        public static byte[] ReverseBytes(byte[] inArray) { Array.Reverse(inArray); return inArray; }
        public static byte[] ToHexFloat(float Axis) { byte[] bytes = BitConverter.GetBytes(Axis); Array.Reverse(bytes); return bytes; }
        public static byte[] RGBA(decimal R, decimal G, decimal B, decimal A) { byte[] RGBA = new byte[4]; byte[] RVal = BitConverter.GetBytes(Convert.ToInt32(R)); byte[] GVal = BitConverter.GetBytes(Convert.ToInt32(G)); byte[] BVal = BitConverter.GetBytes(Convert.ToInt32(B)); byte[] AVal = BitConverter.GetBytes(Convert.ToInt32(A)); RGBA[0] = RVal[0]; RGBA[1] = GVal[0]; RGBA[2] = BVal[0]; RGBA[3] = AVal[0]; return RGBA; }
        public static void ChangeShaderColor(uint elemIndex, int r, int g, int b, int a)
        {
            uint elem = Offsets.G_HudElems + ((elemIndex) * 0xB4);
            PS3.SetMemory(elem + HElems.colorOffset, RGBA(r, g, b, a));
        }
        public static void ChangeTextColor(uint elemIndex, int r, int g, int b, int a)
        {
            uint elem = Offsets.G_HudElems + ((elemIndex) * 0xB4);
            PS3.SetMemory(elem + HElems.colorOffset, RGBA(r, g, b, a));
        }

        public static void ZigZagText(uint elemIndex, short Speed)
        {
            uint Elem = Offsets.G_HudElems + (elemIndex) * 0xB4;
            float i = 0;
            PS3.SetMemory(Elem + HElems.xOffset, ToHexFloat(-400));

            for (; ; )
            {
                float X = PS3.Extension.ReadFloat(Elem + HElems.xOffset);
                if (i == 480)
                {
                    break;
                }
                if (X == (float)-400)
                {
                    float y = i += 120;
                    float x = 800;
                    MoveOverTime(elemIndex, Speed, x, y);
                }
                if (X == (float)800)
                {
                    float y = i += 120;
                    float x = -400;
                    MoveOverTime(elemIndex, Speed, x, y);
                }
                Thread.Sleep(Speed);
            }
        }

        public static void SpinText(uint Index, int Radius, int X, int Y)
        {
            int cx = X;
            int cy = Y;
            int rad = Radius;
            int i = 0;
            for (; ; )
            {
                double xx = cx + Math.Sin(i) * rad;
                double yy = cy + Math.Cos(i) * rad;
                MoveShaderXY(Index, (int)xx, (int)yy);
                Thread.Sleep(100);
                i++;
            }
        }

        public static void ChangeFontScaleOverTime(uint elemIndex, short Time, float OldFont, float NewFont)
        {
            uint Elem = Offsets.G_HudElems + (elemIndex) * 0xB4;
            PS3.Extension.WriteFloat(Elem + HElems.fromFontScale, OldFont);//fromFontScale
            PS3.Extension.WriteUInt32(Elem + HElems.fontScaleStartTime, GetLevelTime());//fontScaleStartTime
            PS3.Extension.WriteInt32(Elem + HElems.fontScaleTime, Time);//fontScaleTime
            PS3.Extension.WriteFloat(Elem + HElems.fontScale, NewFont);

        }

        public static void ScaleOverTime(uint elemIndex, short Time, decimal Width, decimal Height)
        {
            uint Elem = Offsets.G_HudElems + ((elemIndex) * 0xB4);
            PS3.Extension.WriteFloat(Elem + HElems.fromHeight, PS3.Extension.ReadFloat(Elem + HElems.heightOffset));//From Height
            PS3.Extension.WriteFloat(Elem + HElems.fromWidth, PS3.Extension.ReadFloat(Elem + HElems.widthOffset));//from Width
            PS3.Extension.WriteInt32(Elem + HElems.scaleTime, Time);
            PS3.Extension.WriteInt32(Elem + HElems.scaleStartTime, (Int32)GetLevelTime());//MoveStartTime
            PS3.SetMemory(Elem + HElems.heightOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(Height))));
            PS3.SetMemory(Elem + HElems.widthOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(Width))));
        }

        public static uint MoveOverTime(uint Elem, short Time, float X, float Y)
        {
            uint elem = Offsets.G_HudElems + ((uint)Elem) * 0xB4;
            WriteFloat(elem + HElems.fromX, PS3.Extension.ReadFloat(elem + HElems.xOffset));
            WriteFloat(elem + HElems.fromY, PS3.Extension.ReadFloat(elem + HElems.yOffset));
            PS3.Extension.WriteInt32(elem + HElems.moveTime, Time);
            PS3.Extension.WriteInt32(elem + HElems.moveStartTime, (Int32)GetLevelTime());
            WriteFloat(elem + HElems.xOffset, X);
            WriteFloat(elem + HElems.yOffset, Y);
            return Elem;
        }

    

        public static void FadeAlphaOverTime(uint elem, short Time, int OldAlpha, int NewAlpha)
        {
            uint Elem = Offsets.G_HudElems + (elem) * 0xB4;
            byte[] OldAVal = BitConverter.GetBytes(Convert.ToInt32(OldAlpha));//Convert Bytes To Int
            PS3.SetMemory(Elem + 0x37, OldAVal);//Set Old Alpha
            PS3.Extension.WriteUInt32(Elem + Hudelem.HElems.fadeStartTime, GetLevelTime());//Fade Start Time
            PS3.Extension.WriteInt32(Elem + Hudelem.HElems.fadeTime, Time);//Fade Time
            byte[] NewAVal = BitConverter.GetBytes(Convert.ToInt32(NewAlpha));//Convert Bytes To Int
            PS3.SetMemory(Elem + 0x33, NewAVal);//Set New Alpha
        }

        public static void WriteFloat(UInt32 offset, Single input)
        {
            Byte[] single = new Byte[4];
            BitConverter.GetBytes(input).CopyTo(single, 0);
            Array.Reverse(single, 0, 4);
            PS3.SetMemory(offset, single);
        }

        public static void doTypeWriter(uint ElemIndex, UInt32 clientIndex, String text, float fontScale, int font, Single X, Single Y, int fxLetterTime, int fxDecayStartTime, int fxDecayDuration, int r, int g, int b, int a, int r1, int b1, int g1, int a1)
        {
            string setText = text + "\0";
            byte[] TextIndex = SetText(setText);
            uint elem = Offsets.G_HudElems + ((ElemIndex) * 0xB4);
            byte[] ClientID = ReverseBytes(BitConverter.GetBytes(clientIndex));
            PS3.SetMemory(elem, new byte[0xB4]);
            PS3.SetMemory(elem, new byte[] { 0x00, 0x00, 0x00, 0x00 });
            PS3.SetMemory(elem + HElems.relativeOffset, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x92, 0xFF, 0xFF, 0xFF, 0xFF });
            PS3.SetMemory(elem + HElems.relativeOffset - 4, new byte[] { 0x00, 0x00, 0x00, 0x05 });
            PS3.SetMemory(elem + HElems.fontOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(font))));
            PS3.SetMemory(elem + HElems.alignOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(0))));
            PS3.SetMemory(elem + HElems.textOffset + 4, ReverseBytes(BitConverter.GetBytes(0)));
            PS3.SetMemory(elem + HElems.fontSizeOffset, ToHexFloat(fontScale));
            PS3.SetMemory(elem + HElems.xOffset, ToHexFloat(X));
            PS3.SetMemory(elem + HElems.yOffset, ToHexFloat(Y));
            PS3.SetMemory(elem + HElems.colorOffset, RGBA(r, g, b, a));
            PS3.SetMemory(elem + HElems.GlowColor, RGBA(r1, g1, b1, a1));
            PS3.SetMemory(elem + HElems.clientOffset, ClientID);
            PS3.SetMemory(elem + 0xA8, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(clientIndex))));
            byte[] Type_ = BitConverter.GetBytes(1);
            Array.Reverse(Type_);
            PS3.SetMemory(elem, Type_);
            //Typewriter
            PS3.Extension.WriteInt32(elem + HElems.fxBirthTime, (Int32)GetLevelTime());
            PS3.Extension.WriteInt32(elem + HElems.fxLetterTime, fxLetterTime);
            PS3.Extension.WriteInt32(elem + HElems.fxDecayStartTime, fxDecayStartTime);
            PS3.Extension.WriteInt32(elem + HElems.fxDecayDuration, fxDecayDuration);
            PS3.SetMemory(elem + HElems.textOffset, SetText(text));
        }

        public static void doTypeWriterCustom(uint Index, ushort fxLetterTime, ushort fxDecayStartTime, ushort fxDecayDuration)
        {
            uint elem = Offsets.G_HudElems + ((Index) * 0xB4);
            //TypeWriter
            PS3.Extension.WriteInt32(elem + HElems.fxBirthTime, (Int32)GetLevelTime());
            PS3.Extension.WriteInt32(elem + HElems.fxLetterTime, fxLetterTime);
            PS3.Extension.WriteInt32(elem + HElems.fxDecayStartTime, fxDecayStartTime);
            PS3.Extension.WriteInt32(elem + HElems.fxDecayDuration, fxDecayDuration);
        }

        public static uint GetLevelTime()
        {
            return PS3.Extension.ReadUInt32(Offsets.LevelTime);
        }

        public static void ChangeTextSub(int index, string txt)
        {
            string NewText = txt;
            byte[] Textz = Hudelem.SetText(NewText);
            uint elem = Offsets.G_HudElems + (((uint)index) * 0xB4);
            PS3.SetMemory(elem + Hudelem.HElems.textOffset, Textz);
        }

        public static void ChangeText(int index, string txt)
        {
            string NewText = txt + "\0";
            byte[] Textz = Hudelem.SetText(NewText);
            uint elem = Offsets.G_HudElems + ((Convert.ToUInt32(index)) * 0xB4);
            PS3.SetMemory(elem + Hudelem.HElems.textOffset, Textz);
        }
        public static void ChangeFont(int elemIndex, short font)
        {
            uint elem = Offsets.G_HudElems + ((Convert.ToUInt32(elemIndex)) * 0xB4);
            PS3.Extension.WriteInt16(elem + Hudelem.HElems.fontOffset, font);
        }
        public static void ChangeFontScale(uint elemIndex, double fontScale)
        {
            uint elem = Offsets.G_HudElems + (elemIndex) * 0xB4;
            PS3.Extension.WriteFloat(elem + Hudelem.HElems.fontSizeOffset, (float)fontScale);
        }

        // Store Icon
        //public static void StoreIcon(uint elemIndex, decimal client, decimal shader, decimal width, decimal height, float x, float y, uint align, float sort, decimal r, decimal g, decimal b, decimal a)
        // {
        //    uint elem = Offsets.G_HudElems + ((elemIndex) * 0xB4);
        //    byte[] ClientID = ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(client)));
        //    PS3.SetMemory(elem, new byte[0xB4]);
        //    PS3.SetMemory(elem, new byte[] { 0x00, 0x00, 0x00, 0x00 });
        //    PS3.SetMemory(elem + HElems.relativeOffset, new byte[] { 0x00, 0x00, 0x00, 0x01 });
        //    PS3.SetMemory(elem + HElems.relativeOffset - 4, new byte[] { 0x00, 0x00, 0x00, 0x00 });
        //    PS3.SetMemory(elem + HElems.shaderOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(shader))));
        //    PS3.SetMemory(elem + HElems.heightOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(height))));
        //    PS3.SetMemory(elem + HElems.widthOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(width))));
        //    PS3.SetMemory(elem + HElems.alignOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(align))));
        //    PS3.SetMemory(elem + HElems.textOffset + 4, ReverseBytes(BitConverter.GetBytes(sort)));
        //    PS3.SetMemory(elem + HElems.xOffset, ToHexFloat(x));
        //   PS3.SetMemory(elem + HElems.yOffset, ToHexFloat(y));
        //    PS3.SetMemory(elem + HElems.colorOffset, RGBA(r, g, b, a));
        //    PS3.SetMemory(elem + HElems.clientOffset, ClientID);
        //    PS3.SetMemory(elem + 0xA8, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(client))));
        //    byte[] Type_ = BitConverter.GetBytes(4);
        //   Array.Reverse(Type_);
        //   PS3.SetMemory(elem, Type_);
        // }
        public static void StoreIcon(uint elemIndex, decimal client, decimal shader, decimal width, decimal height, float x, float y, uint align, float sort, decimal r, decimal g, decimal b, decimal a, string Priority_)
        {
            byte[] PriorityB = new byte[0];

            byte[] PriorityA = new byte[0];

            if (Priority_ == "Back")
            {
                PriorityB = new byte[] { 5 };
                PriorityA = new byte[] { 0 };
            }
            if (Priority_ == "Front")
            {
                PriorityB = new byte[] { 7 };
                PriorityA = new byte[] { 69 };
            }

            uint elem = 0xF0E10C + ((elemIndex) * 0xB4);
            byte[] ClientID = ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(client)));
            PS3.SetMemory(elem, new byte[0xB4]);
            PS3.SetMemory(elem, new byte[] { 0x00, 0x00, 0x00, 0x00 });
            PS3.SetMemory(elem + HElems.relativeOffset, new byte[] { 0x00, 0x00, 0x00, 0x01 });
            PS3.SetMemory(elem + HElems.relativeOffset - 4, new byte[] { 0x00, 0x00, 0x00, 0x00 });
            PS3.SetMemory(elem + HElems.shaderOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(shader))));
            PS3.SetMemory(elem + HElems.heightOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(height))));
            PS3.SetMemory(elem + HElems.widthOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(width))));
            PS3.SetMemory(elem + HElems.alignOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(align))));
            PS3.SetMemory(elem + HElems.textOffset + 4, ReverseBytes(BitConverter.GetBytes(sort)));
            PS3.SetMemory(elem + HElems.xOffset, ToHexFloat(x));
            PS3.SetMemory(elem + 0x88, PriorityA);
            PS3.SetMemory(elem + 0xa7, PriorityB);
            PS3.SetMemory(elem + HElems.yOffset, ToHexFloat(y));
            PS3.SetMemory(elem + HElems.colorOffset, RGBA(r, g, b, a));
            PS3.SetMemory(elem + HElems.clientOffset, ClientID);
            PS3.SetMemory(elem + 0x2b, new byte[] { 0x5 });
            PS3.SetMemory(elem + 0xA8, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(client))));
            byte[] Type_ = BitConverter.GetBytes(4);
            Array.Reverse(Type_);
            PS3.SetMemory(elem, Type_);
        }
        public static void ChangeWidth(int elemIndex, short width)
        {
            uint elem = Offsets.G_HudElems + ((Convert.ToUInt32(elemIndex)) * 0xB4);
            PS3.Extension.WriteInt16(elem + HElems.widthOffset, width);
        }

        public static void ChangeText(uint index, string txt, int xAxis)
        {
            string NewText = txt + "\0";
            byte[] Textz = Hudelem.SetText(NewText);
            uint elem = Offsets.G_HudElems + ((index) * 0xB4);
            byte[] newX = new byte[4];
            newX = BitConverter.GetBytes(Convert.ToSingle(xAxis));
            Array.Reverse(newX);
            PS3.SetMemory(elem + HElems.xOffset, newX);
            PS3.SetMemory(elem + HElems.textOffset, Textz);
        }
        public static void ChangeAlpha(int index, int r, int g, int b, int a)
        {
            uint elem = Offsets.G_HudElems + (((uint)index) * 0xB4);
            PS3.SetMemory(elem + HElems.colorOffset, RGBA(r, g, b, a));
        }
        public static void ChangeTextSize(uint index, double fontScale_)
        {
            byte[] fontScale = new byte[4];
            fontScale = BitConverter.GetBytes(Convert.ToSingle(fontScale_));
            Array.Reverse(fontScale);
            PS3.SetMemory(Offsets.G_HudElems + (index * 0xB4) + 20, fontScale);
        }
        public static void DestroyAll()
        {
            PS3.SetMemory(Offsets.G_HudElems, new byte[184320]);
        }
        public static void DestroyElem(int index)
        {
            uint elem = Offsets.G_HudElems + (((uint)index) * 0xB4);
            PS3.SetMemory(elem, new byte[0xB4]);
        }
        public static void SetGlowText(uint elemIndex, int client, string Text, decimal font, float fontScale, float x, float y, uint align, float sort, decimal r, decimal g, decimal b, decimal a, decimal r1, decimal g1, decimal b1, decimal a1)
        {
            string setText = Text + "\0";
            byte[] TextIndex = SetText(setText);
            uint elem = Offsets.G_HudElems + ((elemIndex) * 0xB4);
            byte[] ClientID = ReverseBytes(BitConverter.GetBytes(client));
            PS3.SetMemory(elem, new byte[0xB4]);
            PS3.SetMemory(elem, new byte[] { 0x00, 0x00, 0x00, 0x00 });
            PS3.SetMemory(elem + HElems.relativeOffset, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x92, 0xFF, 0xFF, 0xFF, 0xFF });
            PS3.SetMemory(elem + HElems.relativeOffset - 4, new byte[] { 0x00, 0x00, 0x00, 0x05 });
            PS3.SetMemory(elem + Hudelem.HElems.textOffset, TextIndex);
            PS3.SetMemory(elem + HElems.fontOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(font))));
            PS3.SetMemory(elem + HElems.alignOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(align))));
            PS3.SetMemory(elem + HElems.textOffset + 4, ReverseBytes(BitConverter.GetBytes(sort)));
            PS3.SetMemory(elem + HElems.fontSizeOffset, ToHexFloat(fontScale));
            PS3.SetMemory(elem + HElems.xOffset, ToHexFloat(x));
            PS3.SetMemory(elem + HElems.yOffset, ToHexFloat(y));
            PS3.SetMemory(elem + HElems.colorOffset, RGBA(r, g, b, a));
            PS3.SetMemory(elem + HElems.GlowColor, RGBA(r1, g1, b1, a1));
            PS3.SetMemory(elem + HElems.clientOffset, ClientID);
            PS3.SetMemory(elem + 0xA8, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(client))));
            byte[] Type_ = BitConverter.GetBytes(1);
            Array.Reverse(Type_);
            PS3.SetMemory(elem, Type_);
        }

        public static void MoveShaderXY(uint index, float X, float Y)
        {
            PS3.Extension.WriteFloat(Offsets.G_HudElems + (index * 0xB4) + Hudelem.HElems.xOffset, X);
            PS3.Extension.WriteFloat(Offsets.G_HudElems + (index * 0xB4) + Hudelem.HElems.yOffset, Y);
        }

        public static void MoveShaderY(uint index, float Y)
        {
            PS3.Extension.WriteFloat(Offsets.G_HudElems + (index * 0xB4) + Hudelem.HElems.yOffset, Y);
        }

        public static void StoreTextElem(uint elemIndex, int client, string Text, double font, double fontScale, float x, float y, uint align, float sort, decimal r, decimal g, decimal b, decimal a)
        {
            string setText = Text + "\0";
            byte[] TextIndex = SetText(setText);
            uint elem = Offsets.G_HudElems + ((elemIndex) * 0xB4);
            byte[] ClientID = ReverseBytes(BitConverter.GetBytes(client));
            PS3.SetMemory(elem, new byte[0xB4]);
            PS3.SetMemory(elem, new byte[] { 0x00, 0x00, 0x00, 0x00 });
            PS3.SetMemory(elem + HElems.relativeOffset, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x92, 0xFF, 0xFF, 0xFF, 0xFF });
            PS3.SetMemory(elem + HElems.relativeOffset - 4, new byte[] { 0x00, 0x00, 0x00, 0x05 });
            PS3.SetMemory(elem + Hudelem.HElems.textOffset, TextIndex);
            PS3.Extension.WriteFloat(elem + HElems.fontOffset, (float)font);
            PS3.SetMemory(elem + HElems.alignOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(align))));
            PS3.SetMemory(elem + HElems.textOffset + 4, ReverseBytes(BitConverter.GetBytes(sort)));
            PS3.Extension.WriteFloat(elem + HElems.fontSizeOffset, (float)fontScale);
            PS3.SetMemory(elem + HElems.xOffset, ToHexFloat(x));
            PS3.SetMemory(elem + HElems.yOffset, ToHexFloat(y));
            PS3.SetMemory(elem + HElems.colorOffset, RGBA(r, g, b, a));
            PS3.SetMemory(elem + HElems.clientOffset, ClientID);
            PS3.SetMemory(elem + 0xA8, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(client))));
            byte[] Type_ = BitConverter.GetBytes(1);
            Array.Reverse(Type_);
            PS3.SetMemory(elem, Type_);
        }
        public static Int32 G_MaterialIndex(String Material)
        {
            return RPC_MW3.Call(0x001BE744, Material);
        }
        public static UInt32 HudElem_Alloc()
        {
            UInt32
                Address = 0xF0E10C,
                Run = 50;
            while (Run <= 1024)
            {
                if (PS3.Extension.ReadByte(Address + 3 + (Run * 0xB4)) == 0)
                    return (Address + (Run * 0xB4));
                else
                    Run++;
            }
            return 0;
        }
        public static UInt32 setIcon(Int32 Client, String Material, Int32 width, Int32 height, Single x, Single y, Byte r = 255, Byte g = 255, Byte b = 255, Byte a = 255)
        {
            UInt32 Elem = HudElem_Alloc();
            Byte[] Bytes = new Byte[0xB4];
            ArrayBuilder Builder = new ArrayBuilder(Bytes);
            Builder.Write.SetByte((Int32)HElems.type + 3, 4);
            Builder.Write.SetUInt32((Int32)HElems.materialIndex, (UInt32)G_MaterialIndex(Material));
            Builder.Write.SetInt32((Int32)HElems.width, width);
            Builder.Write.SetInt32((Int32)HElems.height, height);
            Builder.Write.SetFloat((Int32)HElems.xOffset, x);
            Builder.Write.SetFloat((Int32)HElems.yOffset, y);
            Byte[] Color = new Byte[] { r, g, b, a };
            Builder.Write.SetBytes((Int32)HElems.color, Color);
            Builder.Write.SetInt32((Int32)HElems.clientOffset, Client);
            PS3.SetMemory(Elem, Bytes);
            return Elem;
        }
        public static void SetGlow(uint elemIndex, decimal r1, decimal g1, decimal b1, decimal a1)
        {
            uint elem = Offsets.G_HudElems + ((elemIndex) * 0xB4);
            PS3.SetMemory(elem + HElems.GlowColor, RGBA(r1, g1, b1, a1));
        }

        public static void ActivateIndex(Boolean State, int index, int type)
        {

            uint elem = Offsets.G_HudElems + ((uint)index * 0xB4);
            byte[] Type_ = BitConverter.GetBytes(type);
            Array.Reverse(Type_);
            if (State == true)
            {
                PS3.SetMemory(elem, Type_);
            }
            else
            {
                PS3.SetMemory(elem, new byte[] { 0x00, 0x00, 0x00, 0x00 });
            }
        }
    
}
        #endregion
        public static void Zoidberg(int client)
        {
            Hudelem.StoreIcon(504 + (32 * (uint)client), client, 1, 194, 185, 320, 180, 0, 0, 255, 58, 69, 255, "Back");//Background
            Hudelem.StoreIcon(505 + (32 * (uint)client), client, 1, 57, 55, 252, 285, 0, 0, 255, 58, 69, 255, "Back");//Mouth 1
            Hudelem.StoreIcon(506 + (32 * (uint)client), client, 1, 57, 55, 390, 285, 0, 0, 255, 58, 69, 255, "Back");//Mouth 2
            Hudelem.StoreIcon(511 + (32 * (uint)client), client, 1, 57, 55, 321, 285, 0, 0, 255, 58, 69, 255, "Back");//Mouth 3
            Hudelem.StoreIcon(512 + (32 * (uint)client), client, 1, 14, 14, 287, 279, 0, 0, 55, 39, 39, 255, "Front");//Mouth Square 1
            Hudelem.StoreIcon(513 + (32 * (uint)client), client, 1, 14, 14, 354, 279, 0, 0, 55, 39, 39, 255, "Front");//Mouth Square 2
            Hudelem.StoreIcon(500 + (32 * (uint)client), client, 1, 70, 45, 258, 180, 0, 0, 255, 255, 255, 255, "Front");//Eye 1 (White)
            Hudelem.StoreIcon(501 + (32 * (uint)client), client, 1, 22, 22, 258, 168, 0, 0, 32, 32, 32, 255, "Front");//Eye 2 (Black)
            Hudelem.StoreIcon(510 + (32 * (uint)client), client, 1, 22, 22, 382, 168, 0, 0, 32, 32, 32, 255, "Front");//Eye 3 (Black)
            Hudelem.StoreIcon(503 + (32 * (uint)client), client, 1, 70, 45, 382, 180, 0, 0, 255, 255, 255, 255, "Front");//Eye 4 (white)
            Hudelem.doTypeWriter(515 + (32 * (uint)client), (uint)client, "Zoidberg is back?!", 1.2f, 7, 285, 350, 127, 900, 6000, 255, 255, 255, 255, 255, 0, 0, 255);
            Hudelem.doTypeWriterCustom(515, 115, 900, 6000);
            System.Threading.Thread.Sleep(6000);
            Hudelem.doTypeWriter(516 + (32 * (uint)client), (uint)client, "Remaked By MegaMister", 1.2f, 7, 285, 353, 130, 1000, 6000, 255, 255, 255, 255, 255, 0, 0, 255);
            System.Threading.Thread.Sleep(5000);
            Hudelem.DestroyElem(504);
            Hudelem.DestroyElem(505);
            Hudelem.DestroyElem(506);
            Hudelem.DestroyElem(511);
            Hudelem.DestroyElem(512);
            Hudelem.DestroyElem(513);
            Hudelem.DestroyElem(500);
            Hudelem.DestroyElem(501);
            Hudelem.DestroyElem(510);
            Hudelem.DestroyElem(503);
        }
        private void numericUpDown39_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown40_ValueChanged(object sender, EventArgs e)
        {

        }
        
       
       
      
        private void button156_Click(object sender, EventArgs e)
        {

            Zoidberg((int)numericUpDown41.Value);
      
        }
        public static void Anonymous(int client)
{
Hudelem.doTypeWriter(600 + (32 * (uint)client), Hudelem.HElems.AllClient, "We are Anonymous!!!!!!", 2.2f, 2, 320, 340, 130, 1000, 8000, 255, 255, 255, 255, 0, 0, 0, 0);

Hudelem.StoreIcon(605 + (32 * (uint)client), Hudelem.HElems.AllClient, 1, 200, 200, 320, 180, 0, 0, 255, 255, 255, 255, "Back");//Background (white)
Hudelem.StoreIcon(606 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 66, 22, 253, 111, 0, 0, 32, 32, 32, 255, "Front");//eyebrau left (Black)
Hudelem.StoreIcon(607 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 66, 22, 387, 111, 0, 0, 32, 32, 32, 255, "Front");//eyebrau right (Black)

Hudelem.StoreIcon(608 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 46, 22, 275, 160, 0, 0, 32, 32, 32, 255, "Front");//Eye left (Black)
Hudelem.StoreIcon(609 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 46, 22, 367, 160, 0, 0, 32, 32, 32, 255, "Front");//Eye right (Black)
Hudelem.StoreIcon(610 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 46, 22, 320, 210, 0, 0, 32, 32, 32, 255, "Front");//mustache Center (Black)
Hudelem.StoreIcon(611 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 56, 22, 270, 231, 0, 0, 32, 32, 32, 255, "Front");//mustache Left (Black)
Hudelem.StoreIcon(612 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 56, 22, 371, 231, 0, 0, 32, 32, 32, 255, "Front");//mustache right (Black)
Hudelem.StoreIcon(613 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 22, 22, 231, 210, 0, 0, 32, 32, 32, 255, "Front");//mustache Left top(Black)
Hudelem.StoreIcon(614 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 22, 22, 409, 210, 0, 0, 32, 32, 32, 255, "Front");//mustache right top(Black)
Hudelem.StoreIcon(615 + (32 * (uint)client), Hudelem.HElems.AllClient, 1, 22, 22, 231, 188, 0, 0, 234, 142, 135, 255, "Front");//cheek left (pink)
Hudelem.StoreIcon(616 + (32 * (uint)client), Hudelem.HElems.AllClient, 1, 22, 22, 409, 188, 0, 0, 234, 142, 135, 255, "Front");//cheek right (pink)
Hudelem.StoreIcon(617 + (32 * (uint)client), Hudelem.HElems.AllClient, 1, 86, 22, 320, 253, 0, 0, 234, 142, 135, 255, "Front");//mouth (pink)
Hudelem.StoreIcon(618 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 22, 46, 320, 286, 0, 0, 32, 32, 32, 255, "Front");//goaty Center (Black)
Hudelem.StoreIcon(619 + (32 * (uint)client), Hudelem.HElems.AllClient, 1, 140, 22, 320, 290, 0, 0, 255, 255, 255, 255, "Back");//Background (white)
Hudelem.StoreIcon(620 + (32 * (uint)client), Hudelem.HElems.AllClient, 1, 100, 22, 320, 302, 0, 0, 255, 255, 255, 255, "Back");//Background (white)

System.Threading.Thread.Sleep(4000);
Hudelem.DestroyElem(605);
Hudelem.DestroyElem(606);
Hudelem.DestroyElem(607);
Hudelem.DestroyElem(608);
Hudelem.DestroyElem(609);
Hudelem.DestroyElem(610);
Hudelem.DestroyElem(611);
Hudelem.DestroyElem(612);
Hudelem.DestroyElem(613);
Hudelem.DestroyElem(614);
Hudelem.DestroyElem(615);
Hudelem.DestroyElem(616);
Hudelem.DestroyElem(617);
Hudelem.DestroyElem(618);
Hudelem.DestroyElem(619);
Hudelem.DestroyElem(620);
}
        private void button157_Click(object sender, EventArgs e)
        {
            Anonymous((int)numericUpDown41.Value);
        }
        public static void Anonymousv2(int client)
        {
            Hudelem.doTypeWriter(800 + (32 * (uint)client), Hudelem.HElems.AllClient, "We are Anonymous!!!!!!", 2.2f, 2, 320, 340, 130, 1000, 8000, 255, 255, 255, 255, 0, 0, 0, 0);
            Hudelem.StoreIcon(801 + (32 * (uint)client), Hudelem.HElems.AllClient, 1, 140, 22, 320, 290, 0, 0, 255, 255, 255, 255, "Back");//Background (white)
            Hudelem.StoreIcon(802 + (32 * (uint)client), Hudelem.HElems.AllClient, 1, 100, 22, 320, 302, 0, 0, 255, 255, 255, 255, "Back");//Background (white)
            Hudelem.StoreIcon(803 + (32 * (uint)client), Hudelem.HElems.AllClient, 1, 200, 200, 320, 180, 0, 0, 255, 255, 255, 255, "Back");//Background (white)
            Hudelem.StoreIcon(804 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 66, 22, 253, 111, 0, 0, 32, 32, 32, 255, "Front");//eyebrau left (Black)
            Hudelem.StoreIcon(805 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 22, 22, 286, 125, 0, 0, 32, 32, 32, 255, "Front");//eyebrau left2 (Black)
            Hudelem.StoreIcon(806 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 66, 22, 387, 111, 0, 0, 32, 32, 32, 255, "Front");//eyebrau right (Black)
            Hudelem.StoreIcon(807 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 22, 22, 356, 125, 0, 0, 32, 32, 32, 255, "Front");//eyebrau right2 (Black)
            Hudelem.StoreIcon(808 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 46, 16, 275, 170, 0, 0, 32, 32, 32, 255, "Front");//Eye left (Black)
            Hudelem.StoreIcon(809 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 46, 16, 367, 170, 0, 0, 32, 32, 32, 255, "Front");//Eye right (Black)
            Hudelem.StoreIcon(810 + (32 * (uint)client), Hudelem.HElems.AllClient, 1, 32, 8, 320, 217, 0, 0, 104, 97, 96, 40, "Front");//Nose Center (Black)
            Hudelem.StoreIcon(811 + (32 * (uint)client), Hudelem.HElems.AllClient, 1, 4, 65, 338, 185, 0, 0, 104, 97, 96, 40, "Front");//Nose Center (Black)
            Hudelem.StoreIcon(812 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 56, 22, 270, 231, 0, 0, 32, 32, 32, 255, "Front");//mustache Left (Black)
            Hudelem.StoreIcon(813 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 56, 22, 371, 231, 0, 0, 32, 32, 32, 255, "Front");//mustache right (Black)
            Hudelem.StoreIcon(814 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 16, 22, 234, 220, 0, 0, 32, 32, 32, 255, "Front");//mustache Left middle(Black)
            Hudelem.StoreIcon(815 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 16, 22, 406, 220, 0, 0, 32, 32, 32, 255, "Front");//mustache right middle(Black)
            Hudelem.StoreIcon(816 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 16, 16, 306, 229, 0, 0, 32, 32, 32, 255, "Front");//mustache Center left(Black)
            Hudelem.StoreIcon(817 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 16, 16, 336, 229, 0, 0, 32, 32, 32, 255, "Front");//mustache Center right(Black)
            Hudelem.StoreIcon(818 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 120, 6, 320, 248, 0, 0, 234, 142, 135, 255, "Front");//mouth (black)
            Hudelem.StoreIcon(819 + (32 * (uint)client), Hudelem.HElems.AllClient, 1, 45, 6, 320, 260, 0, 0, 104, 97, 96, 40, "Front");//mouth shadow(grey)
            Hudelem.StoreIcon(820 + (32 * (uint)client), Hudelem.HElems.AllClient, 2, 18, 46, 320, 290, 0, 0, 32, 32, 32, 255, "Front");//goaty Center (Black)

            Thread.Sleep(4000);

            Hudelem.DestroyElem(800);
            Hudelem.DestroyElem(801);
            Hudelem.DestroyElem(802);
            Hudelem.DestroyElem(803);
            Hudelem.DestroyElem(804);
            Hudelem.DestroyElem(805);
            Hudelem.DestroyElem(806);
            Hudelem.DestroyElem(807);
            Hudelem.DestroyElem(808);
            Hudelem.DestroyElem(809);
            Hudelem.DestroyElem(810);
            Hudelem.DestroyElem(811);
            Hudelem.DestroyElem(812);
            Hudelem.DestroyElem(813);
            Hudelem.DestroyElem(814);
            Hudelem.DestroyElem(815);
            Hudelem.DestroyElem(816);
            Hudelem.DestroyElem(817);
            Hudelem.DestroyElem(818);
            Hudelem.DestroyElem(819);
            Hudelem.DestroyElem(820);

        }

      

        private void button158_Click(object sender, EventArgs e)
        {
            Anonymousv2((int)numericUpDown41.Value);
        }

        private void numericUpDown41_ValueChanged(object sender, EventArgs e)
        {

        }
        public static Boolean inGame()
        {
            if (PS3.Extension.ReadByte(0x007f0736) != 0)
                return true;
            else
                return false;
        }
        private void button646_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (inGame())
                {
                    UInt32 AllClientHUD = 0x7FF;
                    if (Mw3StoreIconRadio.Checked)
                    {
                        if (Mw3IconClient.Value == -1)
                        {
                            Hudelem.StoreIcon((UInt32)Mw3IconElementIndex.Value, AllClientHUD, (Int32)Mw3IconShader.Value, (Int32)Mw3IconWidth.Value, (Int32)Mw3IconHeight.Value,
                                (Int32)Mw3IconX.Value, (Int32)Mw3IconY.Value, (UInt32)Mw3IconAlign.Value, (Int32)Mw3IconSort.Value, (Int32)Mw3IconR.Value, (Int32)Mw3IconG.Value, (Int32)Mw3IconB.Value, (Int32)Mw3IconA.Value, (String)Mw3IconPriority.Text);
                        }
                        else
                        {
                            Hudelem.StoreIcon((UInt32)Mw3IconElementIndex.Value, (UInt32)Mw3IconClient.Value, (Int32)Mw3IconShader.Value, (Int32)Mw3IconWidth.Value, (Int32)Mw3IconHeight.Value,
                                (Int32)Mw3IconX.Value, (Int32)Mw3IconY.Value, (UInt32)Mw3IconAlign.Value, (Int32)Mw3IconSort.Value, (Int32)Mw3IconR.Value, (Int32)Mw3IconG.Value, (Int32)Mw3IconB.Value, (Int32)Mw3IconA.Value, (String)Mw3IconPriority.Text);
                        }
                    }
                    else
                    {
                        if (Mw3IconClient.Value == -1)
                        {
                            Hudelem.setIcon((Int32)AllClientHUD, (String)Mw3IconeMaterial.Text, (Int32)Mw3IconWidth.Value, (Int32)Mw3IconHeight.Value,
                                (float)Mw3IconX.Value, (float)Mw3IconY.Value, (Byte)Mw3IconR.Value, (Byte)Mw3IconG.Value, (Byte)Mw3IconB.Value, (Byte)Mw3IconA.Value);
                        }
                        else
                        {
                            Hudelem.setIcon((Int32)Mw3IconClient.Value, (String)Mw3IconeMaterial.Text, (Int32)Mw3IconWidth.Value, (Int32)Mw3IconHeight.Value,
                                (float)Mw3IconX.Value, (float)Mw3IconY.Value, (Byte)Mw3IconR.Value, (Byte)Mw3IconG.Value, (Byte)Mw3IconB.Value, (Byte)Mw3IconA.Value);
                        }
                    }
                }
            }
            catch { }
        }
        private void Mw3StoreIconRadioChecked()
        {
            Mw3IconElementIndex.Enabled = true;
            Mw3IconShader.Enabled = true;
            Mw3IconSort.Enabled = true;
            Mw3IconAlign.Enabled = true;
            Mw3IconPriority.Enabled = true;
            Mw3IconeMaterial.Enabled = false;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Mw3StoreIconRadioChecked();
        }
      
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Mw3IconElementIndex.Enabled = false;
            Mw3IconShader.Enabled = false;
            Mw3IconSort.Enabled = false;
            Mw3IconAlign.Enabled = false;
            Mw3IconPriority.Enabled = false;
            Mw3IconeMaterial.Enabled = true;
        }

        private void Mw3IconColorControl_SelectedColorChanged(object sender, EventArgs e)
        {
            Mw3IconR.Value = Mw3IconColorControl.SelectedColor.R;
            Mw3IconG.Value = Mw3IconColorControl.SelectedColor.G;
            Mw3IconB.Value = Mw3IconColorControl.SelectedColor.B;
            Mw3IconR.ForeColor = Mw3IconColorControl.SelectedColor;
            Mw3IconG.ForeColor = Mw3IconColorControl.SelectedColor;
            Mw3IconB.ForeColor = Mw3IconColorControl.SelectedColor;
            panel3.BackColor =   Mw3IconColorControl.SelectedColor;
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button159_Click(object sender, EventArgs e)
        {
            DestroyAll();
            Thread.Sleep(20);
        }

        private void button160_Click(object sender, EventArgs e)
        {
           
        }

        private void button161_Click(object sender, EventArgs e)
        {
             for (int i = 1060; i < 1090; i++)
            {
                RPC_MW3.SV_GameSendServerCommand(-1, "d " + i + comboBox9.Text);
            }
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
 
            }

        private void toolStripMenuItem36_Click(object sender, EventArgs e)
        {
        
        }
        public static void Invert(Int32 client, Byte input)
        {
            PS3.SetMemory(0x110a280 + 0x64 + ((UInt32)client * 0x3980), new Byte[] { 0x44 });
            PS3.SetMemory(0x110a280 + 0x68 + ((UInt32)client * 0x3980), new Byte[] { 0x44 });
            PS3.Extension.WriteByte(0x110a280 + 0x65 + ((UInt32)client * 0x3980), input);
            PS3.Extension.WriteByte(0x110a280 + 0x69 + ((UInt32)client * 0x3980), input);
        }
        private void onToolStripMenuItem16_Click(object sender, EventArgs e)
        {
             PS3.SetMemory(0x0110d73f + ((uint)dataGridView1.CurrentRow.Index * 0x3980), new byte[] { 0x01, 0xFF });
        }

        private void offToolStripMenuItem16_Click(object sender, EventArgs e)
        {
        PS3.SetMemory(0x0110d73f + ((uint)dataGridView1.CurrentRow.Index * 0x3980), new byte[] { 0x00, 0x00 });
        }

        private void numericUpDown42_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown43_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button160_Click_1(object sender, EventArgs e)
        {
            Invert((int)numericUpDown42.Value, (byte)numericUpDown43.Value);
        }

        private void onToolStripMenuItem17_Click(object sender, EventArgs e)
        {
            PS3.SetMemory((uint)(0x110a280 + ((uint)dataGridView1.CurrentRow.Index * 0x3980)), new byte[] { 0x80 });
        }

        private void offToolStripMenuItem17_Click(object sender, EventArgs e)
        {
            PS3.SetMemory((uint)(0x110a280 + ((uint)dataGridView1.CurrentRow.Index * 0x3980)), new byte[] { 0x00 });
        }

        private void onToolStripMenuItem18_Click(object sender, EventArgs e)
        {
            PS3.SetMemory((uint)(0x110a280 + ((uint)dataGridView1.CurrentRow.Index * 0x3980)), new byte[] { 0x30 });
        }

        private void offToolStripMenuItem18_Click(object sender, EventArgs e)
        {
            PS3.SetMemory((uint)(0x110a280 + ((uint)dataGridView1.CurrentRow.Index * 0x3980)), new byte[] { 0x00 });
        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox33_TextChanged(object sender, EventArgs e)
        {

        }

        private void button162_Click(object sender, EventArgs e)
        {
            byte[] NAME = Encoding.ASCII.GetBytes(textBox32.Text);
            Array.Resize(ref NAME, NAME.Length + 1);
            PS3.SetMemory(0x318c9ab1, NAME);
            byte[] NAME1 = Encoding.ASCII.GetBytes(textBox33.Text);
            Array.Resize(ref NAME1, NAME1.Length + 1);
            PS3.SetMemory(0x318c838b, NAME1);
        }

        private void button163_Click(object sender, EventArgs e)
        {
            RPC_MW3.CBuf_AddText(-1, "gameInvitesReceived");
        }

        private void numericUpDown54_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown53_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown52_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button164_Click(object sender, EventArgs e)
        {
            RPC_MW3.SV_GameSendServerCommand(-1, "d 8 " + numericUpDown54.Value + " " + numericUpDown53.Value + " " + numericUpDown52.Value);
        }

        private void button165_Click(object sender, EventArgs e)
        {
            SetSunLight(-1, 1.0, 1.0, 1.0);
        }
        public static void SetSunLight(int Client, double R, double G, double B)
        {
            RPC_MW3.SV_GameSendServerCommand(Client, "d 8 " + R + " " + G + " " + B);
        }
        public static void Disco1()
        {
            PS3.ConnectTarget();// Since this is a thread out side the current UI we have to connect to the ps3 again.
            while (DiscoThread.IsAlive)
            {
                for (double Colour = 1; Colour < 14; Colour++)
                {
                    if (Colour > 2)//Red
                    {
                        if (Colour > 4)//Yellow
                        {
                            if (Colour > 6)//Grenn
                            {
                                if (Colour > 8)//Cyan
                                {
                                    if (Colour > 10)//Blue
                                    {
                                        if (Colour == 13)//Violett
                                        {
                                            RPC_MW3.iPrintln(-1, "^1F^2U^4C^1K^2I^4N^1G ^2P^4A^1R^2T^4Y ^1H^2A^4R^1D ^6<3");
                                        }
                                        else
                                            SetSunLight(-1, Colour - 10, 0, Colour - 10);
                                    }
                                    else
                                        SetSunLight(-1, 0, 0, Colour - 8);
                                }
                                else
                                    SetSunLight(-1, 0, Colour - 6, Colour - 6);
                            }
                            else
                                SetSunLight(-1, 0, Colour - 4, 0);
                        }
                        else
                            SetSunLight(-1, Colour - 2, Colour - 2, 0);
                    }
                    else
                        SetSunLight(-1, Colour, 0, 0);
                    Thread.Sleep(200);
                }
            }
        }
        public static bool DiscoState = false;
        public static Thread DiscoThread;
        private void button167_Click(object sender, EventArgs e)
        {
            ThreadStart Start = null;
            Thread.Sleep(100);
            if (Start == null)
            {
                Start = () => Disco1();
            }
            DiscoThread = new Thread(Start);
            DiscoThread.IsBackground = true;
            DiscoThread.Start();
        }

        private void button166_Click(object sender, EventArgs e)
        {
            DiscoThread.Abort();
            SetSunLight(-1, 1.0, 1.0, 1.0);
        }

        private void button169_Click(object sender, EventArgs e)
        {
           
        }

        private void button168_Click(object sender, EventArgs e)
        {
           
        }
        public static uint SolidModel1(float[] Origin, float[] Angles, string Model, Int32 Index)// = Bush.CarePackage "com_plasticcase_friendly"
        {
            uint Entity = (uint)RPC_MW3.Call(0x01C058C);//G_Spawn
            WriteFloatArray(Entity + 0x138, Origin);//Position
            WriteFloatArray(Entity + 0x144, Angles);//Orientation
            RPC_MW3.Call(0x01BEF5C, Entity, Model);//G_SetModel
            RPC_MW3.Call(0x01B6F68, Entity); //SP_script_model
            RPC_MW3.Call(0x002377B8, Entity);//SV_UnlinkEntity
            PS3.Extension.WriteByte(Entity + 0x101, 4);
            WriteInt(Entity + 0x8C, (Int32)Index);
            RPC_MW3.Call(0x0022925C, Entity);//SV_SetBrushModel
            RPC_MW3.Call(0x00237848, Entity);//SV_LinkEntity
            return Entity;
        }
        public static void SpawnWall(UInt32 Client, uint Height, uint Length)
        {
            bool State = false;
            bool State1 = false;
            uint Count = Height;
            float[] Origin = new float[3];
            float[] NewOrigin = new float[3];
            float[] Angles = new float[3];
            float[] forward = new float[3];

            for (uint i = 0; i < Length * Height + 1; i++)
            {
                if (State == false)
                {
                    Origin = GetOrigin(Client);
                    NewOrigin = Origin;
                    Angles = GetAngles(Client);
                    forward = AnglesToForward(Origin, new float[] { 0, Angles[1], 0 }, 55);
                    State = true;
                }
                SolidModel1(new float[] { forward[0], forward[1], Origin[2] }, new float[] { 0, Angles[1] + 90, 0 }, "com_plasticcase_friendly", 2);
                if (State1 == true)
                {
                    if (i == Count)
                    {
                        Origin[2] += -((Height - 1) * 25);
                        NewOrigin = AnglesToForward(NewOrigin, new float[] { 0, Angles[1] - 90, 0 }, 55);
                        forward = AnglesToForward(NewOrigin, new float[] { 0, Angles[1], 0 }, 55);
                        Count += Height;
                    }
                    else
                    {
                        Origin[2] += 25;
                    }
                }
                else
                {
                    State1 = true;

                }

            }
            State = false;
            State1 = false;
        }
        public static void SpawnO(UInt32 Client, uint Height, uint Length)
        {
            bool State = false;
            bool State1 = false;
            uint Count = Height;
            float[] Origin = new float[3];
            float[] NewOrigin = new float[3];
            float[] Angles = new float[3];
            float[] forward = new float[3];

            for (uint i = 0; i < Length * Height + 1; i++)
            {
                if (State == false)
                {
                    Origin = GetOrigin(Client);
                    NewOrigin = Origin;
                    Angles = GetAngles(Client);
                    forward = AnglesToForward(Origin, new float[] { 0, Angles[1], 0 }, 55);
                    Angles[1] += 15;
                    State = true;
                }
               SolidModel1(new float[] { forward[0], forward[1], Origin[2] }, new float[] { 0, Angles[1] + 90, 0 }, "com_plasticcase_friendly", 2);
                if (State1 == true)
                {
                    if (i == Count)
                    {
                        Origin[2] += -((Height - 1) * 25);
                        NewOrigin = AnglesToForward(NewOrigin, new float[] { 0, Angles[1] - 90, 0 }, 55);
                        forward = AnglesToForward(NewOrigin, new float[] { 0, Angles[1], 0 }, 55);
                        Count += Height;
                        Angles[1] += 15;
                    }
                    else
                    {
                        Origin[2] += 25;
                    }
                }
                else
                {
                    State1 = true;

                }

            }
            State = false;
            State1 = false;
        }
        public static float[] AnglesToForward(float[] Origin, float[] Angles, uint Distance)
        {
            float diff = Distance;
            float num = ((float)Math.Sin((Angles[0] * Math.PI) / 180)) * diff;
            float num1 = (float)Math.Sqrt(((diff * diff) - (num * num)));
            float num2 = ((float)Math.Sin((Angles[1] * Math.PI) / 180)) * num1;
            float num3 = ((float)Math.Cos((Angles[1] * Math.PI) / 180)) * num1;
            return new float[] { Origin[0] + num3, Origin[1] + num2, Origin[2] - num };
        }
        private void button170_Click(object sender, EventArgs e)
        {
            SpawnWall(0,5,5);
        }

        private void button168_Click_1(object sender, EventArgs e)
        {
            SpawnO((uint)Client, 5, 25);
        }

        private void comboBox9_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button169_Click_1(object sender, EventArgs e)
        {
            RPC_MW3.SV_GameSendServerCommand(-1, "d 1134 " + comboBox11.Text);
        }

        private void comboBox11_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }
        public static void PS3Freeze(Int32 client)
        {
            PS3.SetMemory(0x0110A4FF + ((UInt32)client * 0x3980), new byte[] {0x4a, 0x4a, 0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a, 0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a, 0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a, 0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,
                0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a,
                0x4a,0x4a, 0x4a,0x4a, 0x4a,0x4a, 0x4a});
        }
        public static void KickPlayer(uint client, String message)
        {//Credits To SC58< for this function
            RPC_MW3.Call(0x00223BD0, new Object[] { client, message });
        }
        private void comboBox14_SelectedIndexChanged_3(object sender, EventArgs e)
        {

        }
          public static void Kickgod(string message)
        {
            for (uint i = 0; i < 18; i++)
            {
                byte[] antigod1 = new byte[1];
                byte[] antigod2 = new byte[1];
                byte[] antigod3 = new byte[1];
                PS3.GetMemory(0x110a280 + 0x27b + (i * 0x3980),  antigod1);
                PS3.GetMemory(0x110a280 + 0x283 + (i * 0x3980),  antigod2);
                PS3.GetMemory(0x110a280 + 0x27f + (i * 0x3980),  antigod3);
                if (antigod1[0] != 0x00 && antigod2[0] == 0x00 && antigod3[0] == 0x00)
                {
                    RPC_MW3.SV_GameSendServerCommand((Int32)i, "^1FUCK OFF");
                    Thread.Sleep(50);
                    PS3Freeze((Int32)i);//freeze clients console
                    Thread.Sleep(100);
                    KickPlayer(i, message);//kick the fuck out
                    
                }
            }        
          }
            
        private void button171_Click(object sender, EventArgs e)
        {
            RPC_MW3.SV_GameSendServerCommand(-1, "d 1657 " + comboBox14.Text);
        }
        public static void PlaySound(int Client, Int32 SoundID)
        {
            RPC_MW3.SV_GameSendServerCommand(Client, "n " + SoundID);
        }
        private void numericUpDown58_ValueChanged(object sender, EventArgs e)
        {
            PlaySound(-1, (Int32)numericUpDown58.Value);
        }

        private void Crate_Tick(object sender, EventArgs e)
        {
            if (PS3.Extension.ReadFloat(0x110a5f8 + ((uint)FXC.Value * 0x3980)) > 0)
            {
                float[] Origin = GetOrigin((uint)numericUpDown59.Value);
                float[] Angles = GetAngles((uint)numericUpDown59.Value);
                Origin[2] += 30;
                SolidModel1(AnglesToForward(Origin, new float[] { 0, 0, 0 }, 80), new float[] { 0, Angles[1] + 90, 0 }, comboBox15.Text, 2);
            }
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown59_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button24_Click_1(object sender, EventArgs e)
        {
            if (button24.Text == "DrawModels [ OFF ]")
            {
                Crate.Start();
                button24.Text = "DrawModels [ ON ]";
            }
            else if (button24.Text == "DrawModels [ ON ]")
            {
                Crate.Stop();
                button24.Text = "DrawModels [ OFF ]";
            }
        }

        private void button172_Click(object sender, EventArgs e)
        {
            RPC_MW3.SV_GameSendServerCommand(-1, "q cg_deadChatWithDead 1" + " cg_deadChatWithTeam 1" + " cg_deadHearTeamLiving 1" + " cg_deadHearAllLiving 1" + " cg_everyonehearseveryone 1");
        }

        private void button562_Click_1(object sender, EventArgs e)
        {
             
     
              
        }
    }
}
        





            #endregion