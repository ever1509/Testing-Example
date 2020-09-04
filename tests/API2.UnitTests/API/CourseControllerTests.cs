using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using API2.Application.Courses.Commands.CreateCourse;
using API2.Application.Courses.Commands.DeleteCourse;
using API2.Application.Courses.Commands.UpdateCourse;
using API2.Application.Courses.Queries.GetCourses;
using API2.Controllers;
using API2.UnitTests.Base;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace API2.UnitTests.API
{
    public class CourseControllerTests :ControllerTestBase
    {
        [Fact]
        public async Task CreateCourseTest()
        {
            //Arrange
            var controller = new CoursesController(MediatorFake);

            //Act
            var result = await controller.Create(new CreateCourse()
            {
                Title = "Test title",
                Department = "Test Department",
                Location = "Test Location",
                InstructorId = 1,
                StudentId = 1
            });

            //Assert
            result.Should().NotBeNull();

            var r = (OkObjectResult)result;
            r.Should().NotBeNull();
            r.StatusCode.Should().Be(StatusCodes.Status200OK);
            r.Value.Should().BeEquivalentTo(1);

        }
        [Fact]
        public async Task UpdateCourseTest()
        {
            //Arrange
            var controller = new CoursesController(MediatorFake);

            //Act
            var result = await controller.Update(new UpdateCourse()
            {
                Title = "Test title",
                Department = "Test Department",
                Location = "Test Location",
                InstructorId = 1,
                StudentId = 1
            });

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<NoContentResult>();
        }
        [Fact]
        public async Task DeleteCourseTest()
        {
            //Arrange
            var controller = new CoursesController(MediatorFake);

            //Act
            var result = await controller.Delete(new DeleteCourse()
            {
                Id = 1
            });

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<NoContentResult>();

        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetFlashCardsTest(int id)
        {
            //Arrange
            var controller = new CoursesController(MediatorFake);

            //Act
            var result = await controller.GetCourses(id);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ActionResult<CoursesVm>>();

            var r = (OkObjectResult)result.Result;

            r.StatusCode.Should().Be(StatusCodes.Status200OK);
            r.Value.Should().BeEquivalentTo(GetCoursesFake());
        }

    }
}
