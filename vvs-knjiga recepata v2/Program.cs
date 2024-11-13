using vvs_knjiga_recepata_v2;

class Program
{
    static void Main(string[] args)
    {

        // Kreiranje instance knjige recepata
        KnjigaRecepata knjigaRecepata = KnjigaRecepata.Instance;



        Console.WriteLine("Dobrodošli! Šta želite danas kuhati?");
        Console.WriteLine("Odaberite opciju:");
        Console.WriteLine("1. Pogledajte sve recepte");
        Console.WriteLine("2. Pretražite recept po nazivu");
        Console.WriteLine("3. Pretražite recepte na osnovu kategorije (slatko/slano)");
        Console.WriteLine("4. Izaberite sastojke na osnovu kojih ćemo Vam predložiti jela");

        //ovo u petlju staviti 
        int opcija;
        if (int.TryParse(Console.ReadLine(), out opcija))
        {
            switch (opcija)
            {
                case 1:
                    // Prikaz svih recepata
                    List<Recept> sviRecepti = knjigaRecepata.DohvatiSveRecepte();
                    Console.WriteLine("Svi recepti:");
                    foreach (var recept in sviRecepti)
                    {
                        knjigaRecepata.ipisiRecept(recept);
                    }
                    break;

                case 2:
                    // Pretraga po nazivu
                    Console.WriteLine("Unesite naziv recepta:");
                    string naziv = Console.ReadLine();
                    var pronadjeniRecepti = knjigaRecepata.PretraziPoNazivu(naziv);
                    Console.WriteLine($"Pronađeno recepata: {pronadjeniRecepti.Count}");
                    foreach (var recept in pronadjeniRecepti)
                    {
                        knjigaRecepata.ipisiRecept(recept);
                    }
                    break;

                case 3:
                    // Pretraga po kategoriji
                    Console.WriteLine("Izaberite kategoriju: \n1. Slatko\n2. Slano");
                    string izborKategorije = Console.ReadLine();

                    string kategorija = string.Empty;
                    if (izborKategorije == "1")
                    {
                        kategorija = "slatko";
                    }
                    else if (izborKategorije == "2")
                    {
                        kategorija = "slano";
                    }
                    

                    Console.WriteLine("Izaberite sekundarni kriterijum za sortiranje: \n1. Vreme pripreme\n2. Kalorije\n3. Broj sastojaka");
                    string izborKriterijuma = Console.ReadLine();

                    string sekundarniKriterijum = null;
                    if (izborKriterijuma == "1")
                    {
                        sekundarniKriterijum = "vrijeme";
                    }
                    else if (izborKriterijuma == "2")
                    {
                        sekundarniKriterijum = "kalorije";
                    }
                    else if (izborKriterijuma == "3")
                    {
                        sekundarniKriterijum = "sastojci";
                    }
                    
                    List<Recept> filtriraniRecepti = knjigaRecepata.SortirajRecepte(kategorija, sekundarniKriterijum);
                    Console.WriteLine($"Pronađeno recepata: {filtriraniRecepti.Count}");
                    foreach (var recept in filtriraniRecepti)
                    {
                        knjigaRecepata.ipisiRecept(recept);
                    }
                    break;

                case 4:
                    // Filtriranje na osnovu sastojaka
                    Console.WriteLine("Unesite sastojke (odvojene zarezom):");
                    string sastojciInput = Console.ReadLine();
                    var sastojci = sastojciInput.Split(',');
                    var korisnickiSastojci = new List<Sastojak>();
                    foreach (var sastojakIme in sastojci)
                    {
                        korisnickiSastojci.Add(new Sastojak { ImeSastojka = sastojakIme.Trim() });
                    }

                    var predlozeniRecepti = knjigaRecepata.FiltrirajPoSastojcima(korisnickiSastojci);
                    Console.WriteLine($"Pronađeno recepata: {predlozeniRecepti.Count}");
                    foreach (var recept in predlozeniRecepti)
                    {
                        knjigaRecepata.ipisiRecept(recept);
                    }
                    break;

                default:
                    Console.WriteLine("Nepoznata opcija. Pokušajte ponovo.");
                    break;
            }
        }
        










        /*
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
        */

    }
}
