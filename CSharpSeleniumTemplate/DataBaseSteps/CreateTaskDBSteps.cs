using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
    class CreateTaskDBSteps
    {
        public static void MassaCriarTarefa()
        {
            string dadosCriarTarefas = CriarTarefasQueries.MassaDeDadosCriarTarefas + 
                CriarTarefasQueries.MassaAdicionarMarcadores + 
                CriarTarefasQueries.MassaPreencherCamposTarefa + 
                CriarTarefasQueries.MassaPreencherOsCampos;            
            DataBaseHelpers.ExecuteQuery( dadosCriarTarefas);
        }
    }
}
