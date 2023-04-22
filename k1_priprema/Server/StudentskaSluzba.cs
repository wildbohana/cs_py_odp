using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class StudentskaSluzba : IStudentskaSluzba, IBezbednosniMehanizmi
    {
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
                BazaPodataka.Studenti.Add(student.BrIndeksa, student);
            }
            else
            {
                string razlog = "Student sa prosleđenim brojem indeksa već postoji. Nije moguće dodavanje.";
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
                return false;
            }
        }

        public void IzmeniStudenta(Student student, string token)
        {
            direktorijum.KorisnikAutentifikovanIAutorizovan(token, EPravaPristupa.Modifikacija);

            if (BazaPodataka.Studenti.ContainsKey(student.BrIndeksa))
            {
                BazaPodataka.Studenti[student.BrIndeksa] = student;
            }
            else
            {
                string razlog = "Student sa prosleđenim brojem indeksa ne postoji. Nije moguća izmena.";
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
                student = null;
                return false;
            }
        }

        // Dodato čisto ovako
        public string IspisiSveStudente(string token)
        {
            direktorijum.KorisnikAutentifikovanIAutorizovan(token, EPravaPristupa.Citanje);

            string retVal = "";
            foreach (Student s in BazaPodataka.Studenti.Values)
                retVal += s.ToString() + "\n";

            return retVal;
        }
    }
}
