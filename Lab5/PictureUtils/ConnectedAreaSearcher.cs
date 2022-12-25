using Lab5.Models;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Lab5.picture_utils
{
    // белый 0
    // черный 1
    internal class ConnectedAreaSearcher
    {
        public Dictionary<int, byte[,]> _areas = new Dictionary<int, byte[,]>();
        int left = 0;
        int right = 0;
        int bottom = 0;
        int upper = 0;
        public byte[,] Find(byte[,] pixelsB)
        {
            int label = 1;
            byte[,] pixelsLB = pixelsB;
            int rows = pixelsLB.GetUpperBound(0) + 1;    // количество строк
            int columns = pixelsLB.Length / rows; // кол-во столбцов
            FindComponents(pixelsLB, label);
           

            return pixelsLB;
        }

       
        private void FindComponents(byte[,] pixelsLB, int label)
        {
            int rows = pixelsLB.GetUpperBound(0) + 1;    // количество строк
            int columns = pixelsLB.Length / rows; // кол-во столбцов
            Dictionary<int, byte[,]> _areasTmp = new Dictionary<int, byte[,]>();
            
            for (int L = 0; L < rows; L++) 
            {
                for(int P = 0; P < columns; P++)
                {
                    if (pixelsLB[L, P] == 1) 
                    {
                        left = columns;

                        right = 0;

                        bottom = 0;
                        
                        upper = rows;
                        

                        label++;
                        Search(pixelsLB, label, L, P, rows, columns);

                        int r = bottom - upper;
                        int c = right - left;
                        
                        byte[,] area = new byte[r + 1, c + 1];

                        int k = 0;
                        int h = 0;
                        for (int i = L; i <= bottom; i++) { 
                            for(int j = P; j <= right; j++)
                            {
                                area[k, h] = pixelsLB[i, j];
                                h++;
                            }
                            k++;
                            h = 0;
                        }
                        _areasTmp[label] = area;
                         
                        for(int i = 0; i <= r; i++)
                        {
                            for(int j = 0; j <= c; j++)
                            {
                                area[i,j] = (byte)(area[i,j] == label ? 1 : 0);
                            }
                        }

                        _areas[label] = area;
                    } 
                }
            }
        }

        private void Search(byte[,] pixelsLB, int label, int L, int P, int rows, int columns) 
        {
            pixelsLB[L, P] = (byte)label;
            

            HashSet<Pair<int, int>> neighbors = Neighbors(L, P, pixelsLB, rows, columns);

            if (L < upper)
            {
                upper = L;
            }

            if (L > bottom)
            {   
                bottom = L;
            }

            if (P < left)
            {
                left = P;
            }

            if (P > right)
            {
                right = P;
            }

            foreach (Pair<int, int> neighbor in neighbors)
            {
                if (pixelsLB[neighbor.First, neighbor.Second] == 1)
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
