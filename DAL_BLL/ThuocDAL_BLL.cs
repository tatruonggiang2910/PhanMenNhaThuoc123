using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Recognition;

namespace DAL_BLL
{
    public class ThuocDAL_BLL
    {
        QLNTTDataContext _QLNTT = new QLNTTDataContext();

        #region Load thuốc

        public IQueryable Load_tenthuoc(string maloai)
        {
            var tenthuoc = from tt in _QLNTT.THUOCs where tt.MALOAITHUOC == maloai select new { tt.TENTHUOC, tt.MATHUOC };
            return tenthuoc;

        }

        public List<THUOC> Load_xuatxu(string mathuoc)
        {
            List<THUOC> thuoc = new List<THUOC>();
            var xx = (from xuatxu in _QLNTT.XUATXUs
                      join th in _QLNTT.THUOCs
                      on xuatxu.MAXUATXU equals th.MAXUATXU
                      where th.MATHUOC == mathuoc
                      select xuatxu.TENXUATXU).ToList();
            // thuoc.AddRange(xx);
            return thuoc;
        }

        //public IQueryable Load_thuoc()
        //{
        //    var th = from thuoc in _QLNTT.THUOCs select thuoc;
        //    return th;
        //}

        public IQueryable load_donvitinh(string mathuoc)
        {
            var slt = from sl in _QLNTT.THUOCs where sl.MATHUOC == mathuoc select new { sl.DVT };
            return slt;
        }

        public IQueryable load_donvitinh_Thuoc()
        {
            var slt = from sl in _QLNTT.THUOCs select new { sl.DVT };
            return slt.Distinct();
        }

        public List<THUOC> Load_soluongton(string mathuoc)
        {
            List<THUOC> thuoc = new List<THUOC>();
            var slt = (from dg in _QLNTT.THUOCs
                       where dg.MATHUOC == mathuoc
                       select dg).ToList();
            thuoc.AddRange(slt);
            return thuoc;
        }

        public List<THUOC> Load_dongia(string mathuoc)
        {
            List<THUOC> thuoc = new List<THUOC>();
            var dongia = (from dg in _QLNTT.THUOCs
                          where dg.MATHUOC == mathuoc
                          select dg).ToList();
            thuoc.AddRange(dongia);
            return thuoc;
        }

        public List<THUOC> Load_soluong(string mathuoc)
        {
            List<THUOC> thuoc = new List<THUOC>();
            var soluong = (from sl in _QLNTT.THUOCs
                           where sl.MATHUOC == mathuoc
                           select sl).ToList();
            thuoc.AddRange(soluong);
            return thuoc;
        }

        public List<THUOC> Load_DVT(string mathuoc)
        {
            List<THUOC> thuoc = new List<THUOC>();
            var DVT = (from dvt in _QLNTT.THUOCs
                       where dvt.MATHUOC == mathuoc
                       select dvt).ToList();
            thuoc.AddRange(DVT);
            return thuoc;
        }

        public IQueryable Load_thuoc()
        {
            var th = from thuoc in _QLNTT.THUOCs
                     select new
                     {
                         thuoc.MATHUOC,
                         thuoc.MALOAITHUOC,
                         thuoc.MAHSX,
                         thuoc.MAXUATXU,
                         thuoc.TENTHUOC,
                         thuoc.HINHTHUOC,
                         thuoc.THANHPHAN,
                         thuoc.CONGDUNG,
                         thuoc.BAOQUAN,
                         thuoc.GHICHUTHUOC,
                         thuoc.DVT,
                         thuoc.SOLOTHUOC,
                         thuoc.NGAYSANXUAT,
                         thuoc.HANSUDUNG,
                         thuoc.DONGIATHUOC,
                         thuoc.SOLUONGTON
                     };
            return th;
        }

        public List<THUOC> Load_Thuoc_list()
        {
            List<THUOC> thuoc = new List<THUOC>();
            var tenThuoc = (from tt in _QLNTT.THUOCs select tt).ToList();
            thuoc.AddRange(tenThuoc);
            return thuoc;
        }

        #endregion

        #region Thêm xóa sửa thuốc

