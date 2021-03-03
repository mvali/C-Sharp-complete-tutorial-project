using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CSharp
{
    //JSON  = JavaScript Object Notation = primary format for transmitting object data over web
    /*   // test json format: https://jsoneditoronline.org/
     { "firstName" : "John",
       "lastName" : "Doe",
       "address" : { "street" : "Main street",
                     "city"   : "NY"
                   },
      "phoneNumbers" : [ { "type" : "home",   "number" : "+123456789" },  // "phoneNumbers" has array attribute 
                         { "type" : "office", "number" : "+234567890" } ]
     }
     */
    public class JsonSample
    {
        void MainTest()
        {
            DeAndSerializeJson("json from your web request");
            Task<bool> a = SerializeObject(1);

            //bool b= a.Result; // avoid: cause deadlock
            a.Wait(); a.RunSynchronously(); // do not work for suspended dispatchers
        }

        private static readonly HttpClient client = new() { BaseAddress = new Uri("https://localhost:5001") };

        private async Task<bool> SerializeObject(int objectId)
        {
            JsonPatchDocument<JsonPersonLevel1> patchDoc = new JsonPatchDocument<JsonPersonLevel1>();
            patchDoc.Replace(e => e.firstName, "Ana");
            patchDoc.Replace(e => e.lastName, "Ionescu");

            // serialize and PATCH
            var serializedItemToUpdate = JsonConvert.SerializeObject(patchDoc);

            var response = await client.PatchAsync("api/alimentasync/" + objectId,
                                new StringContent(serializedItemToUpdate,
                                System.Text.Encoding.Unicode, "application/json"));

            // simple get request
            var strResponse = await client.GetStringAsync("/");
            return true;
        }
        void DeAndSerializeJson(string strJson)
        {
            // create object based on string input data
            var jPerson = JsonConvert.DeserializeObject<dynamic>(strJson);
            var jPerson1 = JsonConvert.DeserializeObject<JsonPerson>(strJson);
            var jPerson2 = JsonConvert.DeserializeObject<JsonPersonLevel3>(strJson);

            Console.WriteLine($"firstname={jPerson.firstName} lastname={jPerson.lastName} address={jPerson.address.street}");
            foreach (var item in jPerson.phoneNumbers)
            {
                Console.WriteLine($"phone type={item.type} number={item.number}");
            }
            // serialize to sent over httprequest
            string strPerson = JsonConvert.SerializeObject(jPerson2);
        }
    }
    public class JsonPerson
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Address address { get; set; }
        public List<PhoneNumber> phoneNumbers { get; set; }

        public class Address
        {
            public string street { get; set; }
            public string city { get; set; }
        }
        public class PhoneNumber
        {
            public string type { get; set; }
            public string number { get; set; }
        }
    }

    public class JsonPersonLevel1
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
    public class JsonPersonLevel2 : JsonPersonLevel1
    {
        public Address address { get; set; }
        public class Address
        {
            public string street { get; set; }
            public string city { get; set; }
        }
    }
    public class JsonPersonLevel3 : JsonPersonLevel2
    {
        public List<PhoneNumber> phoneNumbers { get; set; }
        public class PhoneNumber
        {
            public string type { get; set; }
            public string number { get; set; }
        }
    }
}
