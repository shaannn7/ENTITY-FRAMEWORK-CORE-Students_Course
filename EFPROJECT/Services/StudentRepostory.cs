using AutoMapper;
using EFPROJECT.Data;
using EFPROJECT.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFPROJECT.Services
{
    public class StudentRepostory : IStudents
    {
        private readonly DbContextClass _dbcontextclass;
        private readonly IMapper _mapper;
        public StudentRepostory(DbContextClass dbcontextclass , IMapper mapper)
        {
            _dbcontextclass = dbcontextclass;
            _mapper = mapper;
        }

        public List<StudentsDTOall> GetallStudents()
        {
            try
            {
                var data = _dbcontextclass.Students.ToList();
                //var all = data.Select(o => new StudentsDTOall
                //{
                //    Id = o.Id,
                //    Name = o.Name,
                //    Age = o.Age,
                //    Dob = o.Dob,
                //    Email = o.Email,
                //    Phone = o.Phone,
                //    CourseID = o.CourseID,
                //}).ToList();
                return  _mapper.Map<List<StudentsDTOall>>(data); 
            }catch(Exception ex) 
            {
                throw new Exception("An error occurred while retrieving all students information.", ex);
            }           
        }

        public List<StudentsDTOall> GetallStudentsByPage(int Pgn=1, int Pgsize=4)
        {
           var data = _dbcontextclass.Students.Skip((Pgn - 1) * (Pgsize)).Take(Pgsize).ToList();
           var all = data.Select(o => new StudentsDTOall
           {
                 Id = o.Id,
                 Name = o.Name,
                 Age = o.Age,
                 Dob = o.Dob,
                 Email = o.Email,
                 Phone = o.Phone,
                 CourseID = o.CourseID,
           }).ToList();
           return all;      
        }

        public StudentsDTOall Getstudent(int id)
        {
            var data = _dbcontextclass.Students.FirstOrDefault(o => o.Id == id);
            if (data == null)
            {
                return null;  
            }
            return new StudentsDTOall
            {
                Id = data.Id,
                Name = data.Name,
                Age = data.Age,
                Dob = data.Dob,
                Email = data.Email,
                Phone = data.Phone,
                CourseID = data.CourseID,
            };

        }

        public List<StudentsDTOalll> SearchByStudentName(string studentName)
        {
           
           var data = _dbcontextclass.Students.Include(x=>x.Course).Where(x => x.Name.StartsWith(studentName)).ToList();

           var all = data.Select(x => new StudentsDTOalll()
           {
                  Id = x.Id,
                  Name = x.Name,
                  Age = x.Age,
                  Dob = x.Dob,
                  Email = x.Email,
                  Phone = x.Phone,
                  CourseID = x.CourseID,
                  Mentor=x.Course.Mentor
           }).ToList();
           return all;            
        }

        public List<StudentsDTOalll> FindStudentByCourseID(int courseID)
        {
            var data = _dbcontextclass.Students.Include(e => e.Course).Where(x => x.CourseID == courseID).ToList();
            if (data == null)
            {
                return null;
            }
            var val = data.Select(t => new StudentsDTOalll()
            {
                Id = t.Id,
                Name = t.Name,
                Age = t.Age,
                Dob = t.Dob,
                Email = t.Email,
                Phone = t.Phone,
                CourseID = t.CourseID,
                Mentor = t.Course.Mentor,
            }).ToList();
            return val;
        }

        public void AddStudent(StudentDTO student)
        {
            try
            {
                var Data = _mapper.Map<Students>(student);
                if(Data != null)
                {
                    _dbcontextclass.Students.Add(Data);
                    _dbcontextclass.SaveChanges();
                }
                else
                {
                    throw new Exception("Failed to add student data.");
                }
            }catch (Exception e)
            {
                throw new Exception("An error occurred while Adding new student.", e);
            } 
        }

        public void UpdateStudent(int id , StudentsupdateDto student)
        {
            try
            {
                var data = _dbcontextclass.Students.FirstOrDefault(o => o.Id == id);
                if(data != null)
                {
                    data.Name = student.Name;
                    data.Age = student.Age;
                    data.Dob = student.Dob;
                    data.Email = student.Email;
                    data.Password = student.Password;
                    data.Phone = student.Phone;
                    data.CourseID = student.CourseID;
                    _dbcontextclass.SaveChanges();
                }
                else
                {
                    throw new Exception($"Student with ID {id} not found.");
                }
            }catch(Exception e) 
            {
                throw new Exception("An error occurred while Updating student.", e);
            }
            
            
        }

        public void Delete(int id)
        {
             var data = _dbcontextclass.Students.FirstOrDefault(i => i.Id == id);
               _dbcontextclass.Students.Remove(data);
               _dbcontextclass.SaveChanges();
        }
    }
}
