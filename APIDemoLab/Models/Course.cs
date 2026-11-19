using System.ComponentModel.DataAnnotations;

namespace APIDemoLab.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [MaxLength(45)]
        public string Name { get; set; } = string.Empty;

        public int Credit { get; set; }

        // Eliminacion logica: false = "eliminado"
        public bool IsActive { get; set; } = true;

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
