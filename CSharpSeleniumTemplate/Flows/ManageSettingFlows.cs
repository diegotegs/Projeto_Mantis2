using CSharpSeleniumTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Flows
{
    public class ManageSettingFlows
    {
        #region Page Object and Constructor
        ManagePage managePage;

        public ManageSettingFlows()
        {
            managePage = new ManagePage();
        }
        #endregion

        public void GerenciarConfiguracaoSubsMenu()
        {
            managePage.ClicarMenuGerenciar();
            managePage.ClicarGerenciarConfiguracoes();
        }
    }
}
