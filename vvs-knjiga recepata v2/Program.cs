using vvs_knjiga_recepata_v2;

class Program
{
    static void Main(string[] args)
    {
        // Definisanje 10 sastojaka
        var sastojci = new List<Sastojak>
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

        // Kreiranje pojedinacnih recepata
        var recepti = new List<Recept>
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

        // Kreiranje knjige recepata i dodavanje recepata
        KnjigaRecepata knjigaRecepata = new KnjigaRecepata();
        foreach (var recept in recepti)
        {
            knjigaRecepata.DodajRecept(recept);
        }

        // ispis recepata
        Console.WriteLine("Recepti i sastojci:");
        foreach (var recept in recepti)
        {
            Console.WriteLine($"{recept.Naziv} (sastojci: {string.Join(", ", recept.Sastojci.Select(s => $"{s.Sastojak.ImeSastojka} - {s.Kolicina} {s.Sastojak.MjernaJedinica}"))})");
        }

        // testovi  (različit broj sastojaka)
        var korisnickiZahtjevi = new List<List<Sastojak>>
        {
            new List<Sastojak> { sastojci[10] }, 
            new List<Sastojak> { sastojci[1], sastojci[2], sastojci[3] }, 
            new List<Sastojak> { sastojci[4], sastojci[5], sastojci[6], sastojci[7] }, 
            new List<Sastojak> { sastojci[0], sastojci[1], sastojci[2], sastojci[4], sastojci[5] }, 
            new List<Sastojak> { sastojci[1], sastojci[3], sastojci[4], sastojci[6], sastojci[8], sastojci[9] }
        };

        //  filtriranja recepata po zahtjevima
        foreach (var korisnickiZahtjev in korisnickiZahtjevi)
        {
            var filtriraniRecepti = knjigaRecepata.FiltrirajPoSastojcima(korisnickiZahtjev);
            Console.WriteLine($"Filtrirani recepti za sastojke: {string.Join(", ", korisnickiZahtjev.Select(s => s.ImeSastojka))}");
            foreach (var recept in filtriraniRecepti)
            {
                Console.WriteLine($"- {recept.Naziv}");
            }
        }

        // Interaktivno pretraživanje recepata po imenu
        Console.WriteLine("Unesite naziv recepta za pretragu (ili pritisnite Enter da preskočite):");
        string nazivRecepta = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(nazivRecepta))
        {
            var pronadjeniReceptiPoImenu = knjigaRecepata.PretraziPoImenu(nazivRecepta);
            Console.WriteLine($"\nRecepti koji sadrže '{nazivRecepta}' u nazivu:");
            foreach (var recept in pronadjeniReceptiPoImenu)
            {
                Console.WriteLine($"- {recept.Naziv}");
            }
        }
        else
        {
            Console.WriteLine("Nijedan naziv nije unesen za pretragu po imenu.");
        }

        // Interaktivno pretraživanje recepata po sastojcima sa uslovom da ima barem 50% odgovarajućih sastojaka
        Console.WriteLine("\nUnesite nazive sastojaka za pretragu, odvojene zarezom (npr. 'Brašno, Jaje'):");
        string sastojciInput = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(sastojciInput))
        {
            var naziviSastojaka = sastojciInput.Split(',').Select(s => s.Trim()).ToList();
            var trazeniSastojci = sastojci
                .Where(s => naziviSastojaka.Contains(s.ImeSastojka))
                .ToList();

            if (trazeniSastojci.Any())
            {
                var pronadjeniReceptiPoSastojcima = knjigaRecepata.FiltrirajPoSastojcima(trazeniSastojci);
                Console.WriteLine("\nRecepti koji sadrže barem 50% unesenih sastojaka:");
                foreach (var recept in pronadjeniReceptiPoSastojcima)
                {
                    Console.WriteLine($"- {recept.Naziv}");
                }
            }
            else
            {
                Console.WriteLine("Nijedan uneseni sastojak nije pronađen u listi sastojaka.");
            }
        }
        else
        {
            Console.WriteLine("Nijedan sastojak nije unesen za pretragu po sastojcima.");
        }


    }
}
