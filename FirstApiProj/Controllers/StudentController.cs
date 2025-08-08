using FirstApiProj.Model;
using FirstApiProj.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FirstApiProj.DTO;

namespace FirstApiProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // Controller => Service => Repository => Database

        [HttpGet]
        public async Task<IActionResult> GetStudent(int? id)
        {
            var students = await _studentService.GetStudents(id);
            if (students == null || !students.Any()) return NotFound();
            var response = students.Select(student => new DtoStudentResponse
            {
                Name = student.Name,
                Section = student.Section,
                Gpa = student.Gpa,
                Address = student.Address,
            }).ToList();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> NewStudent([FromBody] DtoCreateStudent? student)
        {
            if (student == null) return BadRequest("Student is null!");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            Student newStudent = new()
            {
                Name = student.Name,
                Gpa = student.Gpa,
                Section = student.Section,
                Address = student.Address,
                CreatedAt = DateTime.UtcNow
            };
            Student? createdStudent = await _studentService.CreateStudent(newStudent);
            if (createdStudent == null) return StatusCode(500, "An Error Occured while creating the student!");
            var response = new DtoStudentResponse
            {
                Name = createdStudent.Name,
                Section = createdStudent.Section,
                Address = createdStudent.Address,
                Gpa = createdStudent.Gpa,

            };
            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] DtoStudentUpdate student)
        {
            if (student == null)
                return BadRequest("Invalid data: student is null");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Student stdToBeUpdated = new Student
            {
                Id = id,
                Name = student.Name,
                Section = student.Section,
                Address = student.Address,
                Gpa = (float)student.Gpa,
            };

            var updated = await _studentService.UpdateStudent(stdToBeUpdated);

            if (updated == null)
                return NotFound("Student Not Found");

            var response = new DtoStudentResponse
            {
                Name = updated.Name,
                Section = updated.Section,
                Address = updated.Address,
                Gpa = updated.Gpa,
            };

            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id <= 0) return BadRequest("Please provide ID");
            var isDeleted = await _studentService.Delete(id);
            if (!isDeleted) return NotFound("Student Not Found");
            return Ok("Deleted Successfully");
        }

    }
}
