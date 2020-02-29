using JuCheap.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Entity
{
    public class NoticeEntity : BaseEntity
    {
        /// <summary>
        /// 公告名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 公告内容
        /// </summary>
        public string Content { get; set; }
    }
}
