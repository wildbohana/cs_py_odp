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
            // Komunikacioni kanal i proxy -  PRVO ZA AUTENTIFIKACIJU KORISNIKA
            ChannelFactory<IBezbednosniMehanizmi> channelBezbednost = new ChannelFactory<IBezbednosniMehanizmi>("ServiceNameBezbednost");
            IBezbednosniMehanizmi proxyBezbednost = channelBezbednost.CreateChannel();

            // Token nam služi kao način da autentifikujemo korisnika
            string token = "";

            try
            {
                // pera, p3ra
                // admin, Adm1n

                Console.WriteLine("Korisničko ime :");
                string korisnickoIme = Console.ReadLine();
                Console.WriteLine("Lozinka:");
                string lozinka = Console.ReadLine();
            
                token = proxyBezbednost.Autentifikacija(korisnickoIme, lozinka);
            }
            catch (FaultException<BezbednosniIzuzetak> izuzetak)
            {
                Console.WriteLine(izuzetak.Detail.Poruka);
                return;
            }

            // Komunikacioni kanal i proxy (redovni) se otvaraju tek nakon uspešne autentifikacije korisnika
            ChannelFactory<IFizickaLica> channel = new ChannelFactory<IFizickaLica>("ServiceName");
            IFizickaLica proxy = channel.CreateChannel();

            // Dodavanje lica (osim  proksija prosleđujemo i token)
            DodajLice(new FizickoLice(0123456789123, "Milan", "Milic"), proxy, token);
            DodajLice(new FizickoLice(0123456789124, "Jovana", "Jovic"), proxy, token);
            DodajLice(new FizickoLice(0123456789125, "Milica", "Milic"), proxy, token);
            DodajLice(new FizickoLice(0123456789123, "Milan", "Milic"), proxy, token);
            IspisLica(proxy, token);

            // Brisanje lica (takođe nam treba token)
            ObrisiLice(0123456789123, proxy, token);
            ObrisiLice(0123456789123, proxy, token);
            IspisLica(proxy, token);

            // Kraj
            Console.WriteLine("\nPritisnite [ENTER] za gašenje klijenta.");
            Console.ReadKey();
        }

        static void IspisLica(IFizickaLica proxy, string token)
        {
            Console.WriteLine("\nSpisak lica :");

            try
            {
                foreach (FizickoLice lice in proxy.SpisakLica(token))
                    Console.WriteLine(lice);
            }
            catch (FaultException<BezbednosniIzuzetak> izuzetak)
            {
                Console.WriteLine("ERROR : " + izuzetak.Detail.Poruka);
            }
        }

        static void DodajLice(FizickoLice fizickoLice, IFizickaLica proxy, string token)
        {
            try
            {
                proxy.DodajLice(fizickoLice, token);
            }
            catch (FaultException<BezbednosniIzuzetak> izuzetak)
            {
                Console.WriteLine("ERROR : " + izuzetak.Detail.Poruka);
            }
            catch (FaultException<ServisFizickihLicaIzuzetak> izuzetak)
            {
                Console.WriteLine("ERROR : " + izuzetak.Detail.Razlog);
            }          
        }

        static void ObrisiLice(long jmbg, IFizickaLica proxy, string token)
        {
            try
            {
                proxy.ObrisiLice(jmbg, token);
            }
            catch (FaultException<BezbednosniIzuzetak> izuzetak)
            {
                Console.WriteLine("ERROR : " + izuzetak.Detail.Poruka);
            }
            catch (FaultException<ServisFizickihLicaIzuzetak> izuzetak)
            {
                Console.WriteLine("ERROR : " + izuzetak.Detail.Razlog);
            }
        }
    }
}
