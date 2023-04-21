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
            // Komunikacioni kanal i proxy -  PRVO ZA AUTENTIFIKACIJU KORISNIKA
            ChannelFactory<IBezbednosniMehanizmi> channelBezbednost = new ChannelFactory<IBezbednosniMehanizmi>("StudentiBezbednost");
            IBezbednosniMehanizmi proxyBezbednost = channelBezbednost.CreateChannel();

            string token = "";

            try
            {
                Console.WriteLine("Korisničko ime :");
                string korisnickoIme = Console.ReadLine();
                Console.WriteLine("Lozinka:");
                string lozinka = Console.ReadLine();

                token = proxyBezbednost.Autentifikacija(korisnickoIme, lozinka);
            }
            catch (FaultException<BezbednosniIzuzetak> izuzetak)
            {
                Console.WriteLine(izuzetak.Detail.Razlog);
                return;
            }

            // Posle toga započinješ sa redovnim radom servera
            ChannelFactory<IStudentskaSluzba> servislica = new ChannelFactory<IStudentskaSluzba>("Studenti");

            while (true)
            {
                try
                {
                    // Otvaraš proksi, realizuješ zadati scenario
                    IStudentskaSluzba proksi = servislica.CreateChannel();

                    // Dodaj studenta broj 1
                    try
                    {
                        Console.WriteLine("Dodajem studenta broj 1");
                        proksi.DodajStudenta(new Student("PR83/2020", "Duki", "Suzuki", DateTime.Now), token);
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
                        proksi.DodajStudenta(new Student("PR14/2020", "Marko", "Markovic", DateTime.Now), token);
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
                        proksi.IzmeniStudenta(new Student("PR83/2020", "Bole", "Kometa", DateTime.Now), token);
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
                        proksi.PronadjiStudenta("PR83/2020", out trazeni, token);
                        Console.WriteLine(trazeni.ToString());
                    }
                    catch (FaultException<BezbednosniIzuzetak> bex)
                    {
                        Console.WriteLine(bex.Detail.Razlog);
                    }
                    catch (FaultException<StudentskaSluzbaIzuzetak> ex)
                    {
                        Console.WriteLine(ex.Detail.Razlog);
                    }

                    // Dodati studenta broj 3
                    try
                    {
                        Console.WriteLine("Dodajem studenta broj 3");
                        proksi.DodajStudenta(new Student("PR53/2020", "Nebojsa", "Stojanovic", DateTime.Now), token);
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
                        proksi.IzmeniStudenta(new Student("PR14/2020", "Janko", "Markovic", DateTime.Now), token);
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
                        proksi.IzbrisiStudenta("PR83/2020", token);
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
                        proksi.PronadjiStudenta("PR83/2020", out trazeni, token);
                        Console.WriteLine(trazeni.ToString());
                    }
                    catch (FaultException<BezbednosniIzuzetak> bex)
                    {
                        Console.WriteLine(bex.Detail.Razlog);
                    }
                    catch (FaultException<StudentskaSluzbaIzuzetak> ex)
                    {
                        Console.WriteLine(ex.Detail.Razlog);
                    }

                    // Izmeniti studenta broj 3
                    try
                    {
                        Console.WriteLine("Menjam studenta broj 3");
                        proksi.IzmeniStudenta(new Student("PR53/2020", "Janko", "Dragovic", DateTime.Now), token);
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
                        proksi.IzmeniStudenta(new Student("PR14/2020", "Jelena", "Markovic", DateTime.Now), token);
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
                        Console.WriteLine(proksi.IspisiSveStudente(token));
                    }
                    catch (FaultException<BezbednosniIzuzetak> bex)
                    {
                        Console.WriteLine(bex.Detail.Razlog);
                    }
                    catch (FaultException<StudentskaSluzbaIzuzetak> ex)
                    {
                        Console.WriteLine(ex.Detail.Razlog);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                // Sleep 10 sekundi
                Thread.Sleep(10000);
            }
        }
    }
}
