using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UITests.DataDriven;
using UITests.ObjectRepository.User;

namespace UITests.TestCases.User
{
    public class APITestCase :BaseClass
    {
        UserLogin ulog;
        public void UserLogin()
        {
            ulog = new UserLogin(driver);
            browserOps.Goto("https://uitesting.eb-test.site/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
        }

        public string Login()
        {
            string url = "https://uitesting.eb-test.site/api/authenticate?username=anoopa.baby@expressbase.com&password=Qwerty@123";
            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(url);
            HttpResponseMessage hrm = httpResponse.Result;
            HttpContent responseContent = hrm.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            httpClient.Dispose();
            return data;
        }

        public string GetResponse(string url, string statuscode)
        {
            string data = Login();
            string bToken, rToken;
            dynamic json = JObject.Parse(data);
            bToken = json.bToken;
            rToken = json.rToken;

            HttpClient httpClient = new HttpClient();

            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.RequestUri = new Uri(url);
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.Headers.Add("bToken", bToken);
            httpRequestMessage.Headers.Add("rToken", rToken);

            Console.WriteLine(httpRequestMessage.ToString());
            Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);
            HttpResponseMessage hrm = httpResponse.Result;
            
            HttpStatusCode httpStatusCode = hrm.StatusCode;
            Assert.AreEqual(statuscode, httpStatusCode.ToString());

            HttpContent responseContent = hrm.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string datas = responseData.Result;
            return datas;
        }


        [Property("TestCaseId", "API_DataReader_001")]
        [TestCaseSource("ApiWithDataReaderData"), Order(1)]
        public void TestApiWithDataReader(dynamic xmldata)
        {
            try
            {
                string url = "https://uitesting.eb-test.site/api/api_getusrsdetails/1.0.0/json";
                string datas = GetResponse(url, xmldata.statuscode);
                dynamic jsondata = JObject.Parse(datas);
                Console.WriteLine("Data : " + JsonConvert.SerializeObject(jsondata.message.description));
                Assert.AreEqual(xmldata.data, JsonConvert.SerializeObject(jsondata.message.description));
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "API_DataWriter_001")]
        [TestCaseSource("ApiWithDataWriterData"), Order(2)]
        public void TestApiWithDataWriter(dynamic xmldata)
        {
            try
            {
                string url = String.Format("https://uitesting.eb-test.site/api/apiaddcourses/1.0.0/json?name={0}&desc={1}", xmldata.name, xmldata.desc);
                string datas = GetResponse(url, xmldata.statuscode); ;
                dynamic jsondata = JObject.Parse(datas);
                Console.WriteLine("Data : " + JsonConvert.SerializeObject(jsondata.message.description));
                Assert.AreEqual(xmldata.data, JsonConvert.SerializeObject(jsondata.message.description));
                //httpClient.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "API_DataProcessor_001")]
        [TestCaseSource("ApiWithProcessorData"), Order(3)]
        public void TestApiWithProcessor(dynamic xmldata)
        {
            try
            {
                string url = String.Format("https://uitesting.eb-test.site/api/apisalarydetails/1.0.0/json?name={0}", xmldata.name);
                string datas = GetResponse(url, xmldata.statuscode); ;
                dynamic jsondata = JObject.Parse(datas);
                Console.WriteLine("Data : " + JsonConvert.SerializeObject(jsondata.result));
                Assert.AreEqual(xmldata.data, JsonConvert.SerializeObject(jsondata.result));
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }
        
        [Property("TestCaseId", "API_DataProcessor_002")]
        [TestCaseSource("ApiForProcessorData"), Order(4)]
        public void TestApiForProcessor(dynamic xmldata)
        {
            try
            {
                string c_name = xmldata.name + id.GetId;
                string url = String.Format("https://uitesting.eb-test.site/api/apiaddnewcourses/1.0.0/json?name={0}&desc={1}", c_name, xmldata.desc);
                string datas = GetResponse(url, xmldata.statuscode);
                dynamic jsondata = JObject.Parse(datas);
                Console.WriteLine("Data : " + JsonConvert.SerializeObject(jsondata.result));
                Assert.AreEqual(xmldata.data, JsonConvert.SerializeObject(jsondata.result));
                //httpClient.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "API_ApiForSQLFunction_001")]
        [TestCaseSource("ApiForSQLFunction"), Order(5)]
        public void TestApiForSQLFunction(dynamic xmldata)
        {
            try
            {
                string url = String.Format("https://uitesting.eb-test.site/api/api_getuserreccount/1.0.0/json");
                string datas = GetResponse(url, xmldata.statuscode);
                dynamic jsondata = JObject.Parse(datas);
                Console.WriteLine("Data : " + JsonConvert.SerializeObject(jsondata.message.status));
                Assert.AreEqual(xmldata.data, JsonConvert.SerializeObject(jsondata.message.status));
                //httpClient.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "API_ApiForApi_001")]
        [TestCaseSource("ApiForApi"), Order(6)]
        public void TestApiForApi(dynamic xmldata)
        {
            try
            {
                string url = String.Format("https://uitesting.eb-test.site/api/apitestapi/1.0.0/json");
                string datas = GetResponse(url, xmldata.statuscode);
                dynamic jsondata = JObject.Parse(datas);
                Console.WriteLine("Data : " + JsonConvert.SerializeObject(jsondata.message.status));
                Assert.AreEqual(xmldata.data, JsonConvert.SerializeObject(jsondata.message.status));
                //httpClient.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "API_ApiForThirdPartyApi_001")]
        [TestCaseSource("ApiForThirdPartyApi"), Order(7)]
        public void TestApiForThirdPartyApi(dynamic xmldata)
        {
            try
            {
                string url = String.Format("https://uitesting.eb-test.site/api/apitestapi/1.0.0/json");
                string datas = GetResponse(url, xmldata.statuscode);
                dynamic jsondata = JObject.Parse(datas);
                Console.WriteLine("Data : " + JsonConvert.SerializeObject(jsondata.message.status));
                Assert.AreEqual(xmldata.data, JsonConvert.SerializeObject(jsondata.message.status));
                //httpClient.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        private static List<EbTestItem> ApiWithDataReaderData()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\User\ApiDataReaderTestCase.xml");
        }

        private static List<EbTestItem> ApiWithDataWriterData()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\User\ApiDataWriterTestCase.xml");
        }

        private static List<EbTestItem> ApiWithProcessorData()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\User\ApiProcessorTestCase.xml");
        }

        private static List<EbTestItem> ApiForProcessorData()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\User\ApiProcessorInsertTestCase.xml");
        }

        private static List<EbTestItem> ApiForSQLFunction()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\User\ApiSQLFuncTestCase.xml");
        }

        private static List<EbTestItem> ApiForApi()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\User\ApiForApiTestCase.xml");
        }

        private static List<EbTestItem> ApiForThirdPartyApi()
        {
            return GetDataFromXML.GetDataFromFile(@"TestCases\User\ApiForThirdPartyApiTestCase.xml");
        }
    }
}
