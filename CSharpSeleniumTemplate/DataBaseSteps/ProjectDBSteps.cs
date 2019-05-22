using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
    public class ProjectDBSteps
    {
        public static void CriarProjetoBD(string nome, string descricao)
        {
            
            string inserirProjeto = CriarProjetoQueries.MassaDeDadosCriarProjeto.Replace("$name", nome ).
                Replace("$descricao", descricao);
            
            DataBaseHelpers.ExecuteQuery(inserirProjeto);
            
        }

        public static int RetornaQuantidadeDeProjetosCriadosDB()
        {
            string query = SelectsQueries.RetornaQuantidadeDeProjetoExistente;
            return Convert.ToInt32(DataBaseHelpers.RetornaDadosQuery(query)[0]);

        }
    }
}
