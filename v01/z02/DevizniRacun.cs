using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
    class DevizniRacun : Racun
    {
        public DevizniRacun(string id, double stanje) : base(id, stanje) {}

        public override void Uplata(double novac)
        {
            Stanje = Stanje + novac - (novac * 5) / 100;
        }

        public override void Isplata(double novac)
        {
            Stanje = Stanje - novac - (novac * 5) / 100;
        }

        public override void Ispis()
        {
            base.Ispis();
            Console.WriteLine("(deviznom) je: " + Stanje + " EUR");
        }
    }
}
