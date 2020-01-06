using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.Interfaces;
using OnionArchitecture.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnionArchitecture.Infra.Data.Repositories
{
    public class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {
        public IEnumerable<Task> FindByTitle(string Title)
        {
            return Db.Tasks.Where(t => t.Title.ToLower() == Title.ToLower());
        }
    }
}
