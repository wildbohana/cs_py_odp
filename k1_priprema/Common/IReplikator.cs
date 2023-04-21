using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

// Dobijaš ovo (bez atributa iznad)
// Izmenjene su metode, dodala sam proxy kao argument

namespace Common
{
    [ServiceContract]
    public interface IReplikator
    {
        [OperationContract]
        [FaultContract(typeof(StudentskaSluzbaIzuzetak))]
        void Posalji(IStudentskaSluzba proxy, List<Student> studenti);

        [OperationContract]
        [FaultContract(typeof(StudentskaSluzbaIzuzetak))]
        List<Student> Preuzmi(IStudentskaSluzba proxy, DateTime vremeReplikacije);
    }
}
