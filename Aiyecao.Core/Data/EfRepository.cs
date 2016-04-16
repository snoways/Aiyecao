using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aiyecao.Core.Data
{
    public class EfRepository<T> : IRepository<T> where T : class
    {

        private readonly IDbContext _context;
        private IDbSet<T> _entities;

        public EfRepository(IDbContext context)
        {
            this._context = context;
        }

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }
        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get
            {
                return this.Entities;
            }
        }

        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool InsertEntity(T entity)
        {
            bool RetStatus = false;
            this.Entities.Add(entity);
            if (Save() > 0)
            {
                RetStatus = true;
            }
            return RetStatus;

        }


        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            // throw new NotImplementedException();
            bool RetStatus = false;
            if (entity != null && Save() > 0)
            {
                RetStatus = true;
            }
            return RetStatus;

        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            //throw new NotImplementedException();
            bool RetStatus = false;
            if (entity != null)
            {
                this.Entities.Remove(entity);
                if (Save() > 0)
                {
                    RetStatus = true;
                }
            }
            return RetStatus;

        }

        /// <summary>
        /// 对Set<T>根据id 的查询的操作
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T GetEntityById(object Id)
        {
            return this.Entities.Find(Id);
        }

        /// <summary>
        /// 这里对Set<T>是带条件的操作
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> where)
        {
            return this.Entities.Where(where).FirstOrDefault<T>();
        }



        /// <summary>
        /// 查询所有的
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetALLEntity()
        {
            //  throw new NotImplementedException();

            IEnumerable<T> query = this.Entities;

            return query;
        }

        /// <summary>
        /// 查询所有带条件
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IQueryable<T> GetAllEntityWhere(Expression<Func<T, bool>> where)
        {
            IQueryable<T> query = this.Entities.Where(where);
            return query;

        }


        /// <summary>
        /// 分页方法
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public IList<T> GetPageEntities(int pageIndex, int PageSize)
        {
            IList<T> List = this.Entities.Skip(pageIndex * PageSize).Take(PageSize).ToList();
            return List;

        }


        /// <summary>
        /// 分页带查询条件
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList<T> GetPageEntities(int pageIndex, int PageSize, Expression<Func<T, bool>> where)
        {
            // throw new NotImplementedException();
            IList<T> List = this.Entities.Where(where).Skip(pageIndex * PageSize).Take(PageSize).ToList();
            return List;

        }



        /// <summary>
        /// Save 保存确认方法
        /// </summary>
        public int Save()
        {
            return this._context.SaveChanges();

        }
    }
}
