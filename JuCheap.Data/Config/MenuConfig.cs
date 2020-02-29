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
    /// 菜单表配置
    /// </summary>
    public class MenuConfig : BaseConfig<MenuEntity>
    {
        public MenuConfig()
        {
            ToTable("Menu");
            
            Property(item => item.Name).HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(item => item.Type).IsRequired();
            Property(item => item.Url).HasColumnType("varchar").IsRequired().HasMaxLength(300);
        }
    }
}
