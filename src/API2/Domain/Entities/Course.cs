using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API2.Domain.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }
        public int InstructorId { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
