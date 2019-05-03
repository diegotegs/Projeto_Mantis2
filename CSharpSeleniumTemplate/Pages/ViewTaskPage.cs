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
        By bntOk = By.XPath("//div[2]/div[2]/div/input");
        By btnConfirm = By.XPath("//div[2]/input");
        By btnApplicationFilter = By.XPath("//div/input[2]");
        By comboBoxViewTask = By.Name("action");
        By comboBoxChooseUser = By.Name("assign");
        By checkBoxTast = By.CssSelector("span.lbl");
        By conteudoId = By.XPath("//table[@id='buglist']/tbody/tr/td[4]");
        By viewTaskMenu = By.CssSelector("i.menu-icon.fa.fa-list-alt");
        By contentConfirmDelete = By.XPath("//div[@id='action-group-div']/form/div/div[2]/div/div/table/tbody/tr[4]/td");
        By FilterField = By.Id("filter-search-txt");
        public string attributeIDConfirmDelete;
        public string recoverAttributeTableOne;
        public int valueComboBox;
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
            Click(btnConfirm);
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
            ComboBoxSelectByVisibleText(comboBoxViewTask, "Apagar");
        }

        public void SelecionarAtribuir()
        {
            ComboBoxSelectByVisibleText(comboBoxViewTask,"Atribuir");
        }

        public void SelecionarUsuarioParaAtribuirTarefa()
        {
            ComboBoxSelectByVisibleIndex(comboBoxChooseUser, 1);
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
        
       // Recuperar Valor de atributos --------------------------------------------------------------------------------

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
