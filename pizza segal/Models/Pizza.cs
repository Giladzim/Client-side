using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace teson.Models
{
    public class Pizza
    {
        private int id;
        private string name;
        private bool kosher;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public bool Kosher { get => kosher; set => kosher = value; }

        public List<Pizza> Read()
        {
            DBservices dbs = new DBservices();
            return dbs.GetPizza();
            //insert your code here
           // return null;

        }

    }
}

