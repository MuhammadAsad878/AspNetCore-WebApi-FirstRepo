using FirstApiProj.Model;

namespace FirstApiProj.Repository.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllByAsync(int? id);
        Task<Student?> AddAsync(Student student);
        Task<Student?> UpdateAsync(Student student);
        bool Delete(int? id);
    }
}
