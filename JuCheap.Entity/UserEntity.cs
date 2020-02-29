/*******************************************************************************
* Copyright (C) JuCheap.Com
* 
* Author: dj.wong
* Create Date: 09/04/2015 11:47:14
* Description: Automated building by service@JuCheap.com 
* 
* Revision History:
* Date         Author               Description
*
*********************************************************************************/
using System;
using System.Collections.Generic;
using JuCheap.Entity.Base;
using Newtonsoft.Json;

namespace JuCheap.Entity
{
    /// <summary>
    /// 用户实体
    /// </summary>
    public class UserEntity : BaseEntity
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
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
        public string Email { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public byte Status { get; set; }
        
        /// <summary>
        /// 用户拥有的角色
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
