using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class HoaDonBamDAL_BLL
    {
        
        QLNTTDataContext _QLNTT = new QLNTTDataContext();

        int Thanhtien;
        int VAT;
        int tongtien;

        public int tinhTienHDB(int gia, int soluong)
        {

            return Thanhtien = soluong * gia;
        }
        public int TinhVAT(int thanhtien)
        {
            VAT = Thanhtien * 10 / 100;
            return VAT;
        }
        public int tinhthanhtien(int thanhtien, int vat)
        {
            tongtien = thanhtien + vat;
            return tongtien;
        }

        public List<CHITIETHOADONBAN> DSThuocChonMua(string mhd, string mathuoc)
        {
            return _QLNTT.CHITIETHOADONBANs.Where(t => t.MATHUOC == mathuoc && t.MAHDB == mhd).ToList();
        }

        #region Load dữ liệu hóa đơn

        public IQueryable Load_Hoadonban()
        {
            var hdb = from hoadonban in _QLNTT.HOADONBANs select new { hoadonban.MAHDB, hoadonban.NGAYLAPBAN };
            return hdb;
        }

        public IQueryable Load_Hoadonban(string maHDB)
        {
            return (from hdb in _QLNTT.HOADONBANs.Where(t => t.MAHDB.Contains(maHDB)) select new { hdb.MAHDB, hdb.NGAYLAPBAN });
        }

        public IQueryable Load_CTHoadonban(string mahd)
        {
            return (from cthoadonban in _QLNTT.CHITIETHOADONBANs
                    join thuoc in _QLNTT.THUOCs on cthoadonban.MATHUOC equals thuoc.MATHUOC
                    where cthoadonban.MAHDB == mahd
                    select new { cthoadonban.MATHUOC, thuoc.TENTHUOC, thuoc.DVT, thuoc.DONGIATHUOC, cthoadonban.SOLUONGBAN, cthoadonban.THANHTIENBAN });
        }

        public List<HOADONBAN> Load_VAT(string mhd)
        {
            List<HOADONBAN> thuoc = new List<HOADONBAN>();
            var DVT = (from vat in _QLNTT.HOADONBANs
                       where vat.MAHDB == mhd
                       select vat).ToList();
            thuoc.AddRange(DVT);
            return thuoc;
        }

        #endregion

        #region Thống kê thuốc bán

        public IQueryable ThongKe_ThuocBan(string maThuoc, DateTime Tu, DateTime Den)
        { 
            return (from cthoadonban in _QLNTT.CHITIETHOADONBANs
                    join thuoc in _QLNTT.THUOCs on cthoadonban.MATHUOC equals thuoc.MATHUOC
                    join hdb in _QLNTT.HOADONBANs on cthoadonban.MAHDB equals hdb.MAHDB
                    where (cthoadonban.MATHUOC == maThuoc && hdb.NGAYLAPBAN >= Tu && hdb.NGAYLAPBAN <= Den)
                    select new { cthoadonban.MATHUOC, thuoc.TENTHUOC, hdb.MAHDB, hdb.NGAYLAPBAN, thuoc.DONGIATHUOC, cthoadonban.SOLUONGBAN, cthoadonban.THANHTIENBAN, thuoc.SOLUONGTON});
        }

        #endregion

        #region Thống kê hóa đơn bán

        public IQueryable ThongKe_TheoNgay(DateTime tungay, DateTime denngay)
        {
            return (from tk in _QLNTT.HOADONBANs
                    where (tk.NGAYLAPBAN <= denngay && tk.NGAYLAPBAN >= tungay)
                    select new { tk.MAHDB, tk.MAKH, tk.MANV, tk.NGAYLAPBAN, tk.VAT, tk.TONGTIENBAN });
        }

        public IQueryable ThongKe_TheoNgay_KH(DateTime tungay, DateTime denngay, string maKH)
        {
            return (from tk in _QLNTT.HOADONBANs
                    where (tk.NGAYLAPBAN <= denngay && tk.NGAYLAPBAN >= tungay && tk.MAKH == maKH)
                    select new { tk.MAHDB, tk.MAKH, tk.MANV, tk.NGAYLAPBAN, tk.VAT, tk.TONGTIENBAN });
        }

        public IQueryable ThongKe_TheoNgay_NV(DateTime tungay, DateTime denngay, string manv)
        {
            return (from tk in _QLNTT.HOADONBANs
                    where (tk.NGAYLAPBAN <= denngay && tk.NGAYLAPBAN >= tungay && tk.MANV == manv)
                    select new { tk.MAHDB, tk.MAKH, tk.MANV, tk.NGAYLAPBAN, tk.VAT, tk.TONGTIENBAN });
        }

        public IQueryable ThongKe_TheoNgay_TT(DateTime tungay, DateTime denngay, int thanhtientu, int thanhtientoi)
        {
            return (from tk in _QLNTT.HOADONBANs
                    where (tk.NGAYLAPBAN <= denngay && tk.NGAYLAPBAN >= tungay && tk.TONGTIENBAN >= thanhtientu && tk.TONGTIENBAN <= thanhtientoi)
                    select new { tk.MAHDB, tk.MAKH, tk.MANV, tk.NGAYLAPBAN, tk.VAT, tk.TONGTIENBAN });
        }

        #endregion

        #region Thêm xóa sửa hóa đơn bán
        public void insertHDB(string mhd, string makh, string manv, DateTime ngaylap, double VAT, decimal tongtien)
        {
            HOADONBAN hdb = new HOADONBAN
            {
                MAHDB = mhd,
                MAKH = makh,
                MANV = manv,
                NGAYLAPBAN = ngaylap,
                VAT = VAT,
                TONGTIENBAN = tongtien
            };
            _QLNTT.HOADONBANs.InsertOnSubmit(hdb);
            _QLNTT.SubmitChanges();
        }

        #endregion

        #region Thêm xóa sửa chi tiết hóa đơn bán

        public void insertCTHDB(string mhd, string mathuoc, int soluong, decimal thanhtien)
        {
            CHITIETHOADONBAN cthdb = new CHITIETHOADONBAN
            {
                MAHDB = mhd,
                MATHUOC = mathuoc,
                SOLUONGBAN = soluong,
                THANHTIENBAN = thanhtien,
            };
            _QLNTT.CHITIETHOADONBANs.InsertOnSubmit(cthdb);
            _QLNTT.SubmitChanges();
        }

        public void updateCTHDB(string mhd, string mathuoc, int soluong, decimal thanhtien)
        {
            CHITIETHOADONBAN cthdb = _QLNTT.CHITIETHOADONBANs.Where(t => t.MAHDB == mhd && t.MATHUOC == mathuoc).FirstOrDefault();
            cthdb.SOLUONGBAN = soluong;
            cthdb.THANHTIENBAN = thanhtien;
            _QLNTT.SubmitChanges();
        }

        public void deleteCTHDB(string mhd, string mathuoc)
        {
            CHITIETHOADONBAN cthdb = _QLNTT.CHITIETHOADONBANs.Where(t => t.MAHDB == mhd && t.MATHUOC == mathuoc).FirstOrDefault();
            _QLNTT.CHITIETHOADONBANs.DeleteOnSubmit(cthdb);
            _QLNTT.SubmitChanges();
        }
        #endregion
    }
}
