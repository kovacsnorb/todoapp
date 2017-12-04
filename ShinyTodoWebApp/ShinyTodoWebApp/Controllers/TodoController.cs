using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShinyTodoWebApp.Repositories;
using ShinyTodoWebApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShinyTodoWebApp.Controllers
{
    public class TodoController : Controller
    {
        TodoRepository TodoRepository;

        public TodoController(TodoRepository todoRepository)
        {
            TodoRepository = todoRepository;
        }

        [Route("")]
        [Route("todo")]
        public IActionResult List([FromQuery] string isActive)
        {
            var myTodoList = TodoRepository.ListAllTodo(isActive);
            return View(myTodoList);
        }

        [Route("todo/add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Route("todo/add")]
        [HttpPost]
        public IActionResult Add(Todo todo)
        {
            TodoRepository.AddNew(todo);
            return RedirectToAction("List");
        }

        [Route("todo/{id}/delete")]
        [HttpGet]
        public IActionResult Delete(string id)
        {
            TodoRepository.Remove(id);
            return RedirectToAction("List");
        }

        [Route("todo/{id}/update")]
        [HttpGet]
        public IActionResult Update([FromRoute] string id)
        {
            var todoToUpdate = TodoRepository.GetTodoFromId(id);
            return View(todoToUpdate);
        }

        [Route("todo/{id}/update")]
        [HttpPost]
        public IActionResult Update(Todo todo)
        {
            TodoRepository.Update(todo);
            return RedirectToAction("List");
        }
    }
}
