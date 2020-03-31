using System;
using System.Collections.Generic;
using System.Text;

namespace UITests.DataDriven
{
    public class GetUniqueId
    {

        public string GetId
        {
            get
            {
                return Guid.NewGuid().ToString().Substring(0, 8);
            }
        }
    }
}
