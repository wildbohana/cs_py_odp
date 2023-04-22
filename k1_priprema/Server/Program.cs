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
            using (ServiceHost host = new ServiceHost(typeof(StudentskaSluzba)), hostRepl = new ServiceHost(typeof(Replikator)))
            {
                host.Open();
                hostRepl.Open();

                Console.WriteLine("Server je pokrenut.");
                Console.WriteLine("Studentska služba: " + host.BaseAddresses.FirstOrDefault());
                Console.WriteLine("Replikator: " + hostRepl.BaseAddresses.FirstOrDefault());

                Console.WriteLine("Pritisnite [ENTER] za zaustavljanje servera.");
                Console.ReadKey();
                hostRepl.Close();
                host.Close();
            }
        }
    }
}
