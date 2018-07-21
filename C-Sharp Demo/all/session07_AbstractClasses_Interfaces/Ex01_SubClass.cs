/*
 * An abstract class cannot be instantiated.
 * An abstract class may contain abstract methods and accessors.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session05_OOP 
{
    abstract class SupperClass 
    {
        protected string icode;
        protected string itemName;
        protected int rate;

        public SupperClass(string icode, string itemName, int rate)
        {
            this.icode = icode;
            this.itemName = itemName;
            this.rate = rate;
        }      
        public abstract void select();  
    }

    class Ex01_SubClass: SupperClass 
    {
        public Ex01_SubClass(string icode, string itemName, int rate) 
            : base(icode, itemName, rate) { }
        
        //Override
        public override void select() 
        {
            Console.WriteLine("Item information:");
            Console.WriteLine("Item Code\t: {0}", base.icode);
            Console.WriteLine("Item name\t: {0}", base.itemName);
            Console.WriteLine("Item rate\t: {0}", base.rate);
        }
        static void Main(string[] args)
        {
            Ex01_SubClass sub;
            sub = new Ex01_SubClass("STCS-18-M-I", "Suitcase 18'', Moulded, Ivory", 1075);
            sub.select();
            
            Console.ReadKey();
        }
    }
}
