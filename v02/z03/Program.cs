using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak3
{
    class Program
    {
        static void Main(string[] args)
        {
            //  List<object> niz = new List<object>(3000000);
            int size = 3000000;
            object[] niz = new object[size];

            for (int i = 0; i < size; i++)
            {
                if (i % 3 == 0) niz[i] = null;
                else if (i % 3 == 1) niz[i] = "element " + i;
                else if (i % 3 == 2) niz[i] = new object();
            }

            int duzina;

            // Prefiksno kastovanje - baca izuzetke kad ne uspe da kastuje
            Console.WriteLine("Prefiksno kastovanje:");
            duzina = 0;

            foreach (object obj in niz)
            {
                string element = "";
                try
                {
                     element = (string)obj;
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR(prefix) : " + e.Message);
                }

                if (element != null) duzina += element.Length;
            }
            Console.WriteLine($"Dužina je {duzina}");

            // as kastovanje - ne baca izuzetke
            Console.WriteLine("\nas kastovanje:");
            duzina = 0;

            foreach (object obj in niz)
            {
                try 
                {
                    string element = (obj as string);
                    if (element != null) duzina += element.Length;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine($"Dužina je {duzina}");            
            Console.ReadKey();
        }
    }
}
