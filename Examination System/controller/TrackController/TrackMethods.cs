using Examination_System.model;
using Examination_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Examination_System.Controller.TrackController
{
    internal class TrackMethods : ITrackRepo
    {
        public void Delete(Track track)
        {
            if (track.TrackId>= 0)
            {
                string condition = $"track_id   = {track.TrackId}";
                HelperMethods.ExecuteDmlQuery("Track", "delete", null, null, condition, 0);
            }
            else
            {

                MessageBox.Show("Track not found. Please Choose a valid Track ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Insert(Track track)
        {
            string columns = "track_name, track_manager, admin_id_FK";
            string values = $"'{track.TrackName}', {track.InstructorId}, {track.Admin_id_FK}";
            HelperMethods.ExecuteDmlQuery("Track", "insert", columns, values, null, 0);
        }

        public void Update(Track track)
        {
            if (track.TrackId> 0 )
            {
                string columns = "track_name = '{0}', track_manager = {1}";

                string formattedColumns = string.Format(columns,track.TrackName,track.InstructorId);

                string condition = $"track_id = {track.TrackId}";
                HelperMethods.ExecuteDmlQuery("Track", "update", formattedColumns, null, condition, 0);
            }
        }
    }

}
