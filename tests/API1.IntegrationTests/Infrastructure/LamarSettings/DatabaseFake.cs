using System;
using System.Collections.Generic;
using System.Text;
using API1.IntegrationTests.Mocks;
using API1.Models.Contexts;
using Lamar;
using Microsoft.EntityFrameworkCore;

namespace API1.IntegrationTests.Infrastructure.LamarSettings
{
    public class DatabaseFake:ServiceRegistry
    {
        public DatabaseFake()
        {
            For<ApplicationDbContext>().Use(new MockDbContext(new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseInMemoryDatabase("InMemmory" + Guid.NewGuid())
                    .EnableSensitiveDataLogging().Options))
                .Named("DatabaseFake");
        }
    }
}
