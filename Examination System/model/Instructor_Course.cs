using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.model
{
    internal class Instructor_Course
    {
        private int instructorId;
        private int courseId;

        public Instructor_Course() { }

        public int InstructorId
        {
            get { return instructorId; }
            set { instructorId = value; }
        }

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }
    }
}
