using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_08
    {
        static void Main(string[] args)
        {
            Assignment_08_PlayerInCome pl = new Assignment_08_PlayerInCome("Tien", 300, 40, 300);
            pl.displayDetail();
            pl.caculateTax();
            pl.caculateBound();
        }
    }
}
