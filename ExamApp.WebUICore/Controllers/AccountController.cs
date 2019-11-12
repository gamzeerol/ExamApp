using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExamApp.BLL.Abstract;
using ExamApp.WebUICore.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ExamApp.WebUICore.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

      
        
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            var user = _userService.GetAll().Where(u => u.UserName == loginModel.UserName && u.Password == loginModel.Password).SingleOrDefault();
            if (user!=null)
            {
                HttpContext.Session.SetString("username", loginModel.UserName);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "Invalid Account";
                return View(loginModel);
            }
           
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }

    }
}