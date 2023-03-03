using System;

namespace z02
{
    class Program
    {
        static void Main(string[] args)
        {
            // Init
            Tekuci tr = new Tekuci(40000);
            Devizni dr = new Devizni(20000);

            // Inicijalno stanje računa
            Console.WriteLine(tr);
            Console.WriteLine(dr);

            // Uplata 1000 dinara na oba
            tr.uplata(1000);
            dr.uplata(1000);

            Console.WriteLine("Stanje na oba računa posle uplate:");
            Console.WriteLine(tr);
            Console.WriteLine(dr);

            // Isplata 10000 dinara sa oba
            tr.isplata(10000);
            dr.isplata(10000);

            Console.WriteLine("Stanje na oba računa posle uplate:");
            Console.WriteLine(tr);
            Console.WriteLine(dr);

            // Nova dva računa - da proverim id
            Tekuci tr1 = new Tekuci(500);
            Devizni dr1 = new Devizni(500);
            Console.WriteLine(tr1);
            Console.WriteLine(dr1);
        }
    }
}
