using OnionArchitecture.Application.Interface;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Application
{
    public class CustomerAppService : AppServiceBase<Customer>, ICustomerAppService
    {
        private readonly ICustomerService _customerService;

        public CustomerAppService(ICustomerService customerService)
            : base(customerService)
        {
            _customerService = customerService;
        }        
    }
}
