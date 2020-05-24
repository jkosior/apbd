using System;
using Microsoft.AspNetCore.Mvc;
using zadanie2.Models;
using zadanie2.DAL;
using zadanie2.Dtos;


namespace zadanie2.Controllers
{   
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;
        private readonly StudentsContext _context;

        public StudentsController(IDbService dbService, StudentContext context)
        {
            _dbService = dbService;
            _context = context
        }


        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            return Ok(_dbService.GetStudents());
        }

        [HttpGet("{index}")]
        public IActionResult GetOneStudent(string index)
        {
            var student = _dbService.GetStudent(index);
            if (student != null)
            {
                return Ok(student);
            }
            return NotFound("Student not found");
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }

        [HttpPut]
        public IActionResult UpdateStudent([FromBody] StudentDto studentDto)
        {
            var student = _context.Students.SingleOrDefault(s => s.IndexNumber == studentDto.IndexNumber);
            if (student == null) return BadRequest("Nie znaleziono studneta");

            student.BirthDate = studentDto.BirthDate;
            student.IdEnrollment = _context
                .Enrollments
                .Where(e => e.Study.Name == studentDto.StudyName && e.Semester == studentDto.Semester)
                .Select(e => e.IdEnrollment)
                .Single();
            student.FirstName = studentDto.FirstName;
            student.LastName = studentDto.LastName;

            _context.SaveChanges();

            return Ok(student);
        }

        [HttpDelete("{indexNumber}")]
        public IActionResult DeleteStudent(string indexNumber)
        {
            var student = _context.Students.SingleOrDefault(s => s.IndexNumber == indexNumber);
            if (student == null) return BadRequest("Nie znaleziono studenta");

            _context.Students.Remove(student);

            _context.SaveChanges();

            return Ok("Usuwanie ukończone");
        }

    }
}
