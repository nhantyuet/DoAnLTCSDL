using BUS;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongBanLeVLXD
{
    public partial class FrmGiaoDienChinh : Form
    {
        private FrmGiaoDienChinhBL frmGiaoDienChinhBL;
        public FrmGiaoDienChinh()
        {
            InitializeComponent();
        }

        private void FrmGiaoDienChinh_Load(object sender, EventArgs e)
        {
            frmGiaoDienChinhBL = new FrmGiaoDienChinhBL();
            this.Hide();
            FrmLogin Frmlogin = new FrmLogin();
            DialogResult result = Frmlogin.ShowDialog();

            if (result == DialogResult.OK)
            {
                //this.Enabled = true;
                if (Frmlogin.roled == "ChuCuaHang")
                {
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    lbMaNhanVien.Text= Frmlogin.usernamed;
                    lbTenNhanVien.Text = frmGiaoDienChinhBL.tenNhanVienBL(Frmlogin.usernamed);
                }
                else if (Frmlogin.roled == "NhanVienBanHang")
                {
                    FrmNhanVien frmNhanVien = new FrmNhanVien();
                    frmNhanVien.ma_NV = Frmlogin.usernamed; // truyền username từ FrmLogin
                    this.WindowState = FormWindowState.Normal;
                    frmNhanVien.Show();
                    this.Hide();
                }
            }
            else
            {
                Application.Exit();
            }
        }

 
    }
}
