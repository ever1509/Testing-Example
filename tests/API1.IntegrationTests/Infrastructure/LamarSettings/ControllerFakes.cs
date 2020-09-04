using System;
using System.Collections.Generic;
using System.Text;
using API1.Controllers;
using API1.IntegrationTests.Mocks;
using API1.Services;
using Lamar;

namespace API1.IntegrationTests.Infrastructure.LamarSettings
{
    public class ControllerFakes:ServiceRegistry
    {
        public ControllerFakes()
        {
            For<StudentsController>()
                .Use<StudentControllerFake>()
                .Ctor<IStudentService>()
                .Is(c=>c.GetInstance<IStudentService>("MockStudentService"))
                .Named("StudentControllerFake");
        }
    }
}
