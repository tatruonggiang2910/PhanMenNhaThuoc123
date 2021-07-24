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
    public partial class FormTimKiemNhanVien : Form
    {
        public FormTimKiemNhanVien()
        {
            InitializeComponent();
        }

        NhanVienDALBLL _NV = new NhanVienDALBLL();

        private void FormTimKiemNhanVien_Load(object sender, EventArgs e)
        {
            GvNhanVien.DataSource = _NV.load_NV_Search();
            //===============================================//
            cbbMaNhom.DataSource = _NV.getNhomNV();
            cbbMaNhom.DisplayMember = "TENNHOM";
            cbbMaNhom.ValueMember = "MANHOMNV";
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            checkMaNhanVien.Value = checkMaNhom.Value = checkNgayBatDau.Value = checkHoTen.Value = checkGioiTinh.Value = false;
            txtMaNhanVien.Text = cbbMaNhom.Text = DTPNgayBD.Text = txtHoTen.Text = cbbGioiTinh.Text = string.Empty;
            GvNhanVien.DataSource = _NV.load_NV_Search();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //Tìm theo mã nhân viên
            if (checkMaNhanVien.Value)
            {
                GvNhanVien.DataSource = _NV.search_MaNV(txtMaNhanVien.Text);
            }
            //Tìm kiếm theo tên
            if (checkHoTen.Value)
            {
                GvNhanVien.DataSource = _NV.search_HoTen(txtHoTen.Text);
            }
            //Tìm kiếm theo ngày bắt đầu làm
            if (checkNgayBatDau.Value)
            {
                GvNhanVien.DataSource = _NV.search_NgayBDL(DTPNgayBD.Value);
            }
            //Tìm theo giới tính
            if (checkGioiTinh.Value)
            {
                GvNhanVien.DataSource = _NV.search_GioiTinh(cbbGioiTinh.SelectedItem.ToString());
            }
            //Tìm theo mã nhóm
            if (checkMaNhom.Value)
            {
                GvNhanVien.DataSource = _NV.search_MaNhom(cbbMaNhom.SelectedValue.ToString());
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkMaNhanVien_ValueChanged(object sender, EventArgs e)
        {
            if (checkMaNhanVien.Value)
                txtMaNhanVien.Enabled = true;
            else
                txtMaNhanVien.Enabled = false;
        }

        private void checkHoTen_ValueChanged(object sender, EventArgs e)
        {
            if (checkHoTen.Value)
                txtHoTen.Enabled = true;
            else
                txtHoTen.Enabled = false;
        }

        private void checkMaNhom_ValueChanged(object sender, EventArgs e)
        {
            if (checkMaNhom.Value)
                cbbMaNhom.Enabled = true;
            else
                cbbMaNhom.Enabled = false;
        }

        private void checkNgayBatDau_ValueChanged(object sender, EventArgs e)
        {
            if (checkNgayBatDau.Value)
                DTPNgayBD.Enabled = true;
            else
                DTPNgayBD.Enabled = false;
        }

        private void checkGioiTinh_ValueChanged(object sender, EventArgs e)
        {
            if (checkGioiTinh.Value)
                cbbGioiTinh.Enabled = true;
            else
                cbbGioiTinh.Enabled = false;
        }
    }
}
