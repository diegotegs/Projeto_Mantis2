using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
    class TaskDBSteps
    {
        public static void CriarTarefaDB()
        {
            string dadosCriarTarefas = CriarTarefasQueries.MassaDeDadosCriarTarefas + 
                CriarTarefasQueries.MassaDeDadosAdicionarMarcadores + 
                CriarTarefasQueries.MassaDeDadosPreencherCamposTarefa + 
                CriarTarefasQueries.MassaDeDadosPreencherOsCampos;            
            DataBaseHelpers.ExecuteQuery( dadosCriarTarefas);
        }

        public static void CriarMarcadorDB(string nome, string marcador)
        {
            string queryMarcador = InsertsQueries.MassaDeDadosCriarMarcador.Replace("$marcadorDB", nome).Replace("$descriçãoDB", marcador);

            DataBaseHelpers.ExecuteQuery(queryMarcador);
        }

        public static void CriarCampoPersonalizadoDB(string nome)
        {
            string queryCampoPersonalizado = InsertsQueries.MassaDeDadosCampoPersonalizado.Replace("$campoPersonalizado", nome);
            DataBaseHelpers.ExecuteQuery(queryCampoPersonalizado);
        }

        public static int RetornaQuantidadeDeTarefasExistenteDB()
        {
            string query = SelectsQueries.RetornaSeApagouTarefa;
            return Convert.ToInt32(DataBaseHelpers.RetornaDadosQuery(query)[0]);
        }

        public static string RetornaMarcadoresCriadoDB(string nome)
        {
            string queryMarcador = SelectsQueries.RetoraMarcadorExpecifico.Replace("$tag", nome);
            return DataBaseHelpers.RetornaDadosQuery(queryMarcador)[0];
        }

        public static int VerificarMarcadorDeletadoDB(string nome)
        {
            string query = SelectsQueries.RetornaQuantidadeDeMarcadoresExistente.Replace("$marcador", nome);
            return Convert.ToInt32(DataBaseHelpers.RetornaDadosQuery(query)[0]);
        }

        public static string RetornaResumoCriadoDB(string resumo)
        {
            string queryId = SelectsQueries.RetornaTarefaPorResumo.Replace("$resumo", resumo);
            return DataBaseHelpers.RetornaDadosQuery(queryId)[0];
        }

        public static string RetornaResumoCriadoSemParameroDB()
        {
            string queryId = SelectsQueries.RetornarTarefa;
            return DataBaseHelpers.RetornaDadosQuery(queryId)[0];
        }

        public static string RetornaCampoPersonalizadoCadastradoDB(string nome)
        {
            string queryCampoPersonaalizado = SelectsQueries.RetornoCampoPersonalizadoDB.Replace("$namePersonalizado", nome);
            return DataBaseHelpers.RetornaDadosQuery(queryCampoPersonaalizado)[0];
        }

        public static int RetornarQtDeCampoPersonalizadoExpecificoDB(string nome)
        {
            string queryPersonalizado = SelectsQueries.RetornaQuantidadeDeCampoPersonalizadoExpecifico.Replace("$personalizado", nome);
            string campo = DataBaseHelpers.RetornaDadosQuery(queryPersonalizado)[0];
            return Convert.ToInt32(campo);
        }

    }
}
