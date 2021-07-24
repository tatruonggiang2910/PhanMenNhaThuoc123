using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_BLL;
namespace DAL_BLL
{
    public class KhachHangDALBLL
    {
        QLNTTDataContext data = new QLNTTDataContext();

        #region Load dữ liệu
        public IQueryable<KHACHHANG> Load_KhachHang()
        {
            var kh = from KhachHang in data.KHACHHANGs select KhachHang;
            return kh;
        }
        public IQueryable Load_khach1(string mahdb)
        {
            var khach = from kh1 in data.KHACHHANGs
                        join Hd in data.HOADONBANs
                            on kh1.MAKH equals Hd.MAKH
                        where Hd.MAHDB == mahdb
                        select new { kh1.HOTENKH, kh1.MAKH };
            return khach;

        }
        public IQueryable Load_TenKhachHang()
        {
            var kh = from KhachHang in data.KHACHHANGs select new { KhachHang.MAKH, KhachHang.HOTENKH };
            return kh;
        }
        public IQueryable<string> Load_LoaiKhach()
        {
            var kh = from KhachHang in data.KHACHHANGs select KhachHang.LOAIKHACHHANG;
            return kh;
        }
        public IQueryable Load_DiaChi(string makh)
        {
            var kh = from KhachHang in data.KHACHHANGs where KhachHang.MAKH == makh select new { KhachHang.DIACHIKH };
            return kh;
        }
        public List<KHACHHANG> Load_diachikh(string makh)
        {
            List<KHACHHANG> dc = new List<KHACHHANG>();
            var diachi1 = (from diachi in data.KHACHHANGs
                           where diachi.MAKH == makh
                           select diachi).ToList();
            dc.AddRange(diachi1);
            return dc;
        }
        public IQueryable getKhachHang()
        {
            var dgv_khachhang = from kh in data.KHACHHANGs select new { kh.MAKH, kh.MAQUANHUYEN, kh.HOTENKH, kh.LOAIKHACHHANG, kh.NGAYSINHKH, kh.GIOITINHKH, kh.DIACHIKH, kh.SODIENTHOAIKH };
            return dgv_khachhang;
        }
        public List<KHACHHANG> getKhachHangLst()
        {
            return data.KHACHHANGs.Select(k => k).ToList<KHACHHANG>();
        }
        #endregion

        #region Thêm xóa sửa khách hàng
        public bool insertKhachHang(string maKH, string maQH, string tenKH, string loaiKH, string ngaySinh, string gioiTinh, string diaChi, string sDT)
        {
            try
            {
                KHACHHANG khachhang = new KHACHHANG();
                khachhang.MAKH = maKH;
                khachhang.MAQUANHUYEN = maQH;
                khachhang.HOTENKH = tenKH;
                khachhang.LOAIKHACHHANG = loaiKH;
                khachhang.NGAYSINHKH = Convert.ToDateTime(ngaySinh);
                khachhang.GIOITINHKH = gioiTinh;
                khachhang.DIACHIKH = diaChi;
                khachhang.SODIENTHOAIKH = sDT; 
                data.KHACHHANGs.InsertOnSubmit(khachhang);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteKhachHang(string maKH)
        {
            try
            {
                KHACHHANG khachhang = data.KHACHHANGs.Where(t => t.MAKH == maKH).FirstOrDefault();
                data.KHACHHANGs.DeleteOnSubmit(khachhang);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateKhachHang(string maKH, string maQH, string tenKH, string loaiKH, string ngaySinh, string gioiTinh, string diaChi, string sDT)
        {
            KHACHHANG khachhang = data.KHACHHANGs.Where(k => k.MAKH == maKH).FirstOrDefault();
            if (khachhang != null)
            {
                khachhang.MAKH = maKH;
                khachhang.MAQUANHUYEN = maQH;
                khachhang.HOTENKH = tenKH;
                khachhang.LOAIKHACHHANG = loaiKH;
                khachhang.NGAYSINHKH = Convert.ToDateTime(ngaySinh);
                khachhang.GIOITINHKH = gioiTinh;
                khachhang.DIACHIKH = diaChi;
                khachhang.SODIENTHOAIKH = sDT;
                data.SubmitChanges();
                return true;
            }
            return false;
        }
        #endregion
    }
}
