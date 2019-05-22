using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
   public  class ProfileDBSteps
    {
        public static string RetornaPerfilDB(string osGerado)
        {
            string queryPerfil = SelectsQueries.RetornaPerfilAdicionado.Replace("$os", osGerado);
            return DataBaseHelpers.RetornaDadosQuery(queryPerfil)[0];
        }

        public static void CriarPerfilDB(string plat, string osDB, string build)
        {
            string query = InsertsQueries.MassaDeDadoCriarPerfil.Replace("$plataforma", plat).
                Replace("$so", osDB).Replace("$build", build);
            DataBaseHelpers.ExecuteQuery(query);
        }

        public static List<string> RetornaListPerfilDB(string osGerado)
        {
            string queryPerfil = SelectsQueries.RetornaPerfilAdicionado.Replace("$os", osGerado);
            return DataBaseHelpers.RetornaDadosQuery(queryPerfil);
        }

        public static string RetornaConvidadoAdicionadoDB(string nome)
        {
            string query = SelectsQueries.RetornaUsuarioExpecifico.Replace("$convidado", nome);
            return DataBaseHelpers.RetornaDadosQuery(query)[0];

        }

        public static int VerificarQuantidadeDePerfilExistenteDB(string plataforma)
        {
            string query = SelectsQueries.RetornaQuantidadePerfilExistente.Replace("$plataforma", plataforma);
            return Convert.ToInt32(DataBaseHelpers.RetornaDadosQuery(query)[0]);
        }
    }
}
