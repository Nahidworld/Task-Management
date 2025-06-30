using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.BLL.Dtos;
using BLL.DTOs;

namespace TaskManagement.BLL.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<ProjectDto> GetAllProjects();
        ProjectDto GetProjectById(int id);
        void CreateProject(ProjectCreateDto dto);
        void UpdateProject(int id, ProjectUpdateDto dto);
        void DeleteProject(int id);
        //void AddProject(Project project);
        //void UpdateProject(Project project);
        //void DeleteProject(int id);
    }
}

//namespace BLL.Interfaces
//{
//    public interface IProjectService
//    {
//        IEnumerable<Project> GetAllProjects();
//        Project GetProjectById(int id);
//        void AddProject(Project project);
//        void UpdateProject(Project project);
//        void DeleteProject(int id);
//    }
//}