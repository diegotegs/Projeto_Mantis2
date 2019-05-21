using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.Helpers;
using OpenQA.Selenium;


namespace CSharpSeleniumTemplate.Pages
{
   public class InviteUserPage : PageBase
    {
        #region Mapping
        By linkInviteUser = By.LinkText("Convidar Usuários");
        By fieldName = By.Id("user-username");
        By fieldRealName = By.Id("user-realname");
        By fieldEmail = By.Id("email-field");
        By msgSucessful = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div/div[2]/p");
        By selectAccessLevel = By.Id("user-access-level");
        By btnCreateUser = By.XPath("//form[@id='manage-user-create-form']/div/div[3]/input");

        public string returnUser; 

        #endregion
        
        #region Actions
        public void ClicarConvidarUsuario()
        {
            Click(linkInviteUser);
        }
        public void ClicarEmCriarNovoUsuario()
        {
            Click(btnCreateUser);
        }

        public void SelecionarNivelDeAcesso()
        {
            ComboBoxSelectByVisibleText(selectAccessLevel, "desenvolvedor");
        }

        public void PreencherUsuario()
        {
            returnUser = "Test " + GeneralHelpers.ReturnStringWithRandomNumbers(2);
            SendKeys(fieldName,returnUser);
        }
        public void PreencherRealNome()
        {
           
            SendKeys(fieldRealName, "Real nome Test " + GeneralHelpers.ReturnStringWithRandomNumbers(2));
        }
        public void PreencherEmail()
        {
            SendKeys(fieldEmail, "EmailTest@"+GeneralHelpers.ReturnStringWithRandomCharacters(3)+".br");
        }

        public string ValidarMenssagemSucesso()
        {
            return GetText(msgSucessful);
        }
        #endregion

    }
}
