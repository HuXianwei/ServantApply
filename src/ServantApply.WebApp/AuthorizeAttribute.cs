using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServantApply.Common.IManagers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServantApply.WebApp
{
    public class AuthorizeAttributeTest : ActionFilterAttribute
    {
        //private IUserManager userManager;

        //public AuthorizeAttribute(IUserManager userManager)
        //{
        //    this.userManager = userManager;
        //}

        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    var cookie = "";
        //    var cookies = context.HttpContext.Request.Cookies;
        //    if (cookies.Count > 0)
        //    {
        //        cookie = cookies.FirstOrDefault(x => x.Key == ".CNBlogsCookie").Value;
        //    }
        //    if (!string.IsNullOrEmpty(cookie) && !context.HttpContext.User.Identity.IsAuthenticated)
        //    {
        //        var userName = userManager.GetUserNameByCookie(cookie).Result;//根据 Cookie 获取解密后的 UserName
        //        if (!string.IsNullOrEmpty(userName))
        //        {
        //            var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userName) },
        //                              CookieAuthenticationDefaults.AuthenticationScheme));
        //            context.HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
        //                            user,
        //                            new AuthenticationProperties() { IsPersistent = true });//进行新的用户身份登录
        //            if (_userService.IsUserInRole(userName).Result)
        //            {
        //                base.OnActionExecuting(context);
        //                return;
        //            }
        //        }
        //    }
        //    else if (context.HttpContext.User.Identity.IsAuthenticated)
        //    {
        //        if (_userService.IsUserInRole(context.HttpContext.User.Identity.Name).Result)
        //        {
        //            base.OnActionExecuting(context);
        //            return;
        //        }
        //    }
        //    else if (string.IsNullOrEmpty(cookie))
        //    {
        //        context.Result = new RedirectResult("http://passport.cnblogs.com/user/signin?ReturnUrl=");
        //        return;
        //    }
        //    context.Result = new RedirectResult("http://www.cnblogs.com/");
        //    return;
        //}

        //public override void OnActionExecuted(ActionExecutedContext context)
        //{
        //    base.OnActionExecuted(context);
        //}

        //public override void OnResultExecuting(ResultExecutingContext context)
        //{
        //    base.OnResultExecuting(context);
        //}

        //public override void OnResultExecuted(ResultExecutedContext context)
        //{
        //    base.OnResultExecuted(context);
        //}
    }
}
