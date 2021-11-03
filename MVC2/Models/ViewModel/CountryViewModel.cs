using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.ViewModel
{
    public class CountryViewModel
    {
        public CountryViewModel()
        {
            Countries = new List<Country>();
        }
        public List<Country> Countries { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}
