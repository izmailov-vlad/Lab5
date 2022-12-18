using Lab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Filters
{
    internal interface IFilter
    {
        void Execute(Picture image);
    }
}
