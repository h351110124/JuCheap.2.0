

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
    /// Gonggao业务契约
    /// </summary>
    public partial interface IGonggaoService
    {
		/// <summary>
		/// 添加gonggao
		/// </summary>
		/// <param name="gonggao">gonggao实体</param>
		/// <returns></returns>
		string Add(GonggaoDto gonggao);

		/// <summary>
        /// 批量添加gonggao
        /// </summary>
        /// <param name="models">gonggao集合</param>
        /// <returns></returns>
        bool Add(List<GonggaoDto> models);

		/// <summary>
		/// 编辑gonggao
		/// </summary>
		/// <param name="gonggao">实体</param>
		/// <returns></returns>
		bool Update(GonggaoDto gonggao);

		/// <summary>
		/// 批量更新gonggao
		/// </summary>
		/// <param name="gonggaos">gonggao实体集合</param>
		/// <returns></returns>
		bool Update(IEnumerable<GonggaoDto> gonggaos);

		/// <summary>
		/// 删除gonggao(软删除)
		/// </summary>
		/// <param name="id">Id</param>
		/// <returns></returns>
		bool Delete(string id);

		/// <summary>
        /// 批量删除gonggao(软删除)
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool Delete(Expression<Func<GonggaoDto, bool>> exp);

		/// <summary>
        /// 批量删除gonggao(物理删除)
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool DeleteReal(Expression<Func<GonggaoDto, bool>> exp);

		/// <summary>
        ///  获取单条符合条件的 gonggao 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        GonggaoDto GetOne(Expression<Func<GonggaoDto, bool>> exp);

		/// <summary>
        /// 查询符合调价的 gonggao
        /// </summary>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        List<GonggaoDto> Query<OrderKeyType>(Expression<Func<GonggaoDto, bool>> exp, Expression<Func<GonggaoDto, OrderKeyType>> orderExp, bool isDesc = true);

		/// <summary>
        /// 分页获取gonggao
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<GonggaoDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<GonggaoDto, bool>> exp, Expression<Func<GonggaoDto, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取gonggao
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<GonggaoDto> GetWithPages(QueryBase queryBase, Expression<Func<GonggaoDto, bool>> exp, string orderBy, string orderDir = "desc");
    } 
}
