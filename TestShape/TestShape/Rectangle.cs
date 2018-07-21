using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShape
{
    class Rectangle : Shape
    {
        private double width;
        private double length;

        public double Width
        {
            get { return width; }
            set { width = value; }
        }

        public double Length
        {
            get { return length; }
            set { length = value; }
        }

        public override void ShowArea()
        {
            Console.WriteLine("--------------Rectangle-----------");
            Console.WriteLine("Width: {0}", Width);
            Console.WriteLine("Length: {0}", Length);
            Console.WriteLine("Area: {0}", Width * Length);
            Console.WriteLine("----------------------------------");
        }
    }
}