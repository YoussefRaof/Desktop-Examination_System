using Examination_System.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Controller.BranchController
{
    internal interface IBranchRepo
    {
        void Insert(Branch branch);
        void Delete(Branch branch);
        void Update(Branch branch);
    }
}
