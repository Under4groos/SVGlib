using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGlib
{
    public struct SVG_PATH
    {
        public string d;
        public string fill;
        public override string ToString()
        {
            return $"fill:{fill}\nd:{d}";
        }

    }
}
