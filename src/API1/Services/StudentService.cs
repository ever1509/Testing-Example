using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API1.Models;

namespace API1.Services
{
    public class StudentService :IStudentService
    {
        public Task<int> CreateStudentAsync(Student entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudentById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStudent(Student entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
