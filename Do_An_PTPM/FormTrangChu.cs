using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DAL_BLL;

namespace Do_An_CNPM
{
    public partial class FormTrangChu : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public FormTrangChu()
        {
            InitializeComponent();

        }

        DangNhap dn = new DangNhap();
        private void buttonItem19_Click(object sender, EventArgs e)
        {
            FormThuoc vl = new FormThuoc();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem28_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            FormBanHang vl = new FormBanHang();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            FormNhapThuoc vl = new FormNhapThuoc();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            FormNhanVien vl = new FormNhanVien();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            FormKhachHang vl = new FormKhachHang();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem35_Click(object sender, EventArgs e)
        {
            FormQuanLyTaiKhoan vl = new FormQuanLyTaiKhoan();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            FormNhanVien vl = new FormNhanVien();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem18_Click(object sender, EventArgs e)
        {
            FormBangLuongNV vl = new FormBangLuongNV();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }





        private void buttonItem31_Click(object sender, EventArgs e)
        {
            FormBanHang vl = new FormBanHang();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem34_Click(object sender, EventArgs e)
        {
            FormNhapThuoc vl = new FormNhapThuoc();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem36_Click(object sender, EventArgs e)
        {
            FormTimKiemNhanVien vl = new FormTimKiemNhanVien();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }


        private void buttonItem40_Click(object sender, EventArgs e)
        {
            FormThongKeHoaDon vl = new FormThongKeHoaDon();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void buttonItem39_Click(object sender, EventArgs e)
        {
            FormLoaiThuoc lt = new FormLoaiThuoc();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            lt.TopLevel = false;
            lt.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(lt);
            lt.Show();
        }

        private void ribbonBar9_ItemClick(object sender, EventArgs e)
        {
            FormBacLuong lt = new FormBacLuong();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            lt.TopLevel = false;
            lt.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(lt);
            lt.Show();
        }

        private void ribbonBar20_ItemClick(object sender, EventArgs e)
        {
            FormChamCong vl = new FormChamCong();
            if (DangNhap.nv.MANHOMNV == "NV")
                ribbonBar20.Enabled = false;
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void ribbonBar21_ItemClick(object sender, EventArgs e)
        {
            FormThuoc vl = new FormThuoc();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void ribbonBar22_ItemClick(object sender, EventArgs e)
        {
            FormNhaCC vl = new FormNhaCC();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void ribbonBar23_ItemClick(object sender, EventArgs e)
        {
            FormXuatXu vl = new FormXuatXu();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void ribbonBar24_ItemClick(object sender, EventArgs e)
        {
            FormTinhThanh_QuanHuyen vl = new FormTinhThanh_QuanHuyen();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void ribbonBar27_ItemClick(object sender, EventArgs e)
        {
            FormHangSanXuat vl = new FormHangSanXuat();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void ribbonBar28_ItemClick(object sender, EventArgs e)
        {
            FormKeThuoc vl = new FormKeThuoc();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void ribbonBar25_ItemClick(object sender, EventArgs e)
        {
            FormKhachHang vl = new FormKhachHang();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            vl.TopLevel = false;
            vl.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(vl);
            vl.Show();
        }

        private void ribbonBar1_ItemClick(object sender, EventArgs e)
        {
            FormLoaiThuoc lt = new FormLoaiThuoc();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            lt.TopLevel = false;
            lt.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(lt);
            lt.Show();
        }

        private void ribbonBar26_ItemClick(object sender, EventArgs e)
        {

        }

        private void ribbonBar3_ItemClick(object sender, EventArgs e)
        {
            FormDoiMatKhau lt = new FormDoiMatKhau();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            lt.TopLevel = false;
            lt.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(lt);
            lt.Show();
        }

        private void ribbonBar10_ItemClick(object sender, EventArgs e)
        {
            FormTimKiemThuoc lt = new FormTimKiemThuoc();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            lt.TopLevel = false;
            lt.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(lt);
            lt.Show();
        }

        private void ribbonBar11_ItemClick(object sender, EventArgs e)
        {
            FormTimKiemNhanVien lt = new FormTimKiemNhanVien();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            lt.TopLevel = false;
            lt.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(lt);
            lt.Show();
        }

        private void ribbonBar13_ItemClick(object sender, EventArgs e)
        {
            FormSoLuongTon lt = new FormSoLuongTon();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            lt.TopLevel = false;
            lt.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(lt);
            lt.Show();
        }

        private void ribbonBar14_ItemClick(object sender, EventArgs e)
        {
            FormThongKeThuoc lt = new FormThongKeThuoc();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            lt.TopLevel = false;
            lt.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(lt);
            lt.Show();
        }

        private void ribbonBar2_ItemClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.No)
            {
                this.Hide();
                dn.Show();
            }
        }


        private void ribbonBar6_ItemClick(object sender, EventArgs e)
        {

        }

        PhanQuyenDAL_BLL _PQ = new PhanQuyenDAL_BLL();

        private void FormTrangChu_Load(object sender, EventArgs e)
        {
            List<PHANQUYEN> lst_pq = _PQ.load_QuyenChuaCo1(DangNhap.nv.MANHOMNV);
            string maCheck = "";
            labelItem1.Text = "Xin Chào, " + DangNhap.nv.HOTENNV;
            foreach (RibbonBar item in ribbonPanel2.Controls)
            {
                maCheck = item.Tag.ToString();
                if (lst_pq.Any(t => t.MADMMH == maCheck))
                {
                    item.Visible = false;
                }
            }
            foreach (RibbonBar item in ribbonPanel3.Controls)
            {
                maCheck = item.Tag.ToString();
                if (lst_pq.Any(t => t.MADMMH == maCheck))
                {
                    item.Visible = false;
                }
            }
            foreach (RibbonBar item in ribbonPanel4.Controls)
            {
                maCheck = item.Tag.ToString();
                if (lst_pq.Any(t => t.MADMMH == maCheck))
                {
                    item.Visible = false;
                }
            }
            foreach (ButtonItem item in explorerBarGroupItem1.SubItems)
            {
                maCheck = item.Tag.ToString();
                if (lst_pq.Any(t => t.MADMMH == maCheck))
                {
                    item.Visible = false;
                }
            }
        }

        private void ribbonTabItem4_Click(object sender, EventArgs e)
        {

        }

        private void ribbonBar17_ItemClick(object sender, EventArgs e)
        {
            FormTroGiupNguoiDung lt = new FormTroGiupNguoiDung();
            pictureBox1.Show();
            pictureBox1.Controls.Clear();
            lt.TopLevel = false;
            lt.Dock = DockStyle.Fill;
            pictureBox1.Controls.Add(lt);
            lt.Show();
        }
    }
}