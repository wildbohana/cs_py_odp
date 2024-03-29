﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IStudentskaSluzba
    {
        [OperationContract]
        [FaultContract(typeof(BezbednosniIzuzetak))]
        [FaultContract(typeof(StudentskaSluzbaIzuzetak))]
        void DodajStudenta(Student student, string token);

        [OperationContract]
        [FaultContract(typeof(BezbednosniIzuzetak))]
        [FaultContract(typeof(StudentskaSluzbaIzuzetak))]
        void IzmeniStudenta(Student student, string token);

        [OperationContract]
        [FaultContract(typeof(BezbednosniIzuzetak))]
        bool PronadjiStudenta(string index, out Student student, string token);

        [OperationContract]
        [FaultContract(typeof(BezbednosniIzuzetak))]
        bool IzbrisiStudenta(string index, string token);

        [OperationContract]
        [FaultContract(typeof(BezbednosniIzuzetak))]
        string IspisiSveStudente(string token);
    }
}
