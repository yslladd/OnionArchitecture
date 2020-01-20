using AutoMapper;
using OnionArchitecture.Application.ViewModel;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnionArchitecture.Web.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CustomerVM, Customer>();
            CreateMap<Customer, CustomerVM>();

            CreateMap<TaskVM, Domain.Entities.Task>();
            CreateMap<Domain.Entities.Task, TaskVM>();
        }
    }
}
