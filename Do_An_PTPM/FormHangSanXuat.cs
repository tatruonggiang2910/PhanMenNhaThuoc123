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
    public partial class FormHangSanXuat : Form
    {
        HangSXuatDAL_BLL HSX = new HangSXuatDAL_BLL();
        public FormHangSanXuat()
        {
            InitializeComponent();
        }

        private void FormHangSanXuat_Load(object sender, EventArgs e)
        {
            if (DangNhap.nv.MANHOMNV == "NV")
            {
                btnSua.Enabled = btnThem.Enabled = btnXoa.Enabled = btnTaoMoi.Enabled = false;
            }
            GVHangSX.DataSource = HSX.load_HangSX();
        }

        private void GVHangSX_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaHangSX.Text = GVHangSX.CurrentRow.Cells[0].Value.ToString();
                txtTenHangSX.Text = GVHangSX.CurrentRow.Cells[1].Value.ToString();

            }
            catch
            { }
        }
        public void TangMaTuDong_mathuoc()
        {

            string g = "";
            string a = "";
            a = GVHangSX.Rows[GVHangSX.Rows.Count - 1].Cells[0].Value.ToString();

            int ma;
            g = "HSX";
            ma = Convert.ToInt32(a.Substring(3, 2));
            ma = ma + 1;
            if (ma < 10)
                g = g + "0";
            if (ma >= 10)
                g = g + "";
            g += ma.ToString();

            txtMaHangSX.Text = g;

        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            TangMaTuDong_mathuoc();
            txtTenHangSX.Text = string.Empty;
            txtTenHangSX.Enabled = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                HSX.Them_hangsx(txtMaHangSX.Text, txtTenHangSX.Text);
                MessageBox.Show("Thêm dữ liệu  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GVHangSX.DataSource = HSX.load_HangSX();

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
                if (HSX.Xoa_hangsx(txtMaHangSX.Text) == 1)
                {
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVHangSX.DataSource = HSX.load_HangSX();
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
                if (HSX.Sua(txtMaHangSX.Text, txtTenHangSX.Text) == 1)
                {
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVHangSX.DataSource = HSX.load_HangSX();
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
