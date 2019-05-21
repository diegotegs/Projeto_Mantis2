using CSharpSeleniumTemplate.Pages;


namespace CSharpSeleniumTemplate.Flows
{
    public class LoginFlows
    {
        #region Page Object and Constructor
        LoginPage loginPage;

        public LoginFlows()
        {
            loginPage = new LoginPage();
        }
        #endregion

        public void EfetuarLogin(string username, string password)
        {
            loginPage.PreenhcerUsuario(username);
            loginPage.ClicarEmProcessir();
            loginPage.PreencherSenha(password);
            loginPage.ClicarEmLogar();
        }
    }
}
