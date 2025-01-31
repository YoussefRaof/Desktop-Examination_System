using Examination_System.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Controller.QuestionController
{
    internal interface IQuestionRepo
    {
        void Insert(Object obj, int flag);
        void Update(Questions question);
        void Delete(Questions question);
        int GetCourseID(string table, string courseName);
        int GetQuestionID(string table, string quesName);
    }
}
