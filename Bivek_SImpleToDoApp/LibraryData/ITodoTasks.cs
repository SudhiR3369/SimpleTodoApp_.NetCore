using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface ITodoTasks
    {
        IEnumerable<TodoTask> GetAllTasks();
        void AddTask(TodoTask newTask);
        void UpdateTask(TodoTask newTask);
        TodoTask GetTaskByID(int id);
        void DeleteTask(int id);
        void SetTaskComplete(int id);
        IEnumerable<TodoTask> GetCompletedTasks();
    }
}
