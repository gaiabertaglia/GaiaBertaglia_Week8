using Rubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        // Contiene i metodi usati nel menù
        List<Contatto> GetAllContatti();
        Esito InserisciNuovoContatto(Contatto nuovoContatto);
        Esito InserisciNuovoIndirizzo(Indirizzo indirizzoNew);
        List<Indirizzo> GetAllIndirizzi();
        Esito TrovaContatto(int idContattoNew);
        List<Indirizzo> CercaIndirizziContatto(int idContatto);
        Esito EliminaContatto(List<Indirizzo> indirizziContatto, int idContatto);
    }
}
