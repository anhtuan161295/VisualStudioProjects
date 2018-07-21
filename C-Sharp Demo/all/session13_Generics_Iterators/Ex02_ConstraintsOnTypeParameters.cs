/*
 * Limit the data types of the type parameter.
 * Ensure consistency and reliability of data in a collection.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session13_Generics_Iterators
{
    public class Books
    {
        private string title;

        public Books(string title)
        {
            this.title = title;
        }

        public string Title
        {
            get
            {
                return title;
            }   
        }
    }

    class GenericConstraint<T> where T: Books
    {
        T book;
        public GenericConstraint(T book)
        {
            this.book = book;
        }

        public void printScreen()
        {
            Console.WriteLine("Book title: {0}", book.Title);
        }
    }
    
    class Ex02_ConstraintsOnTypeParameters
    {
        static void Main(string[] args)
        {
            Books book;
            GenericConstraint<Books> bookStore;

            book = new Books("The Davinci's code");
            
            bookStore  = new GenericConstraint<Books>(book);
            
            bookStore.printScreen();
                       
            Console.ReadKey();
        }
    }
}
