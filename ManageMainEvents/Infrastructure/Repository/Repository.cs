using System;
using Common.Domain.Core.Data;
using Microsoft.EntityFrameworkCore;
using ManageMainEvents.Infrastructure.Context;
using System.Linq;
using System.Linq.Expressions;

namespace ManageMainEvents.Infrastructure.Repository
{
    public class Repository<TEntity, TID> : IRepository<TEntity, TID> where TEntity : class
    {
        protected readonly DbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(PlataformMainEventContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual void Add(TEntity obj) =>
            DbSet.Add(obj);

        public virtual TEntity GetById(TID id)
        {
            var result = DbSet.Find(id);

            if (result != null)
                Db.Entry(result).Reload();

            return result;
        }

        public virtual IQueryable<TEntity> Search(Expression<Func<TEntity, bool>> predicate) => 
            DbSet.AsNoTracking().Where(predicate);

        public virtual IQueryable<TEntity> GetAll() => DbSet;

        public virtual IQueryable<TEntity> GetPagination(
            Expression<Func<TEntity, bool>> filter,
            int page = 1,
            int quantity = 10) =>
            DbSet.AsNoTracking().Where(filter).Skip((page - 1) * quantity).Take(quantity);

        public virtual IQueryable<TEntity> GetPagination(
          Expression<Func<TEntity, bool>> filter,
          Expression<Func<TEntity, object>> orderBy,
          int page = 1,
          int quantity = 10
          ) =>
          DbSet.AsNoTracking().Where(filter).Skip((page - 1) * quantity).Take(quantity);

        public virtual IQueryable<TEntity> GetAutoComplete(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            int quantity = 10) =>
            DbSet.AsNoTracking().Where(filter).OrderBy(orderBy).Take(quantity);

        public virtual void Update(TEntity obj) =>
            DbSet.Update(obj);

        public virtual void Remove(TID id) =>
            DbSet.Remove(DbSet.Find(id));

        public int SaveChanges() =>
            Db.SaveChanges();

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
