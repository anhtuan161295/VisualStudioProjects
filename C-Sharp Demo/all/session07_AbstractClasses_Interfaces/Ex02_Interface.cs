/*
 * Has only final variables, abstract methods signatures.
 * Cannot be instantiated.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session07_AbstractClasses_Interfaces
{
    interface User1
    {
        void select(string tableName);
    }
    interface User2
    {
        void select(string tableName);
        void update(int rate);
        void delete(string icode);
    }
    class Ex02_Interface: User1, User2
    {
        public void select(string tableName) {
            Console.WriteLine("SELECT * FROM {0}", tableName);
        }
        public void update(int rate)
        {
            Console.WriteLine("UPDATE Item SET rate = {0}", rate);
        }
        public void delete(string icode)
        {
            Console.WriteLine("DELETE FROM Item WHERE Icode = {0}", icode);
        }
        static void Main(string[] args)
        {
            User1 alex = new Ex02_Interface();  //Can use Ex02_Interface alex
            User2 paul = new Ex02_Interface();  //Can use Ex02_Interface paul
            
            Console.WriteLine("Alex action:");
            alex.select("Customer");

            Console.WriteLine("\nPaul action:");
            paul.select("Item");
            paul.update(450);
            paul.delete("'RKSK-B'");

            Console.ReadKey();
        }
    }
}
