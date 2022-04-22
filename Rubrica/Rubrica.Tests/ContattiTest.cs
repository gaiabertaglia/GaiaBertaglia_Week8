using Rubrica.Core.BusinessLayer;
using Rubrica.Core.Entities;
using Rubrica.RepositoryADO;
using Rubrica.RepositoryMOCK;
using Xunit;

namespace Rubrica.Tests
{
    public class ContattiTest
    {
        IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiMock(), new RepositoryIndirizziMock());
        // IBusinessLayer bl = new MainBusinessLayer(new RepositoryContattiAdo(), new RepositoryIndirizziAdo());

        [Fact]
        public void ShouldAddContact()
        {
            Contatto nuovoContatto = new Contatto("Maria", "Novella");
            
            //ACT
            Esito e = bl.InserisciNuovoContatto(nuovoContatto);

            //ASSERT
            Assert.True(e.IsOk == true);

        }
    }
}