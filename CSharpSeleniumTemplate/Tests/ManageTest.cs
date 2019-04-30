using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    public class ManageTest : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] ManagePage managePage;
        [AutoInstance] LoginFlows loginFlows;
        #endregion

        [Test]
        public void VerificarAbaGerenciarUsuario()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            managePage.ClicarMenuGerenciar();
            managePage.ClicarGerenciarUsuario();
            Assert.That(managePage.VerificarExistenciaDoBotaoCriarNovaConta());
        }

        [Test]
        public void VerificarAbaGerenciarProjetos()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            managePage.ClicarMenuGerenciar();
            managePage.ClicarGerenciarProjeto();
            Assert.That(managePage.VerificarExistenciaDoBotaoCriarNovaProjeto());
        }

        [Test]
        public void VerificarAbaGerenciarMarcadores()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            managePage.ClicarMenuGerenciar();
            managePage.ClicarGerenciarMarcadores();
            Assert.That(managePage.VerificarExistenciaDoLinkTodos());
        }

        [Test]
        public void VerificarAbaGerenciarCamposPersonalizados()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            managePage.ClicarMenuGerenciar();
            managePage.ClicarGerenciarCamposPersonalizados();
            Assert.That(managePage.VerificarExistenciaDoBotaoNovoCampoPersonalizado());
        }

        [Test]
        public void VerificarAbaGerenciarPerfisGlobal()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            managePage.ClicarMenuGerenciar();
            managePage.ClicarGerenciarPerfisGlobal();
            Assert.That(managePage.VerificarExistenciaDoBotaoAdicionarPerfil());
        }

        [Test]
        public void VerificarAbaGerenciarPlugins()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            managePage.ClicarMenuGerenciar();
            managePage.ClicarGerenciarPlugins();
            Assert.That(managePage.VerificarExistenciaDoBotaoAtualizar());
        }

        [Test]
        public void VerificarAbaGerenciarConfiguracoes()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            managePage.ClicarMenuGerenciar();
            managePage.ClicarGerenciarConfiguracoes();
            Assert.That(managePage.VerificarExistenciaDoBotaoRelatoriosDePermissoes());
        }

    }
}
