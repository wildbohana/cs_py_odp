using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Common
{
    [DataContract]
    public class FizickoLice
    {
        // Polja
        long jmbg;
        string ime;
        string prezime;

        // Propertiji imaju [DataMember]
        [DataMember]
        public long Jmbg { get => jmbg; set => jmbg = value; }
        [DataMember]
        public string Ime { get => ime; set => ime = value; }
        [DataMember]
        public string Prezime { get => prezime; set => prezime = value; }

        // Konstruktor
        public FizickoLice(long jmbg, string ime, string prezime)
        {
            this.jmbg = jmbg;
            this.ime = ime;
            this.prezime = prezime;
        }

        // Ispis
        public override string ToString()
        {
            return $"{jmbg} : {ime} {prezime}";
        }
    }
}
