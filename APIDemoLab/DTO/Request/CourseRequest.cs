using System.ComponentModel.DataAnnotations;

namespace APIDemoLab.DTO.Request
{
    public class CourseRequest
    {
        [Required]
        [MaxLength(45)]
        public string Name { get; set; } = string.Empty;

        public int Credit { get; set; }
    }
}
