using Examination_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Controller.StudentController
{
    internal interface IStudentRepo
    {
        void Insert(Student student);

        void Update(Student student);

        void Delete(Student student);
        bool Login(Student student);
    }
}
