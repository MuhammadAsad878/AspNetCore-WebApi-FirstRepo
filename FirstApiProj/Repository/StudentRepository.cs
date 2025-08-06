using FirstApiProj.Data;
using FirstApiProj.Model;
using FirstApiProj.Repository.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

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
            if (id == null) return await _context.Students.ToListAsync();
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
            _context.Students.Update(student);
            var res = await _context.SaveChangesAsync();
            if (res > 0) return student;
            return null;
        }

        public bool Delete(int? id)
        {
            if (id == null) return false;
            var student = _context.Students.Find(id);
            if (student == null) return false;
            _context.Students.Remove(student);
            var res = _context.SaveChanges();
            return res > 0;
        }
    }

}
