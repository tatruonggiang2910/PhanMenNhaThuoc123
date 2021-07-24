using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_BLL;
namespace DAL_BLL
{
    public class NhaCungCapDALBLL
    {
        QLNTTDataContext data = new QLNTTDataContext();

        #region Load dữ liệu
        public IQueryable Load_NhaCungCap()
        {
            var ncc = from Ncc in data.NHACUNGCAPs select Ncc;
            return ncc;

        }
        public IQueryable Load_MaNhaCungCap()
        {
            var ncc = from Ncc in data.NHACUNGCAPs select new { Ncc.MANCC, Ncc.TENNHACUNGCAP };
            return ncc;

        }
        public IQueryable Load_ncc1(string mapn)
        {
            var ncc = from pn1 in data.NHACUNGCAPs
                      join Hd in data.PHIEUNHAPTHUOCs
                          on pn1.MANCC equals Hd.MANCC
                      where Hd.MAPNT == mapn
                      select new { pn1.TENNHACUNGCAP, pn1.MANCC };
            return ncc;

        }
        public IQueryable getNhaCungCap()
        {
            var dgv_nhacc = from ncc in data.NHACUNGCAPs select new { ncc.MANCC, ncc.MAQUANHUYEN, ncc.TENNHACUNGCAP, ncc.DIACHI, ncc.SDT };
            return dgv_nhacc;
        }
        public List<NHACUNGCAP> getNhaCungCapLst()
        {
            return data.NHACUNGCAPs.Select(k => k).ToList<NHACUNGCAP>();
        }
        #endregion

        #region Thêm xóa sửa nhà cung cấp
        public bool insertNhaCC(string maNCC, string maQH, string tenNCC, string diaChi, string sDT)
        {
            try
            {
                NHACUNGCAP nhacungcap = new NHACUNGCAP();
                nhacungcap.MANCC = maNCC;
                nhacungcap.MAQUANHUYEN = maQH;
                nhacungcap.TENNHACUNGCAP = tenNCC;
                nhacungcap.DIACHI = diaChi;
                nhacungcap.SDT = sDT;
                data.NHACUNGCAPs.InsertOnSubmit(nhacungcap);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool deleteNhaCC(string maNCC)
        {
            try
            {
                NHACUNGCAP nhacungcap = data.NHACUNGCAPs.Where(t => t.MANCC == maNCC).FirstOrDefault();
                data.NHACUNGCAPs.DeleteOnSubmit(nhacungcap);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool updateNhaCC(string maNCC, string maQH, string tenNCC, string diaChi, string sDT)
        {

            NHACUNGCAP nhacungcap = data.NHACUNGCAPs.Where(k => k.MANCC == maNCC).FirstOrDefault();
            if (nhacungcap != null)
            {
                nhacungcap.MAQUANHUYEN = maQH;
                nhacungcap.TENNHACUNGCAP = tenNCC;
                nhacungcap.DIACHI = diaChi;
                nhacungcap.SDT = sDT;
                data.SubmitChanges();
                return true;
            }
            return false;
        }
        #endregion
    }
}
