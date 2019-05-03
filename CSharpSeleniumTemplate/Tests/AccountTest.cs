using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;

namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    public class AccountTest : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] AccountPage accountPage;
        [AutoInstance] LoginFlows loginFlows;
        #endregion

        [Test]
        public void VerificarAbaMinhaConta()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            accountPage.ClicarAlterarConta();
            Assert.True(accountPage.GetBotaoAtualizarUsuario());
        }

        [Test]
        public void VerificarAbaPreferencias()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            accountPage.ClicarAlterarConta();
            accountPage.ClicarPreferencias();
            Assert.True(accountPage.GetBotaoAtualizarPreferencias());
        }

        [Test]
        public void VerificarAbaGerenciarColunas()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            accountPage.ClicarAlterarConta();
            accountPage.ClicarGerenciarColunas();
            Assert.True(accountPage.GetBotaoAtualizarColunas());
        }

    }
}
