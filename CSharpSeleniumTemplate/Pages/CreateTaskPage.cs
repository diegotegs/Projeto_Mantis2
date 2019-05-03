using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;

namespace CSharpSeleniumTemplate.Pages
{
   public class CreateTaskPage : PageBase
    {
        #region Mapping
        By selectCategory = By.Id("category_id");
        By summaryField = By.Id("summary");
        By descriptionField = By.Id("description");
        By menuCriarTarefa = By.CssSelector("i.menu-icon.fa.fa-edit");       
        By buttonCreateNewTask = By.XPath("//div[2]/input");
        By validateLink = By.XPath("//p");
        
        #endregion

        #region Actions
        public void ClicarIdentificador()
        {
            Click(selectCategory);
        }
        public void PreencherResumo(string resumo)
        {
            SendKeys(summaryField,resumo);
        }
        public void PreencherDescricao(string descricao)
        {
            SendKeys(descriptionField, descricao);
        }

        public void ClicarCriarNovaTarefa()
        {
            Click(buttonCreateNewTask);
        }
        public void ClicarMenuNovaTarefa()
        {
            Click(menuCriarTarefa);
        }
        public string ValidarCriarTarefa()
        {
            return GetText(validateLink);
        }
      
        public string RetornarMsgDescricao(string atributo)
        {
            return GetAttribute(descriptionField,atributo);
        }

        public string RetornarMsgResumo(string atributo)
        {
            return GetAttribute(summaryField, atributo);
        }





        #endregion
    }
}
