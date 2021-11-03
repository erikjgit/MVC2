using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Repo
{
    public interface IPeopleRepo
    {
        Person Create(string name, City city, int phone);
        List<Person> Read();
        Person Read(int id);
        Person Update(Person person);
        bool Delete(Person person);
        static int idCounter;
        public static List<Person> _peopleList;
    }
}
