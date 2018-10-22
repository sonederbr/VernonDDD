﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Domain.Core.Data
{
    public interface IRepository<TEntity, TID> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(TID id);

        IQueryable<TEntity> Search(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetPagination(
            Expression<Func<TEntity, bool>> filter, int pagina = 1, int qtdRegistros = 10);

        IQueryable<TEntity> GetPagination(
            Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, object>> orderBy, int pagina = 1, int qtdRegistros = 10);

        IQueryable<TEntity> GetAutoComplete(
            Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, object>> orderBy,
            int quantity = 10);

        void Update(TEntity obj);

        void Remove(TID id);

        int SaveChanges();
    }
}
