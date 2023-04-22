using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class Student
    {
        private string brIndeksa;
        private string ime;
        private string prezime;
        private DateTime vremePoslednjeIzmene;

        [DataMember]
        public string BrIndeksa { get => brIndeksa; set => brIndeksa = value; }
        [DataMember]
        public string Ime { get => ime; set => ime = value; }
        [DataMember]
        public string Prezime { get => prezime; set => prezime = value; }
        [DataMember]
        public DateTime VremePoslednjeIzmene { get => vremePoslednjeIzmene; set => vremePoslednjeIzmene = value; }

        public Student(string brIndeksa, string ime, string prezime, DateTime vremePoslednjeIzmene)
        {
            this.brIndeksa = brIndeksa;
            this.ime = ime;
            this.prezime = prezime;
            this.vremePoslednjeIzmene = vremePoslednjeIzmene;
        }

        public Student()
        {
            this.brIndeksa = "";
            this.ime = "";
            this.prezime = "";
            this.vremePoslednjeIzmene = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Indeks : {BrIndeksa}, ime i prezime: {Ime} {Prezime}";
        }
    }
}
