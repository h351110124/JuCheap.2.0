

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
    /// UserRole业务契约
    /// </summary>
    public partial class UserRoleService : ServiceBase<UserRoleEntity>, IDependency, IUserRoleService
    {
		#region 构造函数注册上下文
		public IDbContextScopeFactory _dbScopeFactory {get;set;}

        //private readonly IDbContextScopeFactory _dbScopeFactory;

        //public UserRoleService(IDbContextScopeFactory dbScopeFactory)
        //{
        //    _dbScopeFactory = dbScopeFactory;
        //}

        #endregion

		#region IUserRoleService 接口实现

		/// <summary>
		/// 添加userrole
		/// </summary>
		/// <param name="dto">userrole实体</param>
		/// <returns></returns>
		public string Add(UserRoleDto dto)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var entity = Mapper.Map<UserRoleDto, UserRoleEntity>(dto);
				entity.Create();
                dbSet.Add(entity);
                scope.SaveChanges();
                return entity.Id;
            }
		}

		/// <summary>
        /// 批量添加userrole
        /// </summary>
        /// <param name="dtos">userrole集合</param>
        /// <returns></returns>
        public bool Add(List<UserRoleDto> dtos)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var entities = Mapper.Map<List<UserRoleDto>, List<UserRoleEntity>>(dtos);
				entities.ForEach(x => x.Create());
                dbSet.AddRange(entities);
                scope.SaveChanges();
				return true;
            }
		}

		/// <summary>
		/// 编辑userrole
		/// </summary>
		/// <param name="dto">实体</param>
		/// <returns></returns>
		public bool Update(UserRoleDto dto)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var entity = Mapper.Map<UserRoleDto, UserRoleEntity>(dto);
                dbSet.AddOrUpdate(entity);
                scope.SaveChanges();
				return true;
            }
		}

		/// <summary>
		/// 批量更新userrole
		/// </summary>
		/// <param name="dtos">userrole实体集合</param>
		/// <returns></returns>
		public bool Update(IEnumerable<UserRoleDto> dtos)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var entities = Mapper.Map<IEnumerable<UserRoleDto>, IEnumerable<UserRoleEntity>>(dtos);
                dbSet.AddOrUpdate(entities.ToArray());
                scope.SaveChanges();
				return true;
            }
		}

		/// <summary>
		/// 删除userrole(软删除)
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
        /// 批量删除userrole(软删除)
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public bool Delete(Expression<Func<UserRoleDto, bool>> exp)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<UserRoleDto, UserRoleEntity, bool>();
				
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
        /// 批量删除userrole(物理删除)
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public bool DeleteReal(Expression<Func<UserRoleDto, bool>> exp)
		{
			using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<UserRoleDto, UserRoleEntity, bool>();
				
                var models = dbSet.Where(where).ToList();
                dbSet.RemoveRange(models);
                scope.SaveChanges();
				return true;
            }
		}

		/// <summary>
        ///  获取单条符合条件的 userrole 数据
        /// </summary>
        /// <param name="exp">条件表达式</param>
        /// <returns></returns>
        public UserRoleDto GetOne(Expression<Func<UserRoleDto, bool>> exp)
		{
			using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<UserRoleDto, UserRoleEntity, bool>();
                var entity = dbSet.AsNoTracking().FirstOrDefault(where);

				return Mapper.Map<UserRoleEntity, UserRoleDto>(entity);
            }
		}

		/// <summary>
        /// 查询符合调价的 userrole
        /// </summary>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public List<UserRoleDto> Query<OrderKeyType>(Expression<Func<UserRoleDto, bool>> exp, Expression<Func<UserRoleDto, OrderKeyType>> orderExp, bool isDesc = true)
		{
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<UserRoleDto, UserRoleEntity, bool>();
				var order = orderExp.Cast<UserRoleDto, UserRoleEntity, OrderKeyType>();
				var query = GetQuery(dbSet, where, order, isDesc);
				var list = query.ToList();
				return Mapper.Map<List<UserRoleEntity>, List<UserRoleDto>>(list);
            }
		}

		/// <summary>
        /// 分页获取UserRole
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderExp">排序条件</param>
		/// <param name="isDesc">是否是降序排列</param>
        /// <returns></returns>
        public ResultDto<UserRoleDto> GetWithPages<OrderKeyType>(QueryBase queryBase, Expression<Func<UserRoleDto, bool>> exp, Expression<Func<UserRoleDto, OrderKeyType>> orderExp, bool isDesc = true)
        {
			using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<UserRoleDto, UserRoleEntity, bool>();
				var order = orderExp.Cast<UserRoleDto, UserRoleEntity, OrderKeyType>();
				var query = GetQuery(dbSet, where, order, isDesc);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
				var list = query_list.ToList();

                var dto = new ResultDto<UserRoleDto>
				{
					recordsTotal = query_count.Value,
					data = Mapper.Map<List<UserRoleEntity>, List<UserRoleDto>>(list)
                };
				return dto;
            }
        }

		/// <summary>
        /// 分页获取UserRole
        /// </summary>
        /// <param name="queryBase">QueryBase</param>
		/// <param name="exp">过滤条件</param>
		/// <param name="orderBy">排序条件</param>
		/// <param name="orderDir">排序类型：desc(默认)/asc</param>
        /// <returns></returns>
        public ResultDto<UserRoleDto> GetWithPages(QueryBase queryBase, Expression<Func<UserRoleDto, bool>> exp, string orderBy, string orderDir = "desc")
        {
			using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
				var where = exp.Cast<UserRoleDto, UserRoleEntity, bool>();
				//var order = orderExp.Cast<UserRoleDto, UserRoleEntity, OrderKeyType>();
				var query = GetQuery(dbSet, where, orderBy, orderDir);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
				var list = query_list.ToList();

                var dto = new ResultDto<UserRoleDto>
				{
					recordsTotal = query_count.Value,
					data = Mapper.Map<List<UserRoleEntity>, List<UserRoleDto>>(list)
                };
				return dto;
            }
        }

		#endregion
    } 
}
