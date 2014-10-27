using NgTodoList.Data.Context;
using NgTodoList.Domain;
using NgTodoList.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NgTodoList.Data.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private NgTodoListDataContext _context;

        public TodoRepository(NgTodoListDataContext context)
        {
            this._context = context;
        }

        public IList<Todo> Get(string email)
        {
            return _context
                .Todos
                .Include(x => x.User)
                .Where(x =>
                    x.User.Email.ToLower() == email.ToLower() &&
                    x.Done == false)
                .OrderBy(x => x.Title)
                .ToList();
        }

        public IList<Todo> GetArchive(string email)
        {
            return _context
                .Todos
                .Include(x => x.User)
                .Where(x =>
                    x.User.Email.ToLower() == email.ToLower() &&
                    x.Done)
                .OrderBy(x => x.Title)
                .ToList();
        }

        public void Sync(IList<Todo> todos)
        {
            foreach (var todo in todos)
            {
                _context.Entry<Todo>(todo).State = EntityState.Modified;
            }
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
