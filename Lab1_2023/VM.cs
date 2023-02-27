using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Lab1_2023
{
    internal class VM
    {
        Random rand = new Random();
        int firstNum = 0;
        BinaryWriter writer;
        BinaryReader reader;
        string path = "G:\\TestLab1\\123.bin";
        Page[] pages = new Page[3];
        int amountOfPages;
        const int amountOfSymbols = 3000;
        public VM()
        {
            writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));
            writer.Write('V');
            writer.Write('M');
            for (int i = 0; i < amountOfSymbols; i++)
            {
                writer.Write(0);
            }
            writer.Close();

            amountOfPages = amountOfSymbols * sizeof(int) / (528);
            reader = new BinaryReader(File.Open(path,FileMode.Open));
            
            
            for (int i = 0; i < 3; i++)
            {
                BitArray temp = new BitArray(reader.ReadBytes(16));
                pages[i] = new Page();
                pages[i].NumberOfPage = i;
                pages[i].BitMap= temp;
                int[] temp2 = new int[512/sizeof(int)];
                for(int g=0;g< 512/sizeof(int);g++)
                {
                    temp2[g] = reader.ReadInt32();
                }
                pages[i].Symbols = temp2;
            }
            reader.Close();
        }
        public void ReadNextPage()
        {
            reader = new BinaryReader(File.Open(path, FileMode.Open));
            reader.BaseStream.Position = 2 + (pages[1].NumberOfPage+2) * 528;
            BitArray temp = new BitArray(reader.ReadBytes(16));
            pages[0] = pages[1];
            pages[1] = pages[2];
            pages[2] = new Page();
            pages[2].NumberOfPage = pages[1].NumberOfPage + 1;
            pages[2].BitMap = temp;
            int[] temp2 = new int[512 / sizeof(int)];
            for (int g = 0; g < 512 / sizeof(int); g++)
            {
                temp2[g] = reader.ReadInt32();
            }
            pages[2].Symbols = temp2;
            reader.Close();
        }

        public void ReadPreviousPage()
        {
            reader = new BinaryReader(File.Open(path, FileMode.Open));
            reader.BaseStream.Position = 2 + (pages[1].NumberOfPage -2) * 528;
            BitArray temp = new BitArray(reader.ReadBytes(16));
            pages[2] = pages[1];
            pages[1] = pages[0];
            pages[0] = new Page();
            pages[0].NumberOfPage = pages[1].NumberOfPage - 1;
            pages[0].BitMap = temp;
            int[] temp2 = new int[512 / sizeof(int)];
            for (int g = 0; g < 512 / sizeof(int); g++)
            {
                temp2[g] = reader.ReadInt32();
            }
            pages[0].Symbols = temp2;
            reader.Close();
        }
        public void RefreshDataInFile(Page page)
        {
            writer = new BinaryWriter(File.Open(path, FileMode.Open));
            writer.BaseStream.Position = 2 + page.NumberOfPage * 528;
            writer.Write(BitArrayToByteArray(page.BitMap));
            //for (int i = 0; i < 128; i++)
            //{
            //    writer.Write(page.BitMap.Get(i));
            //}
            for (int i = 0; i < page.Symbols.Length; i++)
            {
                writer.Write(page.Symbols[i]);
            }
            writer.Close();

        }
        byte[] BitArrayToByteArray(BitArray bits)
        {
            byte[] ret = new byte[(bits.Length - 1) / 8 + 1];
            bits.CopyTo(ret, 0);
            return ret;
        }
        public int AmountOfPages { get { return amountOfPages; } }  
        public Page[] Pages { get { return pages; } set { pages = value; } }
        public string Path { get { return path; } set { Path = value; } }  
    }
}