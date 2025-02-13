using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using DarkUI.Forms;


public class Class_Cypher
{
    //################################################################################################################################################
    //################################################################################################################################################
    //################################################################################################################################################
    //THOSES FUNCTIONS WORKS FOR 0x27,0x01 SEED REQUEST

    static byte[] Key1 = new byte[2] { 0x00, 0x90 };
    static byte[] Key2 = new byte[2] { 0x83, 0x04 };
    static byte[] Key3 = new byte[2] { 0x35, 0x84 };

    public static UInt16 ToUInt16BE(byte[] TwoBytes)
    {
        UInt16 k0 = BitConverter.ToUInt16(TwoBytes, 0);
        UInt16 k1 = BitConverter.ToUInt16(BitConverter.GetBytes(k0).Reverse().ToArray(), 0);
        return k1;
    }

    public static void CheckForKeyBytes(string ThisECU)
    {
        if (ThisECU != "")
        {
            string ThisPath = Application.StartupPath + @"\ECUS_KEYS.txt";
            if (File.Exists(ThisPath))
            {
                string[] AllLines = File.ReadAllLines(ThisPath);
                foreach (string ThisLine in AllLines)
                {
                    if (ThisLine.Contains(ThisECU))
                    {
                        string[] SplittedLine = ThisLine.Split('|');
                        byte[] KeysBytes = StringToByteArray(SplittedLine[1]);

                        Key1[0] = KeysBytes[0];
                        Key1[1] = KeysBytes[1];

                        Key2[0] = KeysBytes[2];
                        Key2[1] = KeysBytes[3];

                        Key3[0] = KeysBytes[4];
                        Key3[1] = KeysBytes[5];

                        //GForm_Main.method_1("Firmware keys bytes found!" + Environment.NewLine);
                        return;
                    }
                }
            }
        }
    }

    public static byte[] StringToByteArray(string hex)
    {
        return Enumerable.Range(0, hex.Length)
                         .Where(x => x % 2 == 0)
                         .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                         .ToArray();
    }

    public static UInt16 GetKey01(byte[] SeedTwoBytes, string ThisECU)
    {
        CheckForKeyBytes(ThisECU);

        UInt16 s = ToUInt16BE(SeedTwoBytes);
        UInt16 k0 = ToUInt16BE(Key1);
        UInt16 k1 = ToUInt16BE(Key2);
        UInt16 k2 = ToUInt16BE(Key3);

        Int32 sa_key = (((k2 != 0 ? s * k1 % k2 : s * k1) ^ (s + k0)) & 0xFFFF);

        byte[] b = BitConverter.GetBytes(sa_key);
        byte[] FinalKey = new byte[2] { b[0], b[1] };
        return ToUInt16BE(FinalKey);
    }

    //################################################################################################################################################
    //################################################################################################################################################
    //################################################################################################################################################
    //THOSES FUNCTIONS WORKS FOR 0x27,0x41 SEED REQUEST

