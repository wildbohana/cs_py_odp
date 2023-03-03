using System;
using System.Collections.Generic;
using System.Text;

namespace z02
{
    class Devizni : Racun
    {
        // ID za devizni - 1xx
        static int devizniId = 100;
        static private double provizijaDevizni = 0.05;
        
        // Polja
        private int brRacuna;
        private double stanjeNaRacunu;

        // Propertiji
        public int BrRacuna { get => brRacuna; set => brRacuna = value; }
        public double StanjeNaRacunu { get => stanjeNaRacunu; set => stanjeNaRacunu = value; }

        // Konstruktor
        public Devizni(double stanjeNaRacunu)
        {
            this.BrRacuna = devizniId++;
            this.StanjeNaRacunu = stanjeNaRacunu;
        }

        // Metode
        // Provizija na isplatu za devizni je 5
        public override void isplata(double suma)
        {
            StanjeNaRacunu -= suma - suma*provizijaDevizni;
        }
        // Provizija na isplatu za devizni je 5
        public override void uplata(double suma)
        {
            StanjeNaRacunu += suma - suma * provizijaDevizni; 
        }

        // Override ToString
        public override string ToString()
        {
            string tekst = "";

            tekst += "ID deviznog računa:\t" + BrRacuna + "\n";
            tekst += "Stanje na računu:\t" + StanjeNaRacunu + "\n";

            return tekst;
        }
    }
}
