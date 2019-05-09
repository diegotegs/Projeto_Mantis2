using CSharpSeleniumTemplate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
    public class DeleteTodosProjetos
    {
        public static void DeletarProjetos()
        {
             DataBaseHelpers.ExecuteQuery();
        }
    }
}
