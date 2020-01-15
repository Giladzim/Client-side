using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using teson.Models;
namespace teston.Controllers
{
    public class OrderController : ApiController
    {
        // GET api/<controller>
        public List<Order> Get()
        {
            Order o = new Order();
            return o.Read();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public List<Order> Post([FromBody]Order o)
        {
            Order order = new Order();
             order.insert(o);
            return o.Read();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}