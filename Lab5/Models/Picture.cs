
using System.Drawing;

namespace Lab5.Models
{
    internal class Picture
    {
        private readonly byte[][] _pixels;
        private readonly int _height;
        private readonly int _width;
        private readonly Bitmap _bitmap;

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
