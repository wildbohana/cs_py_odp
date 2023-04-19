using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Rečnik(ključ, lista stringova)
            int broj = 10;
            Dictionary<int, List<string>> rečnik = new Dictionary<int, List<string>>(broj);

            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                List<string> lista = new List<string>();
                int brElLista = rand.Next(1, 10);

                for (int j = 0; j < brElLista; j++)
                    lista.Add($"el{j}");
                
                rečnik.Add(i, lista);
            }

            // Element == lista stringova
            foreach (KeyValuePair<int, List<string>> element in rečnik)
            {
                Console.WriteLine("<ključ> - <index> - <vrednost>");
                
                for (int i = 0; i < element.Value.Count; i++)
                    Console.WriteLine($" <{element.Key}> - <{i}> - <{element.Value[i]}>");
            }

            Console.ReadKey();
        }
    }
}