    public static uint GetKey41(uint uint_0, byte byte_0)
    {
        uint uint_ = 0U;
        uint uint_2 = 0U;
        uint KeyBytes1 = 0U;
        uint KeyBytes2 = 0U;
        uint FinalAdder = 0U;

        switch (byte_0)
        {
            case 1:
                goto IL_111;    //CIVIC 06-10 (All models??)
            case 2:
                goto IL_127;    //cant be 0x02
            case 3:
                goto IL_146;    //cant be 0x03 (default switch that does not work**)
            case 4:
                goto IL_15C;    //RIDGELINE 06-13
            case 8:
                goto IL_160;    //CRV 07-10
            case 26:
                goto IL_165;    //RDX 07-12
            case 32:
                goto IL_161;    //FREED 11-13
            default:
                {
                    goto IL_146;    //always this switch??
                }
        }
    //#########################################
    /*IL_FB:
        uint_ = 1U;
        uint_2 = 1;
        num = 890661056U;
        num2 = 1088200887U;
        num3 = 0U;
        goto IL_170;*/
    //#########################################
    IL_111:             //Test#1 work for 0x01 algorithm
        //CIVIC 06-10 (All models??) | AE 0D 23 FF 40 65 58 B3
        uint_ = 2U;
        uint_2 = 0U;
        KeyBytes1 = 2920096767U;
        KeyBytes2 = 1080383667U;
        FinalAdder = 0U;
        goto IL_170;
    //#########################################
    IL_127:
        DarkMessageBox.Show("Unknown Algorithm ID dectected, No Keys Available", "Security Issue", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return 0U;
    //#########################################
    IL_146:             //Test#2 (Default Switch, NOT WORK**)
        uint_ = 2U;
        uint_2 = 0U;
        KeyBytes1 = 3129510011U;
        KeyBytes2 = 0U;
        FinalAdder = 955378367U;
        goto IL_170;
    //#########################################
    IL_15C:             //Test#3 should works without issue
        //RIDGELINE 06-13 | 16 A4 AB B0 BF E8 5A 6D
        uint_ = 1U;
        uint_2 = 0U;
        KeyBytes1 = 379890608U;
        KeyBytes2 = 3219675757U;
        FinalAdder = 0U;
        goto IL_170;
    //#########################################
    IL_160:            //Test#4 should works without issue
        //CRV 07-10 KEY BYTES | 6D 75 32 AC 9D 62 3B 64
        uint_ = 2U;
        uint_2 = 0U;
        KeyBytes1 = BitConverter.ToUInt32(new byte[] { 0xac, 0x32, 0x75, 0x6d }, 0);
        KeyBytes2 = BitConverter.ToUInt32(new byte[] { 0x64, 0x3b, 0x62, 0x9d }, 0);
        FinalAdder = 0U;
        goto IL_170;
    //#########################################
    //#########################################
    //#########################################
    // Those are NOT working!!!
    IL_161:
        //FREED 11-13 | 95 58 3E 2C F3 96 B5 6F
        uint_ = 3U;
        uint_2 = 0U;
        KeyBytes1 = BitConverter.ToUInt32(new byte[] { 0x2c, 0x3e, 0x58, 0x95 }, 0);
        KeyBytes2 = BitConverter.ToUInt32(new byte[] { 0x6f, 0xb5, 0x96, 0xf3 }, 0);
        FinalAdder = 0U;
        goto IL_170;
    IL_165:
        //RDX KEY BYTES | 67 E9 76 C1 78 3E 17 39
        uint_ = 2U;
        uint_2 = 0U;
        KeyBytes1 = BitConverter.ToUInt32(new byte[] { 0xC1, 0x76, 0xE9, 0x67 }, 0);
        KeyBytes2 = BitConverter.ToUInt32(new byte[] { 0x39, 0x17, 0x3E, 0x78 }, 0);
        FinalAdder = 0U;
    //#########################################
    //#########################################
    //#########################################
    IL_170:
        //PERFORM CYPHER WORK BELLOW
        /*Console.WriteLine("num:" + num.ToString());         //num       = 2920096767U -> FF-23-0D-AE
        Console.WriteLine("num2:" + num2.ToString());       //num2      = 1080383667U -> B3-58-65-40
        Console.WriteLine("num3:" + num3.ToString());       //num3      = 0
        Console.WriteLine("uint_:" + uint_.ToString());     //uint_     = 2
        Console.WriteLine("uint_2:" + uint_2.ToString());   //uint_2    = 0*/
        uint num6 = Class_Cypher.smethod_3(KeyBytes1 + uint_0, uint_);
        uint num7 = Class_Cypher.smethod_4(KeyBytes2 + uint_0, uint_2);
        return (num6 ^ num7 ^ (uint_0 & 65535U) * (uint_0 >> 16)) + FinalAdder;
    }

    public static uint smethod_3(uint uint_0, uint uint_1)
    {
        return uint_0 << (int)((byte)uint_1) | uint_0 >> (int)(32 - (byte)uint_1);
    }

    public static uint smethod_4(uint uint_0, uint uint_1)
    {
        return uint_0 >> (int)((byte)uint_1) | uint_0 << (int)(32 - (byte)uint_1);
    }

    public Class_Cypher()
    {
    }
}