using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
    class TekuciRacun : Racun
    {
        public TekuciRacun(string id, double stanje) : base(id, stanje) { }

        public override void Uplata(double novac)
        {
            Stanje = Stanje + novac;
        }

        public override void Isplata(double novac)
        {
            Stanje = Stanje - novac - (novac * 3) / 100;
        }

        public override void Ispis()
        {
            base.Ispis();
            Console.WriteLine("(tekucem) je: " + Stanje + " RSD");
        }
    }
}
