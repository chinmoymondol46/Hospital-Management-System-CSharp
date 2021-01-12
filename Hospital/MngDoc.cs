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
    public partial class MngDoc : Form
    {
        public MngDoc()
        {
            InitializeComponent();
        }

        private void MngDoc_Load(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
            dtpDoB.MaxDate = DateTime.Now;
            dtpDoB.Value = DateTime.Now.AddYears(-20);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataSet ds;
            ds = DBAction.SelectDB("SELECT * FROM Doctor");
            dgvDoc.DataSource = ds.Tables[0];
            dgvDoc.ClearSelection();

            txtSearch.Text = "";

        }


        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void dtpDoB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int count1=0;
            int count2=0;
            if(txtID.Text=="")
            {
                try
                {
                    string maxID;
                    count1 = DBAction.nonDB("insert into Login(Password,UserType) values('" + txtPass.Text + "','Doctor')");
                    maxID = DBAction.SelectDB("select MAX(ID) from Login").Tables[0].Rows[0][0].ToString();
                    count2 = DBAction.nonDB("insert into Doctor (UserID,Name,Gender,DoB,Address,Department,Phone) values (" + maxID + ",'" + txtName.Text + "','" + cbGender.Text + "', '" + dtpDoB.Value.ToString("yyyy-MM-dd") + "','" + txtAddress.Text + "','" + cbDept.Text + "','" + txtPNumber.Text + "');");
                    txtID.Text = maxID;

                    lblMsg.ForeColor = Color.Green;
                    lblMsg.Text = "Inserted " + count1 + " row(s) in Login table.\nInserted " + count2 + " row(s) in Doctor table.";
                }
                catch (Exception exception)
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = exception.Message;
                }
            }
            else
            {
                try
                {
                    if (txtPass.Text != "")
                    {
                        count1 = DBAction.nonDB("update Login set Password = '" + txtPass.Text + "' where ID = '" + txtID.Text + "'");
                    }
                    count2 = DBAction.nonDB("update Doctor set Name = '" + txtName.Text + "',Gender = '" + cbGender.Text + "',DoB = '" + dtpDoB.Value.ToString("yyyy-MM-dd") + "',Address = '" + txtAddress.Text + "',Department = '" + cbDept.Text + "',Phone = '" + txtPNumber.Text + "' where UserID = '" + txtID.Text + "';");

                    lblMsg.ForeColor = Color.Green;
                    if (count1 == 0)
                    {
                        lblMsg.Text = "Updated " + count2 + " row(s) in Doctor table.";
                    }
                    else
                    {
                        lblMsg.Text = "Updated " + count1 + " row(s) in Login table.\nUpdated " + count2 + " row(s) in Doctor table.";
                    }
                }
                catch (Exception exception)
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = exception.Message;
                }
            }
            btnSearch.PerformClick();

        }

        private void ckbPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPass.Checked == true)
                txtPass.PasswordChar = '\0';
            else
                txtPass.PasswordChar = '●';
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            txtPass.Text = "";
            cbDept.SelectedIndex = -1;
            cbGender.SelectedIndex = -1;
            dtpDoB.Value = DateTime.Now.AddYears(-20);
            txtPNumber.Text = "";
            txtAddress.Text = "";
            lblMsg.Text = "";

            dgvDoc.ClearSelection();
        }

        private void dgvDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtID.Text = dgvDoc.Rows[e.RowIndex].Cells["colUserID"].Value.ToString();
                txtName.Text = dgvDoc.Rows[e.RowIndex].Cells["colName"].Value.ToString();
                cbGender.Text = dgvDoc.Rows[e.RowIndex].Cells["colGender"].Value.ToString();
                dtpDoB.Value = DateTime.Parse(dgvDoc.Rows[e.RowIndex].Cells["colDoB"].Value.ToString());
                txtPNumber.Text = dgvDoc.Rows[e.RowIndex].Cells["colPNumber"].Value.ToString();
                txtAddress.Text = dgvDoc.Rows[e.RowIndex].Cells["colAddress"].Value.ToString();
                cbDept.Text = dgvDoc.Rows[e.RowIndex].Cells["colDepartment"].Value.ToString();
                lblMsg.Text = "";
                
            }
            else
            {
                dgvDoc.ClearSelection();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int count1 = 0;
            int count2 = 0;
            if(dgvDoc.SelectedRows.Count < 1)
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "No row selected.";

            }
            else
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete " + dgvDoc.SelectedRows.Count + " item(s)?", "Delete Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        for (int i = 0; i < dgvDoc.SelectedRows.Count; i++)
                        {
                            count2 += DBAction.nonDB("DELETE FROM Doctor WHERE UserID = " + dgvDoc.SelectedRows[i].Cells["colUserID"].Value.ToString() + ";");
                            count1 += DBAction.nonDB("DELETE FROM Login WHERE ID = " + dgvDoc.SelectedRows[i].Cells["colUserID"].Value.ToString() + ";");
                        }

                        btnNew.PerformClick();
                        btnSearch.PerformClick();

                        lblMsg.ForeColor = Color.Green;
                        lblMsg.Text = "Deleted " + count1 + " row(s) in Login table.\nDeleted " + count2 + " row(s) in Doctor table.";
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

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds;
            if (txtSearch.Text != "")
            {
                ds = DBAction.SelectDB("SELECT * FROM Doctor where Name like '%" + txtSearch.Text + "%' or Department like '%" + txtSearch.Text + "%';");
                dgvDoc.DataSource = ds.Tables[0];
                dgvDoc.ClearSelection();
            }
            else
            {
                btnRefresh.PerformClick();
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            }
        }
    }
}
