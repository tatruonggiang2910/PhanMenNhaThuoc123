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
    public partial class FormNhaCC : Form
    {
        NhaCungCapDALBLL nhacungcap = new NhaCungCapDALBLL();
        QuanHuyenDALBLL quanhuyen = new QuanHuyenDALBLL();

        public FormNhaCC()
        {
            InitializeComponent();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            //================================================//
            //Tạo tự động tăng mã
            List<NHACUNGCAP> lst = new List<NHACUNGCAP>();
            lst = nhacungcap.getNhaCungCapLst();
            string a = GVNhaCC.Rows[GVNhaCC.Rows.Count - 1].Cells[0].Value.ToString();
            string mancc = "NCC";
            string b = a.Substring(3, 2);
            int ma = Convert.ToInt32(b);
            ma = ma + 1;
            if (lst.Count < 9)
                mancc = mancc + "0";
            else
                mancc = mancc + "";
            mancc += ma;
            //================================================//
            btnThem.Enabled = true;
            txtMaNCC.Text = mancc;
            txtTenNCC.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
            cbbQuanHuyen.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu rỗng
            if (String.IsNullOrEmpty(txtMaNCC.Text) || String.IsNullOrEmpty(txtTenNCC.Text) || String.IsNullOrEmpty(txtSDT.Text) || String.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Dữ liệu không được để trống", "Thông báo");
                return;
            }
            //================================================//
            //Lấy dữ liệu
            string maNCC = txtMaNCC.Text;
            string tenNCC = txtTenNCC.Text;
            string diaChi = txtDiaChi.Text;
            string sDT = txtSDT.Text;
            string maQH = cbbQuanHuyen.SelectedValue.ToString();
            //================================================//
            //Thêm dữ liệu
            if (nhacungcap.insertNhaCC(maNCC, maQH, tenNCC, diaChi, sDT) == true)
            {
                MessageBox.Show("Thêm thành công", "Thông báo");
                FormNhaCC_Load(sender, e);
                return;
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Thông báo");
                FormNhaCC_Load(sender, e);
                return;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNCC = GVNhaCC.CurrentRow.Cells[0].Value.ToString();
            if (nhacungcap.deleteNhaCC(maNCC) == true)
            {
                MessageBox.Show("Xóa thành công", "Thông báo");
                FormNhaCC_Load(sender, e);
                return;
            }
            else
            {
                MessageBox.Show("Xóa thất bại", "Thông báo");
                FormNhaCC_Load(sender, e);
                return;
            }
        }

        private void FormNhaCC_Load(object sender, EventArgs e)
        {
            if (DangNhap.nv.MANHOMNV == "NV")
            {
                btnSua.Enabled = btnTaoMoi.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            }
            GVNhaCC.DataSource = nhacungcap.getNhaCungCap();
            cbbQuanHuyen.DataSource = quanhuyen.getQuanHuyen();
            cbbQuanHuyen.DisplayMember = "TENQUANHUYEN";
            cbbQuanHuyen.ValueMember = "MAQUANHUYEN";
            cbbQuanHuyen.SelectedIndex = 0;
            btnThem.Enabled = false;
            //================================================//
            txtMaNCC.Text = GVNhaCC.CurrentRow.Cells[0].Value.ToString();
            txtTenNCC.Text = GVNhaCC.CurrentRow.Cells[2].Value.ToString();
            txtDiaChi.Text = GVNhaCC.CurrentRow.Cells[3].Value.ToString();
            txtSDT.Text = GVNhaCC.CurrentRow.Cells[4].Value.ToString();
            cbbQuanHuyen.SelectedValue = GVNhaCC.CurrentRow.Cells[1].Value.ToString();
        }

        private void GVNhaCC_SelectionChanged(object sender, EventArgs e)
        {
            txtMaNCC.Text = GVNhaCC.CurrentRow.Cells[0].Value.ToString();
            txtTenNCC.Text = GVNhaCC.CurrentRow.Cells[2].Value.ToString();
            txtDiaChi.Text = GVNhaCC.CurrentRow.Cells[3].Value.ToString();
            txtSDT.Text = GVNhaCC.CurrentRow.Cells[4].Value.ToString();
            cbbQuanHuyen.SelectedValue = GVNhaCC.CurrentRow.Cells[1].Value.ToString();
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text == "Sửa")
            {
                FormNhaCC_Load(sender, e);
                btnLuu.Enabled = true;
                btnSua.Text = "Hủy";
            }
            else
            {
                FormNhaCC_Load(sender, e);
                btnSua.Text = "Sửa";
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu rỗng
            if (String.IsNullOrEmpty(txtMaNCC.Text) || String.IsNullOrEmpty(txtTenNCC.Text) || String.IsNullOrEmpty(txtSDT.Text) || String.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Dữ liệu không được để trống", "Thông báo");
                return;
            }
            //================================================//
            //Lấy dữ liệu
            string maNCC = txtMaNCC.Text;
            string tenNCC = txtTenNCC.Text;
            string diaChi = txtDiaChi.Text;
            string sDT = txtSDT.Text;
            string maQH = cbbQuanHuyen.SelectedValue.ToString();
            //================================================//
            //Cập nhập dữ liệu
            if (nhacungcap.updateNhaCC(maNCC, maQH, tenNCC, diaChi, sDT) == true)
            {
                MessageBox.Show("Cập nhập thành công", "Thông báo");
                FormNhaCC_Load(sender, e);
                return;
            }
            else
            {
                MessageBox.Show("Cập nhập thất bại", "Thông báo");
                FormNhaCC_Load(sender, e);
                return;
            }
        }
    }
}
