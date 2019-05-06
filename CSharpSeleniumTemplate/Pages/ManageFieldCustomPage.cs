using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.Helpers;
using OpenQA.Selenium;

namespace CSharpSeleniumTemplate.Pages
{
    public class ManageFieldCustomPage : PageBase
    {
        #region Mapping
        By fieldName = By.Name("name");
        By btnNewFieldCustom = By.XPath("//input[@value='Novo Campo Personalizado']");
        By msgSusseful = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div/div[2]/p");
        By msgError = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/p[2]");
        By manageMenu = By.XPath("//div[@id='sidebar']/ul/li[7]/a/i");
        By linkManageFieldCustom = By.LinkText("Gerenciar Campos Personalizados");
        
        #endregion

        #region Actions
        public void PreencherCampoNome(string nome)
        {
            SendKeys(fieldName,nome);
        }


        public void ClicarNovoCampoPersonalizado()
        {
            Click(btnNewFieldCustom);
        }



        public string RetornoMSgSucesso()
        {
            return GetText(msgSusseful);
        }

        public string RetornaMsgDeErro()
        {
          return  GetText(msgError);
        }

        public void ClicarGerenciar()
        {
            Click(manageMenu);
        }

        public void ClicarGerenciarCamposPersonalizados()
        {
            Click(linkManageFieldCustom);
        }
        #endregion
    }
}
