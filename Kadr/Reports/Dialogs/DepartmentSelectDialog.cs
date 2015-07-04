using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Reports.Forms;

namespace Reports.Dialogs
{
    public partial class DepartmentSelectDialog : Form
    {
        
        public DepartmentSelectDialog()
        {
            InitializeComponent();
        }

        private void DepartmentSelectDialog_Load(object sender, EventArgs e)
        {

        }


        private ArrayList depList;
        public ArrayList DepList
        {
            get
            {
                return depList;
            }            
        }

        public IEnumerable<Department> DepsList
        {
           
            set
            {
                departmentBindingSource.DataSource = value;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (depList == null)
                depList = new ArrayList();
            else
                depList.Clear();

            foreach (DataGridViewRow curRow in dgvDepartment.Rows)
            {
                if (Convert.ToBoolean(curRow.Cells[dgvDepartment.Rows[0].Cells.Count - 1].Value))
                {
                    depList.Add((curRow.Cells[0]).Value);
                }
            }
            if (depList.Count == 0)
            {
                MessageBox.Show("Не выбран ни один отдел!", "АИС Штатное расписание", MessageBoxButtons.OK);
                return;
            }

            btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();

        }


        private void dgvDepartment_Click(object sender, EventArgs e)
        {
            dgvDepartment.CurrentRow.Cells[dgvDepartment.Rows[0].Cells.Count - 1].Value = 
                !Convert.ToBoolean(dgvDepartment.CurrentRow.Cells[dgvDepartment.Rows[0].Cells.Count - 1].Value);
        }

        private void DepartmentSelectDialog_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void DepartmentSelectDialog_VisibleChanged(object sender, EventArgs e)
        {
            if ((depList == null) || (depList.Count == 0))
                return;

            foreach (DataGridViewRow curRow in dgvDepartment.Rows)
            {
                if (depList.Contains(curRow.Cells[0].Value))
                {
                    curRow.Cells[dgvDepartment.Rows[0].Cells.Count - 1].Value = true;
                }
                else
                    curRow.Cells[dgvDepartment.Rows[0].Cells.Count - 1].Value = false;
            }


        }

        private void btnCalcel_Click(object sender, EventArgs e)
        {
            //Close();
        }


    }
}
