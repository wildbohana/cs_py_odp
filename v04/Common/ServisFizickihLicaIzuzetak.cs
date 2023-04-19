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
        // Polje - iz kog razloga je bačen izuzetak
        string razlog;

        // Propertiji (public metode) imaju [DataMember] atribute
        [DataMember]
        public string Razlog { get => razlog; set => razlog = value; }

        // Konstruktor
        public ServisFizickihLicaIzuzetak(string razlog)
        {
            Razlog = razlog;
        }
    }
}
