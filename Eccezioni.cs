using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    public class Eccezzioni : Exception
    {
        public Eccezzioni() : base() { }

        public Eccezzioni(string message) : base(message) { }

    }

    public class DataPassataException : Eccezzioni
    {
        public DataPassataException() : base("Impossibile creare un evento con una data passata.") { }
    }

    public class FindDataPassataException : Eccezzioni
    {
        public FindDataPassataException() : base("La data passata è inferiore alla data corrente.") { }
    }

    public class DataOutException : Eccezzioni
    {
        public DataOutException() : base("La data non è nel formato accettabile (dd/MM/yyyy)") { }
    }

    public class TitoloVuotoException : Eccezzioni
    {
        public TitoloVuotoException() : base("Il titolo dell'evento non può essere vuoto.") { }
    }

    public class CapienzaNonValidaException : Eccezzioni
    {
        public CapienzaNonValidaException() : base("La capienza massima deve essere un numero positivo.") { }
    }
}
