using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using JuCheap.Core.Extentions;
using JuCheap.Service.Abstracts;
using JuCheap.Service.Dto;
using JuCheap.Web.Models;

namespace JuCheap.Web.Areas.Adm.Controllers
{
    /// <summary>
    /// role
    /// </summary>
    public class RoleController : AdmBaseController
    {
        public IRoleService roleService { set; get; }

        public IRoleMenuService roleMenuService { get; set; }

        #region Page

        // GET: Adm/Role
        public ActionResult Index(string moudleId, string menuId, string btnId)
        {
            GetButtons(menuId);
            return View();
        }


        public ActionResult Add(string moudleId, string menuId, string btnId)
        {
            return View();
        }


        public ActionResult Edit(string moudleId, string menuId, string btnId, string id)
        {
            var model = roleService.GetOne(item => item.Id == id);
            return View(model);
        }

        public ActionResult AuthMenus(string moudleId, string menuId, string btnId)
        {
            ViewBag.Menus = menuService.Query(item => !item.IsDeleted, item => item.Id, false);
            return View();
        }

        #endregion

        #region Ajax

        public JsonResult GetList(string moudleId, string menuId, string btnId)
        {
            var queryBase = new QueryBase
            {
                Start = Request["start"].ToInt(),
                Length = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                SearchKey = Request["keywords"]
            };
            Expression<Func<RoleDto, bool>> exp = item => !item.IsDeleted;
            if (!queryBase.SearchKey.IsBlank())
                exp = exp.And(item => item.Name.Contains(queryBase.SearchKey));

            var dto = roleService.GetWithPages(queryBase, exp, Request["orderBy"], Request["orderDir"]);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Add(string moudleId, string menuId, string btnId, RoleDto dto)
        {
            roleService.Add(dto);
            return RedirectToAction("Index", RouteData.Values);
        }

        [HttpPost]
        public ActionResult Edit(string moudleId, string menuId, string btnId, RoleDto dto)
        {
            roleService.Update(dto);
            return RedirectToAction("Index", RouteData.Values);
        }


        [HttpPost]
        public JsonResult Delete(string moudleId, string menuId, string btnId, List<string> ids)
        {
            var res = new Result<string>();

            if (ids != null && ids.Any())
                res.flag = roleService.Delete(item => ids.Contains(item.Id));

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AuthMenus(string moudleId, string menuId, string btnId, AuthMenuDto dto)
        {
            var res = new Result<string>();

            foreach (var roleId in dto.RoleIds)
            {
                roleMenuService.Delete(item => item.RoleId == roleId);
                var newRoleMenus = dto.MenuIds.Select(item => new RoleMenuDto {RoleId = roleId, MenuId = item}).ToList();
                roleMenuService.Add(newRoleMenus);
            }

            res.flag = true;

            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetRoleMenusByRoleId(string moudleId, string menuId, string btnId, string id)
        {
            var res = new Result<List<RoleMenuDto>>();
            var list = roleMenuService.Query(item => item.RoleId == id, item => item.Id, false);
            res.flag = true;
            res.data = list;
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}