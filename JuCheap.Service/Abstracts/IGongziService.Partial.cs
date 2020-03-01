

/*******************************************************************************
* Copyright (C)  JuCheap.Com
* 
* Author: dj.wong
* Create Date: 02/29/2020 23:16:05
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
    /// Gongzi业务契约
    /// </summary>
    public partial interface IGongziService
    {
		/// <summary>
		/// 添加gongzi
		/// </summary>
		/// <param name="gongzi">gongzi实体</param>
		/// <returns></returns>
		string Add(GongziDto gongzi);

		/// <summary>
        /// 批量添加gongzi
        /// </summary>
        /// <param name="models">gongzi集合</param>
        /// <returns></returns>
        bool Add(List<GongziDto> models);

		/// <summary>
		/// 编辑gongzi
		/// </summary>
		/// <param name="gongzi">实体</param>
		/// <returns></returns>
		bool Update(GongziDto gongzi);

		/// <summary>
		/// 批量更新gongzi
		/// </summary>
		/// <param name="gongzis">gongzi实体集合</param>
		/// <returns></returns>
		bool Update(IEnumerable<GongziDto> gongzis);

		/// <summary>
		/// 删除gongzi(软删除)
		/// </summary>
		/// <param name="id">Id</param>
		/// <returns></returns>
		bool Delete(string id);

		/// <summary>
        /// 批量删除gongzi(软删除)
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool Delete(Expression<Func<GongziDto, bool>> exp);

		/// <summary>
        /// 批量删除gongzi(物理删除)
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool DeleteReal(Expression<Func<GongziDto, bool>> exp);

		/// <summary>
        ///  获取单条符合条件的 gongzi 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        GongziDto GetOne(Expression<Func<GongziDto, bool>> exp);

		/// <summary>
        /// 查询符合调价的 gongzi
        /// </summary>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        List<GongziDto> Query<OrderKeyType>(Expression<Func<GongziDto, bool>> exp, Expression<Func<GongziDto, OrderKeyType>> orderExp, bool isDesc = true);

		/// <summary>
        /// 分页获取gongzi
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<GongziDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<GongziDto, bool>> exp, Expression<Func<GongziDto, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取gongzi
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<GongziDto> GetWithPages(QueryBase queryBase, Expression<Func<GongziDto, bool>> exp, string orderBy, string orderDir = "desc");
    } 
}
