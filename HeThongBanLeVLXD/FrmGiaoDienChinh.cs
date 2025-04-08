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
        public FrmGiaoDienChinh()
        {
            InitializeComponent();
        }

        private void FrmGiaoDienChinh_Load(object sender, EventArgs e)
        {
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
                    label7.Text= Frmlogin.usernamed;
                }
                else if (Frmlogin.roled == "NhanVienBanHang")
                {
                    FrmNhanVien frmNhanVien = new FrmNhanVien();
                    frmNhanVien.usna_NV = Frmlogin.usernamed; // truyền username từ FrmLogin
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
