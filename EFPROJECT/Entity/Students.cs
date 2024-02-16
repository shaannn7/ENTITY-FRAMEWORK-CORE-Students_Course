using System.ComponentModel.DataAnnotations;

namespace EFPROJECT.Entity
{
    public class Students
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Range(18, 25)]
        [Required]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set;}
    }
    public class StudentDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Range(18, 25)]
        [Required]
        public int Age { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        public int CourseID { get; set; }
    }
    public class StudentsDTOall
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CourseID { get; set; }

    }
    public class StudentsupdateDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public int CourseID { get; set; }
    }
    public class StudentsDTOalll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CourseID { get; set; }
        public string Mentor {  get; set; }
    }
}
