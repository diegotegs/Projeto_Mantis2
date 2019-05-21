using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
    public class DeleteChargesDBSteps
    {
       

        public static void SetUpDB()
        {
            string query = DeleteQueries.LimparBanco;
            DataBaseHelpers.ExecuteQuery(query);
        }

        public static void OneTimeTearDB()
        {
            string query = DeleteQueries.LimparProjeto;
            DataBaseHelpers.ExecuteQuery(query);
            
        }

        public static void DeletaUsuariosDB()
        {
            DataBaseHelpers.ExecuteQuery(DeleteQueries.DeletaUsuariosCriado);

        }
    }
}
