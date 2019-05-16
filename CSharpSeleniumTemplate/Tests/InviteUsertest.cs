using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.DataBaseSteps;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;


namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    public class InviteUserTest : TestBase
    {

        #region Pages and Flows Objects
        [AutoInstance] LoginFlows loginFlows;
        [AutoInstance] InviteUserPage inviteUserPage;
        #endregion

        [Test]
        [Category("AdicionarUsuarioAoProjeto")]
        public void ConvitarUsuario()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion
            DeleteChargesDBSteps.DeletaUsuarios();
            loginFlows.EfetuarLogin(usuario, senha);

            inviteUserPage.ClicarConvidarUsuario();
            inviteUserPage.PreencherUsuario();
            inviteUserPage.PreencherRealNome();
            inviteUserPage.PreencherEmail();
            inviteUserPage.SelecionarNivelDeAcesso();
            inviteUserPage.ClicarEmCriarNovoUsuario();

            Assert.AreEqual(inviteUserPage.returnUser, SelectsDBSteps.RetornaConvidadoAdicionado(inviteUserPage.returnUser));
            Assert.True(inviteUserPage.ValidarMenssagemSucesso().Contains(inviteUserPage.returnUser));
        }
    }
}
