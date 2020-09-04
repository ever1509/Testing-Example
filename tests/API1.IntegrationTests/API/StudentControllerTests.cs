using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API1.Controllers;
using API1.Models;
using API1.Models.Contexts;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace API1.IntegrationTests.API
{
    public class StudentControllerTests: TestBase
    {
        private ApplicationDbContext _dbContext;
        private StudentsController _controller;

        [Fact]
        public async Task GetAllStudentTest()
        {
            //Arrange
            _controller = Container.GetInstance<StudentsController>("StudentControllerFake");

            //Act
            var result = await _controller.GetAll();

            //Assert
            result.Should().NotBeNull();
            var r = (OkObjectResult) result;
            r.Value.Should().BeOfType<List<Student>>();
        }

        [Fact]
        public async Task GetStudentByIdTest()
        {
            //Arrange
            _controller = Container.GetInstance<StudentsController>("StudentControllerFake");

            //Act
            var result = await _controller.Get(1);

            //Assert
            result.Should().NotBeNull();
            var r = (OkObjectResult) result;

            r.Value.Should().BeOfType<Student>();
        }

        [Fact]
        public async Task CreateStudentThenVerifiedCreated()
        {
            //Arrange
            _controller = Container.GetInstance<StudentsController>("StudentControllerFake");
            var student= new Student()
            {
                Name = "Testing Creation Name",
                LastName = "Testing Creation LastName",
                Age = 20,
                Email = "testingcreation@test.com",
                Phone = "22222222",
                DateBirth = DateTime.UtcNow
            };
            //Act
            var result = await _controller.Create(student);

            //Assert
            _dbContext = Container.GetInstance<ApplicationDbContext>("DatabaseFake");
            var students = _dbContext.Students.ToList();
            students.Should().HaveCountLessOrEqualTo(3);
            students.Last().Name.Should().Be(student.Name);
            students.Last().LastName.Should().Be(student.LastName);
        }

    }
}
