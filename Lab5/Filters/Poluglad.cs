using Lab5.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Poluglad
    {
        int increment = 1;      //для масштабирования (от 1 до бесконечности)
        int[] zag = new int[4];     //здесь хранится заголовок
        byte[] b = { 0, 0, 0, 0 };  // буфер для последующей конвертации в int
        byte[][] palette;           //здесь хранятся значения палитры из 16 цветов для 2 типа пикселей (с индексацией) 
        byte[] redPal = new byte[8];  //хранятся все возможные биты для красной составляющей 1 типа пикселей
        byte[] greenPal = new byte[4];  //хранятся все возможные биты для зеленой составляющей 1 типа пикселей
        byte[] bluePal = new byte[4];  //хранятся все возможные биты для синей составляющей 1 типа пикселей
        Picture pic;
        byte[][] pix;
        byte[,] matrix = { { 1, 2, 1 }, { 2, 4, 2 }, { 1, 2, 1 } };


        public byte[,] Execute()
        {
            Poluton();
            Glad();
            byte[,] res = new byte[pic.Height, pic.Width];
            for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    res[i, j] = pix[i][j];
                }
            }
            return res;
        }

        private void Glad()
        {
         for (int i = 0; i < pic.Height; i++)
            {
                for (int j = 0; j < pic.Width; j++)
                {
                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            pix[i][j] = (byte)((matrix[0, 0] * 0 + matrix[0, 1] * 0 + matrix[0, 2] * 0 + matrix[1, 0] * 0 + matrix[1, 1] * pix[i][j] + matrix[1, 2] * pix[i][j+1] + matrix[2, 0] * 0 + matrix[2, 1] * pix[i + 1][j] + matrix[2, 2] * pix[i + 1][j + 1]) / (matrix[0, 0] + matrix[0, 1] + matrix[0, 2] + matrix[1, 0] + matrix[1, 1] + matrix[1, 2] + matrix[2, 0] + matrix[2, 1] + matrix[2, 2]));
                        }
                        else if (j == pic.Width - 1)
                        {
                            pix[i][j] = (byte)((matrix[0, 0] * 0 + matrix[0, 1] * 0 + matrix[0, 2] * 0 + matrix[1, 0] * pix[i][j - 1] + matrix[1, 1] * pix[i][j] + matrix[1, 2] * 0 + matrix[2, 0] * pix[i + 1][j - 1] + matrix[2, 1] * pix[i + 1][j] + matrix[2, 2] * 0) / (matrix[0, 0] + matrix[0, 1] + matrix[0, 2] + matrix[1, 0] + matrix[1, 1] + matrix[1, 2] + matrix[2, 0] + matrix[2, 1] + matrix[2, 2]));
                        }
                        else
                        {
                            pix[i][j] = (byte)((matrix[0, 0] * 0 + matrix[0, 1] * 0 + matrix[0, 2] * 0 + matrix[1, 0] * pix[i][j - 1] + matrix[1, 1] * pix[i][j] + matrix[1, 2] * pix[i][j + 1] + matrix[2, 0] * pix[i + 1][j - 1] + matrix[2, 1] * pix[i + 1][j] + matrix[2, 2] * pix[i + 1][j + 1]) / (matrix[0, 0] + matrix[0, 1] + matrix[0, 2] + matrix[1, 0] + matrix[1, 1] + matrix[1, 2] + matrix[2, 0] + matrix[2, 1] + matrix[2, 2]));
                        }
                    }
                    else if (i == pic.Height - 1)
                    {
                        if (j == 0)
                        {
                            pix[i][j] = (byte)((matrix[0, 0] * 0 + matrix[0, 1] * pix[i - 1][j] + matrix[0, 2] * pix[i - 1][j + 1] + matrix[1, 0] * 0 + matrix[1, 1] * pix[i][j] + matrix[1, 2] * pix[i][j + 1] + matrix[2, 0] * 0 + matrix[2, 1] * 0 + matrix[2, 2] * 0) / (matrix[0, 0] + matrix[0, 1] + matrix[0, 2] + matrix[1, 0] + matrix[1, 1] + matrix[1, 2] + matrix[2, 0] + matrix[2, 1] + matrix[2, 2]));
                        }   
                        else if (j == pic.Width - 1)
                        {
                            pix[i][j] = (byte)((matrix[0, 0] * pix[i - 1][j - 1] + matrix[0, 1] * pix[i - 1][j] + matrix[0, 2] * 0 + matrix[1, 0] * pix[i][j - 1] + matrix[1, 1] * pix[i][j] + matrix[1, 2] * 0 + matrix[2, 0] * 0 + matrix[2, 1] * 0 + matrix[2, 2] * 0) / (matrix[0, 0] + matrix[0, 1] + matrix[0, 2] + matrix[1, 0] + matrix[1, 1] + matrix[1, 2] + matrix[2, 0] + matrix[2, 1] + matrix[2, 2]));
                        }
                        else
                        {
                            pix[i][j] = (byte)((matrix[0, 0] * pix[i - 1][j - 1] + matrix[0, 1] * pix[i - 1][j] + matrix[0, 2] * pix[i - 1][j + 1] + matrix[1, 0] * pix[i][j - 1] + matrix[1, 1] * pix[i][j] + matrix[1, 2] * pix[i][j + 1] + matrix[2, 0] * 0 + matrix[2, 1] * 0 + matrix[2, 2] * 0) / (matrix[0, 0] + matrix[0, 1] + matrix[0, 2] + matrix[1, 0] + matrix[1, 1] + matrix[1, 2] + matrix[2, 0] + matrix[2, 1] + matrix[2, 2]));
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            pix[i][j] = (byte)((matrix[0, 0] * 0 + matrix[0, 1] * pix[i - 1][j] + matrix[0, 2] * pix[i - 1][j + 1] + matrix[1, 0] * 0 + matrix[1, 1] * pix[i][j] + matrix[1, 2] * pix[i][j + 1] + matrix[2, 0] * 0 + matrix[2, 1] * pix[i + 1][j] + matrix[2, 2] * pix[i + 1][j + 1]) / (matrix[0, 0] + matrix[0, 1] + matrix[0, 2] + matrix[1, 0] + matrix[1, 1] + matrix[1, 2] + matrix[2, 0] + matrix[2, 1] + matrix[2, 2]));
                        }
                        else if (j == pic.Width - 1)
                        {
                            pix[i][j] = (byte)((matrix[0, 0] * pix[i - 1][j - 1] + matrix[0, 1] * pix[i - 1][j] + matrix[0, 2] * 0 + matrix[1, 0] * pix[i][j - 1] + matrix[1, 1] * pix[i][j] + matrix[1, 2] * 0 + matrix[2, 0] * pix[i + 1][j - 1] + matrix[2, 1] * pix[i + 1][j] + matrix[2, 2] * 0) / (matrix[0, 0] + matrix[0, 1] + matrix[0, 2] + matrix[1, 0] + matrix[1, 1] + matrix[1, 2] + matrix[2, 0] + matrix[2, 1] + matrix[2, 2]));
                        }
                        else
                        {
                            pix[i][j] = (byte)((matrix[0, 0] * pix[i - 1][j - 1] + matrix[0, 1] * pix[i - 1][j] + matrix[0, 2] * pix[i - 1][j + 1] + matrix[1, 0] * pix[i][j - 1] + matrix[1, 1] * pix[i][j] + matrix[1, 2] * pix[i][j + 1] + matrix[2, 0] * pix[i + 1][j - 1] + matrix[2, 1] * pix[i + 1][j] + matrix[2, 2] * pix[i + 1][j + 1]) / (matrix[0, 0] + matrix[0, 1] + matrix[0, 2] + matrix[1, 0] + matrix[1, 1] + matrix[1, 2] + matrix[2, 0] + matrix[2, 1] + matrix[2, 2]));
                        }
                    }
                }
            }
        }

        private void Poluton()
        {
            using (FileStream fs = new FileStream("a.var3", FileMode.Open))  //открываем поток на чтение
            {
                int val;
                val = BitConverter.ToInt32(b, 0);

                b[1] = (byte)fs.ReadByte();
                b[0] = (byte)fs.ReadByte();
                zag [0] = BitConverter.ToInt32(b, 0); // конвертирование ширины изображения в INT
                b[1] = (byte)fs.ReadByte();
                b[0] = (byte)fs.ReadByte();
                zag[1] = BitConverter.ToInt32(b, 0); // конвертирование длины изображения в INT
                zag[2] = fs.ReadByte();
                b[1] = (byte)fs.ReadByte();
                b[0] = (byte)fs.ReadByte();
                zag[3] = BitConverter.ToInt32(b, 0); // конвертирование кол-ва значений цветов палитры в INT

                palette = new byte[zag[3] + 1][];    //создаем массив для палитры 2 типа пикселей

                

                for (int i = 1; i < zag[3] + 1; i++)  //читаем файл и заполняем палитру (2 тип пикселей)
                {
                    palette[i] = new byte[4];
                    for (int j = 3; j >= 0; j--)
                    {
                        palette[i][j] = (byte)fs.ReadByte();
                    }
                }
                InitializePallet();
                readPixels(fs, pic);  //читаем и отрисовываем пиксели из файла
                pic = new Picture();
                pic.SetHeight(zag[1]);
                pic.SetWidth(zag[0]);
                fs.Close();



                /* while ((val = fs.ReadByte()) >= 0)
                 {
                     Console.WriteLine(val);
                 }*/
            }
        }

        private void readPixels(FileStream fs, Picture pic)
        {
            byte pixel;
            byte red;
            byte green;
            byte blue;
            byte number;  //индекс цвета в палитре (2 тип пикселей)
            byte buf = 0;
            pix = new byte[zag[1]][];

            for (int vis = 0; vis < zag[1]; vis++)        //двигаемся вниз по холсту в соответствии со значением высоты из файла
            {
                pix[vis] = new byte[zag[0]];

                for (int sh = 0; sh < zag[0]; sh++)      //вширь в соответствии значению ширины из файла
                {
                    pixel = (byte)fs.ReadByte();
                    if ((pixel & 128) == 0)
                    {
                        red = (byte)(pixel & 112);
                        red = (byte)(red >> 4);
                        green = (byte)(pixel & 12);
                        green = (byte)(green >> 2);
                        blue = (byte)(pixel & 3);

                        pix[vis][sh] = (byte) (0.3 * redPal[red] + 0.59 * greenPal[green] + 0.11 * bluePal[blue]);
                     

                       //pic.SetPixel(pic.Height, pic.Width, buf);
                        //br.Color = Color.FromArgb(255, redPal[red], greenPal[green], bluePal[blue]);
                        //прибавляем к базовым координатам переменную масштабирования (increment), чобы пиксели можно было различить
                    }
                    else
                    {
                        number = (byte)(pixel & 127);  //получаем индекс в палитре (без старшего бита) 2 типа пикселей

                        pix[vis][sh] = (byte)(0.3 * palette[number][2] + 0.59 * palette[number][1] + 0.11 * palette[number][0]);

                        

                        // br.Color = Color.FromArgb(palette[number][3], palette[number][2], palette[number][1], palette[number][0]);

                    }
                }

            }
        }

        private void InitializePallet()
        {
            redPal[0] = 0;
            redPal[1] = 36;
            redPal[2] = 73;
            redPal[3] = 109;
            redPal[4] = 146;
            redPal[5] = 182;
            redPal[6] = 219;
            redPal[7] = 255;

            greenPal[0] = 0;
            greenPal[1] = 109;
            greenPal[2] = 182;
            greenPal[3] = 255;

            bluePal[0] = 0;
            bluePal[1] = 109;
            bluePal[2] = 182;
            bluePal[3] = 255;
        }
    }
}
