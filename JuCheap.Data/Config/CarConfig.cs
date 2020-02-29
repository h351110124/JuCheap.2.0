using JuCheap.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Data.Config
{
    public class CarConfig : BaseConfig<CarEntity>
    {
        public CarConfig()
        {
            ToTable("car");
            Property(item => item.Carnumber).HasColumnType("nvarchar").IsRequired().HasMaxLength(30);
            Property(item => item.Type).HasColumnType("nvarchar").HasMaxLength(30);
            Property(item => item.Zuoweinumber).HasColumnType("nvarchar").HasMaxLength(10);
            Property(item => item.Pinpai).HasColumnType("nvarchar").HasMaxLength(30);
            Property(item => item.Status).HasColumnType("nvarchar").HasMaxLength(10);
        }
    }
}
