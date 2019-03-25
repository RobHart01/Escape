using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Escape.Models;

namespace Escape.Controllers
{
    public class HomeController : Controller
    {
        [Route("escape")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
