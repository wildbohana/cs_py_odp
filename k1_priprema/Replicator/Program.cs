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
            DateTime vreme;
            DateTime vremePoslednjeReplikacija = DateTime.MinValue;

            while (true)
            {               
                try
                {
                    ChannelFactory<IReplikator> cfIzvor = new ChannelFactory<IReplikator>("Izvor");
                    IReplikator kIzvor = cfIzvor.CreateChannel();
                    ChannelFactory<IReplikator> cfOdrediste = new ChannelFactory<IReplikator>("Odrediste");
                    IReplikator kOdrediste = cfOdrediste.CreateChannel();

                    vreme = DateTime.Now;
                    Console.WriteLine("Započeta je replikacija, vreme: " + vreme.ToString());

                    List<Student> studenti = kIzvor.Preuzmi(vremePoslednjeReplikacija);
                    kOdrediste.Posalji(studenti);

                    vremePoslednjeReplikacija = vreme;
                }
                catch (FaultException<StudentskaSluzbaIzuzetak> ex)
                {
                    Console.WriteLine(ex.Detail.Razlog);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Thread.Sleep(4000);
            }                
        }
    }
}
