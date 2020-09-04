using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API2.Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API2.Application.Courses.Queries.GetCourses
{
    public class GetCourses:IRequest<CoursesVm>
    {
        public int StudentId { get; set; }
    }

    public class GetCoursesValidator : AbstractValidator<GetCourses>
    {
        public GetCoursesValidator()
        {
            RuleFor(c => c.StudentId).NotEmpty().WithMessage("Student Mandatory");
        }
    }
    public class GetCoursesHandler:IRequestHandler<GetCourses, CoursesVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCoursesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CoursesVm> Handle(GetCourses request, CancellationToken cancellationToken)
        {
            try
            {
                var courses = await _context.Courses
                    .Where(c => c.StudentId == request.StudentId)
                    .Include(c=>c.Instructor)
                    .ProjectTo<CourseDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                
                return new CoursesVm(){Courses = courses};
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
