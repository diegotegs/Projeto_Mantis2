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
    

        public static string RetornaResumoCriadoDB(string resumo)
        {
            string queryId = SelectsQueries.RetornaTarefaPorResumo.Replace("$resumo",resumo);
            return DataBaseHelpers.RetornaDadosQuery(queryId)[0];
        }

        public static string RetornaResumoCriadoSemParameroDB()
        {
            string queryId = SelectsQueries.RetornarTarefa;
            return DataBaseHelpers.RetornaDadosQuery(queryId)[0];
        }

        public static List<string> RetornaPerfilDB(string osGerado)
        {
            string queryPerfil = SelectsQueries.RetornaPerfilAdicionado.Replace("$os", osGerado);
            return DataBaseHelpers.RetornaDadosQuery(queryPerfil);
        }

        public static string RetornaCampoPersonalizadoCadastradoDB(string nome)
        {
            string queryCampoPersonaalizado = SelectsQueries.RetornoCampoPersonalizadoDB.Replace("$namePersonalizado", nome);
            return DataBaseHelpers.RetornaDadosQuery(queryCampoPersonaalizado)[0];
        }
        
        public static int RetornarQtDeCampoExpecificoDB(string nome)
        {
            string queryPersonalizado = SelectsQueries.RetornaQuantidadeDeCampoPersonalizadoExpecifico.Replace("$personalizado", nome);
            string campo = DataBaseHelpers.RetornaDadosQuery(queryPersonalizado)[0];
            return Convert.ToInt32(campo);
        }
            
        public static string RetornaConvidadoAdicionadoDB(string nome)
        {
            string query = SelectsQueries.RetornaUsuarioExpecifico.Replace("$convidado", nome);
            return DataBaseHelpers.RetornaDadosQuery(query)[0];

        }
        public static string RetornaMarcadoresCriadoDB(string nome)
        {
            string queryMarcador = SelectsQueries.RetoraMarcadorExpecifico.Replace("$tag", nome);
            return DataBaseHelpers.RetornaDadosQuery(queryMarcador)[0];
        }

        public static int VerificarMarcadorDeletadoDB(string nome )
        {
            string query = SelectsQueries.RetornaQuantidadeDeMarcadoresExistente.Replace("$marcador", nome);
            return Convert.ToInt32(DataBaseHelpers.RetornaDadosQuery(query)[0]);
        }

        public static int VerificarQuantidadeDePerfilExistenteDB(string plataforma)
        {
            string query = SelectsQueries.RetornaQuantidadePerfilExistente.Replace("$plataforma", plataforma);
            return Convert.ToInt32(DataBaseHelpers.RetornaDadosQuery(query)[0]);
        }

        public static int RetornaQuantidadeDeProjetosCriadosDB()
        {
            string query = SelectsQueries.RetornaQuantidadeDeProjetoExistente;
            return Convert.ToInt32(DataBaseHelpers.RetornaDadosQuery(query)[0]);
            
        }

        public static int RetornaQuantidadeDeTarefasExistenteDB()
        {
            string query = SelectsQueries.RetornaSeApagouTarefa;
            return Convert.ToInt32(DataBaseHelpers.RetornaDadosQuery(query)[0]);
        }

       

        }

    }

