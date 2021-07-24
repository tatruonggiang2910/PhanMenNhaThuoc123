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
using System.Speech.Recognition;

namespace Do_An_CNPM
{
    public partial class FormThuoc : Form
    {
        ThuocDAL_BLL Thuoc = new ThuocDAL_BLL();
        HangSXuatDAL_BLL HSX = new HangSXuatDAL_BLL();
        LoaiThuocDAL_BLL LoaiT = new LoaiThuocDAL_BLL();
        XuatXuDAL_BLL XX = new XuatXuDAL_BLL();
        bool RecognizerState = true;
        SpeechRecognitionEngine engine;
        public FormThuoc()
        {
            Speech();

            InitializeComponent();
        }

        void Speech() {
            List<THUOC> tenThuoc = Thuoc.Load_Thuoc_list();
            String[] ten = new String[tenThuoc.Count];
            for(int i = 0; i <= tenThuoc.Count - 1; i++)
            {
                ten[i] = tenThuoc[i].TENTHUOC;
            }
            engine = new SpeechRecognitionEngine();
            engine.SetInputToDefaultAudioDevice();
            GrammarBuilder gb = new GrammarBuilder(new Choices(ten));
            Grammar g = new Grammar(gb);
            engine.LoadGrammar(g);
            RecognizerState = true;
            engine.RecognizeAsync(RecognizeMode.Multiple);
            engine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(engine_SpeechRecognized);
        }

        private void engine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (!RecognizerState)
                return;
            txtSearch.Text += (e.Result.Text);
        }

