using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vvs_knjiga_recepata_v2
{
    public class KnjigaRecepata
    {
        private static KnjigaRecepata _instance;
        private List<Recept> recepti = new List<Recept>();
        private List<Sastojak> sastojci = new List<Sastojak>();


        private KnjigaRecepata()
        {
            sastojci = new List<Sastojak>
            {
                new Sastojak { ImeSastojka = "Šećer", MjernaJedinica = MjernaJedinica.Kilogram },
                new Sastojak { ImeSastojka = "Brašno", MjernaJedinica = MjernaJedinica.Kilogram },
                new Sastojak { ImeSastojka = "Jaje", MjernaJedinica = MjernaJedinica.Komad },
                new Sastojak { ImeSastojka = "Mlijeko", MjernaJedinica = MjernaJedinica.Litar },
                new Sastojak { ImeSastojka = "Puter", MjernaJedinica = MjernaJedinica.Kilogram },
                new Sastojak { ImeSastojka = "Sol", MjernaJedinica = MjernaJedinica.Kilogram },
                new Sastojak { ImeSastojka = "Prašak za pecivo", MjernaJedinica = MjernaJedinica.Kilogram },
                new Sastojak { ImeSastojka = "Voda", MjernaJedinica = MjernaJedinica.Litar },
                new Sastojak { ImeSastojka = "Sirće", MjernaJedinica = MjernaJedinica.Litar },
                new Sastojak { ImeSastojka = "Ulje", MjernaJedinica = MjernaJedinica.Litar },
                new Sastojak { ImeSastojka = "Vanilin secer", MjernaJedinica = MjernaJedinica.Litar }
            };

            recepti = new List<Recept>
            {
                new Recept
                {
                    Naziv = "Palačinke",
                    Sastojci = new List<KolSastojaka>
                    {
                        new KolSastojaka { Sastojak = sastojci[1], Kolicina = 200 },
                        new KolSastojaka { Sastojak = sastojci[2], Kolicina = 2 },
                        new KolSastojaka { Sastojak = sastojci[3], Kolicina = 0.5 },
                        new KolSastojaka { Sastojak = sastojci[4], Kolicina = 100 },
                        new KolSastojaka { Sastojak = sastojci[5], Kolicina = 5 }
                    }
                },
                new Recept
                {
                    Naziv = "Kolač",
                    Sastojci = new List<KolSastojaka>
                    {
                        new KolSastojaka { Sastojak = sastojci[0], Kolicina = 100 },
                        new KolSastojaka { Sastojak = sastojci[1], Kolicina = 300 },
                        new KolSastojaka { Sastojak = sastojci[2], Kolicina = 3 },
                        new KolSastojaka { Sastojak = sastojci[4], Kolicina = 150 },
                        new KolSastojaka { Sastojak = sastojci[6], Kolicina = 10 }
                    }
                },
                new Recept
                {
                    Naziv = "Omlet",
                    Sastojci = new List<KolSastojaka>
                    {
                        new KolSastojaka { Sastojak = sastojci[2], Kolicina = 2 },
                        new KolSastojaka { Sastojak = sastojci[4], Kolicina = 50 },
                        new KolSastojaka { Sastojak = sastojci[5], Kolicina = 3 },
                        new KolSastojaka { Sastojak = sastojci[9], Kolicina = 10 },
                        new KolSastojaka { Sastojak = sastojci[7], Kolicina = 0.1 }
                    }
                },
                new Recept
                {
                    Naziv = "Tjestenina",
                    Sastojci = new List<KolSastojaka>
                    {
                        new KolSastojaka { Sastojak = sastojci[1], Kolicina = 200 },
                        new KolSastojaka { Sastojak = sastojci[7], Kolicina = 0.5 },
                        new KolSastojaka { Sastojak = sastojci[8], Kolicina = 5 },
                        new KolSastojaka { Sastojak = sastojci[9], Kolicina = 20 },
                        new KolSastojaka { Sastojak = sastojci[5], Kolicina = 5 }
                    }
                },
                new Recept
                {
                    Naziv = "Salata",
                    Sastojci = new List<KolSastojaka>
                    {
                        new KolSastojaka { Sastojak = sastojci[3], Kolicina = 0.2 },
                        new KolSastojaka { Sastojak = sastojci[4], Kolicina = 20 },
                        new KolSastojaka { Sastojak = sastojci[5], Kolicina = 2 },
                        new KolSastojaka { Sastojak = sastojci[8], Kolicina = 10 },
                        new KolSastojaka { Sastojak = sastojci[9], Kolicina = 15 }
                    }
                }
            };
        }
        public static KnjigaRecepata Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new KnjigaRecepata();
                }
                return _instance;
            }
        }

        //funkcionalnost: get recepti
        public List<Recept> DohvatiSveRecepte()
        {
            return recepti;
        }
        public void ipisiRecept(Recept recept)
        {
            Console.WriteLine($"Naziv: {recept.Naziv}");
            Console.WriteLine($"Kategorija: {recept.Kategorija}");
            Console.WriteLine($"Vreme pripreme: {recept.VrijemePripreme} minuta");
            Console.WriteLine($"Kalorije: {recept.Kalorije}");

            Console.WriteLine("Sastojci:");
            foreach (var kolSastojka in recept.Sastojci)
            {
                Console.WriteLine($"- {kolSastojka.Sastojak.ImeSastojka} - {kolSastojka.Kolicina} {kolSastojka.Sastojak.MjernaJedinica}");
            }

            Console.WriteLine("\n------------------------------------\n");
        }

        //funkcionalnost: dodaj/obrisi recept
        public void DodajRecept(Recept recept) => recepti.Add(recept);
        public void IzbrisiRecept(Recept recept) => recepti.Remove(recept);
        
        //funkcionalnost: filtriraj po korisnikovim sastojcima
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

        // funkcionalnost: pretraga recepata po nazivu
        public List<Recept> PretraziPoNazivu(string naziv)
        {
            return recepti.Where(recept => recept.Naziv.Contains(naziv, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // funkcionalnost: pretraga recepata po slatko/slano, a zatim ukoliko je naveden i dodatni parametar
        public List<Recept> SortirajRecepte(string kategorija, string? sekundarniKriterijum = null)
        {
            var filtriraniRecepti = recepti.Where(recept =>
                (kategorija == "slatko" && recept.Kategorija == Kategorija.Slatko) ||
                (kategorija == "slano" && recept.Kategorija == Kategorija.Slano)
            ).ToList();

            if (sekundarniKriterijum != null)
            {
                filtriraniRecepti = filtriraniRecepti.OrderBy(recept =>
                {
                    switch (sekundarniKriterijum)
                    {
                        case "vrijeme":
                            return recept.VrijemePripreme;
                        case "kalorije":
                            return recept.Kalorije;
                        case "sastojci":
                            return recept.Sastojci.Count;
                        default:
                            throw new ArgumentException("Nepoznat kriterijum za sortiranje.");
                    }
                }).ToList();
            }

            return filtriraniRecepti;
        }



        /* Metoda za pretragu po sastojcima
        public List<Recept> PretraziPoSastojcima(List<Sastojak> trazeniSastojci)
        {
            return recepti.Where(recept =>
                trazeniSastojci.All(trazeni =>
                    recept.Sastojci.Any(rs => rs.Sastojak.ImeSastojka == trazeni.ImeSastojka)
                )
            ).ToList();
        }*/

    }







}

