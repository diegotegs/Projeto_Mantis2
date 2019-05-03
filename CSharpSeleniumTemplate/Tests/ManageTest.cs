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
        [AutoInstance] ManageSettingFlows manageSettingFlows;
        #endregion

        [Test]
        public void AcessarAbaGerenciarUsuario()
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
        public void AcessarAbaGerenciarProjetos()
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
        public void AcessarAbaGerenciarMarcadores()
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
        public void AcessarAbaGerenciarCamposPersonalizados()
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
        public void AcessarAbaGerenciarPerfisGlobal()
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
        public void AcessarAbaGerenciarPlugins()
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
        public void AcessarAbaGerenciarConfiguracoes()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            manageSettingFlows.GerenciarConfiguracaoSubsMenu();
            Assert.That(managePage.VerificarExistenciaDoBotaoRelatoriosDePermissoes());
        }

        [Test]
        public void CriarNovoProjeto()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;            
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            managePage.ClicarMenuGerenciar();
            managePage.ClicarGerenciarProjeto();
            managePage.ClicarNovoProjeto();
            managePage.PreencherNomeProjeto();
            managePage.PreencherDescricaoProjeto();
            managePage.ClicarAdicionarProjeto();
            Assert.AreEqual("Operação realizada com sucesso.", managePage.MenssagemSucesso());
            

        }

        [Test]
        public void ApagarProjeto()
        {

            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            managePage.ClicarMenuGerenciar();
            managePage.ClicarGerenciarProjeto();
            Assume.That(managePage.VerificarSeExisteProjeto());
            managePage.ClicarPrimeiroProjeto();
            managePage.ClicarApagarProjeto();
            managePage.ConfirmarApagarProjeto();
            Assert.That(managePage.VerificarExistenciaDoBotaoCriarNovaProjeto());


        }

        [Test]
        public void CriarMarcadores()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            managePage.ClicarMenuGerenciar();
            managePage.ClicarGerenciarMarcadores();           
            managePage.PreencherNomeMarcadores();
            managePage.PreecherDescricaoMarcadores();
            managePage.ClicarCriarMarcadores();
            Assert.AreEqual(managePage.confirmCreateMarkers, managePage.VerificarCriarMarcadores());
        }

        [Test]
        public void ApagarMarcador()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            managePage.ClicarMenuGerenciar();
            managePage.ClicarGerenciarMarcadores();

            Assume.That(managePage.VErificarSeExisteMarcadores());

            managePage.GetQuantidadeDeRegistro();
            managePage.ClicarMarcadorParaApagar();
            managePage.ClicarApagarMarcador();
            managePage.ClicarApagarMarcador();
            Assert.Greater(Convert.ToInt32(managePage.qtsRegister), Convert.ToInt32(managePage.qtsRegister)-1);


        }

        [Test]
        public void VerificarAbaRelatorioDeConfiguracao()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            manageSettingFlows.GerenciarConfiguracaoSubsMenu();
            managePage.ClicarRelatorioDeConfiguracao();
            Assert.True(managePage.GetBotaoCriarOpcaoDeConfiguracao());
        }

        [Test]
        public void VerificarAbaLiminaresDeFluxoDeTrabalho()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            manageSettingFlows.GerenciarConfiguracaoSubsMenu();
            managePage.ClicarLiminaresFluxoDeTrabalho();
            Assert.True(managePage.GetBotaoAtualizarConfiguracao());
        }

        [Test]
        public void VerificarAbaTransicoesDeFluxoDeTrabalho()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            manageSettingFlows.GerenciarConfiguracaoSubsMenu();
            managePage.ClicarTransicoesFluxoDeTrabalho();
            Assert.True(managePage.GetBotaoAtualizarConfiguracao());
        }

        [Test]
        public void VerificarAbaNotificacaoPorEmail()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            manageSettingFlows.GerenciarConfiguracaoSubsMenu();
            managePage.ClicarNotificacaoPorEmail();
            Assert.True(managePage.GetBotaoAtualizarConfiguracao());
        }

        [Test]
        public void VerificarAbaGerenciarColunas()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            manageSettingFlows.GerenciarConfiguracaoSubsMenu();
            managePage.ClicarGerenciarColunas();
            Assert.True(managePage.GetBotaoAtualizarColunas());
        }






    }
}
