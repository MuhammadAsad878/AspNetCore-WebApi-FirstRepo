using FirstApiProj.Model;
namespace FirstApiProj.Service.Interfaces
{
    public interface IStudentService
    {
       Task<List<Student>> GetStudents(int? id);
       Task<Student?> CreateStudent(Student student);
       Task<Student?> UpdateStudent(Student student);
       Task<bool> Delete(int? id);
    }
}
