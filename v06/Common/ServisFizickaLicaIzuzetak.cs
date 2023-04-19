using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    // Za klase ide [DataContract]
    [DataContract]
    public class ServisFizickaLicaIzuzetak
    {
        string razlog;

        [DataMember]
        public string Razlog { get => razlog; set => razlog = value; }
    }
}
