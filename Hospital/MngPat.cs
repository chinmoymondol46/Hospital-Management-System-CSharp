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
    public partial class MngPat : Form
    {
        string selectedID = "";

        public MngPat()
        {
            InitializeComponent();
        }

        private void MngPat_Load(object sender, EventArgs e)
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
            ds = DBAction.SelectDB("SELECT * FROM Patient");
            dgvPat.DataSource = ds.Tables[0];
            dgvPat.ClearSelection();
            txtSearch.Text = "";

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void dtpDoB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int count=0;
            if(selectedID=="")
            {
                try
                {
                    count = DBAction.nonDB("insert into Patient (Name,Gender,DoB,Address,Phone) values ('" + txtName.Text + "','" + cbGender.Text + "', '"+ dtpDoB.Value.ToString("yyyy-MM-dd") + "','" + txtAddress.Text + "','"+txtPNumber.Text+"')");

                    lblMsg.ForeColor = Color.Green;
                    lblMsg.Text = "" + count + " row(s) in Patient table.";
                    selectedID = DBAction.SelectDB("select MAX(ID) from Patient").Tables[0].Rows[0][0].ToString();
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
                    count = DBAction.nonDB("update Patient set Name = '" + txtName.Text + "',Gender = '" + cbGender.Text + "',DoB = '" + dtpDoB.Value.ToString("yyyy-MM-dd") + "',Address = '" + txtAddress.Text + "',Phone = '"+txtPNumber.Text+"' where ID = '" + selectedID + "'");

                    lblMsg.ForeColor = Color.Green;
                    lblMsg.Text = "Updated " + count + " row(s) in Patient table.";
                }
                catch (Exception exception)
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = exception.Message;
                }
            }

            btnSearch.PerformClick();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            selectedID = "";
            txtName.Text = "";
            cbGender.SelectedIndex = -1;
            dtpDoB.Value = DateTime.Now.AddYears(-20);
            txtPNumber.Text = "";
            txtAddress.Text = "";
            lblMsg.Text = "";
            cbGender.Text = "Male";

            dgvPat.ClearSelection();
        }

        private void dgvRec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                selectedID = dgvPat.Rows[e.RowIndex].Cells["colID"].Value.ToString();
                txtName.Text = dgvPat.Rows[e.RowIndex].Cells["colName"].Value.ToString();
                cbGender.Text = dgvPat.Rows[e.RowIndex].Cells["colGender"].Value.ToString();
                dtpDoB.Value = DateTime.Parse(dgvPat.Rows[e.RowIndex].Cells["colDoB"].Value.ToString());
                txtPNumber.Text = dgvPat.Rows[e.RowIndex].Cells["colPNumber"].Value.ToString();
                txtAddress.Text = dgvPat.Rows[e.RowIndex].Cells["colAddress"].Value.ToString();
                lblMsg.Text = "";
                
            }
            else
            {
                dgvPat.ClearSelection();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int count = 0;

            if (dgvPat.SelectedRows.Count < 1)
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "No row selected.";
            }
            else
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete " + dgvPat.SelectedRows.Count + " item(s)?", "Delete Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        for (int i = 0; i < dgvPat.SelectedRows.Count; i++)
                        {
                            count += DBAction.nonDB("DELETE FROM Patient WHERE ID = " + dgvPat.SelectedRows[i].Cells["colID"].Value.ToString() + ";");
                        }
                        btnSearch.PerformClick();
                        btnNew.PerformClick();

                        lblMsg.ForeColor = Color.Green;
                        lblMsg.Text = "Deleted " + count + " row(s) in Patient table.";
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
                try
                {
                    ds = DBAction.SelectDB("SELECT * FROM Patient where Name like '%" + txtSearch.Text + "%' or Phone = '" + txtPNumber + "';");
                    dgvPat.DataSource = ds.Tables[0];
                    dgvPat.ClearSelection();
                }
                catch (Exception exception)
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = exception.Message;
                }
            }
            else
            {
                btnRefresh.PerformClick();
            }
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