        public int Them_Thuoc(string mathuoc, string maloaithuoc, string mahsx, string maxuatxu, string tenthuoc, string hinhthuoc, string thanhphan
            , string congdung, string baoquan, string ghichu, string dvt, int solothuoc, DateTime ngaysx, DateTime hansd, decimal dongia, int soluongton)
        {
            THUOC TH = new THUOC
            {
                MATHUOC = mathuoc,
                MALOAITHUOC = maloaithuoc,
                MAHSX = mahsx,
                MAXUATXU = maxuatxu,
                TENTHUOC = tenthuoc,
                HINHTHUOC = hinhthuoc,
                THANHPHAN = thanhphan,
                CONGDUNG = congdung,
                BAOQUAN = baoquan,
                GHICHUTHUOC = ghichu,
                DVT = dvt,
                SOLOTHUOC = solothuoc,
                NGAYSANXUAT = ngaysx,
                HANSUDUNG = hansd,
                DONGIATHUOC = dongia,
                SOLUONGTON = soluongton
            };
            try
            {
                _QLNTT.THUOCs.InsertOnSubmit(TH);
                _QLNTT.SubmitChanges();
                return 1;
            }

            catch
            {
                return 0;
            }
        }
        public int Xoa_Thuoc(string Mathuoc)
        {
            try
            {
                var TH = _QLNTT.THUOCs.Where(t => t.MATHUOC == Mathuoc).Single();

                _QLNTT.THUOCs.DeleteOnSubmit(TH);
                _QLNTT.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Sua(string mathuoc, string maloaithuoc, string mahsx, string maxuatxu, string tenthuoc, string hinhthuoc,
            string thanhphan, string congdung,
            string baoquan, string ghichu, string dvt, int solothuoc, DateTime ngaysx, DateTime hansd, decimal dongia)
        {
            try
            {
                THUOC TH = _QLNTT.THUOCs.Where(t => t.MATHUOC == mathuoc).FirstOrDefault();
                TH.MALOAITHUOC = maloaithuoc;
                TH.MAHSX = mahsx;
                TH.MAXUATXU = maxuatxu;
                TH.TENTHUOC = tenthuoc;
                TH.HINHTHUOC = hinhthuoc;
                TH.THANHPHAN = thanhphan;
                TH.CONGDUNG = congdung;
                TH.BAOQUAN = baoquan;
                TH.GHICHUTHUOC = ghichu;
                TH.DVT = dvt;
                TH.SOLOTHUOC = solothuoc;
                TH.NGAYSANXUAT = ngaysx;
                TH.HANSUDUNG = hansd;
                TH.DONGIATHUOC = dongia;

                _QLNTT.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;

            }
        }
        #endregion

        #region Tìm kiếm thuốc

        public List<THUOC> search_MaThuoc(string maThuoc)
        {
            var query = (from th in _QLNTT.THUOCs.Where(p => p.MATHUOC.Contains(maThuoc))
                         select th).ToList();
            return query;
        }

        public List<THUOC> search_NgaySX(DateTime ngaySX)
        {
            var query = (from th in _QLNTT.THUOCs.Where(p => p.HANSUDUNG == ngaySX)
                         select th).ToList();
            return query;
        }

        public List<THUOC> search_congDung(string congDung)
        {
            var query = (from th in _QLNTT.THUOCs.Where(p => p.CONGDUNG.Contains(congDung))
                         select th).ToList();
            return query;
        }

        public List<THUOC> search_tenThuoc(string tenThuoc)
        {
            var query = (from th in _QLNTT.THUOCs.Where(p => p.TENTHUOC.Contains(tenThuoc))
                         select th).ToList();
            return query;
        }


        #endregion

        #region Thuốc tồn kho

        public IQueryable Search_SoLuongTon(int Tu, int Den)
        {
            var th = from thuoc in _QLNTT.THUOCs 
                     where thuoc.SOLUONGTON >= Tu && thuoc.SOLUONGTON <= Den
                     select new
                     {
                         thuoc.MATHUOC,
                         thuoc.MALOAITHUOC,
                         thuoc.MAHSX,
                         thuoc.MAXUATXU,
                         thuoc.TENTHUOC,
                         thuoc.HINHTHUOC,
                         thuoc.THANHPHAN,
                         thuoc.CONGDUNG,
                         thuoc.BAOQUAN,
                         thuoc.GHICHUTHUOC,
                         thuoc.DVT,
                         thuoc.SOLOTHUOC,
                         thuoc.NGAYSANXUAT,
                         thuoc.HANSUDUNG,
                         thuoc.DONGIATHUOC,
                         thuoc.SOLUONGTON
                     };
            return th;
        }

        public IQueryable Search_NgayHetHan(DateTime Tu, DateTime Den)
        {
            var th = from thuoc in _QLNTT.THUOCs
                     where thuoc.HANSUDUNG >= Tu && thuoc.HANSUDUNG <= Den
                     select new
                     {
                         thuoc.MATHUOC,
                         thuoc.MALOAITHUOC,
                         thuoc.MAHSX,
                         thuoc.MAXUATXU,
                         thuoc.TENTHUOC,
                         thuoc.HINHTHUOC,
                         thuoc.THANHPHAN,
                         thuoc.CONGDUNG,
                         thuoc.BAOQUAN,
                         thuoc.GHICHUTHUOC,
                         thuoc.DVT,
                         thuoc.SOLOTHUOC,
                         thuoc.NGAYSANXUAT,
                         thuoc.HANSUDUNG,
                         thuoc.DONGIATHUOC,
                         thuoc.SOLUONGTON
                     };
            return th;
        }

        public IQueryable Search_ThuocHetHan(DateTime NgayHomNay)
        {
            var th = from thuoc in _QLNTT.THUOCs
                     where thuoc.HANSUDUNG < NgayHomNay
                     select new
                     {
                         thuoc.MATHUOC,
                         thuoc.MALOAITHUOC,
                         thuoc.MAHSX,
                         thuoc.MAXUATXU,
                         thuoc.TENTHUOC,
                         thuoc.HINHTHUOC,
                         thuoc.THANHPHAN,
                         thuoc.CONGDUNG,
                         thuoc.BAOQUAN,
                         thuoc.GHICHUTHUOC,
                         thuoc.DVT,
                         thuoc.SOLOTHUOC,
                         thuoc.NGAYSANXUAT,
                         thuoc.HANSUDUNG,
                         thuoc.DONGIATHUOC,
                         thuoc.SOLUONGTON
                     };
            return th;
        }

        public List<THUOC> XuatThuocHetHan(DateTime NgayHomNay)
        {
            return _QLNTT.THUOCs.Where(t => t.HANSUDUNG < NgayHomNay).ToList();
        }

        #endregion
    }
}
