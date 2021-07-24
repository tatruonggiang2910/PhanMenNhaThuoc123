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
    public partial class FormTinhThanh_QuanHuyen : Form
    {
        TinhThanhDALBLL tinhthanh = new TinhThanhDALBLL();
        QuanHuyenDALBLL quanhuyen = new QuanHuyenDALBLL();
        public FormTinhThanh_QuanHuyen()
        {
            InitializeComponent();
        }

        private void FormTinhThanh_QuanHuyen_Load(object sender, EventArgs e)
        {
            if (DangNhap.nv.MANHOMNV == "NV")
            {
                btnTaoMoiQH.Enabled = btntaomoiTT.Enabled =  btnXoaQH.Enabled = btnXoaTT.Enabled = false;
            }
            GvTinhThanh.DataSource = tinhthanh.getTinhThanh();
            //================================================//
            txtMaTinhThanh.Text = GvTinhThanh.CurrentRow.Cells[0].Value.ToString();
            txtTenTinhThanh.Text = GvTinhThanh.CurrentRow.Cells[1].Value.ToString();
            //================================================//
            cbbTinhThanh.DataSource = tinhthanh.getTinhThanh();
            cbbTinhThanh.ValueMember = "MATINHTHANH";
            cbbTinhThanh.DisplayMember = "TENTINHTHANH";
            //================================================//
            btnThemQH.Enabled = false;
            btnThemTT.Enabled = false;
            txtMaQuanHuyen.Enabled = false;
            txtTenQuanHuyen.Enabled = false;
            txtMaTinhThanh.Enabled = false;
            txtTenTinhThanh.Enabled = false;
            cbbTinhThanh.Enabled = false;
        }

        private void GVQuanHuyen_SelectionChanged(object sender, EventArgs e)
        {
            txtMaQuanHuyen.Text = GVQuanHuyen.CurrentRow.Cells[0].Value.ToString();
            txtTenQuanHuyen.Text = GVQuanHuyen.CurrentRow.Cells[2].Value.ToString();
            //================================================//
            List<TINHTHANH> lstTinhThanh = new List<TINHTHANH>();
            lstTinhThanh = tinhthanh.getTinhThanh();

            //Binding giá trị mã tĩnh thành sang combobox Tinh thanh
            foreach (TINHTHANH i in lstTinhThanh)
            {
                if (i.MATINHTHANH == GVQuanHuyen.CurrentRow.Cells[1].Value.ToString())
                {
                    cbbTinhThanh.SelectedItem = i;
                    break;
                }
            }
        }

        private void GvTinhThanh_SelectionChanged(object sender, EventArgs e)
        {
            txtMaTinhThanh.Text = GvTinhThanh.CurrentRow.Cells[0].Value.ToString();
            txtTenTinhThanh.Text = GvTinhThanh.CurrentRow.Cells[1].Value.ToString();

            GVQuanHuyen.DataSource = quanhuyen.getQuanHuyen(GvTinhThanh.CurrentRow.Cells[0].Value.ToString());
        }

  

        private void btnTaoMoiQH_Click(object sender, EventArgs e)
        {
            btnThemQH.Enabled = true;
            txtMaQuanHuyen.Enabled = true;
            txtTenQuanHuyen.Enabled = true;
            cbbTinhThanh.Enabled = true;
            //================================================//
            txtMaQuanHuyen.Clear();
            txtTenQuanHuyen.Clear();
        }

        private void btnThemQH_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu rỗng
            if (String.IsNullOrEmpty(txtMaQuanHuyen.Text) || String.IsNullOrEmpty(txtTenQuanHuyen.Text))
            {
                MessageBox.Show("Dữ liệu không được để trống", "Thông báo");
                return;
            }

            //Kiểm tra tên quận huyện đã tồn tại hay chưa
            List<QUANHUYEN> lstQuanHuyen = new List<QUANHUYEN>();
            lstQuanHuyen = quanhuyen.getQuanHuyenLst();
            foreach (QUANHUYEN i in lstQuanHuyen)
            {
                if (i.TENQUANHUYEN == txtTenQuanHuyen.Text)
                {
                    MessageBox.Show("Quận Huyện đã tồn tại", "Thông báo");
                    FormTinhThanh_QuanHuyen_Load(sender, e);
                    return;
                }
            }

            //Thêm dữ liệu
            if (quanhuyen.insertQuanHuyen(txtMaQuanHuyen.Text, cbbTinhThanh.SelectedValue.ToString(), txtTenQuanHuyen.Text) == true)
            {
                MessageBox.Show("Thêm thành công", "Thông báo");
                FormTinhThanh_QuanHuyen_Load(sender, e);
                return;
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Thông báo");
                FormTinhThanh_QuanHuyen_Load(sender, e);
                return;
            }
        }

        private void btnXoaQH_Click(object sender, EventArgs e)
        {
            //Xóa dữ liệu
            if (quanhuyen.deleteQuanHuyen(txtMaQuanHuyen.Text) == true)
            {
                MessageBox.Show("Xóa thành công", "Thông báo");
                FormTinhThanh_QuanHuyen_Load(sender, e);
                return;
            }
            else
            {
                MessageBox.Show("Xóa thất bại", "Thông báo");
                FormTinhThanh_QuanHuyen_Load(sender, e);
                return;
            }
        }

        private void btntaomoiTT_Click(object sender, EventArgs e)
        {
            btnThemTT.Enabled = true;
            txtMaTinhThanh.Enabled = true;
            txtTenTinhThanh.Enabled = true;
            //================================================//
            txtMaTinhThanh.Clear();
            txtTenTinhThanh.Clear();
        }

        private void btnThemTT_Click(object sender, EventArgs e)
        {
            //Kiểm tra dữ liệu rỗng
            if (String.IsNullOrEmpty(txtMaTinhThanh.Text) || String.IsNullOrEmpty(txtTenTinhThanh.Text))
            {
                MessageBox.Show("Dữ liệu không được để trống", "Thông báo");
                return;
            }

            //Kiểm tra tên tỉnh thành đã tồn tại hay chưa
            List<TINHTHANH> lstTinhThanh = new List<TINHTHANH>();
            lstTinhThanh = tinhthanh.getTinhThanh();
            foreach (TINHTHANH i in lstTinhThanh)
            {
                if (i.TENTINHTHANH == txtTenTinhThanh.Text)
                {
                    MessageBox.Show("Tỉnh Thành đã tồn tại", "Thông báo");
                    FormTinhThanh_QuanHuyen_Load(sender, e);
                    return;
                }
            }

            //Thêm dữ liệu
            if (tinhthanh.insertTinhThanh(txtMaTinhThanh.Text, txtTenTinhThanh.Text) == true)
            {
                MessageBox.Show("Thêm thành công", "Thông báo");
                FormTinhThanh_QuanHuyen_Load(sender, e);
                return;
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Thông báo");
                FormTinhThanh_QuanHuyen_Load(sender, e);
                return;
            }
        }

        private void btnXoaTT_Click(object sender, EventArgs e)
        {
            //Xóa dữ liệu
            if (tinhthanh.deleteTinhThanh(txtMaTinhThanh.Text) == true)
            {
                MessageBox.Show("Xóa thành công", "Thông báo");
                FormTinhThanh_QuanHuyen_Load(sender, e);
                return;
            }
            else
            {
                MessageBox.Show("Xóa thất bại", "Thông báo");
                FormTinhThanh_QuanHuyen_Load(sender, e);
                return;
            }
        }

        private void btnThoat1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTinhThanh_QuanHuyen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
            {
                e.Cancel = true;

            }
        }

        private void GvTinhThanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
