﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(FizickaLicaServer)))
            {
                //host.AddServiceEndpoint(typeof(IFizickaLica), new NetTcpBinding(), new Uri("net.tcp://localhost:4000/IFizickaLica"));
                host.Open();
                Console.WriteLine("Servis je uspešno pokrenut");

                // Kraj
                Console.WriteLine("\nPritisnite [ENTER] da zaustavite rad servera.");
                Console.ReadKey();
            }
        }
    }
}
