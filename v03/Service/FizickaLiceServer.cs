using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class FizickaLiceServer : IFizickaLica
    {
        public void DodajLice(long jmbg, string ime, string prezime)
        {
            if (BazaPodataka.fizickaLica.ContainsKey(jmbg))
                Console.WriteLine("Taj JMBG se već nalazi u bazi.");
            else
                BazaPodataka.fizickaLica.Add(jmbg, new FizickoLice(jmbg, ime, prezime));
        }

        public void ObrisiLice(long jmbg)
        {
            if (BazaPodataka.fizickaLica.ContainsKey(jmbg))
                BazaPodataka.fizickaLica.Remove(jmbg);
            else
                Console.WriteLine("Taj JMBG se ne nalazi u bazi.");
        }

        public string SpisakLica()
        {
            string retval = "Spisak lica:\n";

            foreach (FizickoLice fl in BazaPodataka.fizickaLica.Values)
            {
                retval += "\tJMBG:\t" + fl.Jmbg;
                retval += "\tIME:\t" + fl.Ime;
                retval += "\tPREZIME:\t" + fl.Prezime;
                retval += "\n";
            }

            return retval;
        }
    }
}
