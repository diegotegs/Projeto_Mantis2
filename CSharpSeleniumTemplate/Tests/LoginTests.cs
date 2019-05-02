using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;
using System.Collections;


namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] LoginPage loginPage;        
        [AutoInstance] LoginFlows loginFlows;
        #endregion

        #region Data Driven Providers
        public static IEnumerable EfetuarLoginInformandoUsuarioInvalidoIProvider()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/Login/EfetuarLoginInformandoUsuarioInvalidoData.csv");
        }
        #endregion

        [Test]
        public void EfetuarLoginComSucesso()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            Assert.True(loginPage.RetornaElementoProximaPagina());


          
        }

        
        [Test]
        public void EfetuarLoginComSenhaInvalida()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha ="123456";
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            Assert.That(loginPage.MenssagemErroSenha().Contains("não estão corretos"));
           
        }
               
    }
}
