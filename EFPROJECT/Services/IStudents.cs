using EFPROJECT.Entity;

namespace EFPROJECT.Services
{
    public interface IStudents
    {
        public List<StudentsDTOall> GetallStudents();

        public List<StudentsDTOall> GetallStudentsByPage(int Pgn , int Pgsize);
        public StudentsDTOall Getstudent(int id);
        public List<StudentsDTOalll> SearchByStudentName(string studentName);
        public List<StudentsDTOalll> FindStudentByCourseID(int courseID);
        public void AddStudent(StudentDTO student);
        public void UpdateStudent(int id , StudentsupdateDto student);
        public void Delete(int id);

    }
}
