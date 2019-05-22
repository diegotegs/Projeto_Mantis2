using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using NUnit.Framework;
using System.Reflection;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.DataBaseSteps;

namespace CSharpSeleniumTemplate.Bases
{
    public class TestBase
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            ExtentReportHelpers.CreateReport();
        }

        [SetUp]
        public void SetUp()
        {
            //Zera algumas tabelas do banco ao iniciar um teste 
            DeleteChargesDBSteps.SetUpDB();
           //cria um projeto ao iniciar um teste
            ProjectDBSteps.CriarProjetoBD("Test " + GeneralHelpers.ReturnStringWithRandomCharacters(3),
               "Descricao " + GeneralHelpers.ReturnStringWithRandomCharacters(3));                
            
            ExtentReportHelpers.AddTest();
            DriverFactory.CreateInstance();
            DriverFactory.INSTANCE.Manage().Window.Maximize();
            DriverFactory.INSTANCE.Navigate().GoToUrl(Properties.Settings.Default.DEFAUL_APPLICATION_URL);
           


            #region [AutoInstance] atribute methods calls to auto instace pages and flows
            //Necessário para realizar a instanciação automática das páginas e fluxos
            this.ProxyGenerator = new ProxyGenerator();
            InjectPageObjects(CollectPageObjects(), null);
            #endregion
        }

        [TearDown]
        public void TearDown()
        {
            ExtentReportHelpers.AddTestResult();          
            DriverFactory.QuitInstace();            

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            ExtentReportHelpers.GenerateReport();

            //deleta cargas no final da execução de teste
            DeleteChargesDBSteps.OneTimeTearDB();


        }

        #region Methodes needed to auto intance pages and flows [AutoInstance]
        //Esses métodos necessariamente precisam estar nesta classe, não funciona se estiverem em outro arquivo.
        private ProxyGenerator ProxyGenerator;

        private void InjectPageObjects(List<FieldInfo> fields, IInterceptor proxy)
        {
            foreach (FieldInfo field in fields)
            {
                field.SetValue(this, ProxyGenerator.CreateClassProxy(field.FieldType, proxy));
            }
        }

        private List<FieldInfo> CollectPageObjects()
        {
            List<FieldInfo> fields = new List<FieldInfo>();

            foreach (FieldInfo field in this.GetType().GetRuntimeFields())
            {
                if (field.GetCustomAttribute(typeof(AutoInstance)) != null)
                    fields.Add(field);
            }

            return fields;
        }
        #endregion
    }
}
