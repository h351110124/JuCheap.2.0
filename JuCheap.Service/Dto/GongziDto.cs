using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Service.Dto
{
    public class GongziDto : BaseDto
    {
        public string Id { get; set; }

        //月份
        public string month { get; set; }

        //姓名
        public string xingming { get; set; }

        //基本工资
        public string jcgz { get; set; }

        //绩效工资
        public string jxgz { get; set; }

        //司龄工资
        public string slgz { get; set; }

        //补贴工资
        public string btgz { get; set; }

        //补发工资
        public string bfgz { get; set; }

        //奖金
        public string jiangjin { get; set; }

        //考勤扣款
        public string kqkk { get; set; }

        //其它扣款
        public string otherkk { get; set; }

        //应发工资
        public string yingfagz { get; set; }

        //实发工资
        public string shifagz { get; set; }
    }
}
