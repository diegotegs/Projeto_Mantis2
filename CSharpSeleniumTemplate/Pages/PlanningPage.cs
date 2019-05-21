using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;


namespace CSharpSeleniumTemplate.Pages
{
   public class PlanningPage : PageBase
    {
        #region Mapping
        By menuPlanning = By.XPath("//div[@id='sidebar']/ul/li[5]/a/i");
        By msgEmpty = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/p");
        #endregion

        #region Actions
        public void ClicarPlanejamento()
        {
            Click(menuPlanning);
        }

        public string RetornoPlanejamentoIndisponivel()
        {
            return GetText(msgEmpty);
        }
        #endregion
    }
}
