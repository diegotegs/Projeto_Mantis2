using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{

    public class ViewTaskPage : PageBase
    {
        #region Mapping
        By viewTaskMenu = By.CssSelector("i.menu-icon.fa.fa-list-alt");
        By checkBoxTast = By.CssSelector("span.lbl");
        By delete = By.Name("action");
        By bntOk = By.XPath("//div[2]/div[2]/div/input");
        By btnConfirmDelete = By.XPath("//div[2]/input");
        By conteudoId = By.XPath("//table[@id='buglist']/tbody/tr/td[4]");
        By FilterField = By.Id("filter-search-txt");
        By btnApplicationFilter = By.XPath("//div/input[2]");
        By contentConfirmDelete = By.XPath("//div[@id='action-group-div']/form/div/div[2]/div/div/table/tbody/tr[4]/td");
        public string attributeIDConfirmDelete;
        public string recoverAttributeTableOne;
        #endregion

        #region Actions
        //Clicar --------------------------------------------------------------------------------------------------------
        public void ClicarMenuVerTarefa()
        {
            Click(viewTaskMenu);
        }

        public void SelecionarTarefa()
        {
            Click(checkBoxTast);
        }
       
        public void ClicarBNTOk()
        {
            Click(bntOk);
        }

        public void ClicarApagarTarefa()
        {
            Click(btnConfirmDelete);
        }

        public void clicarAplicarFiltro()
        {
            Click(btnApplicationFilter);
        }

        public void LimparCampoFiltro()
        {
            Clear(FilterField);
            Click(btnApplicationFilter);
        }

        //Selecionar --------------------------------------------------------------------------------------------------

        public void SelecionarApagar()
        {
            ComboBoxSelectByVisibleText(delete, "Apagar");
        }



        //Verificar ----------------------------------------------------------------------------------------------------

        public bool VerificarElementoSeExiste()
        {
            return ReturnIfElementExists(checkBoxTast);
        }               
       
        public string RetornaConteudoTabelaTarefa ()
        {
            return GetText(conteudoId);
        }

        //Recuperar Valor de atributos --------------------------------------------------------------------------------

        public void GetConteudoConfirmarDelete()
        {
            attributeIDConfirmDelete = GetText(contentConfirmDelete);
        }

        public void GetPrimeiroConteudoDaTabela()
        {
            recoverAttributeTableOne = GetText(conteudoId);
        }

        //Preencher --------------------------------------------------------------------------------------------

        public void PreencherFiltroParaPesquisar()
        {
            SendKeys(FilterField, recoverAttributeTableOne);
        }

        public void PreencherFiltroComIDItemExcluido()
        {
            SendKeys(FilterField,attributeIDConfirmDelete);
        }

       

        #endregion
    }
}
