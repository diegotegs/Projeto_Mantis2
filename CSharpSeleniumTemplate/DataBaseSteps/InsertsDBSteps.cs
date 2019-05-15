using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
   public class InsertsDBSteps
    {
        public static void CriarMarcadorDB(string nome, string marcador)
        {
            string queryMarcador = InsertsQueries.MassaDeDadosCriarMarcador.Replace("$marcadorDB", nome).Replace("$descriçãoDB", marcador);

            DataBaseHelpers.ExecuteQuery(queryMarcador);
        }

        public static void CriarCampoPersonalizadoDB(string nome)
        {
            string queryCampoPersonalizado = InsertsQueries.MassaCampoPersonalizado.Replace("$campoPersonalizado",nome);
            DataBaseHelpers.ExecuteQuery(queryCampoPersonalizado);
        }
    }
}
