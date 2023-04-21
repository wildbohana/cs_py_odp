using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Dobijaš ovo (prazan Main)

namespace Replicator
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime vreme = new DateTime();
            Replikator repl = new Replikator();

            while (true)
            {
                try
                {
                    // Kanali i proksiji i za izvor i za odredište (iznova se otvaraju pri svakoj iteraciji)
                    ChannelFactory<IStudentskaSluzba> cfIzvor = new ChannelFactory<IStudentskaSluzba>("Izvor");
                    IStudentskaSluzba kIzvor = cfIzvor.CreateChannel();

                    ChannelFactory<IStudentskaSluzba> cfOdrediste = new ChannelFactory<IStudentskaSluzba>("Odrediste");
                    IStudentskaSluzba kOdrediste = cfOdrediste.CreateChannel();

                    // Replikacija podataka
                    vreme = DateTime.Now;
                    List<Student> studenti = repl.Preuzmi(kIzvor, vreme);
                    repl.Posalji(kOdrediste, studenti);

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
