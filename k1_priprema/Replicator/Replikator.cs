using Common;
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Ovo praviš sama

namespace Replicator
{
    public class Replikator : IReplikator
    {
        private DateTime vremePoslednjeReplikacije = DateTime.Today;

        // Metode
        public List<Student> Preuzmi(IStudentskaSluzba kIzvor, DateTime vremeReplikacije)
        {
            List<Student> retVal = kIzvor.ReplicirajStudente(vremePoslednjeReplikacije);
            vremePoslednjeReplikacije = vremeReplikacije;

            int cnt = retVal.Count;
            Console.WriteLine($"Preuzeto je {cnt} izmenjenih podataka.");

            return retVal;
        }

        public void Posalji(IStudentskaSluzba kOdrediste, List<Student> studenti)
        {
            int cnt = studenti.Count;
            kOdrediste.IzmeniRepliciraneStudente(studenti);
            Console.WriteLine($"Poslato je {cnt} novih podataka.");
        }
    }
}
