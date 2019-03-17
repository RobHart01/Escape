using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Escape.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Escape.Controllers
{
    public class ArticleController : Controller
    {
        private EscapeContext dbContext;
        public ArticleController(EscapeContext context)
        {
            dbContext = context;
        }
        [HttpGet("escape/article/new")]
        public IActionResult NewArticle()
        {
            return View();
        }
        [HttpGet("escape/article/edit")]
        public IActionResult EditArticle()
        {
            return View();
        }

    }
}