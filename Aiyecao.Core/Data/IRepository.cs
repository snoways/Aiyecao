using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Aiyecao.Core.Data
{
    /// <summary>
    /// 这里T是泛型，（T:class  T是泛型参数。where T : class  是对T的限制，这里的意思是T必须是引用类型，包括任何类、接口、委托或数组类型）
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<T> Table { get; }
        /// <summary>
        /// IRespository插入接口
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool InsertEntity(T entity);


        /// <summary>
        /// IRespository修改接口
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateEntity(T entity);

        /// <summary>
        /// IRespository删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteEntity(T entity);

        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T GetEntityById(object Id);

        /// <summary>
        /// 带条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> where);


        /// <summary>
        /// 查询所有
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetALLEntity();

        /// <summary>
        /// 这里也可以用IEnumerable类型，带条件查询所有
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IQueryable<T> GetAllEntityWhere(Expression<Func<T, bool>> where);


        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        IList<T> GetPageEntities(int pageIndex, int PageSize);

        /// <summary>
        /// 分页带查询条件
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="PageSize"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        IList<T> GetPageEntities(int pageIndex, int PageSize, Expression<Func<T, bool>> where);



    }
}
