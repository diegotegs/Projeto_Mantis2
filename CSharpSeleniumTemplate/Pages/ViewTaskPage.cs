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
        By btnRefreshGravity = By.XPath("//input[@value='Atualizar Gravidade']");
        By btnSolve = By.XPath("//input[@value='Resolver Tarefas']");
        By btnAppliction = By.XPath("//input[@value='Aplicar ']");
        By btnDeleteMarkers = By.XPath("//input[@value='Apagar Marcador']"); 
        
        By comboBoxViewTask = By.Name("action");
        By comboBoxChooseUser = By.Name("assign");
        By checkBoxTast = By.CssSelector("span.lbl");
        By comboBoxGravity = By.Name("severity");

        By linkTaksMarkers = By.XPath("//table[@id='buglist']/tbody/tr/td[4]/a");
        By contentId = By.XPath("//table[@id='buglist']/tbody/tr/td[4]");
        By viewTaskMenu = By.CssSelector("i.menu-icon.fa.fa-list-alt");
        By contentConfirmDelete = By.XPath("//div[@id='action-group-div']/form/div/div[2]/div/div/table/tbody/tr[4]/td");
        By FilterField = By.Id("filter-search-txt");
        By firstTaskInTableGravity = By.XPath("//table[@id='buglist']/tbody/tr/td[8]");
        By contentSolve = By.XPath("//div/span");
        By contentClose = By.XPath("//input[@value='Fechar Tarefas']");
        By fieldApplicationMarkers = By.Id("tag_string");
        By markersOfTask = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div/div[2]/div[2]/div/table/tbody/tr[15]/td");
        By firstMarkerApplication = By.CssSelector("a.btn.btn-xs.btn-primary.btn-white.btn-round");


        public string attributeIDConfirmDelete;
        public string recoverAttributeTableOne;
        public string gravidade;
        public int valueComboBox;
        #endregion

        #region Actions
        //Clicar --------------------------------------------------------------------------------------------------------
        public void ClicarMenuVerTarefa()
        {
            Click(viewTaskMenu);
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
        public void ClicarELimparCampoFiltro()
        {
            Clear(FilterField);
            Click(btnApplicationFilter);
        }
        public void ClicarAtualizarGravidade()
        {
            Click(btnRefreshGravity);
        }
        public void ClicarEmResolver()
        {
            Click(btnSolve);
        }
        public void ClicarFechar()
        {
            Click(contentClose);
        }
        public void ClicarAplicarMarcadores()
        {
            Click(btnAppliction);
        }
        public void ClicarNaTarefa()
        {
            Click(linkTaksMarkers);
        }
        public void ClicarNoMarcador()
        {
            Click(firstMarkerApplication);
        }
        public void ClicarApagarMarcador()
        {
            Click(btnDeleteMarkers);
        }

        //Selecionar --------------------------------------------------------------------------------------------------
       
        public void SelecionarTarefa()
        {
            Click(checkBoxTast);
        }
        public void SelecionarOpcao(string opcao)
        {
            ComboBoxSelectByVisibleText(comboBoxViewTask, opcao);
        }      
        public void SelecionarGrauDeGravidade(string gravidade)
        {
            ComboBoxSelectByVisibleText(comboBoxGravity, gravidade);
        }        

        //Verificar ----------------------------------------------------------------------------------------------------

        public bool VerificarElementoSeExiste()
        {
            return ReturnIfElementExists(checkBoxTast);
        }               
        public string RetornaConteudoTabelaTarefa ()
        {
            return GetText(contentId);
        }
        public bool VerificarSeExisteAlgumMarcadorNaTarefa()
        {
            return ReturnIfElementExists(firstMarkerApplication);
        }
        
       // Recuperar Valor de atributos --------------------------------------------------------------------------------

        public void GetConteudoConfirmarDelete()
        {
            attributeIDConfirmDelete = GetText(contentConfirmDelete);
        }
        public void GetPrimeiroConteudoDaTabela()
        {
            recoverAttributeTableOne = GetText(contentId);
        }
        public void GetGravidade()
        {
            gravidade = GetText(firstTaskInTableGravity);
        }
        public string GetGravidadeModificada()
        {
            return GetText(firstTaskInTableGravity);
        }
        public string GetEstadoTarefa()
        {
            return GetText(contentSolve);
        }
        public string GetMarcadores()
        {
            return GetText(markersOfTask);
        }
        public string GetMarcadorDeletado()
        {
            return GetText(firstMarkerApplication);
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
        public void PreecherAplicarMarcadores(string marcadores)
        {
            SendKeys(fieldApplicationMarkers,marcadores);
        }      

        #endregion
    }
}
