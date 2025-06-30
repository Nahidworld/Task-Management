using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagement.BLL.Dtos;
using TaskManagement.BLL.Interfaces;
using DAL.Interfaces;
using BLL.DTOs;
using TaskManagement.DAL.Interfaces;
using DAL.Models;

namespace TaskManagement.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public IEnumerable<ProjectDto> GetAllProjects()
        {
            var projects = _projectRepository.GetAll();
            return projects.Select(p => new ProjectDto
            {
                ProjectId = p.ProjectId,
                Title = p.Title,
                Description = p.Description,
                CreatedAt = p.CreatedAt
            }).ToList();
        }

        public ProjectDto GetProjectById(int id)
        {
            var project = _projectRepository.GetById(id);
            if (project == null) throw new Exception("Project not found");

            return new ProjectDto
            {
                ProjectId = project.ProjectId,
                Title = project.Title,
                Description = project.Description,
                CreatedAt = project.CreatedAt

            };
        }

        public void CreateProject(ProjectCreateDto dto)
        {
            var project = new Project
            {
                Title = dto.Title,
                Description = dto.Description,
                CreatedAt = dto.CreatedAt
            };

            _projectRepository.Add(project);
        }

        public void UpdateProject(int id, ProjectUpdateDto dto)
        {
            var existingProject = _projectRepository.GetById(id);
            if (existingProject == null)
                throw new Exception("Project not found");

            existingProject.Title = dto.Title;
            existingProject.Description = dto.Description;

            _projectRepository.Update(existingProject);
        }

        public void DeleteProject(int id)
        {
            var project = _projectRepository.GetById(id);
            if (project == null)
                throw new Exception("Project not found");

            _projectRepository.Delete(id);
        }
    }
}
