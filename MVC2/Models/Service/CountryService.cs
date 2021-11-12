using MVC2.Models.Repo;
using MVC2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Models.Service
{
    public class CountryService : ICountryService
    {
        ICountryRepo countries;
        public CountryService(ICountryRepo countryRepo)
        {
            countries = countryRepo;
        }
        public Country Add(CountryViewModel countryViewModel)
        {
            return (countries.Create(countryViewModel.Name));
        }


        public CountryViewModel All()
        {
            CountryViewModel vm = new CountryViewModel();
            vm.Countries = countries.Read();
            return vm;
        }

        public Country FindBy(int id)
        {
            return (countries.Read(id));
        }
        
        public bool Remove(int id)
        {
            return (countries.Delete(countries.Read(id)));
        }
    }
}
