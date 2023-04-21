using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

// Ovo sama praviš

namespace Common
{
    [DataContract]
    public class StudentskaSluzbaIzuzetak
    {
        string razlog;

        [DataMember]
        public string Razlog { get => razlog; set => razlog = value; }
    }
}
