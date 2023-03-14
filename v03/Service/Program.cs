using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;
using System.ServiceModel;


namespace Service
{
    public class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = new ServiceHost(typeof(FizickaLicaServis));

            string address = "net.tcp://localhost:4000/ServisFizickihLica";
            sh.AddServiceEndpoint(typeof(IFizickaLica), new NetTcpBinding(), address);
            sh.Open();

            Console.WriteLine("Servis je uspesno pokrenut.");
            Console.ReadKey();
        }
    }
}
