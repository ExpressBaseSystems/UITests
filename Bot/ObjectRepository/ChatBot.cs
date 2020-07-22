using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.Bot.ObjectRepository
{
    public class ChatBot
    {
        private IWebDriver driver;

        public ChatBot(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement UITestBot
        {
            get
            {
                return this.driver.FindElement(By.Id("botno7"));
            }
        }

        public IWebElement BotFrame
        {
            get
            {
                return this.driver.FindElement(By.Id("eb_iframecont7"));
            }
        }

        public IWebElement BotHeader
        {
            get
            {
                return this.driver.FindElement(By.ClassName("eb__-bot___-eb-chat-head"));
            }
        }

        public IWebElement BotHeaderIcon
        {
            get
            {
                return this.driver.FindElement(By.Id("headerIcon7"));
            }
        }

        public IWebElement BotHeadText
        {
            get
            {
                return this.driver.FindElement(By.ClassName("eb__-bot___-bot-head"));
            }
        }

        public IWebElement BotHeadSubText
        {
            get
            {
                return this.driver.FindElement(By.ClassName("eb__-bot___-headersubtext"));
            }
        }

        public IWebElement BotMaximise
        {
            get
            {
                return this.driver.FindElement(By.Id("maximizediv7"));
            }
        }

        public IWebElement BotClose
        {
            get
            {
                return this.driver.FindElement(By.Id("closediv7"));
            }
        }

        public IWebElement BotBody
        {
            get
            {
                return this.driver.FindElement(By.Id("loderdiv7"));
            }
        }

        public IWebElement BotBodyDate
        {
            get
            {
                return this.driver.FindElement(By.ClassName("chat-date"));
            }
        }

        public IWebElement BotBodyMsgDiv
        {
            get
            {
                return this.driver.FindElement(By.ClassName("msg-cont"));
            }
        }

        public IWebElement BotBodyMsgEmail
        {
            get
            {
                return this.driver.FindElement(By.Id("anon_mail"));
            }
        }

        public IWebElement BotBodyMsgIcon
        {
            get
            {
                return this.driver.FindElement(By.ClassName("bot-icon"));
            }
        }

        public IWebElement BotBodyMsg
        {
            get
            {
                return this.driver.FindElement(By.ClassName("msg-wraper-bot"));
            }
        }

        public IWebElement BotBodyStartOver
        {
            get
            {
                return this.driver.FindElement(By.Id("eb_botStartover"));
            }
        }

        public IWebElement BotBodyPoweredBy
        {
            get
            {
                return this.driver.FindElement(By.ClassName("poweredby-cont"));
            }
        }

        public IWebElement MailSubmitButton
        {
            get
            {
                return this.driver.FindElement(By.Name("contactSubmitMail"));
            }
        }

        //--------------------------------------------------

        public IWebElement Form1ChooseButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[3]/div/div/div/button"));
            }
        }

        public IWebElement Form2ChooseButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[3]/div/div/div/button[2]"));
            }
        }

        public IWebElement Form3ChooseButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[3]/div/div/div/button[3]"));
            }
        }

        public IWebElement Form4ChooseButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[3]/div/div/div/button[4]"));
            }
        }

        public IWebElement Form5ChooseButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[3]/div/div/div/button[5]"));
            }
        }

        //---------------------------------------------------------------

        public IWebElement Form1Icon
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[3]/div/div/div/button/i"));
            }
        }

        //--------------------------------------Text Box
        public IWebElement TextBox1
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox1"));
            }
        }

        public IWebElement TextBox2
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox2"));
            }
        }

        public IWebElement TextBox3
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox3"));
            }
        }

        public IWebElement TextBox4
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox4"));
            }
        }

        public IWebElement TextBox5
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox5"));
            }
        }

        public IWebElement TextBox6
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox6"));
            }
        }

        public IWebElement TextBox7
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox7"));
            }
        }

        public IWebElement TextBox8
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox8"));
            }
        }

        public IWebElement TextBox9
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox9"));
            }
        }

        //--------------------------------------------------------------------------

        public IWebElement TextBoxNameIcon
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_TextBox8\"]/div/span/i"));
            }
        }

        public IWebElement TextBoxPasswordIcon
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_TextBox4\"]/div/span/i"));
            }
        }

        public IWebElement TextBoxEmailIcon
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_TextBox5\"]/div/span/i"));
            }
        }

        //-----------------------------------------------------------------------------

        public IWebElement TextBoxSubmitButton
        {
            get
            {
                return this.driver.FindElement(By.ClassName("ctrlsend"));
            }
        }

        public IWebElement ProceedButton
        {
            get
            {
                return this.driver.FindElement(By.ClassName("ctrlproceedBtn"));
            }
        }

        public IWebElement ColorSubmitButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div[8]/div/div/div/div[2]/button"));
            }
        }


        //---------------------------------------------------------------------------------------

        public IWebElement TextBoxUpperCase
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[9]/div[1]/div"));
            }
        }

        public IWebElement TextBoxLowerCase
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[11]/div[1]/div"));
            }
        }

        public IWebElement TextBoxHelpText
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[4]/div[2]/div"));
            }
        }

        //----------------------------------------------------------------------------------------

        public IWebElement LocationAddress
        {
            get
            {
                return this.driver.FindElement(By.Id("InputGeoLocation1address"));
            }
        }

        public IWebElement LocationAddressButton
        {
            get
            {
                return this.driver.FindElement(By.Id("InputGeoLocation1_subbtn"));
            }
        }

        public IWebElement FormSubmitButton
        {
            get
            {
                return this.driver.FindElement(By.Name("formsubmit"));
            }
        }

        public IWebElement VisualizationSubmitButton
        {
            get
            {
                return this.driver.FindElement(By.ClassName("ctrlproceedBtn"));
            }
        }


    }
}
