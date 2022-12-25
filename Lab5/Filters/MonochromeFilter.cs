using Lab5.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace Lab5.Filters
{
    internal class MonochromeFilter
    {
        public byte[,] Execute(byte[,] pixels)
        {
            int rows = pixels.GetUpperBound(0) + 1;    // количество строк
            int columns = pixels.Length / rows; // кол-во столбцов

            byte[,] _pixels = pixels;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    _pixels[i, j] = (byte)(_pixels[i, j] <= 100 ? 1 : 0);
                }
            }

            return _pixels;
        }
    }
}