        private void FormThuoc_Load(object sender, EventArgs e)
        {
            if (DangNhap.nv.MANHOMNV == "NV")
            {
                btnLoadAnh.Enabled = btnThem.Enabled = btnXoa.Enabled = btnTaoMoi.Enabled = buttonX1.Enabled = false;
            }

            Bitmap anh = new Bitmap(@"E:\New folder\PTPM\PTPM\WebTimThuoc\WebTimThuoc\Content\images\acetylsalicylic.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = (Image)anh;
            GVThuoc.DataSource = Thuoc.Load_thuoc();

            cbbHangSX.DataSource = HSX.load_HangSX();
            cbbHangSX.DisplayMember = "TenHSX";
            cbbHangSX.ValueMember = "MaHSX";

            cbbMaLoai.DataSource = LoaiT.load_Loai_Thuoc();
            cbbMaLoai.DisplayMember = "Tenloaithuoc";
            cbbMaLoai.ValueMember = "Maloaithuoc";

            cbbMaXuatXu.DataSource = XX.load_XX();
            cbbMaXuatXu.DisplayMember = "tenxuatxu";
            cbbMaXuatXu.ValueMember = "Maxuatxu";

            cbbDonViTinh.DataSource = Thuoc.load_donvitinh_Thuoc();
            cbbDonViTinh.DisplayMember = "DVT";
            cbbDonViTinh.ValueMember = "DVT";
        }
        public void TangMaTuDong_thuoc()
        {

            string g = "";
            string a = "";
            a = GVThuoc.Rows[GVThuoc.Rows.Count - 1].Cells[0].Value.ToString();

            int ma;
            g = "TH";
            ma = Convert.ToInt32(a.Substring(2, 2));
            ma = ma + 1;
            if (ma < 10)
                g = g + "0";
            if (ma >= 10)
                g = g + "";
            g += ma.ToString();

            txtMaThuoc.Text = g;

        }
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            TangMaTuDong_thuoc();
            txtTenThuoc.Enabled = true;
            cbbHangSX.Text = string.Empty;
            cbbHangSX.Text = string.Empty;
            cbbMaXuatXu.Text = string.Empty;
            cbbMaLoai.Text = string.Empty;
            txtTenThuoc.Text = string.Empty;
            txtThanhPhan.Text = "";
            txtCongDung.Text = "";

            txtBaoQuan.Text = "";
            txtGhiChu.Text = "";
            cbbDonViTinh.Text = "";
            txtSoLo.Text = "";
            txtSoLuongTon.Text = "0";
            txtDonGia.Text = "";
            DTPSanXuat.Text = "";
            DTPHanSD.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            int nam1 = DTPSanXuat.Value.Year;
            int thang1 = DTPSanXuat.Value.Month;
            int ngay1 = DTPSanXuat.Value.Day;
            int nam = DTPHanSD.Value.Year;
            int thang = DTPHanSD.Value.Month;
            int ngay = DTPHanSD.Value.Day;

            if (String.IsNullOrEmpty(txtTenThuoc.Text) || String.IsNullOrEmpty(txtSoLo.Text) || String.IsNullOrEmpty(txtDonGia.Text) || String.IsNullOrEmpty(txtThanhPhan.Text) || String.IsNullOrEmpty(txtCongDung.Text) || String.IsNullOrEmpty(txtGhiChu.Text) || String.IsNullOrEmpty(cbbDonViTinh.Text) || String.IsNullOrEmpty(cbbHangSX.Text) || String.IsNullOrEmpty(cbbMaLoai.Text) || String.IsNullOrEmpty(cbbMaXuatXu.Text))
            {
                MessageBox.Show("Dữ liệu không được để trống", "Thông báo");
                return;
            }
            try
            {
                if (DTPSanXuat.Value >= System.DateTime.Now)
                {
                    MessageBox.Show("ngày sản xuất phải nhỏ hơn ngày hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (nam1 < nam)
                    {
                        Thuoc.Them_Thuoc(txtMaThuoc.Text, cbbMaLoai.SelectedValue.ToString(), cbbHangSX.SelectedValue.ToString(), cbbMaXuatXu.SelectedValue.ToString(),
                               txtTenThuoc.Text, txthinhanh.Text, txtThanhPhan.Text, txtCongDung.Text, txtBaoQuan.Text, txtGhiChu.Text, cbbDonViTinh.SelectedValue.ToString(),
                               int.Parse(txtSoLo.Text), DateTime.Parse(DTPSanXuat.Text), DateTime.Parse(DTPHanSD.Text), decimal.Parse(txtDonGia.Text),
                               int.Parse(txtSoLuongTon.Text));

                        MessageBox.Show("Thêm dữ liệu  thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        GVThuoc.DataSource = Thuoc.Load_thuoc();
                    }
                    else
                    {
                        MessageBox.Show("Năm sản xuất phải nhỏ năm sử dụng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }

            catch
            {
                MessageBox.Show("Thêm dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (Thuoc.Xoa_Thuoc(txtMaThuoc.Text) == 1 && txtSoLuongTon.Text=="0")
                {
                    MessageBox.Show("Xóa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVThuoc.DataSource = Thuoc.Load_thuoc();
                }
                else
                {
                    MessageBox.Show("Xóa dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Xoá dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Thuoc.Sua(txtMaThuoc.Text, cbbMaLoai.SelectedValue.ToString(), cbbHangSX.SelectedValue.ToString(), cbbMaXuatXu.SelectedValue.ToString(),
                    txtTenThuoc.Text, txthinhanh.Text, txtThanhPhan.Text, txtCongDung.Text, txtBaoQuan.Text, txtGhiChu.Text, cbbDonViTinh.SelectedValue.ToString(),
                    int.Parse(txtSoLo.Text), DateTime.Parse(DTPSanXuat.Text), DateTime.Parse(DTPHanSD.Text), decimal.Parse(txtDonGia.Text)
                    ) == 1)
                {
                    MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GVThuoc.DataSource = Thuoc.Load_thuoc();
                }
                else
                {
                    MessageBox.Show("Sửa dữ liệu không thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                //Ke.Sua(txtMaKe.Text, txtTenKe.Text);
                //MessageBox.Show("Sửa dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //GVKeThuoc.DataSource = Ke.load_KeThuoc();             
            }
            catch
            {
            }
        }

        private void GVThuoc_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaThuoc.Text = GVThuoc.CurrentRow.Cells[0].Value.ToString();
                cbbMaLoai.Text = GVThuoc.CurrentRow.Cells[1].Value.ToString();
                cbbHangSX.Text = GVThuoc.CurrentRow.Cells[2].Value.ToString();
                cbbMaXuatXu.Text = GVThuoc.CurrentRow.Cells[3].Value.ToString();
                txtTenThuoc.Text = GVThuoc.CurrentRow.Cells[4].Value.ToString();
                txthinhanh.Text = GVThuoc.CurrentRow.Cells[5].Value.ToString();
                txtThanhPhan.Text = GVThuoc.CurrentRow.Cells[6].Value.ToString();
                txtCongDung.Text = GVThuoc.CurrentRow.Cells[7].Value.ToString();
                txtBaoQuan.Text = GVThuoc.CurrentRow.Cells[8].Value.ToString();
                txtGhiChu.Text = GVThuoc.CurrentRow.Cells[9].Value.ToString();
                cbbDonViTinh.Text = GVThuoc.CurrentRow.Cells[10].Value.ToString();
                txtSoLo.Text = GVThuoc.CurrentRow.Cells[11].Value.ToString();
                DTPSanXuat.Text = GVThuoc.CurrentRow.Cells[12].Value.ToString();
                DTPHanSD.Text = GVThuoc.CurrentRow.Cells[13].Value.ToString();
                txtDonGia.Text = GVThuoc.CurrentRow.Cells[14].Value.ToString();
                txtSoLuongTon.Text = GVThuoc.CurrentRow.Cells[15].Value.ToString();
                Bitmap anh = new Bitmap(@"E:\New folder\PTPM\PTPM\WebTimThuoc\WebTimThuoc\Content\images\" + txthinhanh.Text);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = (Image)anh;



            }
            catch
            { }
        }

        private void btnLoadAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFile = new OpenFileDialog();
            oFile.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            if (oFile.ShowDialog() == DialogResult.OK)
            {
                txthinhanh.Text = oFile.FileName.Substring(oFile.FileName.LastIndexOf("\\") + 1);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSoLo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Nếu bạn muốn, bạn có thể cho phép nhập số thực với dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            FormLoaiThuoc formNew = new FormLoaiThuoc();
            formNew.Show();
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (btnSearch.Text == "Tìm")
            {
                GVThuoc.DataSource = Thuoc.search_tenThuoc(txtSearch.Text);
                btnSearch.Text = "Hủy";
            }
            else
            {
                GVThuoc.DataSource = Thuoc.Load_thuoc();
                btnSearch.Text = "Tìm";
                txtSearch.Text = String.Empty;
            }
        }

        private void switchButton1_ValueChanged(object sender, EventArgs e)
        {
            if (switchButton1.Value)
            {
                RecognizerState = true;
            }
            else
                RecognizerState = false;
        }
    }
}
