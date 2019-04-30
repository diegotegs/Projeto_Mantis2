using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class ChangeLogPage : PageBase
    {
        #region Mapping
        By changeLogMenu = By.XPath("//li[4]/a/span");
        By msgValidate = By.CssSelector("p.lead");
        #endregion
        #region Actions
        public void ClicarMenuRegistroDeMudanca()
        {
            Click(changeLogMenu);
        }

        public string RetornarMsg()
        {
            return GetText(msgValidate);
        }
        #endregion
    }
}
