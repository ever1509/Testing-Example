using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API1.Models;
using API1.Services;
using FluentAssertions;
using Moq;

namespace API1.Unitests.Base
{
    [ExcludeFromCodeCoverage]
    public class ControllerTestBase
    {
        public readonly Mock<IStudentService> StudentServiceMock;
        public ControllerTestBase()
        {
           StudentServiceMock = new Mock<IStudentService>();
           InitStudentServiceMock();
        }

        private void InitStudentServiceMock()
        {
            StudentServiceMock.Setup(s => s.GetAllStudents())
                .ReturnsAsync(GetStudentsMocks());
            StudentServiceMock.Setup(s => s.GetStudentById(It.Is<int>(arg => WithIntGreaterThanZero(arg))))
                .ReturnsAsync(GetStudentsMocks().FirstOrDefault(s => s.StudentId > 0));
            StudentServiceMock.Setup(s => s.CreateStudentAsync(It.IsAny<Student>()))
                .ReturnsAsync(GetStudentsMocks().Last().StudentId);
            StudentServiceMock.Setup(s => s.DeleteStudent(It.IsAny<int>())).ReturnsAsync(true);
            StudentServiceMock.Setup(s => s.UpdateStudent(It.IsAny<Student>())).ReturnsAsync(true);

            StudentServiceMock.Setup(s => s.CoursesByStudent(It.IsAny<int>())).ReturnsAsync(GetCoursesMock());
        }

        private List<CourseResponse> GetCoursesMock()
        {
            return new List<CourseResponse>()
            {
                new CourseResponse(){CourseId = 1,Title = "Test1",Department ="Test1",Instructor = "Test1",Location = "Test1"},
                new CourseResponse(){CourseId = 2,Title = "Test2",Instructor = "Test2",Location = "Test2",Department = "Test2"}
            };
        }

        private bool WithIntGreaterThanZero(int obj)
        {
            obj.Should().NotBe(0);
            obj.Should().BeGreaterThan(0);
            return true;
        }

        public List<Student> GetStudentsMocks()
        {
            return new List<Student>()
            {
                new Student()
                {
                    StudentId = 1,
                    Name = "Test1",
                    LastName = "LastName Test1",
                    Age = 20,
                    Phone = "78258754",
                    Email = "testing1@test.com",
                },
                new Student()
                {
                    StudentId = 2,
                    Name = "Test2",
                    LastName = "LastName Test2",
                    Age = 22,
                    Phone = "78258754",
                    Email = "testing2@test.com",
                },
                new Student()
                {
                    StudentId = 3,
                    Name = "Test3",
                    LastName = "LastName Test3",
                    Age = 23,
                    Phone = "78258754",
                    Email = "testing3@test.com",
                },
            };
        }

    }
}
