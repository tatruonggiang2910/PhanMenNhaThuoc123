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
    public partial class FormKhachHang : Form
    {
        KhachHangDALBLL khachhang = new KhachHangDALBLL();
        QuanHuyenDALBLL quanhuyen = new QuanHuyenDALBLL();

        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {

            txtHoTenKH.Enabled = true;
            txtSDT.Enabled = true;
            txtDiaChi.Enabled = true;
            btnThem.Enabled = true;
            txtSDT.Enabled = true;
            List<KHACHHANG> lst = new List<KHACHHANG>();
            lst = khachhang.getKhachHangLst();
            string a = GVKhachHang.Rows[GVKhachHang.Rows.Count - 1].Cells[0].Value.ToString();
            string manv = "KH";
            string b = a.Substring(2, 2);
            int ma = Convert.ToInt32(b);
            ma = ma + 1;
            if (lst.Count < 9)
                manv = manv + "0";
            else
                manv = manv + "";
            manv += ma;
            //================================================//
            txtMaKhachHang.Text = manv;
            txtDiaChi.Clear();
            txtHoTenKH.Clear();
            txtSDT.Clear();
            cbbLoaiKH.SelectedIndex = 0;
            cbbGioiTinhKH.SelectedIndex = 0;
            cbbQuanHuyen.SelectedIndex = 0;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaKhachHang.Text) || String.IsNullOrEmpty(txtHoTenKH.Text) || String.IsNullOrEmpty(txtSDT.Text) || String.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Dữ liệu không được để trống", "Thông báo");
                return;
            }
            //================================================//
            string maKH = txtMaKhachHang.Text;
            string tenKH = txtHoTenKH.Text;
            string ngaySinh = DTPNgaysinh.Value.ToString();
            string loaiKH;
            if (cbbLoaiKH.SelectedIndex == 0)
                loaiKH = "Sinh viên";
            else if (cbbLoaiKH.SelectedIndex == 1)
                loaiKH = "Học sinh";
            else if (cbbLoaiKH.SelectedIndex == 2)
                loaiKH = "Nội trợ";
            else if (cbbLoaiKH.SelectedIndex == 3)
                loaiKH = "Đi làm";
            else
                loaiKH = "Lớn tuổi";
            string maQH = cbbQuanHuyen.SelectedValue.ToString();
            string gioiTinh;
            if (cbbGioiTinhKH.SelectedIndex == 0)
                gioiTinh = "Nam";
            else
                gioiTinh = "Nữ";
            string diaChi = txtDiaChi.Text;
            string sdT = txtSDT.Text;
            //================================================//
            //Thêm dữ liệu
            if (khachhang.insertKhachHang(maKH, maQH, tenKH, loaiKH, ngaySinh, gioiTinh, diaChi, sdT) == true)
            {
                MessageBox.Show("Thêm thành công", "Thông báo");
                FormKhachHang_Load(sender, e);
                return;
            }
            {
                MessageBox.Show("Thêm thất bại", "Thông báo");
                FormKhachHang_Load(sender, e);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maKH = GVKhachHang.CurrentRow.Cells[0].Value.ToString();
            if (khachhang.deleteKhachHang(maKH) == true)
            {
                MessageBox.Show("Xóa thành công", "Thông báo");
                FormKhachHang_Load(sender, e);
                return;
            }
            else
            {
                MessageBox.Show("Xóa thất bại", "Thông báo");
                FormKhachHang_Load(sender, e);
                return;
            }
        }

        private void FormKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        private void GVKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            txtMaKhachHang.Text = GVKhachHang.CurrentRow.Cells[0].Value.ToString();
            txtHoTenKH.Text = GVKhachHang.CurrentRow.Cells[2].Value.ToString();
            DTPNgaysinh.Value = Convert.ToDateTime(GVKhachHang.CurrentRow.Cells[4].Value.ToString());
            txtSDT.Text = GVKhachHang.CurrentRow.Cells[7].Value.ToString();
            txtDiaChi.Text = GVKhachHang.CurrentRow.Cells[6].Value.ToString();
            //================================================//
            for (int i = 0; i < cbbLoaiKH.Items.Count; i++)
            {
                if (GVKhachHang.CurrentRow.Cells[3].Value.ToString() == "Sinh viên")
                {
                    cbbLoaiKH.SelectedIndex = 0;
                    break;
                }

                else if (GVKhachHang.CurrentRow.Cells[3].Value.ToString() == "Học sinh")
                {
                    cbbLoaiKH.SelectedIndex = 1;
                    break;
                }
                else if (GVKhachHang.CurrentRow.Cells[3].Value.ToString() == "Nội trợ")
                {
                    cbbLoaiKH.SelectedIndex = 2;
                    break;
                }
                else if (GVKhachHang.CurrentRow.Cells[3].Value.ToString() == "Đi làm")
                {
                    cbbLoaiKH.SelectedIndex = 3;
                    break;
                }
                else
                {
                    cbbLoaiKH.SelectedIndex = 4;
                    break;
                }
            }
            //================================================//
            for (int i = 0; i < cbbGioiTinhKH.Items.Count; i++)
            {
                if (GVKhachHang.CurrentRow.Cells[5].Value.ToString() == "Nam")
                {
                    cbbGioiTinhKH.SelectedIndex = 0;
                    break;
                }
                else
                {
                    cbbGioiTinhKH.SelectedIndex = 1;
                    break;
                }
            }
            //================================================//
            cbbQuanHuyen.SelectedValue = GVKhachHang.CurrentRow.Cells[1].Value.ToString();
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            cbbQuanHuyen.DataSource = quanhuyen.getQuanHuyen();
            cbbQuanHuyen.ValueMember = "MAQUANHUYEN";
            cbbQuanHuyen.DisplayMember = "TENQUANHUYEN";
            GVKhachHang.DataSource = khachhang.getKhachHang();
            //Khởi tạo combobox giới tính
            cbbGioiTinhKH.DisplayMember = "Text";
            cbbGioiTinhKH.ValueMember = "Value";
            cbbGioiTinhKH.Items.Add(new { Text = "Nam", Value = "0" });
            cbbGioiTinhKH.Items.Add(new { Text = "Nữ", Value = "1" });
            cbbGioiTinhKH.SelectedIndex = 0;
            //================================================//
            cbbLoaiKH.DisplayMember = "T";
            cbbLoaiKH.ValueMember = "V";
            cbbLoaiKH.Items.Add(new { T = "Sinh viên", V = "0" });
            cbbLoaiKH.Items.Add(new { T = "Học sinh", V = "1" });
            cbbLoaiKH.Items.Add(new { T = "Nội trợ", V = "2" });
            cbbLoaiKH.Items.Add(new { T = "Đi làm", V = "3" });
            cbbLoaiKH.Items.Add(new { T = "Lớn tuổi", V = "4" });
            cbbLoaiKH.SelectedIndex = 0;
            //================================================//
            txtMaKhachHang.Text = GVKhachHang.CurrentRow.Cells[0].Value.ToString();
            txtHoTenKH.Text = GVKhachHang.CurrentRow.Cells[2].Value.ToString();
            DTPNgaysinh.Value = Convert.ToDateTime(GVKhachHang.CurrentRow.Cells[4].Value.ToString());
            txtSDT.Text = GVKhachHang.CurrentRow.Cells[7].Value.ToString();
            txtDiaChi.Text = GVKhachHang.CurrentRow.Cells[6].Value.ToString();
            //================================================//
            for (int i = 0; i < cbbLoaiKH.Items.Count; i++)
            {
                if (GVKhachHang.CurrentRow.Cells[3].Value.ToString() == "Sinh viên")
                {
                    cbbLoaiKH.SelectedIndex = 0;
                    break;
                }

                else if (GVKhachHang.CurrentRow.Cells[3].Value.ToString() == "Học sinh")
                {
                    cbbLoaiKH.SelectedIndex = 1;
                    break;
                }
                else if (GVKhachHang.CurrentRow.Cells[3].Value.ToString() == "Nội trợ")
                {
                    cbbLoaiKH.SelectedIndex = 2;
                    break;
                }
                else if (GVKhachHang.CurrentRow.Cells[3].Value.ToString() == "Đi làm")
                {
                    cbbLoaiKH.SelectedIndex = 3;
                    break;
                }
                else
                {
                    cbbLoaiKH.SelectedIndex = 4;
                    break;
                }
            }
            //================================================//
            for (int i = 0; i < cbbGioiTinhKH.Items.Count; i++)
            {
                if (GVKhachHang.CurrentRow.Cells[5].Value.ToString() == "Nam")
                {
                    cbbGioiTinhKH.SelectedIndex = 0;
                    break;
                }
                else
                {
                    cbbGioiTinhKH.SelectedIndex = 1;
                    break;
                }
            }
            //================================================//
            cbbQuanHuyen.SelectedValue = GVKhachHang.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                FormKhachHang_Load(sender, e);
                btnLuu.Enabled = true;
                btnSua.Text = "Hủy";
            }
            else
            {
                FormKhachHang_Load(sender, e);
                btnSua.Text = "Sửa";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMaKhachHang.Text) || String.IsNullOrEmpty(txtHoTenKH.Text) || String.IsNullOrEmpty(txtSDT.Text) || String.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Dữ liệu không được để trống", "Thông báo");
                return;
            }
            //================================================//
            string maKH = txtMaKhachHang.Text;
            string tenKH = txtHoTenKH.Text;
            string ngaySinh = DTPNgaysinh.Value.ToString();
            string loaiKH;
            if (cbbLoaiKH.SelectedIndex == 0)
                loaiKH = "Sinh viên";
            else if (cbbLoaiKH.SelectedIndex == 1)
                loaiKH = "Học sinh";
            else if (cbbLoaiKH.SelectedIndex == 2)
                loaiKH = "Nội trợ";
            else if (cbbLoaiKH.SelectedIndex == 3)
                loaiKH = "Đi làm";
            else
                loaiKH = "Lớn tuổi";
            string maQH = cbbQuanHuyen.SelectedValue.ToString();
            string gioiTinh;
            if (cbbGioiTinhKH.SelectedIndex == 0)
                gioiTinh = "Nam";
            else
                gioiTinh = "Nữ";
            string diaChi = txtDiaChi.Text;
            string sdT = txtSDT.Text;
            //================================================//
            //Cập nhập dữ liệu
            if (khachhang.updateKhachHang(maKH, maQH, tenKH, loaiKH, ngaySinh, gioiTinh, diaChi, sdT) == true)
            {
                MessageBox.Show("Cập nhập thành công", "Thông báo");
                FormKhachHang_Load(sender, e);
                return;
            }
            {
                MessageBox.Show("Cập nhập thất bại", "Thông báo");
                FormKhachHang_Load(sender, e);
                return;
            }
        }
    }
}
