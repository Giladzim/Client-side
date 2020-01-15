using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Car
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }


        public int insert() {
            DBservices dbs = new DBservices();
            int numAffected = dbs.insert(this);
            return numAffected;
        }

        public List<Car> getByYear(int year) {
            DBservices dbs = new DBservices();
            return dbs.getCarsByYear(year);

        }

    }
}