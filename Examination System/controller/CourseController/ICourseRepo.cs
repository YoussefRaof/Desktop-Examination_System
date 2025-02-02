using Examination_System.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Controller.CourseController
{
    internal interface ICourseRepo
    {
        void Insert(Course course);
        void Delete(Course course);
        void Update(Course course);
        int GetCourseID(string table, string examName);
    }
}
