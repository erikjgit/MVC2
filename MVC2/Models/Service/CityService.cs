using MVC2.Models.Repo;
using MVC2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Service
{
    public class CityService : ICityService
    {
        ICityRepo cities;
        public CityService(ICityRepo cityRepo)
        {
            cities = cityRepo;
        }
        public City Add(CityViewModel cityViewModel)
        {
            City c = new City();
            c = cities.Create(cityViewModel.Name, cityViewModel.Country);
            return c;
        }

        public CityViewModel All()
        {
            CityViewModel c = new CityViewModel();
            c.Cities = cities.Read();
            return c;

        }

        public City FindBy(int id)
        {
            return (cities.Read(id));
        }

        public bool Remove(int id)
        {
            return (cities.Delete(cities.Read(id)));
        }
        public List<City> FindBy(Country country)
        {
            IEnumerable<City> cityQuery =
                from city in cities.Read()
                where city.Country.Id == country.Id
                select city;
            if(cityQuery == null)
            {
                return (new List<City>());
            }
            return( cityQuery.ToList());
            
        }
    }
}
