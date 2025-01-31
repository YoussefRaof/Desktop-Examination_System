using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.model
{
    internal class Topic
    {
        private int topicId;
        private string topicName;
        private int courseId;
        private int admin_id_FK;


        public Topic() { }

        public int Admin_id_FK
        {
            get { return admin_id_FK; }
            set { admin_id_FK = value; }
        }

        public int TopicId
        {
            get { return topicId; }
            set { topicId = value; }
        }

        public string TopicName
        {
            get { return topicName; }
            set { topicName = value; }
        }

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }
    }
}
