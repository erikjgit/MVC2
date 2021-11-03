using MVC2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Repo
{
    public class DatabaseCityRepo : ICityRepo
    {
        private readonly PeopleDbContext _dbContext;
        public DatabaseCityRepo(PeopleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public City Create(string name, Country country)
        {
            City c = new City();
            c.Name = name;
            c.Country = country;
            _dbContext.Cities.Add(c);
            _dbContext.SaveChanges();
            return c;
        }

        public bool Delete(City city)
        {
            City c = _dbContext.Cities.Find(city.Id);
            if (c == null)
            {
                return false;
            }
            _dbContext.Cities.Remove(city);
            _dbContext.SaveChanges();
            return true;
        }

        public List<City> Read()
        {
            return (_dbContext.Cities.ToList());
        }

        public City Read(int id)
        {
            City c = _dbContext.Cities.Find(id);
            if (c == null)
            {
                return (new City());
            }
            return c;
        }
    }
}
