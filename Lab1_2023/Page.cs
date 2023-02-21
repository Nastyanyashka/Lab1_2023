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
        int numberOfPage;
        bool changed = false;
        public Page()
        {
           
        }

        public BitArray BitMap { get { return bitMap; } set { bitMap = value; } }
        public int[] Symbols { get { return symbols; }  set { 
                changed= true;
                List<int> indexes = new List<int>();    
                for (int i = 0; i < 512 / sizeof(int); i++)
                {
                    if (value[i] != 0)
                    {
                        indexes.Add(i);
                    }
                }
                for(int i = 0; i< indexes.Count; i++)
                {
                    bitMap.Set(indexes[i], true);
                }
                symbols = value; 
            
            } 
        }
        public bool Changed { get { return changed; } set { changed= value; } }
        
        public int NumberOfPage { get { return numberOfPage; } set { numberOfPage = value; } }
    }
}