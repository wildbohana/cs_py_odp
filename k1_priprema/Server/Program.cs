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
            // Moraš oba hosta otvoriti ovde
            using (ServiceHost host = new ServiceHost(typeof(StudentskaSluzbaServer)), hostRepl = new ServiceHost(typeof(Replikator)))
            {
                host.Open();
                hostRepl.Open();

                Console.WriteLine("Servis je uspešno pokrenut ");
                Console.WriteLine("Studentska služba : " + host.BaseAddresses.FirstOrDefault());
                Console.WriteLine("Replikator : " + hostRepl.BaseAddresses.FirstOrDefault());

                Console.WriteLine("\nPritisni [ENTER] za prekid rada servera.\n");
                Console.ReadKey();
                hostRepl.Close();
                host.Close();
            }
        }
    }
}
