using System;
using Microsoft.AspNetCore.Mvc;
using zadanie2.Models;
using zadanie2.DAL;

namespace zadanie2.Controllers
{   
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
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

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            return Ok("Update complete");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            return Ok("Delete complete");
        }
        
    }
}
