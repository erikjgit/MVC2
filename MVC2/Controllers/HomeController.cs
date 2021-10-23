using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC2.Models;
using MVC2.Models.Repo;
using MVC2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
