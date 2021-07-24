namespace Do_An_CNPM
{
    partial class FormPhieuNhap
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
            this.cboPN = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnXuatPN = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // cboPN
            // 
            this.cboPN.DisplayMember = "Text";
            this.cboPN.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPN.FormattingEnabled = true;
            this.cboPN.ItemHeight = 16;
            this.cboPN.Location = new System.Drawing.Point(189, 29);
            this.cboPN.Name = "cboPN";
            this.cboPN.Size = new System.Drawing.Size(121, 22);
            this.cboPN.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboPN.TabIndex = 4;
            // 
            // btnXuatPN
            // 
            this.btnXuatPN.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnXuatPN.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnXuatPN.Location = new System.Drawing.Point(344, 19);
            this.btnXuatPN.Name = "btnXuatPN";
            this.btnXuatPN.Size = new System.Drawing.Size(75, 41);
            this.btnXuatPN.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnXuatPN.TabIndex = 5;
            this.btnXuatPN.Text = "Xuất PN";
            this.btnXuatPN.Click += new System.EventHandler(this.btnXuatPN_Click);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.labelX1.Location = new System.Drawing.Point(38, 29);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(145, 23);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "Mã phiếu nhập";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(13, 78);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1533, 649);
            this.crystalReportViewer1.TabIndex = 6;
            // 
            // FormPhieuNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1558, 739);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.cboPN);
            this.Controls.Add(this.btnXuatPN);
            this.Controls.Add(this.labelX1);
            this.Name = "FormPhieuNhap";
            this.Text = "FormPhieuNhap";
            this.Load += new System.EventHandler(this.FormPhieuNhap_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.ComboBoxEx cboPN;
        private DevComponents.DotNetBar.ButtonX btnXuatPN;
        private DevComponents.DotNetBar.LabelX labelX1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
    }
}