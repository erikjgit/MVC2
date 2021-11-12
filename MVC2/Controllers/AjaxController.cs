using Microsoft.AspNetCore.Mvc;
using MVC2.Models.Repo;
using MVC2.Models.Service;
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
        public AjaxController (IPeopleRepo inMemoryPeopleRepo, IPeopleService peopleService)
        {
            _inMemoryPeopleRepo = inMemoryPeopleRepo;
            _peopleService = peopleService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult People()
        {

            return PartialView("_PeopleListPartialView", _peopleService.All().PersonList);
        }
        [HttpPost]
        public IActionResult Detail(int id)
        {
            return PartialView("_PersonPartial", _peopleService.FindBy(id));
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
