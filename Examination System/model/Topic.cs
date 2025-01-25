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

        public Topic() { }

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
