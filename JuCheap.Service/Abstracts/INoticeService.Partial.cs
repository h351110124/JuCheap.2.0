

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
    /// Notice业务契约
    /// </summary>
    public partial interface INoticeService
    {
		/// <summary>
		/// 添加notice
		/// </summary>
		/// <param name="notice">notice实体</param>
		/// <returns></returns>
		string Add(NoticeDto notice);

		/// <summary>
        /// 批量添加notice
        /// </summary>
        /// <param name="models">notice集合</param>
        /// <returns></returns>
        bool Add(List<NoticeDto> models);

		/// <summary>
		/// 编辑notice
		/// </summary>
		/// <param name="notice">实体</param>
		/// <returns></returns>
		bool Update(NoticeDto notice);

		/// <summary>
		/// 批量更新notice
		/// </summary>
		/// <param name="notices">notice实体集合</param>
		/// <returns></returns>
		bool Update(IEnumerable<NoticeDto> notices);

		/// <summary>
		/// 删除notice(软删除)
		/// </summary>
		/// <param name="id">Id</param>
		/// <returns></returns>
		bool Delete(string id);

		/// <summary>
        /// 批量删除notice(软删除)
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool Delete(Expression<Func<NoticeDto, bool>> exp);

		/// <summary>
        /// 批量删除notice(物理删除)
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool DeleteReal(Expression<Func<NoticeDto, bool>> exp);

		/// <summary>
        ///  获取单条符合条件的 notice 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        NoticeDto GetOne(Expression<Func<NoticeDto, bool>> exp);

		/// <summary>
        /// 查询符合调价的 notice
        /// </summary>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        List<NoticeDto> Query<OrderKeyType>(Expression<Func<NoticeDto, bool>> exp, Expression<Func<NoticeDto, OrderKeyType>> orderExp, bool isDesc = true);

		/// <summary>
        /// 分页获取notice
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<NoticeDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<NoticeDto, bool>> exp, Expression<Func<NoticeDto, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取notice
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<NoticeDto> GetWithPages(QueryBase queryBase, Expression<Func<NoticeDto, bool>> exp, string orderBy, string orderDir = "desc");
    } 
}
