using JuCheap.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Data.Config
{
    public class NoticeConfig : BaseConfig<NoticeEntity>
    {
        public NoticeConfig()
        {
            ToTable("Notice");

            Property(item => item.Name).HasColumnType("nvarchar").IsRequired().HasMaxLength(20);
            Property(item => item.Content).HasColumnType("nvarchar").IsRequired().HasMaxLength(2000);
        }
    }
}
