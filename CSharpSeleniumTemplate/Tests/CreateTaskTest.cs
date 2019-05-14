﻿using CSharpSeleniumTemplate.Bases;
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
            #endregion
            loginFlows.EfetuarLogin(usuario,senha);

            createTaskFlows.CriarTarefa(resumo,"");            
            Assert.AreEqual("Please fill out this field.", createTaskPage.RetornarMsgDescricao("validationMessage"));


        }
        [Test]
        [Category("ValidarCamposObrigatorio")]
        public void ValidarCampoObrigatorioResumo()
        {
            #region Parameters
            string descricao = "Teste descrição";
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion
            loginFlows.EfetuarLogin(usuario, senha);

            createTaskFlows.CriarTarefa("", descricao);            
            Assert.AreEqual("Please fill out this field.", createTaskPage.RetornarMsgResumo("validationMessage"));
            

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
            Assert.That(createTaskPage.ValidarCriarTarefa().Contains("sucesso"));
        }



    }
}
