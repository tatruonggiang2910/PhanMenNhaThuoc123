namespace Do_An_CNPM
{
    partial class FormXuatHD
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.cboHD = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnXuatHD = new DevComponents.DotNetBar.ButtonX();
            this.crystalReportViewer2 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelX1.Location = new System.Drawing.Point(39, 26);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(120, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Mã hóa đơn";
            // 
            // cboHD
            // 
            this.cboHD.DisplayMember = "Text";
            this.cboHD.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboHD.FormattingEnabled = true;
            this.cboHD.ItemHeight = 16;
            this.cboHD.Location = new System.Drawing.Point(190, 26);
            this.cboHD.Name = "cboHD";
            this.cboHD.Size = new System.Drawing.Size(121, 22);
            this.cboHD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboHD.TabIndex = 1;
            // 
            // btnXuatHD
            // 
            this.btnXuatHD.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXuatHD.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXuatHD.Location = new System.Drawing.Point(345, 16);
            this.btnXuatHD.Name = "btnXuatHD";
            this.btnXuatHD.Size = new System.Drawing.Size(75, 41);
            this.btnXuatHD.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXuatHD.TabIndex = 2;
            this.btnXuatHD.Text = "Xuất HD";
            this.btnXuatHD.Click += new System.EventHandler(this.btnXuatHD_Click);
            // 
            // crystalReportViewer2
            // 
            this.crystalReportViewer2.ActiveViewIndex = -1;
            this.crystalReportViewer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer2.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer2.Location = new System.Drawing.Point(12, 74);
            this.crystalReportViewer2.Name = "crystalReportViewer2";
            this.crystalReportViewer2.Size = new System.Drawing.Size(1547, 644);
            this.crystalReportViewer2.TabIndex = 7;
            // 
            // FormXuatHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1571, 730);
            this.Controls.Add(this.crystalReportViewer2);
            this.Controls.Add(this.cboHD);
            this.Controls.Add(this.btnXuatHD);
            this.Controls.Add(this.labelX1);
            this.Name = "FormXuatHD";
            this.Text = "FormXuatHD";
            this.Load += new System.EventHandler(this.FormXuatHD_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboHD;
        private DevComponents.DotNetBar.ButtonX btnXuatHD;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer2;
    }
}