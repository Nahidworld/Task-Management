using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Deadline { get; set; }

        [StringLength(50)]
        public string Status { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        public int AssignedToUserId { get; set; }

        [ForeignKey("AssignedToUserId")]
        public virtual User AssignedToUser { get; set; }
    }
}
