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

 
*/

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Evento evento = new Evento("pippo", new DateTime(2024, 05, 10),-2);



            }
            catch (Exception ex)
            {
                Console.WriteLine($"Si è verificato un errore: {ex.Message}");
            }
           
            
        }
    }
}
