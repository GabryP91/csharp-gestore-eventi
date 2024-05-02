using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace csharp_gestore_eventi
{
    internal class ProgrammaEventi
    {
        //***********PROPERTIES***************************
        public string Titolo { get; private set; }

        private List<Evento> eventi;

        //***********METODI***************************

        //costruttore
        public ProgrammaEventi(string titolo)
        {
            Titolo = titolo;
            eventi = new List<Evento>();
        }

        //inserimento evento in lista
        public void AddEvento(Evento nuovoEvento)
        {
            eventi.Add(nuovoEvento);
        }

        //funzione per trovare tot eventi in base alla data
        public List<Evento> TrovaEventiPerData(DateTime data)
        {
            //creo nuova lista 
            List<Evento> eventiNellaData = new List<Evento>();

            foreach (Evento evento in eventi)
            {

                if (evento.Data == data)
                {
                    eventiNellaData.Add(evento);
                }
            }

            //restituisco lista filtrata con la data scelta
            return eventiNellaData;
        }

        //funzione che restituisce a video una stringa formattatta con data,titolo e numero posti disponibili
        public static string StampaEventi(List<Evento> listaEventi)
        {
            string result = "";
            foreach (Evento evento in listaEventi)
            {
                result += $"{evento.Data.ToString("dd/MM/yyyy")} - {evento.Titolo} - Numero Posti disponibili:{evento.Capienza}\n";
            }
            return result;
        }

        //funzione che restituisce il numero degli eventi in programma
        public int NumEventi()
        {
            return eventi.Count;
        }

        //funzione che svuota la lista degli eventi
        public void SvuotaEventi()
        {
            eventi.Clear();
        }

        //override funzione Tostring
        public override string ToString()
        {
            string result = $"Nome programma evento: {Titolo}\n";
            foreach (Evento evento in eventi)
            {
                result += $"{evento.Data} - {evento.Titolo}\n";
            }
            return result;
        }
    }
}
