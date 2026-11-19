using System.ComponentModel.DataAnnotations;

namespace APIDemoLab.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        // Llave foranea hacia Grade
        public int GradeId { get; set; }

        [MaxLength(45)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(45)]
        public string LastName { get; set; } = string.Empty;

        [MaxLength(45)]
        public string? Phone { get; set; }

        [MaxLength(45)]
        public string? Email { get; set; }

        public Grade Grade { get; set; } = null!;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
