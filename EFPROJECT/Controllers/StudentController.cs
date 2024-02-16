using EFPROJECT.Entity;
using EFPROJECT.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace EFPROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudents _student;
        public StudentController(IStudents student)
        {
            _student = student;
        }
        [HttpGet("All")]
        public IActionResult Get()
        {
            return Ok(_student.GetallStudents());

        }

        [HttpGet("ByPage")]
        public IActionResult GetBypage(int Pgn, int Pgsize)
        {
            var data = _student.GetallStudentsByPage(Pgn, Pgsize);
            if (data.Count > 0)
            {
                return Ok(_student.GetallStudentsByPage(Pgn, Pgsize));
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpGet("GetByID{id}")]
        public IActionResult GetById(int id)
        {
            var data = _student.Getstudent(id);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }

        }

        [HttpGet("Search")]
        public IActionResult GetByName(string name)
        {
            var data = _student.SearchByStudentName(name);
            if (data.Count > 0)
            {
                return Ok(data);
            }
            else
            {
                return NotFound("Not Found");
            }
        }
        [HttpGet("Search By CourseID")]
        public IActionResult GetByCourseid(int courseid)
        {
            var data = _student.FindStudentByCourseID(courseid);
            if (data.Count > 0)
            {
                return Ok(_student.FindStudentByCourseID(courseid));
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPost("Add Students")]
        public IActionResult Post([FromBody] StudentDTO student)
        {
            _student.AddStudent(student);
            return Ok("Student Details Added Succefully");
        }
        [HttpPut("Update Students")]
        public IActionResult Put(int id, [FromBody] StudentsupdateDto student)
        {
            _student.UpdateStudent(id, student);
            return Ok("Updated Successfully");
        }
        [HttpDelete("Delete Students")]
        public IActionResult Delete(int id)
        {
            var check = _student.Getstudent(id);
            if (check == null)
            {
                return NotFound("Student id is not found");
            
            }
            else
            {
                _student.Delete(id);
                return Ok("Student data deleted successfully");
            }
        }
    }
}
