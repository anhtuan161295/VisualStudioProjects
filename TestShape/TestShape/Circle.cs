using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShape
{
    class Circle : Shape
    {
        private double radius;

        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public override void ShowArea()
        {
            Console.WriteLine("-------------Circle----------");
            Console.WriteLine("Radius: {0}", Radius);
            Console.WriteLine("Area: {0}", Radius * Radius * Math.PI);
            Console.WriteLine("------------------------------");
        }
    }
}