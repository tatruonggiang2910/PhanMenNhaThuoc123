using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
   public class HangSXuatDAL_BLL
    {
        QLNTTDataContext QLNT = new QLNTTDataContext();

        #region Load dữ liệu
        public IQueryable load_HangSX()
        {
            var hangsx = from sx in QLNT.HANGSANXUATs select new { sx.MAHSX, sx.TENHSX };
            return hangsx;
        }
        #endregion

        #region Thêm xóa sửa hãng sản xuất
        public int Them_hangsx(string mahangsx, string tenhangsx)
        {
            HANGSANXUAT LT = new HANGSANXUAT { MAHSX = mahangsx, TENHSX = tenhangsx };
            try
            {
                QLNT.HANGSANXUATs.InsertOnSubmit(LT);
                QLNT.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Xoa_hangsx(string mahangsx)
        {
            try
            {
                var LT = QLNT.HANGSANXUATs.Where(t => t.MAHSX == mahangsx).Single();

                QLNT.HANGSANXUATs.DeleteOnSubmit(LT);
                QLNT.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Sua(string mahangsx, string tenhangsx)
        {
            try
            {
                HANGSANXUAT LT = QLNT.HANGSANXUATs.Where(t => t.MAHSX == mahangsx).FirstOrDefault();
                LT.TENHSX = tenhangsx;


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
