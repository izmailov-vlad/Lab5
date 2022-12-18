﻿using Lab5.Filters;
using Lab5.picture_utils;
using Lab5.PictureUtils;
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

            Hemming hemmingDistance = new Hemming();
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

            Console.WriteLine(hemmingDistance.Compare("123456", "888888uuuu"));
            Console.WriteLine("\n");
            
        }
    }
}
