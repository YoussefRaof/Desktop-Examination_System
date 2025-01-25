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
        void Update(Instructor instructor);

        void Delete(Instructor instructor);
    }
}
