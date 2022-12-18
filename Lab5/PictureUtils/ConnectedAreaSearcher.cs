using Lab5.Models;
using System.Collections.Generic;

namespace Lab5.picture_utils
{
    internal class ConnectedAreaSearcher
    {
        public byte[][] Find(byte[][] pixelsLB)
        {
            int label = 0;
            FindComponents(pixelsLB, label);
            return pixelsLB;
        }

        private void FindComponents(byte[][] pixelsLB, int label)
        {
            int rows = pixelsLB.GetUpperBound(0) + 1;    // количество строк
            int columns = pixelsLB.Length / rows; // кол-во столбцов
            for (int L = 0; L < rows; L++)
            {
                for(int P = 0; P < columns; P++)
                {
                    if (pixelsLB[L][P] == 0) 
                    {
                        label++;
                        Search(pixelsLB, label, L, P);
                    }
                }
            }
        }

        private void Search(byte[][] pixelsLB, int label, int L, int P) 
        {
            pixelsLB[L][P] = (byte)label;
            HashSet<Pair<int, int>> neighbors = Neighbors(L, P);

            foreach(Pair<int, int> neighbor in neighbors)
            {
                if (pixelsLB[neighbor.First][neighbor.Second] == 0)
                {
                    Search(pixelsLB, label, neighbor.First, neighbor.Second);
                }
            }
        }

        private HashSet<Pair<int, int>> Neighbors(int L, int P)
        {
            HashSet<Pair<int, int>> neighbors = new HashSet<Pair<int, int>>
            {
                new Pair<int, int>(L + 1, P),
                new Pair<int, int>(L - 1, P),
                new Pair<int, int>(L, P + 1),
                new Pair<int, int>(L, P - 1)
            };
            return neighbors;
        }
    }
}
