using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Infra.Data.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
    }
}
