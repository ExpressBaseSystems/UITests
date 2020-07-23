using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.ObjectRepository.User
{
    class FormObject
    {
        private IWebDriver driver;

        public FormObject(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement SaveForm
        {
            get
            {
                return this.driver.FindElement(By.Id("webformsave"));
            }
        }
        public IWebElement EditForm
        {
            get
            {
                return this.driver.FindElement(By.Id("webformedit"));
            }
        } 
        
        public IWebElement MessageBoxClose
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='close-msg']"));
            }
        }

        public IWebElement FormMode
        {
            get
            {
                return this.driver.FindElement(By.ClassName("fmode"));
            }
        }
        public IWebElement GoToTop
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='layout_div']/div[1]/div"));
            }
        }

        public IWebElement MenuApplication
        {
            get
            {
                return this.driver.FindElement(By.LinkText("UITest"));
            }
        }
        public IWebElement MenuSelectFormMenu
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ebm-objtcontainer']/div[2]/div[1]"));
            }
        }
        public IWebElement MenuSelectBasicControlsTextBox
        {
            get
            {
                return this.driver.FindElement(By.LinkText("Basic Controls TextBox"));
            }
        }
        public IWebElement MenuSelectBasicControlsNumeric
        {
            get
            {
                return this.driver.FindElement(By.LinkText("Basic Controls Numeric"));
            }
        }
        public IWebElement MenuSelectBasicControlsDateTime
        {
            get
            {
                return this.driver.FindElement(By.LinkText("Basic Controls DateTime"));
            }
        }
        public IWebElement MenuSelectBasicControlsBooleanSelect
        {
            get
            {
                return this.driver.FindElement(By.LinkText("Basic Controls BooleanSelect"));
            }
        }
        public IWebElement MenuSelectBasicControlsCheckBoxGroup
        {
            get
            {
                return this.driver.FindElement(By.LinkText("Basic Controls CheckBoxGroup"));
            }
        }
        public IWebElement MenuSelectBasicControlsRadioButton
        {
            get
            {
                return this.driver.FindElement(By.LinkText("Basic Controls RadioButton"));
            }
        }
        public IWebElement MenuSelectBasicControlsPowerSelect
        {
            get
            {
                return this.driver.FindElement(By.LinkText("Basic Controls PowerSelect"));
            }
        }
        public IWebElement MenuSelectBasicControlsSimpleSelect
        {
            get
            {
                return this.driver.FindElement(By.LinkText("Basic Controls SimpleSelect"));
            }
        }
        public IWebElement MenuSelectPlatformControls
        {
            get
            {
                return this.driver.FindElement(By.LinkText("PlatformControls"));
            }
        }
        public IWebElement MenuSelectAdvanceControlsDataGrid
        {
            get
            {
                return this.driver.FindElement(By.LinkText("Advanced Controls DataGrid"));
            }
        }


        public IWebElement TextBoxShowHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_TextBox13"));
            }

        }
        public IWebElement NumericShowHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_Numeric16"));
            }

        }
        public IWebElement DateShowHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_Date12"));
            }
        }
        public IWebElement BooleanSelectShowHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_BooleanSelect10"));
            }
        } 
        public IWebElement CheckboxesShowHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_CheckBoxGroup3"));
            }
        }
        public IWebElement RadioButtonShowHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_RadioGroup4"));
            }
        }
        public IWebElement LabelShowHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_Label2"));
            }
        }
        public IWebElement BooleanShowHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_RadioButton8"));
            }
        }


        public IWebElement TextBoxDisableEnable
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox14"));
            }
        }
        public IWebElement NumericDisableEnable
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric17"));
            }

        }
        public IWebElement DateDisableEnable
        {
            get
            {
                return this.driver.FindElement(By.Id("Date14"));
            }
        }
        public IWebElement BooleanSelectDisableEnable
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect11_dd']/button"));
            }
        } 
        public IWebElement CheckBoxDisableEnable
        {
            get
            {
                return this.driver.FindElement(By.Id("CheckBoxGroup4lbltxtb"));
            }
        }
        public IWebElement RadioButtonDisableEnable
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioGroup5"));
            }
        }
        public IWebElement BooleanDisableEnable
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton5lbltxtb"));
            }
        }
        


        
        
       
        
        public IWebElement BooleanDVE
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton9"));
            }
        }
        


        
        
        
        public IWebElement CheckBoxGroupOnChangeTrigger
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='CheckBoxGroup8']/div[2]"));
            }
        }
        public IWebElement CheckBoxGroupOnChangeHideShow
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_CheckBoxGroup6"));
            }
        }
        public IWebElement CheckBoxGroupOnChangeEnableDisable
        {
            get
            {
                return this.driver.FindElement(By.Id("CheckBoxGroup7_Rd0"));
            }
        }
        
        public IWebElement BooleanOnChangeTrigger
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton10"));
            }
        }
        public IWebElement BooleanOnChangeHideShow
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_RadioButton11"));
            }
        }
        public IWebElement BooleanOnChangeEnableDisable
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton12lbltxtb"));
            }
        }
       
        


        public IWebElement TextBoxLowerCase
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox3"));
            }

        }
        public IWebElement TextBoxUpperCase
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox4"));
            }
        }        
        public IWebElement TextBoxPassword
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox5"));
            }
        }
        public IWebElement TextBoxEmail
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox6"));
            }
        }
        public IWebElement TextBoxMultiLine
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox13"));
            }
        }        
        public IWebElement TextBoxMaxLength
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox7"));
            }
        }        
        public IWebElement TextboxAutosuggestion
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox8"));
            }
        }
        public IWebElement TextboxAutosuggestionItem
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='ui-id-2']"));
            }
        }
        public IWebElement TextboxHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_TextBox2"));
            }
        }
        public IWebElement TextboxReadOnly
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox10"));
            }
        }
        public IWebElement TextboxRequired
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox11"));
            }
        }
        public IWebElement TextboxUnique
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox9"));
            }
        }
        public IWebElement TextboxDoNotPersist
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox14"));
            }
        }        
        public IWebElement TextBoxDVE
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox12"));
            }
        }
        public IWebElement TextboxVE
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox15"));
            }
        }
        public IWebElement TextboxOnChangeTrigger
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox16"));
            }
        }
        public IWebElement TextBoxOnChangeHideShow
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_TextBox17"));
            }
        }
        public IWebElement TextBoxOnChangeEnableDisable
        {
            get
            {
                return this.driver.FindElement(By.Id("TextBox18"));
            }
        }




        public IWebElement NumericBox
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric1"));
            }
        }
        public IWebElement NumericBoxCurrency
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric2"));
            }
        }
        public IWebElement NumericBoxCurrencyIcon
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='Numeric2Wraper']/div/span/i"));
            }
        }
        public IWebElement NumericBoxPhone
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric3"));
            }
        }
        public IWebElement NumericBoxPhoneIcon
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='Numeric3Wraper']/div/span/i"));
            }
        }       
        public IWebElement NumericBoxHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_Numeric4"));
            }
        }       
        public IWebElement NumericBoxReadOnly
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric5"));
            }
        }
        public IWebElement NumericBoxRequired
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric6"));
            }
        }
        public IWebElement NumericBoxMax
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric7"));
            }
        }
        public IWebElement NumericBoxMin
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric8"));
            }
        }
        public IWebElement NumericBoxUnique
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric9"));
            }
        }
        public IWebElement NumericBoxDecimal
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric10"));
            }
        }
        public IWebElement NumericBoxNegative
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric11"));
            }
        }
        public IWebElement NumericBoxDonotpersist
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric12"));
            }
        }
        public IWebElement NumericDVE
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric16"));
            }
        }
        public IWebElement NumericVE
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric17"));
            }
        }
        public IWebElement NumericOnChangetrigger
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric13"));
            }
        }
        public IWebElement NumericOnChangeHideShow
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_Numeric14"));
            }
        }
        public IWebElement NumericOnChangeEnableDisable
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric15lbltxtb"));
            }
        }
        public IWebElement NumericBoxHelpText
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric13"));
            }
        }
        public IWebElement NumericBoxTooltip
        {
            get
            {
                return this.driver.FindElement(By.Id("Numeric14"));
            }
        }
        


        
        public IWebElement Date
        {
            get
            {
                return this.driver.FindElement(By.Id("Date1"));
            }
        }
        public IWebElement Time
        {
            get
            {
                return this.driver.FindElement(By.Id("Date3"));
            }
        }
        public IWebElement DateTime
        {
            get
            {
                return this.driver.FindElement(By.Id("Date2"));
            }
        }
        public IWebElement DateTimeHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_Date4"));
            }
        }
        public IWebElement DateTimeReadOnly
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_Date5"));
            }
        }
        public IWebElement DateTimenullableSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='Date17Wraper']/div/span[1]/input"));
            }
        }
        public IWebElement DateTimenullable
        {
            get
            {
                return this.driver.FindElement(By.Id("Date17"));
            }
        }
        public IWebElement DateTimeDNP
        {
            get
            {
                return this.driver.FindElement(By.Id("Date13"));
            }
        }
        public IWebElement DateTimeDVE
        {
            get
            {
                return this.driver.FindElement(By.Id("Date15"));
            }
        }
        public IWebElement DateTimeVE
        {
            get
            {
                return this.driver.FindElement(By.Id("Date14"));
            }
        }
        public IWebElement DateTimeYear
        {
            get
            {
                return this.driver.FindElement(By.Id("Date16"));
            }
        }
        public IWebElement DateTimeTigger
        {
            get
            {
                return this.driver.FindElement(By.Id("Date18"));
            }
        }
        public IWebElement DateTimeHideExpression
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_Date19"));
            }
        }
        public IWebElement DateTimeReadOnlyExpression
        {
            get
            {
                return this.driver.FindElement(By.Id("Date20lbltxtb"));
            }
        }
        public IWebElement DateTimeFormClick
        {
            get
            {
                return this.driver.FindElement(By.Id("WebForm-cont"));
            }
        }
        public IWebElement DateTimePlaceholder
        {
            get
            {
                return this.driver.FindElement(By.Id("Date9"));
            }
        }
        public IWebElement DateTimeHelptext
        {
            get
            {
                return this.driver.FindElement(By.Id("Date10"));
            }
        }
        public IWebElement DateTimeToolTip
        {
            get
            {
                return this.driver.FindElement(By.Id("Date11"));
            }
        }



        public IWebElement BoolenSelectHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_BooleanSelect1"));
            }
        }
        public IWebElement BoolenSelectToolTip
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect6Wraper']/div/button"));
            }
        }
        
        public IWebElement BoolenSelectTrueText
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect2_dd']/button"));
            }
        }
        public IWebElement BoolenSelectTrueTextSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect2_dd']/div/div/ul/li[1]/a/span"));
            }
        }
        public IWebElement BoolenSelectTrueTextAfterSave
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect2_dd']/button/div/div/div"));
            }
        }
        public IWebElement BoolenSelectFalseText
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect3_dd']/button"));
            }
        }
        public IWebElement BoolenSelectFalseTextSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect3_dd']/div/div/ul/li[2]/a/span"));
            }
        }
        public IWebElement BoolenSelectFalseTextAfterSave
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect3_dd']/button/div/div/div"));
            }
        }
        public IWebElement BoolenSelectDNP
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect5_dd']/button"));
            }
        }
        public IWebElement BoolenSelectDNPSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect5_dd']/div/div/ul/li[1]/a/span"));
            }
        }
        public IWebElement BoolenSelectDNPAfterSave
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect5_dd']/button/div/div/div"));
            }
        } 
        public IWebElement BoolenSelectTrigger
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect7_dd']/button"));
            }
        }
        public IWebElement BoolenSelectTriggerSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect7_dd']/div/div/ul/li[1]/a/span"));
            }
        }
        public IWebElement BoolenSelectTriggerAfterSave
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect7_dd']/button/div/div/div"));
            }
        }
        public IWebElement BooleanSelectHideExpression
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_BooleanSelect8"));
            }
        }
        public IWebElement BooleanSelectDisableExpression
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect9_dd']/button"));
            }
        }
        public IWebElement BooleanSelectDVE
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect6_dd']/button/div/div/div"));
            }
        }
        public IWebElement BooleanSelectVE
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect6_dd']/button/div/div/div"));
            }
        }
        public IWebElement BooleanSelectReadOnly
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect4_dd']/button"));
            }
        }
        public IWebElement BoolenSelectHelptext
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='BooleanSelect5Wraper']/div/button"));
            }
        }



        public IWebElement CheckBoxGroupHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_CheckBoxGroup1"));
            }
        }
        public IWebElement CheckBoxGroupReadOnly
        {
            get
            {
                return this.driver.FindElement(By.Id("CheckBoxGroup2_Rd0"));
            }
        }
        public IWebElement CheckBoxGroupRequired
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_CheckBoxGroup3"));
            }
        }
        public IWebElement CheckBoxGroupRequiredSelect
        {
            get
            {
                return this.driver.FindElement(By.Id("CheckBoxGroup3_Rd0"));
            }
        }
        public IWebElement CheckBoxGroupDoNotPersist
        {
            get
            {
                return this.driver.FindElement(By.Id("CheckBoxGroup4_Rd0"));
            }
        }
        public IWebElement CheckBoxGroupTrigger
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='CheckBoxGroup7']/div[2]"));
            }
        }
        public IWebElement CheckBoxGroupHideExpression
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_CheckBoxGroup8"));
            }
        }
        public IWebElement CheckBoxGroupDisableExpression
        {
            get
            {
                return this.driver.FindElement(By.Id("CheckBoxGroup9_Rd0"));
            }
        }



        public IWebElement RadioButtonGroupHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_RadioGroup1"));
            }
        }
        public IWebElement RadioButtonGroupReadOnly
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioGroup2_Rd0"));
            }
        }
       
        public IWebElement RadioButtonGroupDoNotPersist
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioGroup3_Rd1"));
            }
        }        
        public IWebElement RadioButtonGroupHorizontalRender
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioGroup5Wraper"));
            }
        }
        public IWebElement RadioButtonGroupIcon
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioGroup5Wraper"));
            }
        }
        public IWebElement RadioButtonOnChangeTrigger
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioGroup10_Rd1"));
            }
        }
        public IWebElement RadioButtonnChangeHideShow
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_RadioGroup11"));
            }
        }
        public IWebElement RadioButoonOnChangeEnableDisable
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioGroup12_Rd0"));
            }
        }



        public IWebElement LabelHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_Label1"));
            }
        } 
        public IWebElement LabelHelpText
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_Label2"));
            }
        } 
        public IWebElement LabelHelpTextData
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='cont_Label2']/span[2]"));
            }
        } 
        public IWebElement LabelToolTip
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_Label3"));
            }
        }
        
        

        public IWebElement BoolenHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_RadioButton2"));
            }
        }
        public IWebElement BoolenString
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton7"));
            }
        }
        public IWebElement BoolenReadOnly
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton3lbltxtb"));
            }
        }
        public IWebElement BoolenInteger
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton6"));
            }
        }
        public IWebElement BoolenDoNotPersist
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton5"));
            }
        }
        public IWebElement BoolenRequired
        {
            get
            {
                return this.driver.FindElement(By.Id("RadioButton4"));
            }
        }
        
        
        public IWebElement PowerSelectSimpleSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='PowerSelect1_dd']/button"));
            }
        }
        public IWebElement PowerSelectSimpleSelectitem
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='PowerSelect1_dd']/div/div/ul/li[3]/a"));
            }
        }
        public IWebElement PowerSelectHidden
        {
            get
            {
                return this.driver.FindElement(By.Id("cont_PowerSelect2"));
            }
        }
        public IWebElement PowerSelectReadOnly
        {
            get
            {
                return this.driver.FindElement(By.Id("PowerSelect3lbltxtb"));
            }
        }
        public IWebElement PowerSelectMultiSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[4]/div[3]/div[2]/form/div[2]/table/tbody/tr/td[1]/div/div[2]/div/div/div/div/div/div/div/input"));
            }
        }
        public IWebElement PowerSelectMultiSelectItem1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='PowerSelect4tbl']/tbody/tr[1]/td[1]/input"));
            }
        }
        public IWebElement PowerSelectMultiSelectItem2
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='PowerSelect4tbl']/tbody/tr[2]/td[1]/input"));
            }
        }
        public IWebElement PowerSelectRequired
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='PowerSelect5textbox_lowercase']/div/input"));
            }
        }
        public IWebElement PowerSelectRequiredItem
        { 
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='PowerSelect5tbl_wrapper']/div[3]/div[2]/table/tbody/tr[1]"));
            }
        }
        public IWebElement PowerSelectDNP
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='PowerSelect7textbox_unique']/div"));
            }
        }
        public IWebElement PowerSelectDNPItem
        { 
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='PowerSelect7tbl']/tbody/tr[1]/td"));
            }
        }
        public IWebElement PowerSelectSearch
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='PowerSelect8textbox_unique']/div/input"));
            }
        }
        public IWebElement PowerSelectSearchItem
        { 
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='PowerSelect8tbl']/tbody/tr[1]/td"));
            }
        }
        public IWebElement PowerSelectNonDataInputControl
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='PowerSelect9textbox_unique']/div"));
            }
        }
        public IWebElement PowerSelectNonDataInputControlItem
        { 
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='PowerSelect9tbl']/tbody/tr[1]/td[1]"));
            }
        } 
        
        
        public IWebElement DataGrid1AddRow
        { 
            get
            {
                return this.driver.FindElement(By.Id("DataGrid1addrow"));
            }
        }
        public IWebElement DataGrid1StringInput
        { 
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[2]/div/input"));
            }
        }
        public IWebElement DataGrid1NumericInput
        { 
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[3]/div/input"));
            }
        }
        public IWebElement DataGrid1BooleanInput
        { 
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[4]/div/div/input"));
            }
        }
        public IWebElement DataGrid1DateInput
        { 
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[5]/div/div/input"));
            }
        }
        public IWebElement DataGrid1DateInputSelect
        { 
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[5]/div[1]/div[2]/table/tbody/tr[2]/td[2]"));
            }
        }
        public IWebElement DataGrid1DropDownInput
        { 
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[6]/div/div/button"));
            }
        }
        public IWebElement DataGrid1DropDownSelect
        { 
            get
            {
                return this.driver.FindElement(By.LinkText("ebsimpleselectoption1"));
            }
        }
        public IWebElement DataGrid1BooleanSelectInput
        { 
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[7]/div/div/button"));
            }
        }
        public IWebElement DataGrid1BooleanSelectSelect
        { 
            get
            {
                return this.driver.FindElement(By.XPath("//*[@class='dropdown bootstrap-select open detch_select']/div/div/ul/li[1]/a/span"));
            }
        }
        public IWebElement DataGrid1PowerSelectInput
        { 
            get
            {
                return this.driver.FindElement(By.Id("textbox_unique"));
            }
        }
        public IWebElement DataGrid1UserControlInput
        { 
            get
            {
                return this.driver.FindElement(By.Id("DataGrid1addrow"));
            }
        }
        public IWebElement DataGrid1CreatedByInput
        { 
            get
            {
                return this.driver.FindElement(By.Id("DataGrid1addrow"));
            }
        }
        public IWebElement DataGrid1CreatedAtInput
        { 
            get
            {
                return this.driver.FindElement(By.Id("DataGrid1addrow"));
            }
        }
        public IWebElement DataGrid1ModifiedByInput
        { 
            get
            {
                return this.driver.FindElement(By.Id("DataGrid1addrow"));
            }
        }
        public IWebElement DataGrid1ModifiedAtInput
        { 
            get
            {
                return this.driver.FindElement(By.Id("DataGrid1addrow"));
            }
        }
        public IWebElement DataGrid1UserSelect
        { 
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[4]/div[3]/div[2]/form/div[2]/div/div/div/div/div/div/div[3]/table/tbody/tr/td[13]/div[1]"));
            }
        } 
        public IWebElement DataGrid1UserSelectUser
        { 
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[4]/div[3]/div[2]/form/div[2]/div/div/div/div/div/div/div[3]/table/tbody/tr/td[13]/div[1]/div/div[2]/div[3]/div[5]"));
            }
        } 
        
        
        public IWebElement AutoId
        { 
            get
            {
                return this.driver.FindElement(By.Id("AutoId1"));
            }
        }
        public IWebElement SysLocationReadOnly
        { 
            get
            {
                return this.driver.FindElement(By.Id("SysLocation1lbltxtb"));
            }
        }
        public IWebElement SysLocationSelectableClick
        { 
            get
            {
                return this.driver.FindElement(By.Id("SysLocation2"));
            }
        }
        public IWebElement SysLocationSelectableItemSelect
        { 
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='SysLocation2']/option[2]"));
            }
        }
        public IWebElement SysCreatedBy
        { 
            get
            {
                return this.driver.FindElement(By.Id("SysCreatedBy1"));
            }
        }
        public IWebElement SysCreatedAt
        { 
            get
            {
                return this.driver.FindElement(By.Id("SysCreatedAt1"));
            }
        }        
        public IWebElement SysModifiedBy
        { 
            get
            {
                return this.driver.FindElement(By.Id("SysModifiedBy1"));
            }
        }
        public IWebElement SysModifiedAt
        { 
            get
            {
                return this.driver.FindElement(By.Id("SysModifiedAt1"));
            }
        }         
        public IWebElement UserSelectClick
        { 
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[13]/div[1]"));
            }
        }
        public IWebElement UserSelectItemClick
        { 
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[13]/div[1]/div/div[2]/div[3]/div[1]/div[2]"));
            }
        }         
        public IWebElement UserLocationGlobal
        { 
            get
            {
                return this.driver.FindElement(By.Id("UserLocation1_checkbox"));
            }
        } 
        public IWebElement UserLocationSelect
        { 
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='UserLocation1Wraper']/span/div/button"));
            }
        }
        public IWebElement UserLocationKochi
        { 
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='UserLocation1Wraper']/span/div/ul/li[3]/a/label/input"));
            }
        }
        
        

        public IWebElement DataGridStringAddRow
        { 
            get
            {
                return this.driver.FindElement(By.Id("DataGrid2addrow"));
            }
        }
        public IWebElement DataGridStringRequired
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[2]/div/input"));
            }
        }
        public IWebElement DataGridStringRO
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[3]/div/input"));
            }
        }
        public IWebElement DataGridStringUnique
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[4]/div/input"));
            }
        }
        public IWebElement DataGridStringDNP
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[5]/div/input"));
            }
        }
        public IWebElement DataGridStringMultiLine
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[6]/div/textarea"));
            }
        }
        public IWebElement DataGridStringPassword
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[7]/div/div/input"));
            }
        }
        public IWebElement DataGridStringEmail
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[8]/div/div/input"));
            }
        }
        public IWebElement DataGridStringSaveRow
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid2']/tbody/tr/td[9]/button[2]"));
            }
        }


        public IWebElement DataGridNumericAddRow
        {
            get
            {
                return this.driver.FindElement(By.Id("DataGrid3addrow"));
            }
        }
        public IWebElement DataGridNumericHidden
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid3']/tbody/tr/td[2]/div/div/input"));
            }
        }         


        public IWebElement DataGridDataGrid4AddRow
        {
            get
            {
                return this.driver.FindElement(By.Id("DataGrid4addrow"));
            }
        }
        public IWebElement DataGridBooleanSelectReadOnly
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid4']/tbody/tr/td[2]/div/div/input"));
            }
        }
        public IWebElement DataGridBooleanSelectDNP
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid4']/tbody/tr/td[3]/div/div/input"));
            }
        }
        public IWebElement DataGridDropDownDNP
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid4']/tbody/tr/td[4]/div/div/button"));
            }
        } 
        public IWebElement DataGridDropDownDNPSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[/html/body/div[4]/div[3]/div[2]/form/div[4]/div/div/ul/li[4]/a/span"));
            }
        }
        public IWebElement DataGridBooleanSelectColumnDNP
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid4']/tbody/tr/td[5]/div/div/button"));
            }
        }        
        public IWebElement DataGridBooleanSelectColumnDNPSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[4]/div[3]/div[2]/form/div[5]/div/div/ul/li[1]/a/span"));
            }
        }

        public IWebElement DataGridPowerSelectAddRow
        {
            get
            {
                return this.driver.FindElement(By.Id("DataGrid5addrow"));
            }
        }
        public IWebElement DataGridPowerSelectSimpleSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid5']/tbody/tr/td[2]/div/div/button"));
            }
        }
        public IWebElement DataGridPowerSelectSimpleSelectItem
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[4]/div[3]/div[2]/form/div[4]/div/div/ul/li[2]/a"));
            }
        }
        public IWebElement DataGridPowerSelectMultiSelect
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='DataGrid5_powerselectcolumn3textbox_unique']/div/input"));
            }
        }
        public IWebElement DataGridPowerSelectSimpleSelectMultiItem1
        {
            get
            {
                return this.driver.FindElement(By.XPath("//html/body/div[4]/div[3]/div[2]/form/div[2]/div/div[3]/div[2]/table/tbody/tr[1]/td[1]/input"));
            }
        }
        public IWebElement DataGridPowerSelectSimpleSelectMultiItem2
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[4]/div[3]/div[2]/form/div[2]/div/div[3]/div[2]/table/tbody/tr[2]/td[1]/input"));
            }
        }
        public IWebElement DataGridPowerSelectSimpleSelectMultiItem3
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[4]/div[3]/div[2]/form/div[4]/div/div[2]/div[2]/table/tbody/tr[5]/td[1]/input"));
            }
        }
        public IWebElement DataGridPowerSelectSimpleSelectMultiItem4
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[4]/div[3]/div[2]/form/div[4]/div/div[2]/div[2]/table/tbody/tr[6]/td[1]/input"));
            }
        }
        public IWebElement DataGridPowerReqMinSearch
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='DataGrid5_powerselectcolumn4textbox_lowercase']/div/input"));
            }
        }
        public IWebElement DataGridPowerReqMinSearchItem
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[4]/div[3]/div[2]/form/div[4]/div/div[3]/div[2]/table/tbody/tr[1]/td[1]"));
            }
        } 
        public IWebElement DataGridPowerGriddnp
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='DataGrid5_powerselectcolumn7textbox_unique']/div/input"));
            }
        }
        public IWebElement DataGridPowerGridDnpItem
        {
            get
            {
                return this.driver.FindElement(By.XPath("/html/body/div[4]/div[3]/div[2]/form/div[4]/div/div[2]/div[2]/table/tbody/tr[1]/td[1]"));
            }
        }


        public IWebElement DataGridDateTimeHidden
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[1]/div[1]/div/input"));
            }
        }
        public IWebElement DataGridDateTimeReadOnly
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[2]/div[1]/div/input"));
            }
        }
        public IWebElement DataGridDateTimeRequired
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[3]/div[1]/div/input"));
            }
        }
        public IWebElement DataGridDateTimeDNP
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[4]/div[1]/div/input"));
            }
        }
        public IWebElement DataGridDateTimeDateTime
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[5]/div[1]/div/input"));
            }
        }
        public IWebElement DataGridDateTimeTime
        {
            get
            {
                return this.driver.FindElement(By.XPath("//*[@id='tbl_DataGrid1']/tbody/tr/td[6]/div[1]/div/input"));
            }
        }
    }
}
