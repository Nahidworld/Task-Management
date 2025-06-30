using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BLL.Dtos;


namespace TaskManagement.BLL.Interfaces
{
    public interface ITaskService
    {
        IEnumerable<TaskDto> GetAllTasks();
        TaskDto GetTaskById(int id);
        void CreateTask(TaskCreateDto dto);
        void DeleteTask(int id);
        void UpdateTask(int id, TaskUpdateDto dto);

    }
}

//namespace BLL.Interfaces
//{
//    public interface ITaskService
//    {
//        IEnumerable<TaskItem> GetAllTasks();
//        TaskItem GetTaskById(int id);
//        void AddTask(TaskItem task);
//        void UpdateTask(TaskItem task);
//        void DeleteTask(int id);
//    }
//}