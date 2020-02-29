using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Service.Dto
{
    public class CarDto : BaseDto
    {
        //车牌号
        [DisplayName("车牌号")]
        public string Carnumber { get; set; }

        //车辆类型
        [DisplayName("车辆类型")]
        public string Type { get; set; }

        //可乘人数
        [DisplayName("可乘人数")]
        public string Zuoweinumber { get; set; }

        //车品牌
        [DisplayName("车品牌")]
        public string Pinpai { get; set; }

        //车辆状态 0-回场 1-离场
        [DisplayName("车辆状态")]
        public string Status { get; set; }
    }
}
