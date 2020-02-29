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
    /// 邮件表配置
    /// </summary>
    public class EmailPoolConfig : BaseConfig<EmailPoolEntity>
    {
        public EmailPoolConfig()
        {
            ToTable("EmailPool");
            Property(item => item.Title).HasColumnType("varchar").IsRequired().HasMaxLength(100);
            Property(item => item.Content).HasColumnType("text").IsRequired();
            Property(item => item.FailTimes).IsRequired();
        }
    }
}
