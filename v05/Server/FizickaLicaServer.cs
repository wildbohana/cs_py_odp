using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Server
{
    class FizickaLicaServer : IFizickaLica, IBezbednosniMehanizmi
    {
        static readonly DirektorijumKorisnika direktorijum = new DirektorijumKorisnika();

        public string Autentifikacija(string korisnickoIme, string lozinka)
        {
            return direktorijum.AutentifikacijaKorisnika(korisnickoIme, lozinka);
        }

        public void DodajLice(FizickoLice fizickoLice, string token)
        {
            // Proveri prvo autentifikaciju, pa zatim i autorizaciju za operaciju
            direktorijum.KorisnikAutentifikovan(token);
            direktorijum.KorisnikAutorizovan(token, EPravaPristupa.Azuriranje);
            
            if (!BazaPodataka.fizickaLica.ContainsKey(fizickoLice.Jmbg))
            {
                BazaPodataka.fizickaLica[fizickoLice.Jmbg] = fizickoLice;
            }
            else
            {
                string razlog = "Korisnik sa prosleđenim JMBG-om vec postoji. Nije moguće dodavanje.";
                ServisFizickihLicaIzuzetak izuzetak = new ServisFizickihLicaIzuzetak(razlog);
                throw new FaultException<ServisFizickihLicaIzuzetak>(izuzetak);
            }
        }

        public void ObrisiLice(long jmbg, string token)
        {
            // Proveri prvo autentifikaciju, pa zatim i autorizaciju za operaciju
            direktorijum.KorisnikAutentifikovan(token);
            direktorijum.KorisnikAutorizovan(token, EPravaPristupa.Azuriranje);

            if (!BazaPodataka.fizickaLica.Remove(jmbg))
            {
                string razlog = "Korisnik sa prosleđenim JMBG-om ne postoji. Nije moguće brisanje.";
                ServisFizickihLicaIzuzetak izuzetak = new ServisFizickihLicaIzuzetak(razlog);
                throw new FaultException<ServisFizickihLicaIzuzetak>(izuzetak);
            }
        }

        public List<FizickoLice> SpisakLica(string token)
        {
            // Proveri prvo autentifikaciju, pa zatim i autorizaciju za operaciju
            direktorijum.KorisnikAutentifikovan(token);
            direktorijum.KorisnikAutorizovan(token, EPravaPristupa.Citanje);

            return BazaPodataka.fizickaLica.Values.ToList();            
        }
    }
}
