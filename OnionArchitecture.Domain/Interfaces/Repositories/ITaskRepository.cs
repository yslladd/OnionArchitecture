using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Domain.Interfaces.Repositories
{
    public interface ITaskRepository : IRepositoryBase<Task>
    {
        IEnumerable<Task> FindByTitle(string Title);
    }
}
