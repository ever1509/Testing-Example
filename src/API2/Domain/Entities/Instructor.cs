using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API2.Domain.Enums;

namespace API2.Domain.Entities
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Nivel Nivel { get; set; }

        public ICollection<Course> Courses { get; set; }

    }
}
