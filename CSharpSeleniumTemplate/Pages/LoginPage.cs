using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;


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
        public void ClicarEmProcessir()
        {
            ClickJavaScript(loginNext);
        }
        public void ClicarEmLogar()
        {
            ClickJavaScript(loginButton);
        }

        public void PreenhcerUsuario(string usuario)
        {
            SendKeysJavaScript(usernameField, usuario);
        }
        public void PreencherSenha(string senha)
        {
            SendKeysJavaScript(passwordField, senha);
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
