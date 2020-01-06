using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.Interfaces.Repositories;
using OnionArchitecture.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Domain.Services
{
    public class CustomerService : ServiceBase<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
            : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
    }
}
