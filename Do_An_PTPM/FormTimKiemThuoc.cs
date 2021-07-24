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
    public partial class FormTimKiemThuoc : Form
    {
        public FormTimKiemThuoc()
        {
            InitializeComponent();
        }

        ThuocDAL_BLL _THUOC = new ThuocDAL_BLL();

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (ckma.Value)
            {
                Gv_Thuoc.DataSource = _THUOC.search_MaThuoc(txtMaThuoc.Text);
            }
            if (ckngaysx.Value)
            {
                Gv_Thuoc.DataSource = _THUOC.search_NgaySX(DTNgaySX.Value);
            }
            if (ckcongdung.Value)
            {
                Gv_Thuoc.DataSource = _THUOC.search_congDung(txtCongDung.Text);
            }
            if (ckten.Value)
            {
                Gv_Thuoc.DataSource = _THUOC.search_tenThuoc(txtTenThuoc.Text);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ckcongdung.Value = ckma.Value = ckngaysx.Value = ckten.Value = false;
            txtMaThuoc.Text = txtTenThuoc.Text = txtCongDung.Text = DTNgaySX.Text  = string.Empty;
            Gv_Thuoc.DataSource = _THUOC.Load_thuoc();
        }

        private void FormTimKiemThuoc_Load(object sender, EventArgs e)
        {
            Gv_Thuoc.DataSource = _THUOC.Load_thuoc();
        }

        private void ckma_ValueChanged(object sender, EventArgs e)
        {
            if (ckma.Value)
                txtMaThuoc.Enabled = true;
            else
                txtMaThuoc.Enabled = false;
        }

        private void ckten_ValueChanged(object sender, EventArgs e)
        {
            if (ckten.Value)
                txtTenThuoc.Enabled = true;
            else
                txtTenThuoc.Enabled = false;
        }

        private void ckcongdung_ValueChanged(object sender, EventArgs e)
        {
            if (ckcongdung.Value)
                txtCongDung.Enabled = true;
            else
                txtCongDung.Enabled = false;
        }

        private void ckngaysx_ValueChanged(object sender, EventArgs e)
        {
            if (ckngaysx.Value)
                DTNgaySX.Enabled = true;
            else
                DTNgaySX.Enabled = false;
        }
    }
}
