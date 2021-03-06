﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class pokemonController : ApiController
    {
        // GET api/<controller>
        public List<Pokemon> Get()
        {
            Pokemon o = new Pokemon();
            return o.Read();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public int Post([FromBody] Pokemon[] p)
        {
            int numEffected = 0;
            foreach (Pokemon poke in p)
            {
                
                numEffected+= poke.insert();
            }
            return numEffected;
        }

        // PUT api/<controller>/5
        public void Put([FromBody]Pokemon po)
        {
            po.update(po);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}