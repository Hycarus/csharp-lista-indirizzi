namespace csharp_lista_indirizzi;

class Program
{

    // BONUS POMERIDIANO

    static char[,] board = new char[3, 3];
    static char currentPlayer = 'A';

    //


    static void Main(string[] args)
    {
        string path = "/Users/mirko/boolean/DotNet/csharp-lista-indirizzi/addresses.csv";
        string path2 = "/Users/mirko/boolean/DotNet/csharp-lista-indirizzi/addresses2.csv";
        var indirizzi = LeggiDaTesto(path);
        foreach (var indirizzo in indirizzi)
        {
            Console.WriteLine($"Ecco l'indirizzo {indirizzo}");
        }
        ScriviInTesto(indirizzi, path2);

        // BONUS POMERIDIANO

        CreateBoard();
        bool IsGameWon = false;

        while (!IsGameWon && !IsBoardFull())
        {
            PrintBoard();
            PlayerMove();
            IsGameWon = CheckWin();
            SwitchPlayer();
        }

        PrintBoard();

        if (IsGameWon)
        {
            SwitchPlayer();
            Console.WriteLine($"Giocatore {currentPlayer} ha vinto!");
        }
        else
        {
            Console.WriteLine("La partita finisce in parità");
        }

        //
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

    // Bonus

    public static void ScriviInTesto(List<Indirizzo> indirizzi, string path)
    {
        using StreamWriter stream = File.CreateText(path);
        foreach (var indirizzo in indirizzi)
            stream.WriteLine(indirizzo.ToString());
    }


    // BONUS POMERIDIANO

    static void CreateBoard()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                board[row, col] = ' ';
            }
        }
    }

    static void PrintBoard()
    {
        Console.WriteLine("# | 1 | 2 | 3 |");
        Console.WriteLine("-----------------");
        for (int row = 0; row < 3; row++)
        {
            Console.Write($"{row + 1} | ");
            for (int col = 0; col < 3; col++)
            {
                Console.Write(board[row, col] == ' ' ? " " : board[row, col].ToString());
                if (col < 2)
                {
                    Console.Write(" | ");
                }
            }
            Console.WriteLine(" |");
            if (row < 2)
            {
                Console.WriteLine("-----------------");
            }
        }
    }

    static bool IsBoardFull()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (board[row, col] == ' ')
                {
                    return false;
                }
            }
        }
        return true;
    }

    static void SwitchPlayer()
    {
        currentPlayer = (currentPlayer == 'A') ? 'B' : 'A';
    }

    static void PlayerMove()
    {
        int row, col;

        while (true)
        {
            Console.WriteLine($"Giocatore {currentPlayer} inserisci la tua mossa (ad esempio: 1-2)");
            string input = Console.ReadLine();
            string[] parts = input.Split('-');

            if (parts.Length == 2 && int.TryParse(parts[0], out row) && int.TryParse(parts[1], out col))
            {
                row--;
                col--;

                if (row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == ' ')
                {
                    board[row, col] = currentPlayer;
                    break;
                }
                else
                {
                    Console.WriteLine("Mossa non valida, prova di nuovo");
                }
            }
            else
            {
                Console.WriteLine("Mossa non valida, prova di nuovo");
            }
        }
    }

    static bool CheckWin()
    {
        for (int row = 0; row < 3; row++)
        {
            if (board[row, 0] == currentPlayer && board[row, 1] == currentPlayer && board[row, 2] == currentPlayer)
            {
                return true;
            }
        }

        for (int col = 0; col < 3; col++)
        {
            if (board[0, col] == currentPlayer && board[1, col] == currentPlayer && board[2, col] == currentPlayer)
            {
                return true;
            }
        }

        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
        {
            return true;
        }

        if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
        {
            return true;
        }

        return false;
    }
}