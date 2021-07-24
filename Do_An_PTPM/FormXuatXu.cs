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
    public partial class FormXuatXu : Form
    {
        XuatXuDAL_BLL XX= new XuatXuDAL_BLL();
        public FormXuatXu()
        {
            InitializeComponent();
        }

        private void FormXuatXu_Load(object sender, EventArgs e)
        {
            if (DangNhap.nv.MANHOMNV == "NV")
            {
                btnSua.Enabled = btnTaoMoi.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            }
           GVXuatXu.DataSource = XX.load_XX();
        }
               public void TangMaTuDong_matXX()
        {

            string g = "";
            string a = "";
            a = GVXuatXu.Rows[GVXuatXu.Rows.Count - 1].Cells[0].Value.ToString();

            int ma;
            g = "XX";
            ma = Convert.ToInt32(a.Substring(2, 2));
            ma = ma + 1;
            if (ma < 10)
                g = g + "0";
            if (ma >= 10)
                g = g + "";
            g += ma.ToString();

            txtMaXuatXu.Text = g;

        }
        private void GVXuatXu_Click(object sender, EventArgs e)
        {
         try
            {
                txtMaXuatXu.Text = GVXuatXu.CurrentRow.Cells[0].Value.ToString();
                txtTenXuatXu.Text = GVXuatXu.CurrentRow.Cells[1].Value.ToString();
                txtLoaiXuatXu.Text = GVXuatXu.CurrentRow.Cells[2].Value.ToString();

            }
            catch
            { }
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
          TangMaTuDong_matXX();
            txtLoaiXuatXu.Text = string.Empty;
            txtTenXuatXu.Text = string.Empty;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
         try
            {

                XX.Them_XX(txtMaXuatXu.Text, txtTenXuatXu.Text, txtLoaiXuatXu.Text);
                MessageBox.Show("Thêm dữ liệu  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GVXuatXu.DataSource = XX.load_XX();

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
                if (XX.Xoa_XX(txtMaXuatXu.Text) == 1)
                {
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVXuatXu.DataSource = XX.load_XX();
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

        private void btnSua_Click(object sender, EventArgs e)
        {
         try
            {
                if (XX.Sua(txtMaXuatXu.Text,txtTenXuatXu.Text,txtLoaiXuatXu.Text) == 1)
                {
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVXuatXu.DataSource = XX.load_XX();
                }
                else
                {
                    MessageBox.Show("Sửa dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //Ke.Sua(txtMaKe.Text, txtTenKe.Text);
                //MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //GVKeThuoc.DataSource = Ke.load_KeThuoc();             
            }
            catch
            {

            } 
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
