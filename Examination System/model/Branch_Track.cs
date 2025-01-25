using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.model
{
    internal class Branch_Track
    {
        private int branchId;
        private int trackId;

        public Branch_Track() { }

        public int BranchId
        {
            get { return branchId; }
            set { branchId = value; }
        }

        public int TrackId
        {
            get { return trackId; }
            set { trackId = value; }
        }
    }
}
