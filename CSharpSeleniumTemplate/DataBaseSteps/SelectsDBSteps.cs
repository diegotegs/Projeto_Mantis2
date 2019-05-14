using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
    public class SelectsDBSteps
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

        public static List<string> RetornaPerfil(string osGerado)
        {
            string queryPerfil = SelectsQueries.RetornaPerfilAdicionado.Replace("$os", osGerado);
            return DataBaseHelpers.RetornaDadosQuery(queryPerfil);
        }

    }
}
