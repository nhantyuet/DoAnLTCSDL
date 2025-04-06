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
            this.Show();
            this.Enabled = false;
            FrmLogin Frmlogin = new FrmLogin();
            DialogResult result = Frmlogin.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.Enabled = true;
                if (Frmlogin.roled == "ChuCuaHang")
                {
                    pn_Chu.Visible = true;
                    label4.Text = Frmlogin.usernamed;
                }
                else
                {
                    pn_NV.Visible = true;
                    label6.Text = Frmlogin.usernamed;
                }    
                //label4.Text = Frmlogin.usernamed;
                //label5.Text = Frmlogin.roled;
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
