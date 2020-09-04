using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using API1.Controllers;
using API1.Models;
using API1.Unitests.Base;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
namespace API1.Unitests.Controllers
{
    [ExcludeFromCodeCoverage]
    public class StudentControllerTests:ControllerTestBase
    {

        [Test]
        public async Task GetAllTest()
        {
            //Arrange
            var controller = new StudentsController(StudentServiceMock.Object);

            //Act
            var result = await controller.GetAll();

            //Assert
            result.Should().NotBeNull();

            var r = (OkObjectResult) result;
            r.StatusCode.Should().Be(StatusCodes.Status200OK);
            r.Value.Should().BeEquivalentTo(GetStudentsMocks());

        }
        [Test]
        public async Task CreateStudentTest()
        {
            //Arrange
            var controller = new StudentsController(StudentServiceMock.Object);

            //Act
            var result = await controller.Create(new Student()
            {
                Name = "Test",
                Age = 20,
                Phone = "22222222",
                LastName = "Test LastName",
                DateBirth = DateTime.UtcNow,
                Email = "test@test.com",
                StudentId = 1
            });

            //Assert
            var r = (OkObjectResult)result;
            r.Should().NotBeNull();
            r.StatusCode.Should().Be(StatusCodes.Status200OK);
            r.Value.Should().BeEquivalentTo(new {StudentId=3});

        }
        [Test]
        public async Task UpdateStudentTest()
        {
            //Arrange
            var controller = new StudentsController(StudentServiceMock.Object);

            //Act
            var result = await controller.Update(new Student()
            {
                Name = "Test",
                Age = 20,
                Phone = "22222222",
                LastName = "Test LastName",
                DateBirth = DateTime.UtcNow,
                Email = "test@test.com",
                StudentId = 1
            });

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<NoContentResult>();

        }
        [Test]
        public async Task DeleteStudentTest()
        {
            //Arrange
            var controller = new StudentsController(StudentServiceMock.Object);

            //Act
            var result = await controller.Delete(1);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<NoContentResult>();

        }
    }
}