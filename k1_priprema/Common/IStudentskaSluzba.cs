using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

// Dobijaš ovo (bez atributa iznad)
// Dodate su: jedna metoda za ispis svih, dve metode za replikator

namespace Common
{
    [ServiceContract]
    public interface IStudentskaSluzba
    {
        [OperationContract]
        [FaultContract(typeof(StudentskaSluzbaIzuzetak))]
        [FaultContract(typeof(BezbednosniIzuzetak))]
        void DodajStudenta(Student student, string token);

        [OperationContract]
        [FaultContract(typeof(StudentskaSluzbaIzuzetak))]
        [FaultContract(typeof(BezbednosniIzuzetak))]
        void IzmeniStudenta(Student student, string token);

        [OperationContract]
        [FaultContract(typeof(StudentskaSluzbaIzuzetak))]
        [FaultContract(typeof(BezbednosniIzuzetak))]
        bool PronadjiStudenta(string index, out Student student, string token);

        [OperationContract]
        [FaultContract(typeof(StudentskaSluzbaIzuzetak))]
        [FaultContract(typeof(BezbednosniIzuzetak))]
        bool IzbrisiStudenta(string index, string token);

        // Dodato za ispis
        [OperationContract]
        [FaultContract(typeof(StudentskaSluzbaIzuzetak))]
        [FaultContract(typeof(BezbednosniIzuzetak))]
        string IspisiSveStudente(string token);

        // Dodato za replikator
        [OperationContract]
        [FaultContract(typeof(StudentskaSluzbaIzuzetak))]
        void IzmeniRepliciraneStudente(List<Student> studenti);

        [OperationContract]
        [FaultContract(typeof(StudentskaSluzbaIzuzetak))]
        List<Student> ReplicirajStudente(DateTime vremeReplikacije);
    }
}
