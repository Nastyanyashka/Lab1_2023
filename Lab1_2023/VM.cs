using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_2023
{
    internal class VM
    {
        FileStream file;
        Page[] pages = new Page[3];
        public VM()
        {
            file = File.Create("123");
            file.WriteByte();
        }
    }
}
