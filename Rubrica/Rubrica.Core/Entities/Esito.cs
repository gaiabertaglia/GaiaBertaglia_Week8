using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.Entities
{
    public class Esito
    {
        public bool IsOk { get; set; }
        public string Messaggio { get; set; }

        public Esito()
        {

        }
        public Esito(bool isOK, string messaggio)
        {
            IsOk = isOK;
            Messaggio = messaggio;
        }
    }
}
