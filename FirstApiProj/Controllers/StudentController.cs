using FirstApiProj.Model;
using FirstApiProj.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FirstApiProj.DTO;
using FluentValidation.Validators;
using FluentValidation;

namespace FirstApiProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IValidator<DtoCreateStudent> _createStudentValidator;
        private readonly IValidator<DtoStudentUpdate> _updateStudentValidator;

        public StudentController(IStudentService studentService, IValidator<DtoCreateStudent> createStudentValidator, IValidator<DtoStudentUpdate> updateStudentValidator)
        {
            _studentService = studentService;
            _createStudentValidator = createStudentValidator;
            _updateStudentValidator = updateStudentValidator;
        }
        // Controller => Service => Repository => Database

        [HttpPost("register")]
        public IActionResult Register( DtoRegister? user)
        {
            if (user == null) return BadRequest("Student is null!");           

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudent(int? id)
        {
            var students = await _studentService.GetStudents(id);
            if (students == null || !students.Any()) return NotFound();
            var response = students.Select(student => new DtoStudentResponse(student)).ToList();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> NewStudent([FromBody] DtoCreateStudent? student)
        {            
            if (student == null) return BadRequest("Student is null!");
            var validationResult = await _createStudentValidator.ValidateAsync(student);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
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
            var response = new DtoStudentResponse(createdStudent);
           
            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] DtoStudentUpdate? student)
        {
            if(student == null) return BadRequest("Student is null!");
            var validationResult = await _updateStudentValidator.ValidateAsync(student);
            if(validationResult.IsValid == false)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            Student stdToBeUpdated = new Student
            {
                Id = id,
                Name = student.Name,
                Section = student.Section,
                Address = student.Address,
                Gpa = (float)student.Gpa,
            };

            var updatedStudent = await _studentService.UpdateStudent(stdToBeUpdated);
            if (updatedStudent == null)  return NotFound("Student Not Found");
            var response = new DtoStudentResponse(updatedStudent);
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
