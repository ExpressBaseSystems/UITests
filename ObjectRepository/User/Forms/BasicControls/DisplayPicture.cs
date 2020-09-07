using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User.Forms.BasicControls
{
    class DisplayPicture
    {
        private IWebDriver driver;

        public DisplayPicture(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FormMode
        {
            get
            {
                return this.driver.FindElement(By.ClassName("fmode"));
            }
        }

        public IWebElement DisplayPicture1
        {
            get
            {
                return this.driver.FindElement(By.Id("displaypicture1"));
            }
        }

        public IWebElement DisplayPicture1Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture1"));
            }
        }

        public IWebElement DisplayPicture2
        {
            get
            {
                return this.driver.FindElement(By.Id("displaypicture2"));
            }
        }

        public IWebElement DisplayPicture2Div
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture2"));
            }
        }

        public IWebElement DisplayPicture3
        {
            get
            {
                return this.driver.FindElement(By.Id("displaypicture3"));
            }
        }

        public IWebElement DisplayPicture4
        {
            get
            {
                return this.driver.FindElement(By.Id("displaypicture4"));
            }
        }

        public IWebElement DisplayPicture5
        {
            get
            {
                return this.driver.FindElement(By.Id("displaypicture5"));
            }
        }

        public IWebElement DisplayPicture5Input
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture5-file-input"));
            }
        }

        public IWebElement DisplayPicture5Change
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"DisplayPicture5Wraper\"]/div[2]/div[3]"));
            }
        }

        public IWebElement DisplayPicture5UploadButton
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture5-upload-lin"));
            }
        }

        public IWebElement DisplayPicture5Button
        {
            get
            {
                return this.driver.FindElement(By.ClassName("browse-btn"));
            }
        }

        public IWebElement DisplayPicture6
        {
            get
            {
                return this.driver.FindElement(By.Id("displaypicture6"));
            }
        }

        public IWebElement DisplayPicture6Input
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture6-file-input"));
            }
        }

        public IWebElement DisplayPicture6Change
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"DisplayPicture6Wraper\"]/div[2]/div[3]"));
            }
        }

        public IWebElement DisplayPicture6UploadButton
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture6-upload-lin"));
            }
        }

        public IWebElement DisplayPicture6Button
        {
            get
            {
                return this.driver.FindElement(By.ClassName("browse-btn"));
            }
        }

        public IWebElement DisplayPicture6CropResize
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_DisplayPicture6_cropy_container\"]/div[1]/div[3]"));
            }
        }

        public IWebElement DisplayPicture6CropButton
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture6-crop-lin"));
            }
        }

        public IWebElement DisplayPicture7
        {
            get
            {
                return this.driver.FindElement(By.Id("displaypicture7"));
            }
        }

        public IWebElement DisplayPicture8
        {
            get
            {
                return this.driver.FindElement(By.Id("displaypicture8"));
            }
        }

        public IWebElement DisplayPicture9
        {
            get
            {
                return this.driver.FindElement(By.Id("displaypicture9"));
            }
        }

        public IWebElement SaveButton
        {
            get
            {
                return this.driver.FindElement(By.Id("webformsave"));
            }
        }

        public IWebElement EditButton
        {
            get
            {
                return this.driver.FindElement(By.Id("webformedit"));
            }
        }

    }
}
