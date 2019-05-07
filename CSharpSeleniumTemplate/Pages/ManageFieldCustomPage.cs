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
        By firstFieldInTable = By.XPath("//td/a");
        By btnDeleteField = By.XPath("//input[@value='Apagar Campo Personalizado']");
        By btnConfirmDelete = By.XPath("//input[@value='Apagar Campo']");
        
        
        #endregion

        #region Actions
        public void PreencherCampoNome(string nome)
        {
            SendKeys(fieldName,nome);
        }

        public void AdicionarElementoRepetidoNaTabela()
        {
            SendKeys(fieldName,GetValorPrimeiroElementoDaTabela());
        }


        public void ClicarNovoCampoPersonalizado()
        {
            Click(btnNewFieldCustom);
        }

        public void ClicarApagarCampoPersonalizado()
        {
            Click(btnDeleteField);
        } 

        public void ClicarConfirmarDelete()
        {
            Click(btnConfirmDelete);
        }

        public string RetornoMSgSucesso()
        {
            return GetText(msgSusseful);
        }

        public string RetornaMsgDeErro()
        {
          return  GetText(msgError);
        }
        public string GetValorPrimeiroElementoDaTabela()
        {
            return GetText(firstFieldInTable);
        }



        public void ClicarGerenciar()
        {
            Click(manageMenu);
        }

        public void ClicarGerenciarCamposPersonalizados()
        {
            Click(linkManageFieldCustom);
        }

        public void ClicarPrimeiroCampoPersonalizado()
        {
            Click(firstFieldInTable);
        }

        public bool VerificarSeExisteCampoPersonalizado()
        {
            return ReturnIfElementExists(firstFieldInTable);
        }
        #endregion
    }
}
