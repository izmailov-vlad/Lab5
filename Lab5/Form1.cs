using Lab5.Filters;
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

<<<<<<< HEAD

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(mass2[i, j] + " ");
                }
                Console.Write("\n");
            }
=======
            Console.WriteLine(hemmingDistance.Compare("123456", "888888uuuu"));
            Console.WriteLine("\n");
>>>>>>> 42783ddabad339408962e6ac89d5704815887d05
            
        }
    }
}
