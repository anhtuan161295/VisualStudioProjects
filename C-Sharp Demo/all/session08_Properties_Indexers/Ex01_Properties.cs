/*
 * Provide a useful way to encapsulate data within a class.
 * Allows to set and retrieve values of fields declared with any access modifier.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session08_Properties_Indexers
{
    class Ex01_Properties
    {
        string icode;
        private int rate;

        //Declare as the same Java
        public string getIcode()
        {
            return icode;
        }
        public void setIcode(string value)
        {
            icode = value;
        }
        
        // Declare C# Properties
        public int Rate 
        {
            get
            {
                return rate;
            }
            set
            {
                if(value > 0)
                {
                    rate = value;
                }
            }
        }
        static void Main(string[] args)
        {
            string code = "RKSK-B";
            Ex01_Properties data = new Ex01_Properties();

            //set value as java
            data.setIcode(code);
      
            //set value as C#
            data.Rate = 100;        
           
            //Get value
            Console.WriteLine("The price of {0} is {1}", data.getIcode(), data.Rate);
            Console.ReadKey();
        }
    }
}
