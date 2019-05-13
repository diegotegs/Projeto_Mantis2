using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
    class SelectsDBSteps
    {
        public static List<string> VerificarSeExisteTarefaCriada()
        {
            string queryTarefas = SelectsQueries.VerificarSeExisteTarefera;
            return DataBaseHelpers.RetornaDadosQuery(queryTarefas);

        }

        public static string RetornaResumoCriado(string resumo)
        {
            string queryId = SelectsQueries.RetornaTarefaPorResumo.Replace("$resumo",resumo);
            return DataBaseHelpers.RetornaDadosQuery(queryId)[0];
        }
    }
}
