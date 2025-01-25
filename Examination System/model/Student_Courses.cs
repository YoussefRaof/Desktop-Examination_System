using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.model
{
    internal class Student_Courses
    {
        private int studentId;
        private int courseId;

        public Student_Courses() { }

        public int StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }
    }
}
