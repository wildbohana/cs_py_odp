using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Replikator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool prviPut = true;
            DateTime vreme = DateTime.Now;

            while (true)
            {
                try
                {
                    // Kanali i proksiji i za izvor, i za odredište (iznova se otvaraju pri svakoj iteraciji)
                    ChannelFactory<IFizickaLica> cfIzvor = new ChannelFactory<IFizickaLica>("Izvor");
                    ChannelFactory<IFizickaLica> cfOdrediste = new ChannelFactory<IFizickaLica>("Odrediste");
                    IFizickaLica kIzvor = cfIzvor.CreateChannel();
                    IFizickaLica kOdrediste = cfOdrediste.CreateChannel();
                    
                    // Kad prvi put radimo replikaciju, moramo da pokupimo sve što se nalazi na izvoru
                    // Pri svakoj izmeni moramo da zabeležimo vreme kada smo je poslednji put odradili
                    if (prviPut)
                    {
                        kOdrediste.UpisLica(kIzvor.SpisakLica()); 
                        vreme = DateTime.Now;
                        prviPut = false;
                    }
                    else
                    {
                        List<FizickoLice> lica = kIzvor.OcitavanjeLica(vreme);
                        vreme = DateTime.Now;
                        kOdrediste.UpisLica(lica);
                    }
                    
                    Thread.Sleep(5000);
                }
                catch (FaultException<ServisFizickaLicaIzuzetak> ex)
                {
                    Console.WriteLine(ex.Detail.Razlog);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
