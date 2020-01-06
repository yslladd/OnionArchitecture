using OnionArchitecture.Application.Interface;
using OnionArchitecture.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        private readonly IServiceBase<TEntity> _serviceBase;
        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public void Delete(TEntity obj)
        {
            _serviceBase.Delete(obj);
        }

        
        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public TEntity GetById(int Id)
        {
            return _serviceBase.GetById(Id);
        }

        public TEntity GetById(Guid Id)
        {
            return _serviceBase.GetById(Id);
        }

        public void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}
