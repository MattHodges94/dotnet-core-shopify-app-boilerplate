using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace shopify_app.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            var response = Program.GetCustomers();
            return response;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(long id)
        {
            var response = Program.GetCustomer(id);
            return response;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")] 
        public void Put(long id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
