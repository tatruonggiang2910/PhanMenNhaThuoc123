using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_BLL;

namespace Do_An_CNPM
{
    public partial class FormXuatHD : Form
    {
        public FormXuatHD()
        {
            InitializeComponent();
        }

        HoaDonBamDAL_BLL _HDB = new HoaDonBamDAL_BLL();

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            hoadon rpt = new hoadon();

            rpt.SetDatabaseLogon("sa", "sa2012", "DESKTOP-1N4F6N4", "QLNTTDA");
            
            crystalReportViewer2.ReportSource = rpt;
            crystalReportViewer2.DisplayStatusBar = false;
            crystalReportViewer2.DisplayToolbar = true;
            cboHD.ValueMember = "MAHDB";
            rpt.SetParameterValue("LocMaHDB", cboHD.SelectedValue.ToString());

        }

        private void FormXuatHD_Load(object sender, EventArgs e)
        {
            cboHD.DataSource = _HDB.Load_Hoadonban();
            cboHD.DisplayMember = "MAHDB";
        }
    }
}
