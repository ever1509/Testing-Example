
using System;
using System.Collections.Generic;
using API2.Domain.Entities;
using API2.Domain.Enums;
using API2.Infrastructure.Persistance;

namespace API2.IntegrationTests.API.Base
{
    public static class Utilities
    {
        public static void InitSeedDataFromTestDb(ApplicationDbContext dbContext)
        {
            dbContext.Students.AddRange(new List<Student>()
            {
                new Student(){StudentId = 1, Name = "Test Name", LastName = "Test LastName",Age = 20,Phone = "22222222",Email = "test@test.com",DateOfBirth = DateTime.UtcNow}
            });

            dbContext.Instructors.AddRange(new List<Instructor>()
            {
                new Instructor(){InstructorId = 1,Name = "Test Name",LastName = "Test LastName", Nivel = Nivel.SemiSenior},
                new Instructor(){InstructorId = 2,Name = "Test2 Name",LastName = "Test2 LastName", Nivel = Nivel.Junior},
                new Instructor(){InstructorId = 3,Name = "Test3 Name",LastName = "Test3 LastName", Nivel = Nivel.Senior},

            });

            dbContext.Courses.AddRange(new List<Course>()
            {
                new Course(){CourseId=1,Title = "Test1",Location = "Test1",Department = "Test1",StudentId = 1,InstructorId = 1},
                new Course(){CourseId=2,Title = "Test2",Location = "Test2",Department = "Test2",StudentId = 1,InstructorId = 1},
                new Course(){CourseId=3,Title = "Test3",Location = "Test3",Department = "Test3",StudentId = 1,InstructorId = 2},
                new Course(){CourseId=4,Title = "Test4",Location = "Test4",Department = "Test4",StudentId = 1,InstructorId = 2},
                new Course(){CourseId=5,Title = "Test5",Location = "Test5",Department = "Test5",StudentId = 1,InstructorId = 3},
            });

            dbContext.SaveChanges();
        }
    }
}
