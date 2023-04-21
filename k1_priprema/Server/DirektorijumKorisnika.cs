using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public enum EPravaPristupa { Modifikacija, Citanje, Brisanje }

    class DirektorijumKorisnika
    {
        private const string _pepper = "P&0myWHq";
        private Dictionary<string, Korisnik> korisnici = new Dictionary<string, Korisnik>();
        
        public DirektorijumKorisnika()
        {
            DodajKorisnka("gost", "123");
            DodajKorisnka("admin", "admin");

            // Admin
            DodajPravaKorisniku("admin", EPravaPristupa.Citanje);
            DodajPravaKorisniku("admin", EPravaPristupa.Modifikacija);
            DodajPravaKorisniku("admin", EPravaPristupa.Brisanje);

            // Gost
            DodajPravaKorisniku("gost", EPravaPristupa.Citanje);
        }

        public void DodajKorisnka(string korisnickoIme, string lozinka)
        {
            korisnici.Add(korisnickoIme, new Korisnik() { KorisnickoIme = korisnickoIme, Lozinka = KodiraTekst(lozinka) });
        }

        private string KodiraTekst(string lozinka)
        {
            using (var sha = SHA256.Create())
            {
                var computedHash = sha.ComputeHash(
                Encoding.Unicode.GetBytes(lozinka + _pepper));
                return Convert.ToBase64String(computedHash);
            }
        }

        public string AutentifikacijaKorisnika(string korisnickoIme, string lozinka)
        {
            if (korisnici.TryGetValue(korisnickoIme, out Korisnik korisnik))
            {
                if (KodiraTekst(lozinka).Equals(korisnik.Lozinka))
                {
                    string token = KodiraTekst(korisnickoIme + _pepper);
                    korisnik.Autentifikovan = true;
                    korisnik.Token = token;

                    return token;
                }
            }

            BezbednosniIzuzetak izuzetak = new BezbednosniIzuzetak() { Razlog = "Korisničko ime ili šifra nisu dobri." };
            throw new FaultException<BezbednosniIzuzetak>(izuzetak);
        }

        public void KorisnikAutentifikovan(string token)
        {
            foreach (Korisnik korisnik in korisnici.Values)
                if (korisnik.Token == token && korisnik.Autentifikovan)
                    return;

            BezbednosniIzuzetak izuzetak = new BezbednosniIzuzetak() { Razlog = "Korisnik nije autentifikovan." };
            throw new FaultException<BezbednosniIzuzetak>(izuzetak);
        }

        public bool KorisnikAutentifikovanIAutorizovan(string token, EPravaPristupa pravo)
        {
            BezbednosniIzuzetak izuzetak = new BezbednosniIzuzetak();

            foreach (Korisnik korisnik in korisnici.Values)
            {
                if (korisnik.Token == token)
                {
                    if (!korisnik.ProveriPravoPristupa(pravo))
                    {
                        izuzetak.Razlog = "Korisnik nema pravo " + pravo.ToString();
                        throw new FaultException<BezbednosniIzuzetak>(izuzetak);
                    };

                    return true;
                }
            }

            izuzetak.Razlog = "Korisnik nije autentifikovan ";
            throw new FaultException<BezbednosniIzuzetak>(izuzetak);
        }

        public bool DodajPravaKorisniku(string korisnickoIme, EPravaPristupa pravoPristupa)
        {
            if (korisnici.TryGetValue(korisnickoIme, out Korisnik korisnik))
            {
                return korisnik.DodajPravoPristupa(pravoPristupa);
            }
            return false;
        }

        public bool ProveroPravoKorisnika(string korisnickoIme, EPravaPristupa pravoPristupa)
        {
            if (korisnici.TryGetValue(korisnickoIme, out Korisnik korisnik))
            {
                return korisnik.ProveriPravoPristupa(pravoPristupa);
            }
            return false;
        }
    }
}
