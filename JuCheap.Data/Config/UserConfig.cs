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
    public class UserConfig : BaseConfig<UserEntity>
    {
        public UserConfig()
        {
            ToTable("Userss");
            Property(item => item.User).HasColumnType("varchar").IsRequired().HasMaxLength(20);
            Property(item => item.Pwd).HasColumnType("varchar").IsRequired().HasMaxLength(36);
            Property(item => item.bumen).HasColumnType("nvarchar").IsRequired().HasMaxLength(40);
            Property(item => item.money).HasColumnType("money").IsRequired();
            Property(item => item.type).HasColumnType("nvarchar").IsRequired().HasMaxLength(40);
            Property(item => item.log).HasColumnType("ntext").IsRequired();
            Property(item => item.Tel).HasColumnType("nvarchar").IsRequired().HasMaxLength(30);
            Property(item => item.shenhe).HasColumnType("nvarchar").IsRequired().HasMaxLength(10);
            Property(item => item.RegTime).HasColumnType("datetime").IsRequired();
            Property(item => item.xingming).HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(item => item.lastlogdate).HasColumnType("datetime").IsRequired();
            Property(item => item.lastlogIP).HasColumnType("nvarchar").IsRequired().HasMaxLength(40);
            Property(item => item.kahao).HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(item => item.bmdaiding).HasColumnType("nvarchar").IsRequired().HasMaxLength(10);
            Property(item => item.xiangpian).HasColumnType("nvarchar").IsRequired().HasMaxLength(255);
            Property(item => item.dizhi).HasColumnType("nvarchar").IsRequired().HasMaxLength(255);
            Property(item => item.Fingertmp1).HasColumnType("ntext").IsRequired();
            Property(item => item.Fingertmp2).HasColumnType("ntext").IsRequired().HasMaxLength(20);
            Property(item => item.id2).HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            Property(item => item.butiemoney).HasColumnType("money").IsRequired();
            Property(item => item.openid).HasColumnType("nvarchar").IsRequired().HasMaxLength(100);
            Property(item => item.qcdm).HasColumnType("nvarchar").IsRequired().HasMaxLength(10);
            Property(item => item.quanxian).HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(item => item.shitang).HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(item => item.CardNo).HasColumnType("nvarchar").IsRequired().HasMaxLength(200);
            Property(item => item.ewmuptime).HasColumnType("datetime").IsRequired();
            Property(item => item.zhiwu).HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(item => item.paypwd).HasColumnType("nvarchar").IsRequired().HasMaxLength(30);
            Property(item => item.gonghao).HasColumnType("nvarchar").IsRequired().HasMaxLength(30);
            Property(item => item.Status).IsRequired();
            Property(item => item.Email).HasColumnType("varchar").IsRequired().HasMaxLength(36);
        }
    }
}
