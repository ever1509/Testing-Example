using System;
using System.Collections.Generic;
using System.Text;
using API1.Models.Contexts;
using API1.Services;

namespace API1.IntegrationTests.Mocks
{
    public class MockStudentService:StudentService
    {
        public MockStudentService(ApplicationDbContext context, API2Service client) : base(context, client)
        {
        }
    }
}
