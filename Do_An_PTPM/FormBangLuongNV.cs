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
    public partial class FormBangLuongNV : Form
    {
        NhanVienDALBLL NV = new NhanVienDALBLL();
        BangLuongDAL_BLL BL = new BangLuongDAL_BLL();
        public FormBangLuongNV()
        {
            InitializeComponent();
        }

        private void FormBangLuongNV_Load(object sender, EventArgs e)
        {
            load_manv();
            GVBangLuong.DataSource = BL.loadluong();
        }
        private void load_manv()
        {
            cbbMaNhanVien.DataSource = NV.load_manv();
            cbbMaNhanVien.DisplayMember = "MANV";
        }
        private void load()
        {

            foreach (var q in BL.load_ten(cbbMaNhanVien.Text))
            {
                txtHoTenNhanVien.Text = q.ToString();
            }
            foreach (var q in BL.load_luongcb(cbbMaNhanVien.Text))
            {
                txtMuccLuongCoBan.Text = q.ToString();
            }
            foreach (double q in BL.load_HeSoLuong(cbbMaNhanVien.Text))
            {
                txtHeSoLuong.Text = q.ToString();
            }

            foreach (var q in BL.load_tungay(cbbMaNhanVien.Text))
            {
                DTPTuNgay.Text = q.ToString();
            }
            foreach (var q in BL.load_denngay(cbbMaNhanVien.Text))
            {
                DTPDenNgay.Text = q.ToString();
            }
        }

        private void cbbMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            load();
            try
            {
                decimal tinhtien;
                decimal luong = decimal.Parse(txtMuccLuongCoBan.Text);
                decimal hs = decimal.Parse(txtHeSoLuong.Text);
                tinhtien = hs * luong;
                txtLuongThucTe.Text = tinhtien.ToString();
            }
            catch
            { }    
        }
        public void TangMaTuDong_bangluong()
        {

            string g = "";
            string a = "";
            a = GVBangLuong.Rows[GVBangLuong.Rows.Count - 1].Cells[0].Value.ToString();


            int ma;
            g = "BL";
            ma = Convert.ToInt32(a.Substring(2, 2));
            ma = ma + 1;
            if (ma < 10)
                g = g + "0";
            if (ma >= 10)
                g = g + "";
            g += ma.ToString();

            txtMaBangLuong.Text = g;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            try
            {

                BL.Them_bangluong(txtMaBangLuong.Text, cbbMaNhanVien.Text, decimal.Parse(txtLuongThucTe.Text), DateTime.Parse(DTPNgayApDung.Text), txtGhiChu.Text);
                MessageBox.Show("Thêm dữ liệu  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GVBangLuong.DataSource = BL.loadluong();

            }
            catch
            {
                MessageBox.Show("Thêm dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            try
            {
                if (BL.Xoa_bangluong(txtMaBangLuong.Text) == 1)
                {
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVBangLuong.DataSource = BL.loadluong();
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Xoá dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            TangMaTuDong_bangluong();
            cbbMaNhanVien.Text = string.Empty;
            txtHoTenNhanVien.Text = string.Empty;
            txtHeSoLuong.Text = string.Empty;
            DTPNgayApDung.Text = string.Empty;
            txtMuccLuongCoBan.Text = string.Empty;
            txtLuongThucTe.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            DTPTuNgay.Text = string.Empty;
            DTPDenNgay.Text = string.Empty;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (BL.Sua_bangluong(txtMaBangLuong.Text, DateTime.Parse(DTPNgayApDung.Text), txtGhiChu.Text) == 1)
            {
                MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GVBangLuong.DataSource = BL.loadluong();
            }
            else
            {
                MessageBox.Show("Sửa dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GVBangLuong_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaBangLuong.Text = GVBangLuong.CurrentRow.Cells[0].Value.ToString();
                cbbMaNhanVien.Text = GVBangLuong.CurrentRow.Cells[1].Value.ToString();
                txtLuongThucTe.Text = GVBangLuong.CurrentRow.Cells[2].Value.ToString();
                DTPNgayApDung.Text = GVBangLuong.CurrentRow.Cells[3].Value.ToString();
                txtGhiChu.Text = GVBangLuong.CurrentRow.Cells[4].Value.ToString();

            }
            catch
            { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
