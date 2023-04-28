using Entity.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : BaseEntity, new()
    {
        //TEntity Get(int Id);
        //IQueryable Where(Expression<Func<TEntity, bool>> where);
        //IQueryable GetAll();
        //int Insert(TEntity obj);
        //int Update(TEntity obj);
        //int Delete(TEntity obj);


        //// Async ile ilgili imzalar

        //Task<TEntity> GetAsync(int Id);
        //Task<int> InsertAsync(TEntity obj);
        //Task<int> UpdateAsync(TEntity obj);
        //Task<int> DeleteAsync(TEntity obj);

        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        IQueryable<T> GetAllQ(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
