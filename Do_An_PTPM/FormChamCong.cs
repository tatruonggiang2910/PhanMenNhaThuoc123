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
using DevComponents.DotNetBar;

namespace Do_An_CNPM
{
    public partial class FormChamCong : Form
    {
        public FormChamCong()
        {
            InitializeComponent();
        }

        QLNTTDataContext _QLNTT = new QLNTTDataContext();
        ChamCongDAL_BLL _CC = new ChamCongDAL_BLL();
        NhanVienDALBLL _NV = new NhanVienDALBLL();

        private void FormChamCong_Load(object sender, EventArgs e)
        {
            if (DangNhap.nv.MANHOMNV == "NV")
            {
                GvChamCong.DataSource = _CC.Load_chamcongNV(DangNhap.nv.MANV);
                txtMaChamCong.Text = GvChamCong.Rows[GvChamCong.Rows.Count - 1].Cells[0].Value.ToString();
                cbbNhanVien.Visible = labelX1.Visible = false;
                panelEx1.Visible = false;
                panelEx2.Visible = false;
            }
            else
            {
                GvChamCong.DataSource = _CC.Load_chamcong();
                cbbMaNhanVien.DataSource = _NV.getNhanVien();
                cbbMaNhanVien.ValueMember = "MANV";
                cbbMaNhanVien.DisplayMember = "HOTENNV";

                cbbNhanVien.DataSource = _NV.getNhanVien();
                cbbNhanVien.ValueMember = "MANV";
                cbbNhanVien.DisplayMember = "HOTENNV";
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                int soNgayLam = Int32.Parse(GvChamCong.CurrentRow.Cells[4].Value.ToString());
                _CC.chamCong(txtMaChamCong.Text, DangNhap.nv.MANV, soNgayLam);
                GvChamCong.DataSource = _CC.Load_chamcongNV(DangNhap.nv.MANV);
                MessageBox.Show("Thực hiện chấm công thành công", "Thông báo");
                btnThoat_Click(sender, e);
            }
            catch
            { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtMaChamCong.Text = string.Empty;
            cbbMaNhanVien.Text = string.Empty;
            txtMaCC2.Text = string.Empty;
            txtThang.Text = string.Empty;
            txtNam.Text = string.Empty;
            txtSoNgayLam.Text = string.Empty;
            GvChamCong.DataSource = _CC.Load_chamcong();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaCC2.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lbMCC.Text.ToLower());
                this.txtMaChamCong.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cbbMaNhanVien.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lbMNV.Text.ToLower());
                this.cbbMaNhanVien.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtThang.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lbThang.Text.ToLower());
                this.txtMaChamCong.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtNam.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lbNam.Text.ToLower());
                this.txtMaChamCong.Focus();
                return;
            }

            CHAMCONG cc = _QLNTT.CHAMCONGs.Where(t => t.MANV == cbbMaNhanVien.SelectedValue.ToString() && t.MACHAMCONG == txtMaCC2.Text).FirstOrDefault();
            if (cc == null)
            {
                _CC.insertCC(txtMaCC2.Text, cbbMaNhanVien.SelectedValue.ToString(), Int32.Parse(txtThang.Text), Int32.Parse(txtNam.Text), Int32.Parse(txtSoNgayLam.Text));
                GvChamCong.DataSource = _CC.Load_chamcong();
                MessageBox.Show("Thêm thành công", "Thông báo");
            }
            else
            {
                cc.SONGAYLAMVIEC = Int32.Parse(txtSoNgayLam.Text);
                _QLNTT.SubmitChanges();
                GvChamCong.DataSource = _CC.Load_chamcong();
                MessageBox.Show("Giá trị đã có, sửa thành công", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Muốn xóa bảng chấm công này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    string macc = GvChamCong.CurrentRow.Cells[1].Value.ToString();
                    string manv = GvChamCong.CurrentRow.Cells[0].Value.ToString();
                    _CC.deleteCC(macc, manv);
                    MessageBox.Show("Xoá dữ liệu  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    GvChamCong.DataSource = _CC.Load_chamcong();
                }
            }
            catch
            {
                MessageBox.Show("Xoá dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cbbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            GvChamCong.DataSource = _CC.Load_chamcongNV(cbbNhanVien.SelectedValue.ToString());
        }

    }
}
