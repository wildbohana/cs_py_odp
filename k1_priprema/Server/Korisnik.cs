﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Korisnik
    {
        string korisnickoIme;
        string lozinka;
        bool autentifikovan = false;
        string token;
        SortedSet<EPravaPristupa> pravaPristupa = new SortedSet<EPravaPristupa>();

        public string KorisnickoIme
        {
            get => korisnickoIme;
            set => korisnickoIme = value;
        }
        public string Lozinka
        {
            get => lozinka;
            set => lozinka = value;
        }
        public bool Autentifikovan
        {
            get => autentifikovan;
            set => autentifikovan = value;
        }
        public string Token
        {
            get => token;
            set => token = value;
        }

        public Korisnik() : this("", "") { }

        public Korisnik(string korisnickoIme, string lozinka)
        {
            this.korisnickoIme = korisnickoIme;
            this.Lozinka = lozinka;
        }

        public bool DodajPravoPristupa(EPravaPristupa pravoPristupa)
        {
            return pravaPristupa.Add(pravoPristupa);
        }

        public bool ProveriPravoPristupa(EPravaPristupa pravoPristupa)
        {
            return pravaPristupa.Contains(pravoPristupa);
        }
    }
}
