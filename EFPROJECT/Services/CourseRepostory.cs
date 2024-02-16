using AutoMapper;
using EFPROJECT.Data;
using EFPROJECT.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFPROJECT.Services
{
    public class CourseRepostory:ICourses
    {
        private readonly DbContextClass _DbContext;
        private readonly IMapper _mapper;
        public CourseRepostory(DbContextClass contextClass,IMapper mapper)
        {
            _DbContext = contextClass;
            _mapper = mapper;
        }

        public List<CourseAll> GetAll()
        {
            var find =_DbContext.Courses.ToList();
            var all = find.Select(i => new CourseAll
            {
                CourseId = i.CourseId,
              CourseName = i.CourseName,
              Mentor =i.Mentor,
            }).ToList();
            return all;
        }

        public CourseAll GetById(int id)
        {
            var data = _DbContext.Courses.FirstOrDefault(i=>i.CourseId == id);
            return new CourseAll
            {
                CourseId= data.CourseId,
                CourseName= data.CourseName,
                Mentor=data.Mentor,
            };
        }
        public void AddCourse(CourseDTO course)
        {
            var data = _mapper.Map<Course>(course);
            _DbContext.Courses.Add(data);
            _DbContext.SaveChanges();
        }

        public void UpdateCourse(int id, CourseAll course)
        {
            var data = _DbContext.Courses.FirstOrDefault(i => i.CourseId == id);
            data.CourseName = course.CourseName;
            data.Mentor = course.Mentor;
            _DbContext.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            var data = _DbContext.Courses.FirstOrDefault(i=>i.CourseId == id);
            _DbContext.Courses.Remove(data);
            _DbContext.SaveChanges();
        }

    }
}
