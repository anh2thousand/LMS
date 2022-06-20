using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FullName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int Authorziation { get; set; }

        [NotMapped]
        public virtual ICollection<Course>? Courses { get; set; }
    }
}
