using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.PictureUtils
{
    class Hemming
    {
        public int Compare(string str1, string str2) {
            int d = 0;
            for(int i = 0; i < Math.Min(str1.Length, str2.Length); i++)
            {
                if(str1[i] != str2[i])
                {
                    d += 1;
                }
            }
            return d;
        }
    }
}
