using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ServantApply.Common.IManagers;
using ServantApply.Common.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.AspNetCore.Authentication;
using ServantApply.WebApp.Helpers;

namespace ServantApply.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserManager userManager;
        public HomeController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            User user = new User {
                Name = "hu",
                Role = 1
            };
            //userManager.CreateAsync(user);
            var name = HttpContext.User.Identity.FullName();
            var role = HttpContext.User.Identity.Role();
            return View();
        }

        [Authorize(Roles = "System")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            userManager.QueryAsync();
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> Save(User user)
        {
            if (ModelState.IsValid)
            {
                await userManager.CreateAsync(user);
                return RedirectToAction("Index");
            }
            return View("About", user);
        }
      
    }
}
