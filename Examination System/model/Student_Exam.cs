using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.model
{
    internal class Student_Exam
    {
        private int studentId;
        private int examId;
        private int grade;

        public Student_Exam() { }

        public int StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        public int ExamId
        {
            get { return examId; }
            set { examId = value; }
        }

        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }
    }
}
