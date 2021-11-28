using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC2.Models;
using MVC2.Models.Repo;
using MVC2.Models.Service;
using MVC2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MVC2.Controllers
{
    [Authorize]
    public class PeopleController : Controller
    {

        IPeopleService _peopleService;
        ICityService _cityService;
        IPersonLanguageService _personLanguageService;
        ILanguageService _languageService;
        public PeopleController( IPeopleService peopleService, ICityService cityService, IPersonLanguageService personLanguageService, ILanguageService languageService)
        {
            _languageService = languageService;
            _personLanguageService = personLanguageService;
            _peopleService = peopleService;
            _cityService = cityService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            PeopleViewModel vm = new PeopleViewModel();
            vm = _peopleService.All();
            foreach(Person p in vm.PersonList)
            {
                p.PersonLanguages = _personLanguageService.FindBy(p);
                foreach(PersonLanguage pl in p.PersonLanguages)
                {
                    pl.Language = _languageService.FindBy(pl.LanguageId);
                }
            }
            vm.Cities = _cityService.All().Cities;
            return View(vm);
        }
        [HttpPost]
        public IActionResult Index(PeopleViewModel vm)
        {
            vm = _peopleService.FindBy(vm);
            foreach (Person p in vm.PersonList)
            {
                p.PersonLanguages = _personLanguageService.FindBy(p);
                foreach (PersonLanguage pl in p.PersonLanguages)
                {
                    pl.Language = _languageService.FindBy(pl.LanguageId);
                }
            }
            vm.Cities = _cityService.All().Cities;
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(PeopleViewModel peopleViewModel)
        {
            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();
            createPersonViewModel.Name = peopleViewModel.Name;
            createPersonViewModel.City = _cityService.FindBy(peopleViewModel.CityId);
            createPersonViewModel.Phone = peopleViewModel.Phone;
            _peopleService.Add(createPersonViewModel);
            return RedirectToAction("Index", peopleViewModel);
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            EditPersonViewModel vm = new EditPersonViewModel();
            vm.Person = _peopleService.FindBy(id);
            vm.PersonId = id;
            vm.Person.PersonLanguages = _personLanguageService.FindBy(vm.Person);
            List<Language> ns = _languageService.All().LanguageList;
            vm.NotSpokenLaguages = ns;
            //vm.Cities = _cityService.All().Cities;
            //vm.Cities.Remove(vm.Person.City);
            foreach (PersonLanguage pl in vm.Person.PersonLanguages)
            {
                pl.Language = _languageService.FindBy(pl.LanguageId);
                vm.NotSpokenLaguages.Remove(pl.Language);
            }
            return View(vm);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddLanguage(EditPersonViewModel vm)
        {            
            vm.Person = _peopleService.FindBy(vm.PersonId);
            if (vm.AddId == 0)
            {
                return RedirectToAction("Edit", new { id = vm.Person.Id });
            }
            vm.Person.PersonLanguages = _personLanguageService.FindBy(vm.Person);
            vm.Person.PersonLanguages.Add(_personLanguageService.Add(vm.Person, _languageService.FindBy(vm.AddId)));
            return RedirectToAction("Edit", new { id = vm.Person.Id });
        }
        [Authorize(Roles = "Admin")]
        [HttpPost] public IActionResult RemoveLanguage(EditPersonViewModel vm)
        {
            vm.Person = _peopleService.FindBy(vm.PersonId);
            if (vm.RemoveId == 0)
            {
                return RedirectToAction("Edit", new { id = vm.Person.Id });
            }
            vm.Person.PersonLanguages = _personLanguageService.FindBy(vm.Person);
            _personLanguageService.Remove(_peopleService.FindBy(vm.Person.Id), _languageService.FindBy(vm.RemoveId));
            return RedirectToAction("Edit", new { id = vm.Person.Id });
        }
        //[HttpPost]
        //public IActionResult ChangeCity(EditPersonViewModel vm)
        //{
        //    vm.Person = _peopleService.FindBy(vm.PersonId);
        //    vm.Person.City = _cityService.FindBy(vm.CityId); ;
        //    return RedirectToAction("Edit", new { id = vm.Person.Id });
        //}

    }
}
