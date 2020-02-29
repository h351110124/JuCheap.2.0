using JuCheap.Core.Extentions;
using JuCheap.Service.Abstracts;
using JuCheap.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace JuCheap.Web.Areas.Adm.Controllers
{
    public class GonggaoController : AdmBaseController
    {
        public IGonggaoService gonggaoService { get; set; }
        // GET: Adm/Gonggao
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetList()
        {
            var model = gonggaoService.Query(item =>item.Status == "1", item => item.Uptime, false).FirstOrDefault();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}