using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
    public class CreateProjectDBSteps
    {
        public static void CriarProjetoBD(string nome, string descricao)
        {
            
            string inserirProjeto = CriarProjetoQueries.MassaDeDadosCriarProjeto.Replace("$name", nome ).
                Replace("$descricao", descricao);
            
            DataBaseHelpers.ExecuteQuery(inserirProjeto);
            
        }
    }
}
