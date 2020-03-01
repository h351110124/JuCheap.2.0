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
using System.Collections.Generic;
using JuCheap.Service.Dto;

namespace JuCheap.Service.Abstracts
{
    public partial interface IUserService
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Result<UserDto> Login(UserDto dto);

        Result<UserDto> Yanzheng(string user);

        /// <summary>
        /// 用户退出
        /// </summary>
        void Logout();

        /// <summary>
        /// 获取我的菜单
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        List<MenuDto> GetMyMenus(string UserId);

        /// <summary>
        /// 获取我的角色
        /// </summary>
        /// <param name="query"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        ResultDto<RoleDto> GetMyRoles(QueryBase query,string UserId);

        /// <summary>
        /// 获取我尚未拥有的权限
        /// </summary>
        /// <param name="query"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        ResultDto<RoleDto> GetNotMyRoles(QueryBase query, string UserId);
    }
}
