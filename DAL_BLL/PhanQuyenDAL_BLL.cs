using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_BLL
{
    public class PhanQuyenDAL_BLL
    {
        QLNTTDataContext QLNT = new QLNTTDataContext();

        #region Load dữ liệu
        public bool capNhatNhomQuyen(string maNV, string maNhomNV)
        {
            NHANVIEN nhanvien = QLNT.NHANVIENs.Where(k => k.MANV == maNV).FirstOrDefault();
            if (nhanvien != null)
            {
                nhanvien.MANHOMNV = maNhomNV;
                QLNT.SubmitChanges();
                return true;
            }
            return false;
        }

        public IQueryable load_QuyenChuaCo(string maNhomQuyen)
        {
            return (from pq in QLNT.PHANQUYENs
                    join dmmh in QLNT.DANHMUCMANHINHs on pq.MADMMH equals dmmh.MADMMH
                    where (pq.MANHOMNV == maNhomQuyen && pq.COQUYEN == false)
                    select new { dmmh.MADMMH, dmmh.TENMANHINH });
        }

        public IQueryable load_QuyenCo(string maNhomQuyen)
        {
            return (from tk in QLNT.PHANQUYENs
                    where (tk.MANHOMNV == maNhomQuyen && tk.COQUYEN == true)
                    select new { tk.DANHMUCMANHINH.MADMMH, tk.DANHMUCMANHINH.TENMANHINH });
        }

        public List<PHANQUYEN> load_QuyenChuaCo1(string maNhomQuyen)
        {
            List<PHANQUYEN> pq = new List<PHANQUYEN>();
            var DMMH = (from dm in QLNT.PHANQUYENs
                       where (dm.MANHOMNV == maNhomQuyen && dm.COQUYEN == false)
                       select dm).ToList();
            pq.AddRange(DMMH);
            return pq;
        }
        #endregion

        #region Thêm xóa quyền hạn

        public void themQuyen(string maNhomQuyen, string maDMMH)
        {
            PHANQUYEN PQ = QLNT.PHANQUYENs.Where(t => t.MANHOMNV == maNhomQuyen && t.MADMMH == maDMMH).FirstOrDefault();
            PQ.COQUYEN = true;
            QLNT.SubmitChanges();
        }
        public void xoaQuyen(string maNhomQuyen, string maDMMH)
        {
            PHANQUYEN PQ = QLNT.PHANQUYENs.Where(t => t.MANHOMNV == maNhomQuyen && t.MADMMH == maDMMH).FirstOrDefault();
            PQ.COQUYEN = false;
            QLNT.SubmitChanges();
        }

        #endregion
    }
}
