using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi
{
    internal class Evento
    {

        //***********ATTRIBUTI***************************
        private string titolo;

        private DateTime data;

        private int capienza;

        private int postiPrenotati;

        //***********PROPERTIES***************************
        public string Titolo
        {
            get { return titolo; }

            set {

                titolo = value; 
            }
        }

        public DateTime Data
        {
            // restituisco la data 
            get { return data; }

            set
            {

                // Assegno il valore della data solo se passa i vari controlli
                data = value;
            }
        

        }

        public int Capienza
        {
            get { return capienza; }

            private set
            {
                capienza = value;
            }
        }

        public int Prenotati
        {
            get { return postiPrenotati; }

        }

        //***********METODI***************************

        //Implemento il costruttore impostando a 0 la capienza qualora non sia stata definita dall'utente
        public Evento(string titolo, DateTime data, int capienza = 0)
        {

            this.Titolo = titolo;

            this.Data = data;

            this.Capienza = capienza;

            this.postiPrenotati = 0;


        }

        //funzione per la prenotazione dei posti ad un evento
        public void PrenotaPosti(int numPrenotazioni)
        {
            //se nel momento della prenotazione dei posti, la data risulta superiore alla data dell'evento stesso
            if(DateTime.Now > data)
            {
                Console.WriteLine();

                //Sollevo un'eccezione custom se la prenotazione riguarda una data passata 
                throw new DataPassataException();

            }

            //se il numero delle prenotazioni risulta minore o uguale a zero
            if (numPrenotazioni <= 0)
            {
                Console.WriteLine();
                //sollevo la specifica eccezione "modificata" di quando viene passato un argomento non valido
                throw new ArgumentException("Numero di posti prenotati non può essere minore o uguale a zero");

            }

            // aggiorno i posti disponibili
            int postiDisponibili = capienza - postiPrenotati;

            //se non vi sono più posti disponibili
            if (postiDisponibili < numPrenotazioni)
            {
                Console.WriteLine();
                //sollevo la specifica eccezione "modificata" di quando si tenta di eseguire un'operazione che non è valida nel contesto corrente
                throw new InvalidOperationException("Non ci sono abbastanza posti disponibili per il numero di prenotazioni richieste.");

            }

            //aggiorno i posti prenotati
            postiPrenotati += numPrenotazioni;

        }

        //funzione per disdire un tot numero di posti
        public void DisdiciPosti(int numDisdette)
        {
            //se nel momento della disdetta dei posti, la data risulta superiore alla data dell'evento stesso
            if (DateTime.Now > data)
            {
                Console.WriteLine();
                //sollevo la specifica eccezione "modificata" di quando si tenta di eseguire un'operazione che non è valida nel contesto corrente
                throw new InvalidOperationException("Impossibile disdire posti per un evento passato.");
            }

            //se il numero delle disdette risulta minore o uguale a zero
            if (numDisdette <= 0)
            {
                Console.WriteLine();
                //sollevo la specifica eccezione "modificata" di quando viene passato un argomento non valido
                throw new ArgumentException("Numero di posti da disdire non può essere minore o uguale a zero");
            }

            //se il numero delle disdette risulta maggiore del numero di prenotazioni
            if (postiPrenotati < numDisdette)
            {
                Console.WriteLine();
                //sollevo la specifica eccezione "modificata" di quando si tenta di eseguire un'operazione che non è valida nel contesto corrente
                throw new InvalidOperationException("Non ci sono abbastanza posti prenotati da disdire.");
                
            }


            //aggiorno i posti prenotati
            postiPrenotati -= numDisdette;

        }

        //override del metodo ToString
        public override string ToString()
        {
            return $"{data.ToString("dd/MM/yyyy")} - {titolo}";
        }

    }
}
