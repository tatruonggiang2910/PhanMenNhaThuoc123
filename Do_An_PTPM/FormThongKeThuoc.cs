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
    public partial class FormThongKeThuoc : Form
    {
        public FormThongKeThuoc()
        {
            InitializeComponent();
        }

        ThuocDAL_BLL _THUOC = new ThuocDAL_BLL();
        HoaDonBamDAL_BLL _HDB = new HoaDonBamDAL_BLL();
        HoaDonNhapDAL_BLL _PNT = new HoaDonNhapDAL_BLL();


        public int TongThuocBan()
        {
            int tong = 0;
            for (int i = 0; i < gvThuocBan.RowCount; i++)
            {
                if (gvThuocBan.Rows[i].Cells[5].Value != null)
                {
                    tong += Int32.Parse(gvThuocBan.Rows[i].Cells[5].Value.ToString());

                }
            }
            return tong;
        }

        public int TongThuocNhap()
        {
            int tong = 0;
            for (int i = 0; i < gvThuocNhap.RowCount; i++)
            {
                if (gvThuocNhap.Rows[i].Cells[4].Value != null)
                {
                    tong += Int32.Parse(gvThuocNhap.Rows[i].Cells[4].Value.ToString());

                }
            }
            return tong;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                gvThuocBan.DataSource = _HDB.ThongKe_ThuocBan(cbbThuoc.SelectedValue.ToString(), DTPTuNgay.Value, DTPDenNgay.Value);
                gvThuocNhap.DataSource = _PNT.ThongKe_ThuocNhap(cbbThuoc.SelectedValue.ToString(), DTPTuNgay.Value, DTPDenNgay.Value);
                txtTongThuocBan.Text = TongThuocBan().ToString();
                txtTongThuocNhap.Text = TongThuocNhap().ToString();
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu", "Thông báo");
                return;
            }
        }

        private void FormThongKeThuoc_Load(object sender, EventArgs e)
        {
            cbbThuoc.DataSource = _THUOC.Load_thuoc();
            cbbThuoc.ValueMember = "MATHUOC";
            cbbThuoc.DisplayMember = "TENTHUOC";
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            cbbThuoc.Text = DTPTuNgay.Text = DTPDenNgay.Text = txtTongThuocNhap.Text = txtTongThuocBan.Text = string.Empty;
            gvThuocBan.DataSource = gvThuocNhap.DataSource = null;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
