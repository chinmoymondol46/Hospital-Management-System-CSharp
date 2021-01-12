using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital
{
    public partial class MngCab : Form
    {
        public MngCab()
        {
            InitializeComponent();
        }

        private void MngCab_Load(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
            //cbName.Text = "";
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataSet ds;
            ds = DBAction.SelectDB("Select Cabin.ID,Catagory,Status,Patient.Name,Patient.Phone from Cabin Left Outer Join Patient On Cabin.PatientID = Patient.ID");
            dgvCab.DataSource = ds.Tables[0];
            dgvCab.ClearSelection();

            txtSearch.Text = "";

            txtName.Text = "";
            txtID.Text = "";
            txtCatagory.Text = "";
            txtStatus.Text = "";
            btnPSearch.PerformClick();
            cbPhone.SelectedIndex = -1;
        }


        private void lblName_Click(object sender, EventArgs e)
        {

        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cbPhone.Text != "")
            {
                try
                {
                    DBAction.nonDB("Update Cabin set Status = 'Occupied', PatientID = '" + cbPhone.SelectedValue + "' where ID = " + txtID.Text + ""); ;

                    txtStatus.Text = "Occupied";

                    
                    
                    btnSearch.PerformClick();
                    lblMsg.ForeColor = Color.Green;
                    lblMsg.Text = "Filled " + 1 + " cabin(s).";
                }
                catch (Exception exception)
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = exception.Message;
                }
            }
        }


        private void dgvRec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtID.Text = dgvCab.Rows[e.RowIndex].Cells["colID"].Value.ToString();
                txtCatagory.Text = dgvCab.Rows[e.RowIndex].Cells["colCatagory"].Value.ToString();
                txtStatus.Text = dgvCab.Rows[e.RowIndex].Cells["colStatus"].Value.ToString();
                txtName.Text = dgvCab.Rows[e.RowIndex].Cells["colName"].Value.ToString();
                btnPSearch.PerformClick();
                cbPhone.Text = dgvCab.Rows[e.RowIndex].Cells["colPNumber"].Value.ToString();
                

                if (dgvCab.Rows[e.RowIndex].Cells["colStatus"].Value.ToString() == "Empty")
                {

                    txtName.Text = "";
                    cbPhone.Text = "";
                    cbPhone.SelectedItem = null;
                }

                lblMsg.Text = "";
                
            }
            else
            {
                dgvCab.ClearSelection();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int count = 0;
            int selCount = 0;

            for(int i = 0; i < dgvCab.SelectedRows.Count; i++)
            {
                if (dgvCab.SelectedRows[i].Cells["colStatus"].Value.ToString() != "Empty")
                {
                    selCount += 1;
                }
            }

            if (selCount < 1)
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "No row selected or empty row(s) selected";
            }
            else
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to empty "+ selCount +" cabin(s)?", "Vacancy Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        for (int i = 0; i < dgvCab.SelectedRows.Count; i++)
                        {
                            count += DBAction.nonDB("Update Cabin set Status = 'Empty', PatientID = NULL where ID = " + dgvCab.SelectedRows[i].Cells["colID"].Value.ToString() + ";");
                        }
                        btnSearch.PerformClick();

                        lblMsg.ForeColor = Color.Green;
                        lblMsg.Text = "Emptied " + count + " cabin(s).";

                    }
                    else if (dialogResult == DialogResult.No)
                    {

                    }
                }
                catch (Exception exception)
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = exception.Message;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds;
            if (txtSearch.Text != "")
            {
                ds = DBAction.SelectDB("Select Cabin.ID,Catagory,Status,Patient.Name,Patient.Phone from Cabin Left Outer Join Patient On Cabin.PatientID = Patient.ID Where Cabin.ID = " + txtSearch.Text + ";");
                dgvCab.DataSource = ds.Tables[0];

                txtName.Text = "";
                txtID.Text = "";
                txtCatagory.Text = "";
                txtStatus.Text = "";
                btnPSearch.PerformClick();
                cbPhone.SelectedIndex = -1;

                dgvCab.ClearSelection();
            }
            else
            {
                btnRefresh.PerformClick();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text != "")
                {
                    DataSet ds = DBAction.SelectDB("Select Name, Phone, ID from Patient where Name like '%" + txtName.Text + "%'");
                    cbPhone.DataSource = ds.Tables[0];
                    cbPhone.ValueMember = "ID";
                    cbPhone.DisplayMember = "Phone";
                    cbPhone.Refresh();

                    //txtName.Text = ds.Tables[0].Rows[cbPhone.SelectedIndex]["Name"].ToString();
                }
            }
            catch (Exception)
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Please Enter a Phone Number";//exception.Message;
            }
        }

        private void btnSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }

        private void txtPNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnPSearch.PerformClick();
            }
        }
    }
}
