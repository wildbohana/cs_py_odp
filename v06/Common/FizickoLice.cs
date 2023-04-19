using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    // Za klase ide [DataContract]
    [DataContract]
    public class FizickoLice
    {
        // Polja
        long jmbg;
        string ime;
        string prezime;
        DateTime vremePoslednjeIzmene;

        // Propertiji
        [DataMember]
        public long Jmbg { get => jmbg; set => jmbg = value; }
        [DataMember]
        public string Ime { get => ime; set => ime = value; }
        [DataMember]
        public string Prezime { get => prezime; set => prezime = value; }
        [DataMember]
        public DateTime VremePoslednjeIzmene { get => vremePoslednjeIzmene; set => vremePoslednjeIzmene = value; }

        // Konstruktor
        // public FizickoLice() : this(0, "", "", new DateTime()) {}
        public FizickoLice(long jmbg = 0, string ime = "", string prezime = "", DateTime vremePoslednjeIzmene = new DateTime())
        {
            this.Jmbg = jmbg;
            this.Ime = ime;
            this.Prezime = prezime;
            this.VremePoslednjeIzmene = vremePoslednjeIzmene;
        }

        // Ispis
        public override string ToString()
        {
            return $"JMBG : {Jmbg}, ime i prezime : {Ime} {Prezime}";
        }
    }
}
