using API1.Controllers;
using API1.Services;

namespace API1.IntegrationTests.Mocks
{
    public class StudentControllerFake:StudentsController
    {
        public StudentControllerFake(IStudentService studentService) : base(studentService)
        {
        }
    }
}
