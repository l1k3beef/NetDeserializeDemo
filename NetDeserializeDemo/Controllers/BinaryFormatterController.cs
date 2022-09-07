using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace NetDeserializeDemo.Controllers
{

    public class BinaryFormatterController : ApiController
    {
        [Serializable]
        public class TestClass
        {

        }

        // GET api/binaryFormatter/id
        public string Get(int id)
        {
            return "BinaryFormatter Deserialize Vulnerability";
        }

        // POST api/binaryFormatter/id
        public void Post(int id, [FromBody] string value)
        {
            switch (id)
            {
                case 1:
                    DeserializeData(value);
                    break;
                case 2:
                    UnsafeDeserialize(value);
                    break;
                case 3:
                    DeserializeMethodResponse(value);
                    break;
                case 4:
                    UnsafeDerializeMethodResponse(value);
                    break;
                default:
                    break;
            }
        }

        public object DeserializeData(string data)
        {        
            MemoryStream memoryStream = new MemoryStream(System.Convert.FromBase64String(data));
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return binaryFormatter.Deserialize(memoryStream);
        }

        public object UnsafeDeserialize(string data)
        {
            MemoryStream memoryStream = new MemoryStream(System.Convert.FromBase64String(data));
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return binaryFormatter.UnsafeDeserialize(memoryStream, null);
        }

        public object DeserializeMethodResponse(string data)
        {
            MemoryStream memoryStream = new MemoryStream(System.Convert.FromBase64String(data));
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return binaryFormatter.DeserializeMethodResponse(memoryStream, null, null);
        }

        public object UnsafeDerializeMethodResponse(string data)
        {
            MemoryStream memoryStream = new MemoryStream(System.Convert.FromBase64String(data));
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            return binaryFormatter.UnsafeDeserializeMethodResponse(memoryStream, null, null);
        }


    }
}
