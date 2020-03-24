using OpenQA.Selenium;

namespace UITests.ObjectRepository.Tenant
{
    public class TenantLogin
    {
        private IWebDriver driver;

        public TenantLogin(IWebDriver driver)
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

        public IWebElement TestResult
        {
            get
            {
                return this.driver.FindElement(By.Id("eb_messageBox_container"));
            }
        }

    }
}
