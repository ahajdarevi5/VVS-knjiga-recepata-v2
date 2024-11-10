using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vvs_knjiga_recepata_v2
{
    public class Recept
    {
        public string Naziv { get; set; }
        public int VrijemePripreme { get; set; }
        public int Kalorije { get; set; }
        public Kategorija Kategorija { get; set; }
        public List<KolSastojaka> Sastojci { get; set; } = new List<KolSastojaka>();

        public void DodajSastojak(KolSastojaka sastojak) => Sastojci.Add(sastojak);

        public Recept IzracunajKolicinu(int brojOsoba)
        {
            var prilagodjenRecept = new Recept
            {
                Naziv = this.Naziv,
                VrijemePripreme = this.VrijemePripreme,
                Kalorije = this.Kalorije,
                Kategorija = this.Kategorija,
                Sastojci = this.Sastojci.Select(s => new KolSastojaka
                {
                    Sastojak = s.Sastojak,
                    Kolicina = s.IzracunajKolicinu(brojOsoba)
                }).ToList()
            };
            return prilagodjenRecept;
        }
    }
}