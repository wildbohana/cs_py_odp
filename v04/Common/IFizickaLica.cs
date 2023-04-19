using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IFizickaLica
    {
        [OperationContract]
        [FaultContract(typeof(ServisFizickihLicaIzuzetak))]
        void DodajLice(FizickoLice fizickoLice);

        [OperationContract]
        [FaultContract(typeof(ServisFizickihLicaIzuzetak))]
        void ObrisiLice(long jmbg);

        [OperationContract]
        List<FizickoLice> SpisakLica();
    }
}
