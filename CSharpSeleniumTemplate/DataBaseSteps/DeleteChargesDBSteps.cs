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
            DataBaseHelpers.ExecuteQuery(" TRUNCATE TABLE mantis_bug_text_table;");
            DataBaseHelpers.ExecuteQuery(" TRUNCATE TABLE mantis_bug_table;");
            DataBaseHelpers.ExecuteQuery(" TRUNCATE TABLE mantis_tag_table;");
            DataBaseHelpers.ExecuteQuery(" TRUNCATE TABLE mantis_bug_tag_table;");
            DataBaseHelpers.ExecuteQuery("TRUNCATE TABLE mantis_custom_field_table;");
            DataBaseHelpers.ExecuteQuery("TRUNCATE TABLE mantis_user_profile_table;");
        }

        public static void OneTimeTearDB()
        {
            DataBaseHelpers.ExecuteQuery("TRUNCATE TABLE  mantis_project_table ;");
            
        }

        public static void DeletaUsuarios()
        {
            DataBaseHelpers.ExecuteQuery(DeleteQueries.DeletaUsuariosCriado);
        }
    }
}
