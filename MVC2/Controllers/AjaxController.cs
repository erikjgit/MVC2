using Microsoft.AspNetCore.Mvc;
using MVC2.Models;
using MVC2.Models.Repo;
using MVC2.Models.Service;
using MVC2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Controllers
{
    public class AjaxController : Controller
    {
        IPeopleRepo _inMemoryPeopleRepo;
        IPeopleService _peopleService;
        ICityService _cityService;
        IPersonLanguageService _personLanguageService;
        ILanguageService _languageService;
        public AjaxController (IPeopleRepo inMemoryPeopleRepo, IPeopleService peopleService, ICityService cityService, IPersonLanguageService personLanguageService, ILanguageService languageService)
        {
            _inMemoryPeopleRepo = inMemoryPeopleRepo;
            _peopleService = peopleService;
            _cityService = cityService;
            _personLanguageService = personLanguageService;
            _languageService = languageService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult People()
        {
            PeopleViewModel vm = new PeopleViewModel();
            vm = _peopleService.All();
            foreach (Person p in vm.PersonList)
            {
                p.PersonLanguages = _personLanguageService.FindBy(p);
                foreach (PersonLanguage pl in p.PersonLanguages)
                {
                    pl.Language = _languageService.FindBy(pl.LanguageId);
                }
            }
            vm.Cities = _cityService.All().Cities;

            return PartialView("_PeopleListPartialView", vm.PersonList);
        }
        [HttpPost]
        public IActionResult Detail(int id)
        {
            PeopleViewModel vm = new PeopleViewModel();
            Person person = new Person();
            vm = _peopleService.All();
            vm.Cities = _cityService.All().Cities;            
            foreach (Person p in vm.PersonList)
            {
                if(p.Id == id)
                {
                    person = p;
                }
            }
            person.PersonLanguages = _personLanguageService.FindBy(person);
            foreach (PersonLanguage pl in person.PersonLanguages)
            {
                pl.Language = _languageService.FindBy(pl.LanguageId);
            }
            return PartialView("_PersonPartial", person);
        }
        public IActionResult Delete(int id)
        {
            if (_peopleService.Remove(id))
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
