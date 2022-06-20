using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string? Description { get; set; }
        public int Schedule { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Link { get; set; }
        public string? Security { get; set; }
        public int Actived { get; set; }
        [ForeignKey("UserName")]
        public string UserName { get; set; }

        [NotMapped]
        public virtual ICollection<User>? Users { get; set; }
    }
}
