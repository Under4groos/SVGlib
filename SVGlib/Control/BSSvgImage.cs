using SGVlib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SVGlib.Control
{
    public class BSSvgImage : Border
    {
        Grid grid = new Grid();
        SGVparser parser = new SGVparser();
        public BSSvgImage()
        {
            this.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;        
            this.Child = grid;
            #region event s

            this.SizeChanged += (o,e) =>
            {
                ResizeSvg();
            };
            #region hide 
            //this.Loaded += (o, e) =>
            //{
            //    if (Source == string.Empty)
            //        return;
            //    SetSvgString();
            //};
            #endregion
            #endregion
        }


        public string Source
        {
            get
            {
                return string.Empty;
            }
            set
            {
                SetSvg(value);
                
            }
        }
        
        public string Content
        {
            get; set;
        }
        private void SetSvg(string path)
        {
            if (!File.Exists(path))
                return;

            Content = File.ReadAllText(path);
            if (Content == string.Empty)
                return;
            SetSvgString();


        }

        public void SetSvgString()
        {
            parser.OpenSVGString(Content);
            parser.Parse();
            grid.Children.Clear();

            foreach (SVG_PATH svg in parser.BASESVG.svgpaths)
            {
                System.Windows.Shapes.Path path_svg = new System.Windows.Shapes.Path();

                path_svg.Data = Geometry.Parse(svg.d);
                path_svg.Fill = Brushes.White;

                path_svg.SnapsToDevicePixels = true;

                grid.Children.Add(path_svg);
            }
            ResizeSvg();
        }

        public void ResizeSvg()
        {
            foreach (System.Windows.Shapes.Path path_svg in grid.Children)
            {
                

                double w_ = parser.BASESVG.width.To();
                double h_ = parser.BASESVG.height.To();
                path_svg.PathResize(this.ActualWidth / w_, this.ActualHeight / h_);
            }
        }
    }
}
