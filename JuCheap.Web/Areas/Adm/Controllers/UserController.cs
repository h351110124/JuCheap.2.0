using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using JuCheap.Core;
using JuCheap.Core.Extentions;
using JuCheap.Service.Abstracts;
using JuCheap.Service.Dto;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace JuCheap.Web.Areas.Adm.Controllers
{
    /// <summary>
    /// user
    /// </summary>
    public class UserController : AdmBaseController
    {
        public IUserRoleService userRoleService { get; set; }

        

        #region Page

        // GET: Adm/User
        public ActionResult Index(string moudleId, string menuId, string btnId)
        {
            GetButtons(menuId);
            return View();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult Add(string moudleId, string menuId, string btnId)
        {
            return View();
        }

        public ActionResult Edit(string moudleId, string menuId, string btnId, string id)
        {
            var model = UserService.GetOne(item => item.Id == id);
            return View(model);
        }

        /// <summary>
        /// 用户角色授权
        /// </summary>
        /// <param name="moudleId"></param>
        /// <param name="menuId"></param>
        /// <param name="btnId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Authen(string moudleId, string menuId, string btnId, string id)
        {
            return View();
        }

        // GET: Adm/User/Login
        [HttpGet, AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 忘记密码
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult ForgotPwd()
        {
            return View();
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Reg()
        {
            return View();
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                UserService.Logout();
            }
            return RedirectToAction("Login");
        }

        #endregion

        #region Ajax

        [HttpGet]
        public JsonResult GetList(string moudleId, string menuId, string btnId)
        {
            var queryBase = new QueryBase
            {
                Start = Request["start"].ToInt(),
                Length = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                SearchKey = Request["keywords"]
            };
            Expression<Func<UserDto, bool>> exp = item => !item.IsDeleted;
            if (!queryBase.SearchKey.IsBlank())
                exp = exp.And(item => item.User.Contains(queryBase.SearchKey) || item.xingming.Contains(queryBase.SearchKey));

            var dto = UserService.GetWithPages(queryBase, exp, Request["orderBy"], Request["orderDir"]);
            var res = new ResultDto<UserDto>
            {
                start = dto.start,
                length = dto.length,
                recordsTotal = dto.recordsTotal,
                data = dto.data.Select(d => new UserDto
                {
                    Id = d.Id,
                    User = d.User,
                    xingming = d.xingming,
                    Email = d.Email,
                    CreateDateTime = d.CreateDateTime,
                    Status = d.Status,
                    IsDeleted = d.IsDeleted
                }).ToList()
            };
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetMyRoles(string moudleId, string menuId, string btnId, string id)
        {
            var queryBase = new QueryBase
            {
                Start = Request["start"].ToInt(),
                Length = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                SearchKey = Request["keywords"]
            };

            var dto = UserService.GetMyRoles(queryBase, id);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetNotMyRoles(string moudleId, string menuId, string btnId, string id)
        {
            var queryBase = new QueryBase
            {
                Start = Request["start"].ToInt(),
                Length = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                SearchKey = Request["keywords"]
            };

            var dto = UserService.GetNotMyRoles(queryBase, id);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AuthenRole(string moudleId, string menuId, string btnId, string id, List<RoleDto> roles)
        {
            var dto = new Result<string>();
            var userRoles = roles.Select(item => new UserRoleDto {UserId = id, RoleId = item.Id}).ToList();
            dto.flag = userRoleService.Add(userRoles);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UnAuthenRole(string moudleId, string menuId, string btnId, string id, List<RoleDto> roles)
        {
            var dto = new Result<string>();
            var roleIds = roles.Select(item => item.Id);
            dto.flag = userRoleService.DeleteReal(item => roleIds.Contains(item.RoleId));
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost, AllowAnonymous]
        public ActionResult Login(UserDto model)
        {
            var result = UserService.Login(model);
            if (result.flag)
            {
                var authenticationManager = HttpContext.GetOwinContext().Authentication;
                var claims = new List<Claim>
                {
                    new Claim(ConstValue.LoginUserIdKey, result.data.Id),
                    new Claim(ClaimTypes.Name, model.User)
                };
                var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var pro = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
                authenticationManager.SignIn(pro, identity);
                return RedirectToAction("Index", "Control");
            }
            ModelState.AddModelError("Error", result.msg);
            return View();
        }



        [HttpPost]
        public ActionResult Add(string moudleId, string menuId, string btnId, UserDto dto)
        {
            dto.Pwd = dto.Pwd.ToMD5();
            UserService.Add(dto);
            return RedirectToAction("Index", RouteData.Values);
        }


        [HttpPost]
        public ActionResult Edit(string moudleId, string menuId, string btnId, UserDto dto)
        {
            var old = UserService.GetOne(item => item.Id == dto.Id);
            dto.Pwd = dto.Pwd.IsBlank() ? old.Pwd : dto.Pwd.ToMD5();
            dto.User = old.User;
            UserService.Update(dto);
            return RedirectToAction("Index", RouteData.Values);
        }


        [HttpPost]
        public JsonResult Delete(string moudleId, string menuId, string btnId, List<string> ids)
        {
            var res = new Result<string>();

            if (ids != null && ids.Any())
                res.flag = UserService.Delete(item => ids.Contains(item.Id));

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult GetTestData()
        {
            List<UserDto> users = new List<UserDto>();
            for (int i = 0; i < 5; i++)
            {
                users.Add(new UserDto()
                {
                    User = "i" + i,
                    Id = i.ToString()
                });
            }
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}