using FirstApiProj.Model;
using FirstApiProj.Service.Interfaces;
using FirstApiProj.Repository.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FirstApiProj.Service
{
    public class StudentService : IStudentService
    {
        // Service get data from repository , and repositry get data from database
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
     

        public async Task<List<Student>> GetStudents(int? id)
        {
            return await _studentRepository.GetAllByAsync(id);
        }

        /// <summary>
        /// Asynchronously creates a new student record in the repository.
        /// </summary>
        /// <param name="student">The <see cref="Student"/> object containing the details of the student to create. Cannot be null.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created <see
        /// cref="Student"/> object,  or <see langword="null"/> if the creation was unsuccessful.</returns>
        public async Task<Student?> CreateStudent(Student student)
        {
            
            return await _studentRepository.AddAsync(student);
        }

        public async Task<Student?> UpdateStudent(Student student)
        {
            return await _studentRepository.UpdateAsync(student);
        }
    }
}
