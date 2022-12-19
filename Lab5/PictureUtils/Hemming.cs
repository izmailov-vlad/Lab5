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
            int str1Length = str1.Length;
            int str2Length = str2.Length;
            for(int i = 0; i < Math.Min(str1Length, str2Length); i++)
            {
                str1Length--;
                str2Length--;
                if(str1[str1Length] != str2[str2Length])
                {
                    d += 1;
                }
            }
            return d;
        }
    }
}
