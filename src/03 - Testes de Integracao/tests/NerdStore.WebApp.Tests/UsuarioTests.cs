using NerdStore.WebApp.MVC;
using NerdStore.WebApp.Tests.Config;
using System;

namespace NerdStore.WebApp.Tests
{
    class UsuarioTests
    {
        private readonly IntegrationTestsFixture<StartupWebTests> _testsFixture;

        public UsuarioTests(IntegrationTestsFixture<StartupWebTests> testsFixture)
        {
            _testsFixture = testsFixture;
        }


    }
}
