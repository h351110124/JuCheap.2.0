using JuCheap.Core.Extentions;
using JuCheap.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace JuCheap.Web.Areas.Adm.Controllers
{
    public class GongziController : AdmBaseController
    {
        // GET: Adm/Gongzi
        public ActionResult Gongzi()
        {
            return View();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddGongzi(string moudleId, string menuId, string btnId)
        {
            ViewBag.ParentMenu = gongziService.Query(item => !item.IsDeleted, item => item.Id,
                false);
            return View();
        }

        public ActionResult EditGongzi(string moudleId, string menuId, string btnId, string id)
        {
            ViewBag.ParentMenu = gongziService.Query(item => !item.IsDeleted, item => item.Id,
               false);
            var model = gongziService.GetOne(item => item.Id == id);
            return View(model);
        }

        #region Ajax

        [HttpPost]
        public ActionResult Add(string moudleId, string menuId, string btnId, GongziDto dto)
        {
            gongziService.Add(dto);
            return RedirectToAction("Index", RouteData.Values);
        }


        [HttpPost]
        public ActionResult Edit(string moudleId, string menuId, string btnId, GongziDto dto)
        {
            gongziService.Update(dto);
            return RedirectToAction("Index", RouteData.Values);
        }


        [HttpPost]
        public JsonResult Delete(string moudleId, string menuId, string btnId, List<string> ids)
        {
            var res = new Result<string>();

            if (ids != null && ids.Any())
                res.flag = gongziService.Delete(item => ids.Contains(item.Id));

            return Json(res, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult GetList(string moudleId, string menuId, string btnId, string id)
        {
            //var parentId = id.ToInt();
            //var list = menuService.Query(item => !item.IsDeleted && item.ParentId == parentId, item => item.Id);
            //var dtos = new List<MenuDto>();
            //list.ForEach(item =>
            //{
            //    var dto = new MenuDto
            //    {
            //        id = item.Id.ToString(),
            //        name = item.Name,
            //        type = "folder",
            //        additionalParameters = new AdditionalParameters {id = item.Id.ToString()}
            //    };
            //    dtos.Add(dto);
            //});

            //return Json(dtos, JsonRequestBehavior.AllowGet);

            var queryBase = new QueryBase
            {
                Start = Request["start"].ToInt(),
                Length = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                SearchKey = Request["keywords"]
            };
            Expression<Func<GongziDto, bool>> exp = item => !item.IsDeleted;
            if (!queryBase.SearchKey.IsBlank())
                exp = exp.And(item => item.xingming.Contains(queryBase.SearchKey));

            var dto = gongziService.GetWithPages(queryBase, exp, Request["orderBy"], Request["orderDir"]);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}