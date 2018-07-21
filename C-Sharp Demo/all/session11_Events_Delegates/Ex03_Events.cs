/*
 * See more in session 14 "Multiple Anonymous Methods"
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session11_Events_Delegates
{
    delegate void ChangeLabel();
    
    class Ex03_Events
    {
        public event ChangeLabel onClick;
        
        void changeToSave()
        {
            Console.WriteLine("Save");
        }

        void changeToAdd()
        {
            Console.WriteLine("Add New");
        }

        static void Main(string[] args)
        {
            Ex03_Events events = new Ex03_Events(); 
            
            //Add event handlers to Show event.
            events.onClick += new ChangeLabel(events.changeToSave);
            events.onClick += new ChangeLabel(events.changeToAdd);

            //Invoke the event.
            events.onClick.Invoke();
            
            Console.ReadKey();

        }
    }
}
