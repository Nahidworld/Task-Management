using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.BLL.Dtos;
using TaskManagement.BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using TaskManagement.DAL.Interfaces;

namespace TaskManagement.BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProjectRepository _projectRepository;

        public TaskService(ITaskRepository taskRepository, IUserRepository userRepository, IProjectRepository projectRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _projectRepository = projectRepository;
        }

        public IEnumerable<TaskDto> GetAllTasks()
        {
            var tasks = _taskRepository.GetAll();
            return tasks.Select(t => new TaskDto
            {
                TaskId = t.TaskId,
                Title = t.Title,
                Status = t.Status
            }).ToList();
        }

        public TaskDto GetTaskById(int id)
        {
            var task = _taskRepository.GetById(id);
            if (task == null) throw new Exception("Task not found");

            return new TaskDto
            {
                TaskId = task.TaskId,
                Title = task.Title,
                Status = task.Status
            };
        }

        public void CreateTask(TaskCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Title)) throw new Exception("Title is required");
            if (string.IsNullOrWhiteSpace(dto.Status)) throw new Exception("Status is required");

            var user = _userRepository.GetById(dto.AssignedToUserId);
            if (user == null) throw new Exception("Assigned User not found");

            var project = _projectRepository.GetById(dto.ProjectId);
            if (project == null) throw new Exception("Project not found");

            var task = new Task
            {
                Title = dto.Title,
                Description = dto.Description,
                Deadline = dto.Deadline,
                Status = dto.Status,
                ProjectId = dto.ProjectId,
                AssignedToUserId = dto.AssignedToUserId
            };

            _taskRepository.Add(task);
        }

        public void UpdateTask(int id, TaskUpdateDto dto)
        {
            var existingTask = _taskRepository.GetById(id);
            if (existingTask == null)
                throw new Exception("Task not found");

            existingTask.Title = dto.Title;
            existingTask.Description = dto.Description;
            existingTask.Status = dto.Status;
            existingTask.ProjectId = dto.ProjectId;
            existingTask.AssignedToUserId = dto.AssignedToUserId;
            existingTask.Deadline = dto.Deadline;

            _taskRepository.Update(existingTask);
        }

        public void DeleteTask(int id)
        {
            _taskRepository.Delete(id);
        }
    }
}