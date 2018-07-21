using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    abstract class Assignment_08_Player
    {
        public string name;

        public Assignment_08_Player(string n)
        {
            this.name = n;
        }

        public abstract void displayDetail();

    }

    interface Assignment_08_ITax
    {
        float caculateTax();

    }

    interface Assignment_08_IBound
    {
        float caculateBound();
   
    }
}
