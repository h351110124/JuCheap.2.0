﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(JuCheap.Web.Startup))]

namespace JuCheap.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 有关如何配置应用程序的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureAuth(app);
        }
    }
}
