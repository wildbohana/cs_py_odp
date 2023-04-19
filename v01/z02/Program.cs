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
            DevizniRacun dr = new DevizniRacun("321029022", 5500);
            TekuciRacun tr = new TekuciRacun("5435342", 0);

            dr.Uplata(1000);
            dr.Isplata(500);

            dr.IspisStanja();
            dr.Ispis();

            tr.Uplata(5000);
            tr.Isplata(2000);

            tr.IspisStanja();
            tr.Ispis();
        }
    }
}
