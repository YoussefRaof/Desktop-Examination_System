using Examination_System.model;
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
        int getID(string email);
        bool checkPassword(string password, string email);
    }
}
