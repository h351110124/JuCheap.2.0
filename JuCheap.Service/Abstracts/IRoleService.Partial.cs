

/*******************************************************************************
* Copyright (C)  JuCheap.Com
* 
* Author: dj.wong
* Create Date: 03/01/2020 17:31:47
* Description: Automated building by service@JuCheap.com 
* 
* Revision History:
* Date         Author               Description
* 2017-08-02   dj.wong              optimization
*********************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JuCheap.Service.Dto;

namespace JuCheap.Service.Abstracts
{ 
	/// <summary>
    /// Role业务契约
    /// </summary>
    public partial interface IRoleService
    {
		/// <summary>
		/// 添加role
		/// </summary>
		/// <param name="role">role实体</param>
		/// <returns></returns>
		string Add(RoleDto role);

		/// <summary>
        /// 批量添加role
        /// </summary>
        /// <param name="models">role集合</param>
        /// <returns></returns>
        bool Add(List<RoleDto> models);

		/// <summary>
		/// 编辑role
		/// </summary>
		/// <param name="role">实体</param>
		/// <returns></returns>
		bool Update(RoleDto role);

		/// <summary>
		/// 批量更新role
		/// </summary>
		/// <param name="roles">role实体集合</param>
		/// <returns></returns>
		bool Update(IEnumerable<RoleDto> roles);

		/// <summary>
		/// 删除role(软删除)
		/// </summary>
		/// <param name="id">Id</param>
		/// <returns></returns>
		bool Delete(string id);

		/// <summary>
        /// 批量删除role(软删除)
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool Delete(Expression<Func<RoleDto, bool>> exp);

		/// <summary>
        /// 批量删除role(物理删除)
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool DeleteReal(Expression<Func<RoleDto, bool>> exp);

		/// <summary>
        ///  获取单条符合条件的 role 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        RoleDto GetOne(Expression<Func<RoleDto, bool>> exp);

		/// <summary>
        /// 查询符合调价的 role
        /// </summary>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        List<RoleDto> Query<OrderKeyType>(Expression<Func<RoleDto, bool>> exp, Expression<Func<RoleDto, OrderKeyType>> orderExp, bool isDesc = true);

		/// <summary>
        /// 分页获取role
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<RoleDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<RoleDto, bool>> exp, Expression<Func<RoleDto, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取role
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<RoleDto> GetWithPages(QueryBase queryBase, Expression<Func<RoleDto, bool>> exp, string orderBy, string orderDir = "desc");
    } 
}
