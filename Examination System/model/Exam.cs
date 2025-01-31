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

        private Questions _question;
        private Student_Exam_Questions _studentAnswer;
        private Exam_Questions _examQuestions;

        public Exam() 
        {
            _question = new Questions();
            _studentAnswer = new Student_Exam_Questions();
            _examQuestions = new Exam_Questions();
        }

        public Questions Question
        { 
            get { return _question; }
            set { _question = value; }
        }

        public Student_Exam_Questions StudentAnswer
        {
            get { return _studentAnswer; }
            set { _studentAnswer = value; }
        }

        public Exam_Questions ExamQuestion
        {
            get { return _examQuestions; }
            set { _examQuestions = value; }
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
