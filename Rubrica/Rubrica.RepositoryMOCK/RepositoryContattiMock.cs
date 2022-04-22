using Rubrica.Core;
using Rubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.RepositoryMOCK
{
    public class RepositoryContattiMock : IRepositoryContatti
    {
        public static List<Contatto> Contatti = new List<Contatto>()
        {
            new Contatto(1, "Marcella", "Bianchi"),
            new Contatto(2, "Sergio", "Catozzi"),
            new Contatto(3, "Laura", "Belli"),
            new Contatto(4, "Sara", "Fiori"),

        };

        public Contatto Add(Contatto item)
        {
            if (Contatti.Count == 0)
            {
                item.Id = 1;
            }
            else 
            {
                int maxId = 1;
                foreach (var c in Contatti)
                {
                    if (c.Id > maxId)
                    {
                        maxId = c.Id;
                    }
                }
                item.Id = maxId + 1;
            }
            Contatti.Add(item);
            return item;
        }

        public Contatto Delete(Contatto item)
        {
            Contatti.Remove(item);
            return item;
        }

        public List<Contatto> GetAll()
        {
            return Contatti;
        }

        public Contatto GetById(int id)
        {
            foreach (var item in Contatti)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
