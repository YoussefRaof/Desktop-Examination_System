using Examination_System.model;
using Examination_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.controller
{
    internal interface IAdminRepo
    {
        void Insert(Admin admin);
        void Update(Admin admin);
        bool Login(Admin admin);
       
      
        int AssginInstructorToCourse(Instructor instructor , Course course);
        int AssginStudentToCourse(Student student, Course course);
        int getID(string table, string email);
        bool checkPassword(string password, string table, string email);
        int UnAssignInstructorToCourse(Instructor instructor, Course course);
        int UnAssignStudentToCourse(Student student, Course course);
    }
}
