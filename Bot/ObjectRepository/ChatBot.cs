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

        public IWebElement UITestBot1
        {
            get
            {
                return this.driver.FindElement(By.Id("botno7"));
            }
        }

        public IWebElement UITestBot2
        {
            get
            {
                return this.driver.FindElement(By.Id("botno10"));
            }
        }

        public IWebElement UITestBot3
        {
            get
            {
                return this.driver.FindElement(By.Id("botno11"));
            }
        }

        public IWebElement UITestBot4
        {
            get
            {
                return this.driver.FindElement(By.Id("botno12"));
            }
        }

        public IWebElement UITestBot5
        {
            get
            {
                return this.driver.FindElement(By.Id("botno13"));
            }
        }

        public IWebElement UITestBot6
        {
            get
            {
                return this.driver.FindElement(By.Id("botno14"));
            }
        }

        public IWebElement UITestBot7
        {
            get
            {
                return this.driver.FindElement(By.Id("botno5"));
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

        //----------------------------------------------------------------------------------

        public IWebElement BotBodyMsgName
        {
            get
            {
                return this.driver.FindElement(By.Id("anon_name"));
            }
        }

        public IWebElement BotBodyMsgEmail
        {
            get
            {
                return this.driver.FindElement(By.Id("anon_mail"));
            }
        }

        public IWebElement BotBodyMsgPhoneNumber
        {
            get
            {
                return this.driver.FindElement(By.Id("anon_phno"));
            }
        }

        public IWebElement UserId
        {
            get
            {
                return this.driver.FindElement(By.Id("username_id"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.driver.FindElement(By.Id("password_id"));
            }
        }

        public IWebElement OTPLoginId
        {
            get
            {
                return this.driver.FindElement(By.Id("otp_login_id"));
            }
        }

        public IWebElement OTPField
        {
            get
            {
                return this.driver.FindElement(By.Id("partitioned"));
            }
        }

        //----------------------------------------------------------------------

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

        public IWebElement NameSubmitButton
        {
            get
            {
                return this.driver.FindElement(By.Name("contactSubmitName"));
            }
        }

        public IWebElement MailSubmitButton
        {
            get
            {
                return this.driver.FindElement(By.Name("contactSubmitMail"));
            }
        }

        public IWebElement PhoneNumberSubmitButton
        {
            get
            {
                return this.driver.FindElement(By.Name("contactSubmitPhn"));
            }
        }

        public IWebElement PasswordSubmitButton
        {
            get
            {
                return this.driver.FindElement(By.Name("passwordSubmitBtn"));
            }
        }

        public IWebElement OTPIdSubmitButton
        {
            get
            {
                return this.driver.FindElement(By.Name("otpUserSubmitBtn"));
            }
        }

        public IWebElement OTPValidateButton
        {
            get
            {
                return this.driver.FindElement(By.Name("otpvalidateBtn"));
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

        public IWebElement Form6ChooseButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[3]/div/div/div/button[6]"));
            }
        }

        public IWebElement Form7ChooseButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[3]/div/div/div/button[7]"));
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

        public IWebElement LocationAddressClose
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"InputGeoLocation1address\"]/following-sibling::div"));
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

        public IWebElement TVcontrol1SubmitButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_TVcontrol1\"]/following-sibling::div/div"));
            }
        }


        //--------------------------------------------------Image

        public IWebElement ImageInput1
        {
            get
            {
                return this.driver.FindElement(By.Id("SimpleFileUploader1_inputID"));
            }
        }

        public IWebElement ImageInput1Button
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_SimpleFileUploader1\"]/following-sibling::div/button"));
            }
        }

        //-----------------------------------------------------Email

        public IWebElement EmailControl1
        {
            get
            {
                return this.driver.FindElement(By.Id("EmailControl1"));
            }
        }

        public IWebElement EmailControl1Button
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_EmailControl1\"]/following-sibling::div/button"));
            }
        }

        //-------------------------------------------------------BooleanSelect

        public IWebElement BooleanSelect1
        {
            get
            {
                return this.driver.FindElement(By.Id("BooleanSelect1"));
            }
        }

        public IWebElement BooleanSelect1Button
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_BooleanSelect1\"]/following-sibling::div/button"));
            }
        }

        //---------------------------------------------------------Phone

        public IWebElement Phone1
        {
            get
            {
                return this.driver.FindElement(By.Id("Phone1"));
            }
        }

        public IWebElement Phone1Button
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_Phone1\"]/following-sibling::div/button"));
            }
        }

        //--------------------------------------------------------------Date

        public IWebElement Date1
        {
            get
            {
                return this.driver.FindElement(By.Id("Date1"));
            }
        }

        public IWebElement Date1Button
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_Date1\"]/following-sibling::div/button"));
            }
        }

        //----------------------------------------------------------------SimpleSelect

        public IWebElement SimpleSelect1
        {
            get
            {
                return this.driver.FindElement(By.Id("SimpleSelect1"));
            }
        }

        public IWebElement SimpleSelect1Button
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_SimpleSelect1\"]/following-sibling::div/button"));
            }
        }

        //-----------------------------------------------------------------RadioButton

        public IWebElement RadioGroup1Value
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioGroup1_Rd1"));
            }
        }

        public IWebElement RadioGroup1Button
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_RadioGroup1\"]/following-sibling::div/button"));
            }
        }

        public IWebElement RadioButton2
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton2"));
            }
        }

        public IWebElement RadioButton2Button
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_RadioButton2\"]/following-sibling::div/button"));
            }
        }

        //---------------------------------------------------------Numeric1

        public IWebElement Numeric1
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric1"));
            }
        }

        public IWebElement Numeric1Button
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_Numeric1\"]/following-sibling::div/button"));
            }
        }

        //------------------------------------------------------------ButtonSelect

        public IWebElement ButtonSelect1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"ButtonSelect1\"]/div[1]"));
            }
        }

        //---------------------------------------------------------------Ststic Card

        public IWebElement StaticCardSet2NextButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"StaticCardSet2\"]/div/div[2]/button[2]"));
            }
        }

        public IWebElement StaticCardSet2SubmitButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"StaticCardSet2\"]/div/div[3]/button"));
            }
        }

        //---------------------------------------------------------------Locations

        public IWebElement LocationsSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"Locations1\"]/div[1]/select"));
            }
        }

        public IWebElement Locations1SubmitButton
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_Locations1\"]/following-sibling::div/div"));
            }
        }
        //------------------------------------------------------------Image

        public IWebElement Image1
        {
            get
            {
                return this.driver.FindElement(By.Id("Image1"));
            }
        }

        public IWebElement Image1Button
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_Image1\"]/following-sibling::div/div"));
            }
        }

        //------------------------------------------------------------Video

        public IWebElement Video1
        {
            get
            {
                return this.driver.FindElement(By.Id("Video1"));
            }
        }

        public IWebElement Video1Button
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_Video1\"]/following-sibling::div/div"));
            }
        }

        //-------------------------------------------------------------Rating

        
        public IWebElement Rating1Div
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"Rating1\"]/div/div[2]"));
            }
        }

        public IWebElement Rating1Button
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"cont_Rating1\"]/following-sibling::div/button"));
            }
        }

        //----------------------------------------------------------- 

        public IWebElement FormSubmitSuccessMsg
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[2]/div[2]/div"));
            }
        }




        //--------------------------------------------------------------------------ZOHO Mail

        public IWebElement ZohoMailId
        {
            get
            {
                return this.driver.FindElement(By.Id("login_id"));
            }
        }

        public IWebElement MailIdNextButton
        {
            get
            {
                return this.driver.FindElement(By.Id("nextbtn"));
            }
        }

        public IWebElement ZohoPassword
        {
            get
            {
                return this.driver.FindElement(By.Id("password"));
            }
        }

        public IWebElement Mail1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"zm_centerHolder\"]/div/div/div/div[2]/div/div"));
            }
        }

        public IWebElement Mail1Msg
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"zm_centerHolder\"]/div[1]/div/div/div[3]/div[1]/div[1]/div[2]/div[3]/div/div/div"));
            }
        }

    }
}
