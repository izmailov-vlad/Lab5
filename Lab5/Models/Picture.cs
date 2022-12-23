﻿
using System.Drawing;

namespace Lab5.Models
{
    internal class Picture
    {
        private  byte[][] _pixels;
        private  int _height;
        private  int _width;
        private  Bitmap _bitmap;

        public byte[][] Pixels
        {
            get => _pixels;
        }

        public Bitmap bitmap {get => _bitmap;}

        public int Height { get => _height; }
        public void SetHeight (int h)
        {
            _height = h;
        }
        public int Width { get => _width; }

        public void SetWidth(int w)
        {
            _width = w;
        }

        public byte GetPixel(int i, int j)
        {
            return _pixels[i][j];
        }

        public void SetPixel(int i, int j, byte value)
        {
            _pixels[i][j] = value;
        }


        public Picture(byte[][] pixels)
        {
            this._pixels = pixels;
        }
    }
}
