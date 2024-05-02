using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Eccezioni
    {
        //valore data non corretto
        public static void IncorrectDateValue(string ex)
        {
            Console.WriteLine();
            // Gestisce l'eccezione FormatException con un messaggio personalizzato
            Console.WriteLine($"Si è verificato un errore: Formato data non valido {ex}");
            
        }

    }
}
