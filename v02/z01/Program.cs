using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listaElemenata = new List<int>(154357);
            
            // Ako je indeks elementa deljiv sa 4, upisati vrednost indeksa
            // U suprotnom, upisati vrednost indeksa sa negativnim predznakom
            for (int i = 0; i < listaElemenata.Capacity; i++)
            {
                int element = i % 4 == 0 ? i : -i;              
                listaElemenata.Add(element);
            }

            // Sabrati sve elemente koji su deljivi sa 17
            int zbir = 0;
            for (int i = 0; i < listaElemenata.Count; i++)
                if (listaElemenata[i] % 17 == 0)    
                    zbir += listaElemenata[i];

            /*
            // Ispis svih elemenata u listi
            for (int i = 0; i < listaElemenata.Count; i++)
                Console.WriteLine(listaElemenata[i]);
            */

            // Ispis sume
            Console.WriteLine("Suma je " + zbir);
            Console.ReadKey();
        }
    }
}
