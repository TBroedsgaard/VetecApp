using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    class Point
    {
        public uint X { get; set; }
        public uint Y { get; set; }

        public Point(uint x, uint y)
        {
            X = x;
            Y = y;
        }
    }
}
