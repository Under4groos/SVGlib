using SGVlib;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SVGlib.Control
{
    public class ImageSVG : Border
    {
        public Size SizeSVG
        {
            get; set;
        } = new Size(1, 1);
        SGVparser parser;
        Grid grid;
        public ImageSVG()
        {
            parser = new SGVparser();
            grid = new Grid();
            this.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            this.Child = grid;
        }
        public void SetSizeSvg(double w, double h)
        {
            double w_ = parser.BASESVG.width.To();
            double h_ = parser.BASESVG.height.To();

            foreach (Path item in grid.Children)
            {
                DSetSize(item, h / h_, w / w_);
            }
        }
        
        public void UpdateSize()
        {
            foreach (Path item in grid.Children)
            {
                DSetSize(item, SizeSVG.Width, SizeSVG.Height);
            }
        }
        public void OpenFile() { }
        public void OpenFile(string file)
        {
            parser.OpenSVG(file);
            parser.Parse();
            


            foreach (SVG_PATH svg in parser.BASESVG.svgpaths)
            {
                Path path = new Path();
                
                path.Data = Geometry.Parse(svg.d);
                path.Fill = Brushes.White;
                DSetSize(path, SizeSVG.Width, SizeSVG.Height);
                grid.Children.Add(path);
            }
        }
        private void DSetSize(Path tr, double w, double h)
        {
            ScaleTransform myScaleTransform = new ScaleTransform();
            myScaleTransform.ScaleY = w;
            myScaleTransform.ScaleX = h;
            TransformGroup myTransformGroup = new TransformGroup();
            myTransformGroup.Children.Add(myScaleTransform);
            tr.RenderTransform = myTransformGroup;
        }
        public void SetSVG(string text)
        {
            parser.OpenSVGString(text);
            parser.Parse();
            foreach (SVG_PATH svg in parser.BASESVG.svgpaths)
            {
                Path path = new Path();
                Console.WriteLine(svg.d);
                path.Data = Geometry.Parse(svg.d);
                path.Fill = Brushes.Beige;
                grid.Children.Add(path);
            }
        }
    }
}
