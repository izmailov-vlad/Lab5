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
        private Poluglad _poluglad;

        
        byte[,] pixels;


        public PictureBuilder()
        {
            _monochromeFilter = new MonochromeFilter();
            _morfologiusFilter = new MorfFilter();
            _connectedAreaSearcher = new ConnectedAreaSearcher();
            _hemming = new Hemming();
            _poluglad = new Poluglad();
        }

        public int Build() {
            pixels = _poluglad.Execute();
            pixels = _monochromeFilter.Execute(pixels);
            pixels = _morfologiusFilter.Execute(pixels);
            pixels = _connectedAreaSearcher.Find(pixels);
            Int64 finalHash = _morfologiusFilter.Hashing(pixels);
            return _hemming.Compare(finalHash.ToString(), "Initial hash");
        }
    }
}
