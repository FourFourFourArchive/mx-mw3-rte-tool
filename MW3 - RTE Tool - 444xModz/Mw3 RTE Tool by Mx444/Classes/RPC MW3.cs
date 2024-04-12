using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS3Lib;
using Call_Of_Duty_Multi_Tool_1._0._0;
using System.Threading;
    class RPC_MW3
    {

                #region Huds


        public static int Call(uint address, params object[] parameters)
        {
            int length = parameters.Length;
            int index = 0;
            uint num3 = 0;
            uint num4 = 0;
            uint num5 = 0;
            uint num6 = 0;
            while (index < length)
            {
                if (parameters[index] is int)
                {
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.Extension.WriteInt32(0x10050000 + (num3 * 4), (int)parameters[index]);
                    num3++;
                }
                else if (parameters[index] is uint)
                {
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.Extension.WriteUInt32(0x10050000 + (num3 * 4), (uint)parameters[index]);
                    num3++;
                }
                else if (parameters[index] is short)
                {
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.Extension.WriteInt16(0x10050000 + (num3 * 4), (short)parameters[index]);
                    num3++;
                }
                else if (parameters[index] is ushort)
                {
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.Extension.WriteUInt16(0x10050000 + (num3 * 4), (ushort)parameters[index]);
                    num3++;
                }
                else if (parameters[index] is byte)
                {
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.Extension.WriteByte(0x10050000 + (num3 * 4), (byte)parameters[index]);
                    num3++;
                }
                else
                {
                    uint num7;
                    if (parameters[index] is string)
                    {
                        num7 = 0x10052000 + (num4 * 0x400);
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.Extension.WriteString(num7, Convert.ToString(parameters[index]));
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.Extension.WriteUInt32(0x10050000 + (num3 * 4), num7);
                        num3++;
                        num4++;
                    }
                    else if (parameters[index] is float)
                    {
                        WriteSingle(0x10050024 + (num5 * 4), (float)parameters[index]);
                        num5++;
                    }
                    else if (parameters[index] is float[])
                    {
                        float[] input = (float[])parameters[index];
                        num7 = 0x10051000 + (num6 * 4);
                        WriteSingle(num7, input);
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.Extension.WriteUInt32(0x10050000 + (num3 * 4), num7);
                        num3++;
                        num6 += (uint)input.Length;
                    }
                }
                index++;
            }
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.Extension.WriteUInt32(0x10050048, address);
            Thread.Sleep(20);
            return Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.Extension.ReadInt32(0x1005004c);
        }
        private static void WriteSingle(uint address, float input)
        {
            byte[] array = new byte[4];
            BitConverter.GetBytes(input).CopyTo(array, 0);
            Array.Reverse(array, 0, 4);
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(address, array);
        }

        private static void WriteSingle(uint address, float[] input)
        {
            int length = input.Length;
            byte[] array = new byte[length * 4];
            for (int i = 0; i < length; i++)
            {
                ReverseBytes(BitConverter.GetBytes(input[i])).CopyTo(array, (int)(i * 4));
            }
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(address, array);
        }
       
#endregion
                #region RPC


        public static uint func_address = 0x0277208;

        public static void EnablePPC()
        {
            byte[] Check = new byte[1];
            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.GetMemory(func_address + 4, Check);
            if (Check[0] == 0x3F)
            {

            }
            else
            {
                byte[] PPC = new byte[] 
        
                {
                    0x3F,0x80,0x10,0x05,0x81,0x9C,0,0x48,0x2C,0x0C,0,  0,0x41,0x82,0,0x78,
         0x80,0x7C,0,0,0x80,0x9C,0,0x04,0x80,0xBC,0,0x08,0x80,0xDC,0,0x0C,0x80,
         0xFC,0,0x10,0x81,0x1C,0,0x14,0x81,0x3C,0,0x18,0x81  ,0x5C,0,0x1C,0x81,
         0x7C,0,0x20,0xC0,0x3C,0,0x24,0xC0,0x5C,0,0x28,0xC0  ,0x7C,0,0x2C,0xC0,
         0x9C,0,0x30,0xC0,0xBC,0,0x34,0xC0,0xDC,0,0x38,0xC0  ,0xFC,0,0x3C,0xC1,
         0x1C,0,0x40,0xC1,0x3C,0,0x44,0x7D,0x89,0x03,0xA6,0x4E,0x80,0x04,0x21,
         0x38,0x80,0,0,0x90,0x9C,0,0x48,0x90,0x7C,0,0x4C,0xD0,0x3C,0,0x50,0x48,0,0,0x14};
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(func_address, new byte[] { 0x41 });
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(func_address + 4, PPC);
                Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(func_address, new byte[] { 0x40 });
            }
        }

        public static void EnableRPC()
                {

                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(0x523B10, new byte[2175]);
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(0x18BE6C, new byte[] { 0x60, 0x00, 0x00, 0x00 });
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(0x3BC9CC, new byte[] { 0x60, 0x00, 0x00, 0x00 });
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(0x18BE74, new byte[] { 0x48, 0x00, 0x00, 0x68 });
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(0x1DB1244, new byte[4]);
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(0x114AE64, new byte[4]);
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(0x3BC9E4, new byte[] { 0x41, 0x82, 0x02, 0x20, 0x3D, 0x00, 0x00, 0x52, 0x80, 0x68, 0x3B, 0x10, 0x80, 0x88, 0x3B, 0x14, 0x80, 0xA8, 0x3B, 0x18, 0x80, 0xC8, 0x3B, 0x1C, 0x80, 0xE8, 0x3B, 0x20, 0x39, 0x00, 0x00, 0x00, 0x48, 0x00, 0x00, 0x1D, 0x3C, 0x80, 0x01, 0x15, 0x90, 0x64, 0xAE, 0x64, 0x38, 0x80, 0x00, 0x00, 0x3C, 0x60, 0x01, 0xDB, 0x90, 0x83, 0x12, 0x44, 0x48, 0x00, 0x01, 0xE8, 0x4E, 0x80, 0x00, 0x20, 0x60, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x60, 0x00, 0x00, 0x00 });
                }
                public static void GetMemoryR(uint Address, ref byte[] Bytes)
                {
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.GetMemory(Address, Bytes);
                }
                public static uint str_pointer(string str)
                {
                    uint addr = 0x523B30;
                    byte[] check = new byte[1];
                    uint i;
                    for (i = 0; i < 5; i++)
                    {
                        GetMemoryR(addr, ref check);
                        if (check[0] == 0x00)
                            break;
                        if (i == 4)
                        {
                            i = 0; break;
                        }
                    }
                    addr = (0x523B30 + (i * 0x68));
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(addr, new byte[0x68]);
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(addr, Encoding.UTF8.GetBytes(str));
 
                    return addr;
                }
                public static void CallFunction(uint func_addr, uint param1 = 0, uint param2 = 0, uint param3 = 0, uint param4 = 0, uint param5 = 0)
                {
                    byte[] par1 = BitConverter.GetBytes(param1);
                    byte[] par2 = BitConverter.GetBytes(param2);
                    byte[] par3 = BitConverter.GetBytes(param3);
                    byte[] par4 = BitConverter.GetBytes(param4);
                    byte[] par5 = BitConverter.GetBytes(param5);
                    Array.Reverse(par1);
                    Array.Reverse(par2);
                    Array.Reverse(par3);
                    Array.Reverse(par4);
                    Array.Reverse(par5);
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(0x523B10, par1);
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(0x523B14, par2);
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(0x523B18, par3);
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(0x523B1C, par4);
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(0x523B20, par5);
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(0x3BCA04, MakeBl(0x3BCA04, func_addr));
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(0x1DB1244, new byte[] { 0x00, 0x00, 0x00, 0x01 });

                }
                public static uint GetFuncReturn()
                {
                    byte[] ret = new byte[4];
                    GetMemoryR(0x114AE64, ref ret);
                    Array.Reverse(ret);
                    return BitConverter.ToUInt32(ret, 0);
                }
            
                #endregion
                #region Cbuf_AddText
                public static void CBuf_AddText(int client, string command)
                {
                    CallFunction(Addresses.CBuf_AddText, (uint) client, str_pointer(command),0,0,0);
                }
                #endregion
                #region SV_GameSendServerCommand
                public static void SV_GameSendServerCommand(int client, string command)
                {
                    CallFunction(Addresses.SV_GameSendServerCommand, (uint)client, 0, str_pointer(command), 0, 0);
                }
                #endregion
                #region iPrintln
                public static void iPrintln(int client, string Text)
                {
                    SV_GameSendServerCommand(client, "f \"" + Text + "\"");
                    System.Threading.Thread.Sleep(20);
                }
                #endregion
                #region iPrintlnBold
                public static void iPrintlnBold(int client, string Text)
                {
                    SV_GameSendServerCommand(client, "c \"" + Text + "\"");
                    System.Threading.Thread.Sleep(20);
                }
                #endregion
                #region Set_ClientDvar
                public static void Set_ClientDvar(int client, string Text)
                {
                    SV_GameSendServerCommand(client, "q " + Text);
                    System.Threading.Thread.Sleep(20);
                }
                #endregion
                #region Fov
                public static void Fov(int client, string Text)
                {
                    SV_GameSendServerCommand(client, "q \"cg_fov \"" + Text + "\"");
                    System.Threading.Thread.Sleep(20);
                }
                #endregion

                public static void clonePlayer(int client)
                {
                    Call(0x180f48, new object[] { client << 0x10 });
                }
                
                #region Vision
                public static void Vision(int client, string Text)
                {
                    SV_GameSendServerCommand(client, "J \"" + Text + "\"");
                    System.Threading.Thread.Sleep(20);
                }
                #endregion
                #region KickWithError
                public static void Kick(int client, string Text)
                {
                    SV_GameSendServerCommand(client, "r \"" + Text + "\"");
                    System.Threading.Thread.Sleep(20);
                }
                #endregion
                #region Merda
                private uint HudElem_Alloc()
                {
                    byte[] buffer = new byte[1];
                    for (int i = 0; i < 0x400; i++)
                    {
                        uint addr = (uint)(0xf0e10c + (i * 180));
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.GetMemory(addr, buffer);
                        if (buffer[0] == 0)
                        {
                            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(addr, new byte[0xb1]);
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
                public uint createText(string text)
                {
                    CallFunction(0x1be6cc, str_pointer(text), 0, 0, 0, 0);
                    System.Threading.Thread.Sleep(10);
                    return GetFuncReturn();
                }
                public void spawnElem(int client, uint elemAddress)
                {
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elemAddress + 0xa8, this.ReverseBytesS(BitConverter.GetBytes(client)));
                }

               
                public void setText(uint elem, byte[] text, uint font, float x, float y, uint align, int r = 0xff, int g = 0xff, int b = 0xff, int a = 0xff)
                {
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem, new byte[180]);
                    byte[] val = new byte[4];
                    val[3] = 1;
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem, val);
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.textOffset, text);
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.relativeOffset, this.uintBytesS(5));
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory((elem + HElems.relativeOffset) - 4, this.uintBytesS(6));
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.fontOffset, this.uintBytesS(font));
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.alignOffset, this.uintBytesS(align));
                    byte[] buffer2 = new byte[2];
                    buffer2[0] = 0x40;
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory((elem + HElems.textOffset) + 4, buffer2);

                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.xOffset, this.ReverseBytesS(BitConverter.GetBytes(x)));
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.yOffset, this.ReverseBytesS(BitConverter.GetBytes(y)));
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.colorOffset, new byte[] { BitConverter.GetBytes(r)[0], BitConverter.GetBytes(g)[0], BitConverter.GetBytes(b)[0], BitConverter.GetBytes(a)[0] });
                }


                public class Huds
                {
                    public static PS3API PS3 = new PS3API();
                    public static void Typewriter(uint elemIndex, int client, string text, int font, float fontScale, int x, int y, uint align, int sort, int r, int g, int b, int a, int r1, int g1, int b1, int a1, int fxLetterTime, int fxDecayStartTime, int fxDecayDuration)
                    {
                        
                        uint elem = 0xF0E10C + ((elemIndex) * 0xB4);
                        byte[] ClientID = ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(client)));
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem, new byte[0xB4]);
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.textOffset, uintBytes(CreateText(text + "\0")));
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.relativeOffset, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x92, 0xFF, 0xFF, 0xFF, 0xFF });
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.relativeOffset - 4, new byte[] { 0x00, 0x00, 0x00, 0x05 });
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.fontOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(font))));
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.alignOffset, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(align))));
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.textOffset + 4, ReverseBytes(BitConverter.GetBytes(sort)));
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.fontSizeOffset, ToHexFloat(fontScale));
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.xOffset, ToHexFloat(x));
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.yOffset, ToHexFloat(y));
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + 0x88, new byte[] { 7 });
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + 0xa7, new byte[] { 69 });
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.colorOffset, RGBA(r, g, b, a));
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.GlowColor, RGBA(r1, g1, b1, a1));
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.clientOffset, ClientID);
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + 0x2b, new byte[] { 0x5 });
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + 0x88, new byte[] { 0x44 });
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + 0xA8, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(client))));

                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.fxBirthTime, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(GetClientTime(CheckHost())))));
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.fxLetterTime, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(fxLetterTime))));
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.fxDecayStartTime, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(fxDecayStartTime))));
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem + HElems.fxDecayDuration, ReverseBytes(BitConverter.GetBytes(Convert.ToInt32(fxDecayDuration))));
                        System.Threading.Thread.Sleep(2);
                    }


                    static int GetClientTime(uint clientIndex)
                    {

                        byte[] buffer = new byte[4];
                        Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.GetMemory(0x0110a280 + (clientIndex * 0x3980), buffer);
                        return BitConverter.ToInt32(ReverseBytes(buffer), 0);
                    }
                    public static void ActivateIndex(Boolean State, int index, int type)
                    {

                        uint elem = 0xF0E10C + ((uint)index * 0xB4);
                        byte[] Type_ = BitConverter.GetBytes(type);
                        Array.Reverse(Type_);
                        if (State == true)
                        {
                            Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem, Type_);
                        }
                        else
                        { Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.SetMemory(elem, new byte[] { 0x00, 0x00, 0x00, 0x00 }); }
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
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.GetMemory(0x01BBBC2C, buffer);
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
                    Call_Of_Duty_Multi_Tool_1._0._0.Form1.PS3.GetMemory(0x110a280 + (clientIndex * 0x3980) + 0x338C, nameb);
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
                
                    public static uint xOffset = 0x04, yOffset = 0x08, textOffset = 0x84, fontOffset = 0x24, fontSizeOffset = 0x14, colorOffset = 0x30, relativeOffset = 0x2c, widthOffset = 0x44, heightOffset = 0x48, shaderOffset = 0x4c, GlowColor = 0x8C, clientOffset = 0xA8, alignOffset = 0x2C, fxBirthTime = 0x90,              // 0x90-0x94 
                        fxLetterTime = 0x94, fxDecayStartTime = 0x98, fxDecayDuration = 0x9c;
                }
             

                #region GiveWeapon
                public static void GiveWeapon(int client, int weapon,int akimbo)
                {
                    CallFunction(Addresses.G_GivePlayerWeapon, (uint)G_ClientFunction(client), (uint)weapon, 0);
                    CallFunction(Addresses.Add_Ammo, (uint)(Addresses.G_Entity + (client * 0x280)), (uint)weapon, 0, 9999, 1);
                }
                #endregion
                #region G_ClientFunction
                public static uint G_ClientFunction(int client)
                {
                    return Addresses.G_Client + ((uint)client * 0x3980);
                }
                #endregion
                #region SetModel
                public static void SetModel(int client, string model)
                {
                    CallFunction(Addresses.G_SetModel, (uint)(Addresses.G_Entity + (client * 640)), str_pointer(model), 0, 0, 0);
                }
                #endregion
                #region Cmd_ExecuteSingleCommand
                public static void Cmd_ExecuteSingleCommand(uint client, string command)
                {
                    CallFunction(Addresses.Cmd_ExecuteSingleCommand, (uint)client, str_pointer(command), 0, 0, 0);
                }
                #endregion
            }
    #region Addresses
    public static class Addresses
    {
        public static uint
           G_Client = 0x110A280,
           g_client = 0x110A280,
           G_ClientIndex = 0x3980,
           EntityIndex = 0x280,
           G_Entity = 0xFCA280,
           MapBrushModel = 0x7F80,
           BG_GetPerkIndexForName = 0x210B0,
           BG_GetNumWeapons = 0x3CFBC,
           BG_FindWeaponIndexForName = 0x3CFD0,
           BG_GetWeaponIndexForName = 0x3D434,
           BG_GetViewModelWeaponIndex = 0x3D7D8,
           Cmd_ExecuteSingleCommand = 0x1DB240,
           BG_WeaponFireRecoil = 0x3FBD0,
           CG_FireWeapon = 0xBE498,
           Key_IsDown = 0xD1CD8,
           Key_StringToKeynum = 0xD1D18,
           Key_IsValidGamePadChar = 0xD1E64,
           Key_KeyNumToString = 0xD1EA4,
           Key_Unbind_f = 0xD2368,
           Key_Bind_f = 0xD247C,
           BG_TakePlayerWeapon = 0x1C409C,
           G_GivePlayerWeapon = 0x1C3034,
           SV_GameSendServerCommand = 0x228FA8,
           SV_GetConfigString = 0x22A4A8,
           SV_SetConfigString = 0x22A208,
           va = 0x299490,
           G_SetModel = 0x1BEF5C,
           G_LocalizedStringIndex = 0x1BE6CC,
           G_MaterialIndex = 0x1BE744,
           G_ModelIndex = 0x1BE7A8,
           G_ModelName = 0x1BE8A0,
           Add_Ammo = 0x18A29C,
           PlayerCmd_SetPerk = 0x17EBE8,
           G_Damage = 0x183E18,
           G_RadiusDamage = 0x185600,
           G_GetClientScore = 0x18EA74,
           G_GetClientDeaths = 0x18EA98,
           Cmd_AddCommandInternal = 0x1DC4FC,
           CBuf_AddText /*(int localClientNum, const char *text)*/ = 0x001DB240,
           SV_SendDisconnect /*(client_s *client, int state, const char *reason)*/ = 0x0022472C,
           SV_SendClientGameState /*(client_s *client)*/ = 0x002284F8,
           SV_KickClient /*(client_s *cl, char *playerName, int maxPlayerNameLen)*/ = 0x00223BD0,
           G_CallSpawnEntity /*(gentity_s *ent)*/ = 0x001BA730,
           Player_Die /*(unsigned int *self, unsigned int *inflictor, unsigned int *attacker, int damage, int meansOfDeath, int iWeapon, const float *vDir, unsigned int hitLoc, int psTimeOffset)*/  = 0x00183748,
           SV_DropClient /*(client_s *drop, const char *reason, bool tellThem)*/ = 0x002249FC,
           SV_SendServerCommand /*(client_s *,svscmd_type,char const *,...)*/ = 0x0022CEBC,
           Scr_Notify /*(gentity_s *ent, unsigned __int16 stringValue, unsigned int paramcount)*/ = 0x001BB1B0,
           Sv_SetGametype /*(void)*/ = 0x00229C1C,
           Sv_Maprestart /*(int fast_restart)*/ = 0x00223774,
           sv_maprestart_f = 0x00223B20,
           sv_spawnsever /*(const char *server)*/ = 0x0022ADF8,
           sv_map_f = 0x002235A0,
           sv_matchend /*(void)*/ = 0x0022F7A8,
           R_AddCmdDrawText /*(const char *text, int maxChars, void *font, float x, float y, float xScale, float yScale, float rotation, const float *color, int style)*/ = 0x00393640,
           R_RegisterFont /*(char* asset, int imagetrack)*/ /*(const char *name, int imageTrack)*/ = 0x003808B8,
           R_AddCmdDrawStretchPic /*(float x, float y, float w, float h, float xScale, float yScale, float xay, float yay, const float *color, int material)*/ = 0x00392D78,
           CL_DrawTextHook /*(const char *text, int maxChars, void *font, float x, float y, float xScale, float yScale, const float *color, int style)*/ = 0x000D93A8,
           R_AddCmdDrawTextWithEffects /*(char const *,int,Font_s *,float,float,float,float,float,float const * const,int,float const * const,Material *,Material *,int,int,int,int)*/ = 0x003937C0,
           CG_BoldGameMessage /*(int LocalClientNum, const char *Message)*/ = 0x0007A5C8,
           UI_FillRectPhysical /*(float x, float y, float width, float height, const float *color)*/ = 0x0023A810,
           UI_DrawLoadBar /*(ScreenPlacement *scrPlace, float x, float y, float w, float h, int horzAlign, int vertAlign, const float *color, Material *material)*/ = 0x0023A730,
           Scr_MakeGameMessage /*(int iClientNum, const char *pszCmd)*/ = 0x001B07F0,
           Scr_ConstructMessageString /*(int firstParmIndex, int lastParmIndex, const char *errorContext, char *string, unsigned int stringLimit)*/ = 0x001B04F4,
           R_NormalizedTextScale /*(Font_s *font, float scale)*/ = 0x003808F0,
           TeleportPlayer /*(gentity_s *player, float *origin, float *angles)*/ = 0x00191B00,
           CL_DrawText /*(ScreenPlacement *scrPlace, const char *text, int maxChars, Font_s *font, float x, float y, int horzAlign, int vertAlign, float xScale, float yScale, const float *color, int style)*/ = 0x000D9490,
           CL_DrawTextRotate /*(ScreenPlacement *scrPlace, const char *text, int maxChars, Font_s *font, float x, float y, float rotation, int horzAlign, int vertAlign, float xScale, float yScale, const float *color, int style)*/ = 0x000D9554,
           SV_GameDropClient /*(int clientNum, const char *reason)*/ = 0x00229020,
           Dvar_GetBool /*(const char *dvarName)*/ = 0x00291060,
           Dvar_GetInt /*(const char *dvarName)*/ = 0x002910DC,
           Dvar_GetFloat /*(const char *dvarName)*/ = 0x00291148,
           Dvar_RegisterBool /*(const char *dvarName, bool value, unsigned __int16 flags, const char *description)*/ = 0x002933F0,
           Dvar_IsValidName /*(const char *dvarName)*/ = 0x0029019C,
           Material_RegisterHandle /*(const char *name, int imageTrack)*/ = 0x0038B044,
           CL_RegisterFont /*(const char *fontName, int imageTrack)*/ = 0x000D9734,
           SetClientViewAngle /*(gentity_s *ent, const float *angle)*/ = 0x001767E0,
           R_RegisterDvars /*(void)*/ = 0x0037E420,
           PlayerCmd_SetClientDvar /*(scr_entref_t entref)*/ = 0x0017CB4C,
           Jump_RegisterDvars /*(void)*/ = 0x00018E20,
           AimTarget_RegisterDvars = 0x00012098,
           G_FreeEntity /*(gentity_s *ed)*/ = 0x001C0840,
           G_EntUnlink /*(gentity_s *ent)*/ = 0x001C4A5C,
           SV_DObjGetTree /*(gentity_s *ent)*/ = 0x00229A68,
           BG_GetEntityTypeName /*(const int eType)*/ = 0x0001D1F0,
           CL_GetClientState /*(int localClientNum, uiClientState_s *state)*/ = 0x000E26A8,
            CL_GetConfigString /*(int localClientNum, int configStringIndex)*/ = 0x000C5E7C,
           Info_ValueForKey /*(const char *s, const char *key)*/ = 0x00299604,
           Scr_GetInt /*(unsigned int index)*/ = 0x002201C4,
           ClientSpawn /*(gentity_s *ent, const float *spawn_origin, const float *spawn_angles)*/ = 0x00177468,
           Sv_ClientCommand /*(client_s *cl, msg_t *msg)*/ = 0x00228178,
           Sv_ExecuteClientMessage /*(client_s *cl, msg_t *msg)*/ = 0x00228B50,
           Sv_ExecuteClientCommand /*(client_s *cl, const char *s, int clientOK)*/ = 0x00182DEC,
           ClientCommand /*(int clientNum)*/ = 0x00182440,
           CalculateRanks /*(void)*/ = 0x0019031C,
           ClientScr_SetScore /*(gclient_s *pSelf, client_fields_s *pField)*/ = 0x00176150,
           ClientScr_SetMaxHealth /*(gclient_s *pSelf, client_fields_s *pField)*/ = 0x00176094,
           Sv_ReceiveStats /*(netadr_t from, msg_t *msg)*/ = 0x002244E0,
           ClientConnect /*(int clientNum, unsigned __int16 scriptPersId)*/ = 0x001771A0,
           Sv_DirectConnect /*(netadr_t from)*/ = 0x00255BB4,
           Sv_SetConfigstring /*(int index, const char *val)*/ = 0x0022A208,
           Sv_AddServerCommand /*(client_s *client, svscmd_type type, const char *cmd)*/ = 0x0022CBA0,
           IntermissionClientEndFrame /*(gentity_s *ent)*/ = 0x001745F8,
           memset = 0x0049B928,
           str_pointer = 0x523b30,
           g_gametype = 0x8360d5;






    #endregion
         
                
                }
                   

#endregion