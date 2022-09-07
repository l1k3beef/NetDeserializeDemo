using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace NetDeserializeDemo.Controllers
{

    public class SoapFormatterController : ApiController
    {
        // GET api/soapFormatter
        public string Get()
        {
            return "SoapFormatter Deserialize Vulnerability";
        }

        // POST api/soapFormatter/id
        public void Post(int id, [FromBody] string value)
        {
            switch (id)
            {
                case 1:
                    DeserializeData(value);
                    break;
                default:
                    break;
            }
        }

        public object DeserializeData(string data)
        {            
            SoapFormatter soapFormatter = new SoapFormatter();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(data));
            return soapFormatter.Deserialize(memoryStream);
        }



    }
}
