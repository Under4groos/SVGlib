using SVGlib;
using System;
using System.IO;

namespace SGVlib
{
    public class SGVparser
    {
        const string pattern_svg_ = @"(<svg[\s\S]+?<\/svg>)";
        const string pattern_path = @"(<path[\s\S]+?\/>)";
        const string pattern_svg_inf = @"(<svg[\s\S]+?>)";
        string FILE_TEXT = "";

        public BASE_SVG BASESVG;
        public SGVparser()
        {
            BASESVG = new BASE_SVG();
        }
        public void OpenSVG(string file)
        {
            if (File.Exists(file))
            {
                FILE_TEXT = File.ReadAllText(file);
            }
        }
        public void OpenSVGString(string text)
        {
            FILE_TEXT = text;
        }
        public void Parse()
        {
            СRegex.GetValues(FILE_TEXT, pattern_svg_, (str, count, i) =>
            {
                СRegex.GetValues(str, pattern_path, (str2, count2, i2) =>
                {
                    SVG_PATH svg_path = new SVG_PATH();
                    СRegex.GetValues(str2, "([\\w]+=\"[\\s\\S]+?\")", (str3, count3, i3) =>
                    {
                         
                        string[] Split = str3.Split(new char[] { '=' });
                        if (Split.Length <= 0)
                            return;
                        string name = Split[0];
                        string arg = Split[1].Replace("\"", "");

                        switch (name)
                        {
                            case "d":
                                svg_path.d = arg;
                                break;
                            case "fill":
                                svg_path.fill = arg;
                                break;
                            default:
                                break;
                        }
                    });
                    BASESVG.add(svg_path);
                });

            });

            СRegex.GetValues(FILE_TEXT, pattern_svg_inf, (str, count, i) =>
            {
                СRegex.GetValues(str, "([\\w]+=\"[\\s\\S]+?\")", (str2, count2, i2) =>
                {
                    string[] Split = str2.Split(new char[] { '=' });
                    if (Split.Length <= 0)
                        return;
                    string name = Split[0];
                    string arg = Split[1].Replace("\"" , "");
                    switch (name)
                    {
                        case "width":
                            BASESVG.width = arg;
                            break;
                        case "height":
                            BASESVG.height = arg;
                            break;
                        case "fill":
                            BASESVG.fill = arg;
                            break;
                        default:
                            break;
                    }
                });
            });
        }
    }
}
