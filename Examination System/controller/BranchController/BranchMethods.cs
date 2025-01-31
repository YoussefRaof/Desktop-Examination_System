using Examination_System.model;
using Examination_System.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System.Controller.BranchController
{
    internal class BranchMethods : IBranchRepo
    {
        public void Delete(Branch branch)
        {
            if (branch.BranchId >= 0)
            {
                string condition = $"branch_id   = {branch.BranchId}";
                HelperMethods.ExecuteDmlQuery("Branch", "delete", null, null, condition, 0);
            }
            else
            {

                MessageBox.Show("Branch not found. Please Choose a valid Branch Id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Insert(Branch branch)
        {
            string columns = "branch_name, admin_id_FK";
            string values = $"'{branch.BranchName}', {branch.Admin_id_FK}";
            HelperMethods.ExecuteDmlQuery("Branch", "insert", columns, values, null, 0);
        }

        public void Update(Branch branch)
        {
            if (branch.BranchId> 0 )
            {
                string columns = "branch_name = '{0}'";

                string formattedColumns = string.Format(columns,branch.BranchName );

                string condition = $"branch_id = {branch.BranchId}";
                HelperMethods.ExecuteDmlQuery("Branch", "update", formattedColumns, null, condition, 0);
            }
        }
    }
}
