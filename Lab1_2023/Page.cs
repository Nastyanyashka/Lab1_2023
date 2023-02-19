using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_2023
{
    internal class Page
    {
        BitArray bitMap = new BitArray(128);
        int[] symbols = new int[512 / sizeof(int)];
        static BinaryReader reader = new BinaryReader(File.Open("123", FileMode.OpenOrCreate));
        Page()
        {
            for (int i = 0; i < 512 / sizeof(int); i++)
            {
                symbols[i] = reader.ReadInt32();
            }
        }
        byte[] GetPage()
        {
            byte[]
            return 
        }
    }
}