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
    public partial class Receptionist : Form
    {
        public Receptionist()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login.curUType = "";
            this.Close();
        }

        private void Receptionist_Load(object sender, EventArgs e)
        {
            string name = DBAction.SelectDB("select Name from Receptionist,Login where Receptionist.UserID=Login.ID and Login.ID = " + Login.curUser + ";").Tables[0].Rows[0][0].ToString();
            welMsg.Text = "Welcome "+name+"";
        }

        private void Receptionist_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Login.curUType == "")
            {
                Login.curUser = "";
                Login.curUType = "";

                try
                {
                    ViewDoc viewDoc = (ViewDoc)Application.OpenForms["viewDoc"];
                    viewDoc.Close();
                }
                catch (Exception)
                { }

                try
                {
                    MngCab mngCab = (MngCab)Application.OpenForms["mngCab"];
                    mngCab.Close();
                }
                catch (Exception)
                { }

                try
                {
                    MngPat mngPat = (MngPat)Application.OpenForms["mngPat"];
                    mngPat.Close();
                }
                catch (Exception)
                { }

                try
                {
                    MngApt mngApt = (MngApt)Application.OpenForms["mngApt"];
                    mngApt.Close();
                }
                catch (Exception)
                { }

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

        private void btnDoc_Click(object sender, EventArgs e)
        {
            try
            {
                ViewDoc viewDoc = (ViewDoc)Application.OpenForms["viewDoc"];
                viewDoc.Focus();
            }
            catch (Exception)
            {
                ViewDoc viewDoc = new ViewDoc();
                viewDoc.Show();
            }

        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            try
            {
                MngCab mngCab = (MngCab)Application.OpenForms["MngCab"];
                mngCab.Focus();
            }
            catch (Exception)
            {
                MngCab mngCab = new MngCab();
                mngCab.Show();
            }
        }

        private void btnPat_Click(object sender, EventArgs e)
        {
            try
            {
                MngPat mngPat = (MngPat)Application.OpenForms["MngPat"];
                mngPat.Focus();
            }
            catch (Exception)
            {
                MngPat mngPat = new MngPat();
                mngPat.Show();
            }
        }

        private void btnApt_Click(object sender, EventArgs e)
        {
            try
            {
                MngApt mngApt = (MngApt)Application.OpenForms["mngApt"];
                mngApt.Focus();
            }
            catch (Exception)
            {
                MngApt mngApt = new MngApt();
                mngApt.Show();
            }
        }
    }
}
