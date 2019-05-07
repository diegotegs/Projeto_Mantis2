using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Flows
{
    public class ViewTaskFlows
    {
        ViewTaskPage viewTaskPage;
        public ViewTaskFlows()
        {
            viewTaskPage = new ViewTaskPage();
        }

        public void SelecionarCombox(string opcao)
        {
            viewTaskPage.ClicarMenuVerTarefa();
            viewTaskPage.LimparCampoFiltro();

            Assume.That(viewTaskPage.VerificarElementoSeExiste());
            viewTaskPage.SelecionarTarefa();
            viewTaskPage.GetPrimeiroConteudoDaTabela();
            viewTaskPage.SelecionarOpcao(opcao);
            viewTaskPage.ClicarBNTOk();
        }

        public void PesquisarElemento()
        {
            viewTaskPage.PreencherFiltroParaPesquisar();
            viewTaskPage.clicarAplicarFiltro();
        }
    }
}
