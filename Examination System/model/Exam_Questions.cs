using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.model
{
    internal class Exam_Questions
    {
        private int examId;
        private int questionId;

        public Exam_Questions() { }

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
    }
}
