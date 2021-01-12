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
    public partial class Doctor : Form
    {
        string selectedID;
        string selDocID;
        string curDocID;


        public Doctor()
        {
            InitializeComponent();
        }
        
        private void Doctor_Load(object sender, EventArgs e)
        {
            dgvMain.AutoGenerateColumns = false;

            btnRefresh.PerformClick();
            curDocID = DBAction.SelectDB("select Doctor.ID from Doctor,Login where Doctor.UserID = "+Login.curUser+";").Tables[0].Rows[0][0].ToString();
            btnPSearch.PerformClick();
            string name = DBAction.SelectDB("select Name from Doctor,Login where Doctor.UserID=Login.ID and Login.ID = " + Login.curUser + ";").Tables[0].Rows[0][0].ToString();
            lblWelcome.Text = "Welcome\nDr. "+name+"";
            btnNew.PerformClick();

        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DataSet ds;
            ds = DBAction.SelectDB("Select Medicine.ID,Medicine.Name,Patient.Name,Doctor.Name,Medicine.Date,Patient.Phone,Medicine.DoctorID from Medicine Left Outer Join Patient On Medicine.PatientID = Patient.ID Left Outer Join Doctor On Medicine.DoctorID = Doctor.ID;");
            dgvMain.DataSource = ds.Tables[0];
            dgvMain.ClearSelection();
            txtSearch.Text = "";
            selDocID = "";
            //lblMsg.Text = ""+curDocID+""+selDocID+"";

        }


        private void lblName_Click(object sender, EventArgs e)
        {

        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if(cbPNumber.Text != "")
            {
                if(selectedID=="")
                {
                    try
                    {
                        DBAction.nonDB("Insert into Medicine(Name,PatientID,DoctorID,Date) values('" + txtMed.Text + "'," + cbPNumber.SelectedValue + "," + curDocID + ",'" + DateTime.Now.ToString("yyyy-MM-dd") + "')");

                        selectedID = DBAction.SelectDB("select MAX(ID) from Medicine").Tables[0].Rows[0][0].ToString();

                        //ref1
                        DataSet ds = DBAction.SelectDB("Select Medicine.ID,Medicine.Name,Patient.Name,Doctor.Name,Medicine.Date,Patient.Phone,Medicine.DoctorID from Medicine Left Outer Join Patient On Medicine.PatientID = Patient.ID Left Outer Join Doctor On Medicine.DoctorID = Doctor.ID where Patient.ID = " + cbPNumber.SelectedValue + ";");
                        dgvMain.DataSource = ds.Tables[0];

                        //btnSearch.PerformClick();
                        lblMsg.ForeColor = Color.Green;
                        lblMsg.Text = "Inserted " + 1 + " row in Patient table.";
                    }
                    catch (Exception exception)
                    {
                        lblMsg.ForeColor = Color.Red;
                        lblMsg.Text = exception.Message;
                    }
                }
                else if (selDocID == curDocID)
                {
                    try
                    {
                        DBAction.nonDB("Update Medicine set Name = '" + txtMed.Text + "',DoctorID = " + curDocID + ",Date = '" + DateTime.Now.ToString("yyyy-MM-dd") + "' where ID = " + selectedID + "");

                        lblMsg.ForeColor = Color.Green;
                        lblMsg.Text = "Updated " + 1 + " row in Patient table.";
                        
                        //ref1
                        DataSet ds = DBAction.SelectDB("Select Medicine.ID,Medicine.Name,Patient.Name,Doctor.Name,Medicine.Date,Patient.Phone,Medicine.DoctorID from Medicine Left Outer Join Patient On Medicine.PatientID = Patient.ID Left Outer Join Doctor On Medicine.DoctorID = Doctor.ID where Patient.ID = " + cbPNumber.SelectedValue + ";");
                        dgvMain.DataSource = ds.Tables[0];


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
                    lblMsg.Text = "You can only update entries prescribed by you.";
                }
            }
            else
            {
                lblMsg.ForeColor = Color.Red;
                lblMsg.Text = "Please select a Patient.";
            }
        }


        private void dgvMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                selectedID = dgvMain.Rows[e.RowIndex].Cells["colID"].Value.ToString();
                selDocID = dgvMain.Rows[e.RowIndex].Cells["colDID"].Value.ToString();


                txtMed.Text = dgvMain.Rows[e.RowIndex].Cells["colMName"].Value.ToString();

                txtPName.Text = dgvMain.Rows[e.RowIndex].Cells["colName"].Value.ToString();
                string number = dgvMain.Rows[e.RowIndex].Cells["colPNumber"].Value.ToString();
                btnPSearch.PerformClick();
                cbPNumber.Text = number;

                //ref1
                DataSet ds = DBAction.SelectDB("Select Medicine.ID,Medicine.Name,Patient.Name,Doctor.Name,Medicine.Date,Patient.Phone,Medicine.DoctorID from Medicine Left Outer Join Patient On Medicine.PatientID = Patient.ID Left Outer Join Doctor On Medicine.DoctorID = Doctor.ID where Patient.ID = " + cbPNumber.SelectedValue + ";");
                dgvMain.DataSource = ds.Tables[0];



                lblMsg.Text = "";
                //lblMsg.Text = "" + curDocID + "" + selDocID + "";

            }
            else
            {
                dgvMain.ClearSelection();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int count = 0;
            int selCount = 0;

            for(int i = 0; i < dgvMain.SelectedRows.Count; i++)
            {
                if (dgvMain.SelectedRows[i].Cells["colStatus"].Value.ToString() != "Empty")
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
                        for (int i = 0; i < dgvMain.SelectedRows.Count; i++)
                        {
                            count += DBAction.nonDB("Update Cabin set Status = 'Empty', PatientID = NULL where ID = " + dgvMain.SelectedRows[i].Cells["colID"].Value.ToString() + ";");
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
                //ref1
                ds = DBAction.SelectDB("Select Medicine.ID,Medicine.Name,Patient.Name,Doctor.Name,Medicine.Date,Patient.Phone,Medicine.DoctorID from Medicine Left Outer Join Patient On Medicine.PatientID = Patient.ID Left Outer Join Doctor On Medicine.DoctorID = Doctor.ID where Medicine.Name like '%" + txtSearch.Text + "%' or Doctor.Name like '%" + txtSearch.Text + "%';");
                dgvMain.DataSource = ds.Tables[0];
                dgvMain.ClearSelection();
                selDocID="";
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
            if(txtPName.Text != "")
            {
                try
                {
                    DataSet ds = DBAction.SelectDB("Select Name, Phone, ID from Patient where Name like '%" + txtPName.Text + "%'");
                    cbPNumber.DataSource = ds.Tables[0];
                    cbPNumber.ValueMember = "ID";
                    cbPNumber.DisplayMember = "Phone";
                    cbPNumber.Refresh();

                    //txtPName.Text = ds.Tables[0].Rows[cbPNumber.SelectedIndex]["Name"].ToString();

                    //ref1
                    DataSet ds1 = DBAction.SelectDB("Select Medicine.ID,Medicine.Name,Patient.Name,Doctor.Name,Medicine.Date,Patient.Phone,Medicine.DoctorID from Medicine Left Outer Join Patient On Medicine.PatientID = Patient.ID Left Outer Join Doctor On Medicine.DoctorID = Doctor.ID where Patient.ID = " + cbPNumber.SelectedValue + ";");
                    dgvMain.DataSource = ds1.Tables[0];
                    dgvMain.ClearSelection();

                }
                catch (Exception)
                {
                    lblMsg.ForeColor = Color.Red;
                    lblMsg.Text = "Please Enter a valid name.";//exception.Message;
                }
            }
            else
            {
                cbPNumber.ResetText();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            selectedID = "";
            selDocID = "";
            txtMed.Text = "";
            txtPName.Text = "";
            btnPSearch.PerformClick();
            cbPNumber.SelectedIndex = -1;

            dgvMain.ClearSelection();
            //btnRefresh.PerformClick();
            lblMsg.Text = "";
        }

        private void cbPNumber_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login.curUType = "";
            this.Close();
        }

        private void Doctor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Login.curUType == "")
            {
                Login.curUser = "";
                Login.curUType = "";
            }

            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit the program?", "Exit Confirmation", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Login.curUser = "";
                    Login.curUType = "";
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void cbPNumber_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //ref1
            DataSet ds = DBAction.SelectDB("Select Medicine.ID,Medicine.Name,Patient.Name,Doctor.Name,Medicine.Date,Patient.Phone,Medicine.DoctorID from Medicine Left Outer Join Patient On Medicine.PatientID = Patient.ID Left Outer Join Doctor On Medicine.DoctorID = Doctor.ID where Patient.ID = " + cbPNumber.SelectedValue + ";");
            dgvMain.DataSource = ds.Tables[0];
            dgvMain.ClearSelection();
        }

        private void cbPNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
