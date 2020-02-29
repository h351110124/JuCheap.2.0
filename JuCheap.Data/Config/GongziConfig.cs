using JuCheap.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Data.Config
{
    public class GongziConfig : BaseConfig<GongziEntity>
    {
        public GongziConfig()
        {
            ToTable("gongzi");
            Property(item => item.month).HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(item => item.xingming).HasColumnType("nvarchar").IsRequired().HasMaxLength(30);
            Property(item => item.jcgz).HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(item => item.jxgz).HasColumnType("nvarchar").IsRequired().HasMaxLength(30);
            Property(item => item.slgz).HasColumnType("nvarchar").IsRequired().HasMaxLength(30);
            Property(item => item.btgz).HasColumnType("nvarchar").IsRequired().HasMaxLength(30);
            Property(item => item.bfgz).HasColumnType("nvarchar").IsRequired().HasMaxLength(30);
            Property(item => item.jiangjin).HasColumnType("nvarchar").IsRequired().HasMaxLength(30);
            Property(item => item.kqkk).HasColumnType("nvarchar").IsRequired().HasMaxLength(30);
            Property(item => item.otherkk).HasColumnType("nvarchar").IsRequired().HasMaxLength(30);
            Property(item => item.yingfagz).HasColumnType("nvarchar").IsRequired().HasMaxLength(30);
            Property(item => item.shifagz).HasColumnType("nvarchar").IsRequired().HasMaxLength(30);
        }
    }
}
