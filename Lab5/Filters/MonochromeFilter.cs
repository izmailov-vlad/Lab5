using Lab5.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;

namespace Lab5.Filters
{
    internal class MonochromeFilter : IFilter
    {
        public byte[][] Execute(byte[][] pixels)
        {
            int rows = pixels.GetUpperBound(0) + 1;    // количество строк
            int columns = pixels.Length / rows; // кол-во столбцов

            byte[][] _pixels = pixels;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    _pixels[i][j] = _pixels[i][j] <= 50 ? _pixels[i][j] = 0 : _pixels[i][j] = 1;
                }
            }

            return _pixels;
        }
    }
}
