using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanLeVLXD
{

    public partial class FrmNhanVien : Form
    {
        public FrmNhanVien()
        {
            InitializeComponent();
        }
        public string usna_NV;
        public string ma_NV;
   //     DataProvider dp = new DataProvider();
        private FrmNhanVienBL frmNhanVienBL;

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            frmNhanVienBL = new FrmNhanVienBL();
            lbMaNhanVien.Text = ma_NV;
            usna_NV = frmNhanVienBL.tenNhanVienBL(ma_NV); //Phải gọi tên Nhân Viên Của FrmNhanVienBL
            lbTenNhanVien.Text = usna_NV;
            
        }
        
        private void FrmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnQlyNguoiDung_Click(object sender, EventArgs e) //Bán lẻ
        {
            ChucNangNhanVien.ucBanLe uc_ban_le = new ChucNangNhanVien.ucBanLe();
            uc_ban_le.tenNhanVien = lbMaNhanVien.Text;
            uc_ban_le.maNhanVien = lbTenNhanVien.Text;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uc_ban_le);
            uc_ban_le.Show();
        }

        private void btnQlySanPham_Click(object sender, EventArgs e) //Thanh Toán Công Nợ
        {
            ChucNangNhanVien.ucThanhToanCongNo uc_thanh_toan = new ChucNangNhanVien.ucThanhToanCongNo();
            uc_thanh_toan.tenNhanVien = lbMaNhanVien.Text;
            uc_thanh_toan.maNhanVien = lbTenNhanVien.Text;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(uc_thanh_toan);
            uc_thanh_toan.Show();
        }

        private void btnInFile_Click(object sender, EventArgs e)
        {
            ChucNangNhanVien.ucXuatHoaDon ucXuatHoaDon = new ChucNangNhanVien.ucXuatHoaDon();
            ucXuatHoaDon.tenNhanVien = lbMaNhanVien.Text;
            ucXuatHoaDon.maNhanVien = lbTenNhanVien.Text;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(ucXuatHoaDon);
            ucXuatHoaDon.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
