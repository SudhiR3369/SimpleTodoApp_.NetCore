using Bivek_SImpleToDoApp.Models;
using LibraryData;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Bivek_SImpleToDoApp.Controllers
{
    public class TodoController : Controller
    {
        private ITodoTasks _tasks;
        public TodoController(ITodoTasks tasks)
        {
            _tasks = tasks;
        }

        public IActionResult Index()
        {
            var taskModels = _tasks.GetAllTasks();
            var taskList = taskModels
                .Select(result => new TodoTaskViewModel
                {
                    Id = result.Id,
                    Task = result.Task,
                    Description = result.Description,
                    TaskDate = result.TaskDate.ToString("MM/dd/yyyy"),
                    IsComplete = result.IsComplete
                });
            var taskListVM = new TodoIndexModel()
            {
                Tasks = taskList
            };
            return View(taskListVM);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TodoTaskViewModel taskVM)
        {
            if (ModelState.IsValid)
            {
                DateTime TaskDate = DateTime.Parse(taskVM.TaskDate);
                TodoTask taskModel = new TodoTask()
                {                    
                    Task = taskVM.Task,
                    Description = taskVM.Description,
                    TaskDate = TaskDate
                };
                _tasks.AddTask(taskModel);
                return RedirectToAction("Index");
            }
            else
            {
                return View(new TodoTaskViewModel());
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var taskToEdit = _tasks.GetTaskByID(id);
            string TaskDate = taskToEdit.TaskDate.ToString("MM/dd/yyyy");
            TodoTaskViewModel taskModel = new TodoTaskViewModel()
            {
                Task = taskToEdit.Task,
                Description = taskToEdit.Description,
                TaskDate = TaskDate
            };
            return View(taskModel);
        }

        [HttpPost]
        public IActionResult Edit(TodoTaskViewModel taskVM)
        {
            if (ModelState.IsValid)
            {
                if (taskVM != null)
                {
                    DateTime TaskDate = DateTime.Parse(taskVM.TaskDate);
                    TodoTask taskModel = new TodoTask()
                    {
                        Id = (int)taskVM.Id,
                        Task = taskVM.Task,
                        Description = taskVM.Description,
                        TaskDate = TaskDate
                    };
                    _tasks.UpdateTask(taskModel);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View(new TodoTaskViewModel());
            }
        }
        public IActionResult SetComplete(int id)
        {
            _tasks.SetTaskComplete(id);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteTask(int id)
        {
            _tasks.DeleteTask(id);
            return RedirectToAction("Index");
        }
    }
}
