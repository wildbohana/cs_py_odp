using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class ServisFizickihLicaIzuzetak
    {
        string razlog;

        [DataMember]
        public string Razlog { get => razlog; set => razlog = value; }

        public ServisFizickihLicaIzuzetak(string razlog)
        {
            Razlog = razlog;
        }
    }
}
