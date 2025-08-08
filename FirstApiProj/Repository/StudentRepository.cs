using FirstApiProj.Data;
using FirstApiProj.Model;
using FirstApiProj.DTO;
using FirstApiProj.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FirstApiProj.Repository
{
    public class StudentRepository : IStudentRepository
    {

        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Return Single Student in List or List of All students based on Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Student>> GetAllByAsync(int? id)
        {
            if (id == null)
            {
                return await _context.Students.ToListAsync();
            }
            var student = await _context.Students.FindAsync(id);
            List<Student> students = new List<Student>();
            if (student != null) students.Add(student);
            return students;
        }

        public async Task<Student?> AddAsync(Student student)
        {
            _context.Students.Add(student);
            int result = await _context.SaveChangesAsync();
            if (result > 0) return student;
            return null;
        }

        public async Task<Student?> UpdateAsync(Student student)
        {
            var studentExists = await _context.Students.FindAsync(student.Id);
            if(studentExists == null) return null;
            studentExists.Name = student.Name;
            studentExists.Address = student.Address;
            studentExists.Section = student.Section;
            studentExists.Gpa = student.Gpa;
            //_context.Students.Update(student);
            var res = await _context.SaveChangesAsync();
            if (res > 0) return student;
            return null;
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            if (id == null) return false;
            var student = await _context.Students.FindAsync(id);
            if (student == null) return false;
            _context.Students.Remove(student);
            var res = await _context.SaveChangesAsync();
            return res > 0;
        }
    }

}
