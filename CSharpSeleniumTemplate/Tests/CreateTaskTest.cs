using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    public class CreateTaskTest : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] CreateTaskPage createTaskPage;
        [AutoInstance] LoginFlows loginFlows;
        #endregion

        #region Data Driven Providers
        public static IEnumerable CriarTarefaComCamposObrigatorio()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/CriarTarefas/CriarTarefasCamposObrigatorio.csv");
        }
        #endregion


        [Test]
        public void ValidarCampoObrigatorioDescricao()
        {
            #region Parameters
            string resumo = "Teste Resumo";            
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion
            loginFlows.EfetuarLogin(usuario,senha);
            createTaskPage.ClicarMenuNovaTarefa();
            createTaskPage.ClicarIdentificador();
            createTaskPage.PreencherResumo(resumo);
            createTaskPage.ClicarCriarNovaTarefa();           
            Assert.AreEqual("Preencha este campo.",createTaskPage.RetornarMsg("validationMessage"));


        }
        [Test]
        public void ValidarCampoObrigatorioResumo()
        {
            #region Parameters
            string descricao = "Teste descrição";
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);
            createTaskPage.ClicarMenuNovaTarefa();
            createTaskPage.ClicarIdentificador();
            createTaskPage.PreencherResumo(descricao);
            createTaskPage.ClicarCriarNovaTarefa();
            Assert.AreEqual("Preencha este campo.", createTaskPage.RetornarMsg("validationMessage"));


        }
        [Test]
        public void CriarNovaTarefa()
        {
            #region Parameters
            string resumo = "Teste Resumo";
            string descricao = "Teste descrição";
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);
            createTaskPage.ClicarMenuNovaTarefa();
            createTaskPage.ClicarIdentificador();
            createTaskPage.PreencherResumo(resumo);
            createTaskPage.PreencherDescricao(descricao);
            createTaskPage.ClicarCriarNovaTarefa();
            Assert.That(createTaskPage.ValidarCriarTarefa().Contains("sucesso"));

        }

        [Test, TestCaseSource("CriarTarefaComCamposObrigatorio")]
        public void CriarTarefasComDataDrive(ArrayList testData)
        {
            #region Parameters
            string resumo = testData[0].ToString();
            string descricao = testData[1].ToString();

            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            createTaskPage.ClicarMenuNovaTarefa();
            createTaskPage.ClicarIdentificador();
            createTaskPage.PreencherResumo(resumo);
            createTaskPage.PreencherDescricao(descricao);
            createTaskPage.ClicarCriarNovaTarefa();
            Assert.That(createTaskPage.ValidarCriarTarefa().Contains("sucesso"));
        }



    }
}
