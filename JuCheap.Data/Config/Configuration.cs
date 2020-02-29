/*******************************************************************************
* Copyright (C) JuCheap.Com
* 
* Author: dj.wong
* Create Date: 09/04/2015 11:47:14
* Description: Automated building by service@JuCheap.com 
* 
* Revision History:
* Date         Author               Description
*
*********************************************************************************/
using JuCheap.Core.Extentions;
using JuCheap.Entity;
using JuCheap.Entity.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace JuCheap.Data
{
    /// <summary>
    /// 数据库初始化
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<JuCheapContext>
    {
        private readonly DateTime now = new DateTime(2015, 5, 1, 23, 22, 21);

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;//启用自动迁移
            AutomaticMigrationDataLossAllowed = true;//是否允许接受数据丢失的情况，false=不允许，会抛异常；true=允许，有可能数据会丢失
        }

        protected override void Seed(JuCheapContext context)
        {
            if (context.Set<UserEntity>().Any())
            {
                return;
            }

            #region 用户

            var admin = new UserEntity
            {
                User = "jucheap",
                xingming = "超级管理员",
                Pwd = "qwaszx",
                Email = "service@jucheap.com",
                Status = 2,
                CreateDateTime = now
            };
            admin.Create();
            var guest = new UserEntity
            {
                User = "admin",
                xingming = "游客",
                Pwd = "qwaszx",
                Email = "service@jucheap.com",
                Status = 2,
                CreateDateTime = now
            };
            guest.Create();
            //用户
            var user = new List<UserEntity>
            {
                admin,
                guest
            };
            #endregion

            #region 菜单

            var system = new MenuEntity
            {
                Name = "系统设置",
                Url = "#",
                Type = 1,
                CreateDateTime = now,
                Order = 1
            };
            system.Create();
            var menuMgr = new MenuEntity
            {
                ParentId = system.Id,
                Name = "菜单管理",
                Url = "/Adm/Menu/Index",
                Type = 2,
                CreateDateTime = now,
                Order = 2
            };//2
            menuMgr.Create();
            var roleMgr = new MenuEntity
            {
                ParentId = system.Id,
                Name = "角色管理",
                Url = "/Adm/Role/Index",
                Type = 2,
                CreateDateTime = now,
                Order = 3
            };//3
            roleMgr.Create();
            var userMgr = new MenuEntity
            {
                ParentId = system.Id,
                Name = "用户管理",
                Url = "/Adm/User/Index",
                Type = 2,
                CreateDateTime = now,
                Order = 4
            };//4
            userMgr.Create();
            var roleAuthMgr = new MenuEntity
            {
                ParentId = system.Id,
                Name = "角色授权",
                Url = "/Adm/Role/AuthMenus",
                Type = 2,
                CreateDateTime = now,
                Order = 5
            };//5
            roleAuthMgr.Create();
            var mail = new MenuEntity
            {
                Name = "邮件系统",
                Url = "#",
                Type = 1,
                CreateDateTime = now,
                Order = 6
            };//6
            mail.Create();
            var mailMgr = new MenuEntity
            {
                ParentId = mail.Id,
                Name = "邮件列表",
                Url = "/Adm/Email/Index",
                Type = 2,
                CreateDateTime = now,
                Order = 7
            };//7
            mailMgr.Create();
            var log = new MenuEntity
            {
                Name = "日志查看",
                Url = "#",
                Type = 1,
                CreateDateTime = now,
                Order = 8
            };//8
            log.Create();
            var logLogin = new MenuEntity
            {
                ParentId = log.Id,
                Name = "登录日志",
                Url = "/Adm/Loginlog/Index",
                Type = 2,
                CreateDateTime = now,
                Order = 9
            };
            logLogin.Create();
            var logView = new MenuEntity
            {
                ParentId = log.Id,
                Name = "访问日志",
                Url = "/Adm/PageView/Index",
                Type = 2,
                CreateDateTime = now,
                Order = 10
            };
            logView.Create();
            //菜单
            var menus = new List<MenuEntity>
            {
                system,
                menuMgr,
                roleMgr,
                userMgr,
                roleAuthMgr,
                mail,
                mailMgr,
                log,
                logLogin,
                logView
            };
            var menuBtns = GetMenuButtons(menuMgr.Id, "Menu");//13
            var rolwBtns = GetMenuButtons(roleMgr.Id, "Role");//16
            var userBtns = GetMenuButtons(userMgr.Id, "User");//19
            var userAuth = new MenuEntity
            {
                ParentId = userMgr.Id,
                Name = "用户角色授权",
                Url = string.Format("/Adm/{0}/Authen", "User"),
                Type = 3,
                CreateDateTime = now,
                Order = 11
            };
            userAuth.Create();
            userBtns.Add(userAuth);//20

            menus.AddRange(menuBtns);//23
            menus.AddRange(rolwBtns);//26
            menus.AddRange(userBtns);//29
            var demo = new MenuEntity
            {
                ParentId = string.Empty,
                Name = "示例文档",
                Url = "#",
                Type = 1,
                Order = 12,
                CreateDateTime = now
            };//30
            demo.Create();
            var demoAdv = new MenuEntity
            {
                ParentId = string.Empty, Name = "高级示例", Url = "#", Type = 1,
                Order = 13,
                CreateDateTime = now
            };//31
            demoAdv.Create();
            var mailSend = new MenuEntity { ParentId = mailMgr.Id, Name = "发送邮件", Url = "/Adm/Email/Add", Type = 3, Order = 14, CreateDateTime = now };
            mailSend.Create();
            menus.Add(mailSend);
            menus.Add(demo);
            menus.Add(demoAdv);

            var demoMenus = new List<MenuEntity>
            {
                new MenuEntity { ParentId = demo.Id, Name = "按钮", Url = "/Adm/Demo/Base", Type = 2, Order = 15, CreateDateTime = now },
                new MenuEntity { ParentId = demo.Id, Name = "ICON图标", Url = "/Adm/Demo/Fontawosome", Type = 2, Order = 16, CreateDateTime = now },
                new MenuEntity { ParentId = demo.Id, Name = "表单", Url = "/Adm/Demo/Form", Type = 2, Order = 17, CreateDateTime = now },
                new MenuEntity { ParentId = demo.Id, Name = "高级控件", Url = "/Adm/Demo/Advance", Type = 2, Order = 18, CreateDateTime = now },
                new MenuEntity { ParentId = demo.Id, Name = "相册", Url = "/Adm/Demo/Gallery", Type = 2, Order = 19, CreateDateTime = now },
                new MenuEntity { ParentId = demo.Id, Name = "个人主页", Url = "/Adm/Demo/Profile", Type = 2, Order = 20, CreateDateTime = now },
                new MenuEntity { ParentId = demo.Id, Name = "邮件-收件箱", Url = "/Adm/Demo/InBox", Type = 2, Order = 21, CreateDateTime = now },
                new MenuEntity { ParentId = demo.Id, Name = "邮件-查看邮件", Url = "/Adm/Demo/InBoxDetail", Type = 2, Order = 22, CreateDateTime = now },
                new MenuEntity { ParentId = demo.Id, Name = "邮件-写邮件", Url = "/Adm/Demo/InBoxCompose", Type = 2, Order = 23, CreateDateTime = now },
                new MenuEntity { ParentId = demoAdv.Id, Name = "编辑器", Url = "/Adm/Demo/Editor", Type = 2, Order = 24, CreateDateTime = now },
                new MenuEntity { ParentId = demoAdv.Id, Name = "表单验证", Url = "/Adm/Demo/FormValidate", Type = 2, Order = 25, CreateDateTime = now },
                new MenuEntity { ParentId = demoAdv.Id, Name = "图表", Url = "/Adm/Demo/Chart", Type = 2, Order = 26, CreateDateTime = now },
                new MenuEntity { ParentId = demoAdv.Id, Name = "图表-Morris", Url = "/Adm/Demo/ChartMorris", Type = 2, Order = 27, CreateDateTime = now },
                new MenuEntity { ParentId = demoAdv.Id, Name = "ChartJs", Url = "/Adm/Demo/ChartJs", Type = 2, Order = 28, CreateDateTime = now },
                new MenuEntity { ParentId = demoAdv.Id, Name = "表格", Url = "/Adm/Demo/DataTable", Type = 2, Order = 29, CreateDateTime = now },
                new MenuEntity { ParentId = demoAdv.Id, Name = "高级表格", Url = "/Adm/Demo/DataTableAdv", Type = 2, Order = 30, CreateDateTime = now }
            };
            demoMenus.ForEach(x => x.Create());
            menus.AddRange(demoMenus);

            #endregion

            #region 角色

            var superAdminRole = new RoleEntity { Name = "超级管理员", Description = "超级管理员"};
            var guestRole = new RoleEntity { Name = "guest", Description = "游客"};
            List<RoleEntity> roles = new List<RoleEntity>
            {
                superAdminRole,
                guestRole
            };
            roles.ForEach(x => x.Create());

            #endregion

            #region 用户角色关系

            List<UserRoleEntity> userRoles = new List<UserRoleEntity>
            {
                new UserRoleEntity { UserId = admin.Id, RoleId = superAdminRole.Id},
                new UserRoleEntity { UserId = guest.Id, RoleId = guestRole.Id}
            };
            userRoles.ForEach(x => x.Create());

            #endregion

            #region 角色菜单权限关系
            //超级管理员授权/游客授权
            List<RoleMenuEntity> roleMenus = new List<RoleMenuEntity>();
            var len = menus.Count;
            for (int i = 0; i < len; i++)
            {
                var menuId = menus[i].Id;
                roleMenus.Add(new RoleMenuEntity {RoleId = superAdminRole.Id, MenuId = menuId });
                roleMenus.Add(new RoleMenuEntity {RoleId = guestRole.Id, MenuId = menuId });
            }

            roleMenus.ForEach(x => x.Create());

            #endregion

            AddOrUpdate(context, m => m.User, user.ToArray());

            AddOrUpdate(context, m => new { m.ParentId, m.Name, m.Type }, menus.ToArray());

            AddOrUpdate(context, m => m.Name, roles.ToArray());

            AddOrUpdate(context, m => new { m.UserId, m.RoleId }, userRoles.ToArray());

            AddOrUpdate(context, m => new { m.MenuId, m.RoleId }, roleMenus.ToArray());
        }

        #region Private

        /// <summary>
        /// 获取菜单的基础按钮
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="controllerName"></param>
        /// <returns></returns>
        List<MenuEntity> GetMenuButtons(string parentId, string controllerName)
        {
            var buttons = new List<MenuEntity>
            {
                new MenuEntity
                {
                    ParentId = parentId,
                    Name = "添加",
                    Url = string.Format("/Adm/{0}/Add",controllerName),
                    Type = 3,
                    CreateDateTime = now,
                    Order = 1
                },
                new MenuEntity
                {
                    ParentId = parentId,
                    Name = "修改",
                    Url = string.Format("/Adm/{0}/Edit",controllerName),
                    Type = 3,
                    CreateDateTime = now,
                    Order = 2
                },
                new MenuEntity
                {
                    ParentId = parentId,
                    Name = "删除",
                    Url = string.Format("/Adm/{0}/Delete",controllerName),
                    Type = 3,
                    CreateDateTime = now,
                    Order = 3
                }
            };

            buttons.ForEach(x => x.Create());

            return buttons;
        }

        /// <summary>
        /// 添加更新数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="exp"></param>
        /// <param name="param"></param>
        void AddOrUpdate<T>(DbContext context, Expression<Func<T, object>> exp, T[] param) where T : class
        {
            DbSet<T> set = context.Set<T>();
            set.AddOrUpdate(exp, param);
        }

        #endregion
    }
}
