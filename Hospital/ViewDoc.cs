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
    public partial class ViewDoc : Form
    {
        public ViewDoc()
        {
            InitializeComponent();
        }

        private void ViewDoc_Load(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataSet ds;
            ds = DBAction.SelectDB("SELECT * FROM Doctor");
            dgvDoc.DataSource = ds.Tables[0];
            dgvDoc.ClearSelection();

            txtSearch.Text = "";

        }

        private void dgvDoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
