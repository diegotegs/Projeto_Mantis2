﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSharpSeleniumTemplate.Queries {
    using System;
    
    
    /// <summary>
    ///   Uma classe de recurso de tipo de alta segurança, para pesquisar cadeias de caracteres localizadas etc.
    /// </summary>
    // Essa classe foi gerada automaticamente pela classe StronglyTypedResourceBuilder
    // através de uma ferramenta como ResGen ou Visual Studio.
    // Para adicionar ou remover um associado, edite o arquivo .ResX e execute ResGen novamente
    // com a opção /str, ou recrie o projeto do VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SelectsQueries {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SelectsQueries() {
        }
        
        /// <summary>
        ///   Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CSharpSeleniumTemplate.Queries.SelectsQueries", typeof(SelectsQueries).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Substitui a propriedade CurrentUICulture do thread atual para todas as
        ///   pesquisas de recursos que usam essa classe de recurso de tipo de alta segurança.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT name FROM mantis_tag_table
        ///WHERE NAME = &apos;$tag&apos;;.
        /// </summary>
        internal static string RetoraMarcadorExpecifico {
            get {
                return ResourceManager.GetString("RetoraMarcadorExpecifico", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT platform  FROM mantis_user_profile_table 
        ///WHERE os = &apos;$os&apos;;.
        /// </summary>
        internal static string RetornaPerfilAdicionado {
            get {
                return ResourceManager.GetString("RetornaPerfilAdicionado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT COUNT(*) from mantis_custom_field_table
        ///WHERE NAME = &apos;$personalizado&apos;;.
        /// </summary>
        internal static string RetornaQuantidadeDeCampoPersonalizadoExpecifico {
            get {
                return ResourceManager.GetString("RetornaQuantidadeDeCampoPersonalizadoExpecifico", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT COUNT(*) AS Marcadores FROM mantis_tag_table
        ///WHERE NAME = &apos;$marcador&apos;;.
        /// </summary>
        internal static string RetornaQuantidadeDeMarcadoresExistente {
            get {
                return ResourceManager.GetString("RetornaQuantidadeDeMarcadoresExistente", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT COUNT(*) AS projetos FROM mantis_project_table;.
        /// </summary>
        internal static string RetornaQuantidadeDeProjetoExistente {
            get {
                return ResourceManager.GetString("RetornaQuantidadeDeProjetoExistente", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT COUNT(platform) AS plataforma FROM mantis_user_profile_table 
        ///WHERE platform = &apos;$plataforma&apos;;.
        /// </summary>
        internal static string RetornaQuantidadePerfilExistente {
            get {
                return ResourceManager.GetString("RetornaQuantidadePerfilExistente", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT summary FROM  mantis_bug_table;.
        /// </summary>
        internal static string RetornarTarefa {
            get {
                return ResourceManager.GetString("RetornarTarefa", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT COUNT(*) AS Tarefas FROM mantis_bug_table;.
        /// </summary>
        internal static string RetornaSeApagouTarefa {
            get {
                return ResourceManager.GetString("RetornaSeApagouTarefa", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT summary FROM  mantis_bug_table
        ///WHERE summary = &apos;$resumo&apos;;.
        /// </summary>
        internal static string RetornaTarefaPorResumo {
            get {
                return ResourceManager.GetString("RetornaTarefaPorResumo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT username FROM mantis_user_table
        ///WHERE username =&apos;$convidado&apos;;.
        /// </summary>
        internal static string RetornaUsuarioExpecifico {
            get {
                return ResourceManager.GetString("RetornaUsuarioExpecifico", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a SELECT name FROM mantis_custom_field_table
        ///WHERE NAME = &apos;$namePersonalizado&apos;;.
        /// </summary>
        internal static string RetornoCampoPersonalizadoDB {
            get {
                return ResourceManager.GetString("RetornoCampoPersonalizadoDB", resourceCulture);
            }
        }
    }
}
