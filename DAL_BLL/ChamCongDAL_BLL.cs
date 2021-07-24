using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class ChamCongDAL_BLL
    {
        QLNTTDataContext _QLNTT = new QLNTTDataContext();

        #region Load dữ liệu
        public IQueryable Load_chamcong()
        {
            return (from cc in _QLNTT.CHAMCONGs
                    join nv in _QLNTT.NHANVIENs on cc.MANV equals nv.MANV
                    select new { cc.MANV, cc.MACHAMCONG, nv.HOTENNV, cc.THANG, cc.NAM, cc.SONGAYLAMVIEC });
        }
        public IQueryable Load_chamcongNV(string MaNV)
        {
            return (from chcong in _QLNTT.CHAMCONGs
                    where chcong.MANV == MaNV
                    select new { chcong.MACHAMCONG, chcong.MANV, chcong.THANG, chcong.NAM, chcong.SONGAYLAMVIEC });
        }

        #endregion

        #region Thêm xóa sửa chấm công
        public void chamCong(string mcc, string mnv, int soNgayLam)
        {
            CHAMCONG cc = _QLNTT.CHAMCONGs.Where(t => t.MACHAMCONG == mcc && t.MANV == mnv).FirstOrDefault();
            cc.SONGAYLAMVIEC = soNgayLam + 1;
            _QLNTT.SubmitChanges();
        }
        public void insertCC(string mcc, string mnv, int thang, int nam, int songaylam)
        {
            CHAMCONG d = new CHAMCONG { MACHAMCONG = mcc, MANV = mnv, THANG = thang, NAM = nam, SONGAYLAMVIEC = songaylam };
            _QLNTT.CHAMCONGs.InsertOnSubmit(d);
            _QLNTT.SubmitChanges();
        }
        public void deleteCC(string mcc, string mnv)
        {
            CHAMCONG diem = _QLNTT.CHAMCONGs.Where(t => (t.MACHAMCONG == mcc && t.MANV == mnv)).FirstOrDefault();
            _QLNTT.CHAMCONGs.DeleteOnSubmit(diem);
            _QLNTT.SubmitChanges();
        }
        #endregion
    }
}
