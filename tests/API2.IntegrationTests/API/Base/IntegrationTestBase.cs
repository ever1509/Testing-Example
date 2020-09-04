using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using API2.Application.Common.Models;
using API2.Application.Common.Models.Requests;
using API2.Application.Common.Models.Responses;
using API2.Application.Courses.Commands.CreateCourse;
using Newtonsoft.Json;
using Xunit;

namespace API2.IntegrationTests.API.Base
{
    public class IntegrationTestBase : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        protected readonly HttpClient TestClient;
        public IntegrationTestBase()
        {
            var factory = new CustomWebApplicationFactory<Startup>();
            TestClient = factory.CreateClient();
        }

        protected async Task AuthenticateAsync()
        {
            TestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await GetJwtAsync());
        }

        protected async Task<int> CreateCourseAsync(CreateCourse createCourse)
        {

            var response = await TestClient.PostAsync("api/courses/create", new StringContent(
                JsonConvert.SerializeObject(createCourse), Encoding.UTF8, "application/json"
            ));
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<int>(result);
        }
        private async Task<string> GetJwtAsync()
        {
            var response = await TestClient.PostAsync("api/identity/register", new StringContent(
                JsonConvert.SerializeObject(new UserRegistrationRequest()
                    {
                        Email = "orelle01@test.com",
                        Password = "Orelle01234!"
                    }), Encoding.UTF8, "application/json"
            ));

            var registrationResponse = await response.Content.ReadAsStringAsync();

            var value = JsonConvert.DeserializeObject<AuthenticationResult>(registrationResponse).Token;

           return value;
        }
    }
}
