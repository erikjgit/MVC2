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
        public CitiesController(ICityService cityService, ICountryService countryService)
        {
            _cityService = cityService;
            _countryService = countryService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            CityViewModel vm = new CityViewModel();
            vm = _cityService.All();
            vm.Countries = _countryService.All().Countries;
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(CityViewModel cityViewModel)
        {
            CityViewModel newVm = cityViewModel;
            City c;
            newVm.Country = _countryService.FindBy(cityViewModel.CountryId);
            c = _cityService.Add(newVm);
            _countryService.AddCity(newVm.Country, c);
            return RedirectToAction("Index", cityViewModel);
        }
    }
}
