using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.Interfaces;
using OnionArchitecture.Domain.Interfaces.Repositories;
using OnionArchitecture.Infra.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Infra.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        private readonly OAContext Db;
        public CustomerRepository(OAContext DbContext) : base(DbContext)
        {
            Db = DbContext;
        }

    }
}
