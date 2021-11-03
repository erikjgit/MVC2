using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.ViewModel
{
    public class CityViewModel
    {
        public CityViewModel()
        {
            Cities = new List<City>();
        }
        public List<City> Cities { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string Name { get; set; }
        public List<Person> People { get; set; }
        public List<Country> Countries { get; set; }
    }
}
