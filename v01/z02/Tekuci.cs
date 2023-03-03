using System;
using System.Collections.Generic;
using System.Text;

namespace z02
{
    class Tekuci : Racun
    {
        // ID za tekuci - 2xx
        static public int tekuciId = 200;
        static private double provizijaTekuci = 0.03;

        // Polja
        private int brRacuna;
        private double stanjeNaRacunu;
        
        // Propertiji
        public int BrRacuna { get => brRacuna; set => brRacuna = value; }
        public double StanjeNaRacunu { get => stanjeNaRacunu; set => stanjeNaRacunu = value; }

        // Konstruktor
        public Tekuci(double stanjeNaRacunu)
        {
            this.BrRacuna = tekuciId++;
            this.StanjeNaRacunu = stanjeNaRacunu;
        }

        // Metode
		// Provizija na isplatu za tekuci je 0
        public override void isplata(double suma)
        {
            StanjeNaRacunu -= suma - suma * provizijaTekuci;
        }
    	// Provizija na isplatu za tekuci je 3
        public override void uplata(double suma)
        {
            StanjeNaRacunu += suma;
        }

        // Override ToString
        public override string ToString()
        {
            string tekst = "";

            tekst += "ID tekućeg računa:\t" + BrRacuna + "\n";
            tekst += "Stanje na računu:\t" + StanjeNaRacunu + "\n";

            return tekst;
        }
    }
}
