using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {

        void Add(TEntity obj);

        TEntity GetById(int Id);

        TEntity GetById(Guid Id);

        IEnumerable<TEntity> GetAll();

        void Update(TEntity obj);

        void Delete(TEntity obj);

        void Dispose();

    }
}
