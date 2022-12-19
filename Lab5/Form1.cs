using Lab5.Filters;
using Lab5.picture_utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ConnectedAreaSearcher connectedAreaSearcher= new ConnectedAreaSearcher();
            byte[,] mass1 = new byte[8, 9] { 
                {1,1,0,0,1,0,1,0,0 }, 
                {0,1,0,0,1,0,1,0,0 },
                {0,1,1,1,1,0,1,1,1 },
                {0,0,0,0,0,0,0,0,1 },
                {1,1,1,0,0,0,0,0,0 },
                {0,0,1,1,1,0,1,0,0 },
                {1,1,1,0,1,0,0,0,0 },
                {0,0,0,0,0,0,0,1,1 },
            };
            byte[,] mass2 = new byte[8, 9];
            connectedAreaSearcher.Find(mass1, mass2);


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(mass2[i, j] + " ");
                }
                Console.Write("\n");
            }
            
        }
    }
}
