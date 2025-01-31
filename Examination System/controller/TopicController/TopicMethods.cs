using Examination_System.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Examination_System.Controller.TopicController
{
    internal class TopicMethods : ITopicRepo
    {
        public void Delete(Topic topic)
        {
            if (topic.TopicId>= 0)
            {
                string condition = $"topic_id   = {topic.TopicId}";
                HelperMethods.ExecuteDmlQuery("Topic", "delete", null, null, condition, 0);
            }
            else
            {

                MessageBox.Show("Topic not found. Please Choose a valid Topic Id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Insert(Topic topic)
        {
            string columns = "topic_name";
            string values = $"'{topic.TopicName}'";
            HelperMethods.ExecuteDmlQuery("Topic", "insert", columns, values, null, 0);
        }

        public void Update(Topic topic)
        {
            if (topic.TopicId > 0)
            {
                string columns = "topic_name = '{0}'";

                string formattedColumns = string.Format(columns, topic.TopicName);

                string condition = $"topic_id = {topic.TopicId}";
                HelperMethods.ExecuteDmlQuery("Topic", "update", formattedColumns, null, condition, 0);
            }
        }
    }
}
