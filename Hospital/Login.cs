using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital
{
    public partial class Login : Form
    {
        static SqlConnection con;
        static public string curUser = "";
        static public string curUType = "";
        static public bool loggedIn = false;

        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            con = DBAction.ConnectDB();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = DBAction.SelectDB("select ID from Login where ID = " + txtID.Text);
                
                if (ds.Tables[0].Rows.Count != 0)
                {
                    DataSet ds1 = DBAction.SelectDB("select ID from Login where ID = '" + txtID.Text + "' and Password = '" + txtPass.Text+"'");

                    if (ds1.Tables[0].Rows.Count != 0)
                    {
                        DataSet ds2 = DBAction.SelectDB("select UserType from Login where ID = " + txtID.Text);

                        if (ds2.Tables[0].Rows[0][0].ToString() == "Admin")
                        {
                            curUser = txtID.Text;
                            curUType = "Admin";

                            Admin adm = new Admin();
                            adm.Show();
                            this.Hide();
                            txtPass.Text = "";
                            lblError.Text = "";
                            adm.Closed += (s, args) => this.Show();

                            //adm.Closed += (s, args) => txtID.Text = curUser;
                        }

                        if (ds2.Tables[0].Rows[0][0].ToString() == "Doctor")
                        {
                            curUser = txtID.Text;
                            curUType = "Doctor";

                            Doctor doc = new Doctor();
                            doc.Show();
                            this.Hide();
                            txtPass.Text = "";
                            lblError.Text = "";
                            doc.Closed += (s, args) => this.Show();
                           // doc.Closed += (s, args) => txtID.Text = curUser;
                        }

                        if (ds2.Tables[0].Rows[0][0].ToString() == "Receptionist")
                        {
                            curUser = txtID.Text;
                            curUType = "Receptionist";

                            Receptionist rec = new Receptionist();
                            rec.Show();
                            this.Hide();
                            txtPass.Text = "";
                            lblError.Text = "";
                            rec.Closed += (s, args) => this.Show();
                            //rec.Closed += (s, args) => txtID.Text = curUser;
                        }
                    }
                    else
                    {
                        lblError.Text = "Incorrect password";
                    }
                }

                else
                {
                    lblError.Text = "Incorrect ID";
                }
            }
            catch (Exception)
            {
                lblError.Text = "Invalid ID"; //exception.Message;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPass.Checked == true)
                txtPass.PasswordChar = '\0';
            else
                txtPass.PasswordChar = '●';
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
