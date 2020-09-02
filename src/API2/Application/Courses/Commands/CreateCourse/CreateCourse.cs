using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API2.Application.Common.Interfaces;
using API2.Domain.Entities;
using FluentValidation;
using MediatR;

namespace API2.Application.Courses.Commands.CreateCourse
{
    public class CreateCourse:IRequest<int>
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public int InstructorId { get; set; }
        public int StudentId { get; set; }
    }

    public class CreateCourseValidator : AbstractValidator<CreateCourse>
    {
        public CreateCourseValidator()
        {
            RuleFor(c => c.Title).NotEmpty().WithMessage("Title mandatory");
            RuleFor(c => c.Department).NotEmpty().WithMessage("Department Mandatory");
            RuleFor(c => c.Location).NotEmpty().WithMessage("Location Mandatory");
            RuleFor(c => c.StudentId).NotEmpty().WithMessage("Student Mandatory");
            RuleFor(c => c.InstructorId).NotEmpty().WithMessage("Instructor Mandatory");

        }
    }

    public class CreateCourseHandler : IRequestHandler<CreateCourse, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCourseHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(CreateCourse request, CancellationToken cancellationToken)
        {
            Course entity= new Course()
            {
                Title = request.Title,
                Department = request.Department,
                Location = request.Location,
                InstructorId = request.InstructorId,
                StudentId = request.StudentId
            };
            _context.Courses.Add(entity);
            
            await _context.SaveChangesAsync(cancellationToken);

            return entity.CourseId;

        }
    }
}
