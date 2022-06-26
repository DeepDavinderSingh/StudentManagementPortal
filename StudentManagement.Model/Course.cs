using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Model
{
    public class Course
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        public string? courseName { get; set; }

        [Required]
        public string? courseDuration { get; set; }

    }
}
