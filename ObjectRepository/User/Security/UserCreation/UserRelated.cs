using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User.Security.UserCreation
{
    public class UserRelated
    {
        private IWebDriver driver;

        public UserRelated(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement CreateUserButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnNewCmnList"));
            }
        }

        public IWebElement MaxUserLimitMsg
        {
            get
            {
                return this.driver.FindElement(By.ClassName("eb_messageBox_container"));
            }
        }

        public IWebElement FullName
        {
            get
            {
                return this.driver.FindElement(By.Id("txtFullName"));
            }
        }

        public IWebElement NickName
        {
            get
            {
                return this.driver.FindElement(By.Id("txtNickName"));
            }
        }

        public IWebElement EmailId
        {
            get
            {
                return this.driver.FindElement(By.ClassName("txtEmail"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.driver.FindElement(By.Id("pwdPassword"));
            }
        }

        public IWebElement ConfirmPassword
        {
            get
            {
                return this.driver.FindElement(By.Id("pwdPasswordCon"));
            }
        }

        public IWebElement SaveButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnCreateUser"));
            }
        }

        public IWebElement SaveOkButton
        {
            get
            {
                return this.driver.FindElement(By.Name("Ok"));
            }
        }

        // Group

        public IWebElement AddGroupTab
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"layout_div\"]/div[2]/div/div/div/div[2]/div/ul/li[4]/a"));
            }
        }

        public IWebElement AddGroupButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnAddModalAdd_User_Group"));
            }
        }

        public IWebElement TestUserGroup
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"divSearchResultsAdd_User_Group\"]/div/div[1]/input"));
            }
        }

        public IWebElement ChooseGroupOkButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnModalOkAdd_User_Group"));
            }
        }

        // Role

        public IWebElement AddRoleTab
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"layout_div\"]/div[2]/div/div/div/div[2]/div/ul/li[2]/a"));
            }
        }

        public IWebElement AddRoleButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnAddModalAdd_Roles"));
            }
        }

        public IWebElement SolutionOwner
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"divSearchResultsAdd_Roles\"]/div[1]/div[1]/input"));
            }
        }

        public IWebElement SolutionAdmin
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"divSearchResultsAdd_Roles\"]/div[2]/div[1]/input"));
            }
        }

        public IWebElement RolesOkButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnModalOkAdd_Roles"));
            }
        }

        //--------------------------- User Edit -----------------------------

        public IWebElement VieworEditIcon
        {
            get
            {
                return this.driver.FindElement(By.ClassName("editviewclass"));
            }
        }

        public IWebElement ResetPasswordButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnResetPassword"));
            }
        }

        public IWebElement NewPassword
        {
            get
            {
                return this.driver.FindElement(By.Id("pwdResetNew"));
            }
        }

        public IWebElement ConfirmNewPassword
        {
            get
            {
                return this.driver.FindElement(By.Id("pwdResetNewConfirm"));
            }
        }

        public IWebElement ResetButton
        {
            get
            {
                return this.driver.FindElement(By.Id("btnResetPwd"));
            }
        }

        //EditRole

        public IWebElement EditRoleToggle
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id=\"divSelectedDisplayAdd_Roles\"]/div[1]/div/div[3]/div/i"));
            }
        }

        public IWebElement ViewRole
        {
            get
            {
                return this.driver.FindElement(By.ClassName("dropDownViewClass"));
            }
        }

        public IWebElement RemoveRole
        {
            get
            {
                return this.driver.FindElement(By.ClassName("dropDownRemoveClass"));
            }
        }
    }
}
