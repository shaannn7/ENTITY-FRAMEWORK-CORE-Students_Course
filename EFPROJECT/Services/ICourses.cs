using EFPROJECT.Entity;

namespace EFPROJECT.Services
{
    public interface ICourses
    {
        public List<CourseAll> GetAll();
        public CourseAll GetById(int id);
        public void AddCourse(CourseDTO course);
        public void UpdateCourse(int id , CourseAll course);
        public void DeleteCourse(int id);

    }
}
