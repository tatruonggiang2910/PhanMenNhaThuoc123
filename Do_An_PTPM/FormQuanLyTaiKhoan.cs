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
    public partial class FormQuanLyTaiKhoan : Form
    {
        public FormQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        NhanVienDALBLL _NV = new NhanVienDALBLL();
        PhanQuyenDAL_BLL _PQ = new PhanQuyenDAL_BLL();
        private void FormQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            cbbMaNhanVien.DataSource = _NV.getNhanVien();
            cbbMaNhanVien.DisplayMember = "HOTENNV";
            cbbMaNhanVien.ValueMember = "MANV";

            cbbMaNhomNV.DataSource = _NV.getNhomNV();
            cbbMaNhomNV.DisplayMember = "TENNHOM";
            cbbMaNhomNV.ValueMember = "MANHOMNV";

            cbbQuyen.DataSource = _NV.getNhomNV();
            cbbQuyen.DisplayMember = "TENNHOM";
            cbbQuyen.ValueMember = "MANHOMNV";
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (_PQ.capNhatNhomQuyen(cbbMaNhanVien.SelectedValue.ToString(), cbbMaNhomNV.SelectedValue.ToString()))
            {
                MessageBox.Show("Thay đổi quyền thành công!", "Thông báo");
                return;
            }
            else
            {
                MessageBox.Show("Thay đổi quyền thất bại!", "Thông báo");
                return;
            }
        }

        private void cbbMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbQuyen_SelectedIndexChanged(object sender, EventArgs e)
        {
            Gv_QuyenKhongDuoc.DataSource = _PQ.load_QuyenChuaCo(cbbQuyen.SelectedValue.ToString());
            Gv_QuyenDuoc.DataSource = _PQ.load_QuyenCo(cbbQuyen.SelectedValue.ToString());
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (Gv_QuyenKhongDuoc.SelectedRows.Count > 0)
            {
                _PQ.themQuyen("NV", Gv_QuyenKhongDuoc.CurrentRow.Cells[0].Value.ToString());
                Gv_QuyenKhongDuoc.DataSource = _PQ.load_QuyenChuaCo(cbbQuyen.SelectedValue.ToString());
                Gv_QuyenDuoc.DataSource = _PQ.load_QuyenCo(cbbQuyen.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Vui lòng chọn danh mục màn hình!", "Thông báo");
                return;
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            if (Gv_QuyenDuoc.SelectedRows.Count > 0)
            {
                _PQ.xoaQuyen("NV", Gv_QuyenDuoc.CurrentRow.Cells[0].Value.ToString());
                Gv_QuyenKhongDuoc.DataSource = _PQ.load_QuyenChuaCo(cbbQuyen.SelectedValue.ToString());
                Gv_QuyenDuoc.DataSource = _PQ.load_QuyenCo(cbbQuyen.SelectedValue.ToString());
            }
            else
            {
                MessageBox.Show("Vui lòng chọn danh mục màn hình!", "Thông báo");
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
