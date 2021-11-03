using Microsoft.AspNetCore.Mvc;
using MVC2.Models.Service;
using MVC2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Controllers
{
    public class CountriesController : Controller
    {
        ICountryService _countryService;
        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            CountryViewModel vm = new CountryViewModel();
            vm = _countryService.All();
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
