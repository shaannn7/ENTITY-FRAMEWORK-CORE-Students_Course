using EFPROJECT.Entity;
using EFPROJECT.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFPROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourses _Courses;
        public CourseController(ICourses courses)
        {
            _Courses = courses;
        }
        [HttpGet("ALL")]
        public IActionResult GetAll() 
        {
            return Ok(_Courses.GetAll());
        }
        [HttpGet("GetByID{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_Courses.GetById(id));
        }

        [HttpPost]
        public IActionResult AddCourse(CourseDTO course)
        {
            _Courses.AddCourse(course);
            return Ok("Course Added Succefully");
        }

        [HttpPut]
        public IActionResult UpdateCourse(int id ,CourseAll course)
        {
            _Courses.UpdateCourse(id, course);
            return Ok("Updated Succefully");
        }

        [HttpDelete]
        public IActionResult DeleteCourse(int id)
        {
            _Courses.DeleteCourse(id);
            return Ok("Deleted Succefully");
        }
    }
}
