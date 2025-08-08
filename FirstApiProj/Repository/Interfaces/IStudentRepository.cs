using FirstApiProj.Model;
using FirstApiProj.DTO;

namespace FirstApiProj.Repository.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllByAsync(int? id);
        Task<Student?> AddAsync(Student student);
        Task<Student?> UpdateAsync(Student student);
        Task<bool> DeleteAsync(int? id);
    }
}
