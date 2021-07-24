using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
   public class KeThuocDAL_BLL
    {
        QLNTTDataContext QLNT = new QLNTTDataContext();

        #region Load dữ liệu
        public IQueryable load_KeThuoc()
        {
            var kethuoc = from kt in QLNT.KETHUOCs select new { kt.MAKE, kt.TENKE };
            return kethuoc;
        }
        #endregion

        #region Thêm xóa sửa kệ thuốc
        public int Them_KE(string make, string tenke)
        {
            KETHUOC kt = new KETHUOC { MAKE = make, TENKE = tenke };
            try
            {
                QLNT.KETHUOCs.InsertOnSubmit(kt);
                QLNT.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Xoa_Bac(string MaKe)
        {
            try
            {
                var kt = QLNT.KETHUOCs.Where(t => t.MAKE == MaKe).Single();

                QLNT.KETHUOCs.DeleteOnSubmit(kt);
                QLNT.SubmitChanges();
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int Sua(string tenke)
        {
            try
            {
                KETHUOC kt = QLNT.KETHUOCs.FirstOrDefault();
                kt.TENKE = tenke;

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
