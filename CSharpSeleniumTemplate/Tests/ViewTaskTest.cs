using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.DataBaseSteps;
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
    public class ViewTaskTest : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] ViewTaskPage viewTaskPage;
        [AutoInstance] ViewTaskFlows viewTaskFlows;
        #endregion

        [Test]
        [Category("CRUDTarefa")]
        public void ApagarTarefa()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            string opcao = "Apagar";
            TaskDBSteps.CriarTarefaDB();
            
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            viewTaskFlows.SelecionarCombox(opcao);
            viewTaskPage.GetConteudoConfirmarDelete();
            viewTaskPage.ClicarApagarTarefa();
            viewTaskPage.PreencherFiltroComIDItemExcluido();
            viewTaskPage.clicarAplicarFiltro();

            Assert.AreEqual(0,TaskDBSteps.RetornaQuantidadeDeTarefasExistenteDB());
            Assert.False(viewTaskPage.VerificarElementoSeExiste());

        }

        [Test]
        [Category("CRUDTarefa")]
        public void PesquisarTarefaUsandoNumIdentificador()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            TaskDBSteps.CriarTarefaDB();
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            viewTaskPage.ClicarMenuVerTarefa();
            viewTaskPage.ClicarELimparCampoFiltro();
            Assume.That(viewTaskPage.VerificarElementoSeExiste());
            viewTaskPage.GetPrimeiroConteudoDaTabela();
            viewTaskPage.PreencherFiltroParaPesquisar();
            viewTaskPage.clicarAplicarFiltro();

            Assert.True(viewTaskPage.recoverAttributeTableOne.Equals(viewTaskPage.RetornaConteudoTabelaTarefa()));

        }

        [Test]
        [Category("CRUDTarefa")]
        public void AlterarGravidade()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            string [] gravidade = new string []{ "trivial", "recurso", "texto", "mínimo", "grande", "travamento", "obstáculo" };
            Random n = new Random();
            string opcao = "Atualizar Gravidade";
            TaskDBSteps.CriarTarefaDB();
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            viewTaskPage.ClicarMenuVerTarefa();
            viewTaskPage.ClicarELimparCampoFiltro();

            Assume.That(viewTaskPage.VerificarElementoSeExiste());
            viewTaskPage.SelecionarTarefa();
            viewTaskPage.GetGravidade();
            viewTaskPage.SelecionarOpcao(opcao);
            viewTaskPage.ClicarBNTOk();            
            viewTaskPage.SelecionarGrauDeGravidade(gravidade[n.Next(0,7)]);
            viewTaskPage.ClicarAtualizarGravidade();

            Assert.AreNotEqual(viewTaskPage.gravidade, viewTaskPage.GetGravidadeModificada());      
           
            
        }

        [Test]
        [Category("CRUDTarefa")]
        public void ResolverTarefa()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            string opcao = "Resolver";
            string status = "resolvido";
            TaskDBSteps.CriarTarefaDB();
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            viewTaskPage.ClicarMenuVerTarefa();
            viewTaskPage.ClicarELimparCampoFiltro();

            Assume.That(viewTaskPage.VerificarElementoSeExiste());
            viewTaskPage.GetPrimeiroConteudoDaTabela();
            viewTaskPage.SelecionarTarefa();
            viewTaskPage.SelecionarOpcao(opcao);
            viewTaskPage.ClicarBNTOk();
            viewTaskPage.ClicarEmResolver();
            viewTaskPage.PreencherFiltroParaPesquisar();
            viewTaskPage.clicarAplicarFiltro();

            Assert.AreEqual(status, viewTaskPage.GetEstadoTarefa());



        }

        [Test]
        [Category("CRUDTarefa")]
        public void FecharTarefa()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            string opcao = "Fechar";
            TaskDBSteps.CriarTarefaDB();
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            viewTaskFlows.SelecionarCombox(opcao);           
            viewTaskPage.ClicarFechar();
            viewTaskFlows.PesquisarElemento();

            Assert.False(viewTaskPage.VerificarElementoSeExiste());

        }

        [Test]
        [Category("CRUDTarefa")]
        public void AplicarMarcadoresRelacionadoAUmaTarefa()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            string opcao = "Aplicar marcadores";
            string marcadores = GeneralHelpers.ReturnStringWithRandomCharacters(3);
            TaskDBSteps.CriarTarefaDB();

            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            viewTaskFlows.SelecionarCombox(opcao);
            viewTaskPage.PreecherAplicarMarcadores(marcadores);
            viewTaskPage.ClicarAplicarMarcadores();
            viewTaskFlows.PesquisarElemento();
            viewTaskPage.ClicarNaTarefa();

            Assert.True(viewTaskPage.GetMarcadores().Contains(marcadores));
        }

        [Test]
        [Category("CRUDTarefa")]
        public void ApagarMarcadores()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            string marcadorDeletado;
            TaskDBSteps.CriarTarefaDB();
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            viewTaskPage.ClicarMenuVerTarefa();
            viewTaskPage.ClicarELimparCampoFiltro();

            Assume.That(viewTaskPage.VerificarElementoSeExiste());
            viewTaskPage.GetPrimeiroConteudoDaTabela();
            viewTaskPage.ClicarNaTarefa();
            Assume.That(viewTaskPage.VerificarSeExisteAlgumMarcadorNaTarefa());
            marcadorDeletado = viewTaskPage.GetMarcadorDeletado();
            viewTaskPage.ClicarNoMarcador();
            viewTaskPage.ClicarApagarMarcador();
            viewTaskPage.ClicarApagarMarcador();
            viewTaskPage.ClicarMenuVerTarefa();
            viewTaskPage.ClicarELimparCampoFiltro();
            viewTaskPage.PreencherFiltroParaPesquisar();
            viewTaskPage.clicarAplicarFiltro();
            viewTaskPage.ClicarNaTarefa();  
            
            Assert.False(viewTaskPage.GetMarcadores().Contains(marcadorDeletado));
        }

    }
}
