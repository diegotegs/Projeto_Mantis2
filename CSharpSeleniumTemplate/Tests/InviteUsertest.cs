﻿using CSharpSeleniumTemplate.Bases;
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
        public void ConvitarUsuario()
        {
            #region Parameters
            string usuario = Properties.Settings.Default.DEFAULT_USER;
            string senha = Properties.Settings.Default.DEFAULT_PASSWORD;
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            inviteUserPage.ClicarConvidarUsuario();
            inviteUserPage.PreencherUsuario();
            inviteUserPage.PreencherRealNome();
            inviteUserPage.PreencherEmail();
            inviteUserPage.SelecionarNivelDeAcesso();
            inviteUserPage.ClicarEmCriarNovoUsuario();
            Assert.True(inviteUserPage.ValidarMenssagemSucesso().Contains(inviteUserPage.returnUser));
        }
    }
}