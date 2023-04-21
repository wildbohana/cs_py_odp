using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

// Dobijaš ovo (bez atributa iznad)

namespace Common
{
    [ServiceContract]
    public interface IBezbednosniMehanizmi
    {
        [OperationContract]
        [FaultContract(typeof(BezbednosniIzuzetak))]
        string Autentifikacija(string korisnickoIme, string lozinka);
    }
}
