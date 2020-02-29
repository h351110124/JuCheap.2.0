

/*******************************************************************************
* Copyright (C)  JuCheap.Com
* 
* Author: dj.wong
* Create Date: 02/29/2020 20:57:34
* Description: Automated building by service@JuCheap.com 
* 
* Revision History:
* Date         Author               Description
*
*********************************************************************************/

using AutoMapper;
using EntityFramework.Extensions;
using JuCheap.Core;
using JuCheap.Core.Extentions;
using JuCheap.Entity;
using JuCheap.Entity.Base;
using JuCheap.Service.Dto;
using Mehdime.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace JuCheap.Service.Abstracts
{ 
	/// <summary>
    /// Car业务契约
    /// </summary>
    public partial class CarService : ServiceBase<CarEntity>, IDependency, ICarService
    {
		#region 构造函数注册上下文
		public IDbContextScopeFactory _dbScopeFactory {get;set;}

        //private readonly IDbContextScopeFactory _dbScopeFactory;

        //public CarService(IDbContextScopeFactory dbScopeFactory)
        //{
        //    _dbScopeFactory = dbScopeFactory;
        //}

        #endregion

		#region ICarService 接口实现

		/// <summary>
		/// 添加car
		/// </summary>
		/// <param name="dto">car实体</param>
		/// <returns></returns>
		public string Add(CarDto dto)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var entity = Mapper.Map<CarDto, CarEntity>(dto);
				entity.Create();
                dbSet.Add(entity);
                scope.SaveChanges();
                return entity.Id;
            }
		}

		/// <summary>
        /// 批量添加car
        /// </summary>
        /// <param name="dtos">car集合</param>
        /// <returns></returns>
        public bool Add(List<CarDto> dtos)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var entities = Mapper.Map<List<CarDto>, List<CarEntity>>(dtos);
				entities.ForEach(x => x.Create());
                dbSet.AddRange(entities);
                scope.SaveChanges();
				return true;
            }
		}

		/// <summary>
		/// 编辑car
		/// </summary>
		/// <param name="dto">实体</param>
		/// <returns></returns>
		public bool Update(CarDto dto)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var entity = Mapper.Map<CarDto, CarEntity>(dto);
                dbSet.AddOrUpdate(entity);
                scope.SaveChanges();
				return true;
            }
		}

		/// <summary>
		/// 批量更新car
		/// </summary>
		/// <param name="dtos">car实体集合</param>
		/// <returns></returns>
		public bool Update(IEnumerable<CarDto> dtos)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var entities = Mapper.Map<IEnumerable<CarDto>, IEnumerable<CarEntity>>(dtos);
                dbSet.AddOrUpdate(entities.ToArray());
                scope.SaveChanges();
				return true;
            }
		}

		/// <summary>
		/// 删除car(软删除)
		/// </summary>
		/// <param name="id">Id</param>
		/// <returns></returns>
		public bool Delete(string id)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);

                var model = dbSet.FirstOrDefault(item => item.Id == id);
                model.IsDeleted = true;
                scope.SaveChanges();
				return true;
            }
		}

		/// <summary>
        /// 批量删除car(软删除)
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public bool Delete(Expression<Func<CarDto, bool>> exp)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<CarDto, CarEntity, bool>();
				
                var models = dbSet.Where(where).ToList();
                foreach(var model in models)
				{
					model.IsDeleted = true;
				}
                scope.SaveChanges();
				return true;
            }
		}

		/// <summary>
        /// 批量删除car(物理删除)
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public bool DeleteReal(Expression<Func<CarDto, bool>> exp)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<CarDto, CarEntity, bool>();
				
                var models = dbSet.Where(where).ToList();
                dbSet.RemoveRange(models);
                scope.SaveChanges();
				return true;
            }
		}

		/// <summary>
        ///  获取单条符合条件的 car 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public CarDto GetOne(Expression<Func<CarDto, bool>> exp)
		{
			using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<CarDto, CarEntity, bool>();
                var entity = dbSet.AsNoTracking().FirstOrDefault(where);

				return Mapper.Map<CarEntity, CarDto>(entity);
            }
		}

		/// <summary>
        /// 查询符合调价的 car
        /// </summary>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public List<CarDto> Query<OrderKeyType>(Expression<Func<CarDto, bool>> exp, Expression<Func<CarDto, OrderKeyType>> orderExp, bool isDesc = true)
		{
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<CarDto, CarEntity, bool>();
				var order = orderExp.Cast<CarDto, CarEntity, OrderKeyType>();
				var query = GetQuery(dbSet, where, order, isDesc);
				var list = query.ToList();
				return Mapper.Map<List<CarEntity>, List<CarDto>>(list);
            }
		}

		/// <summary>
        /// 分页获取Car
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public ResultDto<CarDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<CarDto, bool>> exp, Expression<Func<CarDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
			using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<CarDto, CarEntity, bool>();
				var order = orderExp.Cast<CarDto, CarEntity, OrderKeyType>();
				var query = GetQuery(dbSet, where, order, isDesc);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
				var list = query_list.ToList();

                var dto = new ResultDto<CarDto>
				{
					recordsTotal = query_count.Value,
					data = Mapper.Map<List<CarEntity>, List<CarDto>>(list)
                };
				return dto;
            }
        }

		/// <summary>
        /// 分页获取Car
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">排序类型：desc(默认)/asc</param>
        /// <returns></returns>
        public ResultDto<CarDto> GetWithPages(QueryBase queryBase, Expression<Func<CarDto, bool>> exp, string orderBy, string orderDir = "desc")
        {
			using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<CarDto, CarEntity, bool>();
				//var order = orderExp.Cast<CarDto, CarEntity, OrderKeyType>();
				var query = GetQuery(dbSet, where, orderBy, orderDir);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
				var list = query_list.ToList();

                var dto = new ResultDto<CarDto>
				{
					recordsTotal = query_count.Value,
					data = Mapper.Map<List<CarEntity>, List<CarDto>>(list)
                };
				return dto;
            }
        }

		#endregion
    } 
}
