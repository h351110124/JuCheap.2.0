

/*******************************************************************************
* Copyright (C)  JuCheap.Com
* 
* Author: dj.wong
* Create Date: 02/29/2020 23:16:05
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
    /// PageView业务契约
    /// </summary>
    public partial class PageViewService : ServiceBase<PageViewEntity>, IDependency, IPageViewService
    {
		#region 构造函数注册上下文
		public IDbContextScopeFactory _dbScopeFactory {get;set;}

        //private readonly IDbContextScopeFactory _dbScopeFactory;

        //public PageViewService(IDbContextScopeFactory dbScopeFactory)
        //{
        //    _dbScopeFactory = dbScopeFactory;
        //}

        #endregion

		#region IPageViewService 接口实现

		/// <summary>
		/// 添加pageview
		/// </summary>
		/// <param name="dto">pageview实体</param>
		/// <returns></returns>
		public string Add(PageViewDto dto)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var entity = Mapper.Map<PageViewDto, PageViewEntity>(dto);
				entity.Create();
                dbSet.Add(entity);
                scope.SaveChanges();
                return entity.Id;
            }
		}

		/// <summary>
        /// 批量添加pageview
        /// </summary>
        /// <param name="dtos">pageview集合</param>
        /// <returns></returns>
        public bool Add(List<PageViewDto> dtos)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var entities = Mapper.Map<List<PageViewDto>, List<PageViewEntity>>(dtos);
				entities.ForEach(x => x.Create());
                dbSet.AddRange(entities);
                scope.SaveChanges();
				return true;
            }
		}

		/// <summary>
		/// 编辑pageview
		/// </summary>
		/// <param name="dto">实体</param>
		/// <returns></returns>
		public bool Update(PageViewDto dto)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var entity = Mapper.Map<PageViewDto, PageViewEntity>(dto);
                dbSet.AddOrUpdate(entity);
                scope.SaveChanges();
				return true;
            }
		}

		/// <summary>
		/// 批量更新pageview
		/// </summary>
		/// <param name="dtos">pageview实体集合</param>
		/// <returns></returns>
		public bool Update(IEnumerable<PageViewDto> dtos)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var entities = Mapper.Map<IEnumerable<PageViewDto>, IEnumerable<PageViewEntity>>(dtos);
                dbSet.AddOrUpdate(entities.ToArray());
                scope.SaveChanges();
				return true;
            }
		}

		/// <summary>
		/// 删除pageview(软删除)
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
        /// 批量删除pageview(软删除)
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public bool Delete(Expression<Func<PageViewDto, bool>> exp)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<PageViewDto, PageViewEntity, bool>();
				
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
        /// 批量删除pageview(物理删除)
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public bool DeleteReal(Expression<Func<PageViewDto, bool>> exp)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<PageViewDto, PageViewEntity, bool>();
				
                var models = dbSet.Where(where).ToList();
                dbSet.RemoveRange(models);
                scope.SaveChanges();
				return true;
            }
		}

		/// <summary>
        ///  获取单条符合条件的 pageview 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public PageViewDto GetOne(Expression<Func<PageViewDto, bool>> exp)
		{
			using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<PageViewDto, PageViewEntity, bool>();
                var entity = dbSet.AsNoTracking().FirstOrDefault(where);

				return Mapper.Map<PageViewEntity, PageViewDto>(entity);
            }
		}

		/// <summary>
        /// 查询符合调价的 pageview
        /// </summary>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public List<PageViewDto> Query<OrderKeyType>(Expression<Func<PageViewDto, bool>> exp, Expression<Func<PageViewDto, OrderKeyType>> orderExp, bool isDesc = true)
		{
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<PageViewDto, PageViewEntity, bool>();
				var order = orderExp.Cast<PageViewDto, PageViewEntity, OrderKeyType>();
				var query = GetQuery(dbSet, where, order, isDesc);
				var list = query.ToList();
				return Mapper.Map<List<PageViewEntity>, List<PageViewDto>>(list);
            }
		}

		/// <summary>
        /// 分页获取PageView
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public ResultDto<PageViewDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<PageViewDto, bool>> exp, Expression<Func<PageViewDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
			using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<PageViewDto, PageViewEntity, bool>();
				var order = orderExp.Cast<PageViewDto, PageViewEntity, OrderKeyType>();
				var query = GetQuery(dbSet, where, order, isDesc);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
				var list = query_list.ToList();

                var dto = new ResultDto<PageViewDto>
				{
					recordsTotal = query_count.Value,
					data = Mapper.Map<List<PageViewEntity>, List<PageViewDto>>(list)
                };
				return dto;
            }
        }

		/// <summary>
        /// 分页获取PageView
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">排序类型：desc(默认)/asc</param>
        /// <returns></returns>
        public ResultDto<PageViewDto> GetWithPages(QueryBase queryBase, Expression<Func<PageViewDto, bool>> exp, string orderBy, string orderDir = "desc")
        {
			using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<PageViewDto, PageViewEntity, bool>();
				//var order = orderExp.Cast<PageViewDto, PageViewEntity, OrderKeyType>();
				var query = GetQuery(dbSet, where, orderBy, orderDir);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
				var list = query_list.ToList();

                var dto = new ResultDto<PageViewDto>
				{
					recordsTotal = query_count.Value,
					data = Mapper.Map<List<PageViewEntity>, List<PageViewDto>>(list)
                };
				return dto;
            }
        }

		#endregion
    } 
}
