using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public class CountriesController : Controller
    {
        ICountryService _countryService;
        ICityService _cityService;
        public CountriesController(ICountryService countryService,ICityService cityService)
        {
            _countryService = countryService;
            _cityService = cityService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            CountryViewModel vm = new CountryViewModel();
            vm = _countryService.All();
            foreach(Country c in vm.Countries)
            {
                c.Cities = _cityService.FindBy(c);
            }
            return View(vm);
        }
       [HttpPost]
       public IActionResult Create(CountryViewModel countryViewModel)
        {
            _countryService.Add(countryViewModel);
            return RedirectToAction("Index", countryViewModel);
        }
    }
}
