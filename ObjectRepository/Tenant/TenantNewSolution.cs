using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.Tenant
{
    class TenantNewSolution
    {
        private IWebDriver driver;

        public TenantNewSolution(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SkipLink
        {
            get
            {
                return this.driver.FindElement(By.ClassName("touFtr-skip"));
            }
        }

        public IWebElement NewSolutionButton
        {
            get
            {
                return this.driver.FindElement(By.Id("eb-new-solution"));
            }
        }

        public IWebElement MessagePopUpClose
        {
            get
            {
                return this.driver.FindElement(By.Id("eb-popbox-close"));
            }
        }
    }
}
