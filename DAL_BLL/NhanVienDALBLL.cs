using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_BLL;
namespace DAL_BLL
{
    public class NhanVienDALBLL
    {
        QLNTTDataContext data = new QLNTTDataContext();

        #region Đăng nhập

        public List<NHANVIEN> checkDangNhap(string tk, string mk)
        {
            return data.NHANVIENs.Where(t => t.TENDANGNHAP == tk && t.MATKHAU == mk).ToList();
        }

        public bool kiemTraTk(string tk, string mk)
        {
            NHANVIEN nhanvien = data.NHANVIENs.Where(t => t.TENDANGNHAP == tk && t.MATKHAU == mk).FirstOrDefault();
            if (nhanvien == null)
                return false;
            else
                return true;
        }

        public bool doiMatKhau(string tk, string mk)
        {
            NHANVIEN nhanvien = data.NHANVIENs.Where(k => k.TENDANGNHAP == tk).FirstOrDefault();
            if (nhanvien != null)
            {
                nhanvien.MATKHAU = mk;
                data.SubmitChanges();
                return true;
            }
            return false;
        }

        #endregion

        #region Load dữ liệu

        public List<NHANVIEN> getNhanVien()
        {
            return data.NHANVIENs.Select(k => k).ToList<NHANVIEN>();
        }
        public IQueryable load_NV_Search()
        {
            return (from th in data.NHANVIENs.Select(p => p)
                    select new
                    {
                        th.MANV,
                        th.MANHOMNV,
                        th.HOTENNV,
                        th.GIOITINHNV,
                        th.NGAYSINHNV,
                        th.DIACHINV,
                        th.SODIENTHOAINV,
                        th.NGAYBATDAULAMVIEC,
                        th.NGAYKETTHUCLAMVIEC,
                        th.TRINHDOHOCVAN
                    });
        }
        public IQueryable load_manv()
        {
            var manv = from Ma in data.NHANVIENs
                       select new { Ma.MANV };
            return manv;
        }
        public List<NHOMNHANVIEN> getNhomNV()
        {
            return data.NHOMNHANVIENs.Select(k => k).ToList<NHOMNHANVIEN>();
        }

        #endregion

        #region Thêm xóa sửa nhân viên

