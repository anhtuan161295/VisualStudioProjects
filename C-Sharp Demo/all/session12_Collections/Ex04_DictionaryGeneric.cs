using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session12_Collections
{
    class Ex04_DictionaryGeneric
    {
        static void Main(string[] args)
        {
            //Initial dictionary
            Dictionary<String, String> translate = new Dictionary<string, string>();

            translate.Add("hello", "Bon jour");
            translate.Add("one", "un");
            translate.Add("two", "deux");
            translate.Add("three", "trois");
        
            //Display
            Console.WriteLine("Translate English to French:");
            
            foreach (string root in translate.Keys)
            {
                Console.WriteLine("{0}\t : {1}", root, translate[root]);
            }
            //Seaching to translate
            Console.Write("Enter a word to translate: ");
            string word=Console.ReadLine();

            if (translate.ContainsKey(word))
            {
                Console.WriteLine("Meaning is {0}", translate[word]);
            }
            else
            {
                Console.WriteLine("Word not found");
            }
            Console.ReadKey();
        }
    }
}
