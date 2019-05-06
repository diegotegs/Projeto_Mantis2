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
        [AutoInstance] AccountPageFlows accountPageFlows;
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

        [Test]
        public void VerificarAbaPerfil()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            accountPage.ClicarAlterarConta();
            accountPage.ClicarPerfil();
            Assert.That(accountPage.ValidarAbaPerfil());
        }

        [Test]
        public void VerificarAbaTokenApi()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            accountPage.ClicarAlterarConta();
            accountPage.ClicarEmTokenApi();
            Assert.True(accountPage.ValidarAbaTokenApi());
        }
        [Test]
        public void CriarTokenApi()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            accountPage.ClicarAlterarConta();
            accountPage.ClicarEmTokenApi();
            accountPage.PreecherCampoNomeToken(GeneralHelpers.ReturnStringWithRandomCharacters(3));
            accountPage.ClicarCriarTokenApi();
            Assert.AreEqual("Tenha em conta que este token só será exibido uma vez.", accountPage.ValidarRetornoCriarToken());
        }

        [Test]
        public void RevogarToken()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            accountPage.ClicarAlterarConta();
            accountPage.ClicarEmTokenApi();
            Assume.That(accountPage.VerificarSeExisteToken());
            accountPage.GetTokenRevogado();
            accountPage.ClicarEmRevogar();
            Assert.AreEqual("O Token API \"" + accountPage.tokenRevoked + "\" foi revogado.", accountPage.ValidarRetornoRevogarToken());
        }

        [Test]
        public void VerificarCampoObrigatorioPlataformaAdicionarPerfil()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            accountPageFlows.ClicarPerfil("","123","7");
            
            Assert.AreEqual("Preencha este campo.",accountPage.GetMsgObrigatorioPlataforma("validationMessage"));
        }

        [Test]
        public void VerificarCampoObrigatorioOSAdicionarPerfil()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            accountPageFlows.ClicarPerfil("Test", "", "7");
            
            Assert.AreEqual("Preencha este campo.", accountPage.GetMsgObrigatorioOS("validationMessage"));
        }

        [Test]
        public void VerificarCampoObrigatorioVersaoOsAdicionarPerfil()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            accountPageFlows.ClicarPerfil("Test", "Test Os","");
           
            Assert.AreEqual("Preencha este campo.", accountPage.GetMsgObrigatorioVersao("validationMessage"));
        }

        [Test]
        public void AdicionarPerfil()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            accountPageFlows.ClicarPerfil(accountPage.plataforma, accountPage.so, accountPage.versao);
            
            Assert.True(accountPage.RetornaPerfisAdicionado().Contains(accountPage.GetValorPerfilAdicionado()));
        }

        [Test]
        public void ApagarPerfil()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            

            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            accountPage.ClicarAlterarConta();
            accountPage.ClicarPerfil();
            Assume.That(accountPage.VerificarExistenciaDePerfil());
            accountPage.RetornaQuantidadeDeOpcoesNoComboBox();
            accountPage.SelecionarPerfil();            
            accountPage.ClicarEmApagar();
            accountPage.ClicarEnviar();
            Assert.Greater(accountPage.amountOption , accountPage.restOption);
            
        }


    }
}
