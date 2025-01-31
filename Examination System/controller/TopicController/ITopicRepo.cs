using Examination_System.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Controller.TopicController
{
    internal interface ITopicRepo
    {
        void Insert(Topic topic);
        void Delete(Topic topic);
        void Update(Topic topic);
    }
}
