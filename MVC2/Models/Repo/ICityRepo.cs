using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Repo
{
    public interface ICityRepo
    {
        City Create(string name, Country country);
        List<City> Read();
        bool Delete(City city);
        City Read(int id);
        bool AddPerson(Person person);
    }
}
