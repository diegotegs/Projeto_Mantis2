using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
   public  class ReturnProfileDBSteps
    {
        public static string RetornaPerfilDB(string osGerado)
        {
            string queryPerfil = SelectsQueries.RetornaPerfilAdicionado.Replace("$os", osGerado);
            return DataBaseHelpers.RetornaDadosQuery(queryPerfil)[0];
        }
    }
}
