using CSharpSeleniumTemplate.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
    class CreateTaskDBSteps
    {
        public static void CriarTarefa()
        {
           
            DataBaseHelpers.ExecuteQuery("INSERT INTO mantis_tag_table (user_id,NAME,description) VALUES(1,'XPTO 2019','');");
            DataBaseHelpers.ExecuteQuery("INSERT INTO mantis_bug_tag_table(bug_id,tag_id,user_id) VALUES (1,1,1);");
            DataBaseHelpers.ExecuteQuery("INSERT INTO mantis_bug_text_table (id,description,steps_to_reproduce,additional_information) VALUES(1,'Teste Descricao','reproduz', 'informaçoes');");
            DataBaseHelpers.ExecuteQuery(@"INSERT INTO mantis_bug_table (project_id,reporter_id,handler_id,duplicate_id,priority,severity,reproducibility,STATUS,resolution,projection,
eta,bug_text_id,os,os_build,platform,version,fixed_in_version,build,profile_id,view_state,summary,sponsorship_total,sticky,target_version,
category_id)VALUES(1,1,0,0,30,50,70,10,10,10,10,1,'mj',43,'MJFSS', '','','',24,10,'Teste', 0,0,'',1); ");
        }
    }
}
