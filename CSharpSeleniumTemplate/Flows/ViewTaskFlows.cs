using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;


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
            viewTaskPage.ClicarELimparCampoFiltro();

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
