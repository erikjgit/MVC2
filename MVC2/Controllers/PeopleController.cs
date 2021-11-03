using Microsoft.AspNetCore.Mvc;
using MVC2.Models;
using MVC2.Models.Repo;
using MVC2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MVC2.Controllers
{
    public class PeopleController : Controller
    {

        IPeopleService _peopleService;

        public PeopleController( IPeopleService peopleService)
        {
            
            
            _peopleService = peopleService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            PeopleViewModel vm = new PeopleViewModel();
            vm = _peopleService.All();
            return View(vm);
        }
        [HttpPost]
        public IActionResult Filter(PeopleViewModel vm)
        {
            vm = _peopleService.FindBy(vm);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(PeopleViewModel peopleViewModel)
        {
            CreatePersonViewModel createPersonViewModel = new CreatePersonViewModel();
            createPersonViewModel.Name = peopleViewModel.Name;
            createPersonViewModel.City = peopleViewModel.City;
            createPersonViewModel.Phone = peopleViewModel.Phone;
            _peopleService.Add(createPersonViewModel);
            return RedirectToAction("Index", peopleViewModel);
        }


    }
}
