using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGlib
{
    public class BASE_SVG
    {
        public string height;
        public string width;
        public string fill;
        public List<SVG_PATH> svgpaths = new List<SVG_PATH>();
        public int count
        {
            get
            {
                return svgpaths.Count;
            }
            private set { }
        }
        public void add(SVG_PATH svgpath_)
        {
            svgpaths.Add(svgpath_);
        }
        public override string ToString()
        {
            string all_ = $"height:{height}, width:{width}, fill:{fill}\n";
            int count_ = 0;
            foreach (var item in svgpaths)
            {
                all_ += $"\n[{count_}]\n{item}";
                count_++;
            }
            return all_;
        }
    }
}
