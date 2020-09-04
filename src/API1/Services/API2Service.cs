using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API1.Models;
using Newtonsoft.Json;

namespace API1.Services
{
    public class API2Service:IAPI2Service
    {
        private readonly HttpClient _client;

        public API2Service(HttpClient client)
        {
            _client = client;
        }

        public async  Task<List<CourseResponse>> GetCoursesByStudent(int id)
        {
            var content = await _client.GetAsync($"api/courses/{id}");
            if (content.IsSuccessStatusCode)
            {
                var jsonContent = await content.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CourseResponse>>(jsonContent);
            }

            return new List<CourseResponse>();
        }

    }
}
