using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Konfiguracija klijenta
            string address = "net.tcp://localhost:4000/IFizickaLica";
            NetTcpBinding binding = new NetTcpBinding();

            // Komunikacioni kanal i proxy
            ChannelFactory<IFizickaLica> kanal = new ChannelFactory<IFizickaLica>(binding, address);
            IFizickaLica proksi = kanal.CreateChannel();

            // Dodavanje lica
            proksi.DodajLice(0803996800033, "Marko", "Markovic");
            proksi.DodajLice(1503996800033, "Petar", "Petrovic");
            Console.WriteLine(proksi.SpisakLica());

            // Brisanje lica
            proksi.ObrisiLice(1503996800033);
            Console.WriteLine(proksi.SpisakLica());

            // Klijent se zatvara kad korisnik pritisne bilo koji taster
            Console.WriteLine("\nPritisnite [Enter] za zaustavljanje klijenta.");
            Console.ReadKey();
        }
    }
}
