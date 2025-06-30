using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using TaskManagement.DAL.Interfaces;
using DAL;

namespace TaskManagement.DAL.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly TaskContext _context;

        public ProjectRepository(TaskContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return _context.Projects.ToList();
        }

        public Project GetProjectById(int id)
        {
            return _context.Projects.Find(id);
        }

        public void AddProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            _context.Entry(project).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteProject(int id)
        {
            var project = _context.Projects.Find(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
        }
    }
}


//namespace DAL.Repositories
//{
//    public class ProjectRepository : Repository<Project>, IProjectRepository
//    {
//        public ProjectRepository(TaskContext context) : base(context) { }

//        // Add project-specific methods if needed
//    }
//}