        public bool insertNhanVien(string maNV, string tenDN, string matKh, string sDT, string maNhom,string hoTen, string gioiTinh, string ngaySinh, string diaChi, string luongCoBan, string cmnd, string ngayBDL, string ngayKTL, string trinhDo)
        {
            try
            {
                NHANVIEN nhanvien = new NHANVIEN();
                nhanvien.MANV = maNV;
                nhanvien.TENDANGNHAP = tenDN;
                nhanvien.MATKHAU = matKh;
                nhanvien.SODIENTHOAINV = sDT;
                nhanvien.MANHOMNV = maNhom;
                nhanvien.HOTENNV = hoTen;
                nhanvien.GIOITINHNV = gioiTinh;
                nhanvien.NGAYSINHNV = Convert.ToDateTime(ngaySinh);
                nhanvien.DIACHINV = diaChi;
                nhanvien.MUCLUONGCOBAN = Convert.ToDecimal(luongCoBan);
                nhanvien.CHUNGMINHTHU = cmnd;
                nhanvien.NGAYBATDAULAMVIEC = Convert.ToDateTime(ngayBDL);
                nhanvien.NGAYKETTHUCLAMVIEC = Convert.ToDateTime(ngayKTL);
                nhanvien.TRINHDOHOCVAN = trinhDo;
                data.NHANVIENs.InsertOnSubmit(nhanvien);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
            //NHANVIEN nhanvien = new NHANVIEN();
            //nhanvien.MANV = maNV;
            //nhanvien.TENDANGNHAP = tenDN;
            //nhanvien.MATKHAU = matKh;
            //nhanvien.SODIENTHOAINV = sDT;
            //nhanvien.MANHOMNV = maNhom;
            //nhanvien.HOTENNV = hoTen;
            //nhanvien.GIOITINHNV = gioiTinh;
            //nhanvien.NGAYSINHNV = Convert.ToDateTime(ngaySinh);
            //nhanvien.DIACHINV = diaChi;
            //nhanvien.MUCLUONGCOBAN = Convert.ToDecimal(luongCoBan);
            //nhanvien.CHUNGMINHTHU = cmnd;
            //nhanvien.NGAYBATDAULAMVIEC = Convert.ToDateTime(ngayBDL);
            //nhanvien.NGAYKETTHUCLAMVIEC = Convert.ToDateTime(ngayKTL);
            //nhanvien.TRINHDOHOCVAN = trinhDo;
            //data.NHANVIENs.InsertOnSubmit(nhanvien);
            //data.SubmitChanges();
            //return true;
        }
        public bool updateNhanVien(string maNV, string tenDN, string matKh, string sDT, string maNhom, string hoTen, string gioiTinh, string ngaySinh, string diaChi, string luongCoBan, string cmnd, string ngayBDL, string ngayKTL, string trinhDo)
        {
            NHANVIEN nhanvien = data.NHANVIENs.Where(k => k.MANV == maNV).FirstOrDefault();
            if (nhanvien != null)
            {
                nhanvien.MANV = maNV;
                nhanvien.TENDANGNHAP = tenDN;
                nhanvien.MATKHAU = matKh;
                nhanvien.SODIENTHOAINV = sDT;
                nhanvien.MANHOMNV = maNhom;
                nhanvien.HOTENNV = hoTen;
                nhanvien.GIOITINHNV = gioiTinh;
                nhanvien.NGAYSINHNV = Convert.ToDateTime(ngaySinh);
                nhanvien.DIACHINV = diaChi;
                nhanvien.MUCLUONGCOBAN = Convert.ToDecimal(luongCoBan);
                nhanvien.CHUNGMINHTHU = cmnd;
                nhanvien.NGAYBATDAULAMVIEC = Convert.ToDateTime(ngayBDL);
                nhanvien.NGAYKETTHUCLAMVIEC = Convert.ToDateTime(ngayKTL);
                nhanvien.TRINHDOHOCVAN = trinhDo;
                data.SubmitChanges();
                return true;
            }
            return false;
        }
        public bool deleteNhanVien(string maNV)
        {
            try
            {
                NHANVIEN nhanvien = data.NHANVIENs.Where(t => t.MANV == maNV).FirstOrDefault();
                data.NHANVIENs.DeleteOnSubmit(nhanvien);
                data.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Tìm kiếm nhân viên

        public IQueryable search_MaNV(string maNV)
        {
            return (from th in data.NHANVIENs.Where(p => p.MANV.Contains(maNV))
                    select new
                    {
                        th.MANV,
                        th.MANHOMNV,
                        th.HOTENNV,
                        th.GIOITINHNV,
                        th.NGAYSINHNV,
                        th.DIACHINV,
                        th.SODIENTHOAINV,
                        th.NGAYBATDAULAMVIEC,
                        th.NGAYKETTHUCLAMVIEC,
                        th.TRINHDOHOCVAN
                    });
        }

        public IQueryable search_HoTen(string hoTen)
        {
            return (from th in data.NHANVIENs.Where(p => p.HOTENNV.Contains(hoTen))
                    select new
                    {
                        th.MANV,
                        th.MANHOMNV,
                        th.HOTENNV,
                        th.GIOITINHNV,
                        th.NGAYSINHNV,
                        th.DIACHINV,
                        th.SODIENTHOAINV,
                        th.NGAYBATDAULAMVIEC,
                        th.NGAYKETTHUCLAMVIEC,
                        th.TRINHDOHOCVAN
                    });
        }

        public IQueryable search_MaNhom(string maNhom)
        {
            return (from th in data.NHANVIENs.Where(p => p.MANHOMNV.Contains(maNhom))
                    select new
                    {
                        th.MANV,
                        th.MANHOMNV,
                        th.HOTENNV,
                        th.GIOITINHNV,
                        th.NGAYSINHNV,
                        th.DIACHINV,
                        th.SODIENTHOAINV,
                        th.NGAYBATDAULAMVIEC,
                        th.NGAYKETTHUCLAMVIEC,
                        th.TRINHDOHOCVAN
                    });
        }

        public IQueryable search_NgayBDL(DateTime NgayBDL)
        {
            return (from th in data.NHANVIENs.Where(p => p.NGAYBATDAULAMVIEC == NgayBDL)
                    select new
                    {
                        th.MANV,
                        th.MANHOMNV,
                        th.HOTENNV,
                        th.GIOITINHNV,
                        th.NGAYSINHNV,
                        th.DIACHINV,
                        th.SODIENTHOAINV,
                        th.NGAYBATDAULAMVIEC,
                        th.NGAYKETTHUCLAMVIEC,
                        th.TRINHDOHOCVAN
                    });
        }

        public IQueryable search_GioiTinh(string gioiTinh)
        {
            return (from th in data.NHANVIENs.Where(p => p.GIOITINHNV.Contains(gioiTinh))
                    select new
                    {
                        th.MANV,
                        th.MANHOMNV,
                        th.HOTENNV,
                        th.GIOITINHNV,
                        th.NGAYSINHNV,
                        th.DIACHINV,
                        th.SODIENTHOAINV,
                        th.NGAYBATDAULAMVIEC,
                        th.NGAYKETTHUCLAMVIEC,
                        th.TRINHDOHOCVAN
                    });
        }

        #endregion
    }
}
