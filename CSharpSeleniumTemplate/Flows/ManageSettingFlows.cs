using CSharpSeleniumTemplate.Pages;


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
