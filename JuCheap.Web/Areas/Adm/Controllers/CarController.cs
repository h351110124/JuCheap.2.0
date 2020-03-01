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
    public class CarController : AdmBaseController
    {
        // GET: Adm/Car
        public ActionResult Car(string moudleId, string menuId, string btnId)
        {
            GetButtons(menuId);
            return View();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCar(string moudleId, string menuId, string btnId)
        {
            ViewBag.ParentMenu = carService.Query(item => !item.IsDeleted, item => item.Id,
                false);
            return View();
        }

        public ActionResult EditCar(string moudleId, string menuId, string btnId, string id)
        {
            ViewBag.ParentMenu = carService.Query(item => !item.IsDeleted, item => item.Id,
               false);
            var model = carService.GetOne(item => item.Id == id);
            return View(model);
        }

        #region Ajax

        [HttpPost]
        public ActionResult AddCar(string moudleId, string menuId, string btnId, CarDto dto)
        {
            carService.Add(dto);
            return RedirectToAction("Car", RouteData.Values);
        }


        [HttpPost]
        public ActionResult EditCar(string moudleId, string menuId, string btnId, CarDto dto)
        {
            carService.Update(dto);
            return RedirectToAction("Car", RouteData.Values);
        }


        [HttpPost]
        public JsonResult Delete(string moudleId, string menuId, string btnId, List<string> ids)
        {
            var res = new Result<string>();

            if (ids != null && ids.Any())
                res.flag = carService.Delete(item => ids.Contains(item.Id));

            return Json(res, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public JsonResult GetList(string moudleId, string menuId, string btnId, string id)
        {
            var queryBase = new QueryBase
            {
                Start = Request["start"].ToInt(),
                Length = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                SearchKey = Request["keywords"]
            };
            Expression<Func<CarDto, bool>> exp = item => !item.IsDeleted;
            if (!queryBase.SearchKey.IsBlank())
                exp = exp.And(item => item.Carnumber.Contains(queryBase.SearchKey));

            var dto = carService.GetWithPages(queryBase, exp, Request["orderBy"], Request["orderDir"]);
            return Json(dto, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}