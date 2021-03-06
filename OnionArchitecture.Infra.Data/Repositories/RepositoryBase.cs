﻿using Microsoft.EntityFrameworkCore;
using OnionArchitecture.Domain.Interfaces;
using OnionArchitecture.Domain.Interfaces.Repositories;
using OnionArchitecture.Infra.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnionArchitecture.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly OAContext Db;
        public RepositoryBase(OAContext DbContext)
        {
            Db = DbContext;
        }

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public void Delete(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
            Db.SaveChanges();
        }
        
        public IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public TEntity GetById(int Id)
        {
            return Db.Set<TEntity>().Find(Id);
        }

        public TEntity GetById(Guid Id)
        {
            return Db.Set<TEntity>().Find(Id);
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
            Db.SaveChanges();

        }

        public void Dispose()
        {
            Db.Dispose();
        }

    }
}
