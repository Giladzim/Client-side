using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DB.Controllers
{
    public class MoviesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/movie?actor=bruce
        public List<Movie> Get(string actor)
        {
            // classEX enter code here
            return null;
        }

        // POST api/<controller>
        public void Post([FromBody]Movie movie)
        {
            movie.insert();
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