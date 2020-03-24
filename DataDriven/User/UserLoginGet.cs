using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Xml.Linq;

namespace UITests.DataDriven
{

    public enum EbUserDataTypes
    {
        String,
        Int,
        Decimal,
        Date,
        Datetime,
        Time
    }

    public class EbUserLoginData
    {
        public string Name { get; set; }
        public EbUserDataTypes Type { get; set; }
        public dynamic Value { get; set; }
    }

    public class EbUserLoginItem : DynamicObject
    {
        public string Name { get; set; }

        public List<EbUserLoginData> UserDatas { get; set; }

        public EbUserLoginItem()
        {
            UserDatas = new List<EbUserLoginData>();
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            EbUserLoginData item = UserDatas.Find(e => e.Name == binder.Name);
            if (item == null)
            {
                result = null;
                //throw new Exception("Member Not Found : " + binder.Name);
            }
            else
            {
                result = item.Value;
            }
            return true;
        }
    }


    public class GetUserLoginDataFromXml
    {
        public static List<EbUserLoginItem> GetUserValues()
        {
            var doc = XDocument.Load(@"E:\Expressbase.core\UITests\TestData\User\UserLogin.xml");
            List<EbUserLoginItem> TestCases = new List<EbUserLoginItem>();
            foreach (var testcase in doc.Descendants("test"))
            {
                string testname = testcase.Attribute("name").Value;
                EbUserLoginItem testdata = new EbUserLoginItem() { Name = testname };
                foreach (var child in testcase.Elements())
                {
                    EbUserLoginData td = new EbUserLoginData();
                    td.Name = child.Name.ToString();
                    td.Type = (EbUserDataTypes)Enum.Parse(typeof(EbUserDataTypes), child.Attribute("type").Value);
                    td.Value = child.Value;
                    testdata.UserDatas.Add(td);
                }
                TestCases.Add(testdata);
            }
            return TestCases;
        }
    }
}
