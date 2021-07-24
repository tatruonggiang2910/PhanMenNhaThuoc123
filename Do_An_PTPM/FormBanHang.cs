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
using DTO;

namespace Do_An_CNPM
{
    public partial class FormBanHang : Form
    {
        public FormBanHang()
        {
            InitializeComponent();
        }

        QLNTTDataContext _QLNTT = new QLNTTDataContext();
        HoaDonBamDAL_BLL _HDBH = new HoaDonBamDAL_BLL();
        KhachHangDALBLL _KH = new KhachHangDALBLL();
        LoaiThuocDAL_BLL _LT = new LoaiThuocDAL_BLL();
        ThuocDAL_BLL _THUOC = new ThuocDAL_BLL();

        private void FormBanHang_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = DangNhap.nv.MANV;
            txtTenNV.Text = DangNhap.nv.HOTENNV;

            GvHoaDon.DataSource = _HDBH.Load_Hoadonban();
            cbbTenKhachHang.DataSource = _KH.Load_TenKhachHang();
            cbbTenKhachHang.ValueMember = "MAKH";
            cbbTenKhachHang.DisplayMember = "HOTENKH";
            cbbMaLoaiThuoc.DataSource = _LT.load_loaiThuoc();
            cbbMaLoaiThuoc.DisplayMember = "TENLOAITHUOC";
            cbbMaLoaiThuoc.ValueMember = "MALOAITHUOC";
        }

