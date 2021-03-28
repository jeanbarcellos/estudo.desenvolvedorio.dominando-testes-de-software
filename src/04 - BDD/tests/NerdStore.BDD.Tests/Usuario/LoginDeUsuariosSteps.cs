using System;
using TechTalk.SpecFlow;

namespace NerdStore.BDD.Tests.Usuario
{
    [Binding]
    public class LoginDeUsuariosSteps
    {
        [When(@"Ele clicar em login")]
        public void QuandoEleClicarEmLogin()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Preencher os dados do formulario de login")]
        public void QuandoPreencherOsDadosDoFormularioDeLogin(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Clicar no botão login")]
        public void QuandoClicarNoBotaoLogin()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
