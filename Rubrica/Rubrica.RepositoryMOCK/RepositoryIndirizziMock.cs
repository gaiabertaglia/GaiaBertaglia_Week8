using Rubrica.Core;
using Rubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.RepositoryMOCK
{
    public class RepositoryIndirizziMock : IRepositoryIndirizzi
    {
        private static List<Indirizzo> Indirizzi = new List<Indirizzo>()
        {
            new Indirizzo(1, "Domicilio", "Viale Italia", "Firenze", 44132, "FI", "Italia", 1),
            new Indirizzo(2, "Domicilio", "Viale XX Settembre", "Mantova", 44155, "MA", "Italia", 2),
            new Indirizzo(3, "Residenza", "Viale XXV Aprile", "Ravenna", 44123, "RA", "Italia", 2),
            
        };
        public Indirizzo Add(Indirizzo item)
        {
            if (Indirizzi.Count == 0)
            {
                item.IdIndirizzo = 1;
            }
            else
            {
                int maxId = 1;
                foreach (var i in Indirizzi)
                {
                    if (i.IdIndirizzo > maxId)
                    {
                        maxId = i.IdIndirizzo;
                    }
                }
                item.IdIndirizzo = maxId + 1;
            }
            Indirizzi.Add(item);
            return item;
        }
               

        public List<Indirizzo> GetAll()
        {
            return Indirizzi;
        }

        public Indirizzo GetById(int id)
        {
            foreach (var item in Indirizzi)
            {
                if (item.IdIndirizzo == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
