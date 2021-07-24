using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class HoaDonNhapDAL_BLL
    {
        QLNTTDataContext _QLNTT = new QLNTTDataContext();

        public List<CHITIETPHIEUNHAPTHUOC> DSThuocChonNhap(string mpn, string mathuoc)
        {
            return _QLNTT.CHITIETPHIEUNHAPTHUOCs.Where(t => t.MATHUOC == mathuoc && t.MAPNT == mpn).ToList();
        }

        #region Load dữ liệu
        public IQueryable Load_phieunhapthuoc()
        {
            var pnt = from phieunhapthuoc in _QLNTT.PHIEUNHAPTHUOCs select new { phieunhapthuoc.MAPNT, phieunhapthuoc.NGAYNHAPTHUOC };
            return pnt;
        }

        public IQueryable Load_phieunhapthuoc(string maPNT)
        {
            return (from pnt in _QLNTT.PHIEUNHAPTHUOCs.Where(t => t.MAPNT.Contains(maPNT)) select new { pnt.MAPNT, pnt.NGAYNHAPTHUOC });
        }

        public IQueryable Load_CTphieunhapthuoc(string mapn)
        {
            return (from ctphieunhapthuoc in _QLNTT.CHITIETPHIEUNHAPTHUOCs
                    join thuoc in _QLNTT.THUOCs on ctphieunhapthuoc.MATHUOC equals thuoc.MATHUOC
                    where ctphieunhapthuoc.MAPNT == mapn
                    select new { ctphieunhapthuoc.MATHUOC, thuoc.TENTHUOC, thuoc.DVT, ctphieunhapthuoc.DONGIABAN, ctphieunhapthuoc.SOLUONGNHAPTHUOC, ctphieunhapthuoc.THANHTIENNT });
        }

        public List<string> Load_ghichu(string mapn)
        {
            List<string> pnt = new List<string>();
            var ghichu = (from gc in _QLNTT.PHIEUNHAPTHUOCs
                          where gc.MAPNT == mapn
                          select gc.GHICHUNT).ToList();
            pnt.AddRange(ghichu);
            return pnt;
        }

        public List<bool?> Load_trangthai(string mapn)
        {
            List<bool?> pnt = new List<bool?>();
            var ghichu = (from gc in _QLNTT.PHIEUNHAPTHUOCs
                          where gc.MAPNT == mapn
                          select gc.TRANGTHAI).ToList();
            pnt.AddRange(ghichu);
            return pnt;
        }

        #endregion

        #region Thống kê phiếu nhập

        public IQueryable ThongKe_TheoNgay(DateTime tungay, DateTime denngay)
        {
            return (from tk in _QLNTT.PHIEUNHAPTHUOCs
                    where (tk.NGAYNHAPTHUOC <= denngay && tk.NGAYNHAPTHUOC >= tungay)
                    select new { tk.MAPNT, tk.MANCC, tk.NGAYNHAPTHUOC, tk.GHICHUNT, tk.TRANGTHAI, tk.TONGTIEN });
        }

        public IQueryable ThongKe_TheoNgay_NCC(DateTime tungay, DateTime denngay, string mancc)
        {
            return (from tk in _QLNTT.PHIEUNHAPTHUOCs
                    where (tk.NGAYNHAPTHUOC <= denngay && tk.NGAYNHAPTHUOC >= tungay && tk.MANCC == mancc)
                    select new { tk.MAPNT, tk.MANCC, tk.NGAYNHAPTHUOC, tk.GHICHUNT, tk.TRANGTHAI, tk.TONGTIEN });
        }

        public IQueryable ThongKe_TheoNgay_TT(DateTime tungay, DateTime denngay, int thanhtientu, int thanhtientoi)
        {
            return (from tk in _QLNTT.PHIEUNHAPTHUOCs
                    where (tk.NGAYNHAPTHUOC <= denngay && tk.NGAYNHAPTHUOC >= tungay && tk.TONGTIEN >= thanhtientu && tk.TONGTIEN <= thanhtientoi)
                    select new { tk.MAPNT, tk.MANCC, tk.NGAYNHAPTHUOC, tk.GHICHUNT, tk.TRANGTHAI, tk.TONGTIEN });
        }

        #endregion

        #region Thống kê thuốc nhập

        public IQueryable ThongKe_ThuocNhap(string maThuoc, DateTime Tu, DateTime Den)
        {
            return (from ctpnt in _QLNTT.CHITIETPHIEUNHAPTHUOCs
                    join thuoc in _QLNTT.THUOCs on ctpnt.MATHUOC equals thuoc.MATHUOC
                    join pnt in _QLNTT.PHIEUNHAPTHUOCs on ctpnt.MAPNT equals pnt.MAPNT
                    where (ctpnt.MATHUOC == maThuoc && pnt.NGAYNHAPTHUOC >= Tu && pnt.NGAYNHAPTHUOC <= Den)
                    select new { ctpnt.MATHUOC, thuoc.TENTHUOC, pnt.MAPNT, pnt.NGAYNHAPTHUOC, ctpnt.SOLUONGNHAPTHUOC, thuoc.SOLUONGTON });
        }

        #endregion

        #region Thêm sửa phiếu nhập thuốc
        public void insertPNT(string mpn, string mancc, DateTime ngaynhap, string ghichu, bool trangthai, decimal tongtien)
        {
            PHIEUNHAPTHUOC pnt = new PHIEUNHAPTHUOC
            {
                MAPNT = mpn,
                MANCC = mancc,
                NGAYNHAPTHUOC = ngaynhap,
                GHICHUNT = ghichu,
                TRANGTHAI = trangthai,
                TONGTIEN = 0
            };
            _QLNTT.PHIEUNHAPTHUOCs.InsertOnSubmit(pnt);
            _QLNTT.SubmitChanges();
        }

        public void updatePNT(string mpn, string ghichu, bool trangthai)
        {
            PHIEUNHAPTHUOC pnt = _QLNTT.PHIEUNHAPTHUOCs.Where(t => t.MAPNT == mpn).FirstOrDefault();
            pnt.GHICHUNT = ghichu;
            pnt.TRANGTHAI = trangthai;
            _QLNTT.SubmitChanges();
        }
        #endregion

        #region Thêm xóa sửa chi tiết phiếu nhập thuốc
        public void insertCTPNT(string mpn, string mathuoc, int soluongnhap, string dvt, decimal dongiaban, decimal thanhtien)
        {
            CHITIETPHIEUNHAPTHUOC ctpnt = new CHITIETPHIEUNHAPTHUOC
            {
                MAPNT = mpn,
                MATHUOC = mathuoc,
                SOLUONGNHAPTHUOC = soluongnhap,
                DVT = dvt,
                THANHTIENNT = thanhtien,
                DONGIABAN = dongiaban
            };
            _QLNTT.CHITIETPHIEUNHAPTHUOCs.InsertOnSubmit(ctpnt);
            _QLNTT.SubmitChanges();
        }

        public void updateCTPNT(string mpn, string mathuoc, int soluongnhap, decimal dongiaban, decimal thanhtien)
        {
            CHITIETPHIEUNHAPTHUOC ctpnt = _QLNTT.CHITIETPHIEUNHAPTHUOCs.Where(t => t.MAPNT == mpn && t.MATHUOC == mathuoc).FirstOrDefault();
            ctpnt.SOLUONGNHAPTHUOC = soluongnhap;
            ctpnt.DONGIABAN = dongiaban;
            ctpnt.THANHTIENNT = thanhtien;
            _QLNTT.SubmitChanges();
        }

        public void deleteCTPNT(string mpn, string mathuoc)
        {
            CHITIETPHIEUNHAPTHUOC ctpnt = _QLNTT.CHITIETPHIEUNHAPTHUOCs.Where(t => t.MAPNT == mpn && t.MATHUOC == mathuoc).FirstOrDefault();
            _QLNTT.CHITIETPHIEUNHAPTHUOCs.DeleteOnSubmit(ctpnt);
            _QLNTT.SubmitChanges();
        }


        #endregion
    }
}
