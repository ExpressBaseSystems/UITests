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
            browserOps.Goto("https://uitesting.eb-test.cloud/");
            ulog.UserName.SendKeys("anoopa.baby@expressbase.com");
            ulog.Password.SendKeys("Qwerty@123");
            ulog.LoginButton.Click();
            Console.WriteLine("Login Success");
        }

        public string Login()
        {
            string url = "https://uitesting.eb-test.cloud/api/authenticate?username=anoopa.baby@expressbase.com&password=Qwerty@123";
            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> httpResponse = httpClient.GetAsync(url);
            HttpResponseMessage hrm = httpResponse.Result;
            HttpContent responseContent = hrm.Content;
            Task<string> responseData = responseContent.ReadAsStringAsync();
            string data = responseData.Result;
            httpClient.Dispose();
            return data;
        }

        [Property("TestCaseId", "API_DataReader_001")]
        [TestCaseSource("ApiWithDataReaderData")]
        public void TestApiWithDataReader(dynamic xmldata)
        {
            try
            {
                string data = Login();
                string bToken, rToken;
                dynamic json = JObject.Parse(data);
                bToken = json.bToken;
                rToken = json.rToken;

                string url = "https://uitesting.eb-test.cloud/api/api_getusrsdetails/1.0.0/json";
                HttpClient httpClient = new HttpClient();

                HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
                httpRequestMessage.RequestUri = new Uri(url);
                httpRequestMessage.Method = HttpMethod.Get;
                httpRequestMessage.Headers.Add("bToken", bToken);
                httpRequestMessage.Headers.Add("rToken", rToken);

                Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);
                HttpResponseMessage hrm = httpResponse.Result;

                HttpStatusCode httpStatusCode = hrm.StatusCode;
                Console.WriteLine("Status Code : " + httpStatusCode);
                Assert.AreEqual(xmldata.statuscode, httpStatusCode.ToString());

                HttpContent responseContent = hrm.Content;
                Task<string> responseData = responseContent.ReadAsStringAsync();
                string datas = responseData.Result;
                dynamic jsondata = JObject.Parse(datas);
                Console.WriteLine("Data : " + JsonConvert.SerializeObject(jsondata.result.tables));
                Assert.AreEqual(xmldata.data, JsonConvert.SerializeObject(jsondata.result.tables));

                httpClient.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "API_DataWriter_001")]
        [TestCaseSource("ApiWithDataWriterData")]
        public void TestApiWithDataWriter(dynamic xmldata)
        {
            try
            {
                string data = Login();
                string bToken, rToken;
                dynamic json = JObject.Parse(data);
                bToken = json.bToken;
                rToken = json.rToken;

                string url = String.Format("https://uitesting.eb-test.cloud/api/apiaddcourses/1.0.0/json?name={0}&desc={1}", xmldata.name, xmldata.desc);
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
                Assert.AreEqual(xmldata.statuscode, httpStatusCode.ToString());

                HttpContent responseContent = hrm.Content;
                Task<string> responseData = responseContent.ReadAsStringAsync();
                string datas = responseData.Result;
                dynamic jsondata = JObject.Parse(datas);
                Console.WriteLine("Data : " + JsonConvert.SerializeObject(jsondata.message.description));
                Assert.AreEqual(xmldata.data, JsonConvert.SerializeObject(jsondata.message.description));
                httpClient.Dispose();
            }
            catch (Exception e)
            {
                Console.WriteLine("Faliure!!\n" + e.Message);
            }
        }

        [Property("TestCaseId", "API_DataProcessor_001")]
        [TestCaseSource("ApiWithProcessorData")]
        public void TestApiWithProcessor(dynamic xmldata)
        {
            try
            {
                string data = Login();
                string bToken, rToken;
                dynamic json = JObject.Parse(data);
                bToken = json.bToken;
                rToken = json.rToken;

                string url = String.Format("https://uitesting.eb-test.cloud/api/apisalarydetails/1.0.0/json?name={0}", xmldata.name);
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
                Assert.AreEqual(xmldata.statuscode, httpStatusCode.ToString());

                HttpContent responseContent = hrm.Content;
                Task<string> responseData = responseContent.ReadAsStringAsync();
                string datas = responseData.Result;
                dynamic jsondata = JObject.Parse(datas);
                Console.WriteLine("Data : " + JsonConvert.SerializeObject(jsondata.result));
                Assert.AreEqual(xmldata.data, JsonConvert.SerializeObject(jsondata.result));
                httpClient.Dispose();
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
    }
}
