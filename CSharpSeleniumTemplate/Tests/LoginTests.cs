using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;



namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] LoginPage loginPage;        
        [AutoInstance] LoginFlows loginFlows;
        #endregion        

        [Test]
        [Category("Logar")]
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
        [Category("Logar")]
        public void EfetuarLoginComSenhaInvalida()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = GeneralHelpers.ReturnStringWithRandomCharacters(4);
            string msgValidar = "não estão corretos";

            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            Assert.That(loginPage.MenssagemErroSenha().Contains(msgValidar));
           
        }
               
    }
}
