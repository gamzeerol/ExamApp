using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExamApp.WebUICore.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamApp.WebUICore.Controllers
{
    public class AccountController : Controller
    {
     
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
           if(loginModel.UserNAme=="admin" && loginModel.Password == "123")
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                @ViewBag.hata = "Böyle bir kullanıcı yok";
            }
            return View();
        }
        public IActionResult Logout()
        {
            @ViewBag.hata = "";
            return RedirectToAction("Login", "Account");
        }
     
    }
}