using System;
using System.Diagnostics.Contracts;

namespace NgTodoList.Domain
{
    public class Todo
    {
        protected Todo() { }

        public Todo(string title, int userId)
        {
            Contract.Requires<Exception>(title.Length > 3, "O título da tarefa deve conter mais que 3 caracteres");
            Contract.Requires<Exception>(userId > 0, "Usuário inválido");

            this.Id = 0;
            this.Title = title;
            this.Done = false;
            this.UserId = userId;
        }

        public int Id { get; protected set; }
        public string Title { get; protected set; }
        public bool Done { get; protected set; }
        public int UserId { get; protected set; }
        public User User { get; protected set; }
    }
}
