using Examination_System.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Controller.InstructorController
{
    internal interface IInstructorRepo
    {
        void Insert(Instructor instructor);
        bool Login(Instructor instructor);
        void Update(Instructor instructor, int? flag);
        void Delete(Instructor instructor);
        int getID(string table, string email);
        string getName(string table, string email);
        bool checkPassword(string password, string table, string email);
    }
}
