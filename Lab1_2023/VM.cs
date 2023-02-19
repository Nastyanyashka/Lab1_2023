using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_2023
{
    internal class VM
    {
        BinaryWriter writer;
        BinaryReader reader;
        string path = "123";
        Page[] pages = new Page[3];
        public VM()
        {
            writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
            writer.Write('V');
            writer.Write('M');
            for (int i = 0; i < 3000; i++)
            {
                writer.Write(0);
            }
            writer.Close();
            for (int i = 0; i < 3; i++)
            {
                pages[i]
            }
        }
    }
}