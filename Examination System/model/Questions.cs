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

        private string choise1;
        private string choise2;
        private string choise3;
        private string choise4;

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

        public string Choise1
        {
            get { return choise1; }
            set { choise1 = value; }
        }

        public string Choise2
        {
            get { return choise2; }
            set { choise2 = value; }
        }

        public string Choise3
        {
            get { return choise3; }
            set { choise3 = value; }
        }

        public string Choise4
        {
            get { return choise4; }
            set { choise4 = value; }
        }

    }
}
