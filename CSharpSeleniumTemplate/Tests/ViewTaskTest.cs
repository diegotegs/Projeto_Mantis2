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
   public class ViewTaskTest : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] ViewTaskPage viewTaskPage;
        #endregion

        [Test]
        public void ApagarTarefa()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            viewTaskPage.ClicarMenuVerTarefa();
            viewTaskPage.LimparCampoFiltro();

            Assume.That(viewTaskPage.VerificarElementoSeExiste());
            viewTaskPage.SelecionarTarefa();
            viewTaskPage.SelecionarApagar();
            viewTaskPage.ClicarBNTOk();
            viewTaskPage.GetConteudoConfirmarDelete();
            viewTaskPage.ClicarApagarTarefa();
            viewTaskPage.PreencherFiltroComIDItemExcluido();
            viewTaskPage.clicarAplicarFiltro();
            Assert.False(viewTaskPage.attributeIDConfirmDelete.Equals(viewTaskPage.VerificarElementoSeExiste()));
            
            


        }

        [Test]
        public void PesquisarTarefaUsandoNumIdentificador()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            viewTaskPage.ClicarMenuVerTarefa();
            viewTaskPage.LimparCampoFiltro();
            Assume.That(viewTaskPage.VerificarElementoSeExiste());
            viewTaskPage.GetPrimeiroConteudoDaTabela();
            viewTaskPage.PreencherFiltroParaPesquisar();
            viewTaskPage.clicarAplicarFiltro();
            Assert.True(viewTaskPage.recoverAttributeTableOne.Equals(viewTaskPage.RetornaConteudoTabelaTarefa()));






        }
    }
}
