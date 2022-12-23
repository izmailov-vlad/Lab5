using Lab5.Main;
using System.Windows.Forms;

// полутоновое, сглаживающий, привидение к монохромноому, морфологический, связный области, Перцептивный хэш, сравнение с помощью хэмменга

namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PictureBuilder pictureBuilder = new PictureBuilder();
            pictureBuilder.Build();
        }
    }
}
