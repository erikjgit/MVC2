using MVC2.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Repo
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        private readonly PeopleDbContext _dbContext;
        public DatabasePeopleRepo(PeopleDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Person Create(string name, City city, int phone)
        {
            
            Person p = new Person();
            p.Name = name;
            p.City = city;
            p.Phone = phone;
            _dbContext.People.Add(p);

            int result = _dbContext.SaveChanges();
            if (result == 0)
            {
                throw new Exception("Could not add to database.");
            }
            return (p);
        }

        public bool Delete(Person person)
        {
            Person p = _dbContext.People.Find(person.Id);
            if (p == null)
            {
                return false;
            }
            _dbContext.People.Remove(person);
            _dbContext.SaveChanges();
            return true;
        }

        public List<Person> Read()
        {

            return( _dbContext.People.ToList());

        }

        public Person Read(int id)
        {
            Person p = _dbContext.People.Find(id);
            if (p == null)
            {
                return (new Person());
            }
            return p;
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
