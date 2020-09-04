using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API1.Models;

namespace API1.Services
{
    public interface IAPI2Service
    {
        Task<List<CourseResponse>> GetCoursesByStudent(int id);
    }
}
