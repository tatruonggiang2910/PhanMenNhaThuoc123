using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
   public class XuatXuDAL_BLL
    {
        QLNTTDataContext QLNT = new QLNTTDataContext();

        #region Load dữ liệu
        public IQueryable load_XX()
        {
            var Xux = from xx in QLNT.XUATXUs select new { xx.MAXUATXU, xx.TENXUATXU, xx.LOAIXUATXU };
            return Xux;
        }
        #endregion

        #region Thêm xóa sửa xuất xứ
        public int Them_XX(string maxx, string tenxx, string loaixx)
        {
            XUATXU XX = new XUATXU { MAXUATXU = maxx, TENXUATXU = tenxx, LOAIXUATXU = loaixx };
            try
            {
                QLNT.XUATXUs.InsertOnSubmit(XX);
                QLNT.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Xoa_XX(string MaXX)
        {
            try
            {
                var XX = QLNT.XUATXUs.Where(t => t.MAXUATXU == MaXX).Single();

                QLNT.XUATXUs.DeleteOnSubmit(XX);
                QLNT.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Sua(string maxx, string tenxx, string loaixx)
        {
            try
            {
                XUATXU XX = QLNT.XUATXUs.Where(t => t.MAXUATXU == maxx).FirstOrDefault();
                XX.TENXUATXU = tenxx;
                XX.LOAIXUATXU = loaixx;


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
