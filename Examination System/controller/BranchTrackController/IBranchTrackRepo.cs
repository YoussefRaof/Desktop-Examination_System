using Examination_System.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Controller.BranchTrackController
{
    internal interface IBranchTrackRepo
    {
        void Insert(Branch_Track branch_Track);
        void Update(Branch_Track branch_Track);
        void Delete(Branch_Track branch_Track);
    }
}
