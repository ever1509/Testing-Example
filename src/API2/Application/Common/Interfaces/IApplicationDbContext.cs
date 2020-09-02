using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API2.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API2.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Course> Courses { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Instructor> Instructors { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
