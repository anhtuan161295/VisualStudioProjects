using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace propertiesDemo
{
    class Excel
    {
        public void execute() {
            Office office = new Office();
            Console.WriteLine("Name\tVersion\n------|------\n");
            office.show();
        }
    }
}
