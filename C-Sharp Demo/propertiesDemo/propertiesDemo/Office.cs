using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace propertiesDemo
{
    class Office : Software
    {
        private string name;
        private int version;

        public string Name
        {
            get 
            { 
                return name; 
            }
            set 
            { 
                name = value; 
            }
        }

        public int Version
        {
            get 
            {
                return version; 
            }
            set 
            {
                if(value > 0)
                {
                    version = value;
                } 
            }
        }
        
        public Office()
        {
            Console.WriteLine("Enter Office name: ");
            this.Name = Console.ReadLine();

            Console.WriteLine("Enter version: ");
            this.Version = int.Parse(Console.ReadLine());
        }

        public override void show()
        {
            Console.WriteLine("{0}\t{1}", this.name, this.version);
        }
    }
}
