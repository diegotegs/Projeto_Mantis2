using CSharpSeleniumTemplate.Pages;

namespace CSharpSeleniumTemplate.Flows
{
    public class ManageFieldCustomFlows
    {
        #region Page Object and Constructor
        ManageFieldCustomPage manageFieldCustomPage;

        public ManageFieldCustomFlows()
        {
            manageFieldCustomPage = new ManageFieldCustomPage();
        }
        #endregion

        public void GerarCamposPersonalizados()
        {
            manageFieldCustomPage.ClicarGerenciar();
            manageFieldCustomPage.ClicarGerenciarCamposPersonalizados();

        }
    }
}
