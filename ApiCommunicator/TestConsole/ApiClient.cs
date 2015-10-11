using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiCommunicator.Base;
using Newtonsoft.Json.Linq;

namespace TestConsole
{
    class ApiClient : APIWrapperBase
    {
        public ApiClient() : base("https://data.gov.in/api/datastore/resource.json?resource_id=97878f8a-97c3-4b52-b4bd-a40c530d0fe6") { }

        public ApiClient(String APIUrl)
             : base(APIUrl)
        {

        }

        public void GetOutput()
        {
            var ret = Execute<JToken>("&api-key=a9bcdf84a57cf1215c8303e38c2e0214");
            Console.WriteLine(ret);
            Console.ReadLine();
        }
    }
}
