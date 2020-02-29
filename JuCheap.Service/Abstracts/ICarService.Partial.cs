

/*******************************************************************************
* Copyright (C)  JuCheap.Com
* 
* Author: dj.wong
* Create Date: 02/29/2020 20:57:34
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
    /// Car业务契约
    /// </summary>
    public partial interface ICarService
    {
		/// <summary>
		/// 添加car
		/// </summary>
		/// <param name="car">car实体</param>
		/// <returns></returns>
		string Add(CarDto car);

		/// <summary>
        /// 批量添加car
        /// </summary>
        /// <param name="models">car集合</param>
        /// <returns></returns>
        bool Add(List<CarDto> models);

		/// <summary>
		/// 编辑car
		/// </summary>
		/// <param name="car">实体</param>
		/// <returns></returns>
		bool Update(CarDto car);

		/// <summary>
		/// 批量更新car
		/// </summary>
		/// <param name="cars">car实体集合</param>
		/// <returns></returns>
		bool Update(IEnumerable<CarDto> cars);

		/// <summary>
		/// 删除car(软删除)
		/// </summary>
		/// <param name="id">Id</param>
		/// <returns></returns>
		bool Delete(string id);

		/// <summary>
        /// 批量删除car(软删除)
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool Delete(Expression<Func<CarDto, bool>> exp);

		/// <summary>
        /// 批量删除car(物理删除)
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        bool DeleteReal(Expression<Func<CarDto, bool>> exp);

		/// <summary>
        ///  获取单条符合条件的 car 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        CarDto GetOne(Expression<Func<CarDto, bool>> exp);

		/// <summary>
        /// 查询符合调价的 car
        /// </summary>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        List<CarDto> Query<OrderKeyType>(Expression<Func<CarDto, bool>> exp, Expression<Func<CarDto, OrderKeyType>> orderExp, bool isDesc = true);

		/// <summary>
        /// 分页获取car
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<CarDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<CarDto, bool>> exp, Expression<Func<CarDto, OrderKeyType>> orderExp, bool isDesc = true);

        /// <summary>
        /// 分页获取car
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">是否是降序排列</param>
        /// <returns></returns>
        ResultDto<CarDto> GetWithPages(QueryBase queryBase, Expression<Func<CarDto, bool>> exp, string orderBy, string orderDir = "desc");
    } 
}
