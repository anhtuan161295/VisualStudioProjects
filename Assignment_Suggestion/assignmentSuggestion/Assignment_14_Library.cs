using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_14_Library
    {
        internal String StudentName;
        internal String BookName, BookID;
        internal String DateIssue, DateReturn;
        internal int Year;

        /// <summary>
        /// default constructor
        /// </summary>
        public Assignment_14_Library()
        {

        }

        ///paramatered constructors
        public Assignment_14_Library(String StudentName, int Year, String BookName, String BookID, String DateIssue, String DateReturn)
        {

            this.StudentName = StudentName;
            this.Year = Year;
            this.BookName = BookName;
            this.BookID = BookID;
            this.DateIssue = DateIssue;
            this.DateReturn = DateReturn;

        }

        ///override ToString()
        ///
        public override String ToString()
        {
            return String.Format(StudentName + "\t\t" + Year + "\t" + BookName + "\t" + BookID + "\t" + DateIssue + "\t" + DateReturn);

        }
    }
}
