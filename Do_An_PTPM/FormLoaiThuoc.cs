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
    public partial class FormLoaiThuoc : Form
    {
        public FormLoaiThuoc()
        {
            InitializeComponent();
        }
        KeThuocDAL_BLL KE = new KeThuocDAL_BLL();
        LoaiThuocDAL_BLL LT = new LoaiThuocDAL_BLL();
        private void FormLoaiThuoc_Load(object sender, EventArgs e)
        {
            if (DangNhap.nv.MANHOMNV == "NV")
            {
                btnSua.Enabled = btnTaoMoi.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            }
            GVLoaiThuoc.DataSource = LT.load_Loai_Thuoc();
            cbbmake.DataSource = KE.load_KeThuoc();
            cbbmake.DisplayMember = "make";
            cbbmake.ValueMember = "make";
        }

        private void GVLoaiThuoc_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaLoaiThuoc.Text = GVLoaiThuoc.CurrentRow.Cells[0].Value.ToString();
                cbbmake.Text = GVLoaiThuoc.CurrentRow.Cells[1].Value.ToString();
                txtTenLoaiThuoc.Text = GVLoaiThuoc.CurrentRow.Cells[2].Value.ToString();

            }
            catch
            { }
        }
        public void TangMaTuDong_mathuoc()
        {

            string g = "";
            string a = "";
            a = GVLoaiThuoc.Rows[GVLoaiThuoc.Rows.Count - 1].Cells[0].Value.ToString();

            int ma;
            g = "L";
            ma = Convert.ToInt32(a.Substring(1, 3));
            ma = ma + 1;
            if (ma < 10)
                g = g + "00";
            if (ma >= 10)
                g = g + "0";
            g += ma.ToString();

            txtMaLoaiThuoc.Text = g;

        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            TangMaTuDong_mathuoc();
            txtTenLoaiThuoc.Text = string.Empty;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                LT.Them_Loai(txtMaLoaiThuoc.Text, txtTenLoaiThuoc.Text, cbbmake.SelectedValue.ToString());
                MessageBox.Show("Thêm dữ liệu  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GVLoaiThuoc.DataSource = LT.load_Loai_Thuoc();

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
                if (LT.Xoa_loai(txtMaLoaiThuoc.Text) == 1)
                {
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVLoaiThuoc.DataSource = LT.load_Loai_Thuoc();
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
                if (LT.Sua(txtMaLoaiThuoc.Text, cbbmake.SelectedValue.ToString(), txtTenLoaiThuoc.Text) == 1)
                {
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVLoaiThuoc.DataSource = LT.load_Loai_Thuoc();
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

        private void buttonX2_Click(object sender, EventArgs e)
        {
            FormKeThuoc newForm = new FormKeThuoc();
            newForm.Show();
        }
    }
}
