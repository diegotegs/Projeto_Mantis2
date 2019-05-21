using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;


namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    class PlanningTest : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] PlanningPage planningPage;
        #endregion

        [Test]
        [Category("AcessarAbas")]
        public void VerificarPlanejamentoIndisponivel()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            string msgError = "Nenhum planejamento disponível";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            planningPage.ClicarPlanejamento();

            Assert.That(planningPage.RetornoPlanejamentoIndisponivel().Contains(msgError));

        }
    }
}
