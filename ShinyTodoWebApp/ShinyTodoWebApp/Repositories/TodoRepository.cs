using ShinyTodoWebApp.Entities;
using ShinyTodoWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShinyTodoWebApp.Repositories
{
    public class TodoRepository
    {
        TodoContext TodoContext;

        public TodoRepository(TodoContext todoContext)
        {
            TodoContext = todoContext;
        }

        public List<Todo> ListAllTodo(string inputStatus)
        {
            if (inputStatus is null)
            {
                return TodoContext.Todos.ToList();
            }
            else
            {
                return TodoContext.Todos.Where(t => t.IsDone != Boolean.Parse(inputStatus)).ToList();
            }
        }

        public void AddNew(Todo newTodo)
        {
            TodoContext.Todos.Add(newTodo);
            TodoContext.SaveChanges();
        }

        public void Remove(string id)
        {
            var todoToRemove = TodoContext.Todos.FirstOrDefault(t => t.Id == int.Parse(id));
            TodoContext.Remove(todoToRemove);
            TodoContext.SaveChanges();
        }

        public void Update(Todo todo)
        {
            var todoToUpdate = TodoContext.Todos.FirstOrDefault(t => t.Id == todo.Id);
            todoToUpdate.Title = todo.Title;
            todoToUpdate.IsDone = todo.IsDone;
            todoToUpdate.IsUrgent = todo.IsUrgent;
            TodoContext.SaveChanges();
        }

        public Todo GetTodoFromId(string id)
        {
            return TodoContext.Todos.FirstOrDefault(t => t.Id == int.Parse(id));
        }
    }
}
