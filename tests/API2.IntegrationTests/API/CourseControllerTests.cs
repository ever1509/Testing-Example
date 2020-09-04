using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using API2.Application.Courses.Commands.CreateCourse;
using API2.Application.Courses.Queries.GetCourses;
using API2.IntegrationTests.API.Base;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace API2.IntegrationTests.API
{
    [ExcludeFromCodeCoverage]
    public class CourseControllerTests:IntegrationTestBase
    {
        [Fact]
        public async Task GetCoursesTest()
        {
            //Arrange
            int id = 1;
            await AuthenticateAsync();

            //Act
            var response = await TestClient.GetAsync($"api/courses/{id}");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadAsStringAsync();
            var r = JsonConvert.DeserializeObject<CoursesVm>(result);

            r.Should().BeOfType<CoursesVm>();
            r.Courses.Should().HaveCountLessOrEqualTo(5);

        }

        [Fact]
        public async Task CreateCourseInDatabaseTest()
        {
            //Arrange
            int StudentId = 1;
            await AuthenticateAsync();
            var newCourse = new CreateCourse()
            {
                Title = "Test6 title",
                Location = "Test6 location",
                Department = "Test6 department",
                StudentId = StudentId,
                InstructorId = 1
            };
            //Act
            var studentId = await CreateCourseAsync(newCourse);

            studentId.Should().BeGreaterThan(0);
            studentId.Should().Be(6);

            var response = await TestClient.GetAsync($"api/courses/{StudentId}");

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var result = await response.Content.ReadAsStringAsync();
            var r = JsonConvert.DeserializeObject<CoursesVm>(result);

            r.Should().BeOfType<CoursesVm>();
            r.Courses.Should().HaveCountLessOrEqualTo(6);
            r.Courses.Last().Title.Should().Be("Test6 title");
        }
    }
}
