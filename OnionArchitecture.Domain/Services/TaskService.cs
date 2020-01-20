using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.Interfaces.Repositories;
using OnionArchitecture.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Domain.Services
{
   
    public class TaskService : ServiceBase<Task>, ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
            : base(taskRepository)
        {
            _taskRepository = taskRepository;
        }
    }
}
