using JuCheap.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Data.Config
{
    public class GonggaoConfig : BaseConfig<GonggaoEntity>
    {
        public GonggaoConfig()
        {
            ToTable("gonggao");
            Property(item => item.Xuhao).HasColumnType("int");
            Property(item => item.Title).HasColumnType("nvarchar").HasMaxLength(30);
            Property(item => item.Status).HasColumnType("nvarchar").HasMaxLength(10);
            Property(item => item.Remark).HasColumnType("ntext");
            Property(item => item.Uptime).HasColumnType("datetime");
            Property(item => item.leibie).HasColumnType("nvarchar").HasMaxLength(30);
        }
    }
}
