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
    public partial class MngApt : Form
    {
        static public DateTime timeFrom = DateTime.ParseExact("00:00","HH:mm",null);
        static public DateTime timeTo = DateTime.ParseExact("00:00", "HH:mm", null);
        static public DateTime selDate = DateTime.Parse("1-1-1000");
        static public string curDoc = "";


        public MngApt()
        {
            InitializeComponent();
        }

        private void MngApt_Load(object sender, EventArgs e)
        {

            dgvMain.AutoGenerateColumns = false;
            btnRefresh.PerformClick();
            btnNew.PerformClick();
            dtpDate.MinDate = DateTime.Now;
            //cbName.Text = "";
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataSet ds;
            ds = DBAction.SelectDB("SELECT Schedule.ID,Patient.Name as PName,Doctor.Name as DName,Schedule.Date,Schedule.S_Time,Schedule.E_Time,Patient.Phone,Doctor.Department from Schedule Left outer join Patient on Schedule.PatientID = Patient.ID Left outer join Doctor on Schedule.DoctorID = Doctor.ID");
            dgvMain.DataSource = ds.Tables[0];
            dgvMain.ClearSelection();
            txtSearch.Text = "";

        }


        private void lblName_Click(object sender, EventArgs e)
        {

        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbPhone.Text != "" && cbDoc.Text != "" && txtFrom.Text!="" && txtTo.Text!="")
            {
                if(txtID.Text == "")
                {
                    try
                    {
                        DBAction.nonDB("insert into Schedule(PatientID,DoctorID,Date,S_Time,E_Time) values("+cbPhone.SelectedValue+","+cbDoc.SelectedValue+",'"+dtpDate.Value.ToString("yyyy-MM-dd")+"','"+timeFrom.ToString("HH:mm")+"','"+timeTo.ToString("HH:mm")+"')"); ;


                        lblMsg.ForeColor = Color.Green;
                        lblMsg.Text = "Inserted " + 1 + " appointment.";

                        btnSearch.PerformClick();
                        txtID.Text = DBAction.SelectDB("select MAX(ID) from Schedule;").Tables[0].Rows[0][0].ToString();
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
                        DBAction.nonDB("update Schedule set PatientID = " + cbPhone.SelectedValue + ",DoctorID = " + cbDoc.SelectedValue + ",Date = '" + dtpDate.Value.ToString("yyyy-MM-dd") + "',S_Time = '" + timeFrom.ToString("HH:mm") + "',E_Time = '" + timeTo.ToString("HH:mm") + "' where Schedule.ID = "+txtID.Text+""); ;


                        lblMsg.ForeColor = Color.Green;
                        lblMsg.Text = "Updated " + 1 + " appointment.";

                        btnSearch.PerformClick();

                    }
                    catch (Exception exception)
                    {
                        lblMsg.ForeColor = Color.Red;
                        lblMsg.Text = exception.Message;
                    }
                }
            }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Missing Information.";
            }
        }


        private void dgvRec_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                txtID.Text = dgvMain.Rows[e.RowIndex].Cells["colID"].Value.ToString();

                txtName.Text = dgvMain.Rows[e.RowIndex].Cells["colPat"].Value.ToString();
                btnPSearch.PerformClick();
                cbPhone.Text = dgvMain.Rows[e.RowIndex].Cells["colPNumber"].Value.ToString();

                cbDept.Text = dgvMain.Rows[e.RowIndex].Cells["colDept"].Value.ToString();

                //ref2
                try
                {
                    cbDoc.DataSource = DBAction.SelectDB("Select Name, ID from Doctor where Department = '" + cbDept.Text + "'").Tables[0];
                    cbDoc.ValueMember = "ID";
                    cbDoc.DisplayMember = "Name";
                    cbDoc.Refresh();
                }
                catch (Exception)
                {

                }
                cbDoc.Text = dgvMain.Rows[e.RowIndex].Cells["colDoc"].Value.ToString();


                selDate = DateTime.Parse(dgvMain.Rows[e.RowIndex].Cells["colDate"].Value.ToString());
                dtpDate.Value = selDate;

                timeFrom = DateTime.ParseExact(dgvMain.Rows[e.RowIndex].Cells["colFrom"].Value.ToString(), "HH:mm:ss", null);
                timeTo = DateTime.ParseExact(dgvMain.Rows[e.RowIndex].Cells["colTo"].Value.ToString(), "HH:mm:ss", null);

                txtFrom.Text = timeFrom.ToString("hh:mm tt");
                txtTo.Text = timeTo.ToString("hh:mm tt");

                lblMsg.Text = "";
                
            }
            else
            {
                dgvMain.ClearSelection();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int count = 0;
            
            if(dgvMain.SelectedRows.Count > 0)
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete " + dgvMain.SelectedRows.Count + " appointment(s)?", "Delete Confirmation", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        for (int i = 0; i < dgvMain.SelectedRows.Count; i++)
                        {
                            count += DBAction.nonDB("DELETE FROM Schedule WHERE ID = " + dgvMain.SelectedRows[i].Cells["colID"].Value.ToString() + ";");
                        }
                        btnSearch.PerformClick();

                        lblMsg.ForeColor = Color.Green;
                        lblMsg.Text = "" + count + " appointment(s) deleted.";
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
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "No row selected.";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataSet ds;
            if (txtSearch.Text != "")
            {
                ds = DBAction.SelectDB("SELECT Schedule.ID,Patient.Name as PName,Doctor.Name as DName,Schedule.Date,Schedule.S_Time,Schedule.E_Time,Patient.Phone,Doctor.Department from Schedule Left outer join Patient on Schedule.PatientID = Patient.ID Left outer join Doctor on Schedule.DoctorID = Doctor.ID where Patient.Name like '%" + txtSearch.Text+ "%' or Doctor.Name like '%" + txtSearch.Text + "%';");
                dgvMain.DataSource = ds.Tables[0];
                
                
                dgvMain.ClearSelection();


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
                if(txtName.Text!="")
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

        private void cbDept_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //ref2
            try
            {
                cbDoc.DataSource = DBAction.SelectDB("Select Name, ID from Doctor where Department = '" + cbDept.Text + "'").Tables[0];
                cbDoc.ValueMember = "ID";
                cbDoc.DisplayMember = "Name";
                cbDoc.Refresh();
            }
            catch(Exception)
            {

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            cbDept.SelectedIndex = -1;
            btnPSearch.PerformClick();
            curDoc = "";

            //ref2
            try
            {
                cbDoc.DataSource = DBAction.SelectDB("Select Name, ID from Doctor where Department = '" + cbDept.Text + "'").Tables[0];
                cbDoc.ValueMember = "ID";
                cbDoc.DisplayMember = "Name";
                cbDoc.Refresh();
            }
            catch (Exception)
            {

            }

            cbDoc.SelectedIndex = -1;
            cbPhone.SelectedIndex = -1;
            lblMsg.Text = "";
            
            timeFrom = DateTime.ParseExact("00:00", "HH:mm", null);
            timeTo = DateTime.ParseExact("00:00", "HH:mm", null);
            dtpDate.Value = DateTime.Now;
            selDate = dtpDate.Value;

            txtFrom.Text = "";
            txtTo.Text = "";



            dgvMain.ClearSelection();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            try
            {
                curDoc = cbDoc.SelectedValue.ToString();
            }
            catch (Exception)
            {

            }

            if(curDoc != "")
            {
                SelectTime selectTime = new SelectTime();
                selectTime.ShowDialog();
                if (timeFrom != DateTime.ParseExact("00:00", "HH:mm", null))
                {
                    txtFrom.Text = timeFrom.ToString("hh:mm tt");
                    txtTo.Text = timeTo.ToString("hh:mm tt");
                }
            }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Please select a doctor;";
            }
        }

        private void txtFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFrom_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            selDate = dtpDate.Value;
        }
    }
}
