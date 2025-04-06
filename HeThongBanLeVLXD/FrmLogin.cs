using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HeThongBanLeVLXD
{
    public partial class FrmLogin : Form
    {
        public string usernamed;
        public string roled;
        public FrmLogin()
        {
            InitializeComponent();
        }
        private bool UserLogin(Account account)
        {
            DataProvider dp = new DataProvider();
            roled = dp.CheckLogin(account);
            if (roled != null)
            {
                return true;
            }
            return false;
            
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
       
            string user, pass;
            user = txtTenDangNhap.Text.Trim();
            usernamed = user;
            pass = txtMatKhau.Text;

            Account acc = new Account(user, pass);

            if (UserLogin(acc) == true)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
