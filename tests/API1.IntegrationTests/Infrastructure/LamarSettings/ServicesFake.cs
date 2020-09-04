using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using API1.IntegrationTests.Mocks;
using API1.Models.Contexts;
using API1.Services;
using FakeItEasy;
using Lamar;

namespace API1.IntegrationTests.Infrastructure.LamarSettings
{
    public class ServicesFake :ServiceRegistry
    {
        private FakeHttpMessageHandler _fakeHttpMessageHandler = A.Fake<FakeHttpMessageHandler>(op => op.CallsBaseMethods());
        public ServicesFake()
        {
            For<IAPI2Service>()
                .Use<API2Service>()
                .Ctor<HttpClient>()
                .Is(GetApi2ServiceFake());

            For<IStudentService>()
                .Use<MockStudentService>()
                .Named("MockStudentService");
        }

        private HttpClient GetApi2ServiceFake()
        {
            A.CallTo(() => _fakeHttpMessageHandler.Send(A<HttpRequestMessage>._)).Returns(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("[\r\n  {\r\n    \"CourseId\": 1,\r\n    \"Title\": \"Test\",\r\n    \"Instructor\": \"Test\",\r\n    \"Location\": \"Test\",\r\n    \"Department\": \"Test\"\r\n  },\r\n  {\r\n    \"CourseId\": 2,\r\n    \"Title\": \"Test\",\r\n    \"Instructor\": \"Test\",\r\n    \"Location\": \"Test\",\r\n    \"Department\": \"Test\"\r\n  },\r\n  {\r\n    \"CourseId\": 3,\r\n    \"Title\": \"Test\",\r\n    \"Instructor\": \"Test\",\r\n    \"Location\": \"Test\",\r\n    \"Department\": \"Test\"\r\n  }\r\n]")
            });
            var Api2ServiceFake = new HttpClient(_fakeHttpMessageHandler)
            {
                BaseAddress = new Uri("http://localhost/api2clientfake/")
            };
            Api2ServiceFake.DefaultRequestHeaders.Accept.Clear();
            Api2ServiceFake.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            return Api2ServiceFake;
        }
    }
}
