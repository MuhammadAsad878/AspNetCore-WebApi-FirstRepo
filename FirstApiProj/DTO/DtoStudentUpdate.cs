using System.ComponentModel.DataAnnotations;

namespace FirstApiProj.DTO
{
    public class DtoStudentUpdate
    {

        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces!")]
        public string? Name { get; set; } = string.Empty;

        [StringLength(2, MinimumLength = 0, ErrorMessage = "Section Must be named as Morning or Evening also like MA - MB")]        
        public string? Section { get; set; } = string.Empty;

        public string? Address { get; set; } = string.Empty;

        [Range(0.00, 4.00, ErrorMessage = "Gpa Must be between 0.00 - 4.00")]
        public float? Gpa { get; set; }
    }
}
