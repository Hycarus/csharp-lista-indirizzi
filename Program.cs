namespace csharp_lista_indirizzi;

class Program
{
    static void Main(string[] args)
    {
        string path = "/Users/mirko/boolean/DotNet/csharp-lista-indirizzi/addresses.csv";
        string path2 = "/Users/mirko/boolean/DotNet/csharp-lista-indirizzi/addresses2.csv";
        var indirizzi = LeggiDaTesto(path);
        foreach(var indirizzo in indirizzi)
        {
            Console.WriteLine($"Ecco l'indirizzo {indirizzo}");
        }
        ScriviInTesto(indirizzi, path2);
    }

    public static List<Indirizzo> LeggiDaTesto(string path)
    {
        List<Indirizzo> indirizzi = new();
        var stream = File.OpenText(path);
        int i = 0;
        while (!stream.EndOfStream)
        {
            var linea = stream.ReadLine();
            i++;
            if (i <= 1)
                continue;
            try
            {
                var dati = linea?.Split(',');

                if (dati.Length < 6)
                {
                    Console.WriteLine($"Riga {i} non valida: dati mancanti.");
                }

                string name = dati[0];
                string surname = dati[1];
                string street = dati[2];
                string city = dati[3];
                string province = dati[4];
                int zip;

                bool zipConversionSuccess = int.TryParse(dati[5], out zip);

                if (!zipConversionSuccess)
                {
                    Console.WriteLine($"Riga {i} contiene un valore di ZIP non valido: '{dati[5]}'.");
                }

                Indirizzo l = new(name, surname, street, city, province, zip);
                indirizzi.Add(l);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Errore alla linea {i}: {e.Message}");
                Console.WriteLine($"Contenuto della linea: {linea}");
            }
        }

        stream.Dispose();
        return indirizzi;
    }

    public static void ScriviInTesto(List<Indirizzo> indirizzi, string path)
    {
        using StreamWriter stream = File.CreateText(path); 
        foreach (var indirizzo in indirizzi)
            stream.WriteLine(indirizzo.ToString());
    }
}

