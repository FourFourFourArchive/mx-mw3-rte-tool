using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;

    public static class TTT
    {
        #region Values
        private static string Player1, Player2, Turn, Option;
        private static bool[] PLAYER1 = new bool[10], PLAYER2 = new bool[10], STATE = new bool[10];
        private static bool TTTStatus, GameEnd = false;
        private static Thread TTTThread;
        private static uint
           CreditsIndex = 500,
           MoveIndex = 501,
           SelectIndex = 502,
           Player2Index = 503,
           Player1Index = 504,
           TITELIndex = 505,
           AIndex = 506,
           BIndex = 507,
           CIndex = 508,
           DIndex = 509,
           EIndex = 510,
           FIndex = 511,
           GIndex = 512,
           HIndex = 513,
           IIndex = 514,
           SCROLLERIndex = 515,
          TypewriterIndex = 516;
        #endregion

        #region Read + Write

        private static string ReadString(uint Offset)
        {
            uint num = 0;
            List<byte> List = new List<byte>();
            while (true)
            {
                byte[] buffer = new byte[1];
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.GetMemory(Offset + num, buffer);
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
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.GetMemory(Offset, buffer);
            Array.Reverse(buffer, 0, 4);
            return BitConverter.ToSingle(buffer, 0);
        }

        private static int ReadInt(uint Offset)
        {
            byte[] buffer = new byte[4];
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.GetMemory(Offset, buffer);
            Array.Reverse(buffer);
            int Value = BitConverter.ToInt32(buffer, 0);
            return Value;
        }

        private static float[] ReadFloatLength(uint Offset, int Length)
        {
            byte[] buffer = new byte[Length * 4];
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.GetMemory(Offset, buffer);
            ReverseBytes(buffer);
            float[] Array = new float[Length];
            for (int i = 0; i < Length; i++)
            {
                Array[i] = BitConverter.ToSingle(buffer, (Length - 1 - i) * 4);
            }
            return Array;
        }

        private static void WriteString(uint Offset, string Text)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(Text);
            Array.Resize(ref buffer, buffer.Length + 1);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offset, buffer);
        }

        private static void WriteByte(uint Offset, byte Byte)
        {
            byte[] buffer = new byte[1];
            buffer[0] = Byte;
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offset, buffer);
        }

        private static void WriteFloat(uint Offset, float Float)
        {
            byte[] buffer = new byte[4];
            BitConverter.GetBytes(Float).CopyTo(buffer, 0);
            Array.Reverse(buffer, 0, 4);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offset, buffer);
        }

        private static void WriteFloatArray(uint Offset, float[] Array)
        {
            byte[] buffer = new byte[Array.Length * 4];
            for (int Lenght = 0; Lenght < Array.Length; Lenght++)
            {
                ReverseBytes(BitConverter.GetBytes(Array[Lenght])).CopyTo(buffer, Lenght * 4);
            }
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offset, buffer);
        }

        private static void WriteUInt(uint Offset, int Value)
        {
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(Offset, ReverseBytes(BitConverter.GetBytes(Value)));
        }

        #endregion

        #region RPC
        private static uint func_address = 0x0277208;

        private static void Enable()
        {
            byte[] Check = new byte[1];
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.GetMemory(func_address + 4, Check);
            if (Check[0] == 0x3F)
            {

            }
            else
            {
                byte[] PPC = new byte[] 
        {0x3F,0x80,0x10,0x05,0x81,0x9C,0,0x48,0x2C,0x0C,0,0,0x41,0x82,0,0x78,
         0x80,0x7C,0,0,0x80,0x9C,0,0x04,0x80,0xBC,0,0x08,0x80,0xDC,0,0x0C,0x80,
         0xFC,0,0x10,0x81,0x1C,0,0x14,0x81,0x3C,0,0x18,0x81,0x5C,0,0x1C,0x81,
         0x7C,0,0x20,0xC0,0x3C,0,0x24,0xC0,0x5C,0,0x28,0xC0,0x7C,0,0x2C,0xC0,
         0x9C,0,0x30,0xC0,0xBC,0,0x34,0xC0,0xDC,0,0x38,0xC0,0xFC,0,0x3C,0xC1,
         0x1C,0,0x40,0xC1,0x3C,0,0x44,0x7D,0x89,0x03,0xA6,0x4E,0x80,0x04,0x21,
         0x38,0x80,0,0,0x90,0x9C,0,0x48,0x90,0x7C,0,0x4C,0xD0,0x3C,0,0x50,0x48,0,0,0x14};
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(func_address, new byte[] { 0x41 });
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(func_address + 4, PPC);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(func_address, new byte[] { 0x40 });
            }
        }

        private static int Call(uint address, params object[] parameters)
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
                    WriteUInt(0x10050000 + (count * 4), (int)parameters[index]);
                    count++;
                }
                else if (parameters[index] is uint)
                {
                    WriteUInt(0x10050000 + (count * 4), (int)parameters[index]);
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
                        WriteUInt(0x10050000 + (count * 4), (int)pointer);
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
                        WriteUInt(0x10050000 + count * 4, (int)pointer);
                        count++;
                        Array += (uint)Args.Length;
                    }
                }
                index++;
            }
            WriteUInt(0x10050048, (int)address);
            Thread.Sleep(20);
            return ReadInt(0x1005004c);
        }
        #endregion

        #region Functions

        private static uint DPADOFFSET;
        private static bool DPADState = false;
        private static string DPAD_IsDown(uint Client)
        {
            if (DPADState == false)
            {
                DPADOFFSET = ((uint)ReadInt(0x17BB210)) + 0x21022;
                DPADState = true;
            }
            string KeyPressed;
            string Key = ReadString(DPADOFFSET + (Client * 0x68B80));
            if (Key == "16")
            {
                KeyPressed = null;
            }
            else if (Key == "15")
            {
                KeyPressed = "Up";
            }
            else if (Key == "17")
            {
                KeyPressed = "Down";
            }
            else if (Key == "19")
            {
                KeyPressed = "Left";
            }
            else if (Key == "21")
            {
                KeyPressed = "Right";
            }
            else if (Key == "25")
            {
                KeyPressed = "X";
            }
            else
            {
                KeyPressed = Key;
            }
            return KeyPressed;
        }

        private static string GetNames(uint Client)
        {
            return ReadString(0x0110d60c + (Client * 0x3980));
        }

        private static string DeleteLetter(string Text, int Length)
        {
            char[] Letters = Text.ToCharArray();
            char[] OutPut = new char[Letters.Length - Length];
            for (int i = 0; i < Letters.Length - Length; i++)
            {
                OutPut[i] = Letters[i];
            }
            return new string(OutPut);
        }

        private static string NameOnly11Letters(string Name)
        {
            if (Name.Length < 11)
            {
                return Name;
            }
            else
            {
                int Length = Name.Length - 11;
                return DeleteLetter(Name, Length);
            }
        }

        private static byte[] ReverseBytes(byte[] inArray)
        {
            Array.Reverse(inArray);
            return inArray;
        }

        private static void iPrintlnBold(int Client, string Text)
        {
            Call(0x228FA8, Client, 0, "c \"" + Text + "\"");
        }

        private static void DestroyElem(uint Index)
        {
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(0xF0E10C + (Index * 0xB4), new byte[0xB4]);
        }

        private static decimal GetGameMode()
        {
            decimal Shader = 0;
            string GM = null;
            byte[] buffer = new byte[0x100];
            if (buffer[10] == 0)
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.GetMemory(0x8360D5, buffer);
            System.Text.ASCIIEncoding Encoding = new System.Text.ASCIIEncoding();
            if (buffer[0] == 0)
            {

            }
            else
            {
                GM = Encoding.GetString(buffer).Split(new char[] { Convert.ToChar(0x5C) })[2];
            }
            if (GM == "dm")
                Shader = 51;
            else if (GM == "war")
                Shader = 52;
            else if (GM == "sd")
                Shader = 64;
            else if (GM == "sab")
                Shader = 60;
            else if (GM == "dom")
                Shader = 64;
            else if (GM == "koth")
                Shader = 56;
            else if (GM == "ctf")
                Shader = 52;
            else if (GM == "dd")
                Shader = 63;
            else if (GM == "conf")
                Shader = 53;
            else if (GM == "tdef")
                Shader = 53;
            else if (GM == "grnd")
                Shader = 55;
            else if (GM == "tjugg")
                Shader = 52;
            else if (GM == "jugg")
                Shader = 53;
            else if (GM == "gun")
                Shader = 51;
            else if (GM == "infect")
                Shader = 52;
            else if (GM == "oic")
                Shader = 51;
            return Shader;
        }

        private static void StoreHUD(bool State, uint P1 = 0, uint P2 = 0)
        {
            if (State == true)
            {
                Player1 = GetNames(P1);
                Player2 = GetNames(P2);
                StoreText(CreditsIndex, HElems.AllClient, "^:by GMT xCSBKx", 3, 1.3f, 601, 226);//Credits
                StoreText(MoveIndex, HElems.AllClient, "^:Move:[{+actionslot 1}] [{+actionslot 2}] [{+actionslot 3}] [{+actionslot 4}]", 3, 1.3f, 601, 207);//Move
                StoreText(SelectIndex, HElems.AllClient, "^:Select:", 3, 1.3f, 601, 188);//Select
                StoreText(Player2Index, HElems.AllClient, "^1^77	demo_stop" + "^:" + NameOnly11Letters(Player2), 3, 1.3f, 597, 169);//Player2
                StoreText(Player1Index, HElems.AllClient, "^2^77	demo_stop" + "^:" + NameOnly11Letters(Player1), 3, 1.3f, 597, 150);//Player1
                StoreText(TITELIndex, HElems.AllClient, "^:Tic Tac Toe:", 3, 1.3f, 601, 131);//TITEL
                StoreIcon(AIndex, HElems.AllClient, 1, 30, 30, 597, 26, 190, 190, 190, 255);//A
                StoreIcon(BIndex, HElems.AllClient, 1, 30, 30, 632, 26, 190, 190, 190, 255);//B
                StoreIcon(CIndex, HElems.AllClient, 1, 30, 30, 667, 26, 190, 190, 190, 255);//C
                StoreIcon(DIndex, HElems.AllClient, 1, 30, 30, 597, 61, 190, 190, 190, 255);//D
                StoreIcon(EIndex, HElems.AllClient, 1, 30, 30, 632, 61, 190, 190, 190, 255);//E
                StoreIcon(FIndex, HElems.AllClient, 1, 30, 30, 667, 61, 190, 190, 190, 255);//F
                StoreIcon(GIndex, HElems.AllClient, 1, 30, 30, 597, 95, 190, 190, 190, 255);//G
                StoreIcon(HIndex, HElems.AllClient, 1, 30, 30, 632, 95, 190, 190, 190, 255);//H
                StoreIcon(IIndex, HElems.AllClient, 1, 30, 30, 667, 95, 190, 190, 190, 255);//I
                StoreIcon(SCROLLERIndex, HElems.AllClient, GetGameMode(), 45, 45, 590, 18);//SCROLLER     
            }
            else
            {
                Player1 = "";
                Player2 = "";
                for (uint i = 500; i < 516; i++)
                    DestroyElem(i);
                for (int i = 1; i < 10; i++)
                    STATE[i] = false;
                for (int i = 1; i < 10; i++)
                {
                    PLAYER1[i] = false;
                    PLAYER2[i] = false;
                }
                Option = "A";
                GameEnd = false;
                DPADState = false;
            }
        }

        private static void ChangeField(uint State, uint Index)
        {
            if (STATE[State] == false)
            {
                if (Turn == Player1)
                {
                    STATE[State] = true;
                    PLAYER1[State] = true;
                    ChangeRGBA(Index, 0, 255, 0, 255);
                    Turn = Player2;
                    Typewriter(TypewriterIndex, (decimal)GetIndexfromName(Turn), "^:It's your turn!", 230);
                }
                else if (Turn == Player2)
                {
                    STATE[State] = true;
                    PLAYER2[State] = true;
                    ChangeRGBA(Index, 255, 0, 0, 255);
                    Turn = Player1;
                    Typewriter(TypewriterIndex, (decimal)GetIndexfromName(Turn), "^:It's your turn!", 230);
                }
            }
        }

        private static void CheckWin(uint Field1, uint Field2, uint Field3)
        {
            if (PLAYER1[Field1] == true && PLAYER1[Field2] == true && PLAYER1[Field3] == true)
            {
                Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player1) + " Wins!", 215);
                GameEnd = true;
                StoreHUD(false);
                TTTStatus = false;
                TTTThread.Abort();
            }
            else if (PLAYER2[Field1] == true && PLAYER2[Field2] == true && PLAYER2[Field3] == true)
            {
                Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player2) + " Wins!", 215);
                GameEnd = true;
                StoreHUD(false);
                TTTStatus = false;
                TTTThread.Abort();
            }
        }

        private static uint GetIndexfromName(string Name)
        {
            for (uint i = 0; i < 18; i++)
            {
                if (GetNames((uint)i) == Name)
                {
                    return (uint)i;
                }
            }
            return 18;
        }

        private static void StartTTT(uint P1, uint P2)
        {
            StoreHUD(false);
            StoreHUD(true, P1, P2);
            iPrintlnBold(-1, "^: TicTacToe Match : " + Player1 + " vs " + Player2);

            Random Random = new Random();
            switch (Random.Next(1, 3))
            {
                case 1:
                    Turn = Player1;
                    break;
                case 2:
                    Turn = Player2;
                    break;
            }
            Typewriter(TypewriterIndex, (decimal)GetIndexfromName(Turn), "^:It's your turn!", 230);
        }

        private static void TTTFunction()
        {
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.ConnectTarget();
            while (TTTThread.IsAlive)
            {
                switch (Option)
                {
                    #region A
                    case "A":
                        switch (DPAD_IsDown(GetIndexfromName(Turn)))
                        {
                            case "Right":
                                Scroller(2);
                                Option = "B";
                                break;

                            case "Down":
                                Scroller(4);
                                Option = "D";
                                break;

                            case "X":
                                ChangeField(1, AIndex);
                                break;
                        }
                        break;
                    #endregion
                    #region B
                    case "B":
                        switch (DPAD_IsDown(GetIndexfromName(Turn)))
                        {
                            case "Left":
                                Scroller(1);
                                Option = "A";
                                break;

                            case "Right":
                                Scroller(3);
                                Option = "C";
                                break;

                            case "Down":
                                Scroller(5);
                                Option = "E";
                                break;

                            case "X":
                                ChangeField(2, BIndex);
                                break;
                        }
                        break;
                    #endregion
                    #region C
                    case "C":
                        switch (DPAD_IsDown(GetIndexfromName(Turn)))
                        {
                            case "Left":
                                Scroller(2);
                                Option = "B";
                                break;

                            case "Down":
                                Scroller(6);
                                Option = "F";
                                break;

                            case "X":
                                ChangeField(3, CIndex);
                                break;
                        }
                        break;
                    #endregion
                    #region D
                    case "D":
                        switch (DPAD_IsDown(GetIndexfromName(Turn)))
                        {
                            case "Up":
                                Scroller(1);
                                Option = "A";
                                break;

                            case "Right":
                                Scroller(5);
                                Option = "E";
                                break;

                            case "Down":
                                Scroller(7);
                                Option = "G";
                                break;

                            case "X":
                                ChangeField(4, DIndex);
                                break;
                        }
                        break;
                    #endregion
                    #region E
                    case "E":
                        switch (DPAD_IsDown(GetIndexfromName(Turn)))
                        {
                            case "Up":
                                Scroller(2);
                                Option = "B";
                                break;

                            case "Left":
                                Scroller(4);
                                Option = "D";
                                break;

                            case "Right":
                                Scroller(6);
                                Option = "F";
                                break;

                            case "Down":
                                Scroller(8);
                                Option = "H";
                                break;

                            case "X":
                                ChangeField(5, EIndex);
                                break;
                        }
                        break;
                    #endregion
                    #region F
                    case "F":
                        switch (DPAD_IsDown(GetIndexfromName(Turn)))
                        {
                            case "Up":
                                Scroller(3);
                                Option = "C";
                                break;

                            case "Left":
                                Scroller(5);
                                Option = "E";
                                break;

                            case "Down":
                                Scroller(9);
                                Option = "I";
                                break;

                            case "X":
                                ChangeField(6, FIndex);
                                break;
                        }
                        break;
                    #endregion
                    #region G
                    case "G":
                        switch (DPAD_IsDown(GetIndexfromName(Turn)))
                        {
                            case "Up":
                                Scroller(4);
                                Option = "D";
                                break;

                            case "Right":
                                Scroller(8);
                                Option = "H";
                                break;

                            case "X":
                                ChangeField(7, GIndex);
                                break;
                        }
                        break;
                    #endregion
                    #region H
                    case "H":
                        switch (DPAD_IsDown(GetIndexfromName(Turn)))
                        {
                            case "Up":
                                Scroller(5);
                                Option = "E";
                                break;

                            case "Left":
                                Scroller(7);
                                Option = "G";
                                break;

                            case "Right":
                                Scroller(9);
                                Option = "I";
                                break;

                            case "X":
                                ChangeField(8, HIndex);
                                break;
                        }
                        break;
                    #endregion
                    #region I
                    case "I":
                        switch (DPAD_IsDown(GetIndexfromName(Turn)))
                        {
                            case "Up":
                                Scroller(6);
                                Option = "F";
                                break;

                            case "Left":
                                Scroller(8);
                                Option = "H";
                                break;

                            case "X":
                                ChangeField(9, IIndex);
                                break;
                        }
                        break;
                    #endregion
                }
                #region CheckGame
                if (GameEnd == false)
                {
                    #region ABC
                    if (PLAYER1[1] == true && PLAYER1[2] == true && PLAYER1[3] == true)
                    {
                        Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player1) + " Wins!", 215);
                        GameEnd = true;
                        StoreHUD(false);
                        TTTStatus = false;
                        TTTThread.Abort();
                    }
                    else if (PLAYER2[1] == true && PLAYER2[2] == true && PLAYER2[3] == true)
                    {
                        Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player2) + " Wins!", 215);
                        GameEnd = true;
                        StoreHUD(false);
                        TTTStatus = false;
                        TTTThread.Abort();
                    }
                    #endregion
                    #region DEF
                    else if (PLAYER1[4] == true && PLAYER1[5] == true && PLAYER1[6] == true)
                    {
                        Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player1) + " Wins!", 215);
                        GameEnd = true;
                        StoreHUD(false);
                        TTTStatus = false;
                        TTTThread.Abort();
                    }
                    else if (PLAYER2[4] == true && PLAYER2[5] == true && PLAYER2[6] == true)
                    {
                        Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player2) + " Wins!", 215);
                        GameEnd = true;
                        StoreHUD(false);
                        TTTStatus = false;
                        TTTThread.Abort();
                    }
                    #endregion
                    #region GHI
                    else if (PLAYER1[7] == true && PLAYER1[8] == true && PLAYER1[9] == true)
                    {
                        Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player1) + " Wins!", 215);
                        GameEnd = true;
                        StoreHUD(false);
                        TTTStatus = false;
                        TTTThread.Abort();
                    }
                    else if (PLAYER2[7] == true && PLAYER2[8] == true && PLAYER2[9] == true)
                    {
                        Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player2) + " Wins!", 215);
                        GameEnd = true;
                        StoreHUD(false);
                        TTTStatus = false;
                        TTTThread.Abort();
                    }
                    #endregion
                    #region ADG
                    else if (PLAYER1[1] == true && PLAYER1[4] == true && PLAYER1[7] == true)
                    {
                        Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player1) + " Wins!", 215);
                        GameEnd = true;
                        StoreHUD(false);
                        TTTStatus = false;
                        TTTThread.Abort();
                    }
                    else if (PLAYER2[1] == true && PLAYER2[4] == true && PLAYER2[7] == true)
                    {
                        Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player2) + " Wins!", 215);
                        GameEnd = true;
                        StoreHUD(false);
                        TTTStatus = false;
                        TTTThread.Abort();
                    }
                    #endregion
                    #region BEH
                    else if (PLAYER1[2] == true && PLAYER1[5] == true && PLAYER1[8] == true)
                    {
                        Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player1) + " Wins!", 215);
                        GameEnd = true;
                        StoreHUD(false);
                        TTTStatus = false;
                        TTTThread.Abort();
                    }
                    else if (PLAYER2[2] == true && PLAYER2[5] == true && PLAYER2[8] == true)
                    {
                        Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player2) + " Wins!", 215);
                        GameEnd = true;
                        StoreHUD(false);
                        TTTStatus = false;
                        TTTThread.Abort();
                    }
                    #endregion
                    #region CFI
                    else if (PLAYER1[3] == true && PLAYER1[6] == true && PLAYER1[9] == true)
                    {
                        Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player1) + " Wins!", 215);
                        GameEnd = true;
                        StoreHUD(false);
                        TTTStatus = false;
                        TTTThread.Abort();
                    }
                    else if (PLAYER2[3] == true && PLAYER2[6] == true && PLAYER2[9] == true)
                    {
                        Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player2) + " Wins!", 215);
                        GameEnd = true;
                        StoreHUD(false);
                        TTTStatus = false;
                        TTTThread.Abort();
                    }
                    #endregion
                    #region AEI
                    else if (PLAYER1[1] == true && PLAYER1[5] == true && PLAYER1[9] == true)
                    {
                        Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player1) + " Wins!", 215);
                        GameEnd = true;
                        StoreHUD(false);
                        TTTStatus = false;
                        TTTThread.Abort();
                    }
                    else if (PLAYER2[1] == true && PLAYER2[5] == true && PLAYER2[9] == true)
                    {
                        Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player2) + " Wins!", 215);
                        GameEnd = true;
                        StoreHUD(false);
                        TTTStatus = false;
                        TTTThread.Abort();
                    }
                    #endregion
                    #region CEG
                    else if (PLAYER1[3] == true && PLAYER1[5] == true && PLAYER1[7] == true)
                    {
                        Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player1) + " Wins!", 215);
                        GameEnd = true;
                        StoreHUD(false);
                        TTTStatus = false;
                        TTTThread.Abort();
                    }
                    else if (PLAYER2[3] == true && PLAYER2[5] == true && PLAYER2[7] == true)
                    {
                        Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player2) + " Wins!", 215);
                        GameEnd = true;
                        StoreHUD(false);
                        TTTStatus = false;
                        TTTThread.Abort();
                    }
                    #endregion
                    #region IFALLCHECKED
                    else if (STATE[1] == true && STATE[2] == true && STATE[3] == true && STATE[4] == true && STATE[5] == true && STATE[6] == true && STATE[7] == true && STATE[8] == true && STATE[9] == true)
                    {
                        #region ABC
                        if (PLAYER1[1] == true && PLAYER1[2] == true && PLAYER1[3] == true)
                        {
                            Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player1) + " Wins!", 215);
                            GameEnd = true;
                            StoreHUD(false);
                            TTTStatus = false;
                            TTTThread.Abort();
                        }
                        else if (PLAYER2[1] == true && PLAYER2[2] == true && PLAYER2[3] == true)
                        {
                            Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player2) + " Wins!", 215);
                            GameEnd = true;
                            StoreHUD(false);
                            TTTStatus = false;
                            TTTThread.Abort();
                        }
                        #endregion
                        #region DEF
                        else if (PLAYER1[4] == true && PLAYER1[5] == true && PLAYER1[6] == true)
                        {
                            Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player1) + " Wins!", 215);
                            GameEnd = true;
                            StoreHUD(false);
                            TTTStatus = false;
                            TTTThread.Abort();
                        }
                        else if (PLAYER2[4] == true && PLAYER2[5] == true && PLAYER2[6] == true)
                        {
                            Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player2) + " Wins!", 215);
                            GameEnd = true;
                            StoreHUD(false);
                            TTTStatus = false;
                            TTTThread.Abort();
                        }
                        #endregion
                        #region GHI
                        else if (PLAYER1[7] == true && PLAYER1[8] == true && PLAYER1[9] == true)
                        {
                            Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player1) + " Wins!", 215);
                            GameEnd = true;
                            StoreHUD(false);
                            TTTStatus = false;
                            TTTThread.Abort();
                        }
                        else if (PLAYER2[7] == true && PLAYER2[8] == true && PLAYER2[9] == true)
                        {
                            Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player2) + " Wins!", 215);
                            GameEnd = true;
                            StoreHUD(false);
                            TTTStatus = false;
                            TTTThread.Abort();
                        }
                        #endregion
                        #region ADG
                        else if (PLAYER1[1] == true && PLAYER1[4] == true && PLAYER1[7] == true)
                        {
                            Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player1) + " Wins!", 215);
                            GameEnd = true;
                            StoreHUD(false);
                            TTTStatus = false;
                            TTTThread.Abort();
                        }
                        else if (PLAYER2[1] == true && PLAYER2[4] == true && PLAYER2[7] == true)
                        {
                            Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player2) + " Wins!", 215);
                            GameEnd = true;
                            StoreHUD(false);
                            TTTStatus = false;
                            TTTThread.Abort();
                        }
                        #endregion
                        #region BEH
                        else if (PLAYER1[2] == true && PLAYER1[5] == true && PLAYER1[8] == true)
                        {
                            Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player1) + " Wins!", 215);
                            GameEnd = true;
                            StoreHUD(false);
                            TTTStatus = false;
                            TTTThread.Abort();
                        }
                        else if (PLAYER2[2] == true && PLAYER2[5] == true && PLAYER2[8] == true)
                        {
                            Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player2) + " Wins!", 215);
                            GameEnd = true;
                            StoreHUD(false);
                            TTTStatus = false;
                            TTTThread.Abort();
                        }
                        #endregion
                        #region CFI
                        else if (PLAYER1[3] == true && PLAYER1[6] == true && PLAYER1[9] == true)
                        {
                            Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player1) + " Wins!", 215);
                            GameEnd = true;
                            StoreHUD(false);
                            TTTStatus = false;
                            TTTThread.Abort();
                        }
                        else if (PLAYER2[3] == true && PLAYER2[6] == true && PLAYER2[9] == true)
                        {
                            Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player2) + " Wins!", 215);
                            GameEnd = true;
                            StoreHUD(false);
                            TTTStatus = false;
                            TTTThread.Abort();
                        }
                        #endregion
                        #region AEI
                        else if (PLAYER1[1] == true && PLAYER1[5] == true && PLAYER1[9] == true)
                        {
                            Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player1) + " Wins!", 215);
                            GameEnd = true;
                            StoreHUD(false);
                            TTTStatus = false;
                            TTTThread.Abort();
                        }
                        else if (PLAYER2[1] == true && PLAYER2[5] == true && PLAYER2[9] == true)
                        {
                            Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player2) + " Wins!", 215);
                            GameEnd = true;
                            StoreHUD(false);
                            TTTStatus = false;
                            TTTThread.Abort();
                        }
                        #endregion
                        #region CEG
                        else if (PLAYER1[3] == true && PLAYER1[5] == true && PLAYER1[7] == true)
                        {
                            Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player1) + " Wins!", 215);
                            GameEnd = true;
                            StoreHUD(false);
                            TTTStatus = false;
                            TTTThread.Abort();
                        }
                        else if (PLAYER2[3] == true && PLAYER2[5] == true && PLAYER2[7] == true)
                        {
                            Typewriter(TypewriterIndex, HElems.AllClient, "^:" + NameOnly11Letters(Player2) + " Wins!", 215);
                            GameEnd = true;
                            StoreHUD(false);
                            TTTStatus = false;
                            TTTThread.Abort();
                        }
                        #endregion
                        #region NoOne
                        else
                        {
                            Typewriter(TypewriterIndex, HElems.AllClient, "^:The Game is a Draw!", 195);
                            GameEnd = true;
                            StoreHUD(false);
                            TTTStatus = false;
                            TTTThread.Abort();
                        }
                        #endregion
                    }
                    #endregion
                }
                #endregion
            }
        }
        #endregion

        #region HUDS
        public static class HElems
        {
            public static uint
                xOffset = 0x04,
                yOffset = 0x08,
                        fontScale = 0x14,
                        fontOffset = 0x24,
                        alignOrg = 0x28,
                        alignOffset = 0x2C,
                        colorOffset = 0x30,
                        widthOffset = 0x44,
                heightOffset = 0x48,
                        shaderOffset = 0x4C,
                        fromX = 0x60,
                fromY = 0x64,
                         fromAlignOrg = 0x68,
                fromAlignScreen = 0x6C,
                moveStartTime = 0x70,
                 moveTime = 0x74,
                time = 0x78,
                        textOffset = 0x84,
                        glowColor = 0x8C,
                        fxBirthTime = 0x90,
                fxLetterTime = 0x94,
                fxDecayStartTime = 0x98,
                fxDecayDuration = 0x9C,
                        clientOffset = 0xa8,
                        AllClient = 0x7FF;
        }

       public static uint Element(uint Index)
        {
            return 0xF0E10C + ((Index) * 0xB4);
        }

        public static uint StoreText(uint Index, decimal Client, string Text, int Font, float FontScale, int X, int Y, decimal R = 255, decimal G = 255, decimal B = 255, decimal A = 255, decimal R1 = 0, decimal G1 = 0, decimal B1 = 0, decimal A1 = 0)
        {
            uint elem = Element(Index);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.textOffset, CacheString(Text));
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.fontOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(Font))));
            WriteFloat(elem + HElems.fontScale, FontScale);
            WriteFloat(elem + HElems.xOffset, X);
            WriteFloat(elem + HElems.yOffset, Y);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + 0xa7, new byte[] { 7 });
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.colorOffset, new byte[] { (byte)R, (byte)G, (byte)B, (byte)A });
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.glowColor, new byte[] { (byte)R1, (byte)G1, (byte)B1, (byte)A1 });
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.clientOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(Client))));
            System.Threading.Thread.Sleep(20);
            byte[] Type_ = BitConverter.GetBytes(1);
            Array.Reverse(Type_);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem, Type_);
            return elem;
        }

        public static uint StoreIcon(uint Index, decimal Client, decimal Shader, int Width, int Height, int X, int Y, decimal R = 255, decimal G = 255, decimal B = 255, decimal A = 255)
        {
            uint elem = Element(Index);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.shaderOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(Shader))));
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.heightOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(Height))));
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.widthOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(Width))));
            WriteFloat(elem + HElems.xOffset, X);
            WriteFloat(elem + HElems.yOffset, Y);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + 0xa7, new byte[] { 5 });
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.colorOffset, new byte[] { (byte)R, (byte)G, (byte)B, (byte)A });
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.clientOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(Client))));
            System.Threading.Thread.Sleep(20);
            byte[] Type_ = BitConverter.GetBytes(4);
            Array.Reverse(Type_);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem, Type_);
            return elem;
        }

        public static void Typewriter(uint Index, decimal Client, string Text, int X = 180, bool UnderHUD = false, decimal R = 255, decimal G = 255, decimal B = 255, decimal A = 255, decimal R1 = 0, decimal G1 = 0, decimal B1 = 0, decimal A1 = 0)
        {
            uint elem = Element(Index);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.textOffset, CacheString(Text));
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.fontOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(3))));
            WriteFloat(elem + HElems.fontScale, 2);
            WriteFloat(elem + HElems.xOffset, X);
            WriteFloat(elem + HElems.yOffset, 300);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + 0xa7, new byte[] { 7 });
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.colorOffset, new byte[] { (byte)R, (byte)G, (byte)B, (byte)A });
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.glowColor, new byte[] { (byte)R1, (byte)G1, (byte)B1, (byte)A1 });
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.clientOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(Client))));
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.fxBirthTime, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(GetLevelTime()))));
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.fxLetterTime, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(100))));
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.fxDecayStartTime, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(5000))));
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.fxDecayDuration, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(1000))));
            System.Threading.Thread.Sleep(20);
            byte[] Type_ = BitConverter.GetBytes(1);
            Array.Reverse(Type_);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem, Type_);
        }

        public static uint CreateText(string Text)
        {
            return (uint)Call(0x1BE6CC, Text);
        }

        public static uint GetLevelTime()
        {
            return (uint)ReadInt(0xFC3DB0);
        }

        private static byte[] uintBytes(uint Input)
        {
            byte[] Data = BitConverter.GetBytes(Input);
            Array.Reverse(Data);
            return Data;
        }

        private static byte[] CacheString(string Text)
        {
            byte[] Index = uintBytes(CreateText(Text + "\0"));
            return Index;
        }

        public static void ChangeRGBA(uint Index, decimal R = 255, decimal G = 255, decimal B = 255, decimal A = 255)
        {
            uint elem = Element(Index);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.colorOffset, new byte[] { (byte)R, (byte)G, (byte)B, (byte)A });
        }

        public static void MoveOverTime(uint Index, short Time, int X, int Y)
        {
            uint elem = 0xF0E10C + (Index * 0xB4);
            WriteFloatArray(elem + HElems.fromAlignOrg, ReadFloatLength(elem + HElems.alignOrg, 4));
            WriteFloatArray(elem + HElems.fromAlignScreen, ReadFloatLength(elem + HElems.alignOffset, 4));
            WriteFloatArray(elem + HElems.fromY, ReadFloatLength(elem + HElems.yOffset, 4));
            WriteFloatArray(elem + HElems.fromX, ReadFloatLength(elem + HElems.xOffset, 4));
            WriteUInt(elem + HElems.moveStartTime, (Int32)GetLevelTime());
            WriteUInt(elem + HElems.moveTime, Time);
            WriteFloat(elem + HElems.xOffset, X);
            WriteFloat(elem + HElems.yOffset, Y);
        }

       public static void Scroller(int Option)
        {
            if (Option == 1)
            {
                MoveOverTime(SCROLLERIndex, 100, 590, 18);
            }
            else if (Option == 2)
            {
                MoveOverTime(SCROLLERIndex, 100, 625, 18);
            }
            else if (Option == 3)
            {
                MoveOverTime(SCROLLERIndex, 100, 660, 18);
            }
            else if (Option == 4)
            {
                MoveOverTime(SCROLLERIndex, 100, 590, 53);
            }
            else if (Option == 5)
            {
                MoveOverTime(SCROLLERIndex, 100, 625, 53);
            }
            else if (Option == 6)
            {
                MoveOverTime(SCROLLERIndex, 100, 660, 53);
            }
            else if (Option == 7)
            {
                MoveOverTime(SCROLLERIndex, 100, 590, 88);
            }
            else if (Option == 8)
            {
                MoveOverTime(SCROLLERIndex, 100, 625, 88);
            }
            else if (Option == 9)
            {
                MoveOverTime(SCROLLERIndex, 100, 660, 88);
            }
        }
        #endregion

        public static void Start(uint P1 = 0, uint P2 = 0)
        {
            Enable();
            StartTTT(P1, P2);
            ThreadStart Start = null;
            if (!TTTStatus)
            {
                Thread.Sleep(100);
                TTTStatus = true;
                if (Start == null)
                {
                    Start = () => TTTFunction();
                }
                TTTThread = new Thread(Start);
                TTTThread.IsBackground = true;
                TTTThread.Start();
            }
            else
            {
                TTTStatus = false;
                TTTThread.Abort();
            }
        }

        public static void Stop(string Message = "^:The game was stopped!")
        {
            if (Message != null)
                Typewriter(TypewriterIndex, HElems.AllClient, Message, 195);
            GameEnd = true;
            StoreHUD(false);
            TTTStatus = false;
            if (TTTThread != null)
                TTTThread.Abort();
        }
    }

