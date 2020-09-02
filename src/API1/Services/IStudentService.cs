using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API1.Models;

namespace API1.Services
{
    public interface IStudentService
    {
        Task<int> CreateStudentAsync(Student entity);
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int id);
        Task<bool> UpdateStudent(Student entity);
        Task<bool> DeleteStudent(int id);
        Task<List<CourseResponse>> CoursesByStudent(int id);

    }
}
