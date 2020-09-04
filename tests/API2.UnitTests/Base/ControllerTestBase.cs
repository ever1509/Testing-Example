using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API2.Application.Courses.Commands.CreateCourse;
using API2.Application.Courses.Commands.DeleteCourse;
using API2.Application.Courses.Commands.UpdateCourse;
using API2.Application.Courses.Queries.GetCourses;
using API2.Domain.Entities;
using FakeItEasy;
using MediatR;

namespace API2.UnitTests.Base
{
    public class ControllerTestBase
    {
        public readonly IMediator MediatorFake;
        public ControllerTestBase()
        {
            MediatorFake = A.Fake<IMediator>();

            ConfigureMediator(MediatorFake);

        }

        private void ConfigureMediator(IMediator mediatorFake)
        {
            A.CallTo(() => mediatorFake.Send(A<CreateCourse>._, A<CancellationToken>._))
                .Returns(CreateCourseCommandFake());
            A.CallTo(() => mediatorFake.Send(A<UpdateCourse>._, A<CancellationToken>._))
                .Returns(true);
            A.CallTo(() => mediatorFake.Send(A<DeleteCourse>._, A<CancellationToken>._))
                .Returns(true);
            A.CallTo(() => mediatorFake.Send(A<GetCourses>._, A<CancellationToken>._))
                .Returns(GetCoursesFake());
        }

        public CoursesVm GetCoursesFake()
        {
            return new CoursesVm()
            {
                Courses = new List<CourseDto>()
                {
                    new CourseDto()
                    {
                        CourseId = 1,
                        Title = "Test Title1",
                        Instructor = "Test Instructor1",
                        Location = "Test Location1",
                        Department = "Test Department1"
                    },
                    new CourseDto()
                    {
                        CourseId = 2,
                        Title = "Test Title2",
                        Instructor = "Test Instructor2",
                        Location = "Test Location2",
                        Department = "Test Department2"
                    },
                    new CourseDto()
                    {
                        CourseId = 3,
                        Title = "Test Title3",
                        Instructor = "Test Instructor3",
                        Location = "Test Location3",
                        Department = "Test Department3"
                    }
                }
            };
        }

        public int CreateCourseCommandFake()
        {
            var course = new Course(){CourseId = 1};
            return course.CourseId;
        }
    }
}
