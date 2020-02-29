﻿/*******************************************************************************
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using AutoMapper;
using JuCheap.Core;
using JuCheap.Core.Extentions;
using JuCheap.Core.Log;
using JuCheap.Data;
using JuCheap.Entity;
using JuCheap.Service.Dto;
using JuCheap.Service.Enum;

namespace JuCheap.Service.Abstracts
{
    public partial class UserService : IDependency, IUserService
    {
        public IMenuService menuService { get; set; }

        public IRoleService roleService { get; set; }

        public IUserRoleService UserRoleService { get; set; }

        public IRoleMenuService roleMenuService { get; set; }

        public ILoginLogService loginLogService { get; set; }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public Result<UserDto> Login(UserDto dto)
        {
            var res = new Result<UserDto>();
            try
            {
                var User = GetOne(item => item.User == dto.User);
                if (User == null)
                    res.msg = "无效的用户";
                else
                {
                    //记录登录日志
                    loginLogService.Add(new LoginLogDto
                    {
                        UserId = User.Id,
                        User = User.User,
                        IP = WebHelper.GetClientIP(),
                        Mac = WebHelper.GetClientMACAddress()
                    });
                    if (User.Pwd != dto.Pwd)
                        res.msg = "登录密码错误";
                    else if (User.IsDeleted)
                        res.msg = "用户已被删除";
                    else if (User.Status == UserStatus.未激活)
                        res.msg = "账号未被激活";
                    else if (User.Status == UserStatus.禁用)
                        res.msg = "账号被禁用";
                    else
                    {
                        res.flag = true;
                        res.msg = "登录成功";
                        res.data = User;

                        //写入注册信息
                        DateTime expiration = dto.IsRememberMe
                            ? DateTime.Now.AddDays(7)
                            : DateTime.Now.Add(FormsAuthentication.Timeout);
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2,
                            User.User,
                            DateTime.Now,
                            expiration,
                            true,
                            User.Id.ToString(),
                            FormsAuthentication.FormsCookiePath);

                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                            FormsAuthentication.Encrypt(ticket))
                        {
                            HttpOnly = true,
                            Expires = expiration
                        };

#if !DEBUG
                cookie.Domain = FormsAuthentication.CookieDomain;
#endif

                        HttpContext.Current.Response.Cookies.Add(cookie);
                    }
                }
            }
            catch (Exception ex)
            {
                res.msg = ex.Message;
                Logger.Log(ex.Message, ex);
            }
            return res;
        }

        /// <summary>
        ///     用户退出
        /// </summary>
        public void Logout()
        {
            FormsAuthentication.SignOut();
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        /// <summary>
        /// 获取我的菜单
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<MenuDto> GetMyMenus(string UserId)
        {
            //获取我的角色
            var UserRoles = UserRoleService.Query(item => !item.IsDeleted && item.UserId == UserId, item => item.Id,false);
            var roleIds = UserRoles.Select(item => item.RoleId).Distinct();
            //获取我的角色权限
            var roleMenus = roleMenuService.Query(item => !item.IsDeleted && roleIds.Contains(item.RoleId),
                item => item.Id, false);
            var menuIds = roleMenus.Select(item => item.MenuId).Distinct();

            return menuService.Query(item => !item.IsDeleted && menuIds.Contains(item.Id), item => item.Order, false);
        }

        /// <summary>
        /// 获取我的角色
        /// </summary>
        /// <param name="query"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public ResultDto<RoleDto> GetMyRoles(QueryBase query, string UserId)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = scope.DbContexts.Get<JuCheapContext>();
                var UserRoleDbSet = db.Set<UserRoleEntity>().AsNoTracking().OrderBy(item => item.CreateDateTime)
                    .Where(item => item.UserId == UserId).ToList();
                var roleIds = UserRoleDbSet.Select(item => item.RoleId).Distinct().ToList();

                Expression<Func<RoleDto, bool>> exp = item => (!item.IsDeleted && roleIds.Contains(item.Id));
                if (!query.SearchKey.IsBlank())
                    exp = exp.And(item => item.Name.Contains(query.SearchKey));
                var where = exp.Cast<RoleDto, RoleEntity, bool>();
                var roleDbSet = db.Set<RoleEntity>()
                    .AsNoTracking()
                    .OrderBy(item => item.CreateDateTime)
                    .Where(where);
                var list = roleDbSet.Skip(query.Start).Take(query.Length).ToList();

                var dto = new ResultDto<RoleDto>
                {
                    recordsTotal = roleDbSet.Count(),
                    data = Mapper.Map<List<RoleEntity>, List<RoleDto>>(list)
                };
                return dto;
            }
        }

        /// <summary>
        /// 获取我尚未拥有的角色
        /// </summary>
        /// <param name="query"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public ResultDto<RoleDto> GetNotMyRoles(QueryBase query, string UserId)
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = scope.DbContexts.Get<JuCheapContext>();
                var UserRoleDbSet = db.Set<UserRoleEntity>().AsNoTracking().OrderBy(item => item.CreateDateTime)
                    .Where(item => item.UserId == UserId).ToList();
                var roleIds = UserRoleDbSet.Select(item => item.RoleId).Distinct().ToList();

                Expression<Func<RoleDto, bool>> exp = item => (!item.IsDeleted && !roleIds.Contains(item.Id));
                if (!query.SearchKey.IsBlank())
                    exp = exp.And(item => item.Name.Contains(query.SearchKey));
                var where = exp.Cast<RoleDto, RoleEntity, bool>();
                var roleDbSet = db.Set<RoleEntity>()
                    .AsNoTracking()
                    .OrderBy(item => item.CreateDateTime)
                    .Where(where);
                var list = roleDbSet.Skip(query.Start).Take(query.Length).ToList();

                var dto = new ResultDto<RoleDto>
                {
                    recordsTotal = roleDbSet.Count(),
                    data = Mapper.Map<List<RoleEntity>, List<RoleDto>>(list)
                };
                return dto;
            }
        }
    }
}
