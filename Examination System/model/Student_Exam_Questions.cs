using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.model
{
    internal class Student_Exam_Questions
    {
        private int newI;
        private int studentId;
        private int examId;
        private int questionId;
        private string answer;

        public Student_Exam_Questions() { }

        public int NewI
        {
            get { return newI; }
            set { newI = value; }
        }

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

        public int QuestionId
        {
            get { return questionId; }
            set { questionId = value; }
        }

        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }
    }
}
