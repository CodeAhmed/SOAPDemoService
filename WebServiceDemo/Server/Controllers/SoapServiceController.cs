using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SOAPDemoService;
using WebServiceDemo.Server.Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceDemo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoapServiceController : ControllerBase
    {
        private readonly ISoapDemoApi _soapDemoApi;
        public SoapServiceController(ISoapDemoApi soapDemoApi)
        {
            _soapDemoApi = soapDemoApi;
        }
        // GET: api/<SoapServiceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SoapServiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SoapServiceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SoapServiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SoapServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Route("GetAddress")]
        public Task<Address> GetAddress(string zip)
        {
            var output = _soapDemoApi.GetCityDetails(zip);
            return output;
        }
    }
}
