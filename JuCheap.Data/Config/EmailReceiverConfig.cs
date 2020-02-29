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
    /// 邮件接收人表配置
    /// </summary>
    public class EmailReceiverConfig : BaseConfig<EmailReceiverEntity>
    {
        public EmailReceiverConfig()
        {
            ToTable("EmailReceiver");
            
            Property(item => item.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
            Property(item => item.Type).IsRequired();
            HasRequired(item => item.EmailPool).WithMany(item => item.Receivers).HasForeignKey(item => item.EmailId);
        }
    }
}
