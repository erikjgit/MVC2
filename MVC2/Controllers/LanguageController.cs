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
    public class LanguageController : Controller
    {
        ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            LanguageViewModel vm = _languageService.All();
            return View(vm);
        }
        [HttpPost]
        public IActionResult Create(LanguageViewModel vm)
        {
            //LanguageViewModel result = vm;
            vm.LanguageList.Add( _languageService.Add(vm));
            return RedirectToAction("Index", vm);
        }

    }
}
