using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2009._06._02_PCS_AssignmentTest
{
    class Books
    {
        private string type;
        private string title;
        private int price;
        private int edition;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public int Edition
        {
            get { return edition; }
            set { edition = value; }
        }

        public Books()
        {
        }

        public Books(string type, string title, int price, int edition)
        {
            this.type = type;
            this.title = title;
            this.price = price;
            this.edition = edition;
        }
    }
}