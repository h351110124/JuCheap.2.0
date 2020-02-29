using JuCheap.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Entity
{
    public class CarEntity : BaseEntity
    {
        //车牌号
        public string Carnumber { get; set; }

        //车辆类型
        public string Type { get; set; }

        //可乘人数
        public string Zuoweinumber { get; set; }

        //车品牌
        public string Pinpai { get; set; }

        //车辆状态 0-回场 1-离场
        public string Status { get; set; }
    }
}
