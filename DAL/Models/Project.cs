using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation property
        public virtual ICollection<Task> Tasks { get; set; }
    }
}

//namespace DAL.Models
//{
//    using System;
//    using System.Collections.Generic;

//    public partial class Project
//    {
//        public int ProjectId { get; set; }
//        public string Title { get; set; }
//        public string Description { get; set; }
//        public System.DateTime CreatedAt { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<Task> Task { get; set; }
//    }
//}
