using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class QuanHuyenDALBLL
    {
        QLNTTDataContext data = new QLNTTDataContext();

        #region Load dữ liệu
        public IQueryable getQuanHuyen()
        {
            var dgv_quanhuyen = from qh in data.QUANHUYENs select new { qh.MAQUANHUYEN, qh.MATINHTHANH, qh.TENQUANHUYEN };
            return dgv_quanhuyen;
        }

        public IQueryable getQuanHuyen(string maTinhThanh)
        {
            var dgv_quanhuyen = from qh in data.QUANHUYENs where qh.MATINHTHANH == maTinhThanh select new { qh.MAQUANHUYEN, qh.MATINHTHANH, qh.TENQUANHUYEN };
            return dgv_quanhuyen;
        }

        public List<QUANHUYEN> getQuanHuyenLst()
        {
            return data.QUANHUYENs.Select(k => k).ToList<QUANHUYEN>();
        }
        #endregion

        #region Thêm xóa sửa quận huyện
        public bool insertQuanHuyen(string maQH, string maTT, string tenQH)
        {
            try
            {
                QUANHUYEN quanhuyen = new QUANHUYEN();
                quanhuyen.MAQUANHUYEN = maQH;
                quanhuyen.MATINHTHANH = maTT;
                quanhuyen.TENQUANHUYEN = tenQH;
                data.QUANHUYENs.InsertOnSubmit(quanhuyen);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteQuanHuyen(string maQH)
        {
            try
            {
                QUANHUYEN quanhuyen = data.QUANHUYENs.Where(t => t.MAQUANHUYEN == maQH).FirstOrDefault();
                data.QUANHUYENs.DeleteOnSubmit(quanhuyen);
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
