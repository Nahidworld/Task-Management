using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TaskContext : DbContext
    {
        public TaskContext() : base("name=TaskContext") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        //public DbSet<TaskItem> TaskItem { get; set; }
        public DbSet<Task> Tasks { get; set; }
        //public DbSet<Attachment> Attachments { get; set; }
    }
}