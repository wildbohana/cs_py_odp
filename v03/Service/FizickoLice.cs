using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class FizickoLice
    {
        // Polja
        private long jmbg;
        private string ime;
        private string prezime;

        // Propertiji
        public long Jmbg { get => jmbg; set => jmbg = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }

        // Konstruktor
        public FizickoLice(long jmbg = 0, string ime = "", string prezime = "")
        {
            this.Jmbg = jmbg;
            this.Ime = ime;
            this.Prezime = prezime;
        }
    }
}
