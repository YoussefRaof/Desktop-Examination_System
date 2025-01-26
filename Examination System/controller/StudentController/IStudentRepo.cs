using Examination_System.model;
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
        void Update(Student student, int? flag);
        void Delete(Student student);
        bool Login(Student student);
        int getSSN(string table, string email);
        string getName(string table, string email);
        bool checkPassword(string password, string table, string email);
    }
}
