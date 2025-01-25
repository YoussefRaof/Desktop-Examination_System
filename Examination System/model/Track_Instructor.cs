using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.model
{
    internal class Track_Instructor
    {
        private int trackId;
        private int instructorId;

        public Track_Instructor() { }

        public int TrackId
        {
            get { return trackId; }
            set { trackId = value; }
        }

        public int InstructorId
        {
            get { return instructorId; }
            set { instructorId = value; }
        }
    }
}
