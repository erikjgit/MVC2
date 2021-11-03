using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Repo
{
    public class InMemoryPeopleRepo //: IPeopleRepo
    {
        public static List<Person> _peopleList = new List<Person>();
        public static int idCounter= 0;

        public Person Create(string name, string city, int phone)
        {
            Person p = new Person();
            p.Name = name;
            //p.City = city;
            p.Phone = phone;
            p.Id = idCounter++;
            _peopleList.Add(p);
            return (p);

        }

        public bool Delete(Person person)
        {
            return(_peopleList.Remove(person));
        }

        public List<Person> Read()
        {
            return (_peopleList);
        }

        public Person Read(int id)
        {
            foreach(Person p in _peopleList)
            {
                if (p.Id == id)
                {
                    return (p);
                }
            }
            return (new Person());
        }

        public Person Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
