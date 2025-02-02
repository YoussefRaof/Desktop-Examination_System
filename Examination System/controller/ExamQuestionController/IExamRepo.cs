using Examination_System.model;
using Examination_System.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Controller
{
    internal interface IExamRepo
    {
        DataTable GetExamData(int ssn, string course_name);
        void Insert(Exam exam, Course course);
        int GetExamID(string table, string examName);
        void CorrectExam(int ssn, int exam_id);
        void SaveStudentAnswers(Student_Exam_Questions studentAnswer);
        bool IsStudTakeExam(int ssn, string examName);
    }
}
