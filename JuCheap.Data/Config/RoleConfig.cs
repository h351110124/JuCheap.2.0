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
    /// 角色表配置
    /// </summary>
    public class RoleConfig : BaseConfig<RoleEntity>
    {
        public RoleConfig()
        {
            ToTable("Roles");
            
            Property(item => item.Name).HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(item => item.Description).HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
        }
    }
}
