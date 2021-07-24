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
    public partial class FormKeThuoc : Form
    {
        KeThuocDAL_BLL Ke = new KeThuocDAL_BLL();
        public FormKeThuoc()
        {
            InitializeComponent();
        }
        public void TangMaTuDong_make()
        {

            string g = "";
            string a = "";
            a = GVKeThuoc.Rows[GVKeThuoc.Rows.Count - 1].Cells[0].Value.ToString();

            int ma;
            g = "K";
            ma = Convert.ToInt32(a.Substring(1, 1));
            ma = ma + 1;
            if (ma < 10)
                g = g + "";
            if (ma >= 10)
                g = g + "0";
            g += ma.ToString();

            txtMaKe.Text = g;

        }

        private void FormKeThuoc_Load(object sender, EventArgs e)
        {
            if (DangNhap.nv.MANHOMNV == "NV")
            {
                btnSua.Enabled = btnTaoMoi.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            }
            GVKeThuoc.DataSource = Ke.load_KeThuoc();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            TangMaTuDong_make();
            txtTenKe.Text = string.Empty;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                Ke.Them_KE(txtMaKe.Text, txtTenKe.Text);
                MessageBox.Show("Thêm dữ liệu  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GVKeThuoc.DataSource = Ke.load_KeThuoc();

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
                if (Ke.Xoa_Bac(txtMaKe.Text) == 1)
                {
                    MessageBox.Show("Xoá dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVKeThuoc.DataSource = Ke.load_KeThuoc();
                }
                else
                {
                    MessageBox.Show("Xoá dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (Ke.Sua(txtTenKe.Text) == 1)
                {
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVKeThuoc.DataSource = Ke.load_KeThuoc();
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

        private void GVKeThuoc_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaKe.Text = GVKeThuoc.CurrentRow.Cells[0].Value.ToString();
                txtTenKe.Text = GVKeThuoc.CurrentRow.Cells[1].Value.ToString();


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
