namespace Hospital
{
    partial class Receptionist
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Receptionist));
            this.btnPat = new System.Windows.Forms.Button();
            this.btnCab = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.welMsg = new System.Windows.Forms.Label();
            this.btnDoc = new System.Windows.Forms.Button();
            this.btnApt = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPat
            // 
            this.btnPat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPat.BackColor = System.Drawing.Color.SteelBlue;
            this.btnPat.FlatAppearance.BorderSize = 0;
            this.btnPat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPat.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnPat.Location = new System.Drawing.Point(386, 161);
            this.btnPat.Name = "btnPat";
            this.btnPat.Size = new System.Drawing.Size(319, 50);
            this.btnPat.TabIndex = 2;
            this.btnPat.Text = "Manage Patients";
            this.btnPat.UseVisualStyleBackColor = false;
            this.btnPat.Click += new System.EventHandler(this.btnPat_Click);
            // 
            // btnCab
            // 
            this.btnCab.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCab.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCab.FlatAppearance.BorderSize = 0;
            this.btnCab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCab.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnCab.Location = new System.Drawing.Point(386, 217);
            this.btnCab.Name = "btnCab";
            this.btnCab.Size = new System.Drawing.Size(319, 50);
            this.btnCab.TabIndex = 3;
            this.btnCab.Text = "Manage Cabins";
            this.btnCab.UseVisualStyleBackColor = false;
            this.btnCab.Click += new System.EventHandler(this.btnRoom_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnLogout.Location = new System.Drawing.Point(534, 329);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(171, 50);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // welMsg
            // 
            this.welMsg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.welMsg.BackColor = System.Drawing.Color.Transparent;
            this.welMsg.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welMsg.ForeColor = System.Drawing.Color.SteelBlue;
            this.welMsg.Location = new System.Drawing.Point(386, 9);
            this.welMsg.Name = "welMsg";
            this.welMsg.Size = new System.Drawing.Size(319, 93);
            this.welMsg.TabIndex = 5;
            this.welMsg.Text = "Welcome <PlaceHolder>";
            this.welMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDoc
            // 
            this.btnDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoc.BackColor = System.Drawing.Color.SteelBlue;
            this.btnDoc.FlatAppearance.BorderSize = 0;
            this.btnDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoc.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnDoc.Location = new System.Drawing.Point(386, 273);
            this.btnDoc.Name = "btnDoc";
            this.btnDoc.Size = new System.Drawing.Size(319, 50);
            this.btnDoc.TabIndex = 1;
            this.btnDoc.Text = "Doctor Information";
            this.btnDoc.UseVisualStyleBackColor = false;
            this.btnDoc.Click += new System.EventHandler(this.btnDoc_Click);
            // 
            // btnApt
            // 
            this.btnApt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApt.BackColor = System.Drawing.Color.SteelBlue;
            this.btnApt.FlatAppearance.BorderSize = 0;
            this.btnApt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApt.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnApt.Location = new System.Drawing.Point(386, 105);
            this.btnApt.Name = "btnApt";
            this.btnApt.Size = new System.Drawing.Size(319, 50);
            this.btnApt.TabIndex = 6;
            this.btnApt.Text = "Manage Appointments";
            this.btnApt.UseVisualStyleBackColor = false;
            this.btnApt.Click += new System.EventHandler(this.btnApt_Click);
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.BackgroundImage = global::Hospital.Properties.Resources.recLogo;
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picLogo.Location = new System.Drawing.Point(12, 76);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(368, 230);
            this.picLogo.TabIndex = 15;
            this.picLogo.TabStop = false;
            // 
            // Receptionist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(717, 391);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.btnApt);
            this.Controls.Add(this.welMsg);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnCab);
            this.Controls.Add(this.btnPat);
            this.Controls.Add(this.btnDoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Receptionist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receptionist Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Receptionist_FormClosing);
            this.Load += new System.EventHandler(this.Receptionist_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPat;
        private System.Windows.Forms.Button btnCab;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label welMsg;
        private System.Windows.Forms.Button btnDoc;
        private System.Windows.Forms.Button btnApt;
        private System.Windows.Forms.PictureBox picLogo;
    }
}