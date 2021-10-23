using MVC2.Models.Repo;
using MVC2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Service
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo people = new InMemoryPeopleRepo();
        public Person Add(CreatePersonViewModel person)
        {
            return(people.Create(person.Name, person.City, person.Phone));
            //Person p = new Person();
            //person.City = person.City;
            //person.Name = person.Name;
            //person.Phone = person.Phone;
            //people._peopleList.Add(p);
        }

        public PeopleViewModel All()
        {
            PeopleViewModel p = new PeopleViewModel();
            p.PersonList = people.Read();
            return p;
        }

        public Person Edit(int id, Person person)
        {
            throw new NotImplementedException();
        }

        public PeopleViewModel FindBy(PeopleViewModel search)
        {
            throw new NotImplementedException();
        }

        public Person FindBy(int id)
        {
            return (people.Read(id));
        }

        public bool Remove(int id)
        {
            return(people.Delete(people.Read(id)));
        }
    }
}
