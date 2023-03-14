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
            ChannelFactory<IFizickaLica> factory = new ChannelFactory<IFizickaLica>(new NetTcpBinding(), new EndpointAddress("net.tcp://localhost:4000/ServisFizickihLica"));
            IFizickaLica kanal = factory.CreateChannel();

            kanal.DodajLice(0803996800033, "Marko", "Markovic");
            kanal.DodajLice(1503996800033, "Petar", "Petrovic");
            string spisak = kanal.SpisakLica();
            
            Console.WriteLine("Spisak lica: {0}", spisak);
            kanal.ObrisiLice(1503996800033);
            
            Console.WriteLine("Pritisnite [Enter] za zaustavljanje klijenta."); 
            Console.ReadLine();

        }
    }
}
