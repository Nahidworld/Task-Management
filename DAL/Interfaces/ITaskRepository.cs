using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskManagement.DAL.Interfaces
{
    public interface ITaskRepository : IRepository<Task>
    {
        IEnumerable<Task> GetAllTasks();
        Task GetTaskById(int id);
        void AddTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(int id);
    }
}


//namespace DAL.Interfaces
//{
//    public interface ITaskRepository : IRepository<TaskItem>
//    {
//        IEnumerable<TaskItem> GetTasksByProjectId(int projectId);

//    }
//}
