﻿using CSharpSeleniumTemplate.Bases;
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
        By menuManage = By.CssSelector("i.menu-icon.fa.fa-gears");
        By linkManageUser = By.LinkText("Gerenciar Usuários");
        By btnCreateNewAccount = By.XPath("//div[@id='manage-user-div']/div/form/fieldset/button");
        By linkManageProject = By.LinkText("Gerenciar Projetos");
        By btnCreateNewProject = By.XPath("//button[@type='submit']");
        By linkManageMarkers = By.LinkText("Gerenciar Marcadores");        
        By linkAllMarkers = By.LinkText("TODAS");
        By linkManageFiled = By.LinkText("Gerenciar Campos Personalizados");
        By btnNewField = By.XPath("//input[@value='Novo Campo Personalizado']");
        By linkProfileGlobal = By.LinkText("Gerenciar Perfís Globais");
        By btnAddProfile = By.XPath("//input[@value='Adicionar Perfil']");
        By linkManagePlugins = By.LinkText("Gerenciar Plugins");
        By btnRefresh = By.XPath("//input[@value='Atualizar']");
        By linkManageSetting = By.LinkText("Gerenciar Configuração");
        By btnPermissionReport = By.LinkText("Relatório de Permissões");

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

        #endregion
    }
}
