using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.model
{
    internal class Branch
    {
        private int branchId;
        private string branchName;

        public Branch() { }

        public int BranchId
        {
            get { return branchId; }
            set { branchId = value; }
        }

        public string BranchName
        {
            get { return branchName; }
            set { branchName = value; }
        }
    }
}
