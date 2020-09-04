using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace API1.IntegrationTests.Mocks
{
    [ExcludeFromCodeCoverage]
    public class MockDbSet<TEntity> : DbSet<TEntity>
        where TEntity : class, new()
    {
        public void LoadJson(string json, DbSet<TEntity> dbset)
        {
            var file = $"../../../../API1.IntegrationTests/Json/Entity_{json}.json";

            if (!File.Exists(file))
                return;

            if (dbset.Any())
                return;

            var text = File.ReadAllText(file);
            var list = JsonConvert.DeserializeObject<List<TEntity>>(text);

            foreach (var item in list)
            {
                dbset.Add(item);
            }
        }
    }
}
