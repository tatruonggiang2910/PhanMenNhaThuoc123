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
    public partial class FormPhieuNhap : Form
    {
        public FormPhieuNhap()
        {
            InitializeComponent();
        }

        HoaDonNhapDAL_BLL _HDN = new HoaDonNhapDAL_BLL();

        private void btnXuatPN_Click(object sender, EventArgs e)
        {
            phieunhap rpt = new phieunhap();

            rpt.SetDatabaseLogon("sa", "sa2012", "DESKTOP-1N4F6N4", "QLNTTDA");
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.DisplayStatusBar = false;
            crystalReportViewer1.DisplayToolbar = true;
            cboPN.ValueMember = "MAPNT";
            rpt.SetParameterValue("LocMaPN", cboPN.SelectedValue.ToString());

        }

        private void FormPhieuNhap_Load(object sender, EventArgs e)
        {
            cboPN.DataSource = _HDN.Load_phieunhapthuoc();
            cboPN.DisplayMember = "MAPNT";
        }
    }
}
