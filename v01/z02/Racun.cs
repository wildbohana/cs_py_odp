using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak2
{
    abstract class Racun
    {
        private string id;
        private double stanje;
        public Racun() {}

        public Racun(string id, double stanje)
        {
            this.id = id;
            Stanje = stanje;
        }

        public void IspisStanja()
        {
            Console.WriteLine("Stanje na racunu je: " + Stanje);
        }

        public virtual void Ispis()
        {
            Console.Write("Stanje na racunu ");
        }

        abstract public void Uplata(double novac);
        abstract public void Isplata(double novac);

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public double Stanje
        {
            get { return stanje; }
            set { stanje = value; }
        }
    }
}
