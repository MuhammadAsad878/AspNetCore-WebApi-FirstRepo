using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace FirstApiProj.Model
{
    public class Student
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty; 
        public string Section { get; set; } = string.Empty;        
        public string Address { get; set; } = string.Empty;        
        public float Gpa { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? InActive { get; set; } = null;
    }
}
