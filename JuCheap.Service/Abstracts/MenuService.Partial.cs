

/*******************************************************************************
* Copyright (C)  JuCheap.Com
* 
* Author: dj.wong
* Create Date: 03/01/2020 17:31:47
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
    /// Menu业务契约
    /// </summary>
    public partial class MenuService : ServiceBase<MenuEntity>, IDependency, IMenuService
    {
		#region 构造函数注册上下文
		public IDbContextScopeFactory _dbScopeFactory {get;set;}

        //private readonly IDbContextScopeFactory _dbScopeFactory;

        //public MenuService(IDbContextScopeFactory dbScopeFactory)
        //{
        //    _dbScopeFactory = dbScopeFactory;
        //}

        #endregion

		#region IMenuService 接口实现

		/// <summary>
		/// 添加menu
		/// </summary>
		/// <param name="dto">menu实体</param>
		/// <returns></returns>
		public string Add(MenuDto dto)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var entity = Mapper.Map<MenuDto, MenuEntity>(dto);
				entity.Create();
                dbSet.Add(entity);
                scope.SaveChanges();
                return entity.Id;
            }
		}

		/// <summary>
        /// 批量添加menu
        /// </summary>
        /// <param name="dtos">menu集合</param>
        /// <returns></returns>
        public bool Add(List<MenuDto> dtos)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var entities = Mapper.Map<List<MenuDto>, List<MenuEntity>>(dtos);
				entities.ForEach(x => x.Create());
                dbSet.AddRange(entities);
                scope.SaveChanges();
				return true;
            }
		}

		/// <summary>
		/// 编辑menu
		/// </summary>
		/// <param name="dto">实体</param>
		/// <returns></returns>
		public bool Update(MenuDto dto)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var entity = Mapper.Map<MenuDto, MenuEntity>(dto);
                dbSet.AddOrUpdate(entity);
                scope.SaveChanges();
				return true;
            }
		}

		/// <summary>
		/// 批量更新menu
		/// </summary>
		/// <param name="dtos">menu实体集合</param>
		/// <returns></returns>
		public bool Update(IEnumerable<MenuDto> dtos)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var entities = Mapper.Map<IEnumerable<MenuDto>, IEnumerable<MenuEntity>>(dtos);
                dbSet.AddOrUpdate(entities.ToArray());
                scope.SaveChanges();
				return true;
            }
		}

		/// <summary>
		/// 删除menu(软删除)
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
        /// 批量删除menu(软删除)
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public bool Delete(Expression<Func<MenuDto, bool>> exp)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<MenuDto, MenuEntity, bool>();
				
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
        /// 批量删除menu(物理删除)
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public bool DeleteReal(Expression<Func<MenuDto, bool>> exp)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<MenuDto, MenuEntity, bool>();
				
                var models = dbSet.Where(where).ToList();
                dbSet.RemoveRange(models);
                scope.SaveChanges();
				return true;
            }
		}

		/// <summary>
        ///  获取单条符合条件的 menu 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public MenuDto GetOne(Expression<Func<MenuDto, bool>> exp)
		{
			using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<MenuDto, MenuEntity, bool>();
                var entity = dbSet.AsNoTracking().FirstOrDefault(where);

				return Mapper.Map<MenuEntity, MenuDto>(entity);
            }
		}

		/// <summary>
        /// 查询符合调价的 menu
        /// </summary>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public List<MenuDto> Query<OrderKeyType>(Expression<Func<MenuDto, bool>> exp, Expression<Func<MenuDto, OrderKeyType>> orderExp, bool isDesc = true)
		{
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<MenuDto, MenuEntity, bool>();
				var order = orderExp.Cast<MenuDto, MenuEntity, OrderKeyType>();
				var query = GetQuery(dbSet, where, order, isDesc);
				var list = query.ToList();
				return Mapper.Map<List<MenuEntity>, List<MenuDto>>(list);
            }
		}

		/// <summary>
        /// 分页获取Menu
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public ResultDto<MenuDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<MenuDto, bool>> exp, Expression<Func<MenuDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
			using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<MenuDto, MenuEntity, bool>();
				var order = orderExp.Cast<MenuDto, MenuEntity, OrderKeyType>();
				var query = GetQuery(dbSet, where, order, isDesc);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
				var list = query_list.ToList();

                var dto = new ResultDto<MenuDto>
				{
					recordsTotal = query_count.Value,
					data = Mapper.Map<List<MenuEntity>, List<MenuDto>>(list)
                };
				return dto;
            }
        }

		/// <summary>
        /// 分页获取Menu
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">排序类型：desc(默认)/asc</param>
        /// <returns></returns>
        public ResultDto<MenuDto> GetWithPages(QueryBase queryBase, Expression<Func<MenuDto, bool>> exp, string orderBy, string orderDir = "desc")
        {
			using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<MenuDto, MenuEntity, bool>();
				//var order = orderExp.Cast<MenuDto, MenuEntity, OrderKeyType>();
				var query = GetQuery(dbSet, where, orderBy, orderDir);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
				var list = query_list.ToList();

                var dto = new ResultDto<MenuDto>
				{
					recordsTotal = query_count.Value,
					data = Mapper.Map<List<MenuEntity>, List<MenuDto>>(list)
                };
				return dto;
            }
        }

		#endregion
    } 
}
