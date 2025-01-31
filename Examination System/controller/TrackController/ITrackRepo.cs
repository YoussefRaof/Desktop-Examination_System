using Examination_System.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Controller.TrackController
{
    internal interface ITrackRepo
    {
        void Insert(Track track);
        void Delete(Track track);
        void Update(Track track);
    }
}
