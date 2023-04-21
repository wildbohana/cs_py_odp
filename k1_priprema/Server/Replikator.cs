using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Replikator : IReplikator
    {
        public List<Student> Preuzmi(DateTime vremeReplikacije)
        {
            List<Student> retVal = new List<Student>();

            foreach (Student s in BazaPodataka.Studenti.Values)
                if (s.VremePoslednjeIzmene >= vremeReplikacije)
                    retVal.Add(s);

            Console.WriteLine("Replicirano je " + retVal.Count + " studenta.");
            return retVal;
        }

        public void Posalji(List<Student> studenti)
        {
            int cnt = 0;
            foreach (Student s in studenti)
            {
                BazaPodataka.Studenti[s.BrIndeksa] = s;
                cnt++;
            }

            Console.WriteLine("Ažurirano je " + cnt + " studenata.");
        }
    }
}
