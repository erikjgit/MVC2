using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Repo
{
    public interface ICountryRepo
    {
        Country Create(string name);
        List<Country> Read();
        bool Delete(Country country);
        Country Read(int id);
        //bool AddCity(Country country, City city);

    }
}
