using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FizickoLice
    {
        private long jmbg;
        private string ime;
        private string prezime;

        public long Jmbg { get => jmbg; set => jmbg = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }

        public FizickoLice(long jmbg, string ime, string prezime)
        {
            this.Jmbg = jmbg;
            this.Ime = ime;
            this.Prezime = prezime;
        }
    }
}
