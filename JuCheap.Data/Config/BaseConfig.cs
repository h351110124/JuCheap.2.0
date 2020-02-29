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
using JuCheap.Entity.Base;
using System.Data.Entity.ModelConfiguration;

namespace JuCheap.Data.Config
{
    /// <summary>
    /// 基础表配置
    /// </summary>
    public class BaseConfig<T> : EntityTypeConfiguration<T> where T: BaseEntity
    {
        public BaseConfig()
        {
            HasKey(item => item.Id);
            //自增Id的配置(默认不使用自增Id)
            //Property(item => item.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(item => item.Id).HasColumnType("varchar").HasMaxLength(50).IsRequired();
        }
    }
}
