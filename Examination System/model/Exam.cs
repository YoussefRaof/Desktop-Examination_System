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

        private Student_Exam_Questions _Question;

        public Exam() 
        {
            _Question = new Student_Exam_Questions();
        }

        public Student_Exam_Questions Question
        {
            get { return _Question; }
            set { _Question = value; }
        }

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
