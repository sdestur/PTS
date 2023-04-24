using DataAccess.Abstract;
using DataAccess.UnitOfWorkDesign;
using Entity.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {

        public void Add(TEntity entity)
        {
            //DbContext nesnesi biraz fazla memory kullanır
            //using blogu görevini tamamladıktan sonra garbage collector ile 
            //garbage olarak toplanir, hafizadan nesneyi atariz.

            //IDisposable pattern implementation of C#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //entitynin referansını al, veri kaynağıyla ilişkilendir
                addedEntity.State = EntityState.Added; //ve ekle
                context.SaveChanges(); //işlemleri kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); //entitynin referansını al, veri kaynağıyla ilişkilendir
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            //Bu kısımda hata var, buraya tekrar döneceğim!
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList() //filtre null ise bunu yap
                    : context.Set<TEntity>().Where(filter).ToList(); //filtre null degil ise listeyi filtreleyip ver
            }
        }
        public IQueryable<TEntity> GetAllQ(Expression<Func<TEntity, bool>> filter = null)
        {
            //Bu kısımda hata var, buraya tekrar döneceğim!
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>() //filtre null ise bunu yap
                    : context.Set<TEntity>().Where(filter); //filtre null degil ise listeyi filtreleyip ver
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //entitynin referansını al, veri kaynağıyla ilişkilendir
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }















    //private IUnitOfWork _unitOfWork { get; set; }
    //private PersonelTakipSistemiContext _dbcontext { get; set; }
    //private DbSet<TEntity> _objectSet { get; set; }

    //public EfEntityRepositoryBase(IUnitOfWork unitOfWork)
    //{
    //    _unitOfWork = unitOfWork;
    //    _dbcontext = (_unitOfWork as UnitOfWork).Context;
    //    _objectSet = _dbcontext.Set<TEntity>();
    //}

    //public TEntity Get(int Id)
    //{
    //    return _objectSet.Find(Id);
    //}

    //public async Task<TEntity> GetAsync(int Id)
    //{
    //    return await _objectSet.FindAsync(Id);
    //}

    //public IQueryable<TEntity> GetAll()
    //{
    //    return _objectSet.AsQueryable();
    //}

    //public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> where)
    //{
    //    return _objectSet.Where(where);
    //}

    //public int Insert(TEntity obj)
    //{
    //    _objectSet.Add(obj);
    //    return Save();
    //}

    //public async Task<int> InsertAsync(TEntity obj)
    //{
    //    await _objectSet.AddAsync(obj);
    //    return await SaveAsync();
    //}

    //public int Update(TEntity obj)
    //{
    //    return Save();
    //}

    //public async Task<int> UpdateAsync(TEntity obj)
    //{

    //    return await SaveAsync();
    //}

    //public int Delete(TEntity obj)
    //{
    //    _objectSet.Remove(obj);

    //    return Save();
    //}

    //public async Task<int> DeleteAsync(TEntity obj)
    //{
    //    _objectSet.Remove(obj);

    //    return await SaveAsync();
    //}

    //private int Save()
    //{
    //    return _dbcontext.SaveChanges();
    //}

    //private async Task<int> SaveAsync()
    //{
    //    return await _dbcontext.SaveChangesAsync();
    //}

    //IQueryable IEntityRepository<TEntity>.Where(Expression<Func<TEntity, bool>> where)
    //{
    //    throw new NotImplementedException();
    //}

    //IQueryable IEntityRepository<TEntity>.GetAll()
    //{
    //    throw new NotImplementedException();
    //}
}

