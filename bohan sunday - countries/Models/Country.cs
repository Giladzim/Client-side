using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Country
    {
        private int id;
        private string continent;
        private string name;
        private string lang;


        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Continent { get => continent; set => continent = value; }
        public string Lang { get => lang; set => lang = value; }

        public Country() { }

        public Country(string _name, string _lang, string _continent)
        {
            Name = _name;
            Lang = _lang;
            Continent = _continent;
        }

        public List<Country> Read(string name)
        {

            //insert your code here
            return null;

        }

        public Country getCountryByName(string name)
        {
            DBServices dbs = new DBServices();
            return dbs.getCountryByName(name);
        }

        public void update(Country country)
        {

            DBServices dbs1 = new DBServices();
            dbs1.updateCountries(country);
            
        }

        
            public List<Country> getCountryByCont(string cont)
        {
            DBServices dbs = new DBServices();
            return dbs.getCountryByCont(cont);
        }
    }
}