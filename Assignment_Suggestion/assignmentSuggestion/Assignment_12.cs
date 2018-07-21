using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_12
    {
        public int SimpleInterest(int P, int R, int T, int I, int N)
        {
            return P * T * R;
        }
        public int CompoundInterest(int P, int R, int T, int I, int N)
        {
            return (P * N * R) / 100;
        }
        public int RealInterest(int P, int R, int T, int I, int N)
        {
            return (P * T * R) - I;
        }
        public delegate int Delegate(int P, int R, int T, int I, int N);
        static void Main(string[] args)
        {
            string[][] cus = new string[3][];
            cus[0] = new string[] { "Nguyen", "Van A 01", "1/1/2008", "Simple" };
            cus[1] = new string[] { "Nguyen", "Van A 01", "2/2/2009", "Compound" };
            cus[2] = new string[] { "Nguyen", "Van A 03", "3/3/2010", "Real" };

            Assignment_12 customer = new Assignment_12();
            Delegate dele_gate;
            string interest = "";
            Console.WriteLine("\t\t\tInforemation Customer");
            Console.WriteLine("Lastname\tFirstname\t\tDate\t\t\tInterest\n");
            for (int i = 0; i < cus.GetLength(0); i++)
            {
                for (int j = 0; j < cus[i].Length; j++)
                {
                    Console.Write("{0}\t\t", cus[i][j]);
                    switch (cus[i][3])
                    {
                        case "Simple":
                            interest = "Simple";
                            break;
                        case "Compound":
                            interest = "Compound";
                            break;
                        case "Real":
                            interest = "Real";
                            break;
                    }
                }
                switch (interest)
                {
                    case "Simple":
                        dele_gate = new Delegate(customer.SimpleInterest);
                        Console.WriteLine("Simple Interest: {0}\n", dele_gate(2, 4, 6, 8, 10));
                        break;
                    case "Compound":
                        dele_gate = new Delegate(customer.CompoundInterest);
                        Console.WriteLine("\rCompound Interest: {0}\n", dele_gate(12, 14, 16, 18, 20));
                        break;
                    case "Real":
                        dele_gate = new Delegate(customer.RealInterest);
                        Console.WriteLine("Real Interest: {0}\n", dele_gate(22, 24, 26, 28, 30));
                        break;
                }
            }
        }
    }
}
