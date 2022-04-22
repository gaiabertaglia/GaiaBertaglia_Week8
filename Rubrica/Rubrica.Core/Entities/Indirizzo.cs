using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.Entities
{
    public class Indirizzo
    {
        public int IdIndirizzo { get; set; }
        public string Tipologia { get; set; }
        public string Via { get; set; }
        public string Citta { get; set; }
        public int CAP { get; set; }
        public string Provincia { get; set; }
        public string Nazione { get; set; }

        // FK Id del contatto associato alla via
        public int IdContatto { get; set; }

        public Indirizzo()
        {

        }
        public Indirizzo(string tipologia, string via, string citta, int cap, string provincia, string nazione, int idContatto)
        {
            Tipologia = tipologia;
            Via = via;
            Citta = citta;
            CAP = cap;
            Provincia = provincia;
            Nazione = nazione;
            IdContatto = idContatto;

        }

        public Indirizzo(int idIndirizzo, string tipologia, string via, string citta, int cap, string provincia, string nazione, int idContatto)
        {
            IdIndirizzo = idIndirizzo;
            Tipologia = tipologia;
            Via = via;
            Citta = citta;
            CAP = cap;
            Provincia = provincia;
            Nazione = nazione;
            IdContatto = idContatto;
        }

        public override string ToString()
        {
            return $"ID Indirizzo: {IdIndirizzo} - Tipologia: {Tipologia} - Via: {Via} - Città: {Citta} - CAP: {CAP} - Provincia: {Provincia} - " +
                $"Nazione: {Nazione} - ID Contatto: {IdContatto}";
        }

    }
}
