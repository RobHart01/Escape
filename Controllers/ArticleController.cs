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

        private User LoggedInUser
        {
            get
            {
                return dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
            }
        }
        
        // New Article
        [HttpGet("escape/article/new")]
        public IActionResult NewArticle()
        {
            return View();
        }

        // New Article Action
        [HttpPost("escape/article/createarticle")]
        public IActionResult CreateArticle(ArticleViewModel NewArticleData)
        {
            Article SubmittedArticle = NewArticleData.NewArticle;
            if (ModelState.IsValid)
            {
                dbContext.Add(SubmittedArticle);
                dbContext.SaveChanges();
                return RedirectToAction("UserDashboard");
            }
            return View("NewArticle");
        }

        // Edit Article
        [HttpGet("escape/article/edit")]
        public IActionResult EditArticle()
        {
            return View();
        }
    }
}