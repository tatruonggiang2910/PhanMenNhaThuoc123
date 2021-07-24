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
    public partial class FormBacLuong : Form
    {
        public FormBacLuong()
        {
            InitializeComponent();
            gvBacLuong.DataSource = BL.loadBacLuong();
            GvChiTietBacLuong.DataSource = BL.Load_ChiTiet();
        }

        BacLuongDAL_BLL BL = new BacLuongDAL_BLL();

        private void FormBacLuong_Load(object sender, EventArgs e)
        {
            cbbNhanVien.DataSource = BL.Load_ChiTiet();
            cbbNhanVien.DisplayMember = "HOTENNV";
            cbbNhanVien.ValueMember = "MANV";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                //if()

                BL.Them_Bac(txtMaBacLuong.Text, txtBacLuong.Text, Convert.ToDouble(txtHeSoLuong.Text));

                MessageBox.Show("Thêm dữ liệu  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gvBacLuong.DataSource = BL.loadBacLuong();

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
                if (MessageBox.Show("Muốn xóa dữ liệu này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string str = txtMaBacLuong.Text;
                    if (BL.Xoa_Bac(str) == 1)
                    {
                        MessageBox.Show("Xoá dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        gvBacLuong.DataSource = BL.loadBacLuong();
                    }
                    else
                    {
                        MessageBox.Show("Xoá dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
                BL.Sua(txtBacLuong.Text, Convert.ToDouble(txtHeSoLuong.Text), txtMaBacLuong.Text);          
              
                MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);             
                gvBacLuong.DataSource = BL.loadBacLuong();             
             
            }
            catch
            {

            }   
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaBacLuong.Text = string.Empty;
            txtHeSoLuong.Text = string.Empty;
            txtMaBacLuong.Text = string.Empty;
        }

        private void gvBacLuong_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaBacLuong.Text = gvBacLuong.CurrentRow.Cells[0].Value.ToString();
                txtHeSoLuong.Text = gvBacLuong.CurrentRow.Cells[2].Value.ToString();
                txtBacLuong.Text = gvBacLuong.CurrentRow.Cells[1].Value.ToString();

            }
            catch
            { }
        }

        private void GvChiTietBacLuong_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaBacLuong.Text = GvChiTietBacLuong.CurrentRow.Cells[0].Value.ToString();
                cbbNhanVien.Text = GvChiTietBacLuong.CurrentRow.Cells[1].Value.ToString();
                DTPTuNgay.Text = GvChiTietBacLuong.CurrentRow.Cells[2].Value.ToString();
                DTPDenNgay.Text = GvChiTietBacLuong.CurrentRow.Cells[3].Value.ToString();

            }
            catch
            { }
        }

        private void btnTaoMoiCt_Click(object sender, EventArgs e)
        {
            cbbNhanVien.Text = string.Empty;
            DTPTuNgay.Text = string.Empty;
            DTPDenNgay.Text = string.Empty;
        }

        private void btnThemCT_Click(object sender, EventArgs e)
        {
            try
            {
                //if()

                BL.Them_CTBac(txtMaBacLuong.Text,cbbNhanVien.SelectedValue.ToString(),DateTime.Parse(DTPTuNgay.Text),DateTime.Parse(DTPDenNgay.Text));

                MessageBox.Show("Thêm dữ liệu  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GvChiTietBacLuong.DataSource = BL.Load_ChiTiet();

            }
            catch
            {
                
            }
        }

        private void btnSuaCT_Click(object sender, EventArgs e)
        {
            try
            {
               
                BL.Sua_CTBL(cbbNhanVien.Text, txtMaBacLuong.Text, DateTime.Parse(DTPTuNgay.Text), DateTime.Parse(DTPDenNgay.Text));
                MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GvChiTietBacLuong.DataSource = BL.Load_ChiTiet();
      
            }
            catch
            {

            }  
        }

        private void btnXoa1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Muốn xóa bảng chấm công này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string mabac = GvChiTietBacLuong.CurrentRow.Cells[0].Value.ToString();
                    string manv = GvChiTietBacLuong.CurrentRow.Cells[1].Value.ToString();
                    BL.Xoa_CTBac(mabac, manv);
                    MessageBox.Show("Xoá dữ liệu  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    GvChiTietBacLuong.DataSource = BL.Load_ChiTiet();
      
                }
            }
            catch
            {
                MessageBox.Show("Xoá dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
