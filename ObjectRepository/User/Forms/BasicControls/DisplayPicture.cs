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


        public IWebElement DisplayPicture2Input
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture2-file-input"));
            }
        }

        public IWebElement DisplayPicture2Change
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"DisplayPicture2Wraper\"]/div[2]/div[3]"));
            }
        }

        public IWebElement DisplayPicture2UploadButton
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture2-upload-lin"));
            }
        }

        public IWebElement DisplayPicture3
        {
            get
            {
                return this.driver.FindElement(By.Id("displaypicture3"));
            }
        }


        public IWebElement DisplayPicture3Input
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture3-file-input"));
            }
        }

        public IWebElement DisplayPicture3Change
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"DisplayPicture3Wraper\"]/div[2]/div[3]"));
            }
        }

        public IWebElement DisplayPicture3UploadButton
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture3-upload-lin"));
            }
        }

        public IWebElement DisplayPicture4
        {
            get
            {
                return this.driver.FindElement(By.Id("displaypicture4"));
            }
        }


        public IWebElement DisplayPicture4Input
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture4-file-input"));
            }
        }

        public IWebElement DisplayPicture4Change
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"DisplayPicture4Wraper\"]/div[2]/div[3]"));
            }
        }

        public IWebElement DisplayPicture4UploadButton
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture4-upload-lin"));
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


        public IWebElement DisplayPicture7Input
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture7-file-input"));
            }
        }
        

        public IWebElement DisplayPicture7UploadButton
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture7-upload-lin"));
            }
        }

        public IWebElement DisplayPicture7Change
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"DisplayPicture7Wraper\"]/div[2]/div[3]"));
            }
        }

        public IWebElement DisplayPicture7CropResize
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_DisplayPicture7_cropy_container\"]/div[1]/div[1]"));
            }
        }

        public IWebElement DisplayPicture8
        {
            get
            {
                return this.driver.FindElement(By.Id("displaypicture8"));
            }
        }


        public IWebElement DisplayPicture8Input
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture8-file-input"));
            }
        }
        
        public IWebElement DisplayPicture8UploadButton
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture8-upload-lin"));
            }
        }

        public IWebElement DisplayPicture8Change
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"DisplayPicture8Wraper\"]/div[2]/div[3]"));
            }
        }

        public IWebElement DisplayPicture8CropResize
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_DisplayPicture8_cropy_container\"]/div[1]/div[1]"));
            }
        }
        
        public IWebElement DisplayPicture9
        {
            get
            {
                return this.driver.FindElement(By.Id("displaypicture9"));
            }
        }

        public IWebElement DisplayPicture9FullScreen
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[14]/div/img"));
            }
        }


        public IWebElement DisplayPicture9Input
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture9-file-input"));
            }
        }

        public IWebElement DisplayPicture9Change
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"DisplayPicture9Wraper\"]/div[2]/div[3]"));
            }
        }

        public IWebElement DisplayPicture9UploadButton
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_DisplayPicture9-upload-lin"));
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
