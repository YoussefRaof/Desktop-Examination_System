using Examination_System.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Examination_System.Controller.TrackController
{
    internal class TrackMethods : ITrackRepo
    {
        public void Delete(Track track, Branch_Track branch_Track)
        {
            throw new NotImplementedException();
        }

        public void Insert(Track track)
        {
            string columns = "track_name, track_manager, admin_id_FK";
            string values = $"'{track.TrackName}', {track.InstructorId}, {track.Admin_id_FK}";
            HelperMethods.ExecuteDmlQuery("Track", "insert", columns, values, null, 0);

            // Assiging Track To Branch

            //string columns2 = "track_id_FK, branch_id_FK";
            //string values2 = $"'{branch_Track.TrackId}', {branch_Track.BranchId}";
            //HelperMethods.ExecuteDmlQuery("Branch_Has_Track", "insert", columns2, values2, null, 0);


        }

        public void Update(Track track, Branch_Track branch_Track)
        {
            throw new NotImplementedException();
        }
    }
}
