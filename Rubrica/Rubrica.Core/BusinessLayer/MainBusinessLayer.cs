using Rubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryContatti contattiRepo;
        private readonly IRepositoryIndirizzi indirizziRepo;


        public MainBusinessLayer(IRepositoryContatti contatti, IRepositoryIndirizzi indirizzi)
        {
            contattiRepo = contatti;
            indirizziRepo = indirizzi;
        }

        public List<Indirizzo> CercaIndirizziContatto(int idContatto)
        {
            List<Indirizzo> listaIndirizzi = new List<Indirizzo>();
            List<Indirizzo> listaIndirizziConContatto = indirizziRepo.GetAll();

            foreach (var item in listaIndirizziConContatto)
            {
                if (item.IdContatto == idContatto)
                {
                    listaIndirizzi.Add(item);
                }
            }
            return listaIndirizzi;
        }

        public Esito EliminaContatto(List<Indirizzo> indirizziContatto, int idContatto)
        {
            Contatto contattoTrovato = contattiRepo.GetById(idContatto);
            
            if (indirizziContatto.Count == 0)
            {
                contattiRepo.Delete(contattoTrovato);
                return new Esito(true, "Contatto eliminato");
            }
            return new Esito(false, "Non è stato possibile eliminare il contatto perchè è associato ad uno o più indirizzi");
        }

        public List<Contatto> GetAllContatti()
        {
            return contattiRepo.GetAll();
        }

        public List<Indirizzo> GetAllIndirizzi()
        {
            return indirizziRepo.GetAll();
        }

        public Esito InserisciNuovoContatto(Contatto nuovoContatto)
        {
            Contatto contattoRecuperato = contattiRepo.GetById(nuovoContatto.Id);
            if (contattoRecuperato == null)
            {
                contattiRepo.Add(nuovoContatto);
                return new Esito(true, "Contatto aggiungo correttamente");
            }
            return new Esito(false, "Impossibile aggiungere il contatto perchè esiste già un contatto con quell'Id");
        }

        public Esito InserisciNuovoIndirizzo(Indirizzo indirizzoNew)
        {
            Indirizzo indirizzoRecuperato = indirizziRepo.GetById(indirizzoNew.IdIndirizzo);
            if (indirizzoRecuperato == null)
            {
                indirizziRepo.Add(indirizzoNew);
                return new Esito(true, "Indirizzo aggiungo correttamente");
            }
            return new Esito(false, "Impossibile aggiungere l'indirizzo perchè esiste già un indirizzo con quell'id");
        }

        public Esito TrovaContatto(int idContattoNew)
        {
            Contatto contattoEsiste = contattiRepo.GetById(idContattoNew);
            if (contattoEsiste == null)
            {
                return new Esito(false, "Contatto non trovato");
            }
            return new Esito(true, "Contatto esistente");
        }
    }
}
