using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API2.Application.Common.Interfaces;
using FluentValidation;
using MediatR;

namespace API2.Application.Courses.Commands.DeleteCourse
{
    public class DeleteCourse:IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteCourseValidator : AbstractValidator<DeleteCourse>
    {
        public DeleteCourseValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("Id mandatory");
        }
      
    }
    public class DeleteCourseHandler: IRequestHandler<DeleteCourse, bool>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCourseHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(DeleteCourse request, CancellationToken cancellationToken)
        {
            var entity = await _context.Courses.FindAsync(request.Id);

            if (entity == null)
                throw new Exception($"{nameof(Courses)} not found the entity with the Id {request.Id}");

            _context.Courses.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
