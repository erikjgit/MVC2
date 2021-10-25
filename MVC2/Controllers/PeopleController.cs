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

        //IPeopleRepo _peopleRepo;
        IPeopleRepo _inMemoryPeopleRepo;
        IPeopleService _peopleService;
        //private readonly ILogger<HomeController> _logger;

        public PeopleController(/*ILogger<HomeController> logger,*/ IPeopleService peopleService, /*IPeopleRepo peopleRepo,*/ IPeopleRepo inMemoryPeopleRepo)
        {
            //_peopleRepo = peopleRepo;
            _inMemoryPeopleRepo = inMemoryPeopleRepo;
            _peopleService = peopleService;
            //_logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            PeopleViewModel vm = new PeopleViewModel();
            vm = _peopleService.All();
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

        //[HttpPost] 
        //IActionResult Index(string )

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
