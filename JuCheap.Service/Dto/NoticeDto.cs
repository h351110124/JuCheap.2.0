using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Service.Dto
{
    public class NoticeDto : BaseDto
    {
        /// <summary>
        /// 公告名称
        /// </summary>
        [Required, DisplayName("公告名称"), MinLength(2), MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 公告内容
        /// </summary>
        [Required, DisplayName("公告内容"), MinLength(1), MaxLength(200)]
        public string Content { get; set; }
    }
}
