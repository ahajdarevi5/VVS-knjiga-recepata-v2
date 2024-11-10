using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vvs_knjiga_recepata_v2
{
    public class KnjigaRecepata
    {
        private List<Recept> recepti = new List<Recept>();
        public void DodajRecept(Recept recept) => recepti.Add(recept);
        public void IzbrisiRecept(Recept recept) => recepti.Remove(recept);
        /*sortiraj, pretrazi po imenu, filtrirajposastojcima*/
    }
}
