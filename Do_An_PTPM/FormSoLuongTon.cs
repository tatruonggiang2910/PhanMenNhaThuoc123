using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_BLL;

namespace Do_An_CNPM
{
    public partial class FormSoLuongTon : Form
    {
        public FormSoLuongTon()
        {
            InitializeComponent();
        }

        ThuocDAL_BLL _THUOC = new ThuocDAL_BLL();
        DateTime ngayHomNay = System.DateTime.Now;
        WordExport wordExport = new WordExport();

        private void FormSoLuongTon_Load(object sender, EventArgs e)
        {
            GvThuoc.DataSource = _THUOC.Load_thuoc();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (swSoLuongTon.Value)
                {
                    GvThuoc.DataSource = _THUOC.Search_SoLuongTon(integerInput1.Value, integerInput2.Value);
                }
                if (swNgayHetHan.Value)
                {
                    GvThuoc.DataSource = _THUOC.Search_NgayHetHan(dateTimeInput1.Value, dateTimeInput2.Value);
                }
                if (swThuocHetHan.Value)
                {
                    GvThuoc.DataSource = _THUOC.Search_ThuocHetHan(ngayHomNay);
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng thử lại", "Thông báo");
                return;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            swNgayHetHan.Value = swSoLuongTon.Value = swThuocHetHan.Value = false;
            integerInput1.Text = integerInput2.Text = dateTimeInput1.Text = dateTimeInput2.Text = string.Empty;
            GvThuoc.DataSource = _THUOC.Load_thuoc();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void swThuocHetHan_ValueChanged(object sender, EventArgs e)
        {
            btnXuat.Enabled = swThuocHetHan.Value;
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            List<THUOC> ThuocHetHan = _THUOC.XuatThuocHetHan(ngayHomNay);

            int i = 1;
            string Ngay = ngayHomNay.Day.ToString();
            string Thang = ngayHomNay.Month.ToString();
            string Nam = ngayHomNay.Year.ToString();
            string STT = "0";
            string TenThuoc = "";
            string DVT = "";
            string SoLo = "";
           
            string HanSuDung = "";
            string SoLuongTon = "";
            string NgaySanXuat = "";

            foreach (THUOC item in ThuocHetHan)
            {
                STT = STT + i.ToString() + "\n";
                TenThuoc = TenThuoc + item.TENTHUOC.ToString() + "\n";
                DVT = DVT + item.DVT.ToString() + "\n";
                SoLo = SoLo + item.SOLOTHUOC.ToString() + "\n";
                NgaySanXuat = NgaySanXuat + item.NGAYSANXUAT.ToString("dd/MM/yyyy") + "\n";
                HanSuDung = HanSuDung + item.HANSUDUNG.ToString("dd/MM/yyyy") + "\n";
                SoLuongTon = SoLuongTon + item.SOLUONGTON.ToString() + "\n";
                i++;
            }

            wordExport.XuLyThuocHetHan(Ngay, Thang, Nam, DangNhap.nv.HOTENNV, STT, TenThuoc, DVT, SoLo, NgaySanXuat, HanSuDung, SoLuongTon);
           
        }
    }
}
