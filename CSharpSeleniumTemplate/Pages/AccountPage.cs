using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.Helpers;
using OpenQA.Selenium;

namespace CSharpSeleniumTemplate.Pages
{
    public class AccountPage : PageBase
    {
        #region Mapping
        By linkMyAccount = By.XPath("(//a[contains(@href,'/account_page.php')])[2]");
        By linkPreferences = By.LinkText("Preferências");
        By linkManageColumns = By.LinkText("Gerenciar Colunas");
        By btnRefreshUser = By.XPath("//input[@value='Atualizar Usuário']");
        By btnRefreshPreferences = By.XPath("//input[@value='Atualizar Preferências']");
        By btnRefreshColumns = By.Name("update_columns_for_current_project");


        #endregion

        #region Actions
        public void ClicarAlterarConta()
        {
            Click(linkMyAccount);
        }
        public void ClicarPreferencias()
        {
            Click(linkPreferences);
        }
        public void ClicarGerenciarColunas()
        {
            Click(linkManageColumns);
        }

        public bool GetBotaoAtualizarUsuario()
        {
            return ReturnIfElementIsDisplayed(btnRefreshUser);
        }
        public bool GetBotaoAtualizarPreferencias()
        {
            return ReturnIfElementIsDisplayed(btnRefreshPreferences);
        }
        public bool GetBotaoAtualizarColunas()
        {
            return ReturnIfElementIsDisplayed(btnRefreshColumns);
        }
        #endregion
    }
}
