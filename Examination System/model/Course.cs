using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.model
{
    internal class Course
    {
        private int courseId;
        private string courseName;  
        private int admin_id_FK ;
        private int topicId;

        public Course() { }

        public int TopicId
        {
            get { return topicId; }
            set { topicId = value; }
        }
        public int Admin_id_FK
        {
            get { return admin_id_FK; }
            set { admin_id_FK = value; }
        }
        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }

        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

    }
}
