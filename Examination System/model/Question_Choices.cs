using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.model
{
    internal class Question_Choices
    {
        private string choice;
        private int questionId;

        public Question_Choices() { }

        public string Choice
        {
            get { return choice; }
            set { choice = value; }
        }

        public int QuestionId
        {
            get { return questionId; }
            set { questionId = value; }
        }

    }
}
