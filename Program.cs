using System;
using System.Collections.Generic;

class Program
{
    static Random random = new Random();

    static List<string> nomi = new List<string> { "Marco", "Anna", "Luca", "Giulia", "Stefano", "Elisa", "Paolo", "Sara", "Andrea", "Martina" };
    static List<string> cognomi = new List<string> { "Rossi", "Bianchi", "Verdi", "Galli", "Ferrari", "Russo", "Colombo", "Romano", "Moretti", "Barbieri" };
    static List<string> cibi = new List<string> { "Pizza Margherita", "Pizza Diavola", "Focaccia normale", "Focaccia con cipolle", "Focaccia con olive", "Salame", "Mortadella", "Ricotta", "Coca-Cola", "Fanta", "Succo di frutta", "Birra", "Acqua" };
    static List<string> allergie = new List<string> { "Lattosio", "Glutine", "Frutta secca", "Nessuna" };
    static List<string> giorniSettimana = new List<string> { "Lunedì", "Martedì", "Mercoledì", "Giovedì", "Venerdì" };

    class Collega
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Eta { get; set; }
        public List<string> PreferenzeCibo { get; set; }
        public string Allergia { get; set; }
        public decimal ContributoBudget { get; set; }
        public string GiornoPreferito { get; set; }
    }

    class Festino
    {
        public string Data { get; set; }
        public List<Collega> Invitati { get; set; }
        public decimal Budget { get; set; }

        public Festino(string data, List<Collega> invitati)
        {
            Data = data;
            Invitati = invitati;
            Budget = CalcolaBudget(invitati);
        }

        private decimal CalcolaBudget(List<Collega> invitati)
        {
            decimal totale = 0;
            foreach (var collega in invitati)
            {
                totale += collega.ContributoBudget;
            }
            return totale;
        }

        public void StampaDettagli()
        {
            Console.WriteLine($"Festino il {Data}, Budget: {Budget:C}");
            Console.WriteLine("Partecipanti:");
            foreach (var collega in Invitati)
            {
                Console.WriteLine($"- {collega.Nome} {collega.Cognome} (Giorno preferito: {collega.GiornoPreferito})");
            }
        }
    }

    static void Main()
    {
        List<Collega> colleghi = GeneraColleghi(5);
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Console.WriteLine("Elenco dei colleghi e preferenze:");
        foreach (var collega in colleghi)
        {
            Console.WriteLine($"{collega.Nome} {collega.Cognome}, {collega.Eta} anni, preferisce {string.Join(", ", collega.PreferenzeCibo)}, allergia: {collega.Allergia}, contribuisce con: {collega.ContributoBudget:C}, giorno preferito: {collega.GiornoPreferito}");
        }

        Festino festino = new Festino("Venerdì", colleghi);
        festino.StampaDettagli();
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
            decimal contributoCasuale = random.Next(15, 50); // Minimo 15€
            string giornoCasuale = giorniSettimana[random.Next(giorniSettimana.Count)];

            colleghi.Add(new Collega
            {
                Nome = nomeCasuale,
                Cognome = cognomeCasuale,
                Eta = etaCasuale,
                PreferenzeCibo = preferenzeCibo,
                Allergia = allergiaCasuale,
                ContributoBudget = contributoCasuale,
                GiornoPreferito = giornoCasuale
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
