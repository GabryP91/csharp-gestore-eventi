/*
 
Immaginate di lavorare in una software house, che ha diversi clienti. Vi è stato commissionato da parte della vostra azienda la creazione di un gestionale eventi
per eventi come concerti, conferenze, spettacoli,… per un suo cliente. 
Il cliente necessita di un semplice programma senza interfaccia grafica (ossia che venga eseguito in console o terminale) che si occupa di:
-	Memorizzare e tenere traccia di tutti gli eventi in futuro che ha programmato
-	Poter gestire le prenotazioni e le disdette delle sue conferenze e tenere traccia quindi dei posti prenotati e di quelli disponibili per un dato evento
-	Poter gestire un intero programma di Eventi (ossia tenere traccia di tutti gli eventi che afferiscono a serie di Conferenze)


MILESTONE 1
Per prima cosa è necessario creare una classe Evento che abbia i seguenti attributi:
●	titolo
●	data
●	capienza massima dell’evento
●	numero di posti prenotati

Aggiungere metodi getter e setter in modo che:
●	titolo sia in lettura e in scrittura
●	data sia in lettura e scrittura
●	numero di posti per la capienza massima sia solo in lettura
●	numero di posti prenotati sia solo in lettura

ai setters inserire gli opportuni controlli in modo che la data non sia già passata, 
che il titolo non sia vuoto e che la capienza massima di posti sia un numero positivo.
In caso contrario sollevare opportune eccezioni.

Dichiarare un costruttore che prenda come parametri il titolo, la data e i posti a disposizione e inizializza gli opportuni attributi facendo uso dei metodi e controlli già fatti.
Per l’attributo posti prenotati invece si occupa di inizializzarlo lui a 0.

Vanno inoltre implementati dei metodi public che svolgono le seguenti funzioni:

1.	PrenotaPosti: aggiunge i posti passati come parametro ai posti prenotati. Se l’evento è già passato o non ha posti o non ha più posti disponibili deve sollevare un’eccezione.
2.	DisdiciPosti: riduce del i posti prenotati del numero di posti indicati come parametro. Se l’evento è già passato o non ci sono i posti da disdire sufficienti, deve sollevare un’eccezione.
3.	l’override del metodo ToString() in modo che venga restituita una stringa contenente: data formattata – titolo
Per formattare la data correttamente usate nomeVariabile.ToString("dd/MM/yyyy"); applicata alla vostra variabile DateTime.

Le eccezioni possono essere generiche (Exception) o usate quelle già messe a disposizione da C#, ma aggiungete un eventuale messaggio chiaro per comunicare che cosa è successo.

Vi ricordo che man mano che andrete avanti con le altre milestones, potrete aggiungere più avanti altri eventuali metodi (public e private) che vi aiutino a svolgere le funzioni
richieste se ritenete necessari! 


MILESTONE 2

1.	Nel vostro programma principale Program.cs, chiedete all’utente di inserire un nuovo evento con tutti i parametri richiesti dal costruttore.
2.	Dopo che l’evento è stato istanziato, chiedete all’utente se e quante prenotazioni vuole fare e provare ad effettuarle.
3.	Stampare a video il numero di posti prenotati e quelli disponibili.
4.	Ora chiedere all’utente fintanto che lo desidera, se e quanti posti vuole disdire. Ogni volta che disdice dei posti, stampare i posti residui e quelli prenotati. 


Attenzione: In questa prima fase non è necessario gestire le eventuali eccezioni da Program.cs che potrebbero insorgere, 
eventualmente il programma si blocca se qualcosa va storto che voi avevate già previsto. 
Piuttosto pensate bene alla logica del vostro programma principale e della vostra classe Evento pensando bene alle responsabilità dei metodi e alla visibilità di attributi e metodi.

 
*/

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //variabile per continuare a inserire nuovi eventi

            bool continuaEventi = true;

            List<Evento> listaEventi = new List<Evento>();

            //ciclo whileper continuare a inserire nuovi eventi
            while (continuaEventi)
            {
                Console.Write("\n\nVuoi inserire un nuovo evento? (s/n): ");

                //legge una riga di testo inserita dall'utente tramite la console e la converte in una stringa in minuscolo.
                string risposta1 = Console.ReadLine().ToLower();

                if (risposta1 == "s")
                {
                    try
                    {

                        Console.WriteLine("\n\n*********INSERIRE NUOVO EVENTO:*********");

                        //acquisisco titolo
                        Console.Write("Titolo: ");
                        string titolo = Console.ReadLine();

                        //acquisisco data converte la stringa letta in un oggetto DateTime tramite "ParseExact" che richiede il formato esatto (dd/MM/yyyy) da tastiera
                        Console.Write("Data (formato dd/MM/yyyy): ");
                        //DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                        string data = Console.ReadLine();

                        //acquisisco capienza per tale evento
                        Console.Write("Numero di posti disponibili: ");
                        int capienza = int.Parse(Console.ReadLine());

                        // Creazione dell'evento con i parametri passati dall'utente
                        Evento nuovoEvento = new Evento(titolo, data, capienza);

                        //aggiungo il nuovo evento alla mia lista eventi
                        listaEventi.Add(nuovoEvento);


                        //variabile per continuare a inserire nuove prenotazioni
                        bool continuaPrenotazioni = true;

                        //ciclo while per continuare a inserire nuove prenotazioni
                        while (continuaPrenotazioni)
                        {
                            Console.Write("\nVuoi prenotare dei posti? (s/n): ");

                            //legge una riga di testo inserita dall'utente tramite la console e la converte in una stringa in minuscolo.
                            string risposta2 = Console.ReadLine().ToLower();

                            if (risposta2 == "s")
                            {
                                Console.Write("\nQuanti posti vuoi prenotare? ");

                                int postiDaPrenotare = int.Parse(Console.ReadLine());

                                //aggiungo posti valore selezionato a numero di posti già prenotati
                                nuovoEvento.PrenotaPosti(postiDaPrenotare);

                                //stampo totale posti prenotati (aggiornato)
                                Console.WriteLine($"\nPosti prenotati: {nuovoEvento.Prenotati}");

                                //stampo capienza massima (aggiornata)
                                Console.WriteLine($"\nPosti disponibili: {nuovoEvento.Capienza - nuovoEvento.Prenotati}");

                            }

                            else if (risposta2 == "n")
                            {
                                continuaPrenotazioni = false;
                            }

                            else
                            {
                                Console.WriteLine("Risposta non valida. Digitare s oppure n.");
                            }
                        }

                        // Richiesta di input per disdire posti
                        bool continuaDisdette = true;

                        //ciclo while per continuare a disdire le prenotazioni del singolo evento
                        while (continuaDisdette)
                        {
                            Console.Write("\nVuoi disdire dei posti? (s/n): ");

                            //legge una riga di testo inserita dall'utente tramite la console e la converte in una stringa in minuscolo.
                            string risposta2 = Console.ReadLine().ToLower();

                            if (risposta2 == "s")
                            {
                                Console.Write("Quanti posti vuoi disdire? ");

                                int postiDaDisdire = int.Parse(Console.ReadLine());

                                //disdico tot numero posti 
                                nuovoEvento.DisdiciPosti(postiDaDisdire);

                                //stampo totale posti prenotati (aggiornato)
                                Console.WriteLine($"\nPosti prenotati: {nuovoEvento.Prenotati}");

                                //stampo capienza massima (aggiornata)
                                Console.WriteLine($"\nPosti disponibili: {nuovoEvento.Capienza - nuovoEvento.Prenotati}");

                            }

                            else if (risposta2 == "n")
                            {
                                continuaDisdette = false;
                            }

                            else
                            {
                                Console.WriteLine("Risposta non valida. Digitare s oppure n.");
                            }
                        }


                    }

                    

                    catch (Exception ex)
                    {
                        Console.WriteLine($"Si è verificato un errore: {ex.Message}");
                    }
                }

                else if (risposta1 == "n")
                {
                    continuaEventi = false;
                }

                else
                {
                    Console.WriteLine("Risposta non valida. Digitare s oppure n.");
                }

            }
           
       
        }
    }
}
