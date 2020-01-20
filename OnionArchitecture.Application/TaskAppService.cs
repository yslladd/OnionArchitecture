using OnionArchitecture.Application.Interface;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Application
{
    
    public class TaskAppService : AppServiceBase<Task>, ITaskAppService
    {
        private readonly ITaskService _taskAppService;

        public TaskAppService(ITaskService taskAppService)
            : base(taskAppService)
        {
            _taskAppService = taskAppService;
        }
    }
}
