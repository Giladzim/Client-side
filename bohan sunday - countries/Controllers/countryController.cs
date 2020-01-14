using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class countryController : ApiController
    {
        // GET api/<controller>
        //public List<Country> Get()
        //{
            
        //}

        [HttpGet]
        [Route("api/countries/{name}")]
        public Country Get(string name)
        {
            Country country = new Country();
            return country.getCountryByName(name);
        }

        [HttpGet]
        [Route("api/country/cont/{cont}")]
        public List<Country> getbyCont(string cont)
        {
            Country country = new Country();
            return country.getCountryByCont(cont);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }


        public void Put([FromBody]Country country)
        {
            country.update(country);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}