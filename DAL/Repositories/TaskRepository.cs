using DAL.Models;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using TaskManagement.DAL.Interfaces;
using DAL;

namespace TaskManagement.DAL.Repositories
{
    public class TaskRepository : GenericRepository<Task>, ITaskRepository
    {
        private readonly TaskContext _context;

        public TaskRepository(TaskContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _context.Tasks.ToList();
        }

        public Task GetTaskById(int id)
        {
            return _context.Tasks.Find(id);
        }

        public void AddTask(Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTask(Task task)
        {
            _context.Entry(task).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }
    }
}


//namespace DAL.Repositories
//{
//    public class TaskRepository : Repository<TaskItem>, ITaskRepository
//    {
//        public TaskRepository(TaskContext context) : base(context) { }

//        public IEnumerable<TaskItem> GetTasksByProjectId(int projectId)
//        {
//            return dbSet.Where(t => t.ProjectId == projectId).ToList();
//        }
//    }
//}