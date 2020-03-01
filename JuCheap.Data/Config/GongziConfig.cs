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
            Property(item => item.month).HasColumnType("nvarchar").HasMaxLength(20);
            Property(item => item.xingming).HasColumnType("nvarchar").HasMaxLength(30);
            Property(item => item.jcgz).HasColumnType("nvarchar").HasMaxLength(20);
            Property(item => item.jxgz).HasColumnType("nvarchar").HasMaxLength(30);
            Property(item => item.slgz).HasColumnType("nvarchar").HasMaxLength(30);
            Property(item => item.btgz).HasColumnType("nvarchar").HasMaxLength(30);
            Property(item => item.bfgz).HasColumnType("nvarchar").HasMaxLength(30);
            Property(item => item.jiangjin).HasColumnType("nvarchar").HasMaxLength(30);
            Property(item => item.kqkk).HasColumnType("nvarchar").HasMaxLength(30);
            Property(item => item.otherkk).HasColumnType("nvarchar").HasMaxLength(30);
            Property(item => item.yingfagz).HasColumnType("nvarchar").HasMaxLength(30);
            Property(item => item.shifagz).HasColumnType("nvarchar").HasMaxLength(30);
        }
    }
}
