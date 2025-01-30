using Examination_System.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace Examination_System.Controller.BranchTrackController
{
    internal class BranchTrackMethods : IBranchTrackRepo
    {
        public void Delete(Branch_Track branch_Track)
        {
            throw new NotImplementedException();
        }

        public void Insert(Branch_Track branch_Track)
        {
            string columns = "track_id_FK, branch_id_FK";
            string values = $"{branch_Track.TrackId}, {branch_Track.BranchId}";
            HelperMethods.ExecuteDmlQuery("Branch_Has_Track", "insert", columns, values, null, 0);
        }

        public void Update(Branch_Track branch_Track)
        {
            throw new NotImplementedException();
        }
    }
}
