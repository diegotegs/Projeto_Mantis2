using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class LoginPage : PageBase
    {
        #region Mapping
        By usernameField = By.Id("username");
        By passwordField = By.Id("password");
        By loginNext = By.XPath("//input[2]"); 
        By loginButton = By.XPath("//input[3]");
        By buttonNextView = By.XPath("//div[2]/div/ul/li/a/i");
        By msgErroSenha = By.XPath("//p");
        #endregion

        #region Actions
        public void PreenhcerUsuario(string usuario)
        {
            SendKeysJavaScript(usernameField, usuario);
        }

        public void PreencherSenha(string senha)
        {
            SendKeysJavaScript(passwordField, senha);
        }

        public void ClicarEmProcessir()
        {
            ClickJavaScript(loginNext);
        }
        public void ClicarEmLogar()
        {
            ClickJavaScript(loginButton);
        }

        public bool RetornaElementoProximaPagina()
        {
            return ReturnIfElementIsDisplayed(buttonNextView);
        }

        public string MenssagemErroSenha()
        {
            return GetText(msgErroSenha);
        }
        #endregion
    }
}
