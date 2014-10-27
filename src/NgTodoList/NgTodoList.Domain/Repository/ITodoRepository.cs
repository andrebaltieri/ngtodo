using System;
using System.Collections.Generic;

namespace NgTodoList.Domain.Repository
{
    public interface ITodoRepository : IDisposable
    {
        IList<Todo> Get(string email);
        IList<Todo> GetArchive(string email);
        void Sync(IList<Todo> todos);
    }
}
