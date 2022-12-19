using Lab5.Models;
using System.Collections.Generic;
using System.Reflection;

namespace Lab5.picture_utils
{
    // белый 0
    // черный 1
    internal class ConnectedAreaSearcher
    {
        public byte[,] Find(byte[,] pixelsB, byte[,] pixelsLB)
        {
            int label = 0;

            int rows = pixelsLB.GetUpperBound(0) + 1;    // количество строк
            int columns = pixelsLB.Length / rows; // кол-во столбцов
            Negate(pixelsB, pixelsLB, rows, columns);
            FindComponents(pixelsLB, label);
            Normalize(pixelsB, pixelsLB, rows, columns);

            return pixelsLB;
        }

        private void Negate(byte[,] pixelsB, byte[,] pixelsLB, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    pixelsLB[i, j] = (byte)(pixelsB[i, j] == 1 ? 0 : 1);

                }
            }
        }

        private void Normalize(byte[,] pixelsB, byte[,] pixelsLB, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (pixelsB[i,j] == 0)
                    {
                        pixelsLB[i, j] = pixelsB[i, j];
                    }
                    

                }
            }
        }

        private void FindComponents(byte[,] pixelsLB, int label)
        {
            int rows = pixelsLB.GetUpperBound(0) + 1;    // количество строк
            int columns = pixelsLB.Length / rows; // кол-во столбцов
            for (int L = 0; L < rows; L++)
            {
                for(int P = 0; P < columns; P++)
                {
                    if (pixelsLB[L, P] == 0) 
                    {
                        label++;
                        Search(pixelsLB, label, L, P, rows, columns);
                    } 
                }
            }
        }

        private void Search(byte[,] pixelsLB, int label, int L, int P, int rows, int columns) 
        {
            pixelsLB[L, P] = (byte)label;
            HashSet<Pair<int, int>> neighbors = Neighbors(L, P, pixelsLB, rows, columns);

            foreach(Pair<int, int> neighbor in neighbors)
            {
                if (pixelsLB[neighbor.First, neighbor.Second] == 0)
                {
                    Search(pixelsLB, label, neighbor.First, neighbor.Second, rows, columns);
                }
            }
        }

        private HashSet<Pair<int, int>> Neighbors(int L, int P, byte[,] pixelsLB, int rows, int columns)
        {
            int l = L;
            int p = P;

            HashSet<Pair<int, int>> neighbors = new HashSet<Pair<int, int>>();

            if (l - 1 >= 0) {
                neighbors.Add(new Pair<int, int>(l - 1, p));
            }
            if (l + 1 < rows)
            {
                neighbors.Add(new Pair<int, int>(l + 1, p));
            }
            if (p - 1 >= 0)
            {
                neighbors.Add(new Pair<int, int>(l, p - 1));
            }
            if (p + 1 < columns)
            {
                neighbors.Add(new Pair<int, int>(l, p + 1));
            }
            

            return neighbors;
        }
    }
}
