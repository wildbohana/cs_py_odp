using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    // Interfejsi imaju [ServiceContract]
    [ServiceContract]
    public interface IBezbednosniMehanizmi
    {
        // Autentifikacija može da izbaci izuzetak ako nisu dobri kredencijali
        [OperationContract]
        [FaultContract(typeof(BezbednosniIzuzetak))]
        string Autentifikacija(string korisnickoIme, string lozinka);
    }
}
