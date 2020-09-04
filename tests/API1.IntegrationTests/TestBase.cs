using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using API1.Controllers;
using API1.IntegrationTests.Attributes;
using API1.IntegrationTests.Infrastructure.LamarSettings;
using API1.IntegrationTests.Mocks;
using API1.Models.Contexts;
using Lamar;
using Microsoft.EntityFrameworkCore;

namespace API1.IntegrationTests
{
    public class TestBase
    {
        public IContainer Container;

        public TestBase()
        {
            Container = SetContainer();

            SetupMockDataDbContext(Container);
        }

        private void SetupMockDataDbContext(IContainer container)
        {
            try
            {
                var rep = container.GetInstance(typeof(ApplicationDbContext)) as DbContext;
                LoadJsonSeeds(rep);

                var entitesTracked = rep.ChangeTracker.Entries().ToArray();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private void LoadJsonSeeds(DbContext repository)
        {
            var classType = repository.GetType();
            foreach (var prop in classType.GetProperties())
            {
                var attrib = prop.GetCustomAttributes(typeof(SeedDataAttribute), true);
                if (attrib.Length == 0)
                    continue;

                var entityType = prop.PropertyType.GenericTypeArguments[0];

                var mockDbSetType = typeof(MockDbSet<>);
                var mockDbSetTypeGeneric = mockDbSetType.MakeGenericType(entityType);

                var dbSet = Activator.CreateInstance(mockDbSetTypeGeneric);

                var method = mockDbSetTypeGeneric.GetMethod("LoadJson");
                method.Invoke(dbSet, new[] { ((SeedDataAttribute)attrib[0]).File, prop.GetValue(repository) });

                repository.SaveChanges();

            }
        }

        private IContainer SetContainer()
        {
            var serviceRegistry = new ServiceRegistry();

            serviceRegistry.IncludeRegistry<DatabaseFake>();
            serviceRegistry.IncludeRegistry<ServicesFake>();
            serviceRegistry.IncludeRegistry<ControllerFakes>();

            var container = new Container(serviceRegistry);

            return container;

        }
    }
}
