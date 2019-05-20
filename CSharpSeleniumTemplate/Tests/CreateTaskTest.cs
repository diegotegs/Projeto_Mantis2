using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.DataBaseSteps;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    public class CreateTaskTest : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] CreateTaskPage createTaskPage;
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] CreateTaskFlows createTaskFlows;

        public double SelectDBSteps { get; private set; }
        #endregion

        #region Data Driven Providers
        public static IEnumerable CriarTarefaComCamposObrigatorio()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/CriarTarefas/CriarTarefasCamposObrigatorio.csv");
        }
        #endregion


        [Test]
        [Category("ValidarCamposObrigatorio")]
        public void ValidarCampoObrigatorioDescricao()
        {
            #region Parameters
            string resumo = "Teste Resumo";            
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            string msgPortugues ="Preencha este campo.";
            string msgExplorer = "Este é um campo obrigatório";
            string msgIngles = "Please fill out this field.";
            string msgJavaScripit = "validationMessage";
            #endregion
            loginFlows.EfetuarLogin(usuario,senha);

            createTaskFlows.CriarTarefa(resumo,"");
            CollectionAssert.Contains(new[] { msgIngles, msgPortugues, msgExplorer}, createTaskPage.RetornarMsgDescricao(msgJavaScripit));
            

        }
        [Test]
        [Category("ValidarCamposObrigatorio")]
        public void ValidarCampoObrigatorioResumo()
        {
            #region Parameters
            string descricao = "Teste descrição";
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            string msgPortugues = "Preencha este campo.";
            string msgExplorer = "Este é um campo obrigatório";
            string msgIngles = "Please fill out this field.";
            string msgJavaScripit = "validationMessage";
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);

            createTaskFlows.CriarTarefa("", descricao);
            CollectionAssert.Contains(new[] { msgIngles, msgPortugues, msgExplorer }, createTaskPage.RetornarMsgResumo(msgJavaScripit));
            

        }
        [Test]
        [Category("CriarTarefa")]
        public void CriarNovaTarefa()
        {
            #region Parameters
            string resumo = "Teste Resumo " + GeneralHelpers.ReturnStringWithRandomNumbers(6);
            string descricao = "Teste descrição";
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            createTaskFlows.CriarTarefa(resumo, descricao);
            Assert.That(createTaskPage.ValidarCriarTarefa().Contains("sucesso"));
            Assert.True(SelectsDBSteps.RetornaResumoCriado(resumo).Contains("Teste Resumo"));

        }

        [Test, TestCaseSource("CriarTarefaComCamposObrigatorio")]
        [Category("CriarTarefaDataDriven")]
        public void CriarTarefasComDataDriven(ArrayList testData)
        {
            #region Parameters
            string resumo = testData[0].ToString();
            string descricao = testData[1].ToString();

            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            createTaskFlows.CriarTarefa(resumo,descricao);

            Assert.AreEqual(resumo, SelectsDBSteps.RetornaResumoCriadoSemParamero());
            Assert.That(createTaskPage.ValidarCriarTarefa().Contains("sucesso"));
        }



    }
}
