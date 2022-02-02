using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVGlib
{
    public class SvgToWPF
    {
        BASE_SVG bASE_SVG;
        
        public SvgToWPF(BASE_SVG bASE_SVG_) 
        {
            bASE_SVG = bASE_SVG_;
            
        }
        public string[] Convert()
        {
            string source_def = Properties.Resource1.svg_wpf;
            List<string> sourcees = new List<string> {};
            foreach (var item in bASE_SVG.svgpaths)
            {
                string color_ = item.d;
                if (color_ == string.Empty || color_ == "none")
                    color_ = "White";
                source_def = source_def.Replace("_svg_", color_);
                source_def = source_def.Replace("_color_", item.fill);

                sourcees.Add(source_def);
            }

            return sourcees.ToArray();
        }


    }
}
