using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.ViewModel
{
    public class PeopleViewModel
    {
        public PeopleViewModel()
        {
            PersonList = new List<Person>();
            Cities = new List<City>();
        }
        public List<Person> PersonList { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public int Phone { get; set; }
        public string FilterText { get; set; }
        public List<City> Cities { get; set; }
        public int CityId { get; set; }
    }
}
