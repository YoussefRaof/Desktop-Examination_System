using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.model
{
    internal class Exam
    {
        private int examId;
        private string examName;
        private int examDuration;
        private DateTime examDate;
        private int courseId;

        public Exam() { }

        public int ExamId
        {
            get { return examId; }
            set { examId = value; }
        }

        public string ExamName
        {
            get { return examName; }
            set { examName = value; }
        }

        public int ExamDuration
        {
            get { return examDuration; }
            set { examDuration = value; }
        }

        public DateTime ExamDate
        {
            get { return examDate; }
            set { examDate = value; }
        }

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }
    }
}
