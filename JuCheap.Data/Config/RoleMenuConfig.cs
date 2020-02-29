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
using JuCheap.Entity;

namespace JuCheap.Data.Config
{
    /// <summary>
    /// 角色菜单关系表配置
    /// </summary>
    public class RoleMenuConfig : BaseConfig<RoleMenuEntity>
    {
        public RoleMenuConfig()
        {
            ToTable("RoleMenu");
            Property(item => item.RoleId).IsRequired();
            Property(item => item.MenuId).IsRequired();
        }
    }
}
