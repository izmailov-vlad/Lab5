using Lab5.Filters;
using Lab5.picture_utils;
using Lab5.PictureUtils;
using System;
using System.Collections.Generic;

namespace Lab5.Main
{
    internal class PictureBuilder
    {
        private MonochromeFilter _monochromeFilter;
        private MorfFilter _morfologiusFilter;
        private ConnectedAreaSearcher _connectedAreaSearcher;
        private Hemming _hemming;
        private Poluglad _poluglad;

        
        byte[,] pixels = { 
            {1,1,0,0,1,0,1,0,0 }, 
            { 0,1,0,0,1,0,1,0,0}, 
            { 0,1,1,1,1,0,1,1,1},
            { 0,0,0,0,0,0,0,0,1}, 
            { 1,1,1,0,0,0,0,0,0}, 
            { 0,0,1,1,1,0,1,0,0},
            { 1,1,1,0,1,0,0,0,0},
            { 0,0,0,0,0,0,0,1,1},
        };


        public PictureBuilder()
        {
            _monochromeFilter = new MonochromeFilter();
            _morfologiusFilter = new MorfFilter();
            _connectedAreaSearcher = new ConnectedAreaSearcher();
            _hemming = new Hemming();
            _poluglad = new Poluglad();
        }

        public void Build() {
            pixels = _poluglad.Execute();
            pixels = _monochromeFilter.Execute(pixels);
            pixels = _morfologiusFilter.Dilation(pixels);

            pixels = _connectedAreaSearcher.Find(pixels);

            foreach (KeyValuePair<int, byte[,]> valuePair in _connectedAreaSearcher._areas)
            {
                String finalHash = _morfologiusFilter.Nearestneighbor(valuePair.Value);
                Console.WriteLine(_hemming.Compare(finalHash, _poluglad.pic.GetHash("P")));
                Console.WriteLine(_hemming.Compare(finalHash, _poluglad.pic.GetHash("H")));
            }
            

            
        }
    }
}
