using System.ComponentModel.DataAnnotations;

namespace EFPROJECT.Entity
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseName { get; set; }

        [Required]
        [StringLength(50)]
        public string Mentor { get; set; }

        public List<Students> Student_D {  get; set; }  
    }
    public class CourseDTO
    {

        [Required]
        [StringLength(50)]
        public string CourseName { get; set; }

        [Required]
        [StringLength(50)]
        public string Mentor { get; set; }

    }

    public class CourseAll
    {
        public int CourseId { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseName { get; set; }

        [Required]
        [StringLength(50)]
        public string Mentor { get; set; }
    }

}
