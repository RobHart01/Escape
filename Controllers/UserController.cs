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
    public class UserController : Controller
    {
        private EscapeContext dbContext;
        public UserController(EscapeContext context)
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

        // User Dashboard
        [HttpGet("escape/dashboard")]
        public IActionResult UserDashboard()
        {
            return View();
        }

        // Register
        [HttpGet("escape/register")]
        public IActionResult Register()
        {
            return View();
        }
        
        // Register Action
        [HttpPost("escape/newregister")]
        public IActionResult Register(UserViewModel RegisterData)
        {
            User SubmittedUser = RegisterData.NewUser;
            if (ModelState.IsValid)
            {
                if (dbContext.Users.Any(u => u.UserName == SubmittedUser.UserName))
                {
                    ModelState.AddModelError("UserNameAttempt", "Username already in use");
                    return View("Register");
                }
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                SubmittedUser.Password = Hasher.HashPassword(SubmittedUser, SubmittedUser.Password);
                dbContext.Add(SubmittedUser);
                dbContext.SaveChanges();
                HttpContext.Session.SetInt32("UserId", SubmittedUser.UserId);
                return RedirectToAction("UserDashboard");
            }
            return View("Register");
        }

        // Login
        [HttpGet("escape/login")]
        public IActionResult Login()
        {
            return View();
        }

        // Login Action
        [HttpPost("escape/newlogin")]
        public IActionResult Login(UserViewModel LoginData)
        {
            Login SubmmitedLogin = LoginData.NewLogin;
            if (ModelState.IsValid)
            {
                User UserInDb = dbContext.Users.FirstOrDefault(u => u.UserName == SubmmitedLogin.UserNameAttempt);
                if (UserInDb is null)
                {
                    ModelState.AddModelError("UserNameAttempt", "Invalid Username/Password");
                    return View("Login");
                }
                HttpContext.Session.SetInt32("UserId", UserInDb.UserId);
                PasswordHasher<Login> hasher = new PasswordHasher<Login>();
                var result = hasher.VerifyHashedPassword(SubmmitedLogin, UserInDb.Password, SubmmitedLogin.PasswordAttempt);
                if (result is 0)
                {
                    ModelState.AddModelError("PasswordAttempt", "Invalid Email or Password");
                    return View("Login");
                }
                return RedirectToAction("UserDashboard");
            }
            return View("Login");
        }

        // Logout Action
        [HttpPost("escape/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index", "Home");
        }
    }
}