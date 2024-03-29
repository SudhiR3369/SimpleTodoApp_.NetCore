﻿using LibraryData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoServices
{
    public class TodoTaskService : ITodoTasks
    {
        private TheDbContext _context;
        public TodoTaskService(TheDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TodoTask> GetAllTasks()
        {
            return _context.TodoTasks.ToList();
        }

        public void AddTask(TodoTask newTask)
        {
            _context.Add(newTask);
            _context.SaveChanges();
        }

        public void UpdateTask(TodoTask newTask)
        {
            _context.Update(newTask);
            _context.SaveChanges();
        }

        public TodoTask GetTaskByID(int id)
        {
            return GetAllTasks().FirstOrDefault(task => task.Id == id);
        }

        public void DeleteTask(int id)
        {
            var taskDelete = GetTaskByID(id);
            _context.Remove(taskDelete);
            _context.SaveChanges();
        }


        public void SetTaskComplete(int id)
        {
            var taskComplete = GetTaskByID(id);
            taskComplete.IsComplete = true;
            _context.SaveChanges();
        }

        public IEnumerable<TodoTask> GetCompletedTasks()
        {
            var completedTasks = _context.TodoTasks.Where(task => task.IsComplete == true).ToList();
            return completedTasks;
        }
    }
}
