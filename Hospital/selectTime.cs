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
    public partial class SelectTime : Form
    {
        public SelectTime()
        {
            InitializeComponent();
        }

        private void btn1000_Click(object sender, EventArgs e)
        {
            MngApt.timeFrom = DateTime.ParseExact("10:00","HH:mm",null);
            MngApt.timeTo = DateTime.ParseExact("10:30", "HH:mm", null);
            this.Close();
        }

        private void btn1030_Click(object sender, EventArgs e)
        {
            MngApt.timeFrom = DateTime.ParseExact("10:30", "HH:mm", null);
            MngApt.timeTo = DateTime.ParseExact("11:00", "HH:mm", null);
            this.Close();
        }

        private void btn1100_Click(object sender, EventArgs e)
        {
            MngApt.timeFrom = DateTime.ParseExact("11:00", "HH:mm", null);
            MngApt.timeTo = DateTime.ParseExact("11:30", "HH:mm", null);
            this.Close();
        }

        private void btn1130_Click(object sender, EventArgs e)
        {
            MngApt.timeFrom = DateTime.ParseExact("11:30", "HH:mm", null);
            MngApt.timeTo = DateTime.ParseExact("12:00", "HH:mm", null);
            this.Close();
        }

        private void btn1200_Click(object sender, EventArgs e)
        {
            MngApt.timeFrom = DateTime.ParseExact("12:00", "HH:mm", null);
            MngApt.timeTo = DateTime.ParseExact("12:30", "HH:mm", null);
            this.Close();
        }

        private void btn1230_Click(object sender, EventArgs e)
        {
            MngApt.timeFrom = DateTime.ParseExact("12:30", "HH:mm", null);
            MngApt.timeTo = DateTime.ParseExact("13:00", "HH:mm", null);
            this.Close();
        }

        private void btn1400_Click(object sender, EventArgs e)
        {
            MngApt.timeFrom = DateTime.ParseExact("14:00", "HH:mm", null);
            MngApt.timeTo = DateTime.ParseExact("14:30", "HH:mm", null);
            this.Close();
        }

        private void btn1430_Click(object sender, EventArgs e)
        {
            MngApt.timeFrom = DateTime.ParseExact("14:30", "HH:mm", null);
            MngApt.timeTo = DateTime.ParseExact("15:00", "HH:mm", null);
            this.Close();
        }

        private void btn1500_Click(object sender, EventArgs e)
        {
            MngApt.timeFrom = DateTime.ParseExact("15:00", "HH:mm", null);
            MngApt.timeTo = DateTime.ParseExact("15:30", "HH:mm", null);
            this.Close();
        }

        private void btn1530_Click(object sender, EventArgs e)
        {
            MngApt.timeFrom = DateTime.ParseExact("15:30", "HH:mm", null);
            MngApt.timeTo = DateTime.ParseExact("16:00", "HH:mm", null);
            this.Close();
        }

        private void btn1600_Click(object sender, EventArgs e)
        {
            MngApt.timeFrom = DateTime.ParseExact("16:00", "HH:mm", null);
            MngApt.timeTo = DateTime.ParseExact("16:30", "HH:mm", null);
            this.Close();
        }

        private void btn1630_Click(object sender, EventArgs e)
        {
            MngApt.timeFrom = DateTime.ParseExact("16:30", "HH:mm", null);
            MngApt.timeTo = DateTime.ParseExact("17:00", "HH:mm", null);
            this.Close();
        }

        private void SelectTime_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            DataSet ds = DBAction.SelectDB("select S_Time from Schedule where Date = '"+MngApt.selDate.ToString("yyyy-MM-dd")+"' and DoctorID = "+MngApt.curDoc+";");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (DateTime.ParseExact(ds.Tables[0].Rows[i]["S_Time"].ToString(), "HH:mm:ss", null) == DateTime.ParseExact("1000", "HHmm", null))
                {
                    btn1000.Enabled = false;
                }
                if (DateTime.ParseExact(ds.Tables[0].Rows[i]["S_Time"].ToString(), "HH:mm:ss", null) == DateTime.ParseExact("1030", "HHmm", null))
                {
                    btn1030.Enabled = false;
                }
                if (DateTime.ParseExact(ds.Tables[0].Rows[i]["S_Time"].ToString(), "HH:mm:ss", null) == DateTime.ParseExact("1100", "HHmm", null))
                {
                    btn1100.Enabled = false;
                }
                if (DateTime.ParseExact(ds.Tables[0].Rows[i]["S_Time"].ToString(), "HH:mm:ss", null) == DateTime.ParseExact("1130", "HHmm", null))
                {
                    btn1130.Enabled = false;
                }
                if (DateTime.ParseExact(ds.Tables[0].Rows[i]["S_Time"].ToString(), "HH:mm:ss", null) == DateTime.ParseExact("1200", "HHmm", null))
                {
                    btn1200.Enabled = false;
                }
                if (DateTime.ParseExact(ds.Tables[0].Rows[i]["S_Time"].ToString(), "HH:mm:ss", null) == DateTime.ParseExact("1230", "HHmm", null))
                {
                    btn1230.Enabled = false;
                }
                if (DateTime.ParseExact(ds.Tables[0].Rows[i]["S_Time"].ToString(), "HH:mm:ss", null) == DateTime.ParseExact("1400", "HHmm", null))
                {
                    btn1400.Enabled = false;
                }
                if (DateTime.ParseExact(ds.Tables[0].Rows[i]["S_Time"].ToString(), "HH:mm:ss", null) == DateTime.ParseExact("1430", "HHmm", null))
                {
                    btn1430.Enabled = false;
                }
                if (DateTime.ParseExact(ds.Tables[0].Rows[i]["S_Time"].ToString(), "HH:mm:ss", null) == DateTime.ParseExact("1500", "HHmm", null))
                {
                    btn1500.Enabled = false;
                }
                if (DateTime.ParseExact(ds.Tables[0].Rows[i]["S_Time"].ToString(), "HH:mm:ss", null) == DateTime.ParseExact("1530", "HHmm", null))
                {
                    btn1530.Enabled = false;
                }
                if (DateTime.ParseExact(ds.Tables[0].Rows[i]["S_Time"].ToString(), "HH:mm:ss", null) == DateTime.ParseExact("1600", "HHmm", null))
                {
                    btn1600.Enabled = false;
                }
                if (DateTime.ParseExact(ds.Tables[0].Rows[i]["S_Time"].ToString(), "HH:mm:ss", null) == DateTime.ParseExact("1630", "HHmm", null))
                {
                    btn1630.Enabled = false;
                }

            }
        }
    }
}
