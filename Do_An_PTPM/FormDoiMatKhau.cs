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
    public partial class FormDoiMatKhau : Form
    {
        public FormDoiMatKhau()
        {
            InitializeComponent();
        }

        NHANVIEN NvLog = DangNhap.nv;
        DangNhap dangnhap = new DangNhap();
        NhanVienDALBLL nv = new NhanVienDALBLL();
        FormTrangChu trangchu = new FormTrangChu();

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            //Kiểm tra ô nhập giá trị
            if (String.IsNullOrEmpty(txtMatKhauHT.Text) || String.IsNullOrEmpty(txtMatKhauMoi.Text) || String.IsNullOrEmpty(txtXNMatKhauMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ giá trị !", "Thông báo");
                return;
            }

            if (nv.kiemTraTk(NvLog.TENDANGNHAP, txtMatKhauHT.Text))
            {
                if (txtMatKhauMoi.Text == txtXNMatKhauMoi.Text)
                {
                    if (txtMatKhauHT.Text == txtMatKhauMoi.Text)
                    {
                        MessageBox.Show("Mật khẩu mới và mật khẩu hiện tại không được trùng nhau !", "Thông báo");
                        txtMatKhauMoi.Focus();
                        return;
                    }

                    if (nv.doiMatKhau(NvLog.TENDANGNHAP, txtMatKhauMoi.Text))
                    {
                        MessageBox.Show("Đổi mật khẩu thành công !", "Thông báo");
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Đổi thất bại", "Thông báo");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới phải trùng khớp với mật khẩu xác nhận !", "Thông báo");
                    txtMatKhauMoi.Focus();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu hiện tại sai. Vui lòng nhập lại !", "Thông báo");
                txtMatKhauHT.Focus();
                return;
            }
        }

        private void FormDoiMatKhau_Load(object sender, EventArgs e)
        {
            textBoxX1.Text = NvLog.TENDANGNHAP.ToString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txtMatKhauHT.UseSystemPasswordChar = !txtMatKhauHT.UseSystemPasswordChar;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtMatKhauMoi.UseSystemPasswordChar = !txtMatKhauMoi.UseSystemPasswordChar;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtXNMatKhauMoi.UseSystemPasswordChar = !txtXNMatKhauMoi.UseSystemPasswordChar;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
