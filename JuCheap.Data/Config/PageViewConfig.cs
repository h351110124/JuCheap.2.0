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
    /// 用户表配置
    /// </summary>
    public class PageViewConfig : BaseConfig<PageViewEntity>
    {
        public PageViewConfig()
        {
            ToTable("PageView");
            
            Property(item => item.UserId);
            Property(item => item.User).HasColumnType("varchar").HasMaxLength(20);
            Property(item => item.Url).HasColumnType("varchar").IsRequired().HasMaxLength(300);
        }
    }
}
