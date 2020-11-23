using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using UITests.DataDriven;
using UITests.ObjectRepository.User;
using UITests.ObjectRepository.User.Forms.BasicControls;

namespace UITests.TestCases.User.Forms.BasicControls
{
    [TestFixture]
    class BooleanTestCases : BaseClass
    {
        UserLogin ulog;
        Booleans b;
        public void UserLogin()
        {
            ulog = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
            b = new Booleans(driver);
            browserOps.UrlToBe("https://uitesting.eb-test.cloud/UserDashBoard");
        }

        public void CheckUsrLogin()
        {
            if (login_status == false)
            {
                UserLogin();
                login_status = true;
            }
            browserOps.Goto("https://uitesting.eb-test.cloud/WebForm/Index?refid=ebdbjiwavi72zy20200413071346-ebdbjiwavi72zy20200413071346-0-186-186-186-186");
        }

        [Property("TestCaseId", "Boolean_Behaviour_001")]
        [Test, Order(1)]
        public void Boolean_Behaviour()
        {
            CheckUsrLogin();

            elementOps.ExistsId("RadioButton1");
            Assert.Multiple(() =>
            {
                Assert.True(b.RadioButton1Div.GetAttribute("eb-hidden").ToString() == "true", "Success", "Success");
                Assert.True(b.RadioButton7Div.GetAttribute("eb-readonly").ToString() == "true", "Success", "Success");
            });
        }

        [Property("TestCaseId", "Boolean_ValueTypeBoolean_001")]
        [Test, Order(2)]
        public void Boolean_ValueTypeBoolean()
        {
            CheckUsrLogin();

            elementOps.ExistsId("RadioButton2");
            Assert.Multiple(() =>
            {
                Assert.True(b.RadioButton2.GetAttribute("true-val").ToString() == "true", "Success", "Success");
                Assert.True(b.RadioButton2.GetAttribute("false-val").ToString() == "false", "Success", "Success");
            });
        }

        [Property("TestCaseId", "Boolean_ValueTypeInteger_001")]
        [Test, Order(3)]
        public void Boolean_ValueTypeInteger()
        {
            CheckUsrLogin();

            elementOps.ExistsId("RadioButton3");
            Assert.Multiple(() =>
            {
                Assert.True(b.RadioButton3.GetAttribute("true-val").ToString() == "1", "Success", "Success");
                Assert.True(b.RadioButton3.GetAttribute("false-val").ToString() == "0", "Success", "Success");
            });
        }

        [Property("TestCaseId", "Boolean_ValueTypeString_001")]
        [Test, Order(4)]
        public void Boolean_ValueTypeString()
        {
            CheckUsrLogin();

            elementOps.ExistsId("RadioButton4");
            Assert.Multiple(() =>
            {
                Assert.True(b.RadioButton4.GetAttribute("true-val").ToString() == "True", "Success", "Success");
                Assert.True(b.RadioButton4.GetAttribute("false-val").ToString() == "False", "Success", "Success");
            });
        }

    }
}
