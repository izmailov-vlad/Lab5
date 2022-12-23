using Lab5.Filters;
using Lab5.picture_utils;
using Lab5.PictureUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Main
{
    internal class PictureBuilder
    {
        private MonochromeFilter _monochromeFilter;
        private MorfFilter _morfologiusFilter;
        private ConnectedAreaSearcher _connectedAreaSearcher;
        private Hemming _hemming;

        public PictureBuilder()
        {
            _monochromeFilter = new MonochromeFilter();
            _morfologiusFilter = new MorfFilter();
            _connectedAreaSearcher = new ConnectedAreaSearcher();
            _hemming = new Hemming();
        }

        public int Build(byte[,] pixels, Int64 hashB) {
            pixels = _monochromeFilter.Execute(pixels);
            pixels = _morfologiusFilter.Execute(pixels);
            pixels = _connectedAreaSearcher.Find(pixels);
            Int64 hashA = _morfologiusFilter.Hashing(pixels);
            return _hemming.Compare(hashA.ToString(), hashB.ToString());
        }
    }
}
