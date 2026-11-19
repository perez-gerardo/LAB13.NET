using System.ComponentModel.DataAnnotations;

namespace APIDemoLab.DTO.Request
{
    public class GradeRequest
    {
        [Required]
        [MaxLength(45)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(45)]
        public string? Description { get; set; }
    }
}
