using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API2.Application.Common.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace API2.Application.Courses.Commands.UpdateCourse
{
    public class UpdateCourse:IRequest<bool>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }

        public int StudentId { get; set; }
        public int InstructorId { get; set; }
    }

    public class UpdateCourseValidator : AbstractValidator<UpdateCourse>
    {
        public UpdateCourseValidator()
        {
            RuleFor(c => c.Title).NotEmpty().WithMessage("Title mandatory");
            RuleFor(c => c.Department).NotEmpty().WithMessage("Department Mandatory");
            RuleFor(c => c.Location).NotEmpty().WithMessage("Location Mandatory");
            RuleFor(c => c.StudentId).NotEmpty().WithMessage("Student Mandatory");
            RuleFor(c => c.InstructorId).NotEmpty().WithMessage("Instructor Mandatory");
        }
    }
    public class UpdateCourseHandler:IRequestHandler<UpdateCourse,bool>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCourseHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateCourse request, CancellationToken cancellationToken)
        {
            var entity = await _context.Courses.SingleOrDefaultAsync(f => f.CourseId == request.Id, cancellationToken: cancellationToken);

            if (entity == null)
                throw new Exception($"{nameof(Courses)} not found with the Id {request.Id}");

            entity.Title = request.Title;
            entity.Department = request.Department;
            entity.Location = request.Location;
            entity.StudentId = request.StudentId;
            entity.InstructorId = request.InstructorId;

            await _context.SaveChangesAsync(cancellationToken);

            return true;


        }
    }
}