        private void GvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string mhd = GvHoaDon.CurrentRow.Cells[0].Value.ToString();
            GvChiTietHD.DataSource = _HDBH.Load_CTHoadonban(mhd);
            txtMaHoaDon.Text = mhd;
            DTPNgayLap.Text = GvHoaDon.CurrentRow.Cells[1].Value.ToString();
            cbbTenKhachHang.DataSource = _KH.Load_khach1(mhd);
            cbbTenKhachHang.ValueMember = "MAKH";
            cbbTenKhachHang.DisplayMember = "HOTENKH";
            txtVAT.Text = VAT(mhd);
            double tt = (TinhTongTien()) + ((TinhTongTien() * (double.Parse(VAT(mhd)) / 100.0)));
            txtThanhTien.Text = tt.ToString();
        }

        private void format()
        {
            txtMaHoaDon.Text = string.Empty;
            txtSoLuong.Text = string.Empty;
            txtThanhTien.Text = 0.ToString();
            txtVAT.Text = string.Empty;
            txtTonKho.Text = string.Empty;
            txtThanhTien2.Text = string.Empty;
            cbbDonViTinh.Text = string.Empty;
            cbbMaLoaiThuoc.Text = string.Empty;
            cbbTenKhachHang.DataSource = _KH.Load_KhachHang();
            cbbTenKhachHang.ValueMember = "MAKH";
            cbbTenKhachHang.DisplayMember = "HOTENKH";
            cbbMaThuoc.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtGiaBan.Text = string.Empty;
            GvChiTietHD.DataSource = null;
            dsthuocban.Clear();
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            format();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnLapHoaDon.Enabled = true;
        }

        List<KHACHHANG> lst_khachhang;
        public string diachi(string makh)
        {
            lst_khachhang = new List<KHACHHANG>();
            string dg = "";
            lst_khachhang = _KH.Load_diachikh(makh);
            foreach (KHACHHANG th in lst_khachhang)
            {
                dg = (th.DIACHIKH).ToString(); //ten cot don gia
            }
            return dg;
        }

        private void cbbTenKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDiaChi.Text = diachi(cbbTenKhachHang.SelectedValue.ToString()).ToString();
        }

        private void cbbMaLoaiThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbMaThuoc.DataSource = _THUOC.Load_tenthuoc(cbbMaLoaiThuoc.SelectedValue.ToString());
            cbbMaThuoc.DisplayMember = "TENTHUOC";
            cbbMaThuoc.ValueMember = "MATHUOC";
        }

        List<THUOC> lst_thuoc;
        public string SoLuong(string mathuoc)
        {
            lst_thuoc = new List<THUOC>();
            string sl = "";
            lst_thuoc = _THUOC.Load_soluong(mathuoc);
            foreach (THUOC th in lst_thuoc)
            {
                sl = (th.SOLUONGTON).ToString(); //ten cot don gia
            }
            return sl;
        }
        public string DonGia(string mathuoc)
        {
            lst_thuoc = new List<THUOC>();
            string dg = "";
            lst_thuoc = _THUOC.Load_dongia(mathuoc);
            foreach (THUOC th in lst_thuoc)
            {
                dg = (th.DONGIATHUOC).ToString() + " VNĐ"; //ten cot don gia
            }
            return dg;
        }

        public string soluongton(string mathuoc)
        {
            lst_thuoc = new List<THUOC>();
            string dg = "";
            lst_thuoc = _THUOC.Load_soluongton(mathuoc);
            foreach (THUOC th in lst_thuoc)
            {
                dg = (th.SOLUONGTON).ToString(); //ten cot don gia
            }
            return dg;
        }

        List<HOADONBAN> lst_HDB;
        public string VAT(string mhd)
        {
            lst_HDB = new List<HOADONBAN>();
            string dg = "";
            lst_HDB = _HDBH.Load_VAT(mhd);
            foreach (HOADONBAN th in lst_HDB)
            {
                dg = (th.VAT).ToString(); //ten cot don gia
            }
            return dg;
        }

        public double TinhTongTien()
        {
            double tong = 0;
            for (int i = 0; i < GvChiTietHD.RowCount; i++)
            {
                if (GvChiTietHD.Rows[i].Cells[5].Value != null)
                {
                    tong += Int32.Parse(GvChiTietHD.Rows[i].Cells[5].Value.ToString());

                }
            }
            return tong;
        }

        private void cbbMaThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mathuoc = cbbMaThuoc.SelectedValue.ToString();
            txtTonKho.Text = SoLuong(mathuoc);
            txtGiaBan.Text = DonGia(mathuoc);
            cbbDonViTinh.DataSource = _THUOC.load_donvitinh(mathuoc);
            cbbDonViTinh.DisplayMember = "DVT";
            txtSoLuong.Text = "0";
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtThanhTien2.Text = ((Int32.Parse(txtSoLuong.Text)) * (Int32.Parse(txtGiaBan.Text))).ToString();
            }
            catch
            {
                txtThanhTien2.Text = 0.ToString();
            }
        }

        public string layMaTuDong_hoadonban()
        {
            try
            {
                string g = "";
                string a = "";
                a = GvHoaDon.Rows[GvHoaDon.Rows.Count - 1].Cells[0].Value.ToString();
                int ma;
                g = "HDB";
                ma = Convert.ToInt32(a.Substring(3, 3));
                ma = ma + 1;
                if (ma < 10)
                    g = g + "00";
                if (ma >= 10)
                    g = g + "0";
                g += ma.ToString();
                return g;
            }
            catch { return "HDB001"; }
        }

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            if (dsthuocban.Count == 0)
            {
                MessageBox.Show("Hóa đơn phải có ít nhất 1 sản phẩm", "Thông báo");
                return;
            }
            if (string.IsNullOrEmpty(txtVAT.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lbVAT.Text.ToLower());
                this.txtSoLuong.Focus();
                return;
            }
            else
            {
                int slton = int.Parse(txtTonKho.Text);
                int vat = int.Parse(txtVAT.Text);
                decimal thanhtien = decimal.Parse(txtThanhTien2.Text);
                decimal Tongtien = decimal.Parse(((TinhTongTien()) + (TinhTongTien() * (double.Parse(vat.ToString()) / 100.0))).ToString());
                HOADONBAN hdb = new HOADONBAN
                {
                    MAHDB = layMaTuDong_hoadonban(),
                    MAKH = cbbTenKhachHang.SelectedValue.ToString(),
                    MANV = DangNhap.nv.MANV,
                    NGAYLAPBAN = DTPNgayLap.Value,
                    VAT = double.Parse(txtVAT.Text),
                    TONGTIENBAN = Tongtien
                };
                _QLNTT.HOADONBANs.InsertOnSubmit(hdb);
                _QLNTT.SubmitChanges();
                CHITIETHOADONBAN cthdb = null;
                foreach (ThuocCMua_DTO thuocban in dsthuocban)
                {
                    cthdb = new CHITIETHOADONBAN
                    {
                        MAHDB = hdb.MAHDB,
                        MATHUOC = thuocban.MATHUOC,
                        SOLUONGBAN = thuocban.SOLUONG,
                        THANHTIENBAN = Convert.ToDecimal(thuocban.THANHTIEN)
                    };
                    _QLNTT.CHITIETHOADONBANs.InsertOnSubmit(cthdb);

                }
                _QLNTT.SubmitChanges();
                GvHoaDon.DataSource = _HDBH.Load_Hoadonban();
                MessageBox.Show("Thêm hóa đơn thành công", "Thông báo");
                _QLNTT.SubmitChanges();
                dsthuocban.Clear();

                focus();
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnLapHoaDon.Enabled = false;
            }
        }

        private void focus()
        {
            GvHoaDon.ClearSelection();
            int nRowIndex = GvHoaDon.Rows.Count - 1;

            GvHoaDon.Rows[nRowIndex].Selected = true;
            GvHoaDon.Rows[nRowIndex].Cells[0].Selected = true;
        }

        private void GvChiTietHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbMaLoaiThuoc.Text = "";
            cbbMaThuoc.Text = GvChiTietHD.CurrentRow.Cells[1].Value.ToString();
            cbbDonViTinh.Text = GvChiTietHD.CurrentRow.Cells[2].Value.ToString();
            txtGiaBan.Text = GvChiTietHD.CurrentRow.Cells[3].Value.ToString();
            txtSoLuong.Text = GvChiTietHD.CurrentRow.Cells[4].Value.ToString();
            txtThanhTien2.Text = GvChiTietHD.CurrentRow.Cells[5].Value.ToString();
            txtTonKho.Text = soluongton(GvChiTietHD.CurrentRow.Cells[0].Value.ToString());
        }

        public void hienThidsmua()
        {
            GvChiTietHD.DataSource = null;
            GvChiTietHD.DataSource = dsthuocban;
            txtThanhTien.Text = dsthuocban.Sum(p => p.SOLUONG * p.DONGIA).ToString();
            txtThanhTien2.Text = dsthuocban.Sum(p => p.SOLUONG * p.DONGIA).ToString();
            GvHoaDon.DataSource = _HDBH.Load_Hoadonban();
        }

        List<ThuocCMua_DTO> dsthuocban = new List<ThuocCMua_DTO>();
        int soluong;
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoLuong.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lbsoluong.Text.ToLower());
                this.txtSoLuong.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cbbTenKhachHang.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lb_tenkh.Text.ToLower());
                this.cbbTenKhachHang.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cbbMaThuoc.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lb_mathuoc.Text.ToLower());
                this.cbbMaThuoc.Focus();
                return;
            }

            soluong = int.Parse(txtSoLuong.Text);
            if (soluong == 0)
            {
                MessageBox.Show("Số lượng bán không thể bằng 0", "Thông báo");
                this.txtSoLuong.Focus();
                return;
            }

            string maThuoc = cbbMaThuoc.SelectedValue.ToString();
            ThuocCMua_DTO chonmua = dsthuocban.SingleOrDefault(p => p.MATHUOC == maThuoc);
            if (Int32.Parse(txtTonKho.Text) > Int32.Parse(txtSoLuong.Text))
            {
                if (chonmua == null)
                {
                    THUOC thuoc = _QLNTT.THUOCs.SingleOrDefault(p => p.MATHUOC == maThuoc);
                    dsthuocban.Add(new ThuocCMua_DTO
                    {
                        MATHUOC = thuoc.MATHUOC,
                        TENTHUOC = thuoc.TENTHUOC,
                        DVT = thuoc.DVT,
                        DONGIA = Convert.ToDouble(thuoc.DONGIATHUOC),
                        SOLUONG = soluong,
                    });
                }
                else
                {
                    chonmua.SOLUONG = soluong;
                }
                hienThidsmua();

            }
            else
            {
                MessageBox.Show("Số lượng mặt hàng hiện không đủ để cung ứng", "Thông báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Muốn xóa mặt hàng này khỏi hóa đơn này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //string str = txtMaHoaDon.Text;
                    //_HDBH.deleteCTHDB(txtMaHoaDon.Text, GvChiTietHD.CurrentRow.Cells[0].Value.ToString());

                    //GvChiTietHD.DataSource = _HDBH.Load_CTHoadonban(txtMaHoaDon.Text);
                    ThuocCMua_DTO thuocxoa = dsthuocban.SingleOrDefault(p => p.MATHUOC == GvChiTietHD.CurrentRow.Cells[0].Value.ToString());
                    dsthuocban.Remove(thuocxoa);
                    hienThidsmua();
                    MessageBox.Show("Xoá dữ liệu  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Xoá dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXuatHD_Click(object sender, EventArgs e)
        {
            FormXuatHD t = new FormXuatHD();
            t.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            FormLoaiThuoc formNew = new FormLoaiThuoc();
            formNew.Show();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            FormThuoc formNew = new FormThuoc();
            formNew.Show();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            FormKhachHang formNew = new FormKhachHang();
            formNew.Show();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (btnLoc.Text == "Lọc phiếu")
            {
                GvHoaDon.DataSource = _HDBH.Load_Hoadonban(txtSearch.Text);
                btnLoc.Text = "Hủy";
            }
            else
            {
                GvHoaDon.DataSource = _HDBH.Load_Hoadonban();
                txtSearch.Text = string.Empty;
                btnLoc.Text = "Lọc phiếu";
            }

        }

    }
}
