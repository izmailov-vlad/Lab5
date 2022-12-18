using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    internal class Picture
    {
        private byte[][] _pixels { get; }
        private int _height;
        private int _width;
        private Bitmap _bitmap;

        public byte[][] Pixels
        {
            get => _pixels;
        }

        public Bitmap bitmap {get => _bitmap;}

        public int Height { get => _height; }
        public int Width { get => _width; }

        public byte GetPixel(int i, int j)
        {
            return _pixels[i][j];
        }


        public Picture(byte[][] pixels)
        {
            this._pixels = pixels;
        }
    }
}
