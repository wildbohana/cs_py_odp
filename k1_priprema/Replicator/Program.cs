using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Replicator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Klijent koji se povezuje na replikatorski servis otvara kanal ka tom servisu
            // Preko proksija se pozivaju metode od IReplikator

            DateTime vremePoslednjeReplikacije = DateTime.MinValue;
            DateTime vreme;

            while (true)
            {
                try
                {
                    // Kanali i proksiji i za izvor i za odredište (iznova se otvaraju pri svakoj iteraciji)
                    ChannelFactory<IReplikator> cfIzvor = new ChannelFactory<IReplikator>("Izvor");
                    IReplikator kIzvor = cfIzvor.CreateChannel();

                    ChannelFactory<IReplikator> cfOdrediste = new ChannelFactory<IReplikator>("Odrediste");
                    IReplikator kOdrediste = cfOdrediste.CreateChannel();

                    // Replikacija podataka
                    vreme = DateTime.Now;
                    Console.WriteLine("Započeta je replikacija, vreme: " + vreme.ToString());

                    List<Student> studenti = kIzvor.Preuzmi(vremePoslednjeReplikacije);
                    kOdrediste.Posalji(studenti);

                    vremePoslednjeReplikacije = vreme;
                    Thread.Sleep(4000);
                }
                catch (FaultException<StudentskaSluzbaIzuzetak> ex)
                {
                    Console.WriteLine(ex.Detail.Razlog);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                // Ako baci izuzetak, da vidim šta je u pitanju
                //Thread.Sleep(10000);
            }
        }
    }
}
