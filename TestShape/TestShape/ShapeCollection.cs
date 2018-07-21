using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShape
{
    class ShapeCollection : IEnumerable
    {
        List<Shape> list = new List<Shape>();
        private int count = 0;

        public void AddCircle()
        {
            string temp;
            bool isDouble;
            double temp2;
            try
            {
                Circle circle = new Circle();
                Console.Write("Enter radius: ");
                temp = Console.ReadLine();
                //isDouble = double.TryParse(temp, out temp2);
                temp2 = double.Parse(temp);
                circle.Radius = temp2;
                list.Add(circle);
                count++;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void AddRectangle()
        {
            string temp1;
            string temp2;
            bool isNum1;
            bool isNum2;
            double temp3;
            double temp4;

            try
            {
                Rectangle rec = new Rectangle();
                Console.Write("Enter width: ");
                temp1 = Console.ReadLine();
                //isNum1 = double.TryParse(temp1, out temp3);
                temp3 = double.Parse(temp1);
                rec.Width = temp3;
                Console.Write("Enter length: ");
                temp2 = Console.ReadLine();
                //isNum2 = double.TryParse(temp2, out temp4);
                temp4 = double.Parse(temp2);
                rec.Length = temp4;
                list.Add(rec);
                count++;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Show()
        {
            if (count > 0)
            {
                foreach (var var in list)
                {
                    var.ShowArea(); ;
                }
            }
            else
            {
                Console.WriteLine("No object to display");
            }
        }

        public IEnumerator GetShape()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return GetShape();
        }
    }
}