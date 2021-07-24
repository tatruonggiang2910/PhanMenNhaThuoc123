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
    public partial class DangNhap : Form
    {

        NhanVienDALBLL NV = new NhanVienDALBLL();
        public static NHANVIEN nv;

        public DangNhap()
        {
            InitializeComponent();
        }

      

        private void txtMK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.pictureBox5_Click(sender, e);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            List<NHANVIEN> list = NV.checkDangNhap(txtTenDN.Text, txtMK.Text);
            if (list.Any())
            {
                foreach (NHANVIEN item in list)
                {
                    nv = item;
                }
                MessageBox.Show("Dang nhap thanh cong");
                FormTrangChu newForm = new FormTrangChu();
                newForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Vui long kiem tra lai");
                return;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txtMK.UseSystemPasswordChar = !txtMK.UseSystemPasswordChar;
        }

   
    }
}
