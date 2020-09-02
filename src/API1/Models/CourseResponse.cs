using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Models
{
    public class CourseResponse
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Instructor { get; set; }
        public string Location { get; set; }
        public string Department { get; set; }

    }
}
