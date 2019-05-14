using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.DataBaseSteps;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;

using System.Collections.Generic;

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
        [Category("VerificarAcessos")]
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
        [Category("VerificarAcessos")]
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
        [Category("VerificarAcessos")]
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
        [Category("VerificarAcessos")]
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
        [Category("VerificarAcessos")]
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
        [Category("TokenDeApi")]
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
        [Category("TokenDeApi")]
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
        [Category("ValidarCampoAdicionarPerfil")]
        public void VerificarCampoObrigatorioPlataformaAdicionarPerfil()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            accountPageFlows.ClicarPerfil("","123","7");
            
            Assert.AreEqual("Please fill out this field.", accountPage.GetMsgObrigatorioPlataforma("validationMessage"));
        }

        [Test]
        [Category("ValidarCampoAdicionarPerfil")]
        public void VerificarCampoObrigatorioOSAdicionarPerfil()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            accountPageFlows.ClicarPerfil("Test", "", "7");
            
            Assert.AreEqual("Please fill out this field.", accountPage.GetMsgObrigatorioOS("validationMessage"));
        }

        [Test]
        [Category("ValidarCampoAdicionarPerfil")]
        public void VerificarCampoObrigatorioVersaoOsAdicionarPerfil()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            accountPageFlows.ClicarPerfil("Test", "Test Os","");
           
            Assert.AreEqual("Please fill out this field.", accountPage.GetMsgObrigatorioVersao("validationMessage"));
        }

        [Test]
        [Category("CRUDPerfil")]
        public void AdicionarPerfil()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;           
            
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            accountPageFlows.ClicarPerfil(accountPage.plataforma, accountPage.so , accountPage.versao);

            Assert.AreEqual(accountPage.plataforma, accountPage.retornaValor());
            
            Assert.True(accountPage.RetornaPerfisAdicionado().Contains(accountPage.GetValorPerfilAdicionado()));

        }

        [Test]
        [Category("CRUDPerfil")]
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
