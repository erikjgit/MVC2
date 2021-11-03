using MVC2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Repo
{
    public class DatabaseCountryRepo : ICountryRepo
    {
        private readonly PeopleDbContext _dbContext;
        public DatabaseCountryRepo(PeopleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddCity(Country country, City city)
        {
            if (_dbContext.Countries.Find(country.Id).Cities.Contains(city))
            {
                return false;
            }
            _dbContext.Countries.Find(country.Id).Cities.Add(city);
            _dbContext.SaveChanges();
            return true;
        }

        public Country Create(string name)
        {
            Country c = new Country();
            c.Name = name;
            _dbContext.Countries.Add(c);
            _dbContext.SaveChanges();
            return c;
        }

        public bool Delete(Country country)
        {
            Country c = _dbContext.Countries.Find(country.Id);
            if (c == null)
            {
                return false;
            }
            _dbContext.Countries.Remove(country);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Country> Read()
        {
            return (_dbContext.Countries.ToList());
        }

        public Country Read(int id)
        {
            Country c = _dbContext.Countries.Find(id);
            if (c == null)
            {
                return (new Country());
            }
            return c;
        }
    }
}
