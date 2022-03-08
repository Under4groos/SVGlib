using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SVGlib.Control
{
    public static class ControlStaticLib
    {
        public static void PathResize(this System.Windows.Shapes.Path tr, double w, double h)
        {
            ScaleTransform myScaleTransform = new ScaleTransform();
            
            myScaleTransform.ScaleX = w;
            myScaleTransform.ScaleY = h;
            TransformGroup myTransformGroup = new TransformGroup();
            myTransformGroup.Children.Add(myScaleTransform);
            tr.RenderTransform = myTransformGroup;
        }
    }
}
