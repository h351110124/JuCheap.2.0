using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using JuCheap.Core;
using JuCheap.Service.Abstracts;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace JuCheap.Web.Areas.Adm.Controllers
{
    public class ControlController : AdmBaseController
    {
        public IRoleMenuService roleMenuService { get; set; }

        public IUserRoleService UserRoleService { get; set; }

        // GET: Adm/Control
        public ActionResult Index()
        {
            if (IsLogined)
            {
                //获取拥有的角色
                var Userid = CurrentUser.Id;
                ViewBag.MyMenus = UserService.GetMyMenus(Userid);
            }
            return View();
        }

        /// <summary>
        /// Welcome
        /// </summary>
        /// <returns></returns>
        public ActionResult Welcome()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Indexs(string user,string islogin)
        {
            var result = UserService.Yanzheng(user);
            if (result.flag)
            {
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var claims = new List<Claim>
                {
                    new Claim(ConstValue.LoginUserIdKey, result.data.Id),
                    new Claim(ClaimTypes.Name, user)
                };
                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var pro = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                authenticationManager.SignIn(pro, identity);
                return RedirectToAction("Index", "Control");
            }
            return RedirectToAction("Login", "User");
        }
    }
}