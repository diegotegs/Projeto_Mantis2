using CSharpSeleniumTemplate.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Flows
{
   public class CreateTaskFlows 
    {

        #region Page Object and Constructor
        CreateTaskPage createTaskPage;

        public CreateTaskFlows()
        {
            createTaskPage = new CreateTaskPage();
        }
        #endregion
        public void CriarTarefa(string resumo , string descricao)
        {
            createTaskPage.ClicarMenuNovaTarefa();
            createTaskPage.ClicarIdentificador();
            createTaskPage.PreencherResumo(resumo);
            createTaskPage.PreencherDescricao(descricao);
            createTaskPage.ClicarCriarNovaTarefa();
        }

        
    }
}
