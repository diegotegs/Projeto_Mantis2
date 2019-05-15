using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.DataBaseSteps;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;
using System;

namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
   public class ManageFieldCustomTest : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] ManageFieldCustomPage manageFieldCustomPage;
        [AutoInstance] ManageFieldCustomFlows manageFieldCustomFlows;
        #endregion


        [Test]
        [Category("AdicionarCamposPersonalizado")]
        public void CriarCampoPersonalizado()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            string nome = GeneralHelpers.ReturnStringWithRandomCharacters(4);
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            manageFieldCustomFlows.GerarCamposPersonalizados();

            manageFieldCustomPage.PreencherCampoNome(nome);
            manageFieldCustomPage.ClicarNovoCampoPersonalizado();

            Assert.AreEqual(nome, SelectsDBSteps.RetornaCampoPersonalizadoCadastrado(nome));

            Assert.AreEqual("Operação realizada com sucesso.", manageFieldCustomPage.RetornoMSgSucesso());
        }

        [Test]
        [Category("AdicionarCamposPersonalizado")]
        public void AdicionarCampoPersonalizadoSemNome()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            manageFieldCustomFlows.GerarCamposPersonalizados();

            manageFieldCustomPage.ClicarNovoCampoPersonalizado();

            Assert.True(manageFieldCustomPage.RetornaMsgDeErro().Contains("Um campo necessário 'name' estava vazio."));
        }

        [Test]
        [Category("AdicionarCamposPersonalizado")]
        public void AdicionarCampoComOMesmoNomeDoExistente()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;

            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            manageFieldCustomFlows.GerarCamposPersonalizados();

            Assume.That(manageFieldCustomPage.VerificarSeExisteCampoPersonalizado());

            manageFieldCustomPage.AdicionarElementoRepetidoNaTabela();
            manageFieldCustomPage.ClicarNovoCampoPersonalizado();



            Assert.True(manageFieldCustomPage.RetornaMsgDeErro().Contains("Este é um nome duplicado."));
        }

        [Test]
        [Category("AdicionarCamposPersonalizado")]
        public void ExcluirCampoPersonalizado()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            string nome = "CampoPersonalizado "+GeneralHelpers.ReturnStringWithRandomNumbers(3);
            
            #endregion

            InsertsDBSteps.CriarCampoPersonalizadoDB(nome);
            loginFlows.EfetuarLogin(usuario, senha);

            manageFieldCustomFlows.GerarCamposPersonalizados();

            Assume.That(manageFieldCustomPage.VerificarSeExisteCampoPersonalizado());

            manageFieldCustomPage.ClicarPrimeiroCampoPersonalizado();
            manageFieldCustomPage.ClicarApagarCampoPersonalizado();
            manageFieldCustomPage.ClicarConfirmarDelete();        


            
            Assert.AreEqual("Operação realizada com sucesso.",manageFieldCustomPage.RetornoMSgSucesso());
        }



    }
}
