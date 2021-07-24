using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class BacLuongDAL_BLL
    {
        QLNTTDataContext QLNT = new QLNTTDataContext();

        #region Load dữ liệu
        public IQueryable loadBacLuong()
        {
            var bacl = from bl in QLNT.BACLUONGs select bl;
            return bacl;
        }
        public IQueryable Load_ChiTiet()
        {
            var bac = from bacluong in QLNT.CHITIETBACLUONGs select new { bacluong.MABAC, bacluong.MANV, bacluong.TUNGAY, bacluong.DENNGAY };
            return bac;
        }
        #endregion

        #region Thêm xóa sửa bậc lương
        public int Them_Bac(string mabac, string tenbac, double heso)
        {
            BACLUONG bc = new BACLUONG { MABAC = mabac, TENBAC = tenbac, HESO = heso };
            try
            {
                QLNT.BACLUONGs.InsertOnSubmit(bc);
                QLNT.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Xoa_Bac(string MaBac)
        {
            try
            {
                var xxs = QLNT.BACLUONGs.Where(t => t.MABAC == MaBac).Single();

                QLNT.BACLUONGs.DeleteOnSubmit(xxs);
                QLNT.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Sua(string tenbac, double heso, string mabac)
        {
            try
            {
                BACLUONG bc = QLNT.BACLUONGs.Where(t => t.MABAC == mabac).FirstOrDefault();
                bc.HESO = heso;
                bc.TENBAC = tenbac;

                QLNT.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;

            }
        }
        #endregion

        #region Thêm xóa sửa CT bậc lương
        public int Xoa_CTBac(string MaBac, string manv)
        {
            try
            {
                var xxs = QLNT.CHITIETBACLUONGs.Where(t => t.MABAC == MaBac && t.MANV == manv).Single();

                QLNT.CHITIETBACLUONGs.DeleteOnSubmit(xxs);
                QLNT.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Them_CTBac(string mabac, string manv, DateTime tungay, DateTime denngay)
        {
            CHITIETBACLUONG ct = new CHITIETBACLUONG { MABAC = mabac, MANV = manv, TUNGAY = tungay, DENNGAY = denngay };
            try
            {
                QLNT.CHITIETBACLUONGs.InsertOnSubmit(ct);
                QLNT.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Sua_CTBL(string manv, string mabac, DateTime tungay, DateTime denngay)
        {
            try
            {
                CHITIETBACLUONG bac = QLNT.CHITIETBACLUONGs.Where(t => t.MANV == manv & t.MABAC == mabac).FirstOrDefault();


                bac.TUNGAY = tungay;
                bac.DENNGAY = denngay;

                QLNT.SubmitChanges();
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
