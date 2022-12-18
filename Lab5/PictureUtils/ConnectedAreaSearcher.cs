using Lab5.Models;
using System.Collections.Generic;

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
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    pixelsLB[i,j] = (byte)(pixelsB[i,j] == 1 ? 0 : 1);
                    
                }
            }
            FindComponents(pixelsLB, label);
            return pixelsLB;
        }

        private void FindComponents(byte[,] pixelsLB, int label)
        {
            int rows = pixelsLB.GetUpperBound(0) + 1;    // количество строк
            int columns = pixelsLB.Length / rows; // кол-во столбцов
            for (int L = 0; L < 8; L++)
            {
                for(int P = 0; P < 9; P++)
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
            HashSet<Pair<Pair<int, int>, byte>> neighbors = Neighbors(L, P, pixelsLB, rows, columns);

            foreach(Pair<Pair<int, int>, byte> neighbor in neighbors)
            {
                if (neighbor.Second == 0)
                {
                    Search(pixelsLB, label, neighbor.First.First, neighbor.First.Second, rows, columns);
                }
            }
        }

        private HashSet<Pair<Pair<int, int>, byte>> Neighbors(int L, int P, byte[,] pixelsLB, int rows, int columns)
        {
            int l = L;
            int p = P;

            HashSet<Pair<Pair<int, int>, byte>> neighbors = new HashSet<Pair<Pair<int, int>, byte>>();

            if (l - 1 > 0) {
                neighbors.Add(new Pair<Pair<int, int>, byte>(new Pair<int, int>(l - 1, p), pixelsLB[l - 1, p]));
            }
            if (p - 1 > 0)
            {
                new Pair<Pair<int, int>, byte>(new Pair<int, int>(l, p - 1), pixelsLB[l, p - 1]);
            }
            if (p + 1 < columns)
            {
                new Pair<Pair<int, int>, byte>(new Pair<int, int>(l, p + 1), pixelsLB[l, p + 1]);
            }
            if (l + 1 < rows)
            {
                new Pair<Pair<int, int>, byte>(new Pair<int, int>(l + 1, p), pixelsLB[l + 1, p]);
            }

            return neighbors;
        }
    }
}
