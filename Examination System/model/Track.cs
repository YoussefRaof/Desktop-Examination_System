using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.model
{
    internal class Track
    {
        private int trackId;
        private string trackName;
        private int isntructorId;
        private int branchId;
        private int admin_id_FK;



        public Track() { }

        public int Admin_id_FK
        {
            get { return admin_id_FK; }
            set { admin_id_FK = value; }
        }
        public int TrackId
        {
            get { return trackId; }
            set { trackId = value; }
        }

        public string TrackName
        {
            get { return trackName; }
            set { trackName = value; }
        }

        public int InstructorId
        {
            get { return isntructorId; }
            set { isntructorId = value; }
        }

        public int BranchId
        {
            get { return branchId; }
            set { branchId = value; }
        }
    }
}
