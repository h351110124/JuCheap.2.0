using JuCheap.Core;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Helpers;

namespace JuCheap.Web
{
    public partial class Startup
    {
        // 有关配置身份验证的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                CookieName = ConstValue.JuCheapAuthorizeCookieName,
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Adm/User/Login"),
                ExpireTimeSpan = TimeSpan.FromHours(8)//8小时cookie过期(默认是14天)
            });
        }
    }

    /// <summary>
    /// IIdentity扩展
    /// </summary>
    public static class IdentityExtention
    {
        /// <summary>
        /// 获取登录的用户ID
        /// </summary>
        /// <param name="identity">IIdentity</param>
        /// <returns></returns>
        public static string GetLoginUserId(this IIdentity identity)
        {
            if (identity != null)
            {
                var claim = (identity as ClaimsIdentity).FindFirst(ConstValue.LoginUserIdKey);
                if (claim != null)
                    return claim.Value;
            }
            return string.Empty;
        }
    }
}