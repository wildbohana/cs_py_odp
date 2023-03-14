using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class FizickaLicaServis : IFizickaLica
    {
        public void DodajLice(long jmbg, string ime, string prezime)
        {
            if (BazaPodataka.BazaPodatakaFL.ContainsKey(jmbg))
                Console.WriteLine("Taj JMBG se već nalazi u bazi.");
            else
                BazaPodataka.BazaPodatakaFL.Add(jmbg, new FizickoLice(jmbg, ime, prezime));
        }

        public void ObrisiLice(long jmbg)
        {
            if (BazaPodataka.BazaPodatakaFL.ContainsKey(jmbg))
                BazaPodataka.BazaPodatakaFL.Remove(jmbg);
            else
                Console.WriteLine("Taj JMBG se ne nalazi u bazi.");
        }

        public string SpisakLica()
        {
            string retval = "Spisak lica:\n";

            foreach (FizickoLice fl in BazaPodataka.BazaPodatakaFL.Values)
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
