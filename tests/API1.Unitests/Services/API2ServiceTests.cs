using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using API1.Models;
using API1.Services;
using API1.Unitests.Base.Mocks;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace API1.Unitests.Services
{
    [ExcludeFromCodeCoverage]
    public class API2ServiceTests
    {
        private Mock<MockHttpMessageHandler> _mockHttpMessageHandler;
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            _mockHttpMessageHandler = new Mock<MockHttpMessageHandler>(){CallBase = true};
            _mockHttpMessageHandler.Setup(f => f.Send(It.IsAny<HttpRequestMessage>())).Returns(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("[\r\n  {\r\n    \"CourseId\": 1,\r\n    \"Title\": \"Test\",\r\n    \"Instructor\": \"Test\",\r\n    \"Location\": \"Test\",\r\n    \"Department\": \"Test\"\r\n  },\r\n  {\r\n    \"CourseId\": 2,\r\n    \"Title\": \"Test\",\r\n    \"Instructor\": \"Test\",\r\n    \"Location\": \"Test\",\r\n    \"Department\": \"Test\"\r\n  },\r\n  {\r\n    \"CourseId\": 3,\r\n    \"Title\": \"Test\",\r\n    \"Instructor\": \"Test\",\r\n    \"Location\": \"Test\",\r\n    \"Department\": \"Test\"\r\n  }\r\n]")
            });

            _httpClient = new HttpClient(_mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("http://locahost/test")
            };
        }

        [Test]
        public async Task GetCoursesByStudentTest()
        {
            //Arrange
            Setup();
            var api2ServiceTest= new API2Service(_httpClient);

            //Act
            var result = await api2ServiceTest.GetCoursesByStudent(1);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<List<CourseResponse>>();
        }
    }
}
