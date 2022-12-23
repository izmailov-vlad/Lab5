
using System.Drawing;

namespace Lab5.Models
{
    internal class Picture
    {
        private  int _height;
        private  int _width;
        private  Bitmap _bitmap;

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
    }
}
