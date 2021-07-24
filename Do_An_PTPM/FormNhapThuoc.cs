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
    public partial class FormNhapThuoc : Form
    {
        public FormNhapThuoc()
        {
            InitializeComponent();
        }

        QLNTTDataContext _QLNTT = new QLNTTDataContext();
        HoaDonNhapDAL_BLL _HDN = new HoaDonNhapDAL_BLL();
        NhaCungCapDALBLL _NCC = new NhaCungCapDALBLL();
        ThuocDAL_BLL _THUOC = new ThuocDAL_BLL();
        LoaiThuocDAL_BLL _LT = new LoaiThuocDAL_BLL();

        private void FormNhapThuoc_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = DangNhap.nv.MANV;
            txtTenNV.Text = DangNhap.nv.HOTENNV;

            GvPhieuNhap.DataSource = _HDN.Load_phieunhapthuoc();
            cbbMaNhaCC.DataSource = _NCC.Load_MaNhaCungCap();
            cbbMaNhaCC.DisplayMember = "TENNHACUNGCAP";
            cbbMaNhaCC.ValueMember = "MANCC";
            cbbMaLoaiThuoc.DataSource = _LT.load_loaiThuoc();
            cbbMaLoaiThuoc.DisplayMember = "TENLOAITHUOC";
            cbbMaLoaiThuoc.ValueMember = "MALOAITHUOC";

            //GvChiTietPhieuNhap.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
        }

        public int TinhTongTien()
        {
            int tong = 0;
            for (int i = 0; i < GvChiTietPhieuNhap.RowCount; i++)
            {
                if (GvChiTietPhieuNhap.Rows[i].Cells[5].Value != null)
                {
                    tong += Int32.Parse(GvChiTietPhieuNhap.Rows[i].Cells[5].Value.ToString());
                }
            }
            return tong;
        }

        List<string> lst_ghichu;
        public string ghichu(string mapn)
        {
            lst_ghichu = new List<string>();
            string gc = "";
            lst_ghichu = _HDN.Load_ghichu(mapn);
            foreach (string th in lst_ghichu)
            {
                try
                {
                    gc = th.ToString(); //ten cot don gia
                }
                catch
                {
                    return "";
                }
            }
            return gc;
        }

        List<bool?> lst_trangthai;
        public bool? trangthai(string mapn)
        {
            lst_trangthai = new List<bool?>();
            lst_trangthai = _HDN.Load_trangthai(mapn);
            foreach (bool? th in lst_trangthai)
            {
                try
                {
                    return th;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public void checkTrangThai(string mapn)
        {
            if (trangthai(mapn) == true)
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
        }

        private void GvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string pnt = GvPhieuNhap.CurrentRow.Cells[0].Value.ToString();
            txtMaPN.Text = pnt;
            GvChiTietPhieuNhap.DataSource = _HDN.Load_CTphieunhapthuoc(pnt);
            DTPNgayLap.Text = GvPhieuNhap.CurrentRow.Cells[1].Value.ToString();
            txtGhiChu.Text = ghichu(pnt);
            cbbMaNhaCC.DataSource = _NCC.Load_ncc1(pnt);
            cbbMaNhaCC.ValueMember = "MANCC";
            cbbMaNhaCC.DisplayMember = "TENNHACUNGCAP";
            txtTongTien.Text = TinhTongTien().ToString();
            checkTrangThai(pnt);
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

        private void GvChiTietPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbMaLoaiThuoc.Text = "";
            cbbMaThuoc.Text = GvChiTietPhieuNhap.CurrentRow.Cells[1].Value.ToString();
            cbbDonViTinh.Text = GvChiTietPhieuNhap.CurrentRow.Cells[2].Value.ToString();
            txtGiaNhap.Text = GvChiTietPhieuNhap.CurrentRow.Cells[3].Value.ToString();
            txtSoLuong.Text = GvChiTietPhieuNhap.CurrentRow.Cells[4].Value.ToString();
            txtThanhTien2.Text = GvChiTietPhieuNhap.CurrentRow.Cells[5].Value.ToString();
            txtTonKho.Text = soluongton(GvChiTietPhieuNhap.CurrentRow.Cells[0].Value.ToString());
        }

        private void format()
        {
            txtMaPN.Text = string.Empty;
            cbbMaNhaCC.Text = string.Empty;
            txtTongTien.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            radioButton2.Checked = true;
            cbbMaLoaiThuoc.Text = string.Empty;
            cbbMaThuoc.Text = string.Empty;
            txtGiaNhap.Text = string.Empty;
            txtSoLuong.Text = string.Empty;
            txtThanhTien2.Text = string.Empty;
            txtTonKho.Text = string.Empty;
            cbbDonViTinh.Text = string.Empty;
            GvChiTietPhieuNhap.DataSource = null;
            cbbMaNhaCC.DataSource = _NCC.Load_MaNhaCungCap();
            cbbMaNhaCC.DisplayMember = "TENNHACUNGCAP";
            cbbMaNhaCC.ValueMember = "MANCC";
            DTPNgayLap.Value = DateTime.Today;
        }

        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            format();
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnLapHoaDon.Enabled = true;
            btnSuaHD.Enabled = false;
            DTPNgayLap.Value = System.DateTime.Now;
        }

        private void cbbMaLoaiThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbMaThuoc.DataSource = _THUOC.Load_tenthuoc(cbbMaLoaiThuoc.SelectedValue.ToString());
            cbbMaThuoc.DisplayMember = "TENTHUOC";
            cbbMaThuoc.ValueMember = "MATHUOC";
        }

        private void cbbMaThuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mathuoc = cbbMaThuoc.SelectedValue.ToString();
            txtTonKho.Text = SoLuong(mathuoc);
            cbbDonViTinh.DataSource = _THUOC.load_donvitinh(mathuoc);
            cbbDonViTinh.DisplayMember = "DVT";
            txtSoLuong.Text = "0";
            txtGiaNhap.Text = "0";
        }

        List<ThuocCNhap_DTO> dsthuocnhap = new List<ThuocCNhap_DTO>();
        int soluong;
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoLuong.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lbsoluong.Text.ToLower());
                this.txtSoLuong.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cbbMaNhaCC.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống " + lb_ncc.Text.ToLower());
                this.cbbMaNhaCC.Focus();
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
                MessageBox.Show("Số lượng nhập không thể bằng 0", "Thông báo");
                this.txtSoLuong.Focus();
                return;
            }

            string maThuoc = cbbMaThuoc.SelectedValue.ToString();
            ThuocCNhap_DTO chonhap = dsthuocnhap.SingleOrDefault(p => p.MATHUOC == maThuoc);

            if (chonhap == null)
            {
                THUOC thuoc = _QLNTT.THUOCs.SingleOrDefault(p => p.MATHUOC == maThuoc);
                dsthuocnhap.Add(new ThuocCNhap_DTO
                {
                    MATHUOC = thuoc.MATHUOC,
                    TENTHUOC = thuoc.TENTHUOC,
                    DVT = thuoc.DVT,
                    DONGIA = Convert.ToDouble(txtGiaNhap.Text),
                    SOLUONG = soluong,
                });
            }
            else
            {
                chonhap.SOLUONG = soluong;
                MessageBox.Show("Thuốc đã có trong danh sách, cập nhật số lượng thành công", "Thông báo");
            }
            hienThidsdat();

        }

        public void hienThidsdat()
        {
            GvChiTietPhieuNhap.DataSource = null;
            GvChiTietPhieuNhap.DataSource = dsthuocnhap;
            GvPhieuNhap.DataSource = _HDN.Load_phieunhapthuoc();
        }

        public string layMaTuDong_phieunhapthuoc()
        {
            try
            {
                string g = "";
                string a = "";
                a = GvPhieuNhap.Rows[GvPhieuNhap.Rows.Count - 1].Cells[0].Value.ToString();
                int ma;
                g = "PNT";
                ma = Convert.ToInt32(a.Substring(3, 3));
                ma = ma + 1;
                if (ma < 10)
                    g = g + "00";
                if (ma >= 10)
                    g = g + "0";
                g += ma.ToString();
                return g;
            }
            catch { return "PNT001"; }
        }

        private void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            if (dsthuocnhap.Count == 0)
            {
                MessageBox.Show("Hóa đơn phải có ít nhất 1 sản phẩm", "Thông báo");
                return;
            }
            bool kt = radioButton1.Checked ? true : false;
            PHIEUNHAPTHUOC pdmt = new PHIEUNHAPTHUOC
            {
                MAPNT = layMaTuDong_phieunhapthuoc(),
                MANCC = cbbMaNhaCC.SelectedValue.ToString(),
                NGAYNHAPTHUOC = DateTime.Now,
                GHICHUNT = txtGhiChu.Text,
                TRANGTHAI = kt,
                TONGTIEN = Convert.ToDecimal(TinhTongTien())
            };
            _QLNTT.PHIEUNHAPTHUOCs.InsertOnSubmit(pdmt);
            _QLNTT.SubmitChanges();
            CHITIETPHIEUNHAPTHUOC ctdt = null;
            foreach (ThuocCNhap_DTO pdt in dsthuocnhap)
            {
                ctdt = new CHITIETPHIEUNHAPTHUOC
                {
                    MAPNT = pdmt.MAPNT,
                    MATHUOC = pdt.MATHUOC,
                    SOLUONGNHAPTHUOC = pdt.SOLUONG,
                    DVT = pdt.DVT,
                    DONGIABAN = Convert.ToDecimal(pdt.DONGIA),
                    THANHTIENNT = pdt.SOLUONG * Convert.ToDecimal(pdt.DONGIA)
                };
                _QLNTT.CHITIETPHIEUNHAPTHUOCs.InsertOnSubmit(ctdt);
            }
            _QLNTT.SubmitChanges();
            MessageBox.Show("Lập phiếu đặt thành công", "Thông báo");
            dsthuocnhap.Clear();
            GvPhieuNhap.DataSource = _HDN.Load_phieunhapthuoc();
            focus();
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLapHoaDon.Enabled = false;
            btnSuaHD.Enabled = true;
        }

        private void focus()
        {
            GvPhieuNhap.ClearSelection();
            int nRowIndex = GvPhieuNhap.Rows.Count - 1;

            GvPhieuNhap.Rows[nRowIndex].Selected = true;
            GvPhieuNhap.Rows[nRowIndex].Cells[0].Selected = true;
        }

        private void btnSuaHD_Click(object sender, EventArgs e)
        {
            try
            {
                bool kt = radioButton1.Checked ? true : false;
                _HDN.updatePNT(txtMaPN.Text, txtGhiChu.Text, kt);
                GvPhieuNhap.DataSource = _HDN.Load_phieunhapthuoc();
                MessageBox.Show("Sửa phiếu nhập thành công", "Thông báo");
            }
            catch
            {
                MessageBox.Show("Sửa phiếu nhập thất bại", "Thông báo");
            }
        }

        private void txtGiaNhap_TextChanged(object sender, EventArgs e)
        {
            if (txtSoLuong.Text != "" && txtGiaNhap.Text != "")
            {
                txtThanhTien2.Text = (Int32.Parse(txtSoLuong.Text) * Int32.Parse(txtGiaNhap.Text)).ToString();
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
                    ThuocCNhap_DTO thuocxoa = dsthuocnhap.SingleOrDefault(p => p.MATHUOC == GvChiTietPhieuNhap.CurrentRow.Cells[0].Value.ToString());
                    dsthuocnhap.Remove(thuocxoa);
                    hienThidsdat();
                    MessageBox.Show("Xoá dữ liệu  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Xoá dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
            FormNhaCC formNew = new FormNhaCC();
            formNew.Show();
        }

        private void btnXuatPN_Click(object sender, EventArgs e)
        {
            FormPhieuNhap t = new FormPhieuNhap();
            t.Show();
            this.Hide();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (btnLoc.Text == "Lọc phiếu")
            {
                GvPhieuNhap.DataSource = _HDN.Load_phieunhapthuoc(txtSearch.Text);
                btnLoc.Text = "Hủy";
            }
            else
            {
                GvPhieuNhap.DataSource = _HDN.Load_phieunhapthuoc();
                txtSearch.Text = string.Empty;
                btnLoc.Text = "Lọc phiếu";
            }
        }
    }
}
