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
    public partial class FormThongKeHoaDon : Form
    {
        public FormThongKeHoaDon()
        {
            InitializeComponent();
        }

        HoaDonBamDAL_BLL _HDB = new HoaDonBamDAL_BLL();
        HoaDonNhapDAL_BLL _PNT = new HoaDonNhapDAL_BLL();
        KhachHangDALBLL _KH = new KhachHangDALBLL();
        NhaCungCapDALBLL _NCC = new NhaCungCapDALBLL();
        NhanVienDALBLL _NV = new NhanVienDALBLL();

        private void switchButton1_ValueChanged(object sender, EventArgs e)
        {
            if (switchButton1.Value == true)
                groupPanel5.Visible = groupPanel6.Visible = groupPanel7.Visible = true;
            else
                groupPanel5.Visible = groupPanel6.Visible = groupPanel7.Visible = false;
        }


        public int TongHDB()
        {
            int tong = 0;
            for (int i = 0; i < gvHDB.RowCount; i++)
            {
                if (gvHDB.Rows[i].Cells[5].Value != null)
                {
                    tong += Int32.Parse(gvHDB.Rows[i].Cells[5].Value.ToString());

                }
            }
            return tong;
        }

        public int TongPNT()
        {
            int tong = 0;
            for (int i = 0; i < gvPNH.RowCount; i++)
            {
                if (gvPNH.Rows[i].Cells[5].Value != null)
                {
                    tong += Int32.Parse(gvPNH.Rows[i].Cells[5].Value.ToString());

                }
            }
            return tong;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                if (switchButton1.Value == false)
                {
                    gvHDB.DataSource = _HDB.ThongKe_TheoNgay(DTPTuNgay.Value, DTPDenNgay.Value);
                    gvPNH.DataSource = _PNT.ThongKe_TheoNgay(DTPTuNgay.Value, DTPDenNgay.Value);
                    txtTongHDB.Text = TongHDB().ToString() + " VNĐ";
                    txtTongPNT.Text = TongPNT().ToString() + " VNĐ";
                }
                else
                {
                    if (integerInput1.Text != "" && integerInput2.Text != "")
                    {
                        gvHDB.DataSource = _HDB.ThongKe_TheoNgay_TT(DTPTuNgay.Value, DTPDenNgay.Value, integerInput1.Value, integerInput2.Value);
                        gvPNH.DataSource = _PNT.ThongKe_TheoNgay_TT(DTPTuNgay.Value, DTPDenNgay.Value, integerInput1.Value, integerInput2.Value);
                        txtTongHDB.Text = TongHDB().ToString() + " VNĐ";
                        txtTongPNT.Text = TongPNT().ToString() + " VNĐ";
                    }
                    else
                    {
                        if (radioButton1.Checked)
                        {
                            gvHDB.DataSource = _HDB.ThongKe_TheoNgay_KH(DTPTuNgay.Value, DTPDenNgay.Value, cboKhachHang.SelectedValue.ToString());
                            gvPNH.DataSource = _PNT.ThongKe_TheoNgay_NCC(DTPTuNgay.Value, DTPDenNgay.Value, cboNhaCungCap.SelectedValue.ToString());
                            txtTongHDB.Text = TongHDB().ToString() + " VNĐ";
                            txtTongPNT.Text = TongPNT().ToString() + " VNĐ";
                        }
                        else
                        {
                            gvHDB.DataSource = _HDB.ThongKe_TheoNgay_NV(DTPTuNgay.Value, DTPDenNgay.Value, cboNhanVien.SelectedValue.ToString());
                            gvPNH.DataSource = _PNT.ThongKe_TheoNgay_NCC(DTPTuNgay.Value, DTPDenNgay.Value, cboNhaCungCap.SelectedValue.ToString());
                            txtTongHDB.Text = TongHDB().ToString() + " VNĐ";
                            txtTongPNT.Text = TongPNT().ToString() + " VNĐ";
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
                return;
            }
        }

        private void FormThongKeHoaDon_Load(object sender, EventArgs e)
        {
            cboKhachHang.DataSource = _KH.Load_KhachHang();
            cboKhachHang.ValueMember = "MAKH";
            cboKhachHang.DisplayMember = "HOTENKH";

            cboNhanVien.DataSource = _NV.getNhanVien();
            cboNhanVien.ValueMember = "MANV";
            cboNhanVien.DisplayMember = "HOTENNV";

            cboNhaCungCap.DataSource = _NCC.Load_NhaCungCap();
            cboNhaCungCap.ValueMember = "MANCC";
            cboNhaCungCap.DisplayMember = "TENNHACUNGCAP";
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            DTPTuNgay.Text = DTPDenNgay.Text = cboKhachHang.Text = cboNhaCungCap.Text = cboNhanVien.Text = integerInput1.Text = integerInput2.Text = txtTongHDB.Text = txtTongPNT.Text = string.Empty;
            gvHDB.DataSource = gvPNH.DataSource = null;
        }
    }
}
