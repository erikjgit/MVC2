using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Person> People { get; set; }
        public Country Country { get; set; }
        public City()
        {
            People = new List<Person>();
        }
    }
}
