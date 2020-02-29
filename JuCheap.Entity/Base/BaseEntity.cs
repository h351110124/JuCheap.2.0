using JuCheap.Core;
using System;

namespace JuCheap.Entity.Base
{
    public class BaseEntity : IsDeletedFilter
    {
        public BaseEntity()
        {
            IsDeleted = false;
            CreateDateTime = DateTime.Now;
        }

        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime CreateDateTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }

    /// <summary>
    /// 软删除接口
    /// </summary>
    public interface IsDeletedFilter
    {
        /// <summary>
        /// 是否删除
        /// </summary>
        bool IsDeleted { get; set; }
    }

    public static class BaseEntityExtention
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity"></param>
        public static void Create(this BaseEntity entity)
        {
            entity.Id = SnowFlake.NewId();
            entity.CreateDateTime = DateTime.Now;
            entity.IsDeleted = false;
        }
    }
}
