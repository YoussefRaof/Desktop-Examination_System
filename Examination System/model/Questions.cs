using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.model
{
    internal class Questions
    {
        private int questionId;
        private string questionName;
        private string type;
        private string modelAnswer;
        private int courseId;

        public Questions() { }

        public int QuestionId
        {
            get { return questionId; }
            set { questionId = value; }
        }

        public string QuestionName
        {
            get { return questionName; }
            set { questionName = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string ModelAnswer
        {
            get { return modelAnswer; }
            set { modelAnswer = value; }
        }

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }

    }
}
