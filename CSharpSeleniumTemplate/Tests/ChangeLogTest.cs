using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;


namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
   public class ChangeLogTest : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] ChangeLogPage changeLogPage;        
        #endregion

        [Test]
        [Category("VerificarMenuRegistroAusente")]
        public void VerificarAusenciaDeRegistroDeMudanca()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            string msgEsperada = "Nenhum registro de mudança disponível";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            changeLogPage.ClicarMenuRegistroDeMudanca();            
            Assert.That(changeLogPage.RetornarMsg().Contains(msgEsperada));


        }

    }
}
