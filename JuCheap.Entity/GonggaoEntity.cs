using JuCheap.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Entity
{
    public class GonggaoEntity : BaseEntity
    {
        public int Xuhao { get; set; }

        public string Title { get; set; }

        public string Status { get; set; }

        public string Remark { get; set; }

        public DateTime? Uptime { get; set; }

        public string leibie { get; set; }
    }
}
