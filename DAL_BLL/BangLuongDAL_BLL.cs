using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
   public class BangLuongDAL_BLL
    {
        QLNTTDataContext _QLNT = new QLNTTDataContext();

        #region Load dữ liệu
        public IQueryable loadluong()
        {
            var bluong = from bl in _QLNT.BANGLUONGs select new { bl.MABANGLUONG, bl.MANV, bl.LUONGTHUCTE, bl.NGAYAPDUNG, bl.GHICHUBL };
            return bluong;
        }
        public IQueryable load_ten(string ma)
        {
            var query = from c in _QLNT.NHANVIENs
                        where c.MANV == ma
                        select c.HOTENNV;
            return query;
        }
        public IQueryable load_luongcb(string ma)
        {
            var query = from c in _QLNT.NHANVIENs
                        where c.MANV == ma
                        select c.MUCLUONGCOBAN;
            return query;
        }
        public IQueryable load_HeSoLuong(string ma)
        {
            var query = from c in _QLNT.NHANVIENs
                        join ct in _QLNT.CHITIETBACLUONGs
                         on c.MANV equals ct.MANV
                        join heso in _QLNT.BACLUONGs
                         on ct.MABAC equals heso.MABAC
                        where c.MANV == ma
                        select heso.HESO;
            return query;
        }
        public IQueryable load_tungay(string ma)
        {
            var query = from c in _QLNT.NHANVIENs
                        join ct in _QLNT.CHITIETBACLUONGs
                         on c.MANV equals ct.MANV
                        where c.MANV == ma
                        select ct.TUNGAY;
            return query;
        }
        public IQueryable load_denngay(string ma)
        {
            var query = from c in _QLNT.NHANVIENs
                        join ct in _QLNT.CHITIETBACLUONGs
                         on c.MANV equals ct.MANV
                        where c.MANV == ma
                        select ct.DENNGAY;
            return query;
        }
        #endregion

        #region Thêm xóa sửa bảng lương
        public int Them_bangluong(string mabangluong, string manv, decimal luongtt, DateTime ngayapdung, string ghichu)
        {
            BANGLUONG BL = new BANGLUONG { MABANGLUONG = mabangluong, MANV = manv, LUONGTHUCTE = luongtt, NGAYAPDUNG = ngayapdung, GHICHUBL = ghichu };
            try
            {
                _QLNT.BANGLUONGs.InsertOnSubmit(BL);
                _QLNT.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Xoa_bangluong(string mabl)
        {
            try
            {
                var query = _QLNT.BANGLUONGs.Where(p => p.MABANGLUONG == mabl).Single();
                _QLNT.BANGLUONGs.DeleteOnSubmit(query);
                _QLNT.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Sua_bangluong(string mabl, DateTime ngayapdung, string ghichu)
        {

            try
            {
                BANGLUONG BL = _QLNT.BANGLUONGs.Where(p => p.MABANGLUONG == mabl).SingleOrDefault();
                BL.NGAYAPDUNG = ngayapdung;
                BL.GHICHUBL = ghichu;
                _QLNT.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }

        }
        #endregion
    }
}
