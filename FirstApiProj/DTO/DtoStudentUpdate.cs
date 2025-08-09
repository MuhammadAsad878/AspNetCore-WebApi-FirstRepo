using System.ComponentModel.DataAnnotations;

namespace FirstApiProj.DTO
{
    public class DtoStudentUpdate
    {
        public string? Name { get; set; } = string.Empty;   
        public string? Section { get; set; } = string.Empty;
        public string? Address { get; set; } = string.Empty;
        public float? Gpa { get; set; }       
    }
}
