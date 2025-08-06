using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FirstApiProj.Model
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name must be required !")]
        [RegularExpression(@"^[a-zA-Z]+$",ErrorMessage ="Name Only contain letters not any special characters and spaces!")]
        public string Name { get; set; } = string.Empty; 

        [Required]
        [StringLength(3,ErrorMessage = "Section Must be named as Morning or Evening also like MA - MB")]
        public string Section { get; set; } = string.Empty;

        [Required]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Range(0.00,4.00,ErrorMessage = "Gpa Must be between 0.00 - 4.00")]
        public float Gpa { get; set; }
    }
}
