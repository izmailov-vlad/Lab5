using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Filters
{
    class MorfFilter
    {
        // функция Dilation производит Морфологическую дилатацию с помощью маски 3x3.
        // Первый массив - начальный двумерный массив с изображением (монохромным), второй - новый массив той же размерности с результатом работы
        // второй массив нужен в связи с невозможностью сразу записывать новые значения элемента в процессе (особенность прохода маской)
        void Dilation(byte[,] massmain, byte[,] massnew) //дилатация если 1 - это чёрный (мы так решили...)
        {
            int rows = massmain.GetUpperBound(0) + 1;    // количество строк
            int columns = massmain.Length / rows;        // количество столбцов

            for (int i = 1; i < rows - 1; i++)
            {
                for (int j = 1; j < columns - 1; j++)
                {
                    if (((massmain[i - 1, j - 1]) == 0) || ((massmain[i - 1, j]) == 0) || ((massmain[i - 1, j + 1]) == 0) || ((massmain[i, j - 1]) == 0) || ((massmain[i, j]) == 0) || ((massmain[i, j + 1]) == 0) || ((massmain[i + 1, j - 1]) == 0) || ((massmain[i + 1, j]) == 0) || ((massmain[i + 1, j + 1]) == 0))
                    {
                        massnew[i, j] = 0;
                    }
                    else
                        massnew[i, j] = 1;
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    massmain[i, j] = massnew[i, j];
                }
            }
        }
    }
}
