using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HeThongBanLeVLXD
{
    public partial class FrmLogin : Form
    {
        public string usernamed;
        public string maNVed;
        private LoginBL loginBL;
        public string roled;
        public FrmLogin()
        {
            InitializeComponent();
        }
        private bool UserLogin(TaiKhoan tk)
        {
            loginBL = new LoginBL();
            try
            {
                roled = loginBL.CheckLoginBL(tk);
                if (loginBL.CheckLoginBL(tk) == "ChuCuaHang" || loginBL.CheckLoginBL(tk) == "NhanVienBanHang")
                {
                    return true;
                }
                return false;
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
    
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
       
            if(txtTenDangNhap.Text==""|| txtMatKhau.Text=="")
            {
                MessageBox.Show("Vui Long Nhap SDT_Khach_Hang", MessageBoxButtons.OK.ToString());
                return;
            }    
            string user, pass;
            user = txtTenDangNhap.Text.Trim();
            usernamed = user;
            pass = txtMatKhau.Text;

            TaiKhoan tk = new TaiKhoan(user, pass);

            if (UserLogin(tk) == true)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult result = MessageBox.Show("Username and password are incorrect!", "Login", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Retry)
                {
                    txtTenDangNhap.Clear();
                    txtMatKhau.Clear();
                }
                else
                    this.DialogResult = DialogResult.Cancel;
            }
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = checkBox1.Checked ? '\0':'*';
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
