using SGVlib;
using SVGlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleSVG
{
    [TestClass]
    public class test
    {
        [TestMethod]
        public void dtest()
        {

        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {

            main(args);
            Console.ReadLine();
        }

        static void main(string[] args)
        {
            SGVparser sGVparser = new SGVparser();
            sGVparser.OpenSVG(@"C:\Users\UnderKo\Downloads\cell_wifi_black_24dp.svg");
            sGVparser.Parse();

            SvgToWPF svgToWPF = new SvgToWPF(sGVparser.BASESVG);

            foreach (var item in svgToWPF.Convert())
            {
                Console.WriteLine("\n\n");
                Console.WriteLine(item);
            }


            
        }
    }
}
