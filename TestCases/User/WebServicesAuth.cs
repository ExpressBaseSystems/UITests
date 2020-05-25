using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UITests.DataDriven;

namespace UITests.TestCases.User
{
    class WebServicesAuth : BaseClass
    {
        [Property("TestCaseId", "TestWebservicesAuth_001")]
        [TestCaseSource("GetFiles")]
        public void TestWebservicesAuth(dynamic authfiles)
        {
            try
            {
                browserOps.Goto("https://ss.eb-test.cloud/metadata");
                string filenames = authfiles.files;
                filenames.Replace("\n", "").Replace("\t", "").Replace("  ", "");
                List<string> result = filenames.Split(',').ToList();
                int cnt = int.Parse(elementOps.GetTableRowCountFromJS().ToString());
                List<string> UnAuthReq = new List<string>();
                for (int i = 1 ; i < cnt ; i++)
                {
                    IWebElement FileName = this.driver.FindElement(By.XPath("/html/body/div/table/tbody/tr[" + i + "]/th"));
                    if (FileName.FindElements(By.TagName("span")).Count == 0)
                    {
                        if(filenames.Contains(FileName.GetAttribute("innerHTML")))
                            UnAuthReq.Add(FileName.GetAttribute("innerHTML"));
                    }
                }
                Console.WriteLine("UnAuth Requests : ");
                foreach(var name in UnAuthReq)
                {
                    Console.WriteLine(name);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        private static List<EbTestItem> GetFiles()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\User\WebServicesAuthTestCase.xml");
        }
    }
}
