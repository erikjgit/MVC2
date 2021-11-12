using Microsoft.AspNetCore.Mvc;
using MVC2.Models;
using MVC2.Models.Service;
using MVC2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Controllers
{
    public class CitiesController : Controller
    {
        ICityService _cityService;
        ICountryService _countryService;
        IPeopleService _peopleService;
        public CitiesController(ICityService cityService, ICountryService countryService, IPeopleService peopleService)
        {
            _cityService = cityService;
            _countryService = countryService;
            _peopleService = peopleService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            CityViewModel vm = new CityViewModel();
            vm = _cityService.All();
            vm.Countries = _countryService.All().Countries;
            foreach(City c in vm.Cities)
            {
                c.People = _peopleService.FindBy(c);
            }
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(CityViewModel cityViewModel)
        {
            CityViewModel newVm = cityViewModel;
            City c;
            newVm.Country = _countryService.FindBy(cityViewModel.CountryId);
            c = _cityService.Add(newVm);
            return RedirectToAction("Index", cityViewModel);
        }
    }
}
