using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.model
{
    internal class Track_Course
    {
        private int trackId;
        private int courseId;

        public Track_Course() { }

        public int TrackId
        {
            get { return trackId; }
            set { trackId = value; }
        }

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }
    }
}
