using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using ServantApply.Common.IManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServantApply.WebApp.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserManager userManager;
        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<IActionResult> Login(string name)
        {
            var identity = new ClaimsIdentity(
                            new List<Claim>
                            {
                                new Claim(ClaimTypes.Name,name, ClaimValueTypes.String)
                            },
                            ClaimTypes.Authentication,
                            ClaimTypes.Name,
                            ClaimTypes.Role);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties { IsPersistent = true };

            await HttpContext.Authentication.SignInAsync("test", principal, properties);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Unauthorized(string returnUrl = null)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "halower", ClaimValueTypes.String, "https://www.cnblogs.com/rohelm"));
            var userIdentity = new ClaimsIdentity("管理员");
            userIdentity.AddClaims(claims);
            var userPrincipal = new ClaimsPrincipal(userIdentity);
            await HttpContext.Authentication.SignInAsync("MyCookieMiddlewareInstance", userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });

            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Forbidden()
        {
            return View();
        }
    }
}
