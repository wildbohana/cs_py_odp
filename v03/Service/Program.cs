using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            // using automatski poziva Dispose() metodu
            using (ServiceHost host = new ServiceHost(typeof(FizickaLiceServer)))
            {
                // Konfiguracija servera
                string adresa = "net.tcp://localhost:4000/IFizickaLica";
                NetTcpBinding binding = new NetTcpBinding();

                // Otvaranje EP
                host.AddServiceEndpoint(typeof(IFizickaLica), binding, adresa);

                // Pokretanje servera
                host.Open();
                Console.WriteLine($"Servis je uspesno pokrenut na adresi : {adresa}");

                // Server se zatvara kad korisnik pritisne bilo koji taster
                Console.WriteLine("\nPritisnite [Enter] za zaustavljanje servera.");
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
