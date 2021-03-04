using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    // REST = Representational State Transfer
    /* 
    Principle 1: Everything is a Resource
    Principle 2: Every Resource is Identified by a Unique Identifier  (URI)
    Principle 3: Use Simple and Uniform Interfaces
                    GET	Get a resource
                    PUT	Create and Update a resource
                    DELETE	Deletes a resource
                    POST	Submits data the resource
    Principle 4: Communication is Done by Representation
                 Allow multiple representations for same Resource
                    {Customer :{ Name:'Questpond.com', Address:'Mulund Mumbai'}} - in Json, but response can be sent in many format 
    Principle 5: Be Stateless
                     Every request is independent and the server does not need to remember your previous request and states.
    */
    [Route("api/[controller]")]
    [ApiController]
    class RestPrinciple : ControllerBase  // you can not do that here.. this is a console application :)
    {
        // use factory on API server for safe connection reusing
        private readonly IHttpClientFactory _httpClientFactory;
        public RestPrinciple(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        // /api/info
        [HttpGet, ActionName("info")]    // ActionName attribute used as route
        public async Task<HttpResponseMessage> GetInfo()
        {
            var _httpClient = _httpClientFactory.CreateClient(); var API_KEY = "hahsahse"; var cityName="NY";

            string APIURL = $"?key={API_KEY}&q={cityName}";
            var response = await _httpClient.GetAsync(APIURL);
            return response;

            // use next for getting content as string
            // await response.Content.ReadAsStringAsync();
        }

        //  /api/info
        [HttpPost, ActionName("info")]
        public async Task<HttpResponseMessage> PostInfo(Result result)
        {
            // we must save data here.. but hey.. just have some info to sent response
            HttpResponseMessage imCreated = new HttpResponseMessage(System.Net.HttpStatusCode.Created);
            return imCreated;
        }

        public class Result { public int Id { get; set; } public string Name { get; set; }}
    }
}
