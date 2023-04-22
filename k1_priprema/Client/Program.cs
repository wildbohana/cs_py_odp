using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IBezbednosniMehanizmi> kanalBezbednost = new ChannelFactory<IBezbednosniMehanizmi>("StudentiBezbednost");
            IBezbednosniMehanizmi proksiBezbednost = kanalBezbednost.CreateChannel();

            string token = "";

            try
            {
                Console.Write("Korisničko ime: ");
                string kIme = Console.ReadLine();
                Console.Write("Lozinka: ");
                string lozinka = Console.ReadLine();

                token = proksiBezbednost.Autentifikacija(kIme, lozinka);
            }
            catch (FaultException<BezbednosniIzuzetak> bex)
            {
                Console.WriteLine(bex.Detail.Razlog);
                return;
            }

            // I onda ide dalji rad servera
            ChannelFactory<IStudentskaSluzba> kanalSluzba = new ChannelFactory<IStudentskaSluzba>("Studenti");
            
            while (true)
            {
                try
                {
                    IStudentskaSluzba proksiSluzba = kanalSluzba.CreateChannel();

                    try
                    {
                        Console.WriteLine("Dodajem studenta broj 1");
                        proksiSluzba.DodajStudenta(new Student("PR83/2020", "Duki", "Suzuki", DateTime.Now), token);
                    }
                    catch (FaultException<BezbednosniIzuzetak> bex)
                    {
                        Console.WriteLine(bex.Detail.Razlog);
                    }
                    catch (FaultException<StudentskaSluzbaIzuzetak> ex)
                    {
                        Console.WriteLine(ex.Detail.Razlog);
                    }

                    // Dodaj studenta broj 2
                    try
                    {
                        Console.WriteLine("Dodajem studenta broj 2");
                        proksiSluzba.DodajStudenta(new Student("PR14/2020", "Marko", "Markovic", DateTime.Now), token);
                    }
                    catch (FaultException<BezbednosniIzuzetak> bex)
                    {
                        Console.WriteLine(bex.Detail.Razlog);
                    }
                    catch (FaultException<StudentskaSluzbaIzuzetak> ex)
                    {
                        Console.WriteLine(ex.Detail.Razlog);
                    }

                    // Izmeni studenta broj 1
                    try
                    {
                        Console.WriteLine("Menjam studenta broj 1");
                        proksiSluzba.IzmeniStudenta(new Student("PR83/2020", "Bole", "Kometa", DateTime.Now), token);
                    }
                    catch (FaultException<BezbednosniIzuzetak> bex)
                    {
                        Console.WriteLine(bex.Detail.Razlog);
                    }
                    catch (FaultException<StudentskaSluzbaIzuzetak> ex)
                    {
                        Console.WriteLine(ex.Detail.Razlog);
                    }

                    // Procitaj studenta broj 1
                    try
                    {
                        Console.WriteLine("Čitam studenta broj 1");
                        Student trazeni = null;
                        proksiSluzba.PronadjiStudenta("PR83/2020", out trazeni, token);
                        Console.WriteLine(trazeni.ToString());
                    }
                    catch (FaultException<BezbednosniIzuzetak> bex)
                    {
                        Console.WriteLine(bex.Detail.Razlog);
                    }

                    // Dodati studenta broj 3
                    try
                    {
                        Console.WriteLine("Dodajem studenta broj 3");
                        proksiSluzba.DodajStudenta(new Student("PR53/2020", "Nebojsa", "Stojanovic", DateTime.Now), token);
                    }
                    catch (FaultException<BezbednosniIzuzetak> bex)
                    {
                        Console.WriteLine(bex.Detail.Razlog);
                    }
                    catch (FaultException<StudentskaSluzbaIzuzetak> ex)
                    {
                        Console.WriteLine(ex.Detail.Razlog);
                    }

                    // Izmeniti studenta broj 2
                    try
                    {
                        Console.WriteLine("Menjam studenta broj 2");
                        proksiSluzba.IzmeniStudenta(new Student("PR14/2020", "Janko", "Markovic", DateTime.Now), token);
                    }
                    catch (FaultException<BezbednosniIzuzetak> bex)
                    {
                        Console.WriteLine(bex.Detail.Razlog);
                    }
                    catch (FaultException<StudentskaSluzbaIzuzetak> ex)
                    {
                        Console.WriteLine(ex.Detail.Razlog);
                    }

                    // Obrisati studenta broj 1
                    try
                    {
                        Console.WriteLine("Brišem studenta broj 1");
                        proksiSluzba.IzbrisiStudenta("PR83/2020", token);
                    }
                    catch (FaultException<BezbednosniIzuzetak> bex)
                    {
                        Console.WriteLine(bex.Detail.Razlog);
                    }

                    // Procitaj studenta broj 1
                    try
                    {
                        Console.WriteLine("Čitam studenta broj 1");
                        Student trazeni;
                        proksiSluzba.PronadjiStudenta("PR83/2020", out trazeni, token);

                        if (trazeni != null) Console.WriteLine(trazeni.ToString());
                    }
                    catch (FaultException<BezbednosniIzuzetak> bex)
                    {
                        Console.WriteLine(bex.Detail.Razlog);
                    }

                    // Izmeniti studenta broj 3
                    try
                    {
                        Console.WriteLine("Menjam studenta broj 3");
                        proksiSluzba.IzmeniStudenta(new Student("PR53/2020", "Janko", "Dragovic", DateTime.Now), token);
                    }
                    catch (FaultException<BezbednosniIzuzetak> bex)
                    {
                        Console.WriteLine(bex.Detail.Razlog);
                    }
                    catch (FaultException<StudentskaSluzbaIzuzetak> ex)
                    {
                        Console.WriteLine(ex.Detail.Razlog);
                    }

                    // Izmeniti studenta broj 2
                    try
                    {
                        Console.WriteLine("Menjam studenta broj 2");
                        proksiSluzba.IzmeniStudenta(new Student("PR14/2020", "Jelena", "Markovic", DateTime.Now), token);
                    }
                    catch (FaultException<BezbednosniIzuzetak> bex)
                    {
                        Console.WriteLine(bex.Detail.Razlog);
                    }
                    catch (FaultException<StudentskaSluzbaIzuzetak> ex)
                    {
                        Console.WriteLine(ex.Detail.Razlog);
                    }

                    // Ispis svih (neobavezno, meni treba da vidim šta se dešava)
                    try
                    {
                        Console.WriteLine(proksiSluzba.IspisiSveStudente(token));
                    }
                    catch (FaultException<BezbednosniIzuzetak> bex)
                    {
                        Console.WriteLine(bex.Detail.Razlog);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
                // Sleep 10s
                Thread.Sleep(10000);
            }
        }
    }
}
