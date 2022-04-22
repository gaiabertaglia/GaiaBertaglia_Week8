using Rubrica.Core.BusinessLayer;
using Rubrica.Core.Entities;
using Rubrica.RepositoryADO;
using Rubrica.RepositoryMOCK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Presentation
{
    internal static class Menu
    {
        // private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiMock(), new RepositoryIndirizziMock());
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiAdo(), new RepositoryIndirizziAdo());

        internal static void Start()
        {
            bool continua = true;

            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    VisualizzaContatti();
                    break;
                case 2:
                    AggiungiNuovoContatto();
                    break;
                case 3:
                    AggiungiNuovoIndirizzo();
                    break;
                case 4:
                    EliminaContatto();
                    break;                
                case 0:
                    Console.WriteLine("Arrivederci, a presto!");
                    return false;
                default:
                    Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
                    break;
            }
            return true;
        }

        private static void EliminaContatto()
        {
            // Elimina contatto solo se non ha indirizzi associati
            VisualizzaContatti();

            Esito esisteContatto = new Esito();
            int idContatto;
            do
            {
                string msg = "Quale contatto desideri eliminare? Inserisci l'Id: ";
                idContatto = InserisciNumeroPositivo(msg);

                esisteContatto = bl.TrovaContatto(idContatto);

            } while (!esisteContatto.IsOk);

            List<Indirizzo> indirizziContatto = bl.CercaIndirizziContatto(idContatto);            

            Esito esitoEliminazione = bl.EliminaContatto(indirizziContatto, idContatto);

            Console.WriteLine(esitoEliminazione.Messaggio);

        }
                

        private static void AggiungiNuovoIndirizzo()
        {
            // Tipologia, via, citta, cap, provincia, nazione, id contatto

            // Chiedi il contatto per primo, in modo da non far fallire l'inserimento alla fine

            VisualizzaContatti();
            Esito esisteContatto = new Esito();
            int idContattoNew;
            do
            {
                string msg = "Inserisci ID Contatto: ";
                idContattoNew = InserisciNumeroPositivo(msg);

                esisteContatto = bl.TrovaContatto(idContattoNew);

            } while (!esisteContatto.IsOk);
                      
            
            Console.WriteLine("Inserisci tipologia (domicilio/residenza): ");
            string tipologiaNew = Console.ReadLine();

            Console.WriteLine("Inserisci la via: ");
            string viaNew = Console.ReadLine();

            Console.WriteLine("Inserisci la città: ");
            string cittaNew = Console.ReadLine();

            int capNew;
            do
            {
                Console.WriteLine("Inserisci il CAP: ");

            } while (!(int.TryParse(Console.ReadLine(), out capNew)));
            
            Console.WriteLine("Inserisci Provincia");
            string provinciaNew = Console.ReadLine();

            Console.WriteLine("Inserisci nazione: ");
            string nazioneNew = Console.ReadLine();            

            Indirizzo indirizzoNew = new Indirizzo(tipologiaNew, viaNew, cittaNew, capNew, provinciaNew, nazioneNew, idContattoNew);

            Esito esitoInsert = bl.InserisciNuovoIndirizzo(indirizzoNew);
            Console.WriteLine(esitoInsert.Messaggio);
            
            // Posso mostrare la lista degli indirizzi alla fine dell'operazione
            VisualizzaIndirizzi();
            
        }

        private static int InserisciNumeroPositivo(string msg)
        {
            int numero;
            do
            {
                Console.WriteLine(msg);

            } while (!(int.TryParse(Console.ReadLine(), out numero)));
            return numero;
        }   

        private static void VisualizzaIndirizzi()
        {
            List<Indirizzo> indirizzi = bl.GetAllIndirizzi();
            if (indirizzi.Count == 0)
            {
                Console.WriteLine("Nessun indirizzo presente");
            }
            else
            {
                foreach (var item in indirizzi)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void AggiungiNuovoContatto()
        {
            Console.WriteLine("Inserisci il nome: ");
            string nomeNuovo = Console.ReadLine();

            Console.WriteLine("Inserisci il cognome: ");
            string cognomeNuovo = Console.ReadLine();

            Contatto nuovoContatto = new Contatto(nomeNuovo, cognomeNuovo);
            Esito esitoInserimento = bl.InserisciNuovoContatto(nuovoContatto);

            Console.WriteLine(esitoInserimento.Messaggio);
        }

        private static void VisualizzaContatti()
        {
            List<Contatto> contatti = bl.GetAllContatti();
            if (contatti.Count == 0)
            {
                Console.WriteLine("Nessun contatto presente");
            }
            else
            {
                foreach (var item in contatti)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static int SchermoMenu()
        {
            Console.WriteLine("******************RUBRICA*****************");            
            Console.WriteLine("1.Visualizza Contatti");
            Console.WriteLine("2.Inserisci nuovo Contatto");
            Console.WriteLine("3.Aggiungi nuovo Indirizzo");
            Console.WriteLine("4.Elimina Contatto");

            Console.WriteLine("0. EXIT");

            int scelta;
            Console.WriteLine("Inserisci la tua scelta: ");
            while (!(int.TryParse(Console.ReadLine(), out scelta) /*&& scelta >=0 && scelta <= 1*/))
            {
                Console.WriteLine("Scelta errata. Inserisci scelta corretta: ");
            }

            return scelta;
        }
    }
}
