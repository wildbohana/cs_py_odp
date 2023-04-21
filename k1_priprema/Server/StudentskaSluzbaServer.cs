using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class StudentskaSluzbaServer : IStudentskaSluzba, IBezbednosniMehanizmi
    {
        // NE ZABORAVI DIREKTORIJUM KORISNIKA
        static readonly DirektorijumKorisnika direktorijum = new DirektorijumKorisnika();

        public string Autentifikacija(string korisnickoIme, string lozinka)
        {
            return direktorijum.AutentifikacijaKorisnika(korisnickoIme, lozinka);
        }

        public void DodajStudenta(Student student, string token)
        {
            direktorijum.KorisnikAutentifikovanIAutorizovan(token, EPravaPristupa.Modifikacija);

            if (!BazaPodataka.Studenti.ContainsKey(student.BrIndeksa))
            {
                //student.VremePoslednjeIzmene = DateTime.Now;
                BazaPodataka.Studenti.Add(student.BrIndeksa, student);
            }
            else
            {
                string razlog = "Student sa prosleđenim indeksom već postoji. Nije moguće dodavanje.";
                StudentskaSluzbaIzuzetak izuzetak = new StudentskaSluzbaIzuzetak { Razlog = razlog };
                throw new FaultException<StudentskaSluzbaIzuzetak>(izuzetak);
            }
        }

        public bool IzbrisiStudenta(string index, string token)
        {
            direktorijum.KorisnikAutentifikovanIAutorizovan(token, EPravaPristupa.Brisanje);

            if (BazaPodataka.Studenti.ContainsKey(index))
            {
                return BazaPodataka.Studenti.Remove(index);
            }
            else
            {
                string razlog = "Student sa prosleđenim indeksom ne postoji. Nije moguće brisanje.";
                StudentskaSluzbaIzuzetak izuzetak = new StudentskaSluzbaIzuzetak { Razlog = razlog };
                throw new FaultException<StudentskaSluzbaIzuzetak>(izuzetak);
            }
        }

        public void IzmeniStudenta(Student student, string token)
        {
            direktorijum.KorisnikAutentifikovanIAutorizovan(token, EPravaPristupa.Modifikacija);

            if (BazaPodataka.Studenti.ContainsKey(student.BrIndeksa))
            {
                //student.VremePoslednjeIzmene = DateTime.Now;
                BazaPodataka.Studenti[student.BrIndeksa] = student;
            }
            else
            {
                string razlog = "Student sa prosleđenim indeksom ne postoji. Nije moguće brisanje.";
                StudentskaSluzbaIzuzetak izuzetak = new StudentskaSluzbaIzuzetak { Razlog = razlog };
                throw new FaultException<StudentskaSluzbaIzuzetak>(izuzetak);
            }
        }

        public bool PronadjiStudenta(string index, out Student student, string token)
        {
            direktorijum.KorisnikAutentifikovanIAutorizovan(token, EPravaPristupa.Citanje);

            if (BazaPodataka.Studenti.ContainsKey(index))
            {
                student = BazaPodataka.Studenti[index];
                return true;
            }
            else
            {
                string razlog = "Student sa prosleđenim indeksom ne postoji.";
                StudentskaSluzbaIzuzetak izuzetak = new StudentskaSluzbaIzuzetak { Razlog = razlog };
                throw new FaultException<StudentskaSluzbaIzuzetak>(izuzetak);
            }
        }

        // Ne mora ovo, dodala sam zbog preglednosti
        public string IspisiSveStudente(string token)
        {
            direktorijum.KorisnikAutentifikovanIAutorizovan(token, EPravaPristupa.Citanje);

            string svi = "";

            if (BazaPodataka.Studenti.Count > 0)
                foreach (Student s in BazaPodataka.Studenti.Values)
                    svi += s.ToString() + "\n";

            return svi;
        }
    }
}
