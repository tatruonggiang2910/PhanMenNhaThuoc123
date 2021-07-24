using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace DAL_BLL
{
    public class TinhThanhDALBLL
    {
        QLNTTDataContext data = new QLNTTDataContext();

        #region Load dữ liệu
        public List<TINHTHANH> getTinhThanh()
        {
            return data.TINHTHANHs.Select(k => k).ToList<TINHTHANH>();
        }
        #endregion

        #region Thêm xóa sửa tỉnh  thành
        public bool insertTinhThanh(string maTT, string tenTT)
        {
            try
            {
                TINHTHANH tinhthanh = new TINHTHANH();
                tinhthanh.MATINHTHANH = maTT;
                tinhthanh.TENTINHTHANH = tenTT;
                data.TINHTHANHs.InsertOnSubmit(tinhthanh);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteTinhThanh(string maTT)
        {
            try
            {
                TINHTHANH tinhthanh = data.TINHTHANHs.Where(t => t.MATINHTHANH == maTT).FirstOrDefault();
                data.TINHTHANHs.DeleteOnSubmit(tinhthanh);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
