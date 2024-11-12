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

        public List<Recept> FiltrirajPoSastojcima(List<Sastojak> korisnickiSastojci)
        {
            List<Recept> filtriraniRecepti = new List<Recept>();

            foreach (var recept in recepti)
            {
               
                int brojOdgovarajucihSastojaka = recept.Sastojci.Count(ks =>
                    korisnickiSastojci.Any(korisnickiSastojak => korisnickiSastojak.ImeSastojka == ks.Sastojak.ImeSastojka));

                
                double procenatOdgovarajucih = (double)brojOdgovarajucihSastojaka / korisnickiSastojci.Count * 100;

               
                if (procenatOdgovarajucih >= 50)
                {
                    filtriraniRecepti.Add(recept);
                }
            }

            return filtriraniRecepti;
        }

        // Metoda za pretragu po imenu
        public List<Recept> PretraziPoImenu(string naziv)
        {
            return recepti.Where(recept => recept.Naziv.Contains(naziv, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // Metoda za pretragu po sastojcima
        public List<Recept> PretraziPoSastojcima(List<Sastojak> trazeniSastojci)
        {
            return recepti.Where(recept =>
                trazeniSastojci.All(trazeni =>
                    recept.Sastojci.Any(rs => rs.Sastojak.ImeSastojka == trazeni.ImeSastojka)
                )
            ).ToList();
        }

    }







}

