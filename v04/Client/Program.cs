using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Komunikacioni kanal i proxy
            ChannelFactory<IFizickaLica> kanal = new ChannelFactory<IFizickaLica>("ServiceName");
            IFizickaLica proksi = kanal.CreateChannel();

            // Dodavanje lica
            DodajLice(new FizickoLice(0123456789123, "Milan", "Milic"), proksi);
            DodajLice(new FizickoLice(0123456789124, "Jovana", "Jovic"), proksi);
            DodajLice(new FizickoLice(0123456789125, "Milica", "Milic"), proksi);
            DodajLice(new FizickoLice(0123456789123, "Milan", "Milic"), proksi);            
            IspisLica(proksi);

            // Brisanje lica
            BrisanjeLica(0123456789124, proksi);
            IspisLica(proksi);

            // Kraj
            Console.WriteLine("\nPritisnite [ENTER] da zaustavite rad klijenta.");
            Console.ReadKey();
        }

        static void IspisLica(IFizickaLica proxy)
        {
            Console.WriteLine("\nSpisak lica :");

            foreach (FizickoLice lice in proxy.SpisakLica())
                Console.WriteLine(lice);
        }

        static void DodajLice(FizickoLice fizickoLice, IFizickaLica proxy)
        {
            try
            {
                proxy.DodajLice(fizickoLice);
            }
            catch (FaultException<ServisFizickihLicaIzuzetak> izuzetak)
            {
                Console.WriteLine("ERROR : " + izuzetak.Detail.Razlog);
            }
        }

        static void BrisanjeLica(long jmbg, IFizickaLica proxy)
        {
            try
            {
                proxy.ObrisiLice(jmbg);
            }
            catch (FaultException<ServisFizickihLicaIzuzetak> izuzetak)
            {
                Console.WriteLine("ERROR : " + izuzetak.Detail.Razlog);
            }
        }
    }
}
