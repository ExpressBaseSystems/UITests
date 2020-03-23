using OpenQA.Selenium;

namespace UITests.ObjectRepository
{
    public class Login
    {
        private IWebDriver driver;

        public Login(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement UserName
        {
            get
            {
                return this.driver.FindElement(By.Name("uname"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.driver.FindElement(By.Name("pass"));
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                return this.driver.FindElement(By.Id("logNow"));
            }
        }

        public IWebElement UNameCheckValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//div[@validator='email']/div[2]"));
            }
        }

        public IWebElement PasswordCheckValidator
        {
            get
            {
                return this.driver.FindElement(By.XPath("//div[@validator='password']/div[2]"));
            }
        }

        public IWebElement NewSolutionButton
        {
            get
            {
                return this.driver.FindElement(By.Id("eb-new-solution"));
            }
        }

        public IWebElement ApplicationName
        {
            get
            {
                return this.driver.FindElement(By.Id("appName"));
            }
        }
        
        public IWebElement ApplicationDescription
        {
            get
            {
                return this.driver.FindElement(By.Id("DescApp"));
            }
        }

        public IWebElement ApplicationIcon
        {
            get
            {
                return this.driver.FindElement(By.Name("AppIcon"));
            }
        }

        public IWebElement SkipTour
        {
            get
            {
                return this.driver.FindElement(By.ClassName("touFtr-skip"));
            }
        }
    }
}
