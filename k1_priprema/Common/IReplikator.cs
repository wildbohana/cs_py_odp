using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [ServiceContract]
    public interface IReplikator
    {
        [OperationContract]
        void Posalji(List<Student> studenti);
        [OperationContract]
        List<Student> Preuzmi(DateTime vremeReplikacije);
    }
}
