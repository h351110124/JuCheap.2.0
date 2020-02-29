using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using JuCheap.Service.Enum;

namespace JuCheap.Service.Dto
{
    /// <summary>
    /// 用户DTO
    /// </summary>
    public class UserDto : BaseDto
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        [DisplayName("登录账号*"), Required, StringLength(20, MinimumLength = 5, ErrorMessage = "长度在5-20个字符之间")]
        public string User { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        [DisplayName("登录密码*"), Required, StringLength(36, MinimumLength = 6, ErrorMessage = "长度在6-36个字符之间")]
        public string Pwd { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string bumen { get; set; }

        /// <summary>
        /// 余额
        /// </summary>
        public decimal? money { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 日志
        /// </summary>
        public string log { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 审核
        /// </summary>
        public string shenhe { get; set; }


        public DateTime? RegTime { get; set; }

        /// <summary>
        /// 真实姓名
        /// </summary>
        [DisplayName("真实姓名*"), Required, StringLength(20, MinimumLength = 2, ErrorMessage = "长度在2-20个字符之间")]
        public string xingming { get; set; }

        public DateTime? lastlogdate { get; set; }

        public string lastlogIP { get; set; }

        public string kahao { get; set; }

        public string bmdaiding { get; set; }

        public string xiangpian { get; set; }

        public string dizhi { get; set; }

        public string Fingertmp1 { get; set; }

        public string Fingertmp2 { get; set; }

        public string id2 { get; set; }

        public decimal? butiemoney { get; set; }

        public string openid { get; set; }

        public string qcdm { get; set; }

        public string quanxian { get; set; }

        public string shitang { get; set; }

        public string CardNo { get; set; }

        public DateTime? ewmuptime { get; set; }

        public string zhiwu { get; set; }

        public string paypwd { get; set; }

        public string gonghao { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [DisplayName("邮箱*"), Required, StringLength(36, MinimumLength = 5, ErrorMessage = "长度在5-36个字符之间")]
        public string Email { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        [DisplayName("用户状态*"), Required]
        public UserStatus Status { get; set; }

        /// <summary>
        /// 状态名称
        /// </summary>
        public string StatusName
        {
            get { return Status.ToString(); }
        }

        /// <summary>
        /// 记住账号
        /// </summary>
        public bool IsRememberMe { get; set; }
    }
}
