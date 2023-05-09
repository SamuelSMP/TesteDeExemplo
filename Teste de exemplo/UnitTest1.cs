using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using Util;

namespace DemonstracaoTesteAutomatizado
{
    [TestFixture]
    public class TestesNaTelaDeLogin
    {
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void LoginCorreto()
        {
            Utils.NomeDoTeste = "LoginCorreto";
            Utils.driver = driver;
            driver.Navigate().GoToUrl("http://localhost/login/");
            Utils.ChecandoLink("http://localhost/login/");
            driver.FindElement(By.Name("email")).SendKeys("teste@teste.com");
            driver.FindElement(By.Name("senha")).SendKeys("12345");

            Utils.ClickByElement(By.Id("botao"));

            Utils.ChecandoLink("http://localhost/login/SQL%20helper.php");

            Utils.TesteDeuCerto();
            Assert.Pass();
        }

        [Test]
        public void LoginInorreto()
        {
            Utils.NomeDoTeste = "LoginInorreto";
            Utils.driver = driver;
            driver.Navigate().GoToUrl("http://localhost/login/");
            Utils.ChecandoLink("http://localhost/login/");
            driver.FindElement(By.Name("email")).SendKeys("teste@teste.com");
            driver.FindElement(By.Name("senha")).SendKeys("1234567");

            Utils.ClickByElement(By.Id("botao"));
            Utils.ChecandoLink("http://localhost/login/");

            Utils.TesteDeuCerto();
            Assert.Pass();
        }

        [Test]
        public void LinkErradoDeProposito()
        {
            //Este teste foi criado para dar errado de propósito
            Utils.NomeDoTeste = "TesteLoginInorreto";
            Utils.driver = driver;
            driver.Navigate().GoToUrl("http://localhost/login/");
            Utils.ChecandoLink("http://localhost/login/");

            Utils.ClickByElement(By.Id("linkerrado"));

            Utils.ChecandoLink("http://localhost/login/linkcerto");

            Utils.TesteDeuCerto();
            Assert.Pass();
        }

        [OneTimeTearDown]
        public void Finalizacao()
        {
            driver.Quit();
        }
    }

    [TestFixture]
    public class TestesDeSignUp
    {
        IWebDriver driver = new ChromeDriver();

        [Test]
        public void CriandoContaJaExistente()
        {
            Utils.NomeDoTeste = "CriandoContaJaExistente";
            Utils.driver = driver;
            driver.Navigate().GoToUrl("http://localhost/login/");
            Utils.ChecandoLink("http://localhost/login/");

            Utils.ClickByElement(By.Id("signup"));
            Utils.ChecandoLink("http://localhost/login/signup.php");

            driver.FindElement(By.Id("nome")).SendKeys("testeeeee");
            driver.FindElement(By.Id("email")).SendKeys("teste@teste.com");
            driver.FindElement(By.Id("senha")).SendKeys("12345678");

            Utils.ClickByElement(By.Id("botao"));
            Utils.ChecandoLink("http://localhost/login/signup.php");

            Utils.TesteDeuCerto();
            Assert.Pass();
        }

        [Test]
        public void CriandoContaNova()
        {
            Utils.NomeDoTeste = "CriandoContaJaExistente";
            Utils.driver = driver;
            driver.Navigate().GoToUrl("http://localhost/login/");
            Utils.ChecandoLink("http://localhost/login/");

            Utils.ClickByElement(By.Id("signup"));
            Utils.ChecandoLink("http://localhost/login/signup.php");

            driver.FindElement(By.Id("nome")).SendKeys("user");
            Utils.TypeRandomNumber(By.Id("nome"));

            driver.FindElement(By.Id("email")).SendKeys("email");
            Utils.TypeRandomNumber(By.Id("email"));
            driver.FindElement(By.Id("email")).SendKeys("@teste.com");

            driver.FindElement(By.Id("senha")).SendKeys("12345678");

            Utils.ClickByElement(By.Id("botao"));
            Utils.ChecandoLink("http://localhost/login/index.php");

            Utils.TesteDeuCerto();
            Assert.Pass();
        }

        [Test]
        public void CriandoContaSenhaCurta()
        {
            Utils.NomeDoTeste = "CriandoContaJaExistente";
            Utils.driver = driver;
            driver.Navigate().GoToUrl("http://localhost/login/");
            Utils.ChecandoLink("http://localhost/login/");

            Utils.ClickByElement(By.Id("signup"));
            Utils.ChecandoLink("http://localhost/login/signup.php");

            driver.FindElement(By.Id("nome")).SendKeys("user");
            Utils.TypeRandomNumber(By.Id("nome"));

            driver.FindElement(By.Id("email")).SendKeys("email");
            Utils.TypeRandomNumber(By.Id("email"));
            driver.FindElement(By.Id("email")).SendKeys("@teste.com");

            driver.FindElement(By.Id("senha")).SendKeys("123");

            Utils.ClickByElement(By.Id("botao"));
            Utils.ChecandoLink("http://localhost/login/signup.php");

            Utils.TesteDeuCerto();
            Assert.Pass();
        }

        [OneTimeTearDown]
        public void Finalizacao()
        {
            driver.Quit();
        }
    }
}