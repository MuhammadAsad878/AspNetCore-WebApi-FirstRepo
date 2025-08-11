using FirstApiProj.Model;

namespace FirstApiProj.DTO
{
    public class DtoStudentResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Section { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public float  Gpa { get; set; }

        public DtoStudentResponse() { }

        public DtoStudentResponse(Student student)
        {
            Name = student.Name;
            Section = student.Section;
            Address = student.Address;
            Gpa = student.Gpa;
        }

    }
}
