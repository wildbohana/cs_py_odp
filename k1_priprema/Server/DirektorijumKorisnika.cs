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
            DodajKorisnka("admin", "admin");
            DodajKorisnka("gost", "123");

            DodajPravaKorisniku("admin", EPravaPristupa.Modifikacija);
            DodajPravaKorisniku("admin", EPravaPristupa.Citanje);
            DodajPravaKorisniku("admin", EPravaPristupa.Brisanje);

            DodajPravaKorisniku("gost", EPravaPristupa.Citanje);
        }

        public void DodajKorisnka(string korisnickoIme, string lozinka)
        {
            Korisnik k = new Korisnik() { KorisnickoIme = korisnickoIme, Lozinka = KodiraTekst(lozinka) };
            korisnici.Add(k.KorisnickoIme, k);
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
            if (korisnici.TryGetValue(korisnickoIme, out Korisnik k))
            {
                if (KodiraTekst(lozinka).Equals(k.Lozinka))
                {
                    k.Token = KodiraTekst(korisnickoIme + _pepper);
                    k.Autentifikovan = true;

                    return k.Token;
                }
            }

            BezbednosniIzuzetak izuzetak = new BezbednosniIzuzetak() { Razlog = "Korisničko ime ili lozinka nisu tačni." };
            throw new FaultException<BezbednosniIzuzetak>(izuzetak);
        }

        public void KorisnikAutentifikovan(string token)
        {
            foreach (Korisnik k in korisnici.Values)
                if (k.Token == token && k.Autentifikovan)
                    return;

            BezbednosniIzuzetak izuzetak = new BezbednosniIzuzetak() { Razlog = "Korisnik nije autentifikovan." };
            throw new FaultException<BezbednosniIzuzetak>(izuzetak);
        }

        public bool KorisnikAutentifikovanIAutorizovan(string token, EPravaPristupa pravo)
        {
            BezbednosniIzuzetak izuzetak = new BezbednosniIzuzetak();

            foreach (Korisnik k in korisnici.Values)
            {
                if (k.Token == token)
                {
                    if (k.ProveriPravoPristupa(pravo))
                    {
                        return true;
                    }
                    else
                    {
                        izuzetak.Razlog = "Korisnik nema pravo " + pravo.ToString();
                        throw new FaultException<BezbednosniIzuzetak>(izuzetak);
                    }
                }
            }

            izuzetak.Razlog = "Korisnik nije autentifikovan";
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
