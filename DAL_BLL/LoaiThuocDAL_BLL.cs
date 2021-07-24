using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class LoaiThuocDAL_BLL
    {
        QLNTTDataContext _QLNTT = new QLNTTDataContext();

        #region Load dữ liệu
        public IQueryable<LOAITHUOC> load_loaiThuoc()
        {
            var loai = from lt in _QLNTT.LOAITHUOCs select lt;
            return loai;
        }
        public IQueryable<string> load_TenLoai()
        {
            var tenloai = from tl in _QLNTT.LOAITHUOCs select tl.TENLOAITHUOC;
            return tenloai;
        }
        public IQueryable load_MaLoai()
        {
            var Maloai = from tl in _QLNTT.LOAITHUOCs select tl.MALOAITHUOC;
            return Maloai;
        }
        public IQueryable Load_tenThuoctheoLoai(string Maloai)
        {
            var tenthuoc = from tt in _QLNTT.THUOCs
                           join loai in _QLNTT.LOAITHUOCs on tt.MALOAITHUOC equals loai.MALOAITHUOC
                           where loai.TENLOAITHUOC == Maloai
                           select tt;
            return tenthuoc;
        }
        public IQueryable load_Loai_Thuoc()
        {
            var loaiThuoc = from lt in _QLNTT.LOAITHUOCs select new { lt.MALOAITHUOC, lt.MAKE, lt.TENLOAITHUOC };
            return loaiThuoc;
        }
        #endregion

        #region Thêm xóa sửa loại thuốc
        public int Them_Loai(string maloai, string tenloai, string make)
        {
            LOAITHUOC LT = new LOAITHUOC { MAKE = make, TENLOAITHUOC = tenloai, MALOAITHUOC = maloai };
            try
            {
                _QLNTT.LOAITHUOCs.InsertOnSubmit(LT);
                _QLNTT.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Xoa_loai(string MaLoai)
        {
            try
            {
                var LT = _QLNTT.LOAITHUOCs.Where(t => t.MALOAITHUOC == MaLoai).Single();

                _QLNTT.LOAITHUOCs.DeleteOnSubmit(LT);
                _QLNTT.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Sua(string maloai, string make, string tenloaithuoc)
        {
            try
            {
                LOAITHUOC LT = _QLNTT.LOAITHUOCs.Where(t => t.MALOAITHUOC == maloai).FirstOrDefault();
                LT.MAKE = make;
                LT.TENLOAITHUOC = tenloaithuoc;


                _QLNTT.SubmitChanges();
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
