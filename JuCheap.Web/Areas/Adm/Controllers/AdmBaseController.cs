using JuCheap.Core;
using JuCheap.Core.Log;
using JuCheap.Service.Abstracts;
using JuCheap.Service.Dto;
using JuCheap.Service.Enum;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace JuCheap.Web.Areas.Adm.Controllers
{
    /// <summary>
    /// AdmBase
    /// </summary>
    public class AdmBaseController : Controller
    {
        public IPageViewService pageViewService { get; set; }
        public IMenuService menuService { get; set; }
        public IUserService UserService { get; set; }
        public IGongziService gongziService { get; set; }
        public IGonggaoService gonggaoService { get; set; }
        public ICarService carService { get; set; }
        /// <summary>
        /// 当前登录用户
        /// </summary>
        protected UserDto CurrentUser { get; private set; }
        /// <summary>
        /// 是否登录
        /// </summary>
        protected bool IsLogined { get; set; }

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            // TODO
            //用户信息处理
            if (User.Identity.IsAuthenticated)
            {
                CurrentUser = new UserDto
                {
                    Id = User.Identity.GetLoginUserId(),
                    User = User.Identity.Name
                };
            }

            IsLogined = CurrentUser != null;

            ViewRecord(requestContext);
        }

        /// <summary>
        /// 访问记录
        /// </summary>
        /// <param name="_context"></param>
        void ViewRecord(RequestContext _context)
        {
            try
            {
                var dto = new PageViewDto
                {
                    UserId = IsLogined ? CurrentUser.Id : string.Empty,
                    User = IsLogined ? CurrentUser.User : string.Empty,
                    Url = _context.HttpContext.Request.Url.PathAndQuery.ToLower(),
                    IP = WebHelper.GetClientIP()
                };
                pageViewService.Add(dto);
            }
            catch (Exception ex)
            {
                Logger.Log("访问记录", ex);
            }
        }

        /// <summary>
        /// 获取指定菜单下的按钮
        /// </summary>
        /// <param name="parentId"></param>
        protected virtual void GetButtons(string parentId)
        {
            //获取我的角色
            var UserId = CurrentUser.Id;
            var myMenus = UserService.GetMyMenus(UserId);

            ViewBag.MyButtons = myMenus.Where(item => item.ParentId == parentId && item.Type == MenuType.按钮)
                .OrderBy(item => item.Order)
                .ToList();
        }
    }
}