using FirstApiProj.Model;
using FirstApiProj.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            var resonse = await _studentService.GetStudents(id);
            if (resonse.Count == 0) return NotFound();
            return Ok(resonse);
        }

        [HttpPost]
        public async Task<IActionResult> NewStudent([FromBody] Student? student)
        {
            if (!ModelState.IsValid) return BadRequest("Validation Error");
            if (student == null)
            {
                return BadRequest("Student is null.");
            }
            student.Id = 0;
            var response = await _studentService.CreateStudent(student);
            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int? id, [FromBody] Student student)
        {
            if (id == null) return BadRequest("Id is null");
            var ExistingStudent = await _studentService.GetStudents(id);
            if (ExistingStudent == null || ExistingStudent.Count == 0) return NotFound("Student Not Found");
            var updated = await _studentService.UpdateStudent(student);
            if (updated == null) return BadRequest("Not Update");
            return Ok(updated);
        }

    }
}
