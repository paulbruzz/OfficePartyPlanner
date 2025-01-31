using System;
using System.Collections.Generic;

class Program
{
    static Random random = new Random();

    static List<string> nomi = new List<string> { "Marco", "Anna", "Luca", "Giulia", "Stefano", "Elisa", "Paolo", "Sara", "Andrea", "Martina" };
    static List<string> cognomi = new List<string> { "Rossi", "Bianchi", "Verdi", "Galli", "Ferrari", "Russo", "Colombo", "Romano", "Moretti", "Barbieri" };
    static List<string> cibi = new List<string> { "Pizza Margherita", "Pizza Diavola", "Focaccia normale", "Focaccia con cipolle", "Focaccia con olive", "Salame", "Mortadella", "Ricotta", "Coca-Cola", "Fanta", "Succo di frutta", "Birra", "Acqua" };
    static List<string> allergie = new List<string> { "Lattosio", "Glutine", "Frutta secca", "Nessuna" };

    class Collega
    {
        public string? Nome { get; set; }
        public string? Cognome { get; set; }
        public int Eta { get; set; }
        public List<string>? PreferenzeCibo { get; set; }
        public string? Allergia { get; set; }
        public decimal ContributoBudget { get; set; }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        List<Collega> colleghi = GeneraColleghi(5);
        Console.WriteLine("Elenco dei colleghi e preferenze:");
        foreach (var collega in colleghi)
        {
            
            Console.WriteLine($"{collega.Nome} {collega.Cognome}, {collega.Eta} anni, preferisce {string.Join(", ", collega.PreferenzeCibo!)}, allergia: {collega.Allergia}, contribuisce con: {collega.ContributoBudget:C}");
        }
    }

    static List<Collega> GeneraColleghi(int numero)
    {
        List<Collega> colleghi = new List<Collega>();
        for (int i = 0; i < numero; i++)
        {
            string nomeCasuale = nomi[random.Next(nomi.Count)];
            string cognomeCasuale = cognomi[random.Next(cognomi.Count)];
            int etaCasuale = random.Next(20, 60);
            List<string> preferenzeCibo = GeneraPreferenzeCibo();
            string allergiaCasuale = allergie[random.Next(allergie.Count)];
            decimal contributoCasuale = random.Next(15, 30); // Minimo 15€

            colleghi.Add(new Collega
            {
                Nome = nomeCasuale,
                Cognome = cognomeCasuale,
                Eta = etaCasuale,
                PreferenzeCibo = preferenzeCibo,
                Allergia = allergiaCasuale,
                ContributoBudget = contributoCasuale
            });
        }
        return colleghi;
    }

    static List<string> GeneraPreferenzeCibo()
    {
        int numeroPreferenze = random.Next(3, 9); // Minimo 3, massimo 8
        List<string> preferenze = new List<string>();
        List<string> cibiDisponibili = new List<string>(cibi);

        for (int i = 0; i < numeroPreferenze; i++)
        {
            if (cibiDisponibili.Count == 0) break;
            int indice = random.Next(cibiDisponibili.Count);
            preferenze.Add(cibiDisponibili[indice]);
            cibiDisponibili.RemoveAt(indice);
        }
        return preferenze;
    }
}
