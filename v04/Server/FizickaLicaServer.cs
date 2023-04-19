using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Server
{
    class FizickaLicaServer : IFizickaLica
    {
        public void DodajLice(FizickoLice fizickoLice)
        {
            if (!BazaPodataka.fizickaLica.ContainsKey(fizickoLice.Jmbg))
            {
                BazaPodataka.fizickaLica[fizickoLice.Jmbg] = fizickoLice;
            }
            else 
            {
                string razlog = "Korisnik sa prosleđenim JMBG-om već postoji. Nije moguće dodavanje.";
                ServisFizickihLicaIzuzetak izuzetak = new ServisFizickihLicaIzuzetak(razlog);
                throw new FaultException<ServisFizickihLicaIzuzetak>(izuzetak);
            }
        }

        public void ObrisiLice(long jmbg)
        {
            if (!BazaPodataka.fizickaLica.Remove(jmbg))
            {
                string razlog = "Korisnik sa prosleđenim JMBG-om ne postoji. Nije moguće brisanje.";
                ServisFizickihLicaIzuzetak izuzetak = new ServisFizickihLicaIzuzetak(razlog);
                throw new FaultException<ServisFizickihLicaIzuzetak>(izuzetak);
            }
        }

        public List<FizickoLice> SpisakLica()
        {
            return BazaPodataka.fizickaLica.Values.ToList();
        }
    }
}
