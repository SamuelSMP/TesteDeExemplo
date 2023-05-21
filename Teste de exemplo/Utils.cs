using OpenQA.Selenium;
using NUnit.Framework;
using System;
using System.Linq;
using System.Security.Policy;
using System.IO;

namespace Util
{
    public class Utils
    {
        public static IWebDriver driver;

        public static string NomeDoTeste;
        public static string url;

        public static string DataEHora = DateTime.Now.ToString(" d M yyyy  HH mm ss");
        public static string Data = DateTime.Now.ToString("d/M/yyyy HH:mm:ss");

        public static void ClickByElement(By ByElement)
        {
            if (ElementoExiste(ByElement))
            {
                IWebElement element = driver.FindElement(ByElement);
                element.Click();
                Console.WriteLine("Elemento " + ByElement + " clicado!");
                QuickWait(1);
            }
            else
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("alert('Erro: Não foi possível encontrar o elemento -" + ByElement + "-. Um print foi criado e está localizado na pasta -Prints-.')");
                Printar("Erro - elemento não encontrado");
                Console.WriteLine("Texto " + ByElement + " não foi encontrado.");
                Aguarda(3);
                driver.SwitchTo().Alert().Accept();
                throw new Exception("Erro: Elemento " + ByElement + " deveria ser encontrado.");
            }
        }

        public static bool ElementoExiste(By by)
        {
            Console.WriteLine("Verificando se elemento " + by + " existe...");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public static void Aguarda(int segundos)
        {
            System.Threading.Thread.Sleep(segundos * 1000);
        }

        public static void QuickWait(int segundos)
        {
            System.Threading.Thread.Sleep(segundos * 250);
        }

        public static void Printar(string nome)
        {
            DataEHora = DateTime.Now.ToString(" d M yyyy  HH mm ss");
            try
            {
                Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
                image.SaveAsFile("C:/Teste de Exemplo/Prints/" + nome + DataEHora + ".png");
                Console.WriteLine("Um print foi criado na pasta Prints!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                NUnit.Framework.Assert.Fail("Failed with Exception: " + e);
            }
        }

        public static void ChecandoLink(string link)
        {
            Utils.Aguarda(1);
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            if (driver.Url.StartsWith($"{url}/erro.aspx"))
            {
                Printar("Exceção durante o processamento");
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("alert('Apareceu uma tela de erro. O teste será interrompido. Um print foi criado e está localizado na pasta -Prints-.')");
                Console.WriteLine("Apareceu uma tela de erro de exceção no site.");
                EscreverFeedbackNoLog("Apareceu uma tela de erro de exceção no site.");
                Aguarda(3);
                throw new Exception("Apareceu uma tela de erro de exceção no site.");
            }
            else if (driver.Url.StartsWith(link))
            {
                Utils.Aguarda(1);
            }
            else
            {
                Printar("Erro na checagem do link");
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("alert('Erro na checagem do link: O link atual não é o link que deveria ser. O teste será interrompido. Um print foi criado e está localizado na pasta -Prints-.')");
                Console.WriteLine("Erro na checagem do link. O link deveria começar com: " + link + "");
                EscreverFeedbackNoLog("Erro na checagem do link. O link deveria começar com: " + link + "");
                Aguarda(3);
                throw new Exception("Erro: O link deveria começar com: " + link + ".");
            }
        }

        public static void EscreverFeedbackNoLog(string mensagem)
        {
            Data = DateTime.Now.ToString("d/M/yyyy HH:mm:ss");
            using (StreamWriter writer = File.AppendText("C:/Teste de exemplo/Logs/Feedback universal.txt"))
            {
                writer.WriteLine(Environment.NewLine + Environment.NewLine + NomeDoTeste + " " + Data + Environment.NewLine + mensagem);
            }
            LogSeparado(NomeDoTeste, mensagem);
        }

        public static void LogSeparado(string NomeDoTeste, string mensagem)
        {
            Data = DateTime.Now.ToString("d/M/yyyy HH:mm:ss");
            DataEHora = DateTime.Now.ToString(" d M yyyy  HH mm ss");
            using (StreamWriter writer = File.AppendText("C:/Teste de exemplo/Logs/" + NomeDoTeste + " " + DataEHora + ".txt"))
            {
                writer.WriteLine(Environment.NewLine + Environment.NewLine + NomeDoTeste + " " + Data + Environment.NewLine + mensagem);
            }
        }

        public static void TesteDeuCerto()
        {
            Aguarda(3);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("alert('O teste -" + NomeDoTeste + "- foi executado e rodado com sucesso!')");
            Console.WriteLine("Teste " + NomeDoTeste + " executado com sucesso!");
            EscreverFeedbackNoLog("Teste " + NomeDoTeste + " executado com sucesso!");
            Aguarda(2);
            driver.SwitchTo().Alert().Accept();
        }

        public static void TypeRandomNumber(By ByElement)
        {
            var chars = "123456789";
            var stringChars = new char[4];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);

            IWebElement Element = driver.FindElement(ByElement);
            Element.SendKeys(finalString);
            Aguarda(1);
        }
    }
}