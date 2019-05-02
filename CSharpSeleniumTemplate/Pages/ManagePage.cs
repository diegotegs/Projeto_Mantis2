using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
   public class ManagePage : PageBase
    {
        #region Mapping
        //Botoes --------------------------------------------------
        By btnCreateNewAccount = By.XPath("//div[@id='manage-user-div']/div/form/fieldset/button");
        By btnNewField = By.XPath("//input[@value='Novo Campo Personalizado']");
        By btnCreateNewProject = By.XPath("//button[@type='submit']");
        By btnAddProfile = By.XPath("//input[@value='Adicionar Perfil']");
        By btnRefresh = By.XPath("//input[@value='Atualizar']");
        By btnPermissionReport = By.LinkText("Relatório de Permissões");
        By btnAddProject = By.XPath("//form[@id='manage-project-create-form']/div/div[3]/input");
        By btnDeleteProject = By.XPath("//input[@value='Apagar Projeto']");
        By btnCreateMarkers = By.Name("config_set");
        By btnDeleteMarkers = By.XPath("//input[@value='Apagar Marcador']"); 

        //Links
        By linkManageUser = By.LinkText("Gerenciar Usuários");
        By linkManageProject = By.LinkText("Gerenciar Projetos");
        By linkManageMarkers = By.LinkText("Gerenciar Marcadores");        
        By linkAllMarkers = By.LinkText("TODAS");
        By linkManageFiled = By.LinkText("Gerenciar Campos Personalizados");
        By linkProfileGlobal = By.LinkText("Gerenciar Perfís Globais");
        By linkManagePlugins = By.LinkText("Gerenciar Plugins");
        By linkManageSetting = By.LinkText("Gerenciar Configuração");
        //campos
        By fieldNameProject = By.Id("project-name");
        By fieldDescription = By.Id("project-description");
        By fieldNameMarkers = By.Id("tag-name");
        By fieldDescriptionMarkers = By.Id("tag-description");
        //outros
        By menuManage = By.CssSelector("i.menu-icon.fa.fa-gears");
        By msgSucessfullCreateProject = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div/div[2]/p");
        By firstFieldTable = By.XPath("//td/a");
        By qtsRegisterInTableMarkers = By.XPath("//h4/span");
        //Variaveis de controle
        public string confirmCreateMarkers;
        public string qtsRegister;



        #endregion

        #region Actions

        //Clicar -------------------------------------------------------------------------------------------------------
        public void ClicarMenuGerenciar()
        {
            Click(menuManage);
        }

        public void ClicarGerenciarUsuario()
        {
            Click(linkManageUser);
        }

        public void ClicarGerenciarProjeto()
        {
            Click(linkManageProject);
        }

        public void ClicarGerenciarMarcadores()
        {
            Click(linkManageMarkers); 
        }

        public void ClicarGerenciarCamposPersonalizados()
        {
            Click(linkManageFiled);
        }
        public void ClicarGerenciarPerfisGlobal()
        {
            Click(linkProfileGlobal);
        }

        public void ClicarGerenciarPlugins()
        {
            Click(linkManagePlugins);
        }

        public void ClicarGerenciarConfiguracoes()
        {
            Click(linkManageSetting);
        }

        public void ClicarNovoProjeto()
        {
            Click(btnCreateNewProject);
        }

        public void ClicarAdicionarProjeto()
        {
            Click(btnAddProject);
        }

        public void ClicarPrimeiroProjeto()
        {
            Click(firstFieldTable);
        }

        public void ClicarApagarProjeto()
        {
            Click(btnDeleteProject);
        }

        public void ConfirmarApagarProjeto()
        {
            Click(btnDeleteProject);
        }
        
        public void ClicarCriarMarcadores()
        {
            Click(btnCreateMarkers);
        }

        public void ClicarMarcadorParaApagar()
        {
            Click(firstFieldTable);
        }

        public void ClicarApagarMarcador()
        {
            Click(btnDeleteMarkers);
        }


              

        //Validar Retorno --------------------------------------------------------------------------------------------------
        public bool VerificarExistenciaDoBotaoCriarNovaConta()
        {
            return ReturnIfElementIsDisplayed(btnCreateNewAccount);
        }

        public bool VerificarExistenciaDoBotaoCriarNovaProjeto()
        {
            return ReturnIfElementIsDisplayed(btnCreateNewProject);
        }

        public bool VerificarExistenciaDoLinkTodos()
        {
            return ReturnIfElementIsDisplayed(linkAllMarkers);
        }

        public bool VerificarExistenciaDoBotaoNovoCampoPersonalizado()
        {
            return ReturnIfElementIsDisplayed(btnNewField);
        }

        public bool VerificarExistenciaDoBotaoAdicionarPerfil()
        {
            return ReturnIfElementIsDisplayed(btnAddProfile);
        }

        public bool VerificarExistenciaDoBotaoAtualizar()
        {
            return ReturnIfElementIsDisplayed(btnRefresh);
        }

        public bool VerificarExistenciaDoBotaoRelatoriosDePermissoes()
        {
            return ReturnIfElementIsDisplayed(btnPermissionReport);
        }

        public string MenssagemSucesso()
        {
            return GetText(msgSucessfullCreateProject);
        }

        public bool VerificarSeExisteProjeto()
        {
            return ReturnIfElementExists(firstFieldTable);
        }

        public string VerificarCriarMarcadores()
        {
           return GetText(By.LinkText(confirmCreateMarkers));
          
        }

        public bool VErificarSeExisteMarcadores()
        {
            return ReturnIfElementExists(firstFieldTable);
        }

        public void GetQuantidadeDeRegistro()
        {

            qtsRegister = GetText(qtsRegisterInTableMarkers);
            
        }

        //Preencher Campo --------------------------------------------------------------------------------------------------
        public void PreencherNomeProjeto()
        {
            SendKeys(fieldNameProject,"Test "+ GeneralHelpers.ReturnStringWithRandomNumbers(2));
        }

        public void PreencherDescricaoProjeto()
        {
            SendKeys(fieldDescription,GeneralHelpers.ReturnStringWithRandomCharacters(5));
        }

        public void PreencherNomeMarcadores()
        {
            confirmCreateMarkers =  "Test " + GeneralHelpers.ReturnStringWithRandomNumbers(2);
            SendKeys(fieldNameMarkers,confirmCreateMarkers);
        }

        public void PreecherDescricaoMarcadores()
        {
            SendKeys(fieldDescriptionMarkers, "Test "+ GeneralHelpers.ReturnStringWithRandomCharacters(5));
        }
        
        #endregion
    }
}
