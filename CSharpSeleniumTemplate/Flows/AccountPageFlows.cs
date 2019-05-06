using CSharpSeleniumTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Flows
{
    public class AccountPageFlows
    {
        AccountPage accountPage;

        public AccountPageFlows()
        {
            accountPage = new AccountPage();
        }

        public void ClicarPerfil(string plataforma, string os, string versao)
        {
            accountPage.ClicarAlterarConta();
            accountPage.ClicarPerfil();
            accountPage.PreencherCampoPlataforma(plataforma);
            accountPage.PreencherCampoSO(os);
            accountPage.PreencherCampoVersaoSO(versao);

            accountPage.ClicarEmAdicionarPerfil();
        }
    }
}
