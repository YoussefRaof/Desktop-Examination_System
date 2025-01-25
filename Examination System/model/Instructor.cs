using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.model
{
    internal class Instructor : User
    {
        private string phone;
        private int salary;
        private int adminId;

        public Instructor() { }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public int Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public int AdminId
        {
            get { return adminId; }
            set { adminId = value; }
        }
    }
}
