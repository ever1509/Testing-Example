using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API1.Models;
using API1.Models.Contexts;
using Microsoft.AspNetCore.Routing.Tree;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace API1.Services
{
    public class StudentService :IStudentService
    {
        private readonly ApplicationDbContext _context;
        private readonly API2Service _client;

        public StudentService(ApplicationDbContext context, API2Service client)
        {
            _context = context;
            _client = client;
        }
        public async Task<int> CreateStudentAsync(Student entity)
        {
            var e = new Student()
            {
               Name = entity.Name,
               LastName = entity.LastName,
               Age = entity.Age,
               DateBirth = entity.DateBirth,
               Email = entity.Email,
               Phone = entity.Phone,
            };

            _context.Students.Add(entity);

            await _context.SaveChangesAsync();

            return e.StudentId;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return  await _context.Students
                .ToListAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _context.Students
                .SingleOrDefaultAsync(e => e.StudentId == id);
        }

        public async Task<bool> UpdateStudent(Student entity)
        {
            var e = await _context.Students.SingleOrDefaultAsync(c => c.StudentId == entity.StudentId);

            if (entity == null)
                throw new Exception($"{typeof(Student)} entity does'nt exist with the id {entity.StudentId}");

            e.Name = entity.Name;
            e.LastName = entity.LastName;
            e.Age = entity.Age;
            e.DateBirth = entity.DateBirth;
            e.Email = entity.Email;
            e.Phone = entity.Phone;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            var entity = await _context.Students.FindAsync(id);

            if (entity == null)
                throw new Exception($"{typeof(Student)} not found with the Id {id}");

            _context.Students.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }

        public async  Task<List<CourseResponse>> CoursesByStudent(int id)
        {
            return await _client.GetCoursesByStudent(id);
        }
    }
}
